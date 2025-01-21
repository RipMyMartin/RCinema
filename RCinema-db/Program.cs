using RCinema_db.Account;
using RCinema_db.FrontEnd;

namespace RCinema_db
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Panel parentContentPanel = new Panel();
            Application.Run(new Login());  
        }
    }
}
