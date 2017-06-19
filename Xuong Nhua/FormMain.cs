using System;
using System.Windows.Forms;
using Xuong_Nhua.Pane.Base;
using Xuong_Nhua.Pane.Material;
using Xuong_Nhua.Pane.Partner;
using Xuong_Nhua.Pane.Product;
using Xuong_Nhua.Pane.Formula;

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

        private void materialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.PaneMaterial == null)
            {
                Program.PaneMaterial = new PaneMaterial();
                Program.PaneMaterial.Dock = DockStyle.Fill;
                Program.PaneMaterial.LoadPane();
            }
            DisplayInPaneMain(Program.PaneMaterial);
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
    }
}
