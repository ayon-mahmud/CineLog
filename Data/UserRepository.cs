using System;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using CineLog.Solution.Models;

namespace CineLog.Solution.Data
{
    public static class UserRepository
    {
        // Returns the new UserId, or throws if username/email already exists
        public static int Register(string username, string email, string plainPassword)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword);

            using var conn = Database.GetConnection();
            string sql = "INSERT INTO Users (Username, Email, PasswordHash) " +
                         "VALUES (@username, @email, @hash); " +
                         "SELECT LAST_INSERT_ID();";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@hash", passwordHash);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // Returns the matching User if the password is correct, otherwise null
        public static User? Login(string username, string plainPassword)
        {
            using var conn = Database.GetConnection();
            string sql = "SELECT UserId, Username, Email, PasswordHash, CreatedAt, ProfilePicturePath " +
                         "FROM Users WHERE Username = @username;";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null; // no such username

            string storedHash = reader.GetString("PasswordHash");
            if (!BCrypt.Net.BCrypt.Verify(plainPassword, storedHash))
                return null; // wrong password

            return new User
            {
                UserId = reader.GetInt32("UserId"),
                Username = reader.GetString("Username"),
                Email = reader.GetString("Email"),
                PasswordHash = storedHash,
                CreatedAt = reader.GetDateTime("CreatedAt"),
                ProfilePicturePath = reader.IsDBNull(reader.GetOrdinal("ProfilePicturePath")) ? null : reader.GetString("ProfilePicturePath")
            };
        }

        public static void DeleteAccount(int userId)
        {
            using var conn = Database.GetConnection();
            string sql = "DELETE FROM Users WHERE UserId = @userId;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateProfilePicture(int userId, string filePath)
        {
            using var conn = Database.GetConnection();
            string sql = "UPDATE Users SET ProfilePicturePath = @path WHERE UserId = @userId;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@path", filePath);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.ExecuteNonQuery();
        }
    }
}