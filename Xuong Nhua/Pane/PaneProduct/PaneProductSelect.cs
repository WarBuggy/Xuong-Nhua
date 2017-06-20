using Xuong_Nhua.Pane.Base;
using Xuong_Nhua.InputControl;

namespace Xuong_Nhua.Pane.Product
{
    class PaneProductSelect : PaneBaseSelect
    {
        private PaneInputTextbox TxtName;

        public PaneProductSelect()
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
