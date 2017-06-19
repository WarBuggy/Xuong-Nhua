using Xuong_Nhua.Pane.Base;
using MySql.Data.MySqlClient;
using Xuong_Nhua.Theme;
using System.Data;
using Xuong_Nhua.InputControl;

namespace Xuong_Nhua.Pane.Formula
{
    class PaneFormulaUpdate : PaneUpdate
    {
        private PaneInputTextbox TxtComment = new PaneInputTextbox("Comment");
        private PaneInputComboBox CboProduct = new PaneInputComboBox("Product");
        private PaneInputComboBox CboMaterial = new PaneInputComboBox("Material");
        private PaneInputNumberbox NumQuantity = new PaneInputNumberbox("Quantity");

        public PaneFormulaUpdate(PaneInfo info)
            : base(info)
        {
        }

        public override void PopulateControls()
        {
            string sql = "select 1 as sortcol, id, `name` from `product`";
            CboProduct.SetComboBox(sql, ThemeCombo.ONE_SELECT_MODE, "id", "name");
            AddControl(CboProduct);

            sql = "select 1 as sortcol, id, `name` from `material`";
            CboMaterial.SetComboBox(sql, ThemeCombo.ONE_SELECT_MODE, "id", "name");
            AddControl(CboMaterial);

            NumQuantity.SetNumberbox(1);
            AddControl(NumQuantity);
            NumQuantity.ResetValue();

            TxtComment.SetTextbox("", false, 200);
            AddControl(TxtComment);
        }

        public override void SetInputControlsArray()
        {
            InputControls = new PaneInputControl[] { CboProduct, CboMaterial, NumQuantity, TxtComment };
        }

        public override void ReplaceInsertParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("ProductInput", CboProduct.GetInputValue());
            command.Parameters.AddWithValue("MaterialInput", CboMaterial.GetInputValue());
            command.Parameters.AddWithValue("QuantityInput", NumQuantity.GetInputValue());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());

            /*
            INSERT INTO formula (product, material, quantity, comment) VALUES (@ProductInput, @MaterialInput, @QuantityInput, @CommentInput); 
            */
        }

        public override void ReplaceEditParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("ProductInput", CboProduct.GetInputValue());
            command.Parameters.AddWithValue("MaterialInput", CboMaterial.GetInputValue());
            command.Parameters.AddWithValue("QuantityInput", NumQuantity.GetInputValue());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());

            /*
            UPDATE `formula` SET product = @ProductInput, material = @MaterialInput, Quantity = @QuantityInput, Comment = @CommentInput WHERE ID=@ID
            */
        }

        public override void UpdateEditInputData(System.Windows.Forms.DataGridViewRow dataGridViewRow)
        {
            TxtComment.SetNewInitValue(dataGridViewRow.Cells[PaneFormula.ColName_Comment].Value.ToString());
            CboProduct.SetNewInitValue(dataGridViewRow.Cells[PaneFormula.ColName_ProductID].Value);
            CboMaterial.SetNewInitValue(dataGridViewRow.Cells[PaneFormula.ColName_MaterialID].Value);
            NumQuantity.SetNewInitValue(dataGridViewRow.Cells[PaneFormula.ColName_Quantity].Value);
        }

        public override bool CheckExtraInsertRequirement()
        {
            bool IsOk = true;
            string sql = "select id from formula where product=@ProductInput and material=@MaterialInput";
            MySqlCommand command = new MySqlCommand(sql);
            command.Parameters.AddWithValue("ProductInput", CboProduct.GetInputValue());
            command.Parameters.AddWithValue("MaterialInput", CboMaterial.GetInputValue());
            DataTable dt = Share.MySql.GetDataTable(command);
            if (dt.Rows.Count != 0)
            {
                IsOk = false;
                Share.showWarningMessage("Material was already assigned with this product!");
            }
            return IsOk;
        }

        public override bool CheckExtraEditRequirement(int curerrentID)
        {
            bool IsOk = true;
            string sql = "select id from formula where product=@ProductInput and material=@MaterialInput and id <> @IDInput";
            MySqlCommand command = new MySqlCommand(sql);
            command.Parameters.AddWithValue("IDInput", curerrentID);
            command.Parameters.AddWithValue("ProductInput", CboProduct.GetInputValue());
            command.Parameters.AddWithValue("MaterialInput", CboMaterial.GetInputValue());
            DataTable dt = Share.MySql.GetDataTable(command);
            if (dt.Rows.Count != 0)
            {
                IsOk = false;
                Share.showWarningMessage("Material was already assigned with this product!");
            }
            return IsOk;
        }
    }
}
