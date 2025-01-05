using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCinema_db.FrontEnd.Default
{
    public static class DefaultPaths
    {
        public static string DefaultIconsPath { get; set; } = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\Images\Icons"));
        public static string DefaultCinemaImagesPath { get; set; } = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\Images\CinemaImage"));
    }
}