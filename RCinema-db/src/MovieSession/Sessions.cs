using System;

namespace RCinema_db.src.MovieSession
{
    public class Sessions
    {
        public int MovieId { get; set; } // Add a public setter for movieId
        public DateTime Time1 { get; set; } // Add public setter for session1
        public DateTime Time2 { get; set; } // Add public setter for session2
        public DateTime Time3 { get; set; } // Add public setter for session3
        public DateTime Time4 { get; set; } // Add public setter for session4
        public DateTime Time5 { get; set; } // Add public setter for session5
        public int TotalAvailableSeats { get; set; } // Add public setter

        public Sessions()
        {

        }

        public Sessions(int movieId, DateTime time1, DateTime time2, DateTime time3, DateTime time4, DateTime time5, int totalAvailableSeats)
        {
            MovieId = movieId;
            Time1 = time1;
            Time2 = time2;
            Time3 = time3;
            Time4 = time4;
            Time5 = time5;
            TotalAvailableSeats = totalAvailableSeats;
        }
    }
}
