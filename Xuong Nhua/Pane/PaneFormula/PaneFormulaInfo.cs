using Xuong_Nhua.Pane.Base;
using System.Drawing;

namespace Xuong_Nhua.Pane.Formula
{
    public class PaneFormulaInfo : PaneBaseInfo
    {
        public PaneFormulaInfo()
        {
            AddLabel(new object[] { "Product", "Product(s): ", "0", Color.ForestGreen });
            AddLabel(new object[] { "Material", "Material(s): ", "0", Color.DarkCyan });
            AddLabel(new object[] { "Total", "Total(g): ", "0", Color.PaleVioletRed });
        }

        public void SetInfo(int product, int material, int total)
        {
            UpdateLabelValue(new object[] { "Product", product });
            UpdateLabelValue(new object[] { "Material", material });
            UpdateLabelValue(new object[] { "Total", total});
        }
    }
}
