using RCinema_db.src.Movie;
using System.Data.SqlClient;
using MovieTicketApp.src.Managers;
using RCinema_db.src.Managers;
using RCinema_db.src.Movie;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCinema_db.Admin
{
    public partial class UpdateMovie : Form
    {
        private string connectionString = Database.DatabaseConnection.connectionString;
        private int _userId;
        public UpdateMovie(int userId)
        {
            InitializeComponent();
            LoadMovies();
            _userId = userId;
        }

        private void LoadMovies()
        {
            List<Movie> movies = GetMoviesFromDatabase();
            movieGrid.DataSource = movies;
        }

        private List<Movie> GetMoviesFromDatabase()
        {
            List<Movie> movies = new List<Movie>();
            string query = "SELECT id, title, genre, hours, minutes, year, month, day, description, poster FROM Movies";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    int movieID = reader.GetInt32(0); 
                    Movie movie = new Movie(
                        movieID,                               
                        reader.GetString(1),                   
                        reader.GetString(2),                   
                        reader.GetInt32(3),                    
                        reader.GetInt32(4),                    
                        reader.GetInt32(5),                    
                        reader.GetInt32(6),                   
                        reader.GetInt32(7),                   
                        reader.GetString(8),                  
                        reader.GetString(9)                    
                    );

                    movies.Add(movie);  
                }
            }

            return movies;  
        }

        private void Form_UpdateMovie_Load(object sender, EventArgs e)
        {
        }

        private Movie GetMovieFromDatabaseById(int movieId)
        {
            Movie movie = null;
            string query = "SELECT id, title, genre, hours, minutes, year, month, day, description, poster FROM Movies WHERE id = @MovieId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MovieId", movieId);

                Console.WriteLine("Executing SQL Query: " + query);
                Console.WriteLine("Searching for movie ID: " + movieId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int movieID = reader.GetInt32(0);
                    movie = new Movie(
                        movieID,
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetInt32(4),
                        reader.GetInt32(5),
                        reader.GetInt32(6),
                        reader.GetInt32(7),
                        reader.GetString(8),
                        reader.GetString(9)
                    );
                }
                else
                {
                    Console.WriteLine("Movie with ID " + movieId + " not found.");
                }
            }

            return movie;
        }


        private void UpdateMovieInDatabase(int movieId, string title, string genre, int hours, int minutes, int year, int month, int day, string description, string poster)
        {
            string query = "UPDATE Movies SET title = @Title, genre = @Genre, hours = @Hours, minutes = @Minutes, year = @Year, month = @Month, day = @Day, description = @Description, poster = @Poster WHERE id = @MovieId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Genre", genre);
                cmd.Parameters.AddWithValue("@Hours", hours);
                cmd.Parameters.AddWithValue("@Minutes", minutes);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@Day", day);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Poster", poster);
                cmd.Parameters.AddWithValue("@MovieId", movieId);

                cmd.ExecuteNonQuery();
            }
        }

        private void InsertNewMovieIntoDatabase(string title, string genre, int hours, int minutes, int year, int month, int day, string description, string poster)
        {
            string query = "INSERT INTO Movies (title, genre, hours, minutes, year, month, day, description, poster) VALUES (@Title, @Genre, @Hours, @Minutes, @Year, @Month, @Day, @Description, @Poster)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Genre", genre);
                cmd.Parameters.AddWithValue("@Hours", hours);
                cmd.Parameters.AddWithValue("@Minutes", minutes);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@Day", day);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Poster", poster);

                cmd.ExecuteNonQuery();
            }
        }

        private bool ValidateMovieData(string title, string genre, int hours, int minutes, DateTime releaseDate, string description, string poster)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(genre))
            {
                MessageBox.Show("Please provide all required fields.");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminView admin = new AdminView(_userId);
            admin.Show();
            this.Close();
        }

        private void btn_CreateMovie_Click(object sender, EventArgs e)
        {
            string title = textBox_Title.Text;
            string genre = textBox_Genre.Text;
            int hours = int.Parse(textBox_Hours.Text);
            int minutes = int.Parse(textBox_Minutes.Text);
            int year = dateTimePicker_ReleaseDate.Value.Year;
            int month = dateTimePicker_ReleaseDate.Value.Month;
            int day = dateTimePicker_ReleaseDate.Value.Day;
            string description = textBox_Description.Text;
            string poster = textBox_Poster.Text;

            DateTime selectedDate = new DateTime(year, month, day);

            if (!ValidateMovieData(title, genre, hours, minutes, selectedDate, description, poster))
            {
                return;
            }

            InsertNewMovieIntoDatabase(title, genre, hours, minutes, year, month, day, description, poster);

            LoadMovies();

            MessageBox.Show("Movie added successfully.");
        }

        private void btn_UpdateMovie_Click_1(object sender, EventArgs e)
        {
            int movieId = int.Parse(textBox_MovieID.Text);
            Movie movieToUpdate = GetMovieFromDatabaseById(movieId);

            if (movieToUpdate == null)
            {
                MessageBox.Show("Movie not found.");
                return;
            }

            string title = textBox_Title.Text;
            string genre = textBox_Genre.Text;
            int hours = int.Parse(textBox_Hours.Text);
            int minutes = int.Parse(textBox_Minutes.Text);
            int year = dateTimePicker_ReleaseDate.Value.Year;
            int month = dateTimePicker_ReleaseDate.Value.Month;
            int day = dateTimePicker_ReleaseDate.Value.Day;
            string description = textBox_Description.Text;
            string poster = textBox_Poster.Text; 

            DateTime selectedDate = new DateTime(year, month, day);

            if (!ValidateMovieData(title, genre, hours, minutes, selectedDate, description, poster))
            {
                return; 
            }

            UpdateMovieInDatabase(movieId, title, genre, hours, minutes, year, month, day, description, poster);

            LoadMovies();

            MessageBox.Show("Movie data updated successfully.");
        }

        private void movieGrid_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = movieGrid.Rows[index];
            textBox_MovieID.Text = selectedRow.Cells[0].Value.ToString();
            textBox_Title.Text = selectedRow.Cells[1].Value.ToString();
            textBox_Genre.Text = selectedRow.Cells[2].Value.ToString();
            textBox_Hours.Text = selectedRow.Cells[3].Value.ToString();
            textBox_Minutes.Text = selectedRow.Cells[4].Value.ToString();
            textBox_Description.Text = selectedRow.Cells[8].Value.ToString();
            textBox_Poster.Text = selectedRow.Cells[9].Value.ToString();

            int year = int.Parse(selectedRow.Cells[5].Value.ToString());
            int month = int.Parse(selectedRow.Cells[6].Value.ToString());
            int day = int.Parse(selectedRow.Cells[7].Value.ToString());

            DateTime selectedDate = new DateTime(year, month, day);
            dateTimePicker_ReleaseDate.Value = selectedDate;
        }

        private void btn_DeleteMovie_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_MovieID.Text))
            {
                MessageBox.Show("Please select a movie to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int movieId;
            if (!int.TryParse(textBox_MovieID.Text, out movieId))
            {
                MessageBox.Show("Invalid Movie ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string checkSessionsQuery = "SELECT COUNT(*) FROM Sessions WHERE id = @MovieId";
            string deleteMovieQuery = "DELETE FROM Movies WHERE id = @MovieId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand checkCmd = new SqlCommand(checkSessionsQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MovieId", movieId);
                        int sessionCount = (int)checkCmd.ExecuteScalar();

                        if (sessionCount > 0)
                        {
                            MessageBox.Show("This movie has associated sessions and cannot be deleted until the sessions are resolved.", "Movie Deletion Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    DialogResult result = MessageBox.Show("Are you sure you want to delete this movie?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        using (SqlCommand deleteCmd = new SqlCommand(deleteMovieQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@MovieId", movieId);
                            int rowsAffected = deleteCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Movie deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadMovies(); 
                            }
                            else
                            {
                                MessageBox.Show("Movie not found or could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting the movie: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Button_openFileDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fullFilePath = openFileDialog1.FileName;
                string imagesDirectory = Path.Combine(Application.StartupPath, @"..\..\..\Images\CinemaImage");

                if (!Directory.Exists(imagesDirectory))
                {
                    Directory.CreateDirectory(imagesDirectory);
                }

                string fileName = Path.GetFileName(fullFilePath);
                string relativeImagePath = Path.Combine(imagesDirectory, fileName);

                File.Copy(fullFilePath, relativeImagePath, true);
                textBox_Poster.Text = @"..\..\..\Images\CinemaImage\" + fileName;
            }
        }
    }
}
