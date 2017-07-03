using Xuong_Nhua.Pane.Base;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Windows.Forms;
using System;

namespace Xuong_Nhua.Pane.Production
{
    public class PaneProduction : PaneBase
    {
        public static string ColName_ID = "ID";
        public static string ColName_Date = "Date";
        public static string ColName_SessionID = "SessionID";
        public static string ColName_Session = "Session";
        public static string ColName_WorkerID = "WorkerID";
        public static string ColName_Worker = "Worker";
        public static string ColName_ProductID = "ProductID";
        public static string ColName_Product = "Product";
        public static string ColName_Quantity = "Quantity(g)";
        public static string ColName_Comment = "Comment";

        /*
        SELECT P.`ID`, DATE_FORMAT(P.`Date`,'%d-%m-%y'), P.`session`, S.`name`, P.`worker`,
           CONCAT (W.`sirname`, ' ', W.`middlename`, ' ', W.`givenname`) as `fullname`,
           P.`product`, D.`Name`, P.`quantity`, P.`Comment`
           FROM `production` as P, `worker` as W, `product` as D, `session` as S
           WHERE P.`product`=D.`ID` AND P.`worker`=W.`id` AND P.`session`=S.`id`
           AND P.`worker`=COALESCE(@WorkerInput, P.`worker`)
           AND P.`product`=COALESCE(@ProductInput, P.`product`)
           AND P.`DATE` >= @DateFrom AND P.`DATE` <= @DateUntil
           ORDER BY P.`date`
        */

        public override void SetPANEID()
        {
            PANEID = Program.PANE_PRODUCTION_ID;
        }

        public override void SetColNames()
        {
            ColNames = new string[] { ColName_ID, ColName_Date, ColName_SessionID, ColName_Session, ColName_WorkerID, ColName_Worker, ColName_ProductID, ColName_Product, ColName_Quantity, ColName_Comment };
        }

        public override void SetColVisibility()
        {
            Grid.Columns[ColName_ID].Visible = false;
            Grid.Columns[ColName_SessionID].Visible = false;
            Grid.Columns[ColName_WorkerID].Visible = false;
            Grid.Columns[ColName_ProductID].Visible = false;
        }

        public override void SetPaneSum()
        {
            PaneSumChild = new PaneProductionInfo();
        }

        public override void SetPaneSelect()
        {
            PaneSelectChild = new PaneProductionSelect();
        }

        public override void SetPaneUpdate()
        {
            PaneUpdateChild = new PaneProductionUpdate(PaneInfo);
        }

        public override MySqlCommand CreateViewQueryCommand(object[] args)
        {
            MySqlCommand command = new MySqlCommand(PaneInfo.ViewQuery);
            if (args.Length == 4)
            {
                command.Parameters.AddWithValue("DateFrom", args[0]);
                command.Parameters.AddWithValue("DateUntil", args[1]);
                command.Parameters.AddWithValue("WorkerInput", args[2]);
                command.Parameters.AddWithValue("ProductInput", args[3]);
            }
            return command;

            /*
            SELECT P.`ID`, DATE_FORMAT(P.`Date`,'%d-%m-%y'), P.`session`, S.`name`, P.`worker`,
              CONCAT (W.`sirname`, ' ', W.`middlename`, ' ', W.`givenname`),
              P.`product`, D.`Name`, P.`quantity`, P.`Comment`
              FROM `production` as P, `worker` as W, `product` as D, `session` as S
              WHERE P.`product`=D.`ID` AND P.`worker`=W.`id` AND P.`session`=S.`id`
              AND P.`worker`=COALESCE(@WorkerInput, P.`worker`)
              AND P.`product`=COALESCE(@ProductInput, P.`product`)
              AND P.`DATE` >= @DateFrom AND P.`DATE` <= @DateUntil
              ORDER BY P.`date`
            */
        }

        public override void PopulatePaneSummary(ref DataTable dt)
        {
            DataView View = new DataView(dt);

            int productCount = View.ToTable(true, "product").Rows.Count;
            int workerCount = View.ToTable(true, "worker").Rows.Count;

            int totalQuantity = Grid.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[ColName_Quantity].Value));
            if (dt.Rows.Count > 0)
            {
                totalQuantity = totalQuantity / 1000;
            }
            
            ((PaneProductionInfo)PaneSumChild).SetInfo(dt.Rows.Count, workerCount, productCount, totalQuantity);
        }

        public override void FormatGrid()
        {
            Grid.Columns[ColName_Quantity].DefaultCellStyle.ForeColor = System.Drawing.Color.PaleVioletRed;
            Grid.Columns[ColName_Quantity].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid.Columns[ColName_Quantity].DefaultCellStyle.Format = "N0";

            Grid.Columns[ColName_Worker].DefaultCellStyle.ForeColor = System.Drawing.Color.DarkGoldenrod;

            Grid.Columns[ColName_Product].DefaultCellStyle.ForeColor = System.Drawing.Color.ForestGreen;

            Grid.Columns[ColName_Date].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
