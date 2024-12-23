using RCinema_db.FrontEnd.componenet;
using RCinema_db.FrontEnd.Default;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RCinema_db.FrontEnd
{
    public partial class HomeForm : Form
    {
        private Panel container1;
        private PictureBox login;
        private Label cinemaHeader, schedule, movies, special;

        public HomeForm()
        {
            Design();
        }

        private void Design()
        {
            DefaultSize defaultSize = new DefaultSize("Home");
            defaultSize.ApplyToForm(this);

            var navController = new NavController
            {
                Dock = DockStyle.Top 
            };
            this.Controls.Add(navController);
        }
    }
}
