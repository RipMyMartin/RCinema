using RCinema_db.FrontEnd.Default;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCinema_db.FrontEnd.componenet
{
    public partial class CardController : UserControl
    {
        private PictureBox cinemaIcon, langPicture;
        private Panel card;
        private Label cinemaName, timeLangBack, timeLangName, langBack, langName;
        public CardController()
        {
            InitializeComponent();
            CompoenentCard();
        }

        public void CompoenentCard()
        {
            BackColor = DefaultColor.darkGray;
            DefaultSize defaultSize = new DefaultSize("Home");
            defaultSize.ApplyToControll(this);

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



            timeLangBack = new Label()
            {
                Size = new Size(190, 50),
                BackColor = DefaultColor.darkGray,
            };
            timeLangBack.Region = DefaultBorderRadius.CreateRoundedRegion(timeLangBack.Width, timeLangBack.Height, radius);
            timeLangBack.Location = new Point((this.timeLangBack.Width - timeLangBack.Width + 580) / 2, (this.timeLangBack.Height - timeLangBack.Height + 280) / 2);
            card.Controls.Add(timeLangBack);

            timeLangName = new Label()
            {
                Text = "11:00",
                Font = Default.DefaultFont.GetFont(20),
                ForeColor = DefaultColor.white,
                AutoSize = true

            };
            timeLangBack.Controls.Add(timeLangName);

            langBack = new Label()
            {
                Size = new Size(95, 40),
                BackColor = DefaultColor.lightGray,
            };
            langBack.Region = DefaultBorderRadius.CreateRoundedRegion(langBack.Width, langBack.Height, radius);

            langBack.Location = new Point(timeLangName.Location.X + timeLangName.Width, (timeLangBack.Height - langBack.Height) / 2 );
            timeLangBack.Controls.Add(langBack);

            langPicture = new PictureBox()
            {
                Size = new Size(30, 30), 
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = DefaultIcons.GetWifiIcon()
            };

            langPicture.Location = new Point((langBack.Width - langPicture.Width - 60) / 2,5 );
            langBack.Controls.Add(langPicture);

            langName = new Label()
            {
                Text = "EE", 
                Font = Default.DefaultFont.GetFont(20),
                ForeColor = DefaultColor.white,
                AutoSize=true
            };
            langName.Location = new Point((langName.Width - langName.Width + 60) / 2, (langName.Height - langName.Height - 3));
            langBack.Controls.Add(langName);


        }
    }
}
