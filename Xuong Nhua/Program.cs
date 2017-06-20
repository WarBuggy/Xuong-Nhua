using System;
using System.Windows.Forms;
using Xuong_Nhua.Pane.Partner;
using Xuong_Nhua.Pane.MatType;
using Xuong_Nhua.Pane.Product;
using Xuong_Nhua.Pane.Material;
using Xuong_Nhua.Pane.Formula;

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
        
        public static PanePartner PanePartner = null;
        public static PaneProduct PaneProduct = null;
        public static PaneMaterial PaneMaterial = null;
        public static PaneFormula PaneFormula = null;
        public static PaneMatType PaneMatType = null;


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
