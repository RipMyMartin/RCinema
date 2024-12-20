using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCinema_db.UserControls
{
    public partial class NavPanel : UserControl
    {
        public NavPanel()
        {
            InitializeComponent();
        }
        private void InitializeNavButtons()
        {
            Button btnHome = new Button
            {
                Text = "Home",
                Dock = DockStyle.Top,
                Height = 50
            };
            btnHome.Click += (s, e) => OnNavigate?.Invoke("Home");

            Button btnMovies = new Button
            {
                Text = "Movies",
                Dock = DockStyle.Top,
                Height = 50
            };
            btnMovies.Click += (s, e) => OnNavigate?.Invoke("Movies");

            Button btnAdmin = new Button
            {
                Text = "Admin Panel",
                Dock = DockStyle.Top,
                Height = 50,
                Visible = false 
            };

            Controls.Add(btnAdmin);
            Controls.Add(btnMovies);
            Controls.Add(btnHome);
        }

        public Action<string> OnNavigate { get; set; }

        public void UpdateNavForRole(string role)
        {
            foreach (Control control in Controls)
            {
                if (control is Button btn)
                {
                    if (btn.Text == "Admin Panel")
                    {
                        btn.Visible = role == "Admin"; // Показывать только для администраторов
                    }
                }
            }
        }
    }
}