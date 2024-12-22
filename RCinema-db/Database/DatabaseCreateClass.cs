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
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'languages')
                BEGIN
                    CREATE TABLE languages (
                        LanguageID INT IDENTITY(1,1) PRIMARY KEY,
                        Language VARCHAR(20) NOT NULL,
                        CONSTRAINT UC_Language UNIQUE (Language)
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'movies')
                BEGIN
                    CREATE TABLE movies (
                        MovieID INT IDENTITY(1,1) PRIMARY KEY,
                        MovieName VARCHAR(100) NOT NULL,
                        ReleaseDate DATE NOT NULL,
                        MovieImage VARBINARY(MAX) NOT NULL,
                        MovieStart TIME NULL,
                        MovieLength TIME NULL,
                        MovieYear INT NULL,
                        LanguageID INT NOT NULL,
                        PlanID INT NOT NULL,
                        FOREIGN KEY (LanguageID) REFERENCES languages(LanguageID) ON DELETE CASCADE,
                        FOREIGN KEY (PlanID) REFERENCES moviesplan(PlanID) ON DELETE CASCADE
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'moviesplan')
                BEGIN
                    CREATE TABLE moviesplan (
                        PlanID INT IDENTITY(1,1) PRIMARY KEY,
                        PlanRow INT NOT NULL,
                        PlanSeat INT NOT NULL,
                        SeatID INT NOT NULL,
                        FOREIGN KEY (SeatID) REFERENCES seats(SeatID) ON DELETE CASCADE
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'purchases')
                BEGIN
                    CREATE TABLE purchases (
                        PurchaseID INT IDENTITY(1,1) PRIMARY KEY,
                        UserID INT NOT NULL,
                        TypeID INT NOT NULL,
                        MovieID INT NOT NULL,
                        PurchaseDate DATETIME NOT NULL DEFAULT GETDATE(),
                        SeatsCount INT NOT NULL,
                        TotalPrice DECIMAL(10,2) NOT NULL,
                        FOREIGN KEY (UserID) REFERENCES users(UserID) ON DELETE CASCADE,
                        FOREIGN KEY (TypeID) REFERENCES tickettype(TypeID) ON DELETE CASCADE,
                        FOREIGN KEY (MovieID) REFERENCES movies(MovieID) ON DELETE CASCADE
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'purchased_seats')
                BEGIN
                    CREATE TABLE purchased_seats (
                        PurchaseID INT NOT NULL,
                        SeatID INT NOT NULL,
                        PRIMARY KEY (PurchaseID, SeatID),
                        FOREIGN KEY (PurchaseID) REFERENCES purchases(PurchaseID) ON DELETE CASCADE,
                        FOREIGN KEY (SeatID) REFERENCES seats(SeatID) ON DELETE CASCADE
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'seats')
                BEGIN
                    CREATE TABLE seats (
                        SeatID INT IDENTITY(1,1) PRIMARY KEY,
                        SeatName VARCHAR(50) NULL,
                        BasePrice DECIMAL(10,2) NOT NULL
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tickettype')
                BEGIN
                    CREATE TABLE tickettype (
                        TypeID INT IDENTITY(1,1) PRIMARY KEY,
                        SeatID INT NOT NULL,
                        Type VARCHAR(50) NOT NULL,
                        Price DECIMAL(10,2) NOT NULL,
                        FOREIGN KEY (SeatID) REFERENCES seats(SeatID) ON DELETE CASCADE
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'users')
                BEGIN
                    CREATE TABLE users (
                        UserID INT IDENTITY(1,1) PRIMARY KEY,
                        Username VARCHAR(20) NOT NULL,
                        Email VARCHAR(100) NOT NULL,
                        Password VARCHAR(100) NOT NULL,
                        Role VARCHAR(10) DEFAULT 'User',
                        CONSTRAINT UC_Email UNIQUE (Email)
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
