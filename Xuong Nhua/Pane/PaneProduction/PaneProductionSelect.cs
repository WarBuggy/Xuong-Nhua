using Xuong_Nhua.Pane.Base;
using Xuong_Nhua.Theme;
using Xuong_Nhua.InputControl;
using System;

namespace Xuong_Nhua.Pane.Production
{
    class PaneProductionSelect : PaneBaseSelect
    {
        private PaneInputDateFrom DatFrom = new PaneInputDateFrom("From", -3);
        private PaneInputDate DatUntil = new PaneInputDate("Until");
        private PaneInputComboBox CboWorker = new PaneInputComboBox("Worker");
        private PaneInputComboBox CboProduct = new PaneInputComboBox("Product");

        public PaneProductionSelect()
        {
            DatFrom.SetDateBox();
            DatFrom.Datebox.Value = DateTime.Now.AddYears(-1);
            AddSelector(DatFrom);

            DatUntil.SetDateBox();
            AddSelector(DatUntil);

            string sql = "select 1 as sortcol, id, CONCAT(sirname, ' ', middlename, ' ', givenname) as fullname from `worker`";
            CboWorker.SetComboBox(sql, ThemeCombo.ALL_SELECT_MODE, "id", "fullname");
            AddSelector(CboWorker);


            sql = "select 1 as sortcol, id, `name` from `product`";
            CboProduct.SetComboBox(sql, ThemeCombo.ALL_SELECT_MODE, "id", "name");
            AddSelector(CboProduct);
        }

        public override object[] GetParams()
        {
            return new object[] { DatFrom.GetInputValue(), DatUntil.GetInputValue(), CboWorker.GetInputValue(), CboProduct.GetInputValue() };
        }
    }
}
