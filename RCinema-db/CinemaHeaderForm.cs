using RCinema_db.FrontEnd.Default;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace RCinema_db.FrontEnd
{
    public partial class CinemaHeaderForm : Form
    {
        public CinemaHeaderForm()
        {
            InitializeComponent();

            DefaultSize defaultSize = new("Home");
            defaultSize.ApplyToForm(this);
        }

    }
}
