using RCinema_db.Account;
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

namespace RCinema_db.User
{
    public partial class Movies : Form
    {
        private string _moviesFile = ".\\movies.txt";
        private string _sessionsFile = ".\\sessions.txt";

        List<Movie> movies = GlobalData.Movies;

        public Movies()
        {
            InitializeComponent();

            //movies = LoadMovies(_moviesFile, _sessionsFile);
            // this string needs to match the name of a Movie field (i.e. Title, Genre, etc)
            listbox_Movies.DisplayMember = "Title";
            listbox_Movies.DataSource = movies;
        }

        public void Form_Movies_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void listbox_Movies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox_Movies.SelectedIndex >= 0)
            {
                // need to cast the list item into a Movie object in order access its properties
                Movie selectedMovie = (Movie)listbox_Movies.SelectedItem;

                lbl_Movie_Title.Text = selectedMovie.Title;
                lbl_Movie_Duration_Genre.Text = $"{selectedMovie.Duration}, {selectedMovie.Genre}";
                lbl_Movie_Release_Date.Text = $"Released on {selectedMovie.ReleaseDate.ToString("dd MMM yyyy")}";
                txt_Movie_Description.Text = selectedMovie.Description;

                string moviePoster = selectedMovie.Poster;

                try
                {
                    picbox_Movie_Poster.Image = Image.FromFile(moviePoster);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        private void SessionButton_Click(object? sender, EventArgs e)
        {

        }

        private void btn_Log_Out_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btn_UserProfile_Click(object sender, EventArgs e)
        {

        }

        private void btn_UserProfile_Click_1(object sender, EventArgs e)
        {
            UserProfile profile = new UserProfile();
            profile.Show();
            this.Close();
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
