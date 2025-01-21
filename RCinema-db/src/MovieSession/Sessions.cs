namespace RCinema_db.src.MovieSession
{
    public class Sessions
    {
        public int MovieId { get; set; } // Movie ID
        public DateTime StartTime { get; set; } // Start time of the session
        public int TotalAvailableSeats { get; set; } // Total available seats for the session

        public Sessions(int movieId, DateTime startTime, int totalAvailableSeats)
        {
            MovieId = movieId;
            StartTime = startTime;
            TotalAvailableSeats = totalAvailableSeats;
        }

        public override string ToString()
        {
            return $"{StartTime.ToString("yyyy-MM-dd HH:mm")} - {TotalAvailableSeats} seats available";
        }
    }
}
