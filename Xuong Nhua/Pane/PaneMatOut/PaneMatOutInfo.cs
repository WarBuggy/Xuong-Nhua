using Xuong_Nhua.Pane.Base;
using System.Drawing;

namespace Xuong_Nhua.Pane.MatOut
{
    public class PaneMatOutInfo : PaneBaseInfo
    {
        public PaneMatOutInfo()
        {
            AddLabel(new object[] { "Output", "Output(s): ", "0" });
            AddLabel(new object[] { "Lot", "Lot(s): ", "0" });
            AddLabel(new object[] { "Material", "Material(s): ", "0", Color.DarkCyan });
            AddLabel(new object[] { "Quantity", "Total Qty(g): ", "0", Color.PaleVioletRed });
            AddLabel(new object[] { "Production", "Production(s): ", "0" });
            AddLabel(new object[] { "Product", "Product(s): ", "0", Color.ForestGreen });
        }

        public void SetInfo(int output, int lot, int material, int quantity, int production, int product)
        {
            UpdateLabelValue(new object[] { "Output", output });
            UpdateLabelValue(new object[] { "Lot", lot });
            UpdateLabelValue(new object[] { "Material", material });
            UpdateLabelValue(new object[] { "Quantity", quantity });
            UpdateLabelValue(new object[] { "Production", production });
            UpdateLabelValue(new object[] { "Product", product });
        }
    }
}
