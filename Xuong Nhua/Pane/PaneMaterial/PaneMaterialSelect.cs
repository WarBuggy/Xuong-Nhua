using Xuong_Nhua.Pane.Base;
using Xuong_Nhua.InputControl;
using Xuong_Nhua.Theme;


namespace Xuong_Nhua.Pane.Material
{
    class PaneMaterialSelect : PaneBaseSelect
    {
        private PaneInputTextbox TxtName;
        private PaneInputComboBox CboType = new PaneInputComboBox("Type");

        public PaneMaterialSelect()
        {
            TxtName = new PaneInputTextbox("Name");
            TxtName.SetTextbox("");
            AddSelector(TxtName);

            string sql = "select 1 as sortcol, id, `name` from `mattype`";
            CboType.SetComboBox(sql, ThemeCombo.ALL_SELECT_MODE, "id", "name");
            AddSelector(CboType);

        }

        public override object[] GetParams()
        {
            return new object[] { TxtName.GetInputValue(), CboType.GetInputValue() };
        }
    }
}
