using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCinema_db.MainWeb
{
    public partial class MoviesForm : Form
    {
        public MoviesForm()
        {
            InitializeComponent();
            InitializeDesign();
        }

        private void InitializeDesign()
        {
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

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
