using Xuong_Nhua.Pane.Base;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Windows.Forms;
using System;

namespace Xuong_Nhua.Pane.MatIn
{
    public class PaneMatIn : PaneBase
    {
        public static string ColName_ID = "ID";
        public static string ColName_Date = "Date";
        public static string ColName_Lot = "Lot";
        public static string ColName_MaterialID = "MaterialID";
        public static string ColName_Material = "Material";
        public static string ColName_Quantity = "Quantity(g)";
        public static string ColName_Price = "Price(/1000g)";
        public static string ColName_Total = "Total(VND)";
        public static string ColName_PartnerID = "PartnerID";
        public static string ColName_Partner = "Partner";
        public static string ColName_Comment = "Comment";

        public override void SetPANEID()
        {
            PANEID = Program.PANE_MATIN_ID;
        }

        public override void SetColNames()
        {
            ColNames = new string[] { ColName_ID, ColName_Date, ColName_Lot, ColName_MaterialID, ColName_Material,
                ColName_Quantity, ColName_Price, ColName_Total, ColName_PartnerID, ColName_Partner, ColName_Comment };
        }

        public override void SetColVisibility()
        {
            Grid.Columns[ColName_ID].Visible = false;
            Grid.Columns[ColName_MaterialID].Visible = false;
            Grid.Columns[ColName_PartnerID].Visible = false;
        }

        public override void SetPaneSum()
        {
            PaneSumChild = new PaneMatInInfo();
        }

        public override void SetPaneSelect()
        {
            PaneSelectChild = new PaneMatInSelect();
        }

        public override void SetPaneUpdate()
        {
            PaneUpdateChild = new PaneMatInUpdate(PaneInfo);
        }

        public override MySqlCommand CreateViewQueryCommand(object[] args)
        {
            MySqlCommand command = new MySqlCommand(PaneInfo.ViewQuery);
            if (args.Length == 5)
            {
                command.Parameters.AddWithValue("DateFrom", args[0]);
                command.Parameters.AddWithValue("DateUntil", args[1]);
                command.Parameters.AddWithValue("LotInput", args[2]);
                command.Parameters.AddWithValue("MaterialInput", args[3]);
                command.Parameters.AddWithValue("PartnerInput", args[4]);
            }
            return command;

            /*
            SELECT I.`ID`, DATE_FORMAT(I.`Date`,'%d-%m-%y'), I.`lot`, I.`material`, M.`name`, I.`quantity`, I.`price`, 
                `price`*`quantity`/1000 as total, I.`partner`, P.`name`, I.`Comment` 
                FROM `matin` as I, `material` as M, `partner` as P 
                WHERE I.`material` = M.`ID` AND I.`partner` = P.`ID` 
                AND I.`material` =  COALESCE(@MaterialInput, I.material)
                AND I.`partner` = COALESCE(@PartnerInput, I.partner)
                AND I.`lot` LIKE CONCAT('%',@LotInput,'%') 
                AND I.`DATE` >= @DateFrom AND I.`DATE` <= @DateUntil
                ORDER BY I.`date`
            */
        }

        public override void PopulatePaneSummary(ref DataTable dt)
        {
            DataView View = new DataView(dt);

            int partnerCount = View.ToTable(true, "partner").Rows.Count;
            int materialCount = View.ToTable(true, "material").Rows.Count;

            int totalQuantity = Grid.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[PaneMatIn.ColName_Quantity].Value));
            int totalPrice = Grid.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[PaneMatIn.ColName_Price].Value));
            int sum = Grid.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[PaneMatIn.ColName_Total].Value));

            ((PaneMatInInfo)PaneSumChild).SetInfo(dt.Rows.Count, materialCount, totalQuantity, totalPrice, sum, partnerCount);
        }

        public override void FormatGrid()
        {
            Grid.Columns[ColName_Quantity].DefaultCellStyle.ForeColor = System.Drawing.Color.PaleVioletRed;
            Grid.Columns[ColName_Quantity].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid.Columns[ColName_Quantity].DefaultCellStyle.Format = "N0";

            Grid.Columns[ColName_Price].DefaultCellStyle.ForeColor = System.Drawing.Color.DarkBlue;
            Grid.Columns[ColName_Price].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid.Columns[ColName_Price].DefaultCellStyle.Format = "N0";

            Grid.Columns[ColName_Total].DefaultCellStyle.ForeColor = System.Drawing.Color.Goldenrod;
            Grid.Columns[ColName_Total].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid.Columns[ColName_Total].DefaultCellStyle.Format = "N0";

            Grid.Columns[ColName_Partner].DefaultCellStyle.ForeColor = System.Drawing.Color.Orange;

            Grid.Columns[ColName_Date].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
