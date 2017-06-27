using Xuong_Nhua.Pane.Base;
using Xuong_Nhua.InputControl;
using Xuong_Nhua.Theme;

namespace Xuong_Nhua.Pane.Worker
{
    class PaneWorkerSelect : PaneBaseSelect
    {
        private PaneInputTextbox TxtSirName;
        private PaneInputTextbox TxtGivenName;

        public PaneWorkerSelect()
        {
            TxtSirName = new PaneInputTextbox("SirName");
            TxtSirName.SetTextbox("");
            AddSelector(TxtSirName);

            TxtGivenName = new PaneInputTextbox("GivenName");
            TxtGivenName.SetTextbox("");
            AddSelector(TxtGivenName);
        }

        public override object[] GetParams()
        {
            return new object[] { TxtSirName.GetInputValue(), TxtGivenName.GetInputValue() };
        }
    }
}
