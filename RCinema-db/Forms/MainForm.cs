using RCinema_db.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RCinema_db.Forms
{
    public partial class MainForm : Form
    {
        private readonly NavPanel navPanel;
        private readonly MainContentPanel mainContentPanel;
        public MainForm()
        {
            InitializeComponent();
            navPanel = new NavPanel { Dock = DockStyle.Left, Width = 200 };
            mainContentPanel = new MainContentPanel { Dock = DockStyle.Fill };

            // Добавление событий
            navPanel.OnNavigate = NavigateTo;

            // Добавление компонентов на форму
            Controls.Add(mainContentPanel);
            Controls.Add(navPanel);

            // По умолчанию показать контент "Home"
            NavigateTo("Home");
        }

        private void NavigateTo(string destination)
        {
            UserControl content = destination switch
            {
                "Home" => new HomeControl(),
                "Movies" => new MoviesControl(),
                "Admin Panel" => new AdminControl(),
                _ => new HomeControl(),
            };

            mainContentPanel.LoadContent(content);
        }

        public void UpdateForUser(string role)
        {
            navPanel.UpdateNavForRole(role);
        }
    }
}