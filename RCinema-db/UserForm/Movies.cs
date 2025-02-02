using RCinema_db.Account;
using RCinema_db.FrontEnd.Default;
using RCinema_db.src.Movie;
using RCinema_db.UserForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace RCinema_db.User
{
    public partial class Movies : Form
    {
        private string _connectionString = Database.DatabaseConnection.connectionString;

        private List<Movie> movies = new List<Movie>();
        private int _userId;
        public Movies(int userId)
        {
            InitializeComponent();

            LoadMoviesFromDatabase();

            listbox_Movies.DisplayMember = "Title";
            listbox_Movies.DataSource = movies;
            _userId = userId;
        }

        private void LoadMoviesFromDatabase()
        {
            string query = "SELECT id, title, genre, hours, minutes, year, month, day, description, poster FROM Movies";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Movie movie = new Movie(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.IsDBNull(2) ? "Unknown" : reader.GetString(2),
                                    reader.GetInt32(3),
                                    reader.GetInt32(4),
                                    reader.GetInt32(5),
                                    reader.GetInt32(6),
                                    reader.GetInt32(7),
                                    reader.IsDBNull(8) ? "No description available." : reader.GetString(8),
                                    reader.IsDBNull(9) ? null : reader.GetString(9)
                                );
                                movies.Add(movie);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading movies: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Form_Movies_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void Exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_UserProfile_Click_2(object sender, EventArgs e)
        {
            UserProfile profile = new UserProfile(_userId);
            profile.Show();
            this.Close();
        }

        private void btn_Log_Out_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void listbox_Movies_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listbox_Movies.SelectedIndex >= 0)
            {
                Movie selectedMovie = (Movie)listbox_Movies.SelectedItem;

                lbl_Movie_Title.Text = selectedMovie.Title;
                lbl_Movie_Duration_Genre.Text = $"{selectedMovie.Duration} mins, {selectedMovie.Genre}";
                lbl_Movie_Release_Date.Text = $"Released on {selectedMovie.ReleaseDate:dd MMM yyyy}";
                txt_Movie_Description.Text = selectedMovie.Description;

                string moviePoster = selectedMovie.Poster;  

                try
                {
                    if (File.Exists(moviePoster))
                    {
                        picbox_Movie_Poster.Image = Image.FromFile(moviePoster);  
                    }
                    else
                    {
                        picbox_Movie_Poster.Image = DefaultImage.GetDefaultImage();  
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"An error occurred while loading the poster: {ex.Message}");
                    picbox_Movie_Poster.Image = DefaultImage.GetDefaultImage();  
                }
            }
        }


        private void btn_BuyTicket_Click(object sender, EventArgs e)
        {
            if (listbox_Movies.SelectedIndex >= 0)
            {
                Movie selectedMovie = (Movie)listbox_Movies.SelectedItem;

                SeatSelectionForm seatSelectionForm = new SeatSelectionForm(selectedMovie, _userId);
                seatSelectionForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a movie first.", "No Movie Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}