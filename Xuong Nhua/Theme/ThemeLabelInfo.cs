﻿using System;
using System.Windows.Forms;
using System.Drawing;

namespace Xuong_Nhua.Theme
{
    public class ThemeLabelInfo : Label
    {
        public ThemeLabelInfo()
        {
            this.Padding = new Padding(5, 0, 0, 0);
            this.AutoSize = true;
            this.Font = Share.FontApp;
            this.ForeColor = Share.ColDark;
        }
    }
}
