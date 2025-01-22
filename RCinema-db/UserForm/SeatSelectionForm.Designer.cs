
namespace RCinema_db.UserForm
{
    partial class SeatSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lbl_Title;
        private Label lbl_GenreDuration;
        private Label lbl_ReleaseDate;
        private TextBox txt_Description;
        private PictureBox pic_Poster;
        private Button btn_SelectSeats;
        private FlowLayoutPanel flow_SeatGrid;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_Title = new Label();
            lbl_GenreDuration = new Label();
            lbl_ReleaseDate = new Label();
            txt_Description = new TextBox();
            pic_Poster = new PictureBox();
            btn_SelectSeats = new Button();
            flow_SeatGrid = new FlowLayoutPanel();
            btn_BackToMovies = new Button();
            ((System.ComponentModel.ISupportInitialize)pic_Poster).BeginInit();
            SuspendLayout();
            // 
            // lbl_Title
            // 
            lbl_Title.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbl_Title.Location = new Point(38, 81);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(400, 40);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "Movie Title";
            // 
            // lbl_GenreDuration
            // 
            lbl_GenreDuration.Font = new Font("Segoe UI", 12F);
            lbl_GenreDuration.Location = new Point(38, 131);
            lbl_GenreDuration.Name = "lbl_GenreDuration";
            lbl_GenreDuration.Size = new Size(400, 30);
            lbl_GenreDuration.TabIndex = 1;
            lbl_GenreDuration.Text = "Genre, Duration";
            // 
            // lbl_ReleaseDate
            // 
            lbl_ReleaseDate.Font = new Font("Segoe UI", 12F);
            lbl_ReleaseDate.Location = new Point(38, 171);
            lbl_ReleaseDate.Name = "lbl_ReleaseDate";
            lbl_ReleaseDate.Size = new Size(400, 30);
            lbl_ReleaseDate.TabIndex = 2;
            lbl_ReleaseDate.Text = "Release Date";
            // 
            // txt_Description
            // 
            txt_Description.Font = new Font("Segoe UI", 10F);
            txt_Description.Location = new Point(38, 211);
            txt_Description.Multiline = true;
            txt_Description.Name = "txt_Description";
            txt_Description.ReadOnly = true;
            txt_Description.Size = new Size(400, 200);
            txt_Description.TabIndex = 3;
            txt_Description.Text = "Description of the movie...";
            // 
            // pic_Poster
            // 
            pic_Poster.Location = new Point(468, 81);
            pic_Poster.Name = "pic_Poster";
            pic_Poster.Size = new Size(200, 300);
            pic_Poster.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Poster.TabIndex = 4;
            pic_Poster.TabStop = false;
            // 
            // btn_SelectSeats
            // 
            btn_SelectSeats.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_SelectSeats.Location = new Point(468, 401);
            btn_SelectSeats.Name = "btn_SelectSeats";
            btn_SelectSeats.Size = new Size(200, 50);
            btn_SelectSeats.TabIndex = 6;
            btn_SelectSeats.Text = "Select Seats";
            btn_SelectSeats.Click += btn_Book_Click;
            // 
            // flow_SeatGrid
            // 
            flow_SeatGrid.AutoScroll = true;
            flow_SeatGrid.FlowDirection = FlowDirection.TopDown;
            flow_SeatGrid.Location = new Point(724, 121);
            flow_SeatGrid.Name = "flow_SeatGrid";
            flow_SeatGrid.Size = new Size(301, 250);
            flow_SeatGrid.TabIndex = 5;
            flow_SeatGrid.WrapContents = false;
            // 
            // btn_BackToMovies
            // 
            btn_BackToMovies.BackColor = Color.Firebrick;
            btn_BackToMovies.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btn_BackToMovies.ForeColor = Color.White;
            btn_BackToMovies.Location = new Point(38, 26);
            btn_BackToMovies.Name = "btn_BackToMovies";
            btn_BackToMovies.Size = new Size(106, 40);
            btn_BackToMovies.TabIndex = 40;
            btn_BackToMovies.Text = "Go Back";
            btn_BackToMovies.UseVisualStyleBackColor = false;
            btn_BackToMovies.Click += btn_BackToMovies_Click_1;
            // 
            // SeatSelectionForm
            // 
            ClientSize = new Size(1082, 462);
            Controls.Add(btn_BackToMovies);
            Controls.Add(lbl_Title);
            Controls.Add(lbl_GenreDuration);
            Controls.Add(lbl_ReleaseDate);
            Controls.Add(txt_Description);
            Controls.Add(pic_Poster);
            Controls.Add(flow_SeatGrid);
            Controls.Add(btn_SelectSeats);
            Name = "SeatSelectionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Seat Selection";
            ((System.ComponentModel.ISupportInitialize)pic_Poster).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_BackToMovies;
    }
}