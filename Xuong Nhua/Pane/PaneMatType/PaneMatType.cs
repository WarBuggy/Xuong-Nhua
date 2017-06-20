using Xuong_Nhua.Pane.Base;
using System.Data;
using MySql.Data.MySqlClient;

namespace Xuong_Nhua.Pane.MatType
{
    public class PaneMatType : PaneBase
    {
        public static string ColName_ID = "ID";
        public static string ColName_Name = "Name";
        public static string ColName_Desc = "Description";
        public static string ColName_Comment = "Comment";

        public override void SetPANEID()
        {
            PANEID = Program.PANE_MATTYPE_ID;
        }

        public override void SetColNames()
        {
            ColNames = new string[] { ColName_ID, ColName_Name, ColName_Desc, ColName_Comment };
        }

        public override void SetColVisibility()
        {
            Grid.Columns[ColName_ID].Visible = false;
        }

        public override void SetPaneSum()
        {
            PaneSumChild = new PaneMatTypeInfo();
        }

        public override void SetPaneSelect()
        {
            PaneSelectChild = new PaneMatTypeSelect();
        }

        public override void SetPaneUpdate()
        {
            PaneUpdateChild = new PaneMatTypeUpdate(PaneInfo);
        }

        public override MySqlCommand CreateViewQueryCommand(object[] args)
        {
            MySqlCommand command = new MySqlCommand(PaneInfo.ViewQuery);
            if (args.Length == 1)
            {
                command.Parameters.AddWithValue("NameInput", args[0]);
            }
            return command;

            // SELECT `ID`,`Name`,`Description`,`Comment` FROM `mattype` WHERE `Name` LIKE CONCAT('%',@NameInput,'%') ORDER BY `Name`
        }

        public override void PopulatePaneSummary(ref DataTable dt)
        {
            ((PaneMatTypeInfo)PaneSumChild).SetInfo(dt.Rows.Count);
        }

        public override void FormatGrid()
        {
        }
    }
}
