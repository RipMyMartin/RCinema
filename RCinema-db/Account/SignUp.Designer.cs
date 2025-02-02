namespace RCinema_db.Account
{
    partial class SignUp
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
            txt_Password = new TextBox();
            txt_Email = new TextBox();
            txt_LastName = new TextBox();
            txt_FirstName = new TextBox();
            lbl_LogIn = new Label();
            lbl_FirstName = new Label();
            btn_SignUp = new Button();
            lbl_LastName = new Label();
            lbl_Password = new Label();
            lbl_Username = new Label();
            lbl_Title_SignUp = new Label();
            SuspendLayout();
            // 
            // txt_Password
            // 
            txt_Password.Location = new Point(294, 276);
            txt_Password.Name = "txt_Password";
            txt_Password.PasswordChar = '*';
            txt_Password.Size = new Size(260, 23);
            txt_Password.TabIndex = 33;
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(294, 123);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(260, 23);
            txt_Email.TabIndex = 32;
            // 
            // txt_LastName
            // 
            txt_LastName.Location = new Point(294, 222);
            txt_LastName.Name = "txt_LastName";
            txt_LastName.Size = new Size(260, 23);
            txt_LastName.TabIndex = 31;
            // 
            // txt_FirstName
            // 
            txt_FirstName.Location = new Point(294, 173);
            txt_FirstName.Name = "txt_FirstName";
            txt_FirstName.Size = new Size(260, 23);
            txt_FirstName.TabIndex = 30;
            // 
            // lbl_LogIn
            // 
            lbl_LogIn.AutoSize = true;
            lbl_LogIn.Cursor = Cursors.Hand;
            lbl_LogIn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline);
            lbl_LogIn.ForeColor = Color.Yellow;
            lbl_LogIn.Location = new Point(396, 317);
            lbl_LogIn.Name = "lbl_LogIn";
            lbl_LogIn.Size = new Size(60, 20);
            lbl_LogIn.TabIndex = 29;
            lbl_LogIn.Text = "LOG IN";
            lbl_LogIn.Click += lbl_LogIn_Click_1;
            // 
            // lbl_FirstName
            // 
            lbl_FirstName.AutoSize = true;
            lbl_FirstName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lbl_FirstName.ForeColor = SystemColors.Control;
            lbl_FirstName.Location = new Point(378, 149);
            lbl_FirstName.Name = "lbl_FirstName";
            lbl_FirstName.Size = new Size(85, 21);
            lbl_FirstName.TabIndex = 27;
            lbl_FirstName.Text = "First name";
            // 
            // btn_SignUp
            // 
            btn_SignUp.BackColor = Color.DarkOrange;
            btn_SignUp.Cursor = Cursors.Hand;
            btn_SignUp.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            btn_SignUp.ForeColor = SystemColors.Window;
            btn_SignUp.Location = new Point(299, 354);
            btn_SignUp.Name = "btn_SignUp";
            btn_SignUp.Size = new Size(255, 43);
            btn_SignUp.TabIndex = 26;
            btn_SignUp.Text = "Sign Up";
            btn_SignUp.UseVisualStyleBackColor = false;
            btn_SignUp.Click += btn_SignUp_Click_1;
            // 
            // lbl_LastName
            // 
            lbl_LastName.AutoSize = true;
            lbl_LastName.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lbl_LastName.ForeColor = SystemColors.Control;
            lbl_LastName.Location = new Point(386, 199);
            lbl_LastName.Name = "lbl_LastName";
            lbl_LastName.Size = new Size(77, 20);
            lbl_LastName.TabIndex = 25;
            lbl_LastName.Text = "Last name";
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lbl_Password.ForeColor = SystemColors.Control;
            lbl_Password.Location = new Point(386, 253);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new Size(73, 20);
            lbl_Password.TabIndex = 23;
            lbl_Password.Text = "Password";
            // 
            // lbl_Username
            // 
            lbl_Username.AutoSize = true;
            lbl_Username.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lbl_Username.ForeColor = SystemColors.Control;
            lbl_Username.Location = new Point(386, 100);
            lbl_Username.Name = "lbl_Username";
            lbl_Username.Size = new Size(78, 20);
            lbl_Username.TabIndex = 22;
            lbl_Username.Text = "Username";
            // 
            // lbl_Title_SignUp
            // 
            lbl_Title_SignUp.AutoSize = true;
            lbl_Title_SignUp.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lbl_Title_SignUp.ForeColor = Color.Olive;
            lbl_Title_SignUp.Location = new Point(299, 9);
            lbl_Title_SignUp.Name = "lbl_Title_SignUp";
            lbl_Title_SignUp.Size = new Size(255, 40);
            lbl_Title_SignUp.TabIndex = 20;
            lbl_Title_SignUp.Text = "DOTNET Cinemas";
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(txt_Password);
            Controls.Add(txt_Email);
            Controls.Add(txt_LastName);
            Controls.Add(txt_FirstName);
            Controls.Add(lbl_LogIn);
            Controls.Add(lbl_FirstName);
            Controls.Add(btn_SignUp);
            Controls.Add(lbl_LastName);
            Controls.Add(lbl_Password);
            Controls.Add(lbl_Username);
            Controls.Add(lbl_Title_SignUp);
            Name = "SignUp";
            Text = "SignUp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Password;
        private TextBox txt_Email;
        private TextBox txt_LastName;
        private TextBox txt_FirstName;
        private Label lbl_LogIn;
        private Label lbl_FirstName;
        private Button btn_SignUp;
        private Label lbl_LastName;
        private Label lbl_Password;
        private Label lbl_Username;
        private Label lbl_Title_SignUp;
    }
}