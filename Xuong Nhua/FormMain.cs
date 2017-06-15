using System;
using System.Windows.Forms;
using Xuong_Nhua.Pane.Base;
using Xuong_Nhua.Pane.Partner;

namespace Xuong_Nhua
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public void ClearPaneMain()
        {
            PaneMain.Controls.Clear();
        }

        public void DisplayInPaneMain(PaneBase pane)
        {
            ClearPaneMain();
            PaneMain.Controls.Add(pane);
        }

        private void partnersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.PanePartner == null)
            {
                Program.PanePartner = new PanePartner();
                Program.PanePartner.Dock = DockStyle.Fill;
                Program.PanePartner.LoadPane();
            }
            DisplayInPaneMain(Program.PanePartner);
        }

        //private void warehouseToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (Program.PaneWarehouse == null)
        //    {
        //        Program.PaneWarehouse = new PaneWarehouse();
        //        Program.PaneWarehouse.Dock = DockStyle.Fill;
        //        Program.PaneWarehouse.LoadPane();
        //    }
        //    DisplayInPaneMain(Program.PaneWarehouse);
        //}
    }
}
