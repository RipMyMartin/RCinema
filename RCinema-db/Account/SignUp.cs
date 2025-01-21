using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCinema_db.Account
{
    public partial class SignUp : Form
    {
        private string loginCredentialsFile = ".\\login-credentials.txt";
        private string email = "";
        private string password = "";
        private string firstName = "";
        private string lastName = "";

        public SignUp()
        {
            InitializeComponent();
        }

        private void frm_SignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close(); 
        }

        private void SaveCredentialsToFile()
        {
            try
            {
                int newUserId;

                string[] lines = File.ReadAllLines(loginCredentialsFile);

                if (lines.Length > 0)
                {
                    string[] lastLineData = lines[lines.Length - 1].Split(',');
                    int lastUserId = Convert.ToInt32(lastLineData[0]);
                    newUserId = lastUserId + 1;
                }
                else
                {
                    newUserId = 10001;
                }

                string newUserLine = $"{newUserId},{email},{password},{firstName},{lastName}" + Environment.NewLine;
                File.AppendAllText(loginCredentialsFile, newUserLine);
            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = { txt_Email, txt_Password, txt_FirstName, txt_LastName };

            if (textBoxes.All(txt => !string.IsNullOrWhiteSpace(txt.Text)))
            {
                email = txt_Email.Text;
                password = txt_Password.Text;
                firstName = txt_FirstName.Text;
                lastName = txt_LastName.Text;

                SaveCredentialsToFile();
                MessageBox.Show("Sign up successfull!");

                Login login = new Login();
                login.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }

        private void lbl_LogIn_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

    }
}
