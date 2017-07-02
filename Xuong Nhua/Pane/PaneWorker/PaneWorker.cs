using Xuong_Nhua.Pane.Base;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Windows.Forms;
using System;

namespace Xuong_Nhua.Pane.Worker
{
    public class PaneWorker : PaneBase
    {
        public static string ColName_ID = "ID";
        public static string ColName_SirName = "Sir Name";
        public static string ColName_MidName = "Middle Name";
        public static string ColName_GivenName = "Given Name";
        public static string ColName_Contact = "Contact";
        public static string ColName_Salary = "Salary";
        public static string ColName_Comment = "Comment";

        public override void SetPANEID()
        {
            PANEID = Program.PANE_WORKER_ID;
        }

        public override void SetColNames()
        {
            ColNames = new string[] { ColName_ID, ColName_SirName, ColName_MidName, ColName_GivenName, ColName_Contact, ColName_Salary, ColName_Comment };
        }

        public override void SetColVisibility()
        {
            Grid.Columns[ColName_ID].Visible = false;
        }

        public override void SetPaneSum()
        {
            PaneSumChild = new PaneWorkerInfo();
        }

        public override void SetPaneSelect()
        {
            PaneSelectChild = new PaneWorkerSelect();
        }

        public override void SetPaneUpdate()
        {
            PaneUpdateChild = new PaneWorkerUpdate(PaneInfo);
        }

        public override MySqlCommand CreateViewQueryCommand(object[] args)
        {
            MySqlCommand command = new MySqlCommand(PaneInfo.ViewQuery);
            if (args.Length == 2)
            {
                command.Parameters.AddWithValue("SirNameInput", args[0]);
                command.Parameters.AddWithValue("GivenNameInput", args[1]);
            }
            return command;

            /*
            SELECT id, sirname, middlename, givenname, contact, salary, comment from worker where sirname LIKE CONCAT('%',@SirNameInput,'%') AND  givenname LIKE CONCAT('%',@GivenNameInput,'%') ORDER BY `givenname`
            */
        }

        public override void PopulatePaneSummary(ref DataTable dt)
        {
            int totalSalary = Grid.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[ColName_Salary].Value));
            ((PaneWorkerInfo)PaneSumChild).SetInfo(dt.Rows.Count, totalSalary);
        }

        public override void FormatGrid()
        {
            Grid.Columns[ColName_Salary].DefaultCellStyle.ForeColor = System.Drawing.Color.DarkMagenta;
            Grid.Columns[ColName_Salary].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid.Columns[ColName_Salary].DefaultCellStyle.Format = "N0";
        }
    }
}
