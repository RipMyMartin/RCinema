namespace RCinema_db.Account
{
    partial class ChangePassword
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
            btn_BackToMovies = new Button();
            btn_ChangePW = new Button();
            lbl_PWMatchWarning = new Label();
            lbl_PWLengthWarning = new Label();
            label5 = new Label();
            textBox_confirmPW = new TextBox();
            textBox_newPW = new TextBox();
            label3 = new Label();
            label1 = new Label();
            lbl_Title_SignUp = new Label();
            SuspendLayout();
            // 
            // btn_BackToMovies
            // 
            btn_BackToMovies.BackColor = Color.Firebrick;
            btn_BackToMovies.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btn_BackToMovies.ForeColor = Color.White;
            btn_BackToMovies.Location = new Point(69, 33);
            btn_BackToMovies.Name = "btn_BackToMovies";
            btn_BackToMovies.Size = new Size(106, 40);
            btn_BackToMovies.TabIndex = 39;
            btn_BackToMovies.Text = "Go Back";
            btn_BackToMovies.UseVisualStyleBackColor = false;
            btn_BackToMovies.Click += btn_BackToMovies_Click;
            // 
            // btn_ChangePW
            // 
            btn_ChangePW.BackColor = Color.Firebrick;
            btn_ChangePW.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btn_ChangePW.ForeColor = Color.White;
            btn_ChangePW.Location = new Point(356, 366);
            btn_ChangePW.Name = "btn_ChangePW";
            btn_ChangePW.Size = new Size(93, 34);
            btn_ChangePW.TabIndex = 38;
            btn_ChangePW.Text = "Submit";
            btn_ChangePW.UseVisualStyleBackColor = false;
            btn_ChangePW.Click += btn_ChangePW_Click;
            // 
            // lbl_PWMatchWarning
            // 
            lbl_PWMatchWarning.AutoSize = true;
            lbl_PWMatchWarning.ForeColor = Color.Firebrick;
            lbl_PWMatchWarning.Location = new Point(423, 295);
            lbl_PWMatchWarning.Name = "lbl_PWMatchWarning";
            lbl_PWMatchWarning.Size = new Size(137, 15);
            lbl_PWMatchWarning.TabIndex = 37;
            lbl_PWMatchWarning.Text = "Passwords do not match";
            // 
            // lbl_PWLengthWarning
            // 
            lbl_PWLengthWarning.AutoSize = true;
            lbl_PWLengthWarning.ForeColor = Color.Firebrick;
            lbl_PWLengthWarning.Location = new Point(334, 212);
            lbl_PWLengthWarning.Name = "lbl_PWLengthWarning";
            lbl_PWLengthWarning.Size = new Size(226, 15);
            lbl_PWLengthWarning.TabIndex = 36;
            lbl_PWLengthWarning.Text = "Your new password be 4+ characters long";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(330, 73);
            label5.Name = "label5";
            label5.Size = new Size(157, 21);
            label5.TabIndex = 35;
            label5.Text = "At least 4 characters";
            // 
            // textBox_confirmPW
            // 
            textBox_confirmPW.Location = new Point(262, 269);
            textBox_confirmPW.Name = "textBox_confirmPW";
            textBox_confirmPW.Size = new Size(298, 23);
            textBox_confirmPW.TabIndex = 34;
            // 
            // textBox_newPW
            // 
            textBox_newPW.Location = new Point(262, 186);
            textBox_newPW.Name = "textBox_newPW";
            textBox_newPW.Size = new Size(298, 23);
            textBox_newPW.TabIndex = 33;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(262, 245);
            label3.Name = "label3";
            label3.Size = new Size(142, 21);
            label3.TabIndex = 32;
            label3.Text = "Confirm Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(262, 162);
            label1.Name = "label1";
            label1.Size = new Size(116, 21);
            label1.TabIndex = 31;
            label1.Text = "New Password";
            // 
            // lbl_Title_SignUp
            // 
            lbl_Title_SignUp.AutoSize = true;
            lbl_Title_SignUp.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lbl_Title_SignUp.ForeColor = Color.Firebrick;
            lbl_Title_SignUp.Location = new Point(281, 33);
            lbl_Title_SignUp.Name = "lbl_Title_SignUp";
            lbl_Title_SignUp.Size = new Size(258, 40);
            lbl_Title_SignUp.TabIndex = 30;
            lbl_Title_SignUp.Text = "Change Password";
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_BackToMovies);
            Controls.Add(btn_ChangePW);
            Controls.Add(lbl_PWMatchWarning);
            Controls.Add(lbl_PWLengthWarning);
            Controls.Add(label5);
            Controls.Add(textBox_confirmPW);
            Controls.Add(textBox_newPW);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(lbl_Title_SignUp);
            Name = "ChangePassword";
            Text = "ChangePassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_BackToMovies;
        private Button btn_ChangePW;
        private Label lbl_PWMatchWarning;
        private Label lbl_PWLengthWarning;
        private Label label5;
        private TextBox textBox_confirmPW;
        private TextBox textBox_newPW;
        private Label label3;
        private Label label1;
        private Label lbl_Title_SignUp;
    }
}