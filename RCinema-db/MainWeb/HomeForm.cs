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
    public partial class HomeForm : Form
    {
        private Panel navPanel;
        private Panel contentPanel;

        public HomeForm()
        {
            InitializeComponent();
            InitializeDesign();
        }

        private void InitializeDesign()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = "MoviePortal";
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

            string[] menuItems = { "Login" };
            int xPosition = 1832;

            foreach (string item in menuItems)
            {
                Button navButton = new Button
                {
                    Text = item,
                    ForeColor = Color.Black,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(xPosition, 10),
                    Width = 80,
                    Height = 30
                };

                if (item == "Login")
                {
                    navButton.Image = Image.FromFile(@"C:\\Users\\ripmy\\source\\repos\\RCinema-db\\RCinema-db\\CinemaIcon\loginIcon.png") ;
                    navButton.ImageAlign = ContentAlignment.MiddleLeft; 
                }

                navButton.FlatAppearance.BorderSize = 0;
                navButton.Click += NavButton_Click;

                navPanel.Controls.Add(navButton);
                xPosition += 90;
            }

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
            ShowForm(new HomeForm());
        }

        private void NavButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                contentPanel.Controls.Clear();

                switch (button.Text)
                {
                    case "Home":
                        ShowForm(new HomeForm());
                        break;
                    case "Login":
                        ShowForm(new LoginForm());
                        break;
                }
            }
        }

        private void LoadHomePage()
        {
            Label homeLabel = new Label
            {
                Text = "Welcome to MoviePortal\n\nDiscover the latest movies, create your watchlist, and join our community of movie enthusiasts.",
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
