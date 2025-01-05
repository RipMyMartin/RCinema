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
    public partial class MoviesForm : Form
    {
        public MoviesForm()
        {
            InitializeComponent();
            Label moviesLabel = new Label
            {
                Text = "Movies Page\nHere you can find the latest movies.",
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(20, 50),
                AutoSize = true
            };
            this.Controls.Add(moviesLabel);
        }
    }
}
