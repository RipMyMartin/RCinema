using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace RCinema_db.Account
{
    public partial class SignUp : Form
    {
        private string connectionString = Database.DatabaseConnection.connectionString;
        private string username = "";
        private string password = "";
        private string firstName = "";
        private string lastName = "";
        public SignUp()
        {
            InitializeComponent();
        }

        private void frm_SignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void SaveCredentialsToDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Account (UserName, FirstName, LastName, Password, Role) VALUES (@UserName, @FirstName, @LastName, @Password, @Role)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", username);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Role", "User");

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }

        private void lbl_LogIn_Click_1(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void btn_SignUp_Click_1(object sender, EventArgs e)
        {
            TextBox[] textBoxes = { txt_Email, txt_Password, txt_FirstName, txt_LastName };

            if (textBoxes.All(txt => !string.IsNullOrWhiteSpace(txt.Text)))
            {
                username = txt_Email.Text;
                password = txt_Password.Text;
                firstName = txt_FirstName.Text;
                lastName = txt_LastName.Text;

                SaveCredentialsToDatabase();
                MessageBox.Show("Sign-up successful!");

                Login login = new Login();
                login.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }
    }
}
