using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RCinema_db
{
    public partial class AddRecordForm : Form
    {
        private string _tableName;
        private SqlConnection _connection;

        public AddRecordForm(string tableName, SqlConnection connection)
        {
            InitializeComponent();
            _tableName = tableName;
            _connection = connection;
            lblTableName.Text = $"Добавление записи в таблицу: {tableName}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO {_tableName} (Column1, Column2) VALUES (@Value1, @Value2)";
                    command.Parameters.AddWithValue("@Value1", txtValue1.Text);
                    command.Parameters.AddWithValue("@Value2", txtValue2.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно добавлена!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления записи: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}