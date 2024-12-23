using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCinema_db.FrontEnd.Default
{
    public static class DefaultColor
    {
        public static Color darkGray { get; set; } = ColorTranslator.FromHtml("#1B1B1B");
        public static Color lightGray { get; set; } = ColorTranslator.FromHtml("#2B2B2B");
        public static Color white { get; set; } = ColorTranslator.FromHtml("#FFFFFF");
        public static Color buttonSubmit { get; set; } = ColorTranslator.FromHtml("#FF3A1E");
    }
}
