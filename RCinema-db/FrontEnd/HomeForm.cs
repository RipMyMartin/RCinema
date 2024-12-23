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
            int radius = 20;
            BackColor = DefaultColor.darkGray;
            DefaultSize defaultSize = new DefaultSize("Home");
            defaultSize.ApplyToForm(this);

            cinemaHeader = new Label()
            {
                Text = "Cinema",
                Font = Default.DefaultFont.GetFont(50),
                ForeColor = DefaultColor.white,
                FlatStyle = FlatStyle.Flat,
                BackColor = DefaultColor.darkGray,
            };
            Size preferredSize = cinemaHeader.PreferredSize;
            cinemaHeader.Size = new Size(preferredSize.Width, preferredSize.Height);
            cinemaHeader.Location = new Point((this.ClientSize.Width - cinemaHeader.Width) / 2, (this.ClientSize.Height - 1100) / 2);
            Controls.Add(cinemaHeader);


            container1 = new Panel
            {
                Size = new Size(700, 80),
                BackColor = DefaultColor.lightGray
            };
            container1.Region = DefaultBorderRadius.CreateRoundedRegion(container1.Width, container1.Height, radius);
            container1.Location = new Point((this.ClientSize.Width - container1.Width) / 2, (this.ClientSize.Height - 845) / 2);
            Controls.Add(container1);

            schedule = new Label
            {
                Size = new Size(180, 60),
                Text = "Schedule",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = Default.DefaultFont.GetFont(20),
                ForeColor = DefaultColor.white,
                BackColor = DefaultColor.darkGray,
                FlatStyle = FlatStyle.Flat,
            };
            schedule.Region = DefaultBorderRadius.CreateRoundedRegion(schedule.Width, schedule.Height, radius);
            schedule.Location = new Point((this.ClientSize.Width - schedule.Width + 200) / 3, (this.ClientSize.Height - schedule.Height - 770) / 2);
            Controls.Add(schedule);
            schedule.BringToFront();

            movies = new Label
            {
                Size = new Size(150, 60),
                Text = "Movies",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = Default.DefaultFont.GetFont(20),
                ForeColor = DefaultColor.white,
                BackColor = DefaultColor.darkGray,
                FlatStyle = FlatStyle.Flat,
            };
            movies.Region = DefaultBorderRadius.CreateRoundedRegion(movies.Width, movies.Height, radius);
            movies.Location = new Point((this.ClientSize.Width - movies.Width + 900) / 3,  (this.ClientSize.Height - movies.Height - 770) / 2);
            Controls.Add(movies);
            movies.BringToFront();

            special = new Label
            {
                Size = new Size(150, 60),
                Text = "Special",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = Default.DefaultFont.GetFont(20),
                ForeColor = DefaultColor.white,
                BackColor = DefaultColor.darkGray,
                FlatStyle = FlatStyle.Flat,
            };
            special.Region = DefaultBorderRadius.CreateRoundedRegion(special.Width, special.Height, radius);
            special.Location = new Point((this.ClientSize.Width - special.Width + 1600) / 3, (this.ClientSize.Height - special.Height - 770) / 2);
            Controls.Add(special);
            special.BringToFront();

            login = new PictureBox
            {
                Size = new Size(130,130),
                Text = "Special",
                Font = Default.DefaultFont.GetFont(20),
                SizeMode = PictureBoxSizeMode.Zoom,
                
            };
            login.Location = new Point((this.ClientSize.Width - login.Width + 3550) / 3, (this.ClientSize.Height - login.Height - 920) / 2);
            login.Image = DefaultIcons.GetLoginIcon();
            Controls.Add(login);
        }
    }
}
