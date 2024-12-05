using System.Data.SqlClient;

namespace RCinema_db
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateDatabaseIfNotExist();
        }
        private void CreateDatabaseIfNotExist()
        {
            DatabaseCreateClass dbIfNot = new DatabaseCreateClass();
            dbIfNot.CreateDatabase();
        }
    }
}
