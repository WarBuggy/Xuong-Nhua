using System;
using System.Windows.Forms;
using Xuong_Nhua.InputControl;

namespace Xuong_Nhua.Pane.Base
{
    public abstract partial class PaneBaseSelect : UserControl
    {
        public PaneBaseSelect()
        {
            InitializeComponent();
        }

        public void AddSelector(PaneInputControl control)
        {
            control.Name = control.Caption;
            Pane.Controls.Add(control);
        }

        public void RefreshData()
        {
            foreach (Control InputControl in Pane.Controls)
            {
                if (InputControl is PaneInputControl)
                {
                    if (((PaneInputControl)InputControl).MODE == PaneInputControl.MODE_COMBO)
                    {
                        ((PaneInputControl)InputControl).RefreshData();
                    }
                }
            }
        }

        public abstract object[] GetParams();

        internal void ResetParameter()
        {
            foreach (Control InputControl in Pane.Controls)
            {
                if (InputControl is PaneInputControl)
                {
                    ((PaneInputControl)InputControl).ResetValue();
                }
            }
        }
    }
}
