using Xuong_Nhua.Pane.Base;
using MySql.Data.MySqlClient;
using Xuong_Nhua.Theme;
using System.Data;
using Xuong_Nhua.InputControl;

namespace Xuong_Nhua.Pane.MatInventory
{
    class PaneMatInventoryUpdate : PaneUpdate
    {
        private PaneInputDate DatIn = new PaneInputDate("Date");
        private PaneInputTextbox TxtLot = new PaneInputTextbox("Lot");
        private PaneInputComboBox CboProduction = new PaneInputComboBox("Production");
        private PaneInputNumberbox NumQuantity = new PaneInputNumberbox("Quantity(g)");
        private PaneInputTextbox TxtComment = new PaneInputTextbox("Comment");
        private int id;

        public PaneMatInventoryUpdate(PaneInfo info)
            : base(info)
        {
        }

        public override void PopulateControls()
        {
            DatIn.SetDateBox();
            AddControl(DatIn);

            TxtLot.SetTextbox("", false, 100);
            TxtLot.SetEnable(false);
            AddControl(TxtLot);

            string sql = "";
            CboProduction.SetComboBox(sql, ThemeCombo.ONE_SELECT_MODE, "id", "name");
            AddControl(CboProduction);

            NumQuantity.SetNumberbox(1);
            AddControl(NumQuantity);
            NumQuantity.ResetValue();

            TxtComment.SetTextbox("", false, 200);
            AddControl(TxtComment);
        }

        public override void SetInputControlsArray()
        {
            InputControls = new PaneInputControl[] { DatIn, TxtLot, CboProduction, NumQuantity, TxtComment };
        }

        public override void ReplaceInsertParams(ref MySqlCommand command) { }

        public override void ReplaceEditParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("DateInput", DatIn.GetInputValue());
            command.Parameters.AddWithValue("InIDInput", id);
            command.Parameters.AddWithValue("QuantityInput", NumQuantity.GetInputValue());
            command.Parameters.AddWithValue("ProductionInput", CboProduction.GetInputValue());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue());
            /*
            INSERT INTO `matout` (`date`,`inid`,`quantity`,`production`,`comment`) VALUES(@DateInput,@InIDInput,@QuantityInput,@ProductionInput,@CommentInput)
            */
        }

        public override void UpdateEditInputData(System.Windows.Forms.DataGridViewRow dataGridViewRow)
        {
            id = (int)dataGridViewRow.Cells[PaneMatInventory.ColName_ID].Value;
            TxtLot.SetNewInitValue(dataGridViewRow.Cells[PaneMatInventory.ColName_Lot].Value.ToString());
            string sql = "SELECT 1 as sortcol,P.`id`, CONCAT(DATE_FORMAT(P.`Date`,'%d-%m-%y'), '; ',S.`name`) as `name`";
            sql = sql + "FROM `production` as P,material as M,`matin` as I,`formula` as F,`product` as R,`session` as S ";
            sql = sql + "WHERE I.`ID`=" + id + " AND M.`ID`= F.`material` AND P.`product`= R.`ID` ";
            sql = sql + "AND I.`material`= M.`ID` AND F.`product`= P.`product` ";
            sql = sql + "AND S.`id`= P.`session`";
            CboProduction.SetComboBox(sql, ThemeCombo.ONE_SELECT_MODE, "id", "name");
        }

        public override bool CheckExtraEditRequirement(int inputId)
        {
            string sql = "select I.`quantity` - (select coalesce(sum(`quantity`), 0) from matout where inid =" + inputId;
            sql = sql + ") - " + NumQuantity.GetInputValue() + " FROM `matin` as I WHERE I.`id`=" + inputId;
            MySqlCommand command = new MySqlCommand(sql);
            DataTable temp = Share.MySql.GetDataTable(command);
            if ((decimal)temp.Rows[0][0] < 0)
            {
                Share.showErrorMessage("Not enough quantity. Please reduce the amount and select another lot!");
                return false;
            }

            return true;
        }

    }
}
