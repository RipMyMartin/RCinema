namespace RCinema_db.User
{
    partial class UserProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_Seats = new Label();
            lbl_MovieTime = new Label();
            lbl_MovieName = new Label();
            btn_BackToMovies = new Button();
            btn_GoToChangePW = new Button();
            label2 = new Label();
            pic_Ticket = new PictureBox();
            listBox_Bookings = new ListBox();
            label1 = new Label();
            lbl_Title_SignUp = new Label();
            ((System.ComponentModel.ISupportInitialize)pic_Ticket).BeginInit();
            SuspendLayout();
            // 
            // lbl_Seats
            // 
            lbl_Seats.AutoSize = true;
            lbl_Seats.BackColor = Color.Transparent;
            lbl_Seats.Location = new Point(477, 279);
            lbl_Seats.Name = "lbl_Seats";
            lbl_Seats.Size = new Size(62, 15);
            lbl_Seats.TabIndex = 35;
            lbl_Seats.Text = "Seat(s): XX";
            lbl_Seats.UseWaitCursor = true;
            // 
            // lbl_MovieTime
            // 
            lbl_MovieTime.AutoSize = true;
            lbl_MovieTime.BackColor = Color.Transparent;
            lbl_MovieTime.Location = new Point(477, 250);
            lbl_MovieTime.Name = "lbl_MovieTime";
            lbl_MovieTime.Size = new Size(53, 15);
            lbl_MovieTime.TabIndex = 34;
            lbl_MovieTime.Text = "Time: XX";
            // 
            // lbl_MovieName
            // 
            lbl_MovieName.AutoSize = true;
            lbl_MovieName.BackColor = Color.Transparent;
            lbl_MovieName.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lbl_MovieName.Location = new Point(463, 213);
            lbl_MovieName.Name = "lbl_MovieName";
            lbl_MovieName.Size = new Size(97, 20);
            lbl_MovieName.TabIndex = 33;
            lbl_MovieName.Text = "Movie Name";
            lbl_MovieName.TextAlign = ContentAlignment.TopCenter;
            // 
            // btn_BackToMovies
            // 
            btn_BackToMovies.BackColor = Color.Firebrick;
            btn_BackToMovies.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btn_BackToMovies.ForeColor = Color.White;
            btn_BackToMovies.Location = new Point(38, 33);
            btn_BackToMovies.Name = "btn_BackToMovies";
            btn_BackToMovies.Size = new Size(111, 36);
            btn_BackToMovies.TabIndex = 32;
            btn_BackToMovies.Text = "Go Back";
            btn_BackToMovies.UseVisualStyleBackColor = false;
            btn_BackToMovies.Click += btn_BackToMovies_Click_1;
            // 
            // btn_GoToChangePW
            // 
            btn_GoToChangePW.BackColor = Color.Firebrick;
            btn_GoToChangePW.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btn_GoToChangePW.ForeColor = Color.White;
            btn_GoToChangePW.Location = new Point(603, 33);
            btn_GoToChangePW.Name = "btn_GoToChangePW";
            btn_GoToChangePW.Size = new Size(166, 36);
            btn_GoToChangePW.TabIndex = 31;
            btn_GoToChangePW.Text = "Change Password";
            btn_GoToChangePW.UseVisualStyleBackColor = false;
            btn_GoToChangePW.Click += btn_GoToChangePW_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(32, 109);
            label2.Name = "label2";
            label2.Size = new Size(117, 21);
            label2.TabIndex = 30;
            label2.Text = "View Bookings";
            // 
            // pic_Ticket
            // 
            pic_Ticket.Location = new Point(414, 175);
            pic_Ticket.Name = "pic_Ticket";
            pic_Ticket.Size = new Size(308, 188);
            pic_Ticket.TabIndex = 29;
            pic_Ticket.TabStop = false;
            // 
            // listBox_Bookings
            // 
            listBox_Bookings.FormattingEnabled = true;
            listBox_Bookings.ItemHeight = 15;
            listBox_Bookings.Location = new Point(32, 133);
            listBox_Bookings.Name = "listBox_Bookings";
            listBox_Bookings.Size = new Size(358, 289);
            listBox_Bookings.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(44, 109);
            label1.Name = "label1";
            label1.Size = new Size(0, 21);
            label1.TabIndex = 27;
            // 
            // lbl_Title_SignUp
            // 
            lbl_Title_SignUp.AutoSize = true;
            lbl_Title_SignUp.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lbl_Title_SignUp.ForeColor = Color.Firebrick;
            lbl_Title_SignUp.Location = new Point(304, 29);
            lbl_Title_SignUp.Name = "lbl_Title_SignUp";
            lbl_Title_SignUp.Size = new Size(178, 40);
            lbl_Title_SignUp.TabIndex = 26;
            lbl_Title_SignUp.Text = "User Profile\r\n";
            // 
            // UserProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_Seats);
            Controls.Add(lbl_MovieTime);
            Controls.Add(lbl_MovieName);
            Controls.Add(btn_BackToMovies);
            Controls.Add(btn_GoToChangePW);
            Controls.Add(label2);
            Controls.Add(pic_Ticket);
            Controls.Add(listBox_Bookings);
            Controls.Add(label1);
            Controls.Add(lbl_Title_SignUp);
            Name = "UserProfile";
            Text = "UserProfile";
            ((System.ComponentModel.ISupportInitialize)pic_Ticket).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Seats;
        private Label lbl_MovieTime;
        private Label lbl_MovieName;
        private Button btn_BackToMovies;
        private Button btn_GoToChangePW;
        private Label label2;
        private PictureBox pic_Ticket;
        private ListBox listBox_Bookings;
        private Label label1;
        private Label lbl_Title_SignUp;
    }
}