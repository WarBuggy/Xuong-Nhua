using Xuong_Nhua.Pane.Base;
using Xuong_Nhua.InputControl;

namespace Xuong_Nhua.Pane.MatType
{
    class PaneMatTypeSelect : PaneBaseSelect
    {
        private PaneInputTextbox TxtName;

        public PaneMatTypeSelect()
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
