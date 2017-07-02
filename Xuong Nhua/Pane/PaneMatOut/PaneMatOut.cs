using Xuong_Nhua.Pane.Base;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Windows.Forms;
using System;

namespace Xuong_Nhua.Pane.MatOut
{
    public class PaneMatOut : PaneBase
    {
        public static string ColName_ID = "ID";
        public static string ColName_OutDate = "Out date";
        public static string ColName_InID = "InID";
        public static string ColName_Lot = "Lot";
        public static string ColName_MaterialID = "MaterialID";
        public static string ColName_Material = "Material";
        public static string ColName_Quantity = "Quantity(g)";
        public static string ColName_ProductionID = "ProductionID";
        public static string ColName_Production = "Production";
        public static string ColName_ProductID = "ProductID";
        public static string ColName_Product = "Product";
        public static string ColName_Comment = "Comment";

        public override void SetPANEID()
        {
            PANEID = Program.PANE_MATOUT_ID;
        }

        public override void SetColNames()
        {
            ColNames = new string[] { ColName_ID, ColName_OutDate, ColName_InID, ColName_Lot, ColName_MaterialID, ColName_Material, ColName_Quantity, ColName_ProductionID, ColName_Production, ColName_ProductID, ColName_Product, ColName_Comment };
        }

        public override void SetColVisibility()
        {
            Grid.Columns[ColName_ID].Visible = false;
            Grid.Columns[ColName_MaterialID].Visible = false;
            Grid.Columns[ColName_InID].Visible = false;
            Grid.Columns[ColName_ProductionID].Visible = false;
            Grid.Columns[ColName_ProductID].Visible = false;
        }

        public override void SetPaneSum()
        {
            PaneSumChild = new PaneMatOutInfo();
        }

        public override void SetPaneSelect()
        {
            PaneSelectChild = new PaneMatOutSelect();
        }

        public override void SetPaneUpdate()
        {
            PaneUpdateChild = new PaneMatOutUpdate(PaneInfo);
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
                command.Parameters.AddWithValue("ProductInput", args[4]);
            }
            return command;

            /*
            SELECT O.id, DATE_FORMAT(O.`date`,'%d-%m-%y') as `outdate`, O.inid, I.lot, M.id as `material`, M.name, 
             O.quantity, O.production, CONCAT(DATE_FORMAT(P.`date`,'%d-%m-%y'), '; ', S.name) as `productiondate`, 
             P.product, R.name, O.comment 
             FROM matout O, matin I, production P, product R, material M, session S
             WHERE I.id=O.inid AND I.material=M.id 
             AND P.id=O.production AND P.product=R.id AND S.id=P.session
             AND M.`id`=COALESCE(@MaterialInput, M.`id`)
             AND I.`lot` LIKE CONCAT('%',@LotInput,'%') 
             AND O.`DATE`>=@DateFrom AND O.`DATE`<=@DateUntil
             AND R.`id`=COALESCE(@ProductInput, R.`id`) 
             GROUP BY O.id
            */
        }

        public override void PopulatePaneSummary(ref DataTable dt)
        {
            DataView View = new DataView(dt);

            int productCount = View.ToTable(true, "product").Rows.Count;
            int materialCount = View.ToTable(true, "material").Rows.Count;
            int ProductionCount = View.ToTable(true, "production").Rows.Count;
            int lotCount = View.ToTable(true, "lot").Rows.Count;

            int totalQuantity = Grid.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[ColName_Quantity].Value));
            
            ((PaneMatOutInfo)PaneSumChild).SetInfo(dt.Rows.Count, lotCount, materialCount, totalQuantity, ProductionCount, productCount);
        }

        public override void FormatGrid()
        {
            Grid.Columns[ColName_Quantity].DefaultCellStyle.ForeColor = System.Drawing.Color.PaleVioletRed;
            Grid.Columns[ColName_Quantity].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid.Columns[ColName_Quantity].DefaultCellStyle.Format = "N0";

            Grid.Columns[ColName_Product].DefaultCellStyle.ForeColor = System.Drawing.Color.ForestGreen;

            Grid.Columns[ColName_Material].DefaultCellStyle.ForeColor = System.Drawing.Color.DarkCyan;

            Grid.Columns[ColName_OutDate].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void SetButtonsVisibility()
        {
            SHOW_INSERT_BUTTON = false;
            SHOW_EDIT_BUTTON = false;
        }

        public override void SetFirstMode()
        {
            MODE_TO_SHOW_FIRST = -1;
        }
    }
}
