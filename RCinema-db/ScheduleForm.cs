﻿using RCinema_db.FrontEnd.Default;
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
    public partial class ScheduleForm : Form
    {
        public ScheduleForm()
        {
            Compoenent();
            BackColor = Color.Red;
        }
        private void Compoenent()
        {
            DefaultSize defaultSize = new("Schedule");
            defaultSize.ApplyToForm(this);
        }
    }
}
