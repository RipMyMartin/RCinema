using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RCinema_db.Database
{
    internal class DatabaseCreateClass
    {
        public void CreateDatabase()
        {
            SqlConnection conn = null;
            try
            {
                conn = DatabaseConnection.GetConnection();
                conn.Open();

                string createTablesQuery = @"
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'User')
                    BEGIN
                        CREATE TABLE Account (
                            UserID INT IDENTITY(1,1) PRIMARY KEY, 
                            UserName VARCHAR(20) NOT NULL,         
                            FirstName VARCHAR(20) NOT NULL,        
                            LastName VARCHAR(20) NOT NULL,         
                            Password VARCHAR(100) NOT NULL,   
                            Role VARCHAR(10) NOT NULL
                        );
                    END;
            ";

                using (SqlCommand cmd = new SqlCommand(createTablesQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Viga andmebaasi või tabeli loomisel: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
