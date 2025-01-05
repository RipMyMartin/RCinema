namespace RCinema_db
{
    partial class AddRecordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblTableName;
        private TextBox txtValue1;
        private TextBox txtValue2;
        private Button btnSave;
        private Button btnCancel;

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
            this.Text = "AddRecordForm";

            this.lblTableName = new Label();
            this.txtValue1 = new TextBox();
            this.txtValue2 = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            // Label
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(12, 9);
            this.lblTableName.Size = new System.Drawing.Size(200, 17);
            this.lblTableName.Text = "Добавление записи";

            // TextBox1
            this.txtValue1.Location = new System.Drawing.Point(15, 40);
            this.txtValue1.Size = new System.Drawing.Size(200, 22);

            // TextBox2
            this.txtValue2.Location = new System.Drawing.Point(15, 80);
            this.txtValue2.Size = new System.Drawing.Size(200, 22);

            // Save Button
            this.btnSave.Location = new System.Drawing.Point(15, 120);
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // Cancel Button
            this.btnCancel.Location = new System.Drawing.Point(140, 120);
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // Add controls to form
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.txtValue1);
            this.Controls.Add(this.txtValue2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
        }

        #endregion
    }
}