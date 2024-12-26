using RCinema_db.FrontEnd.Controll;
using RCinema_db.FrontEnd.Default;
using RCinema_db.MainWeb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace RCinema_db.FrontEnd.componenet
{
    public partial class NavController : UserControl
    {
        private Panel container1;
        private PictureBox login;
        private Label cinemaHeader, schedule, movies, special;

        public delegate void FormSwitchHandler(Form targetForm);
        public event FormSwitchHandler? OnFormSwitch;
        public NavController()
        {
            InitializeComponent();
            CompoenentNav();
        }
        public void CompoenentNav()
        {
            int radius = 20;
            BackColor = DefaultColor.darkGray;
            DefaultSize defaultSize = new DefaultSize("Home");
            defaultSize.ApplyToControll(this);

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
            cinemaHeader.Click += (s, e) => OnFormSwitch?.Invoke(new FrontEnd.CinemaHeaderForm());

            int buttonWidth = 150;
            int buttonHeight = 60;
            int spacing = 20; 
            int totalWidth = 3 * buttonWidth + 2 * spacing;
            int startX = (this.ClientSize.Width - totalWidth) / 2; //Change to 4 if session admin
            int yPosition = (this.ClientSize.Height - 820) / 2; 

            container1 = new Panel
            {
                Size = new Size(totalWidth + 2 * spacing, buttonHeight + 40), 
                BackColor = DefaultColor.lightGray
            };
            container1.Region = DefaultBorderRadius.CreateRoundedRegion(container1.Width, container1.Height, radius);
            container1.Location = new Point((this.ClientSize.Width - container1.Width) / 2,/*Change to 4 if session admin*/ yPosition - 20);
            Controls.Add(container1);

            schedule = new Label
            {
                Size = new Size(buttonWidth, buttonHeight),
                Text = "Schedule",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = Default.DefaultFont.GetFont(20),
                ForeColor = DefaultColor.white,
                BackColor = DefaultColor.darkGray,
                FlatStyle = FlatStyle.Flat,
            };
            schedule.Region = DefaultBorderRadius.CreateRoundedRegion(schedule.Width, schedule.Height, radius);
            schedule.Location = new Point(startX, yPosition); 
            Controls.Add(schedule);
            schedule.BringToFront();
            schedule.Click += (s, e) => OnFormSwitch?.Invoke(new FrontEnd.ScheduleForm());

            movies = new Label
            {
                Size = new Size(buttonWidth, buttonHeight),
                Text = "Movies",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = Default.DefaultFont.GetFont(20),
                ForeColor = DefaultColor.white,
                BackColor = DefaultColor.darkGray,
                FlatStyle = FlatStyle.Flat,
            };
            movies.Region = DefaultBorderRadius.CreateRoundedRegion(movies.Width, movies.Height, radius);
            movies.Location = new Point(startX + buttonWidth + spacing, yPosition);
            Controls.Add(movies);
            movies.Click += (s, e) => OnFormSwitch?.Invoke(new FrontEnd.MoviesForm());
            movies.BringToFront();

            special = new Label
            {
                Size = new Size(buttonWidth, buttonHeight),
                Text = "Special",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = Default.DefaultFont.GetFont(20),
                ForeColor = DefaultColor.white,
                BackColor = DefaultColor.darkGray,
                FlatStyle = FlatStyle.Flat,
            };
            special.Region = DefaultBorderRadius.CreateRoundedRegion(special.Width, special.Height, radius);
            special.Location = new Point(startX + 2 * (buttonWidth + spacing), yPosition); 
            Controls.Add(special);
            special.BringToFront();
            special.Click += (s, e) => OnFormSwitch?.Invoke(new FrontEnd.SpecialForm());

            login = new PictureBox
            {
                Size = new Size(130, 130),
                SizeMode = PictureBoxSizeMode.Zoom,
            };
            login.Location = new Point((this.ClientSize.Width - login.Width + 3550) / 3, (this.ClientSize.Height - login.Height - 920) / 2); 
            login.Image = DefaultIcons.GetLoginIcon();
            Controls.Add(login);


        }
    }
}
