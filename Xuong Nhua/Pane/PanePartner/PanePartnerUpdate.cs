using Xuong_Nhua.Pane.Base;
using MySql.Data.MySqlClient;
using Xuong_Nhua.InputControl;

namespace Xuong_Nhua.Pane.Partner
{
    class PanePartnerUpdate : PaneUpdate
    {
        private PaneInputTextbox TxtName = new PaneInputTextbox("Name");
        private PaneInputTextbox TxtComment = new PaneInputTextbox("Comment");
        private PaneInputTextbox TxtDesc = new PaneInputTextbox("Description");
        private PaneInputTextbox TxtPhone = new PaneInputTextbox("Phone");
        private PaneInputTextbox TxtEmail = new PaneInputTextbox("Email");

        public PanePartnerUpdate(PaneInfo info)
            : base(info)
        {
        }

        public override void PopulateControls()
        {
            TxtName.SetTextbox("");
            AddControl(TxtName);

            TxtDesc.SetTextbox("", false, 200);
            AddControl(TxtDesc);

            TxtPhone.SetTextbox("", false, 100);
            AddControl(TxtPhone);

            TxtEmail.SetTextbox("", false, 100);
            AddControl(TxtEmail);

            TxtComment.SetTextbox("", false, 200);
            AddControl(TxtComment);
        }

        public override void SetInputControlsArray()
        {
            InputControls = new PaneInputControl[] { TxtName, TxtPhone, TxtEmail, TxtComment, TxtDesc };
        }

        public override void ReplaceInsertParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("NameInput", TxtName.GetInputValue().ToString());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());
            command.Parameters.AddWithValue("DescInput", TxtDesc.GetInputValue().ToString());
            command.Parameters.AddWithValue("PhoneInput", TxtPhone.GetInputValue().ToString());
            command.Parameters.AddWithValue("EmailInput", TxtEmail.GetInputValue().ToString());

            // INSERT INTO `ctynhua`.`partner` (`Name`,`Description`,`phone`, `email`,`Comment`) VALUES (@NameInput, @DescInput, @PhoneInput, @EmailInput, @CommentInput);
        }

        public override void ReplaceEditParams(ref MySqlCommand command)
        {
            command.Parameters.AddWithValue("NameInput", TxtName.GetInputValue().ToString());
            command.Parameters.AddWithValue("CommentInput", TxtComment.GetInputValue().ToString());
            command.Parameters.AddWithValue("DescInput", TxtDesc.GetInputValue());
            command.Parameters.AddWithValue("EmailInput", TxtEmail.GetInputValue());
            command.Parameters.AddWithValue("PhoneInput", TxtPhone.GetInputValue());

            // UPDATE `ctynhua`.`partner` SET `Name` = @NameInput,`Description` = @DescInput,`Phone`=@PhoneInput, `Email`=@EmailInput,`Comment` = @CommentInput WHERE ID=@ID
        }

        public override void UpdateEditInputData(System.Windows.Forms.DataGridViewRow dataGridViewRow)
        {
            TxtName.SetNewInitValue(dataGridViewRow.Cells[PanePartner.ColName_Name].Value.ToString());
            TxtComment.SetNewInitValue(dataGridViewRow.Cells[PanePartner.ColName_Comment].Value.ToString());
            TxtDesc.SetNewInitValue(dataGridViewRow.Cells[PanePartner.ColName_Desc].Value.ToString());
            TxtEmail.SetNewInitValue(dataGridViewRow.Cells[PanePartner.ColName_Email].Value.ToString());
            TxtPhone.SetNewInitValue(dataGridViewRow.Cells[PanePartner.ColName_Phone].Value.ToString());
        }
    }
}
