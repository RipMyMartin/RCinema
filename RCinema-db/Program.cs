using RCinema_db.Account;

namespace RCinema_db
{
    internal static class Program
    {
        private static int _userId;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Assuming you pass the userId as a command line argument
            if (args.Length > 0 && int.TryParse(args[0], out int userId))
            {
                _userId = userId;
            }

            ApplicationConfiguration.Initialize();
            Panel parentContentPanel = new Panel();
            Application.Run(new Login());
        }
    }
}
