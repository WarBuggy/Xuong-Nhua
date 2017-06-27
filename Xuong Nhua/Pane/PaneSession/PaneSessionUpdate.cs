using Xuong_Nhua.Pane.Base;
using MySql.Data.MySqlClient;
using Xuong_Nhua.InputControl;
using Xuong_Nhua.Theme;

namespace Xuong_Nhua.Pane.Session
{
    class PaneSessionUpdate : PaneUpdate
    {
        private PaneInputTextbox TxtName = new PaneInputTextbox("Name");
        private PaneInputTextbox TxtComment = new PaneInputTextbox("Comment");
        private PaneInputTextbox TxtDesc = new PaneInputTextbox("Description");
        private PaneInputNumberbox NumLength = new PaneInputNumberbox("Length");

        public PaneSessionUpdate(PaneInfo info)
            : base(info)
        {
        }

        public override void PopulateControls()
        {
            TxtName.SetTextbox("");
            AddControl(TxtName);

            TxtDesc.SetTextbox("", false, 200);
            AddControl(TxtDesc);

            NumLength.SetNumberbox(1);
            AddControl(NumLength);
            NumLength.ResetValue();

            TxtComment.SetTextbox("", false, 200);
            AddControl(TxtComment);
        }

        public override void SetInputControlsArray()
        {
            InputControls = new PaneInputControl[] { TxtName, TxtDesc, NumLength, TxtComment };
        }

        public override void ReplaceInsertParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("NameInput", TxtName.GetInputValue().ToString());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());
            command.Parameters.AddWithValue("DescInput", TxtDesc.GetInputValue().ToString());
            command.Parameters.AddWithValue("LengthInput", NumLength.GetInputValue());

            // INSERT INTO `session` (`Name`,`Description`,`Comment`,`length`) VALUES (@NameInput, @DescInput, @CommentInput,@LengthInput);
        }

        public override void ReplaceEditParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("NameInput", TxtName.GetInputValue().ToString());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());
            command.Parameters.AddWithValue("DescInput", TxtDesc.GetInputValue());
            command.Parameters.AddWithValue("LengthInput", NumLength.GetInputValue());

            // UPDATE `session` SET `Name` = @NameInput,`Description` = @DescInput,`Comment` = @CommentInput, `length`=@LengthInput WHERE ID=@ID
        }

        public override void UpdateEditInputData(System.Windows.Forms.DataGridViewRow dataGridViewRow)
        {
            TxtName.SetNewInitValue(dataGridViewRow.Cells[PaneSession.ColName_Name].Value.ToString());
            TxtComment.SetNewInitValue(dataGridViewRow.Cells[PaneSession.ColName_Comment].Value.ToString());
            TxtDesc.SetNewInitValue(dataGridViewRow.Cells[PaneSession.ColName_Desc].Value.ToString());
            NumLength.SetNewInitValue(dataGridViewRow.Cells[PaneSession.ColName_Hour].Value);
        }
    }
}
