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
        public HomeForm()
        {
            Component();
        }

        private void Component()
        {
            DefaultSize defaultSize = new ("Home");
            defaultSize.ApplyToForm(this);

            NavController navController = new ()
            {
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width, 220)
            };
            Controls.Add(navController);

            CardController cardController = new ()
            {
                Location = new Point(0, navController.Bottom - 200),
            };
            Controls.Add(cardController);
        }
    }
}
