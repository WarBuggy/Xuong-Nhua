using System;
using Xuong_Nhua.Pane.Base;
using Xuong_Nhua.InputControl;

namespace Xuong_Nhua.Pane.Partner
{
    class PanePartnerSelect : PaneBaseSelect
    {
        private PaneInputTextbox TxtName;

        public PanePartnerSelect()
        {
            TxtName = new PaneInputTextbox("Name");
            TxtName.SetTextbox("");
            AddSelector(TxtName);
        }

        public override object[] GetParams()
        {
            return new object[] { TxtName.GetInputValue() };
        }
    }
}
