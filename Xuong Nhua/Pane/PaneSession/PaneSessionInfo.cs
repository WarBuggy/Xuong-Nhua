using Xuong_Nhua.Pane.Base;

namespace Xuong_Nhua.Pane.Session
{
    public class PaneSessionInfo : PaneBaseInfo
    {
        public PaneSessionInfo()
        {
            AddLabel(new object[] { "Session", "Session(s): ", "0" });
        }

        public void SetInfo(int session)
        {
            UpdateLabelValue(new object[] { "Session", session });
        }
    }
}
