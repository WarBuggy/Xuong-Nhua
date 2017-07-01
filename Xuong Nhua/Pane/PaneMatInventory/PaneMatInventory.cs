﻿using Xuong_Nhua.Pane.Base;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Windows.Forms;
using System;

namespace Xuong_Nhua.Pane.MatInventory
{
    public class PaneMatInventory : PaneBase
    {
        public static string ColName_ID = "ID";
        public static string ColName_Date = "Date";
        public static string ColName_Lot = "Lot";
        public static string ColName_MaterialID = "Material ID";
        public static string ColName_MaterialName = "Material";
        public static string ColName_Quantity = "Quantity";
        public static string ColName_Output = "Output";
        public static string ColName_Remaining = "Remaining";
        public static string ColName_Price = "Price";
        public static string ColName_Comment = "Comment";

        public override void SetPANEID()
        {
            PANEID = Program.PANE_MATINVENTORY_ID;
        }

        public override void SetColNames()
        {
            ColNames = new string[] { ColName_ID, ColName_Date, ColName_Lot, ColName_MaterialID, ColName_MaterialName, ColName_Quantity, ColName_Output, ColName_Remaining, ColName_Price, ColName_Comment };
        }

        public override void SetColVisibility()
        {
            Grid.Columns[ColName_ID].Visible = false;
            Grid.Columns[ColName_MaterialID].Visible = false;
        }

        public override void SetPaneSum()
        {
            PaneSumChild = new PaneMatInventoryInfo();
        }

        public override void SetPaneSelect()
        {
            PaneSelectChild = new PaneMatInventorySelect();
        }

        public override void SetPaneUpdate()
        {
            PaneUpdateChild = new PaneMatInventoryUpdate(PaneInfo);
        }

        public override MySqlCommand CreateViewQueryCommand(object[] args)
        {
            MySqlCommand command = new MySqlCommand(PaneInfo.ViewQuery);
            if (args.Length == 4)
            {
                command.Parameters.AddWithValue("DateFrom", args[0]);
                command.Parameters.AddWithValue("DateUntil", args[1]);
                command.Parameters.AddWithValue("LotInput", args[2]);
                command.Parameters.AddWithValue("MaterialInput", args[3]);
            }
            return command;

            /*
           SELECT * FROM (
            */
        }

        public override void PopulatePaneSummary(ref DataTable dt)
        {
            DataView View = new DataView(dt);
            int materialCount = View.ToTable(true, "material").Rows.Count;

            int totalQuantity = Grid.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[ColName_Quantity].Value));
            int totalOutput = Grid.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[ColName_Output].Value));
            int totalRemaining = Grid.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[ColName_Remaining].Value));
            int totalPrice = Grid.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[ColName_Price].Value));
            ((PaneMatInventoryInfo)PaneSumChild).SetInfo(dt.Rows.Count, materialCount, totalQuantity, totalOutput, totalRemaining, totalPrice / dt.Rows.Count);
        }

        public override void FormatGrid()
        {
            Grid.Columns[ColName_Date].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Grid.Columns[ColName_Quantity].DefaultCellStyle.ForeColor = System.Drawing.Color.PaleVioletRed;
            Grid.Columns[ColName_Quantity].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid.Columns[ColName_Quantity].DefaultCellStyle.Format = "N0";

            Grid.Columns[ColName_Price].DefaultCellStyle.ForeColor = System.Drawing.Color.DarkBlue;
            Grid.Columns[ColName_Price].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid.Columns[ColName_Price].DefaultCellStyle.Format = "N0";

            Grid.Columns[ColName_Output].DefaultCellStyle.ForeColor = System.Drawing.Color.DarkViolet;
            Grid.Columns[ColName_Output].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid.Columns[ColName_Output].DefaultCellStyle.Format = "N0";

            Grid.Columns[ColName_Remaining].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
            Grid.Columns[ColName_Remaining].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid.Columns[ColName_Remaining].DefaultCellStyle.Format = "N0";
        }

        public override void SetButtonsVisibility()
        {
            SHOW_INSERT_BUTTON = false;
            SHOW_DELETE_BUTTON = false;
        }

        public override void SetFirstMode()
        {
            MODE_TO_SHOW_FIRST = PaneUpdate.MODE_EDIT;
            CURRENT_MODE = PaneUpdate.MODE_EDIT;
        }
    }
}