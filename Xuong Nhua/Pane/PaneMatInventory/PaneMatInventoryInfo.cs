using Xuong_Nhua.Pane.Base;
using System.Drawing;

namespace Xuong_Nhua.Pane.MatInventory
{
    public class PaneMatInventoryInfo : PaneBaseInfo
    {
        public PaneMatInventoryInfo()
        {
            AddLabel(new object[] { "Lot", "Lot(s): ", "0" });
            AddLabel(new object[] { "Material", "Material(s): ", "0", Color.DarkCyan });
            AddLabel(new object[] { "Quantity", "Total Qty(kg): ", "0", Color.PaleVioletRed });
            AddLabel(new object[] { "Output", "Total output(kg): ", "0", Color.DarkViolet });
            AddLabel(new object[] { "Remaining", "Total remainng(kg): ", "0", Color.Red});
            AddLabel(new object[] { "AvgPrice", "Avg price: ", "0", Color.DarkBlue });
        }

        public void SetInfo(int lot, int material, double quantity, double output, double remaining, int partner)
        {
            UpdateLabelValue(new object[] { "Lot", lot });
            UpdateLabelValue(new object[] { "Material", material });
            UpdateLabelValue(new object[] { "Quantity", quantity });
            UpdateLabelValue(new object[] { "Output", output });
            UpdateLabelValue(new object[] { "Remaining", remaining });
            UpdateLabelValue(new object[] { "AvgPrice", partner });
        }
    }
}
