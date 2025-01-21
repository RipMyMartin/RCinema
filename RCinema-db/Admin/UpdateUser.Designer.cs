namespace RCinema_db.Admin
{
    partial class UpdateUser
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
            btn_DeleteUser = new Button();
            label7 = new Label();
            label6 = new Label();
            btn_CreateNewUser = new Button();
            textBox_lastName = new TextBox();
            textBox_firstName = new TextBox();
            textBox_Password = new TextBox();
            textBox_Username = new TextBox();
            textBox_UserId = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btn_UpdateData = new Button();
            btn_Cancel = new Button();
            userGrid = new DataGridView();
            lbl_Title_SignUp = new Label();
            ((System.ComponentModel.ISupportInitialize)userGrid).BeginInit();
            SuspendLayout();
            // 
            // btn_DeleteUser
            // 
            btn_DeleteUser.BackColor = Color.Firebrick;
            btn_DeleteUser.Cursor = Cursors.Hand;
            btn_DeleteUser.ForeColor = Color.White;
            btn_DeleteUser.Location = new Point(488, 161);
            btn_DeleteUser.Name = "btn_DeleteUser";
            btn_DeleteUser.Size = new Size(140, 23);
            btn_DeleteUser.TabIndex = 40;
            btn_DeleteUser.Text = "Delete Selected User";
            btn_DeleteUser.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_DeleteUser.UseVisualStyleBackColor = false;
            btn_DeleteUser.Click += btn_DeleteUser_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.CausesValidation = false;
            label7.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic);
            label7.Location = new Point(62, 99);
            label7.Name = "label7";
            label7.Size = new Size(145, 13);
            label7.TabIndex = 39;
            label7.Text = "Auto-generated for new users";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(593, 53);
            label6.Name = "label6";
            label6.Size = new Size(0, 15);
            label6.TabIndex = 38;
            // 
            // btn_CreateNewUser
            // 
            btn_CreateNewUser.BackColor = Color.Firebrick;
            btn_CreateNewUser.Cursor = Cursors.Hand;
            btn_CreateNewUser.ForeColor = Color.White;
            btn_CreateNewUser.Location = new Point(147, 161);
            btn_CreateNewUser.Name = "btn_CreateNewUser";
            btn_CreateNewUser.Size = new Size(114, 23);
            btn_CreateNewUser.TabIndex = 37;
            btn_CreateNewUser.Text = "Create New User";
            btn_CreateNewUser.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_CreateNewUser.UseVisualStyleBackColor = false;
            btn_CreateNewUser.Click += btn_CreateNewUser_Click;
            // 
            // textBox_lastName
            // 
            textBox_lastName.Location = new Point(543, 116);
            textBox_lastName.Name = "textBox_lastName";
            textBox_lastName.Size = new Size(165, 23);
            textBox_lastName.TabIndex = 36;
            // 
            // textBox_firstName
            // 
            textBox_firstName.Location = new Point(544, 73);
            textBox_firstName.Name = "textBox_firstName";
            textBox_firstName.Size = new Size(165, 23);
            textBox_firstName.TabIndex = 35;
            // 
            // textBox_Password
            // 
            textBox_Password.Location = new Point(293, 116);
            textBox_Password.Name = "textBox_Password";
            textBox_Password.Size = new Size(161, 23);
            textBox_Password.TabIndex = 34;
            // 
            // textBox_Username
            // 
            textBox_Username.Location = new Point(293, 73);
            textBox_Username.Name = "textBox_Username";
            textBox_Username.Size = new Size(170, 23);
            textBox_Username.TabIndex = 33;
            // 
            // textBox_UserId
            // 
            textBox_UserId.CausesValidation = false;
            textBox_UserId.Location = new Point(114, 73);
            textBox_UserId.Name = "textBox_UserId";
            textBox_UserId.ReadOnly = true;
            textBox_UserId.Size = new Size(93, 23);
            textBox_UserId.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(474, 119);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 31;
            label5.Text = "Last Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(474, 78);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 30;
            label4.Text = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(230, 116);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 29;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(227, 76);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 28;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.CausesValidation = false;
            label1.Location = new Point(68, 76);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 27;
            label1.Text = "UserId";
            // 
            // btn_UpdateData
            // 
            btn_UpdateData.BackColor = Color.Firebrick;
            btn_UpdateData.Cursor = Cursors.Hand;
            btn_UpdateData.ForeColor = Color.White;
            btn_UpdateData.Location = new Point(315, 161);
            btn_UpdateData.Name = "btn_UpdateData";
            btn_UpdateData.Size = new Size(129, 23);
            btn_UpdateData.TabIndex = 26;
            btn_UpdateData.Text = "Update User Data";
            btn_UpdateData.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_UpdateData.UseVisualStyleBackColor = false;
            btn_UpdateData.Click += btn_UpdateData_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.BackColor = Color.Firebrick;
            btn_Cancel.Cursor = Cursors.Hand;
            btn_Cancel.ForeColor = Color.White;
            btn_Cancel.Location = new Point(22, 27);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(148, 23);
            btn_Cancel.TabIndex = 25;
            btn_Cancel.Text = "Exit and Save Changes";
            btn_Cancel.TextImageRelation = TextImageRelation.TextAboveImage;
            btn_Cancel.UseVisualStyleBackColor = false;
            btn_Cancel.Click += btn_Cancel_Click_1;
            // 
            // userGrid
            // 
            userGrid.AllowUserToAddRows = false;
            userGrid.AllowUserToDeleteRows = false;
            userGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userGrid.Location = new Point(36, 205);
            userGrid.Name = "userGrid";
            userGrid.ReadOnly = true;
            userGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            userGrid.Size = new Size(742, 235);
            userGrid.TabIndex = 24;
            userGrid.CellClick += userGrid_CellClick_1;
            // 
            // lbl_Title_SignUp
            // 
            lbl_Title_SignUp.AutoSize = true;
            lbl_Title_SignUp.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lbl_Title_SignUp.ForeColor = Color.Firebrick;
            lbl_Title_SignUp.Location = new Point(293, 11);
            lbl_Title_SignUp.Name = "lbl_Title_SignUp";
            lbl_Title_SignUp.Size = new Size(212, 40);
            lbl_Title_SignUp.TabIndex = 23;
            lbl_Title_SignUp.Text = "Manage Users";
            // 
            // UpdateUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_DeleteUser);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btn_CreateNewUser);
            Controls.Add(textBox_lastName);
            Controls.Add(textBox_firstName);
            Controls.Add(textBox_Password);
            Controls.Add(textBox_Username);
            Controls.Add(textBox_UserId);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_UpdateData);
            Controls.Add(btn_Cancel);
            Controls.Add(userGrid);
            Controls.Add(lbl_Title_SignUp);
            Name = "UpdateUser";
            Text = "UpdateUser";
            ((System.ComponentModel.ISupportInitialize)userGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_DeleteUser;
        private Label label7;
        private Label label6;
        private Button btn_CreateNewUser;
        private TextBox textBox_lastName;
        private TextBox textBox_firstName;
        private TextBox textBox_Password;
        private TextBox textBox_Username;
        private TextBox textBox_UserId;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btn_UpdateData;
        private Button btn_Cancel;
        private DataGridView userGrid;
        private Label lbl_Title_SignUp;
    }
}