using RCinema_db.FrontEnd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using RCinema_db.Database;
using RCinema_db.FrontEnd.Default;

namespace RCinema_db
{
    public partial class HomeForm : Form
    {
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ripmy\source\repos\RCinema-db\RCinema-db\Database\Database.mdf;Integrated Security=True";
        public HomeForm()
        {
            InitializeComponent();
            dataCreate();
            LoadMovies();
        }

        private void dataCreate()
        {
            var database = new DatabaseCreateClass();
            database.CreateDatabase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var scheduleForm = new ScheduleForm();
            scheduleForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var moviesForm = new MoviesForm();
            moviesForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var specialForm = new SpecialForm();
            specialForm.Show();
        }

        private void LoadMovies()
        {
            string query = @"
            SELECT 
                m.MovieName, 
                m.MovieImage, 
                m.MovieStart, 
                l.Language
            FROM movies m
            INNER JOIN languages l ON m.LanguageID = l.LanguageID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                int yOffset = 120;
                int xOffset = 70;

                while (reader.Read())
                {
                    string movieName = reader["MovieName"].ToString();
                    byte[] movieImage = (reader["MovieImage"] != DBNull.Value) ? (byte[])reader["MovieImage"] : null;
                    TimeSpan? movieStart = reader["MovieStart"] as TimeSpan?;
                    string language = reader["Language"].ToString();

                    AddMovieComponent(movieName, movieImage, movieStart, language, ref xOffset, ref yOffset);
                }
            }
        }

        private void AddMovieComponent(string movieName, byte[] movieImage, TimeSpan? movieStart, string language, ref int xOffset, ref int yOffset)
        {
            Panel panel = new Panel
            {
                Width = 300,
                Height = 120,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                Left = xOffset, 
                Top = yOffset 
            };

            // Добавляем картинку
            PictureBox pictureBox = new PictureBox
            {
                Width = 100,
                Height = 100,
                Left = 10,
                Top = 10,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            if (movieImage != null && movieImage.Length > 0)
            {
                pictureBox.Image = ByteArrayToImage(movieImage); 
            }
            else
            {
                pictureBox.Image = DefaultImage.GetCinemaImage_NewLife();
            }

            panel.Controls.Add(pictureBox);

            Label lblName = new Label
            {
                Text = $"Название: {movieName}",
                Left = 120,
                Top = 10,
                Width = 160
            };
            panel.Controls.Add(lblName);

            Label lblTime = new Label
            {
                Text = $"Время: {(movieStart.HasValue ? movieStart.Value.ToString(@"hh\:mm") : "N/A")}",
                Left = 120,
                Top = 50,
                Width = 160
            };
            panel.Controls.Add(lblTime);

            // Добавляем язык
            Label lblLanguage = new Label
            {
                Text = $"Язык: {language}",
                Left = 120,
                Top = 80, 
                Width = 160
            };
            panel.Controls.Add(lblLanguage);

            this.Controls.Add(panel);

            panel.Click += (sender, e) => {
                MovieDetailsForm detailsForm = new MovieDetailsForm(movieName, movieImage, movieStart, language);
                detailsForm.Show();
            };
            xOffset += panel.Width + 70; 

            if (xOffset >= 2 * (panel.Width + 70))
            {
                xOffset = 70; 
                yOffset += panel.Height + 20; 
            }
        }




        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
