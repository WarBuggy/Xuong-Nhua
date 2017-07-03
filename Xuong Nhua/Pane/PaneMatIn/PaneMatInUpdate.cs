using Xuong_Nhua.Pane.Base;
using MySql.Data.MySqlClient;
using Xuong_Nhua.Theme;
using System.Data;
using Xuong_Nhua.InputControl;

namespace Xuong_Nhua.Pane.MatIn
{
    class PaneMatInUpdate : PaneUpdate
    {
        private PaneInputDate DatIn = new PaneInputDate("Date");
        private PaneInputTextbox TxtLot = new PaneInputTextbox("Lot");
        private PaneInputComboBox CboMaterial = new PaneInputComboBox("Material");
        private PaneInputComboBox CboPartner = new PaneInputComboBox("Partner");
        private PaneInputNumberbox NumPrice = new PaneInputNumberbox("Price");
        private PaneInputNumberbox NumQuantity = new PaneInputNumberbox("Quantity");
        private PaneInputTextbox TxtComment = new PaneInputTextbox("Comment");


        public PaneMatInUpdate(PaneInfo info)
            : base(info)
        {
        }

        public override void PopulateControls()
        {
            DatIn.SetDateBox();
            AddControl(DatIn);

            TxtLot.SetTextbox("", false, 100);
            AddControl(TxtLot);

            string sql = "select 1 as sortcol, id, `name` from `material`";
            CboMaterial.SetComboBox(sql, ThemeCombo.ONE_SELECT_MODE, "id", "name");
            AddControl(CboMaterial);

            NumQuantity.SetNumberbox(1);
            AddControl(NumQuantity);
            NumQuantity.ResetValue();

            NumPrice.SetNumberbox(1);
            AddControl(NumPrice);
            NumQuantity.ResetValue();

            sql = "select 1 as sortcol, id, `name` from `partner`";
            CboPartner.SetComboBox(sql, ThemeCombo.ONE_SELECT_MODE, "id", "name");
            AddControl(CboPartner);

            TxtComment.SetTextbox("", false, 200);
            AddControl(TxtComment);
        }

        public override void SetInputControlsArray()
        {
            InputControls = new PaneInputControl[] { DatIn, TxtLot, CboMaterial, NumQuantity, NumPrice, CboPartner, TxtComment };
        }

        public override void ReplaceInsertParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("DatInInput", DatIn.GetInputValue());
            command.Parameters.AddWithValue("LotInput", TxtLot.GetInputValue());
            command.Parameters.AddWithValue("MaterialInput", CboMaterial.GetInputValue());
            command.Parameters.AddWithValue("QuantityInput", NumQuantity.GetInputValue());
            command.Parameters.AddWithValue("PriceInput", NumPrice.GetInputValue());
            command.Parameters.AddWithValue("PartnerInput", CboPartner.GetInputValue());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());

            /*
            INSERT INTO matin (date, lot, material, quantity, price, partner, comment) VALUES (@DatInInput, @LotInput, @MaterialInput, @QuantityInput, @PriceInput, @PartnerInput, @CommentInput); 
            */
        }

        public override void ReplaceEditParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("DatInInput", DatIn.GetInputValue());
            command.Parameters.AddWithValue("LotInput", TxtLot.GetInputValue());
            command.Parameters.AddWithValue("MaterialInput", CboMaterial.GetInputValue());
            command.Parameters.AddWithValue("QuantityInput", NumQuantity.GetInputValue());
            command.Parameters.AddWithValue("PriceInput", NumPrice.GetInputValue());
            command.Parameters.AddWithValue("PartnerInput", CboPartner.GetInputValue());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());

            /*
            UPDATE `matin` SET `date` = @DatInInput, `lot`=@LotInput, `material` = @MaterialInput, `Quantity` = @QuantityInput, `price`=@PriceInput, `partner`=@PartnerInput, `Comment` = @CommentInput WHERE `ID`=@ID
            */
        }

        public override void UpdateEditInputData(System.Windows.Forms.DataGridViewRow dataGridViewRow)
        {
            DatIn.SetNewInitValue(dataGridViewRow.Cells[PaneMatIn.ColName_Date].Value.ToString());
            TxtLot.SetNewInitValue(dataGridViewRow.Cells[PaneMatIn.ColName_Lot].Value.ToString());
            TxtComment.SetNewInitValue(dataGridViewRow.Cells[PaneMatIn.ColName_Comment].Value.ToString());
            CboPartner.SetNewInitValue(dataGridViewRow.Cells[PaneMatIn.ColName_PartnerID].Value);
            CboMaterial.SetNewInitValue(dataGridViewRow.Cells[PaneMatIn.ColName_MaterialID].Value);
            NumQuantity.SetNewInitValue(dataGridViewRow.Cells[PaneMatIn.ColName_Quantity].Value);
            NumPrice.SetNewInitValue(dataGridViewRow.Cells[PaneMatIn.ColName_Price].Value);
        }
    }
}
