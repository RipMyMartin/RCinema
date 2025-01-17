using RCinema_db.FrontEnd.Default;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RCinema_db
{
    public partial class MovieDetailsForm : Form
    {
        private Button[,] seats;
        private decimal seatPrice = 10.0m;
        private List<(int row, int col)> selectedSeats;

        public MovieDetailsForm(string movieName, byte[] movieImage, TimeSpan? movieStart, string language)
        {
            InitializeComponent();

            selectedSeats = new List<(int, int)>();

            // Заголовок фильма с улучшенным стилем
            Label lblMovieName = new Label
            {
                Text = $"Название: {movieName}",
                Left = 10,
                Top = 10,
                Width = 400,
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.White
            };
            this.Controls.Add(lblMovieName);

            // Изображение фильма с улучшениями
            PictureBox pictureBox = new PictureBox
            {
                Width = 120,
                Height = 120,
                Left = 220,
                Top = 10,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = DefaultImage.GetCinemaImage_NewLife() // Преобразование байтового массива в изображение
            };
            this.Controls.Add(pictureBox);

            // Время начала с улучшением шрифта и цвета
            Label lblTime = new Label
            {
                Text = $"Время: {(movieStart.HasValue ? movieStart.Value.ToString(@"hh\:mm") : "N/A")}",
                Left = 10,
                Top = 120,
                Width = 200,
                Font = new Font("Arial", 12),
                ForeColor = Color.White
            };
            this.Controls.Add(lblTime);

            // Язык с улучшением шрифта и цвета
            Label lblLanguage = new Label
            {
                Text = $"Язык: {language}",
                Left = 10,
                Top = 150,
                Width = 200,
                Font = new Font("Arial", 12),
                ForeColor = Color.White
            };
            this.Controls.Add(lblLanguage);

            // Создание сетки мест с улучшениями
            seats = new Button[5, 8];
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Button seatButton = new Button
                    {
                        Width = 50,
                        Height = 50,
                        Left = 10 + col * 60,
                        Top = 200 + row * 60,
                        Text = $"{row + 1}-{col + 1}",
                        BackColor = Color.Green,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        ForeColor = Color.White
                    };
                    seatButton.Click += SeatButton_Click;
                    seats[row, col] = seatButton;
                    this.Controls.Add(seatButton);
                }
            }

            // Место для подсчета выбранных мест и цены с улучшением
            Label lblSelectedSeats = new Label
            {
                Text = "Выбранные места:",
                Left = 10,
                Top = 450,
                Width = 400,
                Font = new Font("Arial", 12),
                ForeColor = Color.White
            };
            this.Controls.Add(lblSelectedSeats);

            // Добавление кнопки с улучшением стиля
            Button btnSubmit = new Button
            {
                Text = "Забронировать",
                Left = 10,
                Top = 480,
                Width = 150,
                Height = 40,
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSubmit.Click += BtnSubmit_Click;
            this.Controls.Add(btnSubmit);

            // Изменение фона формы
            this.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button seatButton = sender as Button;
            string[] seatInfo = seatButton.Text.Split('-');
            int row = int.Parse(seatInfo[0]) - 1;
            int col = int.Parse(seatInfo[1]) - 1;

            // Если место уже выбрано, ставим красный цвет
            if (seatButton.BackColor == Color.Green)
            {
                seatButton.BackColor = Color.Red;
                selectedSeats.Add((row, col));
            }
            else if (seatButton.BackColor == Color.Red)
            {
                seatButton.BackColor = Color.Green;
                selectedSeats.Remove((row, col));
            }

            // Обновляем отображение выбранных мест и их цену
            UpdateSelectedSeats();
        }

        private void UpdateSelectedSeats()
        {
            string selectedSeatsText = "Выбранные места:\n";
            decimal totalPrice = 0;

            foreach (var seat in selectedSeats)
            {
                selectedSeatsText += $"Место {seat.row + 1}-{seat.col + 1}\n";
                totalPrice += seatPrice;
            }

            Label lblSelectedSeats = this.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text.StartsWith("Выбранные места"));
            lblSelectedSeats.Text = selectedSeatsText;

            Label lblPrice = this.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text.StartsWith("Общая цена"));
            if (lblPrice == null)
            {
                lblPrice = new Label
                {
                    Text = $"Общая цена: {totalPrice:C}",
                    Left = 10,
                    Top = 470,
                    Width = 200,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.Yellow
                };
                this.Controls.Add(lblPrice);
            }
            else
            {
                lblPrice.Text = $"Общая цена: {totalPrice:C}";
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            // Логика отправки выбора (например, сохранение в базу данных)
            MessageBox.Show("Ваши места забронированы!");
            this.Close(); // Закрытие формы
        }
    }
}
