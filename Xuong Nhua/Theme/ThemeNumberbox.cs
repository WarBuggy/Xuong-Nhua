using System;
using System.Windows.Forms;
using System.Drawing;

namespace Xuong_Nhua.Theme
{
    class ThemeNumberbox : NumericUpDown
    {
        // Methods
        public ThemeNumberbox()
        {
            base.Enter += new EventHandler(this.Me_Enter);
            base.Click += new EventHandler(this.Me_Click);
            this.Font = Share.FontApp;
            this.BackColor = Share.ColLight;
            this.ForeColor = Share.ColDark;
            Size size = new Size(50, 0x16);
            this.Size = size;
            this.TextAlign = HorizontalAlignment.Right;
            this.ThousandsSeparator = true;
            this.Minimum = decimal.Zero;
            this.Maximum = 9999999M;
        }

        private void Me_Click(object sender, EventArgs e)
        {
            this.Select(0, this.ToString().Length);
        }

        private void Me_Enter(object sender, EventArgs e)
        {
            this.Select(0, this.ToString().Length);
        }

        public string returnValue()
        {
            return this.Value.ToString().Replace(".", "").Replace(",", ".");
        }
    }
}
