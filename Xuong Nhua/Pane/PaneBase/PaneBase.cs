using System;
using System.Windows.Forms;
using System.Data;
using Xuong_Nhua.Theme;
using MySql.Data.MySqlClient;

namespace Xuong_Nhua.Pane.Base
{
    public abstract partial class PaneBase : UserControl
    {
        public int PANEID = 0;
        public PaneInfo PaneInfo = null;
        public ThemeDGV Grid = new ThemeDGV();
        public string[] ColNames;

        public PaneBaseInfo PaneSumChild = null;
        public PaneBaseSelect PaneSelectChild = null;
        public PaneUpdate PaneUpdateChild = null;

        public int CURRENT_MODE = -1;
        public int MODE_TO_SHOW_FIRST = PaneUpdate.MODE_INSERT;

        public bool SHOW_INSERT_BUTTON = true;
        public bool SHOW_EDIT_BUTTON = true;
        public bool SHOW_DELETE_BUTTON = true;
        public bool SHOW_RESET_BUTTON = true;

        public string INSERT_BUTTON_LABEL = "&Add";
        public string DELETE_BUTTON_LABEL = "&Delete";
        public string EDIT_BUTTON_LABEL = "&Edit";
        public string RESET_BUTTON_LABEL = "&Reset";

        public bool ALLOW_MULTIPLE_SELECTION_ON_GRID = false;

        public PaneBase()
        {
            InitializeComponent();
            SetGridMultipleSelecAbility();
            SetPANEID();
            SetColNames();
            PaneInfo = new PaneInfo(PANEID);
            SetPaneGridSize();

            SetPaneSum();
            PaneSumChild.Dock = DockStyle.Top;
            SetPaneSelect();
            PaneSelectChild.Dock = DockStyle.Top;

            PaneSum.Controls.Add(PaneSumChild);
            PaneSelect.Controls.Add(PaneSelectChild);

            SetPaneUpdate();
            PaneUpdateChild.SetPaneBase(this);
            PaneUpdateChild.Dock = DockStyle.Top;
            PaneUpdateChild.PopulateControls();
            PaneInput.Controls.Add(PaneUpdateChild);
            SetFirstMode();
            if (MODE_TO_SHOW_FIRST >= 0)
            {
                PaneUpdateChild.ShowPane(MODE_TO_SHOW_FIRST);
            }
            else
            {
                PaneUpdateChild.HideButtons();
            }
            Grid.MouseDown += new MouseEventHandler(this.Grid_Click);
        }

        private void PaneBase_Load(object sender, EventArgs e)
        {
        }

        private void SetPaneGridSize()
        {
            PaneGrid.Height = Screen.PrimaryScreen.WorkingArea.Height / 5 * 3;
        }

        public abstract void SetPANEID();

        public abstract void SetColNames();

        public abstract void SetColVisibility();

        public abstract void PopulatePaneSummary(ref DataTable dt);

        public abstract void FormatGrid();

        public abstract void SetPaneSum();

        public abstract void SetPaneSelect();

        public abstract void SetPaneUpdate();

        public abstract MySqlCommand CreateViewQueryCommand(object[] args);

        public void RefreshPane()
        {
            PaneSelectChild.RefreshData();
            PaneUpdateChild.RefreshControls();
            MySqlCommand commandView = CreateViewQueryCommand(PaneSelectChild.GetParams());
            DataTable dt = Share.MySql.GetDataTable(commandView);
            dt = ProcessDataTable(dt);
            Grid.setData(dt);
            PopulatePaneSummary(ref dt);
            FormatGrid();
            Grid.resizeColumns();
            Grid.ClearSel();
        }

        public virtual DataTable ProcessDataTable(DataTable dt)
        {
            return dt;
        }

        public void LoadPane()
        {
            if (!PaneInfo.IsValid())
            {
                return;
            }
            LoadTitle();
            PaneGrid.Controls.Add(Grid);
            InitGrid();
            SetupButtons();
        }

        private void LoadTitle()
        {
            LblTitle.Font = Share.FontTitle;
            LblTitle.ForeColor = Share.ColDark;
            LblTitle.Text = PaneInfo.Title.ToUpper();
        }

        private void InitGrid()
        {
            SetColNames();
            SetGridColNames();
            SetColVisibility();
            Grid.resizeColumns();
        }

        private void SetGridColNames()
        {
            Grid.ColumnCount = ColNames.Length;
            for (int i = 0; i < Grid.ColumnCount; i++)
            {
                Grid.Columns[i].HeaderText = ColNames[i];
                Grid.Columns[i].Name = ColNames[i];
            }
        }

