using Xuong_Nhua.Pane.Base;
using MySql.Data.MySqlClient;
using Xuong_Nhua.Theme;
using Xuong_Nhua.InputControl;

namespace Xuong_Nhua.Pane.Production
{
    class PaneProductionUpdate : PaneUpdate
    {
        private PaneInputDate DatIn = new PaneInputDate("Date");
        private PaneInputComboBox CboSession = new PaneInputComboBox("Session");
        private PaneInputComboBox CboWorker= new PaneInputComboBox("Worker");
        private PaneInputComboBox CboProduct = new PaneInputComboBox("Product");
        private PaneInputNumberbox NumQuantity = new PaneInputNumberbox("Quantity(g)");
        private PaneInputTextbox TxtComment = new PaneInputTextbox("Comment");


        public PaneProductionUpdate(PaneInfo info)
            : base(info)
        {
        }

        public override void PopulateControls()
        {
            DatIn.SetDateBox();
            AddControl(DatIn);

            string sql = "select 1 as sortcol, id, `name` from `session`";
            CboSession.SetComboBox(sql, ThemeCombo.ONE_SELECT_MODE, "id", "name");
            AddControl(CboSession);

            sql = "select 1 as sortcol, id, CONCAT(sirname, ' ', middlename, ' ', givenname) as name from `worker`";
            CboWorker.SetComboBox(sql, ThemeCombo.ONE_SELECT_MODE, "id", "name");
            AddControl(CboWorker);

            sql = "select 1 as sortcol, `id`, `name` from `product` WHERE id IN(select distinct product from formula)";
            CboProduct.SetComboBox(sql, ThemeCombo.ONE_SELECT_MODE, "id", "name");
            AddControl(CboProduct);


            NumQuantity.SetNumberbox(1);
            AddControl(NumQuantity);
            NumQuantity.ResetValue();
            
            TxtComment.SetTextbox("", false, 200);
            AddControl(TxtComment);
        }

        public override void SetInputControlsArray()
        {
            InputControls = new PaneInputControl[] { DatIn, CboSession, CboWorker, CboProduct, NumQuantity, TxtComment };
        }

        public override void ReplaceInsertParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("DateInput", DatIn.GetInputValue());
            command.Parameters.AddWithValue("SessionInput", CboSession.GetInputValue());
            command.Parameters.AddWithValue("WorkerInput", CboWorker.GetInputValue());
            command.Parameters.AddWithValue("ProductInput", CboProduct.GetInputValue());
            command.Parameters.AddWithValue("QuantityInput", NumQuantity.GetInputValue());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());

            /*
            INSERT INTO `production`(`date`,`session`,`worker`,`product`,`quantity`,`Comment`) VALUES (@DateInput, @SessionInput, @WorkerInput, @ProductInput, @QuantityInput, @CommentInput)
            */
        }

        public override void ReplaceEditParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("DateInput", DatIn.GetInputValue());
            command.Parameters.AddWithValue("SessionInput", CboSession.GetInputValue());
            command.Parameters.AddWithValue("WorkerInput", CboWorker.GetInputValue());
            command.Parameters.AddWithValue("ProductInput", CboProduct.GetInputValue());
            command.Parameters.AddWithValue("QuantityInput", NumQuantity.GetInputValue());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());

            /*
            UPDATE `production` SET `date` = @DateInput, `session` = @SessionInput, `worker` = @WorkerInput, `product` = @ProductInput, `quantity` = @QuantityInput, `Comment` = @CommentInput WHERE `ID` = @ID
            */
        }

        public override void UpdateEditInputData(System.Windows.Forms.DataGridViewRow dataGridViewRow)
        {
            DatIn.SetNewInitValue(dataGridViewRow.Cells[PaneProduction.ColName_Date].Value.ToString());
            CboSession.SetNewInitValue(dataGridViewRow.Cells[PaneProduction.ColName_SessionID].Value);
            CboWorker.SetNewInitValue(dataGridViewRow.Cells[PaneProduction.ColName_WorkerID].Value);
            CboProduct.SetNewInitValue(dataGridViewRow.Cells[PaneProduction.ColName_ProductID].Value);
            NumQuantity.SetNewInitValue(dataGridViewRow.Cells[PaneProduction.ColName_Quantity].Value);
            TxtComment.SetNewInitValue(dataGridViewRow.Cells[PaneProduction.ColName_Comment].Value.ToString());
        }
    }
}
