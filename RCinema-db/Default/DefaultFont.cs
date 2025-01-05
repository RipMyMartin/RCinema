using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using RCinema_db.FrontEnd.Default;

namespace RCinema_db.FrontEnd.Default
{
    public static class DefaultFont
    {
        private static PrivateFontCollection fontCollection = new PrivateFontCollection();

        static DefaultFont()
        {
            fontCollection.AddFontFile(@"..\..\..\FrontEnd\Default\Tomorrow-Bold.ttf");
        }

        public static Font GetFont(float size)
        {
            return new Font(fontCollection.Families[0], size);
        }

        public static void SetFont(Form form, float size)
        {
            form.Font = new Font(fontCollection.Families[0], size);
        }
    }
}
