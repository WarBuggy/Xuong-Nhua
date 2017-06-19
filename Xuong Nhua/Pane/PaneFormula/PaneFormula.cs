using Xuong_Nhua.Pane.Base;
using System.Data;
using MySql.Data.MySqlClient;

namespace Xuong_Nhua.Pane.Formula
{
    public class PaneFormula : PaneBase
    {
        public static string ColName_ID = "ID";
        public static string ColName_ProductID = "Product ID";
        public static string ColName_ProductName = "Product";
        public static string ColName_MaterialID = "Material ID";
        public static string ColName_MaterialName = "Material";
        public static string ColName_Quantity = "Quantity";
        public static string ColName_Comment = "Comment";

        public override void SetPANEID()
        {
            PANEID = Program.PANE_FORMULA_ID;
        }

        public override void SetColNames()
        {
            ColNames = new string[] { ColName_ID, ColName_ProductID, ColName_ProductName, ColName_MaterialID, ColName_MaterialName, ColName_Quantity, ColName_Comment };
        }

        public override void SetColVisibility()
        {
            Grid.Columns[ColName_ID].Visible = false;
            Grid.Columns[ColName_ProductID].Visible = false;
            Grid.Columns[ColName_MaterialID].Visible = false;
        }

        public override void SetPaneSum()
        {
            PaneSumChild = new PaneFormulaInfo();
        }

        public override void SetPaneSelect()
        {
            PaneSelectChild = new PaneFormulaSelect();
        }

        public override void SetPaneUpdate()
        {
            PaneUpdateChild = new PaneFormulaUpdate(PaneInfo);
        }

        public override MySqlCommand CreateViewQueryCommand(object[] args)
        {
            MySqlCommand command = new MySqlCommand(PaneInfo.ViewQuery);
            if (args.Length == 2)
            {
                command.Parameters.AddWithValue("ProductInput", args[0]);
                command.Parameters.AddWithValue("MaterialInput", args[1]);
            }
            return command;

            /*
            SELECT F.ID, F.product, P.name, F.material, M.name, F.quantity, F.Comment 
            FROM formula as F,material as M, product as P 
            WHERE F.material = M.ID AND F.product = P.ID 
            AND F.material = COALESCE(@MaterialInput, F.material) 
            AND F.product = COALESCE(@ProductInput, F.product) ORDER BY P.Name; 
            */
        }

        public override void PopulatePaneSummary(ref DataTable dt)
        {
            DataView View = new DataView(dt);
            int productCount = View.ToTable(true, "product").Rows.Count;
            int materialCount = View.ToTable(true, "material").Rows.Count;
            ((PaneFormulaInfo)PaneSumChild).SetInfo(productCount, materialCount);
        }

        public override void FormatGrid()
        {
        }
    }
}
