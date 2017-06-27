using System;
using System.Windows.Forms;
using Xuong_Nhua.Pane.Base;
using Xuong_Nhua.Pane.MatType;
using Xuong_Nhua.Pane.Material;
using Xuong_Nhua.Pane.Partner;
using Xuong_Nhua.Pane.Product;
using Xuong_Nhua.Pane.Formula;
using Xuong_Nhua.Pane.MatIn;
using Xuong_Nhua.Pane.Session;
using Xuong_Nhua.Pane.Worker;

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

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.PaneProduct == null)
            {
                Program.PaneProduct = new PaneProduct();
                Program.PaneProduct.Dock = DockStyle.Fill;
                Program.PaneProduct.LoadPane();
            }
            DisplayInPaneMain(Program.PaneProduct);
        }

        private void formulasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.PaneFormula == null)
            {
                Program.PaneFormula = new PaneFormula();
                Program.PaneFormula.Dock = DockStyle.Fill;
                Program.PaneFormula.LoadPane();
            }
            DisplayInPaneMain(Program.PaneFormula);
        }

        private void typesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.PaneMatType == null)
            {
                Program.PaneMatType = new PaneMatType();
                Program.PaneMatType.Dock = DockStyle.Fill;
                Program.PaneMatType.LoadPane();
            }
            DisplayInPaneMain(Program.PaneMatType);
        }

        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Program.PaneMaterial == null)
            {
                Program.PaneMaterial = new PaneMaterial();
                Program.PaneMaterial.Dock = DockStyle.Fill;
                Program.PaneMaterial.LoadPane();
            }
            DisplayInPaneMain(Program.PaneMaterial);
        }

        private void inputToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Program.PaneMatIn == null)
            {
                Program.PaneMatIn = new PaneMatIn();
                Program.PaneMatIn.Dock = DockStyle.Fill;
                Program.PaneMatIn.LoadPane();
            }
            DisplayInPaneMain(Program.PaneMatIn);
        }

        private void sessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.PaneSession == null)
            {
                Program.PaneSession = new PaneSession();
                Program.PaneSession.Dock = DockStyle.Fill;
                Program.PaneSession.LoadPane();
            }
            DisplayInPaneMain(Program.PaneSession);
        }

        private void workersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.PaneWorker == null)
            {
                Program.PaneWorker = new PaneWorker();
                Program.PaneWorker.Dock = DockStyle.Fill;
                Program.PaneWorker.LoadPane();
            }
            DisplayInPaneMain(Program.PaneWorker);
        }
    }
}
