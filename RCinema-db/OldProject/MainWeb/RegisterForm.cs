﻿using RCinema_db.Database;
using System.Data.SqlClient;

namespace RCinema_db.MainWeb
{
    public partial class RegisterForm : Form
    {
        private Panel parentContentPanel;
        private SqlConnection conn = null;
        private RoundedTextBox usernameTextBox, emailTextBox, passwordTextBox;
        public RegisterForm(Panel contentPanel)
        {
            InitializeComponent();
            InitializeDesign();
            parentContentPanel = contentPanel;

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
                Text = "Register",
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                AutoSize = true,
                Location = new Point((centerPanel.Width - 100) / 2, 130)
            };

            usernameTextBox = new RoundedTextBox
            {
                PlaceholderText = "Username",
                Location = new Point(50, 180),
                Width = 300,
                CornerRadius = 10
            };

            emailTextBox = new RoundedTextBox
            {
                PlaceholderText = "Email",
                Location = new Point(50, 240),
                Width = 300,
                CornerRadius = 10
            };

            passwordTextBox = new RoundedTextBox
            {
                PlaceholderText = "Password",
                Location = new Point(50, 300),
                Width = 300,
                UseSystemPasswordChar = true,
                CornerRadius = 10
            };

            Button registerButton = new Button
            {
                Text = "Register",
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Width = 200,
                Height = 40,
                Location = new Point((centerPanel.Width - 200) / 2, 370)
            };

            registerButton.FlatAppearance.BorderSize = 0;
            registerButton.Click += RegisterButton_Click;

            LinkLabel registerLink = new LinkLabel
            {
                Text = "You have login?",
                LinkColor = Color.SteelBlue,
                AutoSize = true,
                Location = new Point((centerPanel.Width - 100) / 2, 420),
                Font = new Font("Arial", 10)
            };
            registerLink.Click += loginLink_Click;

            centerPanel.Controls.Add(logo);
            centerPanel.Controls.Add(titleLabel);
            centerPanel.Controls.Add(usernameTextBox);
            centerPanel.Controls.Add(emailTextBox);
            centerPanel.Controls.Add(passwordTextBox);
            centerPanel.Controls.Add(registerButton);
            centerPanel.Controls.Add(registerLink);
            this.Controls.Add(centerPanel);
        }

        private void RegisterButton_Click(object? sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("All fields must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn = DatabaseConnection.GetConnection();
                conn.Open();

                string query = "INSERT INTO Users (Username, Email, Password, Role) VALUES (@Username, @Email, @Password, @Role)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", "User");

                    cmd.ExecuteNonQuery();

                    parentContentPanel.Controls.Clear();
                    LoginForm loginForm = new LoginForm(parentContentPanel);
                    loginForm.TopLevel = false;
                    loginForm.Dock = DockStyle.Fill;
                    loginForm.FormBorderStyle = FormBorderStyle.None;

                    parentContentPanel.Controls.Add(loginForm);
                    loginForm.Show();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving account: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void loginLink_Click(object? sender, EventArgs e)
        {
            parentContentPanel.Controls.Clear();
            LoginForm loginForm = new LoginForm(parentContentPanel);
            loginForm.TopLevel = false;
            loginForm.Dock = DockStyle.Fill;
            loginForm.FormBorderStyle = FormBorderStyle.None;

            parentContentPanel.Controls.Add(loginForm);
            loginForm.Show();
        }

    }
}
