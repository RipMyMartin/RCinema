using RCinema_db.FrontEnd.Default;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RCinema_db.FrontEnd
{
    public partial class HomeForm : Form
    {
        private Button cinemaButton, schedule, movies, special;
        private Panel container1;
        private PictureBox login;

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

            cinemaButton = new Button()
            {
                Text = "Cinema",
                Font = Default.DefaultFont.GetFont(50),
                ForeColor = DefaultColor.white,
                FlatStyle = FlatStyle.Flat,
                BackColor = DefaultColor.darkGray,
                FlatAppearance =
                {
                    BorderSize = 0,
                    MouseOverBackColor = Color.Transparent,
                    MouseDownBackColor = Color.Transparent
                }
            };
            Size preferredSize = cinemaButton.PreferredSize;
            cinemaButton.Size = new Size(preferredSize.Width, preferredSize.Height);
            cinemaButton.Location = new Point((this.ClientSize.Width - cinemaButton.Width) / 2, (this.ClientSize.Height - 1100) / 2);
            Controls.Add(cinemaButton);


            container1 = new Panel
            {
                Size = new Size(700, 80),
                BackColor = DefaultColor.lightGray
            };
            container1.Region = DefaultBorderRadius.CreateRoundedRegion(container1.Width, container1.Height, radius);
            container1.Location = new Point((this.ClientSize.Width - container1.Width) / 2, (this.ClientSize.Height - 845) / 2);
            Controls.Add(container1);

            schedule = new Button
            {
                Size = new Size(180, 60),
                Text = "Schedule",
                Font = Default.DefaultFont.GetFont(20),
                ForeColor = DefaultColor.white,
                BackColor = DefaultColor.darkGray,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    BorderSize = 0,
                    MouseOverBackColor = Color.Transparent,
                    MouseDownBackColor = Color.Transparent
                }
            };
            schedule.Region = DefaultBorderRadius.CreateRoundedRegion(schedule.Width, schedule.Height, radius);
            schedule.Location = new Point((this.ClientSize.Width - schedule.Width + 200) / 3, (this.ClientSize.Height - schedule.Height - 770) / 2);
            Controls.Add(schedule);
            schedule.BringToFront();

            movies = new Button
            {
                Size = new Size(150, 60),
                Text = "Movies",
                Font = Default.DefaultFont.GetFont(20),
                ForeColor = DefaultColor.white,
                BackColor = DefaultColor.darkGray,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    BorderSize = 0,
                    MouseOverBackColor = Color.Transparent,
                    MouseDownBackColor = Color.Transparent
                }
            };
            movies.Region = DefaultBorderRadius.CreateRoundedRegion(movies.Width, movies.Height, radius);
            movies.Location = new Point((this.ClientSize.Width - movies.Width + 900) / 3,  (this.ClientSize.Height - movies.Height - 770) / 2);
            Controls.Add(movies);
            movies.BringToFront();

            special = new Button
            {
                Size = new Size(150, 60),
                Text = "Special",
                Font = Default.DefaultFont.GetFont(20),
                ForeColor = DefaultColor.white,
                BackColor = DefaultColor.darkGray,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    BorderSize = 0,
                    MouseOverBackColor = Color.Transparent,
                    MouseDownBackColor = Color.Transparent
                }
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
