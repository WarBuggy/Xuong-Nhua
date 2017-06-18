using System;
using System.Windows.Forms;
using Xuong_Nhua.Pane.Partner;
using Xuong_Nhua.Pane.Product;
using Xuong_Nhua.Pane.Material;

namespace Xuong_Nhua
{
    static class Program
    {
        public static FormMain FormMain = null;

        public static int PANE_PARTNER_ID = 5;
        public static int PANE_PRODUCT_ID = 6;
        public static int PANE_MATERIAL_ID = 7;
        public static int PANE_FORMULA_ID = 8;

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
        public static PaneMaterial PaneMaterial = null;
        public static PaneFormula PaneFormula = null;

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
