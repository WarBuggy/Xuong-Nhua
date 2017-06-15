using System;
using System.Windows.Forms;

namespace Xuong_Nhua.Theme
{
    public class ThemeTextbox : TextBox
    {
        // Methods
        public ThemeTextbox()
        {
            base.Enter += new EventHandler(this.Me_Enter);
            base.Click += new EventHandler(this.Me_Click);
            this.ForeColor = Share.ColDark;
            this.BackColor = Share.ColLight;
            this.Font = Share.FontApp;
        }

        private void Me_Click(object sender, EventArgs e)
        {
            this.SelectAll();
        }

        private void Me_Enter(object sender, EventArgs e)
        {
            this.SelectAll();
        }
    }
}
