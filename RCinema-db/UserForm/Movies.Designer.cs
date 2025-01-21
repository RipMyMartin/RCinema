namespace RCinema_db.User
{
    partial class Movies
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
            Exit = new Button();
            btn_UserProfile = new Button();
            btn_Log_Out = new Button();
            lbl_Sessions = new Label();
            lbl_Movie_Release_Date = new Label();
            txt_Movie_Description = new TextBox();
            lbl_Movie_Duration_Genre = new Label();
            lbl_Movie_Title = new Label();
            picbox_Movie_Poster = new PictureBox();
            lbl_Title_Login = new Label();
            listbox_Movies = new ListBox();
            ((System.ComponentModel.ISupportInitialize)picbox_Movie_Poster).BeginInit();
            SuspendLayout();
            // 
            // Exit
            // 
            Exit.Location = new Point(612, 92);
            Exit.Name = "Exit";
            Exit.Size = new Size(170, 23);
            Exit.TabIndex = 36;
            Exit.Text = "Exit and Save Changes";
            Exit.UseVisualStyleBackColor = true;
            Exit.Visible = false;
            Exit.Click += Exit_Click_1;
            // 
            // btn_UserProfile
            // 
            btn_UserProfile.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btn_UserProfile.ForeColor = Color.Firebrick;
            btn_UserProfile.Location = new Point(602, 43);
            btn_UserProfile.Name = "btn_UserProfile";
            btn_UserProfile.Size = new Size(87, 33);
            btn_UserProfile.TabIndex = 35;
            btn_UserProfile.Text = "Profile";
            btn_UserProfile.UseVisualStyleBackColor = true;
            btn_UserProfile.Click += btn_UserProfile_Click_2;
            // 
            // btn_Log_Out
            // 
            btn_Log_Out.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btn_Log_Out.ForeColor = Color.Firebrick;
            btn_Log_Out.Location = new Point(695, 43);
            btn_Log_Out.Name = "btn_Log_Out";
            btn_Log_Out.Size = new Size(87, 33);
            btn_Log_Out.TabIndex = 34;
            btn_Log_Out.Text = "Log Out";
            btn_Log_Out.UseVisualStyleBackColor = true;
            btn_Log_Out.Click += btn_Log_Out_Click_1;
            // 
            // lbl_Sessions
            // 
            lbl_Sessions.AutoSize = true;
            lbl_Sessions.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lbl_Sessions.Location = new Point(275, 335);
            lbl_Sessions.Name = "lbl_Sessions";
            lbl_Sessions.Size = new Size(83, 25);
            lbl_Sessions.TabIndex = 28;
            lbl_Sessions.Text = "Sessions";
            // 
            // lbl_Movie_Release_Date
            // 
            lbl_Movie_Release_Date.AutoSize = true;
            lbl_Movie_Release_Date.Font = new Font("Segoe UI", 9.75F);
            lbl_Movie_Release_Date.Location = new Point(452, 142);
            lbl_Movie_Release_Date.Name = "lbl_Movie_Release_Date";
            lbl_Movie_Release_Date.Size = new Size(191, 17);
            lbl_Movie_Release_Date.TabIndex = 27;
            lbl_Movie_Release_Date.Text = "Released on (Day, Month, Year)";
            // 
            // txt_Movie_Description
            // 
            txt_Movie_Description.BackColor = SystemColors.Control;
            txt_Movie_Description.BorderStyle = BorderStyle.None;
            txt_Movie_Description.Font = new Font("Segoe UI", 9.75F);
            txt_Movie_Description.Location = new Point(452, 207);
            txt_Movie_Description.Multiline = true;
            txt_Movie_Description.Name = "txt_Movie_Description";
            txt_Movie_Description.Size = new Size(312, 104);
            txt_Movie_Description.TabIndex = 26;
            txt_Movie_Description.Text = "Description";
            // 
            // lbl_Movie_Duration_Genre
            // 
            lbl_Movie_Duration_Genre.AutoSize = true;
            lbl_Movie_Duration_Genre.Font = new Font("Segoe UI", 9.75F);
            lbl_Movie_Duration_Genre.Location = new Point(452, 175);
            lbl_Movie_Duration_Genre.Name = "lbl_Movie_Duration_Genre";
            lbl_Movie_Duration_Genre.Size = new Size(100, 17);
            lbl_Movie_Duration_Genre.TabIndex = 25;
            lbl_Movie_Duration_Genre.Text = "Duration, Genre";
            // 
            // lbl_Movie_Title
            // 
            lbl_Movie_Title.AutoSize = true;
            lbl_Movie_Title.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lbl_Movie_Title.Location = new Point(449, 103);
            lbl_Movie_Title.Name = "lbl_Movie_Title";
            lbl_Movie_Title.Size = new Size(49, 25);
            lbl_Movie_Title.TabIndex = 24;
            lbl_Movie_Title.Text = "Title";
            // 
            // picbox_Movie_Poster
            // 
            picbox_Movie_Poster.Location = new Point(275, 111);
            picbox_Movie_Poster.MaximumSize = new Size(150, 200);
            picbox_Movie_Poster.Name = "picbox_Movie_Poster";
            picbox_Movie_Poster.Size = new Size(150, 200);
            picbox_Movie_Poster.SizeMode = PictureBoxSizeMode.AutoSize;
            picbox_Movie_Poster.TabIndex = 23;
            picbox_Movie_Poster.TabStop = false;
            // 
            // lbl_Title_Login
            // 
            lbl_Title_Login.AutoSize = true;
            lbl_Title_Login.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lbl_Title_Login.ForeColor = Color.Firebrick;
            lbl_Title_Login.Location = new Point(19, 36);
            lbl_Title_Login.Name = "lbl_Title_Login";
            lbl_Title_Login.Size = new Size(207, 40);
            lbl_Title_Login.TabIndex = 22;
            lbl_Title_Login.Text = "Now Showing";
            // 
            // listbox_Movies
            // 
            listbox_Movies.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            listbox_Movies.FormattingEnabled = true;
            listbox_Movies.ItemHeight = 20;
            listbox_Movies.Location = new Point(26, 111);
            listbox_Movies.Name = "listbox_Movies";
            listbox_Movies.Size = new Size(207, 304);
            listbox_Movies.TabIndex = 21;
            // 
            // Movies
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Exit);
            Controls.Add(btn_UserProfile);
            Controls.Add(btn_Log_Out);
            Controls.Add(lbl_Sessions);
            Controls.Add(lbl_Movie_Release_Date);
            Controls.Add(txt_Movie_Description);
            Controls.Add(lbl_Movie_Duration_Genre);
            Controls.Add(lbl_Movie_Title);
            Controls.Add(picbox_Movie_Poster);
            Controls.Add(lbl_Title_Login);
            Controls.Add(listbox_Movies);
            Name = "Movies";
            Text = "Movies";
            ((System.ComponentModel.ISupportInitialize)picbox_Movie_Poster).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Exit;
        private Button btn_UserProfile;
        private Button btn_Log_Out;
        private Label lbl_Sessions;
        private Label lbl_Movie_Release_Date;
        private TextBox txt_Movie_Description;
        private Label lbl_Movie_Duration_Genre;
        private Label lbl_Movie_Title;
        private PictureBox picbox_Movie_Poster;
        private Label lbl_Title_Login;
        private ListBox listbox_Movies;
    }
}