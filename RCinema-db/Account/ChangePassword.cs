using RCinema_db.User;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace RCinema_db.Account
{
    public partial class ChangePassword : Form
    {
        private int _userId; // Хранение UserID для изменения пароля

        public ChangePassword(int userId)
        {
            InitializeComponent();
            lbl_PWLengthWarning.Visible = false;
            lbl_PWMatchWarning.Visible = false;

            _userId = userId; // Сохраняем UserID, переданный в конструктор
        }

        private void btn_BackToMovies_Click(object sender, EventArgs e)
        {
            UserProfile profile = new UserProfile(_userId);
            profile.Show();
            this.Close();
        }
        private void btn_BackToMovies_Click_1(object sender, EventArgs e)
        {
            UserProfile profile = new UserProfile(_userId);
            profile.Show();
            this.Close();
        }

        private void btn_ChangePW_Click_1(object sender, EventArgs e)
        {
            string newPassword = textBox_newPW.Text;
            string confirmNewPassword = textBox_confirmPW.Text;

            // Проверка длины пароля
            if (newPassword.Length < 4)
            {
                lbl_PWLengthWarning.Visible = true;
                return;
            }
            else
            {
                lbl_PWLengthWarning.Visible = false;
            }

            // Проверка совпадения пароля
            if (newPassword != confirmNewPassword)
            {
                lbl_PWMatchWarning.Visible = true;
                return;
            }
            else
            {
                lbl_PWMatchWarning.Visible = false;
            }

            // Debugging: Print the _userId to check if it's correct
            Debug.WriteLine($"Attempting to change password for UserID: {_userId}");

            // Сохранение нового пароля в базе данных
            try
            {
                using (SqlConnection conn = Database.DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        string query = "UPDATE Account SET Password = @Password WHERE UserID = @UserID";
                        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Password", newPassword);
                            cmd.Parameters.AddWithValue("@UserID", _userId);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                MessageBox.Show("Пароль успешно изменен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Ошибка: пользователь не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении пароля: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UserProfile form = new UserProfile(_userId);
            form.Show();
            this.Close();
        }
    }
}
