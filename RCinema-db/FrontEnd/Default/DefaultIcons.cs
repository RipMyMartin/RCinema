using System;
using System.Drawing;

namespace RCinema_db.FrontEnd.Default
{
    public static class DefaultIcons
    {
        public static Image GetLoginIcon() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultIconsPath, "loginIcon.png")); }
    }
}
