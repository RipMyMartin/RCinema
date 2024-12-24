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
        private PictureBox login, cinemaIcon;
        private Panel card;
        private Label cinemaName, timeLangBack, timeLangName;

        public HomeForm()
        {
            Design();
            NavComponent();

        }

        private void NavComponent()
        {
            var navController = new NavController
            {
                Location = new Point(0, 0),
                Size = new Size(this.ClientSize.Width, 220) 
            };
            this.Controls.Add(navController);

            var cardController = new CardController
            {
                Location = new Point(0, navController.Bottom - 200), 
            };
            this.Controls.Add(cardController);
        }



        private void Design()
        {
            DefaultSize defaultSize = new DefaultSize("Home");
            defaultSize.ApplyToForm(this);

            int radius = 20;

            timeLangBack = new Label()
            {
                Size = new Size(150, 50),
                BackColor = DefaultColor.darkGray,
            };
            timeLangBack.Region = DefaultBorderRadius.CreateRoundedRegion(timeLangBack.Width, timeLangBack.Height, radius);
            timeLangBack.Location = new Point((this.timeLangBack.Width - timeLangBack.Width + 625) / 2, (this.timeLangBack.Height - timeLangBack.Height + 280) / 2);
            Controls.Add(timeLangBack);

            timeLangName = new Label()
            {
                Text = "11:00",
                Font = Default.DefaultFont.GetFont(20), 
                ForeColor = DefaultColor.white,

            };

            /*
            card = new Panel()
            {
                Size = new Size(500, 350),
                BackColor = DefaultColor.lightGray,
            };
            card.Region = DefaultBorderRadius.CreateRoundedRegion(card.Width, card.Height, radius);
            card.Location = new Point((this.ClientSize.Width - card.Width + 700) / 2, (this.ClientSize.Height - 600) / 2);
            Controls.Add(card);
            */
        }
    }
}
