using MovieTicketApp.src.Managers;
using RCinema_db.src.Managers;
using RCinema_db.src.User;
using RCinema_db.User;

namespace RCinema_db.Account
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
            lbl_PWLengthWarning.Visible = false;
            lbl_PWMatchWarning.Visible = false;
        }

        private void btn_ChangePW_Click(object sender, EventArgs e)
        {
            string newPassword = textBox_newPW.Text;
            string confirmNewPassword = textBox_confirmPW.Text;

            // Check if the new password is at least 4 characters long
            if (newPassword.Length < 4)
            {
                lbl_PWLengthWarning.Visible = true;
                return;
            }
            else
            {
                lbl_PWLengthWarning.Visible = false;
            }

            // Check if the new password and confirm new password match
            if (newPassword != confirmNewPassword)
            {
                lbl_PWMatchWarning.Visible = true;
                return;
            }
            else
            {
                lbl_PWMatchWarning.Visible = false;
            }

            /*
            User currentUser = CurrentUserManager.Instance.CurrentUser;

            if (currentUser != null)
            {
                UserData.ChangePassword(currentUser.Id, newPassword);
            }
            */

            // Provide feedback to the user (e.g., show a success message)
            UserProfile form = new UserProfile();
            form.Show();
            this.Close();

            FileManager.SaveUserData();
            MessageBox.Show("Password changed successfully.");
        }

        private void btn_BackToMovies_Click(object sender, EventArgs e)
        {
            UserProfile profile = new UserProfile();
            profile.Show();
            this.Close();
        }
    }
}

