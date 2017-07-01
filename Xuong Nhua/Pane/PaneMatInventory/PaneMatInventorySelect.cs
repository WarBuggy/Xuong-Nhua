using Xuong_Nhua.Pane.Base;
using Xuong_Nhua.Theme;
using Xuong_Nhua.InputControl;
using System;

namespace Xuong_Nhua.Pane.MatInventory
{
    class PaneMatInventorySelect : PaneBaseSelect
    {
        private PaneInputDateFrom DatFrom = new PaneInputDateFrom("From", -1);
        private PaneInputDate DatUntil = new PaneInputDate("Until");
        private PaneInputTextbox TxtLot = new PaneInputTextbox("Lot");
        private PaneInputComboBox CboMaterial = new PaneInputComboBox("Material");

        public PaneMatInventorySelect()
        {
            DatFrom.SetDateBox();
            DatFrom.Datebox.Value = DateTime.Now.AddMonths(-1);
            AddSelector(DatFrom);

            DatUntil.SetDateBox();
            AddSelector(DatUntil);


            TxtLot = new PaneInputTextbox("Lot");
            TxtLot.SetTextbox("");
            AddSelector(TxtLot);

            string sql = "select 1 as sortcol, id, `name` from `material`";
            CboMaterial.SetComboBox(sql, ThemeCombo.ALL_SELECT_MODE, "id", "name");
            AddSelector(CboMaterial);
        }

        public override object[] GetParams()
        {
            return new object[] { DatFrom.GetInputValue(), DatUntil.GetInputValue(), TxtLot.GetInputValue(), CboMaterial.GetInputValue() };
        }
    }
}
