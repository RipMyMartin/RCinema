using Microsoft.VisualBasic.ApplicationServices;
using MovieTicketApp.src.Managers;
using RCinema_db.Account;
using RCinema_db.src.Managers;
using RCinema_db.src.Movie;
using RCinema_db.src.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCinema_db.User
{
    public partial class UserProfile : Form
    {

        private int _userId;
        public UserProfile(int userId)
        {
            _userId = userId;

            InitializeComponent();

            pic_Ticket.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Ticket.Image = Image.FromFile("ticket.png");
            pic_Ticket.Visible = false;
            lbl_MovieName.Visible = false;
            lbl_MovieTime.Visible = false;
            lbl_Seats.Visible = false;


        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            MessageBox.Show("You clicked: " + clickedButton.Text);
        }


        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword changePasswordForm = new ChangePassword();
            changePasswordForm.Show();
            this.Hide();
        }

        private void Form_UserProfile_Load(object sender, EventArgs e)
        {
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            listBox_Bookings.Items.Clear();

            foreach (Booking booking in GlobalData.Bookings)
            {
                Movie movie = GlobalData.Movies.FirstOrDefault(m => m.Id == booking.MovieID);

                string bookingInfo = $"Movie Title: {movie?.Title},  Booking ID: {booking.BookingID}";
                listBox_Bookings.Items.Add(bookingInfo);
            }
        }

        private void listBox_Bookings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Bookings.SelectedItem != null)
            {
                string selectedBookingInfo = listBox_Bookings.SelectedItem.ToString();

                string[] parts = selectedBookingInfo.Split(new[] { ", " }, StringSplitOptions.None);

                if (parts.Length >= 2)
                {
                    string part = parts[1];
                    string[] splitParts = part.Split(':');
                    if (splitParts.Length == 2)
                    {
                        if (int.TryParse(splitParts[1].Trim(), out int bookingID))
                        {
                            Booking? selectedBooking = GlobalData.Bookings.FirstOrDefault(booking => booking.BookingID == bookingID);

                            if (selectedBooking != null)
                            {
                                Movie? movie = GlobalData.Movies.FirstOrDefault(m => m.Id == selectedBooking.MovieID);

                                string movieTitle = movie != null ? movie.Title : "Movie Not Found";

                                lbl_MovieName.Text = "Movie Title: " + movieTitle;
                                lbl_MovieTime.Text = "Time: " + selectedBooking.Session.ToString("HH:mm");
                                lbl_Seats.Text = "Seats: " + selectedBooking.SeatsBooked.Replace('-', ',');

                                pic_Ticket.Visible = true;
                                lbl_MovieName.Visible = true;
                                lbl_MovieTime.Visible = true;
                                lbl_Seats.Visible = true;
                                lbl_Seats.BackColor = Color.Transparent;
                                lbl_MovieTime.BackColor = Color.Transparent;
                                lbl_Seats.BackColor = Color.Transparent;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void lbl_MovieName_Click(object sender, EventArgs e)
        {

        }

        private void btn_BackToMovies_Click_1(object sender, EventArgs e)
        {
            Movies movies = new Movies(_userId);
            movies.Show();
            this.Close();
        }

        private void btn_GoToChangePW_Click_1(object sender, EventArgs e)
        {
            ChangePassword form = new ChangePassword();
            form.Show();
            this.Close();
        }
    }
}
