using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Xuong_Nhua
{
    public class PaneInfo
    {
        private int PANEID = 0;

        public string Title { get; set; }
        public string ViewQuery { get; set; }
        public string InsertQuery { get; set; }
        public string UpdateQuery { get; set; }
        public string DeleteQuery { get; set; }
        public string LocalName { get; set; }

        public PaneInfo(int PaneID)
        {
            PANEID = PaneID;
            CheckValidPaneID();
        }

        private bool CheckValidPaneID()
        {
            if (PANEID <= 0)
            {
                Share.showErrorMessage("Invalid panel ID: " + PANEID + ".");
                PANEID = 0;
                return false;
            }

            string sql = "SELECT PaneID, Title, ViewQuery, InsertQuery,";
            sql = sql + "UpdateQuery, DeleteQuery, LocalName, Comment FROM PaneInfo WHERE PaneID = @PaneID";
            MySqlCommand command = new MySqlCommand(sql);
            command.Parameters.Add(new MySqlParameter("PaneID", PANEID));
            DataTable DT = Share.MySql.GetDataTable(command);
            if (DT.Rows.Count != 1)
            {
                Share.showErrorMessage("Such panel ID does not exist or is not unique: " + PANEID + ".");
                PANEID = 0;
                return false;
            }
            Title = (DT.Rows[0]["Title"].ToString());
            ViewQuery = (DT.Rows[0]["ViewQuery"].ToString());
            InsertQuery = (DT.Rows[0]["InsertQuery"].ToString());
            UpdateQuery = (DT.Rows[0]["UpdateQuery"].ToString());
            DeleteQuery = (DT.Rows[0]["DeleteQuery"].ToString());
            LocalName = (DT.Rows[0]["LocalName"].ToString());
            return true;
        }

        public bool IsValid()
        {
            if (PANEID <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
