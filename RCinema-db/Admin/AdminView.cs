using MovieTicketApp.src.Managers;
using RCinema_db.Account;
using RCinema_db.src.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCinema_db.Admin
{
    public partial class AdminView : Form
    {
        private int _userId;
        public AdminView(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void btn_EditUser_Click(object sender, EventArgs e)
        {
            UpdateUser form = new UpdateUser(_userId);
            form.Show();
            this.Hide();
        }

        private void btn_EditMovie_Click_1(object sender, EventArgs e)
        {
            UpdateMovie form = new UpdateMovie(_userId);
            form.Show();
            this.Hide();
        }

        private void btn_Log_Out_Click_1(object sender, EventArgs e)
        {
            FileManager.Save();
            Login logout = new Login();
            logout.Show();
            this.Hide();
        }
    }
}
