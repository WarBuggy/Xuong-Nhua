using System;
using System.Windows.Forms;
using Xuong_Nhua.Pane.Partner;
using Xuong_Nhua.Pane.MatType;
using Xuong_Nhua.Pane.Product;
using Xuong_Nhua.Pane.Material;
using Xuong_Nhua.Pane.Formula;
using Xuong_Nhua.Pane.MatIn;
using Xuong_Nhua.Pane.Session;
using Xuong_Nhua.Pane.Worker;
using Xuong_Nhua.Pane.Production;
using Xuong_Nhua.Pane.MatInventory;
using Xuong_Nhua.Pane.MatOut;

namespace Xuong_Nhua
{
    static class Program
    {
        public static FormMain FormMain = null;

        public static int PANE_PARTNER_ID = 5;
        public static int PANE_PRODUCT_ID = 6;
        public static int PANE_MATERIAL_ID = 7;
        public static int PANE_FORMULA_ID = 8;
        public static int PANE_MATTYPE_ID = 9;
        public static int PANE_MATIN_ID = 10;
        public static int PANE_SESSION_ID = 11;
        public static int PANE_WORKER_ID = 12;
        public static int PANE_PRODUCTION_ID = 13;
        public static int PANE_MATINVENTORY_ID = 14;
        public static int PANE_MATOUT_ID = 15;

        public static PanePartner PanePartner = null;
        public static PaneProduct PaneProduct = null;
        public static PaneMaterial PaneMaterial = null;
        public static PaneFormula PaneFormula = null;
        public static PaneMatType PaneMatType = null;
        public static PaneMatIn PaneMatIn = null;
        public static PaneSession PaneSession = null;
        public static PaneWorker PaneWorker = null;
        public static PaneProduction PaneProduction = null;
        public static PaneMatInventory PaneMatInventory = null;
        public static PaneMatOut PaneMatOut = null;

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