        private void SetupButView()
        {
            ButView.SetButtonText("&View");
            ButView.GetButton().Click += new System.EventHandler(this.ButView_Click);
        }

        private void ButView_Click(object sender, EventArgs e)
        {
            RefreshPane();
        }

        private void SetupButInsert()
        {
            ButInsert.Visible = SHOW_INSERT_BUTTON;
            if (SHOW_INSERT_BUTTON)
            {
                ButInsert.SetButtonText(INSERT_BUTTON_LABEL);
                ButInsert.GetButton().Click += new System.EventHandler(this.ButInsert_Click);
            }
        }

        private void SetupButUpdate()
        {
            ButUpdate.Visible = SHOW_EDIT_BUTTON;
            if (SHOW_EDIT_BUTTON)
            {
                ButUpdate.SetButtonText(EDIT_BUTTON_LABEL);
                ButUpdate.GetButton().Click += new System.EventHandler(this.ButUpdate_Click);
            }
        }

        private void SetupButReset()
        {
            ButReset.Visible = SHOW_RESET_BUTTON;
            if (SHOW_RESET_BUTTON)
            {
                ButReset.SetButtonText(RESET_BUTTON_LABEL);
                ButReset.GetButton().Click += new System.EventHandler(this.ButReset_Click);
            }
        }

        private void ButReset_Click(object sender, EventArgs e)
        {
            PaneSelectChild.ResetParameter();
        }

        private void ButInsert_Click(object sender, EventArgs e)
        {
            PaneUpdateChild.ShowPane(PaneUpdate.MODE_INSERT);
            PaneUpdateChild.ResetToControlDefaultValue();
            CURRENT_MODE = PaneUpdate.MODE_INSERT;
        }

        private void ButUpdate_Click(object sender, EventArgs e)
        {
            PaneUpdateChild.ShowPane(PaneUpdate.MODE_EDIT);
            if (Grid.curRow >= 0)
            {
                UpdateEditPaneInputData(Grid.Rows[Grid.CurrentRow.Index]);
            }
            CURRENT_MODE = PaneUpdate.MODE_EDIT;
        }

        private void SetupButDelete()
        {
            ButDelete.Visible = SHOW_DELETE_BUTTON;
            if (SHOW_DELETE_BUTTON)
            {
                ButDelete.SetButtonText(DELETE_BUTTON_LABEL);
                ButDelete.GetButton().Click += new System.EventHandler(this.ButDelete_Click);
            }
        }

        private void ButDelete_Click(object sender, EventArgs e)
        {
            if (Grid.curRow < 0)
            {
                Share.showWarningMessage("Please select a " + PaneInfo.LocalName + " to delete!");
            }
            else if (MessageBox.Show("Are you sure you want to delete this " + PaneInfo.LocalName + "?", Share.confirmCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteDatabaseRow(Grid.Rows[Grid.curRow].Cells[0].Value);
                RefreshPane();
            }
        }

        public void DeleteDatabaseRow(object inputID)
        {
            int ID = 0;
            try
            {
                ID = Int32.Parse(inputID.ToString());
            }
            catch (Exception e)
            {
                Share.showErrorMessage("Cannot parse index of row: " + e.Message);
                return;
            }

            string sql = PaneInfo.DeleteQuery + ID;
            Share.MySql.ExeCommand(sql);
        }

        private void SetupButtons()
        {
            SetButtonsVisibility();
            SetupButReset();
            SetupButView();
            SetupButInsert();
            SetupButUpdate();
            SetupButDelete();
        }

        private void Grid_Click(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                Grid.hit = Grid.HitTest(e.X, e.Y);
                if (Grid.hit.Type == DataGridViewHitTestType.Cell)
                {
                    Grid.curRow = Grid.Rows[Grid.hit.RowIndex].Index;
                    UpdateCurentSelectedID((int)(Grid.Rows[Grid.curRow]).Cells[0].Value);
                }
            }
            if (CURRENT_MODE == PaneUpdate.MODE_EDIT)
            {
                if (Grid.curRow >= 0)
                {
                    UpdateEditPaneInputData(Grid.Rows[Grid.curRow]);
                }
            }
        }

        private void UpdateEditPaneInputData(DataGridViewRow dataGridViewRow)
        {
            PaneUpdateChild.UpdateEditInputData(dataGridViewRow);
        }

        public virtual void SetButtonsVisibility() { }
        public virtual void SetGridMultipleSelecAbility() { }
        public void UpdateCurentSelectedID(int selectedID)
        {
            PaneUpdateChild.UpdateCurentSelectedID(selectedID);
        }

        // Decide which panel to show 1st, INSERT OR EDIT (default is INSERT)
        public virtual void SetFirstMode() { }
    }
}

