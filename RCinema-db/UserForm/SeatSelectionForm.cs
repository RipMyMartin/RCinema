using RCinema_db.src.Movie;
using RCinema_db.src.MovieSession;
using RCinema_db.src.Seat;
using RCinema_db.User;
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
        private Button[,] seatButtons;
        private const int Rows = 5;
        private const int Columns = 5;

        public SeatSelectionForm(Movie movie, int userId)
        {
            InitializeComponent();
            _selectedMovie = movie;
            _userId = userId;

            LoadMovieDetails();
            CreateSeatGrid();
            LoadSeatAvailability();
        }

        private void LoadMovieDetails()
        {
            lbl_Title.Text = _selectedMovie.Title;
            lbl_GenreDuration.Text = $"{_selectedMovie.Duration} mins, {_selectedMovie.Genre}";
            lbl_ReleaseDate.Text = $"Released on {_selectedMovie.ReleaseDate:dd MMM yyyy}";
            txt_Description.Text = _selectedMovie.Description;

            if (!string.IsNullOrEmpty(_selectedMovie.Poster))
            {
                try
                {
                    pic_Poster.Image = Image.FromFile(_selectedMovie.Poster);
                }
                catch
                {
                    pic_Poster.Image = null;
                }
            }
        }

        private void CreateSeatGrid()
        {
            seatButtons = new Button[Rows, Columns];

            // Set FlowLayoutPanel properties to arrange the buttons in a grid-like pattern
            flow_SeatGrid.FlowDirection = FlowDirection.TopDown;
            flow_SeatGrid.WrapContents = true;

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Button seatButton = new Button
                    {
                        Width = 40,
                        Height = 40,
                        Margin = new Padding(5),
                        Tag = new { Row = row, Column = col },
                        BackColor = Color.LightGreen
                    };
                    seatButton.Click += SeatButton_Click;

                    seatButtons[row, col] = seatButton;
                    flow_SeatGrid.Controls.Add(seatButton);
                }
            }
        }

        private void LoadSeatAvailability()
        {
            string query = "SELECT seatsBooked FROM Bookings WHERE movieID = @MovieId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MovieId", _selectedMovie.Id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<string> bookedSeats = new List<string>();

                while (reader.Read())
                {
                    // Получаем забронированные места как строку (например, "A1, A2, B3")
                    string seats = reader.GetString(0);
                    bookedSeats.AddRange(seats.Split(','));
                }

                // Пройдем по всем кнопкам и проверим, заняты ли они
                for (int row = 0; row < Rows; row++)
                {
                    for (int col = 0; col < Columns; col++)
                    {
                        string seatName = $"{(char)(row + 'A')}{col}";

                        if (bookedSeats.Contains(seatName))
                        {
                            seatButtons[row, col].BackColor = Color.Red; // Место занято
                            seatButtons[row, col].Enabled = false; // Сделать кнопку неактивной
                        }
                        else
                        {
                            seatButtons[row, col].BackColor = Color.LightGreen; // Место свободно
                            seatButtons[row, col].Enabled = true;
                        }
                    }
                }
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                var position = (dynamic)clickedButton.Tag;
                int row = position.Row;
                int column = position.Column;

                // Если место уже забронировано (красное), то не даем его выбрать
                if (clickedButton.BackColor == Color.Red)
                {
                    MessageBox.Show("This seat has already been booked.");
                    return; 
                }

                // Если место свободно (зеленое), выбираем его
                if (clickedButton.BackColor == Color.LightGreen)
                {
                    clickedButton.BackColor = Color.Yellow; // Выбираем место
                }
                else if (clickedButton.BackColor == Color.Yellow)
                {
                    clickedButton.BackColor = Color.LightGreen; // Отменяем выбор
                }
            }
        }
        private void btn_Book_Click(object sender, EventArgs e)
        {
            List<string> selectedSeats = new List<string>();

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (seatButtons[row, col].BackColor == Color.Yellow)  // Yellow for selected seats
                    {
                        selectedSeats.Add($"{(char)(row + 'A')}{col}");
                    }
                }
            }

            if (selectedSeats.Count > 0)
            {
                string seats = string.Join(",", selectedSeats);

                // Проверка, не забронировано ли уже место в базе данных
                string checkSeatsQuery = "SELECT SeatRow, SeatColumn FROM Seats WHERE MovieId = @MovieId AND IsBooked = 1 AND SeatRow + '-' + SeatColumn IN (@Seats)";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand checkSeatsCommand = new SqlCommand(checkSeatsQuery, connection);
                    checkSeatsCommand.Parameters.AddWithValue("@MovieId", _selectedMovie.Id);
                    checkSeatsCommand.Parameters.AddWithValue("@Seats", string.Join(",", selectedSeats));  // Проверка выбранных мест

                    connection.Open();
                    SqlDataReader reader = checkSeatsCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        return; // Если хотя бы одно место занято, прерываем бронирование
                    }
                }

                // Если все места свободны, продолжаем бронирование
                string query = "INSERT INTO Bookings (session, numberOfTickets, seatsBooked, subtotal, ticketType, userID, MovieId) " +
                               "VALUES (@Session, @Tickets, @Seats, @Subtotal, @Type, @UserId, @MovieId);";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Session", DateTime.Now);
                    command.Parameters.AddWithValue("@Tickets", selectedSeats.Count);
                    command.Parameters.AddWithValue("@Seats", seats);
                    command.Parameters.AddWithValue("@Subtotal", selectedSeats.Count * 10.0m);  // Assuming $10 per ticket
                    command.Parameters.AddWithValue("@Type", "Standard");
                    command.Parameters.AddWithValue("@UserId", _userId);
                    command.Parameters.AddWithValue("@MovieId", _selectedMovie.Id);  // Добавлен MovieId

                    connection.Open();

                    // Выполнение команды на добавление в таблицу Bookings
                    command.ExecuteNonQuery();

                    // Обновление статуса занятых мест в таблице Seats
                    foreach (var seat in selectedSeats)
                    {
                        var seatParts = seat.Split('-'); // Разделяем строку на два элемента: ряд и колонка
                        if (seatParts.Length == 2)
                        {
                            string row = seatParts[0];
                            int column = int.Parse(seatParts[1]);

                            // Обновление статуса занятости места
                            string updateSeatQuery = "UPDATE Seats SET IsBooked = 1 WHERE MovieId = @MovieId AND SeatRow = @Row AND SeatColumn = @Column";
                            SqlCommand updateSeatCommand = new SqlCommand(updateSeatQuery, connection);
                            updateSeatCommand.Parameters.AddWithValue("@MovieId", _selectedMovie.Id); // Передаем MovieId
                            updateSeatCommand.Parameters.AddWithValue("@Row", row);
                            updateSeatCommand.Parameters.AddWithValue("@Column", column);

                            updateSeatCommand.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Booking successful!");

                    EmailForm emailForm = new EmailForm(_selectedMovie.Title, seats, selectedSeats.Count, selectedSeats.Count * 10.0m);
                    emailForm.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select at least one seat.");
            }
        }



        private void btn_BackToMovies_Click_1(object sender, EventArgs e)
        {
            Movies moviesForm = new Movies(_userId);
            moviesForm.Show();
            this.Close();
        }
    }
}
