using System.IO;
using System.Windows;

namespace DogsExhibitionsSystem
{
    public partial class App : Application
    {
        public static string DbFilePath { get; private set; }
        public static bool NeedDeleteDb { get; private set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            DbFilePath = e.Args[0];
            NeedDeleteDb = int.Parse(e.Args[1]) == 1;
            if (NeedDeleteDb)
                File.Delete(DbFilePath);
        }
    }
}
