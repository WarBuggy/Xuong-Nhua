using System;
using System.Windows.Forms;
using Xuong_Nhua.Pane.Partner;
using Xuong_Nhua.Pane.Product;
//using Xuong_Nhua.Pane.PartnerClassification;
//using Xuong_Nhua.Pane.InventoryInput;
//using Xuong_Nhua.Pane.Sell;
//using Xuong_Nhua.Pane.InventoryOutput;
//using Xuong_Nhua.Pane.InventorySummary;
//using Xuong_Nhua.Pane.IncomeCategory;
//using Xuong_Nhua.Pane.Income;
//using Xuong_Nhua.Pane.ExpenditureCategory;
//using Xuong_Nhua.Pane.Expenditure;
////FACTORY SECTION
//using Xuong_Nhua.Pane.StyleVariation;
//using Xuong_Nhua.Pane.UnitPrice;
//using Xuong_Nhua.Pane.StaffList;

namespace Xuong_Nhua
{
    static class Program
    {
        public static FormMain FormMain = null;

        //public static int PANE_WAREHOUSE_ID = 1;
        //public static int PANE_CATEGORY_ID = 2;
        //public static int PANE_STYLE_ID = 3;
        //public static int PANE_PARTNER_CATEGORY_ID = 4;
        public static int PANE_PARTNER_ID = 5;
        public static int PANE_PRODUCT_ID = 6;

        //public static int PANE_PARTNER_CLASSIFICATION_ID = 6;
        //public static int PANE_INVENTORY_INPUT_ID = 7;
        //public static int PANE_SELL_ID = 8;
        //public static int PANE_INVENTORY_OUTPUT_ID = 9;
        //public static int PANE_INVENTORY_SUMMARY_ID = 10;
        //public static int PANE_INCOME_CATEGORY_ID = 11;
        //public static int PANE_INCOME_ID = 12;
        //public static int PANE_EXPENDITURE_CATEGORY_ID = 13;
        //public static int PANE_EXPENDITURE_ID = 14;
        //// FACTORY SECTION
        //public static int PANE_STYLE_VARIATION_ID = 200;
        //public static int PANE_UNIT_PRICE_ID = 201;
        //public static int PANE_STAFF_LIST = 202;

        //public static PaneWarehouse PaneWarehouse = null;
        //public static PaneCategory PaneCategory = null;
        //public static PaneStyle PaneStyle = null;
        //public static PanePartnerCategory PanePartnerCategory = null;
        public static PanePartner PanePartner = null;
        public static PaneProduct PaneProduct = null;
        //public static PanePartnerClassification PanePartnerClassification = null;
        //public static PaneInventoryInput PaneInventoryInput = null;
        //public static PaneSell PaneSell = null;
        //public static PaneInventoryOutput PaneInventoryOutput = null;
        //public static PaneInventorySummary PaneInventorySummary = null;
        //public static PaneIncomeCategory PaneIncomeCategory = null;
        //public static PaneIncome PaneIncome = null;
        //public static PaneExpenditureCategory PaneExpenditureCategory = null;
        //public static PaneExpenditure PaneExpenditure = null;
        ////FACTORY SECTION
        //public static PaneStyleVariation PaneStyleVariation = null;
        //public static PaneUnitPrice PaneUnitPrice = null;
        //public static PaneStaffList PaneStaffList = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormMain = new FormMain();
            Application.Run(FormMain);
        }
    }
}
