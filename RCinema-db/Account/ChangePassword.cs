using RCinema_db.src.Managers;
using RCinema_db.User;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace RCinema_db.Account
{
    public partial class ChangePassword : Form
    {
        private int _userId;

        public ChangePassword()
        {
            InitializeComponent();
            _userId = CurrentUserManager.Instance.CurrentUser?.Id ?? 0;

            lbl_PWLengthWarning.Visible = false;
            lbl_PWMatchWarning.Visible = false;

        }

        private void btn_BackToMovies_Click(object sender, EventArgs e)
        {
            Movies moviesForm = new Movies(_userId);
            moviesForm.Show();
            this.Close();
        }

        private void btn_ChangePW_Click(object sender, EventArgs e)
        {
            string newPassword = textBox_newPW.Text;
            string confirmNewPassword = textBox_confirmPW.Text;

            if (newPassword.Length < 4)
            {
                lbl_PWLengthWarning.Visible = true;
                return;
            }
            lbl_PWLengthWarning.Visible = false;

            if (newPassword != confirmNewPassword)
            {
                lbl_PWMatchWarning.Visible = true;
                return;
            }
            lbl_PWMatchWarning.Visible = false;

            try
            {
                using (SqlConnection conn = Database.DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Account SET Password = @Password WHERE UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Password", newPassword);
                        cmd.Parameters.AddWithValue("@UserID", _userId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password changed successfully", "Success");
                        }
                        else
                        {
                            MessageBox.Show("User not found", "Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error changing password: {ex.Message}");
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }

            UserProfile form = new UserProfile(_userId);
            form.Show();
            this.Close();
        }
    }
}
