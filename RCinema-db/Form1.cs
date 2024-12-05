using System.Data.SqlClient;

namespace RCinema_db
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateDatabase();
            //BLA TI DAUN
        }

        private void CreateDatabase()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\RCinema-db\RCinema-db\Database.mdf;Integrated Security=True"))
                {
                    conn.Open();
                    string createTablesQuery = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Ladu') 
                    BEGIN
                        CREATE TABLE Ladu (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            LaoNimetus VARCHAR(50) NOT NULL,
                            Suurus VARCHAR(50) NOT NULL,
                            Kirjeldus NCHAR(10) NOT NULL
                        );

                        INSERT INTO Ladu (LaoNimetus, Suurus, Kirjeldus)
                        VALUES
                            ('Suur', '5', 'POLE'),
                            ('Keskmine', '3', 'POLE'),
                            ('Väike', '1', 'POLE');
                    END;

                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Toode') 
                    BEGIN
                        CREATE TABLE Toode (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            Nimetus NVARCHAR(100) NOT NULL,
                            Kogus INT NOT NULL,
                            Hind DECIMAL(18, 2) NOT NULL,
                            Pilt NVARCHAR(MAX),
                            ProductPicture VARBINARY(MAX),
                            LaoId INT NULL,
                            CONSTRAINT FK_Toode_Ladu FOREIGN KEY (LaoId) REFERENCES Ladu (Id)
                        );
                    END;
                    ";

                    using (SqlCommand cmd = new SqlCommand(createTablesQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Viga andmebaasi või tabeli loomisel: " + ex.Message);
            }
        }
    }
}
