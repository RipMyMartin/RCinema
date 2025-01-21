using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using RCinema_db.src.Movie;
using RCinema_db.src.MovieSession;
using RCinema_db.src.User;

namespace MovieTicketApp.src.Managers
{
    internal class GlobalData
    {

        //Stores Global List<T> variables for access across the software
        public static List<Movie> Movies { get; set; } = new List<Movie>();
        public static List<Booking> Bookings { get; set; } = new List<Booking>();
        public static List<MovieSession> Sessions { get; set; } = new List<MovieSession>();
        public static List<UserData> UserData { get; set; } = new List<UserData>();

        // Clear or reset the data in the global lists
        public static void Clear()
        {
            Movies.Clear();
            Bookings.Clear();
            Sessions.Clear();
            UserData.Clear();
        }
    }
}
