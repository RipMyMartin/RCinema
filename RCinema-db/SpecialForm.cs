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

namespace RCinema_db.FrontEnd
{
    public partial class SpecialForm : Form
    {
        public SpecialForm()
        {
            InitializeComponent();
            Components();
            Label moviesLabel = new Label
            {
                Text = "SpecialForm Page\nHere you can find the latest SpecialForm.",
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(20, 50),
                AutoSize = true
            };
            this.Controls.Add(moviesLabel);
        }

        private void Components()
        {
            DefaultSize defaultSize = new("Schedule");
            defaultSize.ApplyToForm(this);
        }
    }
}
