using System;

namespace RCinema_db.src.MovieSession
{
    public class MovieSession
    {
        public int MovieID { get; set; }
        public DateTime Time { get; set; }
        public int AvailableSeats { get; set; }

        public MovieSession(int MovieID, DateTime time, int availableSeats)
        {
            this.MovieID = MovieID;
            Time = time;
            AvailableSeats = availableSeats;
        }
    }
}