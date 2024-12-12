using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace RCinema_db
{
    public partial class MainForm : Form
    {
        private const string ApiKey = "c3099c33";
        private const string BaseUrl = "http://www.omdbapi.com/";

        public MainForm()
        {
            InitializeComponent();
            LoadMoviesFromApi();
        }

        private async void LoadMoviesFromApi()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetFromJsonAsync<MovieApiResponse>($"{BaseUrl}?apikey={ApiKey}&s=star+wars");

                    if (response?.Search != null)
                    {
                        foreach (var movie in response.Search)
                        {
                            Console.WriteLine($"Title: {movie.Title}, Poster: {movie.Poster}");

                            var pictureBox = new PictureBox
                            {
                                ImageLocation = string.IsNullOrEmpty(movie.Poster)
                                    ? "https://via.placeholder.com/150x200?text=No+Image"
                                    : movie.Poster,
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Size = new System.Drawing.Size(150, 200),
                                Cursor = Cursors.Hand,
                                Tag = movie
                            };

                            pictureBox.Click += (sender, args) =>
                            {
                                var selectedMovie = (Movie)((PictureBox)sender).Tag;
                                MessageBox.Show($"Название: {selectedMovie.Title}\nОписание: {selectedMovie.Plot}");
                            };

                            flowLayoutPanelMovies.Controls.Add(pictureBox);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Данные о фильмах не найдены.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки фильмов: {ex.Message}");
            }
        }

        public class MovieApiResponse
        {
            public List<Movie> Search { get; set; }
        }

        public class Movie
        {
            public string Title { get; set; }
            public string Plot { get; set; }
            public string Poster { get; set; }
        }
    }
}
