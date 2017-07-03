using Xuong_Nhua.Pane.Base;
using MySql.Data.MySqlClient;
using Xuong_Nhua.InputControl;
using Xuong_Nhua.Theme;

namespace Xuong_Nhua.Pane.Material
{
    class PaneMaterialUpdate : PaneUpdate
    {
        private PaneInputTextbox TxtName = new PaneInputTextbox("Name");
        private PaneInputTextbox TxtComment = new PaneInputTextbox("Comment");
        private PaneInputTextbox TxtDesc = new PaneInputTextbox("Description");
        private PaneInputComboBox CboType = new PaneInputComboBox("Type");

        public PaneMaterialUpdate(PaneInfo info)
            : base(info)
        {
        }

        public override void PopulateControls()
        {
            TxtName.SetTextbox("");
            AddControl(TxtName);

            string sql = "select 1 as sortcol, id, `name` from `mattype`";
            CboType.SetComboBox(sql, ThemeCombo.ALL_SELECT_MODE, "id", "name");
            AddControl(CboType);

            TxtDesc.SetTextbox("", false, 200);
            AddControl(TxtDesc);

            TxtComment.SetTextbox("", false, 200);
            AddControl(TxtComment);

        }

        public override void SetInputControlsArray()
        {
            InputControls = new PaneInputControl[] { TxtName, CboType, TxtDesc, TxtComment };
        }

        public override void ReplaceInsertParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("NameInput", TxtName.GetInputValue().ToString());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());
            command.Parameters.AddWithValue("DescInput", TxtDesc.GetInputValue().ToString());
            command.Parameters.AddWithValue("TypeInput", CboType.GetInputValue());

            // INSERT INTO `material` (`Name`,`Description`,`Comment`,`type`) VALUES (@NameInput, @DescInput, @CommentInput,@TypeInput);
        }

        public override void ReplaceEditParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("NameInput", TxtName.GetInputValue().ToString());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());
            command.Parameters.AddWithValue("DescInput", TxtDesc.GetInputValue());
            command.Parameters.AddWithValue("TypeInput", CboType.GetInputValue());

            // UPDATE `material` SET `Name` = @NameInput,`Description` = @DescInput,`Comment` = @CommentInput, `type`=@TypeInput WHERE ID=@ID
        }

        public override void UpdateEditInputData(System.Windows.Forms.DataGridViewRow dataGridViewRow)
        {
            TxtName.SetNewInitValue(dataGridViewRow.Cells[PaneMaterial.ColName_Name].Value.ToString());
            TxtComment.SetNewInitValue(dataGridViewRow.Cells[PaneMaterial.ColName_Comment].Value.ToString());
            TxtDesc.SetNewInitValue(dataGridViewRow.Cells[PaneMaterial.ColName_Desc].Value.ToString());
            CboType.SetNewInitValue(dataGridViewRow.Cells[PaneMaterial.ColName_TypeID].Value);
        }
    }
}
