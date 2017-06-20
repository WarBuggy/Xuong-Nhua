using Xuong_Nhua.Pane.Base;

namespace Xuong_Nhua.Pane.MatType
{
    public class PaneMatTypeInfo : PaneBaseInfo
    {
        public PaneMatTypeInfo()
        {
            AddLabel(new object[] { "Type", "Type(s): ", "0" });
        }

        public void SetInfo(int type)
        {
            UpdateLabelValue(new object[] { "Type", type });
        }
    }
}
