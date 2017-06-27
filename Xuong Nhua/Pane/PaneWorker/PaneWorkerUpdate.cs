using Xuong_Nhua.Pane.Base;
using MySql.Data.MySqlClient;
using Xuong_Nhua.InputControl;
using Xuong_Nhua.Theme;

namespace Xuong_Nhua.Pane.Worker
{
    class PaneWorkerUpdate : PaneUpdate
    {
        private PaneInputTextbox TxtSirName = new PaneInputTextbox("Sir Name");
        private PaneInputTextbox TxtMiddleName = new PaneInputTextbox("Middle Name");
        private PaneInputTextbox TxtGivenName = new PaneInputTextbox("Given Name");
        private PaneInputTextbox TxtComment = new PaneInputTextbox("Comment");
        private PaneInputNumberbox NumSalary = new PaneInputNumberbox("Salary");
        private PaneInputTextbox TxtContact = new PaneInputTextbox("Contact");

        public PaneWorkerUpdate(PaneInfo info)
            : base(info)
        {
        }

        public override void PopulateControls()
        {
            TxtSirName.SetTextbox("", true, 70);
            AddControl(TxtSirName);

            TxtMiddleName.SetTextbox("", true, 70);
            AddControl(TxtMiddleName);

            TxtGivenName.SetTextbox("", true, 70);
            AddControl(TxtGivenName);

            TxtContact.SetTextbox("", false, 200);
            AddControl(TxtContact);

            NumSalary.SetNumberbox(1);
            AddControl(NumSalary);
            NumSalary.ResetValue();

            TxtComment.SetTextbox("", false, 200);
            AddControl(TxtComment);
        }

        public override void SetInputControlsArray()
        {
            InputControls = new PaneInputControl[] { TxtSirName, TxtMiddleName, TxtGivenName, TxtContact, NumSalary, TxtComment };
        }

        public override void ReplaceInsertParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("SirNameInput", TxtSirName.GetInputValue().ToString());
            command.Parameters.AddWithValue("MiddleNameInput", TxtMiddleName.GetInputValue().ToString());
            command.Parameters.AddWithValue("GivenNameInput", TxtGivenName.GetInputValue().ToString());
            command.Parameters.AddWithValue("ContactInput", TxtContact.GetInputValue().ToString());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());
            command.Parameters.AddWithValue("SalaryInput", NumSalary.GetInputValue());

            //INSERT INTO `worker` (`sirname`,`middlename`,`givenname`,`contact`,`salary`,`comment`) VALUES (@SirNameInput, @MiddleNameInput, @GivenNameInput, @ContactInput, @SalaryInput, @CommentInput)
        }

        public override void ReplaceEditParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("SirNameInput", TxtSirName.GetInputValue().ToString());
            command.Parameters.AddWithValue("MiddleNameInput", TxtMiddleName.GetInputValue().ToString());
            command.Parameters.AddWithValue("GivenNameInput", TxtGivenName.GetInputValue().ToString());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());
            command.Parameters.AddWithValue("ContactInput", TxtContact.GetInputValue());
            command.Parameters.AddWithValue("SalaryInput", NumSalary.GetInputValue());

            // UPDATE `worker` SET `sirname` = @SirNameInput,`middlename`=@MiddleNameInput,`givenname`=@GivenNameInput,`contact`=@ContactInput,`salary`= @SalaryInput,`comment`=@CommentInput WHERE `id`=@ID;
        }

        public override void UpdateEditInputData(System.Windows.Forms.DataGridViewRow dataGridViewRow)
        {
            TxtSirName.SetNewInitValue(dataGridViewRow.Cells[PaneWorker.ColName_SirName].Value.ToString());
            TxtMiddleName.SetNewInitValue(dataGridViewRow.Cells[PaneWorker.ColName_MidName].Value.ToString());
            TxtGivenName.SetNewInitValue(dataGridViewRow.Cells[PaneWorker.ColName_GivenName].Value.ToString());
            TxtComment.SetNewInitValue(dataGridViewRow.Cells[PaneWorker.ColName_Comment].Value.ToString());
            TxtContact.SetNewInitValue(dataGridViewRow.Cells[PaneWorker.ColName_Contact].Value.ToString());
            NumSalary.SetNewInitValue(dataGridViewRow.Cells[PaneWorker.ColName_Salary].Value);
        }
    }
}
