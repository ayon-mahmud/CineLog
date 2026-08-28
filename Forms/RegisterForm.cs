using CineLog.Solution.Data;

namespace CineLog.Solution.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "All fields are required.";
                return;
            }

            if (password != confirmPassword)
            {
                lblError.Text = "Passwords do not match.";
                return;
            }

            try
            {
                int newUserId = UserRepository.Register(username, email, password);
                MessageBox.Show("Account created! Please log in.");
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry"))
                    lblError.Text = "Username or email already taken.";
                else
                    lblError.Text = "Registration failed: " + ex.Message;
            }
        }
    }
}