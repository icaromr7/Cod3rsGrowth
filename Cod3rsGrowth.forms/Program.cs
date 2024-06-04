using System.Configuration;

namespace Cod3rsGrowth.forms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings["ConnectionString"];
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}