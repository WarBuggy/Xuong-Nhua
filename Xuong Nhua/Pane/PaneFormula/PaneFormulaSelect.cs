using Xuong_Nhua.Pane.Base;
using Xuong_Nhua.Theme;
using Xuong_Nhua.InputControl;

namespace Xuong_Nhua.Pane.Formula
{
    class PaneFormulaSelect : PaneBaseSelect
    {
        private PaneInputTextbox TxtName;
        private PaneInputComboBox CboProduct = new PaneInputComboBox("Product");
        private PaneInputComboBox CboMaterial = new PaneInputComboBox("Material");

        public PaneFormulaSelect()
        {
            TxtName = new PaneInputTextbox("Name");
            TxtName.SetTextbox("");
            AddSelector(TxtName);

            string sql = "select 1 as sortcol, id, `name` from `product`";
            CboProduct.SetComboBox(sql, ThemeCombo.ALL_SELECT_MODE, "id", "name");
            AddSelector(CboProduct);

            sql = "select 1 as sortcol, id, `name` from `material`";
            CboMaterial.SetComboBox(sql, ThemeCombo.ALL_SELECT_MODE, "id", "name");
            AddSelector(CboMaterial);
        }

        public override object[] GetParams()
        {
            return new object[] { TxtName.GetInputValue(), CboProduct.GetInputValue(), CboMaterial.GetInputValue() };
        }
    }
}
