﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xuong_Nhua.Theme
{
    public partial class ThemeLabel : UserControl
    {
        public ThemeLabel()
        {
            InitializeComponent();
            Label.ForeColor = Share.ColDark;
            Label.TextAlign = ContentAlignment.MiddleCenter;
            Label.BackColor = Color.Transparent;
            Label.Font = Share.FontApp;
            Label.AutoSize = true;
        }

        public Label GetLabel()
        {
            return Label;
        }
    }
}
