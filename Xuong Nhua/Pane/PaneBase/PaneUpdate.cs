using System;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;
using Xuong_Nhua.InputControl;

namespace Xuong_Nhua.Pane.Base
{
    public abstract partial class PaneUpdate : UserControl
    {
        private static string EDIT_PREFIX = "EDIT THE CURRENT ";
        private static string INSERT_PREFIX = "CREATE A NEW ";
        public static int MODE_INSERT = 0;
        public static int MODE_EDIT = 1;

        public int MODE = -1;
        public PaneInputControl[] InputControls;
        private PaneInfo Info;
        private PaneBase PaneBase;
        private int GRID_COLUMN_ID = 0;
        public int REPEAT_INSERT = 1;

        public int CURRENT_SELECTED_ID = -1;

        public PaneUpdate(PaneInfo info)
        {
            InitializeComponent();
            SetInputControlsArray();
            LblUpdateTitle.Font = Share.FontTitle;
            Info = info;

            ButSecondary.GetButton().Click += new EventHandler(this.Secondary_Click);
            ButPrimary.GetButton().Click += new EventHandler(this.Primary_Click);
        }

        public void SetPaneBase(PaneBase paneBase)
        {
            PaneBase = paneBase;
        }

        public void ShowPane(int mode)
        {
            if (mode < 0)
            {
                ShowInsertPane();
                return;
            }
            if (mode != MODE)
            {
                MODE = mode;
                if (MODE == MODE_EDIT)
                {
                    ShowUpdatePane();
                }
                else
                {
                    ShowInsertPane();
                }
            }
        }

        public void HideButtons()
        {
            ButPrimary.Visible = false;
            ButSecondary.Visible = false;
        }

        private void ShowUpdatePane()
        {
            BeforeShowUpdatePane();
            ButPrimary.SetButtonText("Update");
            ButSecondary.SetButtonText("Undo");
            LblUpdateTitle.ForeColor = Color.HotPink;
            this.BackColor = Color.LavenderBlush;
            LblUpdateTitle.Text = EDIT_PREFIX + Info.LocalName.ToUpper();
        }

        private void ShowInsertPane()
        {
            BeforeShowInsertPane();
            ButPrimary.SetButtonText("&Create");
            ButSecondary.SetButtonText("&Reset");
            LblUpdateTitle.ForeColor = Color.SteelBlue;
            this.BackColor = Color.LightBlue;
            LblUpdateTitle.Text = INSERT_PREFIX + Info.LocalName.ToUpper();
        }

        public void AddControl(PaneInputControl control)
        {
            control.Anchor = AnchorStyles.None;
            control.Name = control.Caption;
            PaneControl.Controls.Add(control);
        }

        public abstract void PopulateControls();

        public abstract void SetInputControlsArray();

        public void ResetValue()
        {
            foreach (PaneInputControl control in InputControls)
            {
                control.ResetValue();
            }
        }

        public void ResetToControlDefaultValue()
        {
            foreach (PaneInputControl control in InputControls)
            {
                control.SetDefaultControlValue();
            }
        }

        public void CreateRecord()
        {
            if (!CheckRequired())
            {
                return;
            }
            if (!CheckExtraInsertRequirement())
            {
                return;
            }
            MySqlCommand command = new MySqlCommand(Info.InsertQuery);
            ReplaceInsertParams(ref command);
            if (command == null)
            {
                Share.showErrorMessage("Insert command was not created properly");
                return;
            }

            UpdateRepeatInsert();

            for (int i = 0; i < REPEAT_INSERT; i++)
            {
                Share.MySql.ExeCommand(command);
            }
            PaneBase.RefreshPane();
            ResetValue();
        }

        public void EditRecord()
        {
            int currentID = (int)PaneBase.Grid.Rows[PaneBase.Grid.curRow].Cells[GRID_COLUMN_ID].Value;
            if (!CheckRequired())
            {
                return;
            }
            if (!CheckExtraEditRequirement(currentID))
            {
                return;
            }
            MySqlCommand command = new MySqlCommand(Info.UpdateQuery);
            command.Parameters.AddWithValue("ID", currentID);
            ReplaceEditParams(ref command);
            if (command == null)
            {
                Share.showErrorMessage("Edit command was not created properly");
                return;
            }
            Share.MySql.ExeCommand(command);
            PaneBase.RefreshPane();
        }

        private bool CheckRequired()
        {
            bool AllOK = true;
            string ErrorMassage = "";
            foreach (PaneInputControl control in InputControls)
            {
                if (!control.IsReady())
                {
                    ErrorMassage = ErrorMassage + control.GetNotReadyError() + System.Environment.NewLine;
                    AllOK = false;
                }
            }
            if (AllOK == false)
            {
                Share.showWarningMessage(ErrorMassage);
            }
            return AllOK;
        }

        private void Secondary_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void Primary_Click(object sender, EventArgs e)
        {
            if (MODE == MODE_INSERT)
            {
                CreateRecord();
            }
            else if (MODE == MODE_EDIT)
            {
                if (PaneBase.Grid.curRow < 0)
                {
                    Share.showWarningMessage("Please select a " + Info.LocalName + " to edit!");
                }
                else
                {
                    EditRecord();
                }
            }
        }

        public virtual void UpdateRepeatInsert() { }

        public virtual void BeforeShowUpdatePane() { }

        public virtual void BeforeShowInsertPane() { }

        public abstract void ReplaceInsertParams(ref MySqlCommand command);

        public abstract void ReplaceEditParams(ref MySqlCommand command);

        public virtual bool CheckExtraInsertRequirement()
        {
            return true;
        }

        public virtual bool CheckExtraEditRequirement(int id)
        {
            return true;
        }

        public void RefreshControls()
        {
            if (InputControls == null)
            {
                return;
            }

            foreach (Control InputControl in InputControls)
            {
                if (InputControl is PaneInputControl)
                {
                    ((PaneInputControl)InputControl).RefreshData();
                }
            }
        }

        public abstract void UpdateEditInputData(DataGridViewRow dataGridViewRow);

        public virtual void SetCustomUpdateRowID() { }

        public void UpdateCurentSelectedID(int currentSelectedID)
        {
            CURRENT_SELECTED_ID = currentSelectedID;
        }
    }
}
