using System;
using MovieTicketApp.src.Managers;
using RCinema_db.src.Managers;

namespace RCinema_db.src.User
{
    [Serializable]

    public class Booking
    {
        public int BookingID { get; set; }
        public int MovieID { get; set; }
        public DateTime Session { get; set; }
        public int NumOfTickets { get; set; }
        public string SeatsBooked { get; set; }
        public double Subtotal { get; set; }
        public string TicketType { get; set; }
        public int UserID { get; set; }


        public Booking(int bookingID, int movieID, DateTime session, int numOfAttendees, string seatsBooked
            , double subtotal, string ticketType, int userID)
        {
            BookingID = bookingID;
            MovieID = movieID;
            Session = session;
            NumOfTickets = numOfAttendees;
            SeatsBooked = seatsBooked;
            TicketType = ticketType;
            UserID = userID;
            Subtotal = subtotal;
        }

        // Must use this method to create bookings or else it won't increment ID or add to global
        public static Booking CreateNewBooking(int movieId, DateTime session, int numOfAttendees, string seatsBooked
            , double subtotal, string ticketType, int userID)
        {
            int newBookingId = GenerateNewBookingId();
            Booking booking = new Booking(newBookingId, movieId, session,
                numOfAttendees, seatsBooked, subtotal, ticketType, userID);
            GlobalData.Bookings.Add(booking);
            return booking;
        }

        private static int GenerateNewBookingId()
        {
            int maxId = GlobalData.Bookings.Max(b => b.BookingID); // Find the maximum BookingId among existing bookings
            return maxId + 1;
        }
    }
}
