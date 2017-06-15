using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Xuong_Nhua.Theme
{
    public class PaneCenterFlow : FlowLayoutPanel
    {
        // Fields
        private int intControlNum;
        private int intTotalControlHeight = 0;
        private int intTotalControlWidth = 0;

        // Methods
        public PaneCenterFlow()
        {
            this.BackColor = Share.ColLight;
            Padding padding = new Padding(10, 10, 10, 10);
            this.Padding = padding;
        }

        public void AddControls(Control aControl)
        {
            this.intControlNum = this.Controls.Count;
            this.intTotalControlWidth = (this.intTotalControlWidth + aControl.Width) + 20;
            this.intTotalControlHeight = (this.intTotalControlHeight + aControl.Height) + 20;
            if ((this.FlowDirection == FlowDirection.LeftToRight) | (this.FlowDirection == FlowDirection.RightToLeft))
            {
                Padding padding = new Padding((int)Math.Round((double)(((double)(this.Width - this.intTotalControlWidth)) / 2.0)), this.Padding.Top, (int)Math.Round((double)(((double)(this.Width - this.intTotalControlWidth)) / 2.0)), this.Padding.Bottom);
                this.Padding = padding;
            }
            else
            {
                Padding padding = new Padding(this.Padding.Left, (int)Math.Round((double)(((double)(this.Height - this.intTotalControlHeight)) / 2.0)), this.Padding.Right, (int)Math.Round((double)(((double)(this.Height - this.intTotalControlHeight)) / 2.0)));
                this.Padding = padding;
            }
            this.Controls.Add(aControl);
        }

        public int GetControlWidths()
        {
            return this.intTotalControlWidth;
        }
    }
}
