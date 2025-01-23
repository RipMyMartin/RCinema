using MovieTicketApp.src.Managers;
using RCinema_db.src.MovieSession;

namespace RCinema_db.Admin
{
    public partial class UpdateSession : Form
    {
        private static int _userId;
        public UpdateSession(int userId)
        {
            InitializeComponent();
            _userId = userId;
            sessionGrid.DataSource = GlobalData.Sessions;

            dateTimePicker_SessionTime.Format = DateTimePickerFormat.Custom;
            dateTimePicker_SessionTime.CustomFormat = "hh:mm tt";
            dateTimePicker_SessionTime.ShowUpDown = true;
        }

        private void sessionGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = sessionGrid.Rows[index];

            if (selectedRow != null)
            {
                textBox_MovieID.Text = selectedRow.Cells[0].Value.ToString();

                if (DateTime.TryParse(selectedRow.Cells[1].Value.ToString(), out DateTime sessionTime))
                {
                    dateTimePicker_SessionTime.Value = sessionTime;
                }

                int availableSeats = (int)numericUpDown_seats.Value;

                numericUpDown_seats.Value = (int)selectedRow.Cells[2].Value;
            }
        }

        private void sessionGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (e.Value is DateTime dateTimeValue)
                {
                    e.Value = dateTimeValue.ToString("HH:mm");
                    e.FormattingApplied = true;
                }
            }
        }

        private void btn_CreateNewSession_Click(object sender, EventArgs e)
        {
            if (!ValidateSessionData())
            {
                return; 
            }

            int movieID = int.Parse(textBox_MovieID.Text);
            DateTime sessionTime = dateTimePicker_SessionTime.Value;
            int availableSeats = (int)numericUpDown_seats.Value;

            bool sessionExists = GlobalData.Sessions.Any(session =>
                session.MovieID == movieID && session.Time == sessionTime);

            if (sessionExists)
            {
                MessageBox.Show("A session with the same movie and time already exists.");
                return;
            }

            // Create the new session
            MovieSession newSession = new MovieSession(movieID, sessionTime, availableSeats);
            GlobalData.Sessions.Add(newSession);

            sessionGrid.DataSource = null;
            sessionGrid.DataSource = GlobalData.Sessions;
            sessionGrid.Refresh();

            MessageBox.Show("Session added successfully.");
        }

        private void btn_UpdateSession_Click(object sender, EventArgs e)
        {
            if (!ValidateSessionData())
            {
                return; 
            }

            MovieSession? sessionToUpdate = GlobalData.Sessions.FirstOrDefault(session =>
                session.MovieID == int.Parse(textBox_MovieID.Text) && session.Time == dateTimePicker_SessionTime.Value);

            if (sessionToUpdate == null)
            {
                MessageBox.Show("Session not found.");
                return;
            }

            sessionToUpdate.AvailableSeats = (int)numericUpDown_seats.Value;

            sessionGrid.DataSource = null;
            sessionGrid.DataSource = GlobalData.Sessions;
            sessionGrid.Refresh();

            MessageBox.Show("Session data updated successfully.");
        }


        private void btn_DeleteSession_Click(object sender, EventArgs e)
        {
            int movieIDToDelete = int.Parse(textBox_MovieID.Text);
            DateTime sessionTimeToDelete = dateTimePicker_SessionTime.Value;

            int sessionIndexToDelete = GlobalData.Sessions.FindIndex(session =>
                session.MovieID == movieIDToDelete && session.Time == sessionTimeToDelete);

            if (sessionIndexToDelete == -1)
            {
                MessageBox.Show("Session not found.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this session?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                GlobalData.Sessions.RemoveAt(sessionIndexToDelete);

                sessionGrid.DataSource = null;
                sessionGrid.DataSource = GlobalData.Sessions;
                sessionGrid.Refresh();

                MessageBox.Show("Session deleted successfully.");
            }
        }



        private bool ValidateSessionData()
        {
            int movieID;
            if (!int.TryParse(textBox_MovieID.Text, out movieID))
            {
                MessageBox.Show("Movie ID must be a valid integer.");
                return false;
            }

            int availableSeats = (int)numericUpDown_seats.Value;
            if (availableSeats < 0 || availableSeats > 20) 
            {
                MessageBox.Show("Available seats must be between 0 and 20.");
                return false;
            }

            return true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            FileManager.SaveSessions();
            AdminView form = new AdminView(_userId);
            form.Show();
            this.Hide();
        }
    }
}
