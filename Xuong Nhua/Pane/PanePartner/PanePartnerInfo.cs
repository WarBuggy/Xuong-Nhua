using Xuong_Nhua.Pane.Base;
using System.Drawing;

namespace Xuong_Nhua.Pane.Partner
{
    public class PanePartnerInfo : PaneBaseInfo
    {
        public PanePartnerInfo()
        {
            AddLabel(new object[] { "Partner", "Partner(s): ", "0", Color.Orange });
        }

        public void SetInfo(int partner)
        {
            UpdateLabelValue(new object[] { "Partner", partner });
        }
    }
}
