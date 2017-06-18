using Xuong_Nhua.Pane.Base;

namespace Xuong_Nhua.Pane.Formula
{
    public class PaneFormulaInfo : PaneBaseInfo
    {
        public PaneFormulaInfo()
        {
            AddLabel(new object[] { "Formula", "Formula(s): ", "0" });
            AddLabel(new object[] { "Product", "Product(s): ", "0" });
            AddLabel(new object[] { "Material", "Material(s): ", "0" });
        }

        public void SetInfo(int formula, int product, int material)
        {
            UpdateLabelValue(new object[] { "Formula", formula});
            UpdateLabelValue(new object[] { "Product", product });
            UpdateLabelValue(new object[] { "Material", material});
        }
    }
}
