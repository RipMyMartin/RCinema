using RCinema_db.FrontEnd;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RCinema_db.FrontEnd.Default
{
    public class DefaultSize
    {
        public string FormName { get; set; }
        public Size ClientSize { get; set; }
        public AutoScaleMode AutoScaleMode { get; set; }
        public string Text { get; set; }
        public FormWindowState WindowState { get; set; }
        public bool TopMost { get; set; }

        public DefaultSize(string formName)
        {
            if (string.IsNullOrWhiteSpace(formName))
            {
                throw new ArgumentException("Default", nameof(formName));
            }

            FormName = formName;
            ClientSize = new Size(1080, 720);
            AutoScaleMode = AutoScaleMode.Font;
            Text = formName; 
            TopMost = true;
        }

        public DefaultSize(string formName, Size clientSize, AutoScaleMode autoScaleMode, string text, FormWindowState windowState, bool topMost)
        {
            if (string.IsNullOrWhiteSpace(formName))
            {
                throw new ArgumentException("Default", nameof(formName));
            }

            FormName = formName;
            ClientSize = clientSize;
            AutoScaleMode = autoScaleMode;
            Text = string.IsNullOrWhiteSpace(text) ? formName : text; 
            WindowState = windowState;
            TopMost = topMost;
        }

        public void ApplyToForm(Form form)
        {
            if (form == null) throw new ArgumentNullException(nameof(form));

            form.Name = FormName;
            form.ClientSize = ClientSize;
            form.AutoScaleMode = AutoScaleMode;
            form.Text = Text;
            form.WindowState = WindowState;
            form.TopMost = TopMost;
        }

        public void ApplyToControll(UserControl userControl)
        {
            if (userControl == null) throw new ArgumentNullException(nameof(userControl));

            userControl.Name = FormName;
            userControl.ClientSize = ClientSize;
            userControl.AutoScaleMode = AutoScaleMode;
            userControl.Text = Text;
            //userControl.WindowState = WindowState;
            //userControl.TopMost = TopMost;
        }
    }
}
