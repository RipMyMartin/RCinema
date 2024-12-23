using RCinema_db.Database;
using RCinema_db.MainWeb;
using System.Data.SqlClient;
using RCinema_db.Database;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RCinema_db.MainWeb
{
    public partial class LoginForm : Form
    {
        private Panel parentContentPanel;
        private SqlConnection conn = null;
        private RoundedTextBox usernameBox, passwordBox;
        public LoginForm(Panel conectPanel)
        {
            InitializeComponent();
            parentContentPanel = conectPanel;
            InitializeDesign();
        }

        private void CreateDatabaseIfNotExist()
        {
            DatabaseCreateClass db = new DatabaseCreateClass();
            db.CreateDatabase();
        }

        private void InitializeDesign()
        {
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.FormBorderStyle = FormBorderStyle.None;

            RoundedPanel centerPanel = new RoundedPanel
            {
                Size = new Size(400, 500),
                BackColor = Color.White,
                Location = new Point((this.Width - 400) / 2, (this.Height - 500) / 2),
                CornerRadius = 20
            };

            PictureBox logo = new PictureBox
            {
                Image = Image.FromFile("CinemaIcon/loginIcon.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 100,
                Height = 100,
                Location = new Point((centerPanel.Width - 100) / 2, 20)
            };

            Label titleLabel = new Label
            {
                Text = "Login",
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                AutoSize = true,
                Location = new Point((centerPanel.Width - 70) / 2, 130)
            };

            usernameBox = new RoundedTextBox
            {
                PlaceholderText = "Username",
                Location = new Point(50, 180),
                Width = 300,
                CornerRadius = 10
            };

            passwordBox = new RoundedTextBox
            {
                PlaceholderText = "Password",
                Location = new Point(50, 240),
                Width = 300,
                UseSystemPasswordChar = true,
                CornerRadius = 10
            };

            Button loginButton = new Button
            {
                Text = "Login",
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Width = 200,
                Height = 40,
                Location = new Point((centerPanel.Width - 200) / 2, 320)
            };
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.Click += LoginButton_Click;

            LinkLabel registerLink = new LinkLabel
            {
                Text = "Don't have an account? Register",
                LinkColor = Color.SteelBlue,
                AutoSize = true,
                Location = new Point((centerPanel.Width - 200) / 2, 380),
                Font = new Font("Arial", 10)
            };
            registerLink.Click += CreateAccountLink_Click;

            centerPanel.Controls.Add(logo);
            centerPanel.Controls.Add(titleLabel);
            centerPanel.Controls.Add(usernameBox);
            centerPanel.Controls.Add(passwordBox);
            centerPanel.Controls.Add(loginButton);
            centerPanel.Controls.Add(registerLink);

            this.Controls.Add(centerPanel);
        }
        
        private void LoginButton_Click(object sender, EventArgs e)
        {
                string username = usernameBox.Text.Trim();
                string password = passwordBox.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter your username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    conn = DatabaseConnection.GetConnection();
                    conn.Open();

                    string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string role = result.ToString();
                            if (role == "Admin")
                            {
                                parentContentPanel.Controls.Clear();
                                AdminForm adminForm = new AdminForm();
                                adminForm.TopLevel = false;
                                adminForm.Dock = DockStyle.Fill;
                                adminForm.FormBorderStyle = FormBorderStyle.None;

                                parentContentPanel.Controls.Add(adminForm);
                                adminForm.Show();
                            }
                            else
                            {
                                parentContentPanel.Controls.Clear();
                                HomeForm homeForm = new HomeForm();
                                homeForm.TopLevel = false;
                                homeForm.Dock = DockStyle.Fill;
                                homeForm.FormBorderStyle = FormBorderStyle.None;

                                parentContentPanel.Controls.Add(homeForm);
                                homeForm.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error logging in: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn != null && conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }

        private void CreateAccountLink_Click(object sender, EventArgs e)
        {
            parentContentPanel.Controls.Clear();
            RegisterForm registerForm = new RegisterForm(parentContentPanel);
            registerForm.TopLevel = false;
            registerForm.Dock = DockStyle.Fill;
            registerForm.FormBorderStyle = FormBorderStyle.None;

            parentContentPanel.Controls.Add(registerForm);
            registerForm.Show();
        }
    }
}
