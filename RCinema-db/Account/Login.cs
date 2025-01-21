using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Login : Form
    {
        string _loginFile = ".\\login-credentials.txt";

        public Login()
        {
            InitializeComponent();
        }

        private void frm_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string enteredUsername = txt_Username.Text.Trim();
            string enteredPassword = txt_Password.Text.Trim();

            if (ValidateCredentials(enteredUsername, enteredPassword))
            {
                if (enteredUsername == "admin")
                {
                    AdminView adminView = new AdminView();
                    adminView.Show();
                    this.Hide();
                }
                else
                {
                    Movies frm_Movies = new Movies();
                    frm_Movies.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again");
            }
        }

        private bool ValidateCredentials(string email, string password)
        {
            try
            {
                string[] lines = File.ReadAllLines(_loginFile);

                for (int i = 1; i < lines.Length; i++) // Start at index 1 to skip the header
                {
                    string[] data = lines[i].Split(",");

                    int storedId = Convert.ToInt32(data[0]);
                    string storedUsername = data[1];
                    string storedPassword = data[2];
                    string storedFirstName = data[3];
                    string storedLastName = data[4];

                    if (storedUsername == email && storedPassword == password)
                    {
                        User user = new User(storedId, storedFirstName, storedLastName, storedUsername);
                        CurrentUserManager.Instance.SetCurrentUser(user);
                        return true;
                    }
                }

                return false;
            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(Directory.GetCurrentDirectory());
                return false;
            }
        }


        private void lbl_SignUp_Click(object sender, EventArgs e)
        {
            SignUp signUpForm = new SignUp();
            signUpForm.Show();
            this.Hide();
        }
    }
}
