using Xuong_Nhua.Pane.Base;
using System.Data;
using MySql.Data.MySqlClient;

namespace Xuong_Nhua.Pane.Material
{
    public class PaneMaterial : PaneBase
    {
        public static string ColName_ID = "ID";
        public static string ColName_Name = "Name";
        public static string ColName_Desc = "Description";
        public static string ColName_TypeID = "TypeID";
        public static string ColName_Type = "TypeID";
        public static string ColName_Comment = "Comment";

        public override void SetPANEID()
        {
            PANEID = Program.PANE_MATERIAL_ID;
        }

        public override void SetColNames()
        {
            ColNames = new string[] { ColName_ID, ColName_Name, ColName_Desc, ColName_TypeID, ColName_Type, ColName_Comment };
        }

        public override void SetColVisibility()
        {
            Grid.Columns[ColName_ID].Visible = false;
            Grid.Columns[ColName_TypeID].Visible = false;
        }

        public override void SetPaneSum()
        {
            PaneSumChild = new PaneMaterialInfo();
        }

        public override void SetPaneSelect()
        {
            PaneSelectChild = new PaneMaterialSelect();
        }

        public override void SetPaneUpdate()
        {
            PaneUpdateChild = new PaneMaterialUpdate(PaneInfo);
        }

        public override MySqlCommand CreateViewQueryCommand(object[] args)
        {
            MySqlCommand command = new MySqlCommand(PaneInfo.ViewQuery);
            if (args.Length == 2)
            {
                command.Parameters.AddWithValue("NameInput", args[0]);
                command.Parameters.AddWithValue("TypeInput", args[1]);
            }
            return command;

            /*
            SELECT M.`ID`, M.`Name`, M.`Description`, M.`type`, T.`name`, M.`Comment` 
            FROM `ctynhua`.`material` as M, `mattype` as T 
            WHERE M.`Name` LIKE CONCAT('%',@NameInput,'%') AND M.`type` = COALESCE(@TypeInput, M.`type`) 
            AND M.`type` = T.`ID` 
            ORDER BY M.`Name`
            */
        }

        public override void PopulatePaneSummary(ref DataTable dt)
        {
            ((PaneMaterialInfo)PaneSumChild).SetInfo(dt.Rows.Count);
        }

        public override void FormatGrid()
        {
        }
    }
}
