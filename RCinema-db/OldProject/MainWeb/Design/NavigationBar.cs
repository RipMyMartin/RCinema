using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCinema_db.MainWeb.Design
{
    public partial class NavigationBar : Form
    {
        public event EventHandler LoginButtonClicked;
        public event EventHandler TitleClicked;
        public NavigationBar()
        {
            InitializeComponent();
        }
        private void InitializeDesign()
        {
            Dock = DockStyle.Top;
            Height = 50;
            BackColor = Color.Black;

            Button titleLabel = new Button
            {
                Text = "MoviePortal",
                ForeColor = Color.Red,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };
            titleLabel.Click += (s, e) => TitleClicked?.Invoke(s, e);
            Controls.Add(titleLabel);

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
            loginButton.Click += (s, e) => LoginButtonClicked?.Invoke(s, e);
            Controls.Add(loginButton);
        }
    }
}