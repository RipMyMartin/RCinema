using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCinema_db.MainWeb
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            InitializeDesign();
        }

        private void InitializeDesign()
        {
            this.Text = "Login - MoviePortal";
            this.Size = new Size(400, 250);
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            PictureBox logo = new PictureBox
            {
                Image = Image.FromFile(@"C:\\Users\\ripmy\\source\\repos\\RCinema-db\\RCinema-db\\CinemaIcon\loginIcon.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 100,
                Height = 100,
                Location = new Point(150, 20)
            };
            this.Controls.Add(logo);

            Label usernameLabel = new Label
            {
                Text = "Username:",
                Location = new Point(50, 130),
                Width = 100
            };
            this.Controls.Add(usernameLabel);

            TextBox usernameTextBox = new TextBox
            {
                Location = new Point(150, 125),
                Width = 200
            };
            this.Controls.Add(usernameTextBox);

            Label passwordLabel = new Label
            {
                Text = "Password:",
                Location = new Point(50, 170),
                Width = 100
            };
            this.Controls.Add(passwordLabel);

            TextBox passwordTextBox = new TextBox
            {
                Location = new Point(150, 165),
                Width = 200,
                PasswordChar = '*'
            };
            this.Controls.Add(passwordTextBox);

            Button loginButton = new Button
            {
                Text = "Login",
                Location = new Point(150, 200),
                Width = 100
            };
            loginButton.Click += LoginButton_Click;
            this.Controls.Add(loginButton);

            LinkLabel createAccountLink = new LinkLabel
            {
                Text = "Create account",
                Location = new Point(150, 230),
                AutoSize = true,
                ForeColor = Color.Blue,
                Cursor = Cursors.Hand
            };
            createAccountLink.Click += CreateAccountLink_Click;
            this.Controls.Add(createAccountLink);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ПАШОЛ НАХУЙ ЕЩЁ НЕ СДЕЛАЙНО!!!");
        }

        private void CreateAccountLink_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

    }
}
