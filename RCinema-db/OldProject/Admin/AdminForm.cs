using RCinema_db.Database;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace RCinema_db
{
    public partial class AdminForm : Form
    {
        private SqlConnection conn = null;
        private DataGridView infoPanel;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private Panel parentContentPanel;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void InitializeAdminForm()
        {
            this.Text = "Admin Dashboard";
            this.Size = new Size(1024, 768);
            this.BackColor = Color.FromArgb(34, 34, 34);
            this.FormBorderStyle = FormBorderStyle.None;

            Panel navigationPanel = new Panel
            {
                Size = new Size(250, this.Height),
                BackColor = Color.FromArgb(24, 24, 24),
                Dock = DockStyle.Left
            };
            this.Controls.Add(navigationPanel);

            Panel contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(44, 44, 44)
            };
            this.Controls.Add(contentPanel);

            Label titleLabel = new Label
            {
                Text = "Admin Dashboard",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 20)
            };
            contentPanel.Controls.Add(titleLabel);
            infoPanel = new DataGridView
            {
                Size = new Size(1650, 400), 
                Location = new Point(300, 150), 
                BackgroundColor = Color.FromArgb(243, 239, 224),
                ForeColor = Color.White,
                GridColor = Color.Gray,
                BorderStyle = BorderStyle.None,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(48, 48, 48),
                    ForeColor = Color.White,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(34, 34, 34),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.FromArgb(64, 64, 64),
                    SelectionForeColor = Color.White,
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                }
            };
            contentPanel.Controls.Add(infoPanel);

            AddNavButton(navigationPanel, "View Users", BtnViewUsers_Click, 50);
            AddNavButton(navigationPanel, "View Bookings", BtnViewBookings_Click, 110);
            AddNavButton(navigationPanel, "View Movies", BtnViewMovies_Click, 170);
            AddNavButton(navigationPanel, "Settings", BtnSettings_Click, 230);

            conn = DatabaseConnection.GetConnection();
        }

        private void AddNavButton(Panel parent, string text, EventHandler clickEvent, int top)
        {
            Button button = new Button
            {
                Text = text,
                Font = new Font("Arial", 12),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(48, 48, 48),
                Size = new Size(200, 40),
                Location = new Point(25, top),
                FlatStyle = FlatStyle.Flat
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += clickEvent;
            parent.Controls.Add(button);
        }

        private void BtnViewUsers_Click(object sender, EventArgs e)
        {
            ExecuteQuery("SELECT * FROM Users");
        }

        private void BtnViewBookings_Click(object sender, EventArgs e)
        {
            ExecuteQuery("SELECT * FROM Booking");
        }

        private void BtnViewMovies_Click(object sender, EventArgs e)
        {
            ExecuteQuery("SELECT * FROM Movies");
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings feature coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExecuteQuery(string query)
        {
            try
            {
                conn.Open();
                dataAdapter = new SqlDataAdapter(query, conn);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                infoPanel.DataSource = dataTable;

                foreach (DataGridViewColumn column in infoPanel.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}

