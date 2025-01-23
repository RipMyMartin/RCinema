using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Data.SqlClient;
using RCinema_db.User;

namespace RCinema_db.UserForm
{
    public partial class EmailForm : Form
    {
        private string _seats;
        private decimal _subtotal;
        private int _tickets;
        private string _movieTitle;

        public EmailForm(string movieTitle, string seats, int tickets, decimal subtotal)
        {
            InitializeComponent();
            _seats = seats;
            _subtotal = subtotal;
            _tickets = tickets;
            _movieTitle = movieTitle;
        }

        private void btn_SendEmail_Click(object sender, EventArgs e)
        {
            string email = txt_Email.Text;
            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email.");
                return;
            }

            try
            {
                string pdfPath = GeneratePdf();

                SendEmail(email, pdfPath);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email. Error: {ex.Message}");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GeneratePdf()
        {
            string outputDir = Path.Combine(Application.StartupPath, "GeneratedFiles");
            if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);

            string pdfPath = Path.Combine(outputDir, "BookingDetails.pdf");

            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont fontTitle = new XFont("Arial", 16);
            XFont fontText = new XFont("Arial", 12);

            byte[] imageBytes = GetMoviePosterFromDatabase(_movieTitle);
            if (imageBytes != null)
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    XImage image = XImage.FromStream(ms);
                    gfx.DrawImage(image, 40, 40, 100, 100);
                }
            }

            gfx.DrawString($"Movie: {_movieTitle}", fontTitle, XBrushes.Black, 40, 160);
            gfx.DrawString($"Seats: {_seats}", fontText, XBrushes.Black, 40, 180);
            gfx.DrawString($"Tickets: {_tickets}", fontText, XBrushes.Black, 40, 200);
            gfx.DrawString($"Total: {_subtotal}", fontText, XBrushes.Black, 40, 220);

            document.Save(pdfPath);

            return pdfPath;
        }

        private byte[] GetMoviePosterFromDatabase(string movieTitle)
        {
            byte[] imageBytes = null;

            string connectionString = Database.DatabaseConnection.connectionString; 
            string query = "SELECT Poster FROM Movies WHERE Title = @MovieTitle";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MovieTitle", movieTitle);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        imageBytes = reader["Poster"] as byte[];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving image from database: {ex.Message}");
                }
            }

            return imageBytes;
        }

        public static void SendEmail(string recipientEmail, string pdfPath)
        {
            try
            {
                if (!File.Exists(pdfPath))
                {
                    MessageBox.Show($"PDF file does not exist: {pdfPath}");
                    return;
                }

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("martinsild.mr@gmail.com");
                    mail.To.Add(recipientEmail); 
                    mail.Subject = "Your Booking Details";
                    mail.Body = "Please find your booking details attached.";
                    mail.Attachments.Add(new Attachment(pdfPath));

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("martinsild.mr@gmail.com", "jjkg jwwe pqbl kzzg");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                MessageBox.Show("Email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email.\nError: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
        }
    }
}
