
namespace RCinema_db.UserForm
{
    partial class SeatSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBox_Sessions;
        private Panel panel_Seats;
        private Button btn_ConfirmPurchase;
        private Label lbl_SelectedSeats;
        private Label lbl_TotalAmount;
        private Label lbl_Session;
        private Label lbl_AvailableSeats;
        private Label lbl_SessionInfo;


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
            comboBox_Sessions = new ComboBox();
            lbl_Session = new Label();
            panel_Seats = new Panel();
            lbl_SelectedSeats = new Label();
            lbl_TotalAmount = new Label();
            btn_ConfirmPurchase = new Button();
            lbl_SessionInfo = new Label();
            lbl_AvailableSeats = new Label();
            btn_Buy_Ticket = new Button();
            SuspendLayout();
            // 
            // comboBox_Sessions
            // 
            comboBox_Sessions.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Sessions.Location = new Point(50, 50);
            comboBox_Sessions.Name = "comboBox_Sessions";
            comboBox_Sessions.Size = new Size(200, 23);
            comboBox_Sessions.TabIndex = 0;
            comboBox_Sessions.SelectedIndexChanged += ComboBox_Sessions_SelectedIndexChanged;
            // 
            // lbl_Session
            // 
            lbl_Session.Location = new Point(50, 20);
            lbl_Session.Name = "lbl_Session";
            lbl_Session.Size = new Size(200, 20);
            lbl_Session.TabIndex = 1;
            lbl_Session.Text = "Select a session:";
            // 
            // panel_Seats
            // 
            panel_Seats.AutoScroll = true;
            panel_Seats.Location = new Point(50, 100);
            panel_Seats.Name = "panel_Seats";
            panel_Seats.Size = new Size(700, 300);
            panel_Seats.TabIndex = 2;
            // 
            // lbl_SelectedSeats
            // 
            lbl_SelectedSeats.Location = new Point(50, 420);
            lbl_SelectedSeats.Name = "lbl_SelectedSeats";
            lbl_SelectedSeats.Size = new Size(400, 20);
            lbl_SelectedSeats.TabIndex = 3;
            lbl_SelectedSeats.Text = "Selected Seats: ";
            // 
            // lbl_TotalAmount
            // 
            lbl_TotalAmount.Location = new Point(500, 420);
            lbl_TotalAmount.Name = "lbl_TotalAmount";
            lbl_TotalAmount.Size = new Size(200, 20);
            lbl_TotalAmount.TabIndex = 4;
            lbl_TotalAmount.Text = "Total: $0.00";
            // 
            // btn_ConfirmPurchase
            // 
            btn_ConfirmPurchase.Location = new Point(600, 460);
            btn_ConfirmPurchase.Name = "btn_ConfirmPurchase";
            btn_ConfirmPurchase.Size = new Size(150, 40);
            btn_ConfirmPurchase.TabIndex = 5;
            btn_ConfirmPurchase.Text = "Confirm Purchase";
            btn_ConfirmPurchase.Click += Btn_ConfirmPurchase_Click;
            // 
            // lbl_SessionInfo
            // 
            lbl_SessionInfo.Location = new Point(300, 38);
            lbl_SessionInfo.Name = "lbl_SessionInfo";
            lbl_SessionInfo.Size = new Size(400, 20);
            lbl_SessionInfo.TabIndex = 6;
            lbl_SessionInfo.Text = "Selected Session: ";
            // 
            // lbl_AvailableSeats
            // 
            lbl_AvailableSeats.Location = new Point(300, 58);
            lbl_AvailableSeats.Name = "lbl_AvailableSeats";
            lbl_AvailableSeats.Size = new Size(400, 20);
            lbl_AvailableSeats.TabIndex = 7;
            lbl_AvailableSeats.Text = "Available Seats: ";
            // 
            // btn_Buy_Ticket
            // 
            btn_Buy_Ticket.BackColor = Color.Firebrick;
            btn_Buy_Ticket.Cursor = Cursors.Hand;
            btn_Buy_Ticket.ForeColor = Color.White;
            btn_Buy_Ticket.Location = new Point(617, 415);
            btn_Buy_Ticket.Name = "btn_Buy_Ticket";
            btn_Buy_Ticket.Size = new Size(133, 23);
            btn_Buy_Ticket.TabIndex = 20;
            btn_Buy_Ticket.Text = "BUY";
            btn_Buy_Ticket.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_Buy_Ticket.UseVisualStyleBackColor = false;
            btn_Buy_Ticket.Click += btn_Buy_Ticket_Click;
            // 
            // SeatSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Buy_Ticket);
            Controls.Add(comboBox_Sessions);
            Controls.Add(lbl_Session);
            Controls.Add(panel_Seats);
            Controls.Add(lbl_SelectedSeats);
            Controls.Add(lbl_TotalAmount);
            Controls.Add(btn_ConfirmPurchase);
            Controls.Add(lbl_SessionInfo);
            Controls.Add(lbl_AvailableSeats);
            Name = "SeatSelectionForm";
            Text = "SeatSelectionForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Buy_Ticket;
    }
}