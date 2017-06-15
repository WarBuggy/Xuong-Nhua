using System;
using Xuong_Nhua.Pane.Base;

namespace Xuong_Nhua.Pane.Partner
{
    public class PanePartnerInfo : PaneBaseInfo
    {
        public PanePartnerInfo()
        {
            AddLabel(new object[] { "Partner", "Partner(s): ", "0" });
        }

        public void SetInfo(int partner)
        {
            UpdateLabelValue(new object[] { "Partner", partner });
        }
    }
}
