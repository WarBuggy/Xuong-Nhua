using Xuong_Nhua.Pane.Base;
using Xuong_Nhua.InputControl;
using Xuong_Nhua.Theme;

namespace Xuong_Nhua.Pane.Session
{
    class PaneSessionSelect : PaneBaseSelect
    {
        private PaneInputTextbox TxtName;

        public PaneSessionSelect()
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
