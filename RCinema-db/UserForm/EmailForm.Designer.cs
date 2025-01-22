namespace RCinema_db.UserForm
{
    partial class EmailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lbl_EmailPrompt;
        private TextBox txt_Email;
        private Button btn_SendEmail;
        private Label lbl_Info;

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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "EmailForm";

            this.lbl_EmailPrompt = new Label();
            this.txt_Email = new TextBox();
            this.btn_SendEmail = new Button();
            this.lbl_Info = new Label();

            this.SuspendLayout();

            // 
            // lbl_EmailPrompt
            // 
            this.lbl_EmailPrompt.AutoSize = true;
            this.lbl_EmailPrompt.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lbl_EmailPrompt.Location = new Point(20, 20);
            this.lbl_EmailPrompt.Name = "lbl_EmailPrompt";
            this.lbl_EmailPrompt.Size = new Size(210, 19);
            this.lbl_EmailPrompt.Text = "Enter your email to receive ticket:";

            // 
            // txt_Email
            // 
            this.txt_Email.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txt_Email.Location = new Point(20, 50);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new Size(300, 25);

            // 
            // btn_SendEmail
            // 
            this.btn_SendEmail.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.btn_SendEmail.Location = new Point(120, 90);
            this.btn_SendEmail.Name = "btn_SendEmail";
            this.btn_SendEmail.Size = new Size(100, 30);
            this.btn_SendEmail.Text = "Send Email";
            this.btn_SendEmail.UseVisualStyleBackColor = true;
            this.btn_SendEmail.Click += new EventHandler(this.btn_SendEmail_Click);

            // 
            // lbl_Info
            // 
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            this.lbl_Info.ForeColor = Color.DarkGreen;
            this.lbl_Info.Location = new Point(20, 130);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new Size(0, 15); // Initially empty
            this.lbl_Info.Text = "";

            // 
            // EmailForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(350, 200);
            this.Controls.Add(this.lbl_EmailPrompt);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.btn_SendEmail);
            this.Controls.Add(this.lbl_Info);
            this.Name = "EmailForm";
            this.Text = "Enter Your Email";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}