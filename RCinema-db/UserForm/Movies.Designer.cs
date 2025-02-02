namespace RCinema_db.User
{
    partial class Movies
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btn_UserProfile = new Button();
            btn_Log_Out = new Button();
            lbl_Movie_Release_Date = new Label();
            txt_Movie_Description = new TextBox();
            lbl_Movie_Duration_Genre = new Label();
            lbl_Movie_Title = new Label();
            picbox_Movie_Poster = new PictureBox();
            lbl_Title = new Label();
            listbox_Movies = new ListBox();
            btn_BuyTicket = new Button();
            ((System.ComponentModel.ISupportInitialize)picbox_Movie_Poster).BeginInit();
            SuspendLayout();

            // Общий стиль формы
            BackColor = Color.FromArgb(30, 30, 30);
            ForeColor = Color.White;
            Font = new Font("Arial", 10F, FontStyle.Regular);

            // Заголовок
            lbl_Title.AutoSize = true;
            lbl_Title.Font = new Font("Arial", 24F, FontStyle.Bold);
            lbl_Title.ForeColor = Color.Orange;
            lbl_Title.Location = new Point(20, 20);
            lbl_Title.Text = "Current Movies";

            // Список фильмов
            listbox_Movies.Font = new Font("Arial", 12F);
            listbox_Movies.BackColor = Color.FromArgb(45, 45, 45);
            listbox_Movies.ForeColor = Color.White;
            listbox_Movies.Location = new Point(20, 80);
            listbox_Movies.Size = new Size(220, 300);
            listbox_Movies.SelectedIndexChanged += listbox_Movies_SelectedIndexChanged_1;

            // Постер фильма
            picbox_Movie_Poster.Location = new Point(260, 80);
            picbox_Movie_Poster.Size = new Size(180, 250);
            picbox_Movie_Poster.SizeMode = PictureBoxSizeMode.Zoom;

            // Название фильма
            lbl_Movie_Title.Font = new Font("Arial", 16F, FontStyle.Bold);
            lbl_Movie_Title.ForeColor = Color.Cyan;
            lbl_Movie_Title.Location = new Point(460, 80);
            lbl_Movie_Title.AutoSize = true;

            // Дата выхода
            lbl_Movie_Release_Date.Font = new Font("Arial", 12F);
            lbl_Movie_Release_Date.Location = new Point(460, 120);
            lbl_Movie_Release_Date.AutoSize = true;

            // Жанр и длительность
            lbl_Movie_Duration_Genre.Font = new Font("Arial", 12F);
            lbl_Movie_Duration_Genre.Location = new Point(460, 150);
            lbl_Movie_Duration_Genre.AutoSize = true;

            // Описание
            txt_Movie_Description.BackColor = Color.FromArgb(45, 45, 45);
            txt_Movie_Description.ForeColor = Color.White;
            txt_Movie_Description.BorderStyle = BorderStyle.FixedSingle;
            txt_Movie_Description.Font = new Font("Arial", 10F);
            txt_Movie_Description.Location = new Point(460, 180);
            txt_Movie_Description.Multiline = true;
            txt_Movie_Description.Size = new Size(300, 100);

            // Кнопка покупки билета
            btn_BuyTicket.Font = new Font("Arial", 12F, FontStyle.Bold);
            btn_BuyTicket.ForeColor = Color.White;
            btn_BuyTicket.BackColor = Color.Green;
            btn_BuyTicket.Location = new Point(460, 300);
            btn_BuyTicket.Size = new Size(150, 50);
            btn_BuyTicket.Text = "Buy Ticket";
            btn_BuyTicket.Click += btn_BuyTicket_Click;

            // Кнопка выхода
            btn_Log_Out.Font = new Font("Arial", 10F, FontStyle.Bold);
            btn_Log_Out.ForeColor = Color.White;
            btn_Log_Out.BackColor = Color.Red;
            btn_Log_Out.Location = new Point(620, 20);
            btn_Log_Out.Size = new Size(100, 30);
            btn_Log_Out.Text = "Log Out";
            btn_Log_Out.Click += btn_Log_Out_Click;

            // Добавление элементов на форму
            Controls.Add(lbl_Title);
            Controls.Add(listbox_Movies);
            Controls.Add(picbox_Movie_Poster);
            Controls.Add(lbl_Movie_Title);
            Controls.Add(lbl_Movie_Release_Date);
            Controls.Add(lbl_Movie_Duration_Genre);
            Controls.Add(txt_Movie_Description);
            Controls.Add(btn_BuyTicket);
            Controls.Add(btn_Log_Out);

            Text = "Movies";
            ClientSize = new Size(800, 450);
            FormBorderStyle = FormBorderStyle.FixedSingle;

            ((System.ComponentModel.ISupportInitialize)picbox_Movie_Poster).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_UserProfile;
        private Button btn_Log_Out;
        private Label lbl_Movie_Release_Date;
        private TextBox txt_Movie_Description;
        private Label lbl_Movie_Duration_Genre;
        private Label lbl_Movie_Title;
        private PictureBox picbox_Movie_Poster;
        private Label lbl_Title;
        private ListBox listbox_Movies;
        private Button btn_BuyTicket;
    }
}
