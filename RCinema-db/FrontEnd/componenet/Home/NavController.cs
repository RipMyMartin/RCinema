using RCinema_db.FrontEnd.Controll;
using RCinema_db.FrontEnd.Default;
using RCinema_db.MainWeb;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RCinema_db.FrontEnd.componenet
{
    public partial class NavController : UserControl
    {
        private Label cinemaHeader, schedule, movies, special;
        private PictureBox login;

        public delegate void FormSwitchHandler(Form targetForm);
        public event FormSwitchHandler? OnFormSwitch;

        public NavController()
        {
            InitializeComponent();
            ClientSize = new Size(1080, 720);
            CompoenentNav();
        }

        public void CompoenentNav()
        {
            int radius = 20;
            BackColor = DefaultColor.darkGray;

            cinemaHeader = new Label
            {
                Text = "Cinema",
                Font = Default.DefaultFont.GetFont(25),
                ForeColor = DefaultColor.white,
                BackColor = DefaultColor.darkGray,
                FlatStyle = FlatStyle.Flat,
                AutoSize = true
            };
            cinemaHeader.Location = new Point((ClientSize.Width - cinemaHeader.Width) / 2, 40);
            Controls.Add(cinemaHeader);
            cinemaHeader.Click += (s, e) => OnFormSwitch?.Invoke(new FrontEnd.CinemaHeaderForm());

            int buttonWidth = 150;
            int buttonHeight = 60;
            int spacing = 20;
            int totalWidth = 3 * buttonWidth + 2 * spacing;
            int startX = (ClientSize.Width - totalWidth) / 2;
            int yPosition = (ClientSize.Height - 400) / 3;

            schedule = CreateNavButton("Schedule", startX, yPosition, buttonWidth, buttonHeight);
            Controls.Add(schedule);
            schedule.Click += (s, e) => OnFormSwitch?.Invoke(new FrontEnd.ScheduleForm());

            movies = CreateNavButton("Movies", startX + buttonWidth + spacing, yPosition, buttonWidth, buttonHeight);
            Controls.Add(movies);
            movies.Click += (s, e) => OnFormSwitch?.Invoke(new FrontEnd.MoviesForm());

            special = CreateNavButton("Special", startX + 2 * (buttonWidth + spacing), yPosition, buttonWidth, buttonHeight);
            Controls.Add(special);
            special.Click += (s, e) => OnFormSwitch?.Invoke(new FrontEnd.SpecialForm());

            login = new PictureBox
            {
                Size = new Size(130, 130),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = DefaultIcons.GetLoginIcon()
            };
            login.Location = new Point(ClientSize.Width - login.Width - 25, 25);
            Controls.Add(login);
            login.Click += (s, e) => OnFormSwitch?.Invoke(new FrontEnd.LoginForm());
        }

        private Label CreateNavButton(string text, int x, int y, int width, int height)
        {
            Label button = new Label
            {
                Text = text,
                Size = new Size(width, height),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = Default.DefaultFont.GetFont(20),
                ForeColor = DefaultColor.white,
                BackColor = DefaultColor.darkGray,
                FlatStyle = FlatStyle.Flat
            };
            button.Region = DefaultBorderRadius.CreateRoundedRegion(width, height, 20);
            button.Location = new Point(x, y);
            return button;
        }
    }
}
