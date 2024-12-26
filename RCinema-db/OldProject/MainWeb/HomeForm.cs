using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace RCinema_db.MainWeb
{
    public partial class HomeForm : Form
    {
        private Panel navPanel;
        private Panel contentPanel, parentContentPanel;

        public HomeForm()
        {
            InitializeComponent();
            InitializeDesign();
        }

        private void InitializeDesign()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = "RCinema";
            this.BackColor = Color.White;

            navPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.Black
            };
            this.Controls.Add(navPanel);

            Button titleLabel = new Button
            {
                Text = "MoviePortal",
                ForeColor = Color.Red,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };
            navPanel.Controls.Add(titleLabel);
            titleLabel.Click += TitleLabel_Click;

            Button loginButton = new Button
            {
                Name = "loginButton",
                Width = 80,
                Height = 30,
                Location = new Point(1832, 10),
                FlatStyle = FlatStyle.Flat,
                BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CinemaIcon", "loginIcon.png")),
                BackgroundImageLayout = ImageLayout.Stretch,
                Cursor = Cursors.Hand
            };

            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.Click += NavButton_Click;

            navPanel.Controls.Add(loginButton);

            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.Click += NavButton_Click;

            navPanel.Controls.Add(loginButton);

            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            this.Controls.Add(contentPanel);

            LoadHomePage();
        }


        private void TitleLabel_Click(object? sender, EventArgs e)
        {
            contentPanel.Controls.Clear();

            HomeForm homeForm = new HomeForm(); 

            homeForm.TopLevel = false;
            homeForm.Dock = DockStyle.Fill;
            homeForm.FormBorderStyle = FormBorderStyle.None;

            contentPanel.Controls.Add(homeForm);
            homeForm.Show();
        }

        private void NavButton_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();

            if (sender is Button button)
            {
                switch (button.Name) 
                {
                    case "loginButton":
                        LoginForm loginForm = new LoginForm(contentPanel);
                        ShowForm(loginForm);
                        break;
                }
            }
        }

        private void LoadHomePage()
        {
            Label homeLabel = new Label
            {
                Text = "Welcome RCimena",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(20, 50),
                AutoSize = true
            };
            contentPanel.Controls.Add(homeLabel);
        }

        private void ShowForm(Form form)
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;

            contentPanel.Controls.Add(form);
            form.Show();
        }
    }
}
