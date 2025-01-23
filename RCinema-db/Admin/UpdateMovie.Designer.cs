namespace RCinema_db.Admin
{
    partial class UpdateMovie
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
            textBox_Poster = new TextBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            dateTimePicker_ReleaseDate = new DateTimePicker();
            textBox_Minutes = new TextBox();
            btn_DeleteMovie = new Button();
            label7 = new Label();
            label6 = new Label();
            btn_CreateMovie = new Button();
            textBox_Description = new TextBox();
            textBox_Genre = new TextBox();
            textBox_Hours = new TextBox();
            textBox_Title = new TextBox();
            textBox_MovieID = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btn_UpdateMovie = new Button();
            button1 = new Button();
            movieGrid = new DataGridView();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)movieGrid).BeginInit();
            SuspendLayout();
            // 
            // textBox_Poster
            // 
            textBox_Poster.Location = new Point(551, 116);
            textBox_Poster.Name = "textBox_Poster";
            textBox_Poster.Size = new Size(165, 23);
            textBox_Poster.TabIndex = 72;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(509, 120);
            label12.Name = "label12";
            label12.Size = new Size(40, 15);
            label12.TabIndex = 71;
            label12.Text = "Poster";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.CausesValidation = false;
            label11.Location = new Point(123, 147);
            label11.Name = "label11";
            label11.Size = new Size(85, 15);
            label11.TabIndex = 70;
            label11.Text = "Movie Length-";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(65, 120);
            label10.Name = "label10";
            label10.Size = new Size(67, 15);
            label10.TabIndex = 69;
            label10.Text = "Description";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(384, 171);
            label9.Name = "label9";
            label9.Size = new Size(73, 15);
            label9.TabIndex = 68;
            label9.Text = "Release Date";
            // 
            // dateTimePicker_ReleaseDate
            // 
            dateTimePicker_ReleaseDate.Location = new Point(459, 167);
            dateTimePicker_ReleaseDate.MaxDate = new DateTime(2030, 12, 31, 0, 0, 0, 0);
            dateTimePicker_ReleaseDate.Name = "dateTimePicker_ReleaseDate";
            dateTimePicker_ReleaseDate.Size = new Size(200, 23);
            dateTimePicker_ReleaseDate.TabIndex = 67;
            dateTimePicker_ReleaseDate.Value = new DateTime(2023, 10, 29, 0, 0, 0, 0);
            // 
            // textBox_Minutes
            // 
            textBox_Minutes.Location = new Point(286, 168);
            textBox_Minutes.Name = "textBox_Minutes";
            textBox_Minutes.Size = new Size(47, 23);
            textBox_Minutes.TabIndex = 66;
            // 
            // btn_DeleteMovie
            // 
            btn_DeleteMovie.BackColor = Color.Firebrick;
            btn_DeleteMovie.Cursor = Cursors.Hand;
            btn_DeleteMovie.ForeColor = Color.White;
            btn_DeleteMovie.Location = new Point(471, 205);
            btn_DeleteMovie.Name = "btn_DeleteMovie";
            btn_DeleteMovie.Size = new Size(140, 23);
            btn_DeleteMovie.TabIndex = 65;
            btn_DeleteMovie.Text = "Delete Selected Movie";
            btn_DeleteMovie.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_DeleteMovie.UseVisualStyleBackColor = false;
            btn_DeleteMovie.Click += btn_DeleteMovie_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.CausesValidation = false;
            label7.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic);
            label7.Location = new Point(109, 92);
            label7.Name = "label7";
            label7.Size = new Size(167, 13);
            label7.TabIndex = 64;
            label7.Text = "ID auto-generated for new movies";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(354, 128);
            label6.Name = "label6";
            label6.Size = new Size(0, 15);
            label6.TabIndex = 63;
            // 
            // btn_CreateMovie
            // 
            btn_CreateMovie.BackColor = Color.Firebrick;
            btn_CreateMovie.Cursor = Cursors.Hand;
            btn_CreateMovie.ForeColor = Color.White;
            btn_CreateMovie.Location = new Point(160, 205);
            btn_CreateMovie.Name = "btn_CreateMovie";
            btn_CreateMovie.Size = new Size(114, 23);
            btn_CreateMovie.TabIndex = 62;
            btn_CreateMovie.Text = "Create New Movie";
            btn_CreateMovie.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_CreateMovie.UseVisualStyleBackColor = false;
            btn_CreateMovie.Click += btn_CreateMovie_Click;
            // 
            // textBox_Description
            // 
            textBox_Description.Location = new Point(135, 116);
            textBox_Description.Name = "textBox_Description";
            textBox_Description.Size = new Size(369, 23);
            textBox_Description.TabIndex = 61;
            // 
            // textBox_Genre
            // 
            textBox_Genre.Location = new Point(551, 68);
            textBox_Genre.Name = "textBox_Genre";
            textBox_Genre.Size = new Size(165, 23);
            textBox_Genre.TabIndex = 60;
            // 
            // textBox_Hours
            // 
            textBox_Hours.Location = new Point(168, 167);
            textBox_Hours.Name = "textBox_Hours";
            textBox_Hours.Size = new Size(47, 23);
            textBox_Hours.TabIndex = 59;
            // 
            // textBox_Title
            // 
            textBox_Title.Location = new Point(315, 68);
            textBox_Title.Name = "textBox_Title";
            textBox_Title.Size = new Size(189, 23);
            textBox_Title.TabIndex = 58;
            // 
            // textBox_MovieID
            // 
            textBox_MovieID.CausesValidation = false;
            textBox_MovieID.Location = new Point(181, 68);
            textBox_MovieID.Name = "textBox_MovieID";
            textBox_MovieID.ReadOnly = true;
            textBox_MovieID.Size = new Size(93, 23);
            textBox_MovieID.TabIndex = 57;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(233, 172);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 56;
            label5.Text = "Minutes";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(510, 73);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 55;
            label4.Text = "Genre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(126, 172);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 54;
            label3.Text = "Hours";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(280, 73);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 53;
            label2.Text = "Title";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.CausesValidation = false;
            label1.Location = new Point(109, 71);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 52;
            label1.Text = "Movie ID";
            // 
            // btn_UpdateMovie
            // 
            btn_UpdateMovie.BackColor = Color.Firebrick;
            btn_UpdateMovie.Cursor = Cursors.Hand;
            btn_UpdateMovie.ForeColor = Color.White;
            btn_UpdateMovie.Location = new Point(311, 205);
            btn_UpdateMovie.Name = "btn_UpdateMovie";
            btn_UpdateMovie.Size = new Size(129, 23);
            btn_UpdateMovie.TabIndex = 51;
            btn_UpdateMovie.Text = "Update Movie Data";
            btn_UpdateMovie.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_UpdateMovie.UseVisualStyleBackColor = false;
            btn_UpdateMovie.Click += btn_UpdateMovie_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.Firebrick;
            button1.Cursor = Cursors.Hand;
            button1.ForeColor = Color.White;
            button1.Location = new Point(29, 27);
            button1.Name = "button1";
            button1.Size = new Size(136, 23);
            button1.TabIndex = 50;
            button1.Text = "Exit and Save Changes";
            button1.TextImageRelation = TextImageRelation.TextAboveImage;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // movieGrid
            // 
            movieGrid.AllowUserToAddRows = false;
            movieGrid.AllowUserToDeleteRows = false;
            movieGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            movieGrid.Location = new Point(29, 240);
            movieGrid.Name = "movieGrid";
            movieGrid.ReadOnly = true;
            movieGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            movieGrid.Size = new Size(742, 200);
            movieGrid.TabIndex = 49;
            movieGrid.CellClick += movieGrid_CellClick_1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            label8.ForeColor = Color.Firebrick;
            label8.Location = new Point(286, 11);
            label8.Name = "label8";
            label8.Size = new Size(236, 40);
            label8.TabIndex = 48;
            label8.Text = "Manage Movies";
            // 
            // UpdateMovie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox_Poster);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(dateTimePicker_ReleaseDate);
            Controls.Add(textBox_Minutes);
            Controls.Add(btn_DeleteMovie);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btn_CreateMovie);
            Controls.Add(textBox_Description);
            Controls.Add(textBox_Genre);
            Controls.Add(textBox_Hours);
            Controls.Add(textBox_Title);
            Controls.Add(textBox_MovieID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_UpdateMovie);
            Controls.Add(button1);
            Controls.Add(movieGrid);
            Controls.Add(label8);
            Name = "UpdateMovie";
            Text = "UpdateMovies";
            ((System.ComponentModel.ISupportInitialize)movieGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_Poster;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private DateTimePicker dateTimePicker_ReleaseDate;
        private TextBox textBox_Minutes;
        private Button btn_DeleteMovie;
        private Label label7;
        private Label label6;
        private Button btn_CreateMovie;
        private TextBox textBox_Description;
        private TextBox textBox_Genre;
        private TextBox textBox_Hours;
        private TextBox textBox_Title;
        private TextBox textBox_MovieID;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btn_UpdateMovie;
        private Button button1;
        private DataGridView movieGrid;
        private Label label8;
    }
}