﻿namespace RCinema_db.Account
{
    partial class Login
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
            lbl_Username = new Label();
            lbl_Password = new Label();
            lbl_Title_Login = new Label();
            btn_Login = new Button();
            txt_Username = new TextBox();
            txt_Password = new TextBox();
            label2 = new Label();
            lbl_SignUp = new Label();
            SuspendLayout();
            // 
            // lbl_Username
            // 
            lbl_Username.AutoSize = true;
            lbl_Username.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lbl_Username.ForeColor = SystemColors.ButtonFace;
            lbl_Username.Location = new Point(88, 109);
            lbl_Username.Name = "lbl_Username";
            lbl_Username.Size = new Size(83, 21);
            lbl_Username.TabIndex = 0;
            lbl_Username.Text = "Username";
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lbl_Password.ForeColor = SystemColors.ButtonFace;
            lbl_Password.Location = new Point(88, 200);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new Size(79, 21);
            lbl_Password.TabIndex = 1;
            lbl_Password.Text = "Password";
            // 
            // lbl_Title_Login
            // 
            lbl_Title_Login.AutoSize = true;
            lbl_Title_Login.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lbl_Title_Login.ForeColor = Color.Peru;
            lbl_Title_Login.Location = new Point(88, 23);
            lbl_Title_Login.Name = "lbl_Title_Login";
            lbl_Title_Login.Size = new Size(133, 40);
            lbl_Title_Login.TabIndex = 2;
            lbl_Title_Login.Text = "Cinemas";
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.Gold;
            btn_Login.Cursor = Cursors.Hand;
            btn_Login.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btn_Login.ForeColor = SystemColors.HotTrack;
            btn_Login.Location = new Point(552, 44);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(82, 330);
            btn_Login.TabIndex = 3;
            btn_Login.Text = "Log In";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // txt_Username
            // 
            txt_Username.Location = new Point(88, 149);
            txt_Username.Name = "txt_Username";
            txt_Username.Size = new Size(283, 23);
            txt_Username.TabIndex = 5;
            // 
            // txt_Password
            // 
            txt_Password.Location = new Point(88, 247);
            txt_Password.Name = "txt_Password";
            txt_Password.PasswordChar = '*';
            txt_Password.Size = new Size(281, 23);
            txt_Password.TabIndex = 6;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 0;
            // 
            // lbl_SignUp
            // 
            lbl_SignUp.AutoSize = true;
            lbl_SignUp.Cursor = Cursors.Hand;
            lbl_SignUp.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline);
            lbl_SignUp.ForeColor = Color.Firebrick;
            lbl_SignUp.Location = new Point(453, 201);
            lbl_SignUp.Name = "lbl_SignUp";
            lbl_SignUp.Size = new Size(69, 20);
            lbl_SignUp.TabIndex = 8;
            lbl_SignUp.Text = "SIGN UP";
            lbl_SignUp.Click += lbl_SignUp_Click;
            // 
            // Login
            // 
            AcceptButton = btn_Login;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_SignUp);
            Controls.Add(label2);
            Controls.Add(txt_Password);
            Controls.Add(txt_Username);
            Controls.Add(btn_Login);
            Controls.Add(lbl_Title_Login);
            Controls.Add(lbl_Password);
            Controls.Add(lbl_Username);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login | DOTNET Cinemas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Title_Login;
        private Label lbl_Username;
        private Label lbl_Password;
        private TextBox txt_Username;
        private TextBox txt_Password;
        private Button btn_Login;
        private Label label2;
        private Label lbl_SignUp;
    }
}