using MovieTicketApp.src.Managers;
using MovieTicketApp;
using Microsoft.VisualBasic.Devices;
using RCinema_db.src.MovieSession;
using RCinema_db.src.Movie;

namespace RCinema_db.src.Movie
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }

        public Duration Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<MovieSession.MovieSession> Sessions = new List<MovieSession.MovieSession>();

        public Movie(int movieID, string title, string genre, int hours, int minutes, int year, int month, int day, string description, string poster)
        {
            this.Id = movieID;
            this.Title = title;
            this.Genre = genre;
            this.Hours = hours;
            this.Minutes = minutes;
            this.Year = year;
            this.Month = month;
            this.Day = day;
            this.Description = description;
            this.Poster = poster;

            this.Duration = new Duration(Hours, Minutes);
            this.ReleaseDate = new DateTime(Year, Month, Day);
            LoadSessionsFromFile("sessions.txt");
        }

        public static Movie CreateNewMovie(string title, string genre, int hours, int minutes, int year, int month, int day, string description, string poster)
        {
            int newMovieId = GenerateNewMovieId();
            Movie movie = new Movie(newMovieId, title, genre, hours, minutes, year, month, day, description, poster);
            GlobalData.Movies.Add(movie);
            return movie;
        }

        private static int GenerateNewMovieId()
        {
            int maxId = GlobalData.Movies.Max(m => m.Id);
            return maxId + 1;
        }

        public void LoadSessionsFromFile(string sessionsFilePath)
        {
            if (File.Exists(sessionsFilePath))
            {
                string[] sessionLines = File.ReadAllLines(sessionsFilePath);

                foreach (string line in sessionLines)
                {
                    string[] parts = line.Split(','); 

                    if (parts.Length == 3)
                    {
                        if (int.TryParse(parts[0], out int movieId) &&
                            DateTime.TryParse(parts[1], out DateTime sessionTime) &&
                            int.TryParse(parts[2], out int availableSeats))
                        {
                            if (movieId == this.Id)
                            {
                                AddSession(movieId, sessionTime, availableSeats);
                            }
                        }
                    }
                }
            }
        }

        public void AddSession(int movieID, DateTime date, int availableSeats)
        {
            MovieSession.MovieSession session = new MovieSession.MovieSession(movieID, date, availableSeats);
            this.Sessions.Add(session);
        }

        public override string ToString()
        {
            return $"Movie: {this.Title}, Genre: {this.Genre}, Duration: {this.Hours}:{this.Minutes}, Description: {this.Description}";
        }
    }
}