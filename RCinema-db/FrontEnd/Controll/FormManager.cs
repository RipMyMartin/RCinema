using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;

namespace RCinema_db.FrontEnd.Controll
{
    public static class FormManager
    {
        public static void OpenFormInPanel(Panel mainPanel, Form newForm)
        {
            if (mainPanel == null) return;

            // Закрыть текущие формы в панели
            foreach (Control ctrl in mainPanel.Controls)
            {
                if (ctrl is Form form)
                {
                    form.Close();
                }
            }

            // Открыть новую форму
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(newForm);
            newForm.Show();
        }
    }

}