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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            InitializeDesign();
        }

        private void InitializeDesign()
        {
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            Label registerLabel = new Label
            {
                Text = "Register Page",
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(20, 50),
                AutoSize = true
            };

            TextBox usernameBox = new TextBox
            {
                PlaceholderText = "Username",
                Location = new Point(20, 100),
                Width = 200
            };

            TextBox emailBox = new TextBox
            {
                PlaceholderText = "Email",
                Location = new Point(20, 140),
                Width = 200
            };

            TextBox passwordBox = new TextBox
            {
                PlaceholderText = "Password",
                Location = new Point(20, 180),
                Width = 200,
                UseSystemPasswordChar = true
            };

            Button registerButton = new Button
            {
                Text = "Register",
                Location = new Point(20, 220),
                BackColor = Color.Black,
                ForeColor = Color.White,
                Width = 100
            };

            this.Controls.Add(registerLabel);
            this.Controls.Add(usernameBox);
            this.Controls.Add(emailBox);
            this.Controls.Add(passwordBox);
            this.Controls.Add(registerButton);
        }
    }
}
