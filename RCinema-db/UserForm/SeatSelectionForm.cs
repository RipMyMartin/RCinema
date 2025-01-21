using RCinema_db.src.Movie;
using RCinema_db.src.MovieSession;
using RCinema_db.src.Seat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace RCinema_db.UserForm
{
    public partial class SeatSelectionForm : Form
    {
        private string _connectionString = Database.DatabaseConnection.connectionString;
        private Movie _selectedMovie;
        private int _userId;
        private Dictionary<string, bool> seatAvailability = new Dictionary<string, bool>(); // true for available, false for booked

        public SeatSelectionForm(Movie movie, int userId)
        {
            InitializeComponent();
            _selectedMovie = movie;
            _userId = userId;

            // Load sessions
            LoadSessions();

            // Setup seats
            SetupSeats();  // Add the call to this method
        }

        private void LoadSessions()
        {
            string query = "SELECT id, time, totalAvailableSeats FROM Sessions WHERE movieID = @MovieID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MovieID", _selectedMovie.Id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int sessionId = reader.GetInt32(0);
                                DateTime startTime = reader.GetDateTime(1);
                                int totalSeats = reader.GetInt32(2);

                                // Create session object
                                var session = new src.MovieSession.Sessions(sessionId, startTime, totalSeats);

                                // Add session to ComboBox
                                comboBox_Sessions.Items.Add(session);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading sessions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void SaveBooking(int movieId, string seatId, int userId, decimal totalAmount, string title)
        {
            // Save the booking to the database
            string query = "INSERT INTO TicketInfo (movieID, seatId, userID, ticketPrice, subtotal, title) " +
                           "VALUES (@movieId, @seatId, @userId, @ticketPrice, @subtotal, @title)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection)) // Pass the connection to the SqlCommand
                    {
                        cmd.Parameters.AddWithValue("@movieId", movieId);
                        cmd.Parameters.AddWithValue("@seatId", seatId); // Insert seatId
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@ticketPrice", 10.00m);  // Example ticket price
                        cmd.Parameters.AddWithValue("@subtotal", totalAmount);
                        cmd.Parameters.AddWithValue("@title", title);  // Provide the title value

                        // Execute the command to insert the record
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }








        private void Btn_ConfirmPurchase_Click(object sender, EventArgs e)
        {
            if (comboBox_Sessions.SelectedIndex >= 0)
            {
                Sessions selectedSession = (Sessions)comboBox_Sessions.SelectedItem;

                // Calculate the number of selected seats and the total amount
                int selectedSeatsCount = GetSelectedSeats().Count;
                decimal totalAmount = selectedSeatsCount * 10.00m;  // Assuming each ticket costs $10.00

                // Logic for booking - Pass each seat individually to the SaveBooking method
                foreach (string seat in GetSelectedSeats())
                {
                    SaveBooking(selectedSession.MovieId, seat, _userId, totalAmount, _selectedMovie.Title);
                }
            }
            else
            {
                MessageBox.Show("Please select a session.", "No Session Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetupSeats()
        {
            int seatWidth = 30;
            int seatHeight = 30;

            // Получаем список забронированных мест для выбранного сеанса
            List<string> bookedSeats = GetBookedSeatsForSelectedSession();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    string seatKey = $"{i + 1}-{j + 1}"; // e.g., "1-1", "1-2", etc.

                    Button seatButton = new Button();
                    seatButton.Size = new Size(seatWidth, seatHeight);
                    seatButton.Location = new Point(seatWidth * i, seatHeight * j);
                    seatButton.Text = seatKey;
                    seatButton.Click += SeatButton_Click;

                    // Если место забронировано, изменяем цвет кнопки на красный
                    if (bookedSeats.Contains(seatKey))
                    {
                        seatButton.BackColor = Color.Red; // Забронировано (красное)
                        seatButton.Enabled = false; // Выключаем кнопку, чтобы нельзя было выбрать это место
                    }
                    else
                    {
                        seatButton.BackColor = Color.Green; // Доступное место (зеленое)
                    }

                    panel_Seats.Controls.Add(seatButton);
                }
            }
        }

        private List<string> GetBookedSeatsForSelectedSession()
        {
            List<string> bookedSeats = new List<string>();

            if (comboBox_Sessions.SelectedIndex >= 0)
            {
                Sessions selectedSession = (Sessions)comboBox_Sessions.SelectedItem;
                string query = "SELECT seatsBooked FROM TicketInfo WHERE movieID = @MovieID AND time = @SessionTime";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MovieID", _selectedMovie.Id);  // ID фильма
                            command.Parameters.AddWithValue("@SessionTime", selectedSession.StartTime);  // Время сеанса

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string seats = reader.GetString(0);
                                    if (!string.IsNullOrEmpty(seats))
                                    {
                                        bookedSeats.AddRange(seats.Split(','));
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading booked seats: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return bookedSeats;
        }



        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button seatButton = (Button)sender;
            string seatKey = seatButton.Text;

            if (seatButton.BackColor == Color.Green)  // If it's available
            {
                seatButton.BackColor = Color.Yellow; // Mark as selected (yellow)
            }
            else if (seatButton.BackColor == Color.Yellow)  // If it's selected
            {
                seatButton.BackColor = Color.Green; // Unselect the seat
            }

            lbl_SelectedSeats.Text = $"Selected Seats: {GetSelectedSeats()}";
            lbl_TotalAmount.Text = $"Total: ${GetSelectedSeats().Count * 10.00m}";
        }

        private List<string> GetSelectedSeats()
        {
            List<string> selectedSeats = new List<string>();
            foreach (Button btn in panel_Seats.Controls)
            {
                if (btn.BackColor == Color.Yellow) // Selected seats should be yellow
                {
                    selectedSeats.Add(btn.Text);
                }
            }
            return selectedSeats;
        }

        private void ComboBox_Sessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Sessions.SelectedIndex >= 0)
            {
                // Get the selected session
                Sessions selectedSession = (Sessions)comboBox_Sessions.SelectedItem;

                // Update the form with session information
                lbl_SessionInfo.Text = $"Selected Session: {selectedSession.StartTime.ToString("yyyy-MM-dd HH:mm")}";
                lbl_AvailableSeats.Text = $"Available Seats: {selectedSession.TotalAvailableSeats}";
            }
        }

        private void btn_Buy_Ticket_Click(object sender, EventArgs e)
        {
            if (comboBox_Sessions.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a session first.", "No Session Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> selectedSeats = GetSelectedSeats();
            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Please select at least one seat.", "No Seat Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Sessions selectedSession = (Sessions)comboBox_Sessions.SelectedItem;
            decimal totalAmount = selectedSeats.Count * 10.00m;  // Assuming each ticket costs $10.00

            // Logic to save booking for each selected seat
            foreach (string seatId in selectedSeats)
            {
                SaveBooking(selectedSession.MovieId, seatId, _userId, totalAmount, _selectedMovie.Title);
            }

            // Show success message
            MessageBox.Show("Your booking is successful!", "Booking Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
