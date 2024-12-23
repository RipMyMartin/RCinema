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
        private Label cinemaName;

        public HomeForm()
        {
            Design();
            Components();

        }

        private void Components()
        {
            var navController = new NavController
            {
                Dock = DockStyle.Top
            };
            this.Controls.Add(navController);
        }
        private void Design()
        {
            DefaultSize defaultSize = new DefaultSize("Home");
            defaultSize.ApplyToForm(this);

            int radius = 20;

            card = new Panel()
            {
                Size = new Size(500, 350),
                BackColor = DefaultColor.lightGray,
            };
            card.Region = DefaultBorderRadius.CreateRoundedRegion(card.Width, card.Height, radius);
            card.Location = new Point((this.ClientSize.Width - card.Width) / 4, (this.ClientSize.Height - 600) / 2);
            Controls.Add(card);

            cinemaIcon = new PictureBox()
            {
                Size = new Size(250, 335),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            cinemaIcon.Image = DefaultImage.GetCinemaImage_NewLife();
            cinemaIcon.Region = DefaultBorderRadius.CreateRoundedRegion(cinemaIcon.Width, cinemaIcon.Height, radius);
            cinemaIcon.Location = new Point((card.Width - cinemaIcon.Width - 230) / 2, (card.Height - cinemaIcon.Height) / 2);
            card.Controls.Add(cinemaIcon);

            cinemaName = new Label()
            {
                Text = "New Life",
                Font = Default.DefaultFont.GetFont(20),
                ForeColor = DefaultColor.white,
                AutoSize = true,
            };
            cinemaName.Location = new Point((this.cinemaName.Width - cinemaName.Width + 625) / 2, (this.cinemaName.Height - cinemaName.Height + 30) / 2);
            card.Controls.Add(cinemaName);



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
