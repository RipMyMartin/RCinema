using RCinema_db.Account;
using RCinema_db.Admin;
using RCinema_db.src.Managers;
using RCinema_db.User;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace RCinema_db.Account
{
    public partial class Login : Form
    {
        private string connectionString = Database.DatabaseConnection.connectionString;

        public Login()
        {
            InitializeComponent();
        }

        private void frm_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string enteredUsername = txt_Username.Text.Trim();
            string enteredPassword = txt_Password.Text.Trim();

            if (ValidateCredentials(enteredUsername, enteredPassword, out string role))
            {
                if (role == "Admin")
                {
                    AdminView adminView = new AdminView(CurrentUserManager.Instance.CurrentUser.Id);
                    adminView.Show();
                }
                else
                {
                    Movies moviesForm = new Movies(CurrentUserManager.Instance.CurrentUser.Id);
                    moviesForm.Show();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again");
            }
        }

        private bool ValidateCredentials(string username, string password, out string role)
        {
            role = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT UserID, FirstName, LastName, UserName, Role FROM Account WHERE UserName = @UserName AND Password = @Password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32(0);
                                string firstName = reader.GetString(1);
                                string lastName = reader.GetString(2);
                                string userName = reader.GetString(3);
                                role = reader.GetString(4);

                                src.User.User user = new src.User.User(userId, firstName, lastName, userName);
                                CurrentUserManager.Instance.SetCurrentUser(user);

                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }

            return false;
        }

        private void lbl_SignUp_Click(object sender, EventArgs e)
        {
            SignUp signUpForm = new SignUp();
            signUpForm.Show();
            this.Hide();
        }
    }
}
