using Xuong_Nhua.Pane.Base;
using Xuong_Nhua.Theme;
using Xuong_Nhua.InputControl;

namespace Xuong_Nhua.Pane.Formula
{
    class PaneFormulaSelect : PaneBaseSelect
    {
        private PaneInputComboBox CboProduct = new PaneInputComboBox("Product");
        private PaneInputComboBox CboMaterial = new PaneInputComboBox("Material");
        private PaneInputComboBox CboInOut = new PaneInputComboBox("In/Out");

        public PaneFormulaSelect()
        {

            string sql = "select 1 as sortcol, id, `name` from `product`";
            CboProduct.SetComboBox(sql, ThemeCombo.ALL_SELECT_MODE, "id", "name");
            AddSelector(CboProduct);

            sql = "select 1 as sortcol, id, `name` from `material`";
            CboMaterial.SetComboBox(sql, ThemeCombo.ALL_SELECT_MODE, "id", "name");
            AddSelector(CboMaterial);
            
            sql = "select 1 as sortcol, 0 as id, 'In' as `name` UNION select 1 as sortcol, 1 as id, 'Out' as `name`";
            CboInOut.SetComboBox(sql, ThemeCombo.ALL_SELECT_MODE, "id", "name");
            AddSelector(CboInOut);

        }

        public override object[] GetParams()
        {
            return new object[] { CboProduct.GetInputValue(), CboMaterial.GetInputValue(), CboInOut.GetInputValue() };
        }
    }
}
