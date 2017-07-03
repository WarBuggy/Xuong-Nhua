using Xuong_Nhua.Pane.Base;
using System.Drawing;

namespace Xuong_Nhua.Pane.Production
{
    public class PaneProductionInfo : PaneBaseInfo
    {
        public PaneProductionInfo()
        {
            AddLabel(new object[] { "Production", "Productions(s): ", "0" });
            AddLabel(new object[] { "Worker", "Worker(s): ", "0", Color.DarkGoldenrod });
            AddLabel(new object[] { "Product", "Product(s): ", "0", Color.ForestGreen });
            AddLabel(new object[] { "Quantity", "Total Qty(kg): ", "0", Color.PaleVioletRed });
        }

        public void SetInfo(int production, int worker, int product, int quantity)
        {
            UpdateLabelValue(new object[] { "Production", production });
            UpdateLabelValue(new object[] { "Worker", worker });
            UpdateLabelValue(new object[] { "Product", product });
            UpdateLabelValue(new object[] { "Quantity", quantity });
        }
    }
}
