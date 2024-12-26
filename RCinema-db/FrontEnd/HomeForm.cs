using RCinema_db.FrontEnd.componenet;
using RCinema_db.FrontEnd.Controll;
using RCinema_db.FrontEnd.Default;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RCinema_db.FrontEnd
{
    public partial class HomeForm : Form
    {
        private Panel mainPanel;
        private Panel subPanel;

        public HomeForm()
        {
            Component();
            CinemaHeaderConpoenent_Copy();
        }

        private void Component()
        {
            DefaultSize defaultSize = new("Home");
            defaultSize.ApplyToForm(this);
            BackColor = Default.DefaultColor.darkGray;

            mainPanel = new Panel
            {
                Location = new Point(0, 220),
                Size = new Size(ClientSize.Width, ClientSize.Height - 220),
            };
            Controls.Add(mainPanel);

            NavController navController = new NavController()
            {
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width, 220)
            };
            navController.OnFormSwitch += NavController_OnFormSwitch;
            Controls.Add(navController);

            subPanel = new Panel
            {
                Dock = DockStyle.Fill
            };
            mainPanel.Controls.Add(subPanel);
        }
        private void NavController_OnFormSwitch(Form targetForm)
        {
            FormManager.OpenFormInPanel(mainPanel, targetForm);
        }

        private void CinemaHeaderConpoenent_Copy()
        {
            CardController cardController = new()
            {
                Location = new Point(0, -200),
            };
            subPanel.Controls.Add(cardController);
        }
    }
}
