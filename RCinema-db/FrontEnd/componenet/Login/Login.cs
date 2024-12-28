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

namespace RCinema_db.FrontEnd.componenet.Login
{
    public partial class Login : UserControl
    {
        private Label loginContainer;

        public Login()
        {
            InitializeComponent();
            LoginDesign();
        }

        private void LoginDesign()
        {
            DefaultSize defaultSize = new("Home");
            defaultSize.ApplyToControll(this);
            BackColor = Default.DefaultColor.darkGray;

            loginContainer = new Label()
            {
                Size = new Size(150,150),

            };
        }
    }
}
