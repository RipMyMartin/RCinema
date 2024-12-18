using RCinema_db.MainWeb;

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
            // First, initialize the application configuration
            ApplicationConfiguration.Initialize();  // This should be the first thing in the Main method

            // Now, initialize the Panel object (this could be the parent container in your UI)
            Panel parentContentPanel = new Panel();

            // Now run the application with the HomeForm, passing the Panel
            Application.Run(new HomeForm(parentContentPanel));  // Passing the parentContentPanel to the form
        }
    }
}
