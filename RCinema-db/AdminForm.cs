using RCinema_db.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCinema_db
{
    
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    DataTable schema = connection.GetSchema("Tables");

                    // Логирование для отладки
                    foreach (DataRow row in schema.Rows)
                    {
                        string tableName = row["TABLE_NAME"].ToString();
                        MessageBox.Show($"Таблица: {tableName}"); 
                        cbTables.Items.Add(tableName);
                    }

                    if (cbTables.Items.Count == 0)
                    {
                        MessageBox.Show("Не удалось загрузить таблицы.");
                    }

                    cbTables.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке таблиц: {ex.Message}");
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (cbTables.SelectedItem == null)
            {
                MessageBox.Show("Выберите таблицу для загрузки данных.");
                return;
            }

            string tableName = cbTables.SelectedItem.ToString();
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {tableName}", connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbTables.SelectedItem == null)
            {
                MessageBox.Show("Выберите таблицу для добавления записи.");
                return;
            }

            string tableName = cbTables.SelectedItem.ToString();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                AddRecordForm addForm = new AddRecordForm(tableName, connection);
                addForm.ShowDialog();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функция обновления записи еще не реализована.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbTables.SelectedItem == null)
            {
                MessageBox.Show("Выберите таблицу для удаления записи.");
                return;
            }

            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись для удаления.");
                return;
            }

            string tableName = cbTables.SelectedItem.ToString();
            int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"DELETE FROM {tableName} WHERE {tableName}ID = @id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно удалена.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления записи: {ex.Message}");
                }
            }
        }
    }
}
