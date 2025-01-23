using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace RCinema_db.Admin
{
    public partial class UpdateUser : Form
    {
        private string connectionString = Database.DatabaseConnection.connectionString;
        private int _userId;
        public UpdateUser(int userId)
        {
            InitializeComponent();
            LoadUserData();
            _userId = userId;
        }

        private void LoadUserData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT UserID, UserName, Password, FirstName, LastName, Role FROM Account";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable userTable = new DataTable();
                        userTable.Load(reader);
                        userGrid.DataSource = userTable;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading user data: {ex.Message}");
            }
        }

        private void btn_Cancel_Click_1(object sender, EventArgs e)
        {
            AdminView admin = new AdminView(_userId);
            admin.Show();
            this.Close();
        }

        private bool ValidateUserData(string username, string password, string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("All fields must be filled out.");
                return false;
            }

            if (password.Length < 4)
            {
                MessageBox.Show("Password must be at least 4 characters long.");
                return false;
            }

            return true;
        }

        private void btn_CreateNewUser_Click(object sender, EventArgs e)
        {
            if (!ValidateUserData(textBox_Username.Text, textBox_Password.Text, textBox_firstName.Text, textBox_lastName.Text))
            {
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Account (UserName, Password, FirstName, LastName, Role) VALUES (@UserName, @Password, @FirstName, @LastName, 'User')";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", textBox_Username.Text);
                        command.Parameters.AddWithValue("@Password", textBox_Password.Text); 
                        command.Parameters.AddWithValue("@FirstName", textBox_firstName.Text);
                        command.Parameters.AddWithValue("@LastName", textBox_lastName.Text);

                        command.ExecuteNonQuery();
                    }
                }

                LoadUserData();
                MessageBox.Show("User added successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error adding user: {ex.Message}");
            }
        }

        private void btn_UpdateData_Click(object sender, EventArgs e)
        {
            if (!ValidateUserData(textBox_Username.Text, textBox_Password.Text, textBox_firstName.Text, textBox_lastName.Text))
            {
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Account SET UserName = @UserName, Password = @Password, FirstName = @FirstName, LastName = @LastName WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", int.Parse(textBox_UserId.Text));
                        command.Parameters.AddWithValue("@UserName", textBox_Username.Text);
                        command.Parameters.AddWithValue("@Password", textBox_Password.Text);
                        command.Parameters.AddWithValue("@FirstName", textBox_firstName.Text);
                        command.Parameters.AddWithValue("@LastName", textBox_lastName.Text);

                        command.ExecuteNonQuery();
                    }
                }

                LoadUserData();
                MessageBox.Show("User data updated successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error updating user: {ex.Message}");
            }
        }

        private void btn_DeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                string userInput = textBox_UserId.Text.Trim();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    MessageBox.Show("User ID cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(userInput, out int userId))
                {
                    MessageBox.Show("Invalid User ID. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkBookingsQuery = "SELECT COUNT(*) FROM Bookings WHERE UserID = @UserID";
                    using (SqlCommand checkCommand = new SqlCommand(checkBookingsQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@UserID", userId);

                        int bookingCount = (int)checkCommand.ExecuteScalar();
                        if (bookingCount > 0)
                        {
                            MessageBox.Show("This user has associated bookings and cannot be deleted until the bookings are resolved.", "User Deletion Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Delete user
                    string deleteQuery = "DELETE FROM Account WHERE UserID = @UserID";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@UserID", userId);
                        deleteCommand.ExecuteNonQuery();
                    }
                }

                LoadUserData();
                MessageBox.Show("User deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void userGrid_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = userGrid.Rows[e.RowIndex];
                textBox_UserId.Text = selectedRow.Cells["UserID"].Value.ToString();
                textBox_Username.Text = selectedRow.Cells["UserName"].Value.ToString();
                textBox_Password.Text = selectedRow.Cells["Password"].Value.ToString();
                textBox_firstName.Text = selectedRow.Cells["FirstName"].Value.ToString();
                textBox_lastName.Text = selectedRow.Cells["LastName"].Value.ToString();
            }
        }
    }
}
