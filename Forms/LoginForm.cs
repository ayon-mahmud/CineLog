using CineLog.Solution.Data;
using CineLog.Solution.Forms;

namespace CineLog.Solution.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Please enter username and password.";
                return;
            }

            var user = UserRepository.Login(username, password);

            if (user == null)
            {
                lblError.Text = "Invalid username or password.";
                return;
            }

            var main = new MainForm(user);
            main.Show();
            this.Hide();
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var register = new RegisterForm();
            register.ShowDialog();
        }
    }
}