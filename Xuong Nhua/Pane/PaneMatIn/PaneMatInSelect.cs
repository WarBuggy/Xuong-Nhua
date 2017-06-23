using Xuong_Nhua.Pane.Base;
using Xuong_Nhua.Theme;
using Xuong_Nhua.InputControl;
using System;

namespace Xuong_Nhua.Pane.MatIn
{
    class PaneMatInSelect : PaneBaseSelect
    {
        private PaneInputDate DatFrom = new PaneInputDate("From");
        private PaneInputDate DatUntil = new PaneInputDate("Until");
        private PaneInputTextbox TxtLot = new PaneInputTextbox("Lot");
        private PaneInputComboBox CboPartner = new PaneInputComboBox("Partner");
        private PaneInputComboBox CboMaterial = new PaneInputComboBox("Material");

        public PaneMatInSelect()
        {
            DatFrom.SetDateBox();
            DatFrom.Datebox.Value = DateTime.Now.AddYears(-1);
            AddSelector(DatFrom);

            DatUntil.SetDateBox();
            AddSelector(DatUntil);


            TxtLot = new PaneInputTextbox("Lot");
            TxtLot.SetTextbox("");
            AddSelector(TxtLot);

            string sql = "select 1 as sortcol, id, `name` from `material`";
            CboMaterial.SetComboBox(sql, ThemeCombo.ALL_SELECT_MODE, "id", "name");
            AddSelector(CboMaterial);


            sql = "select 1 as sortcol, id, `name` from `partner`";
            CboPartner.SetComboBox(sql, ThemeCombo.ALL_SELECT_MODE, "id", "name");
            AddSelector(CboPartner);
        }

        public override object[] GetParams()
        {
            return new object[] { DatFrom.GetInputValue(), DatUntil.GetInputValue(), TxtLot.GetInputValue(), CboMaterial.GetInputValue(), CboPartner.GetInputValue() };
        }
    }
}
