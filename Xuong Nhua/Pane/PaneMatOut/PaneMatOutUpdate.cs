using Xuong_Nhua.Pane.Base;
using MySql.Data.MySqlClient;

namespace Xuong_Nhua.Pane.MatOut
{
    class PaneMatOutUpdate : PaneUpdate
    {
        public PaneMatOutUpdate(PaneInfo info)
             : base(info)
        {
        }

        public override void PopulateControls()
        {
        }

        public override void SetInputControlsArray()
        {
        }

        public override void ReplaceInsertParams(ref MySqlCommand command)
        {
        }

        public override void ReplaceEditParams(ref MySqlCommand command)
        {
        }

        public override void UpdateEditInputData(System.Windows.Forms.DataGridViewRow dataGridViewRow)
        {
        }
    }
}
