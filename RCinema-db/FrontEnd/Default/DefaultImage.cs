﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCinema_db.FrontEnd.Default
{
    public static class DefaultImage
    {
        public static Image GetCinemaImage_NewLife() { return Image.FromFile(Path.Combine(DefaultPaths.DefaultCinemaImagesPath, "newLife.png")); }
    }
}