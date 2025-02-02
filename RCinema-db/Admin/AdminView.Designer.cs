namespace RCinema_db.Admin
{
    partial class AdminView
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
            btn_Log_Out = new Button();
            btn_EditMovie = new Button();
            btn_EditUser = new Button();
            lbl_Title_SignUp = new Label();
            SuspendLayout();
            // 
            // btn_Log_Out
            // 
            btn_Log_Out.Cursor = Cursors.Hand;
            btn_Log_Out.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btn_Log_Out.ForeColor = Color.Firebrick;
            btn_Log_Out.Location = new Point(360, 352);
            btn_Log_Out.Name = "btn_Log_Out";
            btn_Log_Out.Size = new Size(87, 33);
            btn_Log_Out.TabIndex = 24;
            btn_Log_Out.Text = "Log Out";
            btn_Log_Out.UseVisualStyleBackColor = true;
            btn_Log_Out.Click += btn_Log_Out_Click_1;
            // 
            // btn_EditMovie
            // 
            btn_EditMovie.BackColor = Color.Transparent;
            btn_EditMovie.Cursor = Cursors.Hand;
            btn_EditMovie.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            btn_EditMovie.ForeColor = Color.Black;
            btn_EditMovie.Location = new Point(291, 237);
            btn_EditMovie.Name = "btn_EditMovie";
            btn_EditMovie.Size = new Size(219, 40);
            btn_EditMovie.TabIndex = 23;
            btn_EditMovie.Text = "Manage Movies";
            btn_EditMovie.UseVisualStyleBackColor = false;
            btn_EditMovie.Click += btn_EditMovie_Click_1;
            // 
            // btn_EditUser
            // 
            btn_EditUser.BackColor = Color.Transparent;
            btn_EditUser.Cursor = Cursors.Hand;
            btn_EditUser.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            btn_EditUser.ForeColor = Color.Black;
            btn_EditUser.Location = new Point(291, 156);
            btn_EditUser.Name = "btn_EditUser";
            btn_EditUser.Size = new Size(219, 39);
            btn_EditUser.TabIndex = 22;
            btn_EditUser.Text = "Manage Users";
            btn_EditUser.UseVisualStyleBackColor = false;
            btn_EditUser.Click += btn_EditUser_Click;
            // 
            // lbl_Title_SignUp
            // 
            lbl_Title_SignUp.AutoSize = true;
            lbl_Title_SignUp.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lbl_Title_SignUp.ForeColor = Color.Orange;
            lbl_Title_SignUp.Location = new Point(311, 65);
            lbl_Title_SignUp.Name = "lbl_Title_SignUp";
            lbl_Title_SignUp.Size = new Size(189, 40);
            lbl_Title_SignUp.TabIndex = 21;
            lbl_Title_SignUp.Text = "Admin Tasks";
            // 
            // AdminView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Log_Out);
            Controls.Add(btn_EditMovie);
            Controls.Add(btn_EditUser);
            Controls.Add(lbl_Title_SignUp);
            Name = "AdminView";
            Text = "AdminView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Log_Out;
        private Button btn_EditMovie;
        private Button btn_EditUser;
        private Label lbl_Title_SignUp;
    }
}