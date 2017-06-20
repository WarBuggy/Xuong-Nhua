using Xuong_Nhua.Pane.Base;
using MySql.Data.MySqlClient;
using Xuong_Nhua.InputControl;

namespace Xuong_Nhua.Pane.MatType
{
    class PaneMatTypeUpdate : PaneUpdate
    {
        private PaneInputTextbox TxtName = new PaneInputTextbox("Name");
        private PaneInputTextbox TxtComment = new PaneInputTextbox("Comment");
        private PaneInputTextbox TxtDesc = new PaneInputTextbox("Description");

        public PaneMatTypeUpdate(PaneInfo info)
            : base(info)
        {
        }

        public override void PopulateControls()
        {
            TxtName.SetTextbox("");
            AddControl(TxtName);

            TxtDesc.SetTextbox("", false, 200);
            AddControl(TxtDesc);

            TxtComment.SetTextbox("", false, 200);
            AddControl(TxtComment);
        }

        public override void SetInputControlsArray()
        {
            InputControls = new PaneInputControl[] { TxtName, TxtComment, TxtDesc };
        }

        public override void ReplaceInsertParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("NameInput", TxtName.GetInputValue().ToString());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());
            command.Parameters.AddWithValue("DescInput", TxtDesc.GetInputValue().ToString());

            // INSERT INTO `mattype` (`Name`,`Description`,`Comment`) VALUES (@NameInput, @DescInput, @CommentInput);
        }

        public override void ReplaceEditParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("NameInput", TxtName.GetInputValue().ToString());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());
            command.Parameters.AddWithValue("DescInput", TxtDesc.GetInputValue());

            // UPDATE `mattype` SET `Name` = @NameInput,`Description` = @DescInput,`Comment` = @CommentInput WHERE ID=@ID
        }

        public override void UpdateEditInputData(System.Windows.Forms.DataGridViewRow dataGridViewRow)
        {
            TxtName.SetNewInitValue(dataGridViewRow.Cells[PaneMatType.ColName_Name].Value.ToString());
            TxtComment.SetNewInitValue(dataGridViewRow.Cells[PaneMatType.ColName_Comment].Value.ToString());
            TxtDesc.SetNewInitValue(dataGridViewRow.Cells[PaneMatType.ColName_Desc].Value.ToString());
        }
    }
}
