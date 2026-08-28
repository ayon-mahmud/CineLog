using CineLog.Solution.Data;
using CineLog.Solution.Models;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace CineLog.Solution.UserControls
{
    public partial class ProfileControl : UserControl
    {
        private readonly User user;
        private Image? avatarImage;

        public ProfileControl(User user)
        {
            InitializeComponent();
            this.user = user;
            pictureBoxAvatar.Paint += PictureBoxAvatar_Paint;
            LoadProfile();
        }

        private void LoadProfile()
        {
            lblUsername.Text = user.Username;
            lblEmail.Text = user.Email;

            int watched = ProfileRepository.GetWatchedCount(user.UserId);
            int lists = ProfileRepository.GetListCount(user.UserId);
            decimal avgRating = ProfileRepository.GetAverageRating(user.UserId);

            lblWatchedCount.Text = $"{watched}\nWatched";
            lblListCount.Text = $"{lists}\nLists";
            lblAvgRating.Text = avgRating > 0 ? $"{avgRating:0.0}\nAvg Rating" : "—\nAvg Rating";
            LoadAvatar();
        }

        public event EventHandler? AccountDeleted;

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                $"Are you sure you want to permanently delete your account, \"{user.Username}\"?\n\n" +
                "This will erase your watchlist, watch history, ratings, reviews, and lists. This cannot be undone.",
                "Delete Account",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                UserRepository.DeleteAccount(user.UserId);
                MessageBox.Show("Your account has been deleted.");
                AccountDeleted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete account: " + ex.Message);
            }
        }

        private void LoadAvatar()
        {
            if (!string.IsNullOrEmpty(user.ProfilePicturePath) && File.Exists(user.ProfilePicturePath))
            {
                avatarImage = LoadImageDetached(user.ProfilePicturePath);
            }

            pictureBoxAvatar.Invalidate();
        }

        private void PictureBoxAvatar_Paint(object? sender, PaintEventArgs e)
        {
            if (avatarImage == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var bounds = pictureBoxAvatar.ClientRectangle;

            using var path = new GraphicsPath();
            path.AddEllipse(bounds);

            using var clippedRegion = new Region(path);
            e.Graphics.SetClip(clippedRegion, CombineMode.Replace);

            e.Graphics.DrawImage(avatarImage, bounds);

            e.Graphics.ResetClip();
            using var pen = new Pen(Color.FromArgb(60, 60, 60), 2);
            e.Graphics.DrawEllipse(pen, 1, 1, bounds.Width - 2, bounds.Height - 2);
        }

        // Loads an image fully into memory (releasing any file lock) and
        // auto-corrects rotation based on the photo's EXIF orientation tag
        private static Image LoadImageDetached(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var image = Image.FromStream(ms);

            const int OrientationId = 0x0112;
            if (Array.IndexOf(image.PropertyIdList, OrientationId) > -1)
            {
                int orientation = image.GetPropertyItem(OrientationId)!.Value[0];
                switch (orientation)
                {
                    case 3: image.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
                    case 6: image.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
                    case 8: image.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
                }
            }

            return image;
        }

        private void btnChangePicture_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
                Title = "Choose a profile picture"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                string appFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "CineLog", "ProfilePictures");
                Directory.CreateDirectory(appFolder);

                string extension = Path.GetExtension(dialog.FileName);
                string savedPath = Path.Combine(appFolder, $"user_{user.UserId}{extension}");

                avatarImage?.Dispose();
                avatarImage = null;

                File.Copy(dialog.FileName, savedPath, overwrite: true);

                UserRepository.UpdateProfilePicture(user.UserId, savedPath);
                user.ProfilePicturePath = savedPath;

                avatarImage = LoadImageDetached(savedPath);
                pictureBoxAvatar.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update profile picture: " + ex.Message);
            }
        }
    }
}