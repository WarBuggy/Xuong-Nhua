using Xuong_Nhua.Pane.Base;
using System.Drawing;

namespace Xuong_Nhua.Pane.MatIn
{
    public class PaneMatInInfo : PaneBaseInfo
    {
        public PaneMatInInfo()
        {
            AddLabel(new object[] { "Lot", "Lot(s): ", "0" });
            AddLabel(new object[] { "Material", "Material(s): ", "0", Color.DarkCyan });
            AddLabel(new object[] { "Quantity", "Total Qty(kg): ", "0", Color.PaleVioletRed });
            AddLabel(new object[] { "AvgPrice", "Avg price(/kg): ", "0", Color.DarkBlue });
            AddLabel(new object[] { "Sum", "Sum(VND): ", "0", Color.Goldenrod });
            AddLabel(new object[] { "Partner", "Partner(s): ", "0", Color.Orange });
        }

        public void SetInfo(int lot, int material, int quantity, int price, int sum, int partner)
        {
            UpdateLabelValue(new object[] { "Lot", lot });
            UpdateLabelValue(new object[] { "Material", material });
            UpdateLabelValue(new object[] { "Quantity", quantity });
            UpdateLabelValue(new object[] { "AvgPrice", price });
            UpdateLabelValue(new object[] { "Sum", sum});
            UpdateLabelValue(new object[] { "Partner", partner });
        }
    }
}
