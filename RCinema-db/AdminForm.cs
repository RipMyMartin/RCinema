using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace RCinema_db
{
    public partial class AdminForm : Form
    {
        SqlConnection conn = null;
        public AdminForm()
        {
            InitializeComponent();
            InitializeAdminForm();
        }

        private void InitializeAdminForm()
        {
            this.Text = "Admin Dashboard";
            this.Size = new Size(800, 600);
            this.BackColor = Color.FromArgb(34, 34, 34);

            Button btnViewUsers = new Button
            {
                Text = "View Users",
                Font = new Font("Arial", 14),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(48, 48, 48),
                Size = new Size(200, 50),
                Location = new Point(300, 50),
                FlatStyle = FlatStyle.Flat
            };
            btnViewUsers.FlatAppearance.BorderSize = 0;
            btnViewUsers.Click += BtnViewUsers_Click;
            this.Controls.Add(btnViewUsers);

            Button btnViewBookings = new Button
            {
                Text = "View Bookings",
                Font = new Font("Arial", 14),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(48, 48, 48),
                Size = new Size(200, 50),
                Location = new Point(300, 120),
                FlatStyle = FlatStyle.Flat
            };
            btnViewBookings.FlatAppearance.BorderSize = 0;
            btnViewBookings.Click += BtnViewBookings_Click;
            this.Controls.Add(btnViewBookings);

            Button btnViewMovies = new Button
            {
                Text = "View Movies",
                Font = new Font("Arial", 14),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(48, 48, 48),
                Size = new Size(200, 50),
                Location = new Point(300, 190),
                FlatStyle = FlatStyle.Flat
            };
            btnViewMovies.FlatAppearance.BorderSize = 0;
            btnViewMovies.Click += BtnViewMovies_Click;
            this.Controls.Add(btnViewMovies);

            Button btnSettings = new Button
            {
                Text = "Settings",
                Font = new Font("Arial", 14),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(48, 48, 48),
                Size = new Size(200, 50),
                Location = new Point(300, 260),
                FlatStyle = FlatStyle.Flat
            };
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.Click += BtnSettings_Click;
            this.Controls.Add(btnSettings);

            Panel infoPanel = new Panel
            {
                Size = new Size(750, 250),
                Location = new Point(25, 350),
                BackColor = Color.FromArgb(24, 24, 24)
            };
            this.Controls.Add(infoPanel);

            Label lblInfo = new Label
            {
                Text = "Admin Information Panel",
                Font = new Font("Arial", 18),
                ForeColor = Color.Lime,
                Location = new Point(20, 20),
                AutoSize = true
            };
            infoPanel.Controls.Add(lblInfo);
        }

        private void BtnViewUsers_Click(object sender, EventArgs e)
        {
            try
            {
                conn = DatabaseConnection.GetConnection();
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        private void BtnViewBookings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Viewing bookings");
        }

        private void BtnViewMovies_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Viewing movies");
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opening settings");
        }
    }
}
