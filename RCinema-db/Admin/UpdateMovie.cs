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

            // Load movies from the database into the DataGridView
            private void LoadMovies()
            {
                movieGrid.DataSource = GetMoviesFromDatabase();
            }

        // Get movies from the database
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
                    movies.Add(new Movie(
                        reader.GetInt32(0),  // movieID
                        reader.GetString(1), // title
                        reader.GetString(2), // genre
                        reader.GetInt32(3),  // hours
                        reader.GetInt32(4),  // minutes
                        reader.GetInt32(5),  // year
                        reader.GetInt32(6),  // month
                        reader.GetInt32(7),  // day
                        reader.GetString(8), // description
                        reader.IsDBNull(9) ? null : reader["poster"] as byte[] // poster
                    ));
                }
            }
            return movies;
        }

        private void Form_UpdateMovie_Load(object sender, EventArgs e)
            {
            }

        private bool ValidateMovieData(string title, string genre, int hours, int minutes, DateTime releaseDate, string description, byte[] poster)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(genre))
            {
                MessageBox.Show("Please provide all required fields.");
                return false;
            }

            if (poster == null)
            {
                MessageBox.Show("Please select a poster image.");
                return false;
            }

            if (releaseDate > DateTime.Now)
            {
                MessageBox.Show("Release date cannot be in the future.");
                return false;
            }

            return true;
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

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string posterPath = reader.IsDBNull(9) ? null : reader.GetString(9);
                    byte[] posterBytes = null;

                    if (!string.IsNullOrEmpty(posterPath) && File.Exists(posterPath))
                    {
                        posterBytes = File.ReadAllBytes(posterPath); // Load image as byte array
                    }

                    movie = new Movie(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.IsDBNull(2) ? "Unknown" : reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetInt32(4),
                        reader.GetInt32(5),
                        reader.GetInt32(6),
                        reader.GetInt32(7),
                        reader.IsDBNull(8) ? "No description available." : reader.GetString(8),
                        posterBytes  // Passing as byte array
                    );
                }
            }

            return movie;
        }


        private void UpdateMovieInDatabase(int movieId, string title, string genre, int hours, int minutes, int year, int month, int day, string description, byte[] poster)
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

        private void InsertOrUpdateMovieInDatabase(string title, string genre, int hours, int minutes, int year, int month, int day, string description, byte[] poster)
        {
            string query;
            SqlCommand cmd;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                query = "INSERT INTO Movies (title, genre, hours, minutes, year, month, day, description, poster) " +
                        "VALUES (@Title, @Genre, @Hours, @Minutes, @Year, @Month, @Day, @Description, @Poster)";

                cmd = new SqlCommand(query, conn);
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
            string posterPath = string.Empty;

            // Открытие диалогового окна для выбора постера
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                posterPath = openFileDialog1.FileName;
            }

            byte[] poster = ConvertImageToByteArray(posterPath); // Преобразуем изображение в массив байтов

            DateTime selectedDate = new DateTime(year, month, day);

            if (!ValidateMovieData(title, genre, hours, minutes, selectedDate, description, poster))
            {
                return; // Валидация не прошла, не продолжаем
            }

            // Вставляем новый фильм в базу данных
            InsertOrUpdateMovieInDatabase(title, genre, hours, minutes, year, month, day, description, poster);

            // Перезагружаем таблицу с фильмами
            LoadMovies();

            MessageBox.Show("Фильм успешно добавлен.");
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
            byte[] poster = null;

            // Check if poster is selected
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string posterPath = openFileDialog1.FileName;
                poster = ConvertImageToByteArray(posterPath);  // Convert the selected image to byte array
            }
            else
            {
                poster = movieToUpdate.Poster;  // Keep existing poster if none selected
            }

            DateTime selectedDate = new DateTime(year, month, day);

            if (!ValidateMovieData(title, genre, hours, minutes, selectedDate, description, poster))
            {
                return; // Validation failed
            }

            // Update movie in database
            UpdateMovieInDatabase(movieId, title, genre, hours, minutes, year, month, day, description, poster);
            LoadMovies(); // Reload data grid

            MessageBox.Show("Movie updated successfully.");
        }


        private void movieGrid_CellClick_1(object sender, DataGridViewCellEventArgs e)
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = movieGrid.Rows[index];

                // Fill text fields with the selected movie data
                textBox_MovieID.Text = selectedRow.Cells[0].Value.ToString();
                textBox_Title.Text = selectedRow.Cells[1].Value.ToString();
                textBox_Genre.Text = selectedRow.Cells[2].Value.ToString();
                textBox_Hours.Text = selectedRow.Cells[3].Value.ToString();
                textBox_Minutes.Text = selectedRow.Cells[4].Value.ToString();
                textBox_Description.Text = selectedRow.Cells[8].Value.ToString();

                // Set the release date in the DateTimePicker
                int year = int.Parse(selectedRow.Cells[5].Value.ToString());
                int month = int.Parse(selectedRow.Cells[6].Value.ToString());
                int day = int.Parse(selectedRow.Cells[7].Value.ToString());
                DateTime selectedDate = new DateTime(year, month, day);
                dateTimePicker_ReleaseDate.Value = selectedDate;

                // Set the poster image path to openFileDialog1's FileName
                string posterPath = selectedRow.Cells[9].Value.ToString();
                if (!string.IsNullOrEmpty(posterPath))
                {
                    // If a valid poster path exists, update the openFileDialog to reflect it
                    openFileDialog1.FileName = posterPath; // Set the file dialog to show the poster path
                }
                else
                {
                    // If there's no poster path, you can reset or handle this as needed
                    openFileDialog1.FileName = string.Empty;
                }
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

                        // Check if there are associated sessions
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

                        // Confirm deletion
                        DialogResult result = MessageBox.Show("Are you sure you want to delete this movie?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // Delete the movie
                            using (SqlCommand deleteCmd = new SqlCommand(deleteMovieQuery, conn))
                            {
                                deleteCmd.Parameters.AddWithValue("@MovieId", movieId);
                                int rowsAffected = deleteCmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Movie deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadMovies(); // Reload the movie grid
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
            private void SaveImageToDatabase(byte[] imageBytes)
            {
                string query = "INSERT INTO Movies (title, genre, hours, minutes, year, month, day, description, poster) " +
                               "VALUES (@Title, @Genre, @Hours, @Minutes, @Year, @Month, @Day, @Description, @Poster)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Title", textBox_Title.Text);
                    cmd.Parameters.AddWithValue("@Genre", textBox_Genre.Text);
                    cmd.Parameters.AddWithValue("@Hours", int.Parse(textBox_Hours.Text));
                    cmd.Parameters.AddWithValue("@Minutes", int.Parse(textBox_Minutes.Text));
                    cmd.Parameters.AddWithValue("@Year", dateTimePicker_ReleaseDate.Value.Year);
                    cmd.Parameters.AddWithValue("@Month", dateTimePicker_ReleaseDate.Value.Month);
                    cmd.Parameters.AddWithValue("@Day", dateTimePicker_ReleaseDate.Value.Day);
                    cmd.Parameters.AddWithValue("@Description", textBox_Description.Text);
                    cmd.Parameters.AddWithValue("@Poster", imageBytes);
                    cmd.ExecuteNonQuery();
                }
            }


        private void button2_Click(object sender, EventArgs e)
        {
            // Открываем диалог для выбора файла
            openFileDialog1.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
            openFileDialog1.Title = "Выберите изображение";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string selectedFilePath = openFileDialog1.FileName;

                    // Проверяем расширение файла
                    string extension = Path.GetExtension(selectedFilePath).ToLower();
                    if (extension == ".png" || extension == ".jpg" || extension == ".jpeg")
                    {
                        // Преобразуем изображение в массив байтов
                        byte[] imageBytes = File.ReadAllBytes(selectedFilePath);

                        // Вставляем изображение в базу данных (например, добавляем или обновляем запись)
                        SaveImageToDatabase(imageBytes); // Call your method for saving image data
                        MessageBox.Show("Изображение успешно загружено.");
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат файла. Пожалуйста, выберите изображение (.png, .jpg, .jpeg).");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
                }
            }
        }


        private byte[] ConvertImageToByteArray(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return null;

            try
            {
                return System.IO.File.ReadAllBytes(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error converting image to byte array: " + ex.Message);
                return null;
            }
        }

    }
    }
