using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace Xuong_Nhua.Theme
{
    public class ThemeDGV : DataGridView
    {
        // Fields
        private int BORDERWIDTH;
        private int BOTTOMOFFSET;
        public int curRow;
        public DataGridView.HitTestInfo hit;
        private int screenWidth;

        // Methods
        public ThemeDGV()
        {
            //base.MouseDown += new MouseEventHandler(this.Me_Click);
            base.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.Me_Click);
            this.BOTTOMOFFSET = 0x15;
            this.BORDERWIDTH = 2;
            this.curRow = -1;
            DataGridViewCellStyle headerCellStyle = new DataGridViewCellStyle();
            headerCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerCellStyle.BackColor = Color.OliveDrab;
            headerCellStyle.Font = Share.FontApp;
            headerCellStyle.ForeColor = Share.ColLight;
            headerCellStyle.SelectionBackColor = SystemColors.Highlight;
            headerCellStyle.SelectionForeColor = SystemColors.HighlightText;
            Padding padding = new Padding(5, 0, 0, 0);
            headerCellStyle.Padding = padding;
            this.ColumnHeadersDefaultCellStyle = headerCellStyle;
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = Color.AntiqueWhite;
            cellStyle.Font = Share.FontApp;
            padding = new Padding(5, 0, 0, 0);
            cellStyle.Padding = padding;
            cellStyle.SelectionBackColor = Color.LemonChiffon;
            cellStyle.SelectionForeColor = Color.DarkGreen;
            cellStyle.WrapMode = DataGridViewTriState.True;
            this.RowsDefaultCellStyle = cellStyle;
            DataGridViewCellStyle altCellStyle = new DataGridViewCellStyle();
            altCellStyle.BackColor = Color.Azure;
            altCellStyle.Font = Share.FontApp;
            padding = new Padding(5, 0, 0, 0);
            altCellStyle.Padding = padding;
            altCellStyle.SelectionBackColor = Color.LemonChiffon;
            altCellStyle.SelectionForeColor = Color.DarkGreen;
            altCellStyle.WrapMode = DataGridViewTriState.True;
            this.AlternatingRowsDefaultCellStyle = altCellStyle;
            this.EnableHeadersVisualStyles = false;
            this.GridColor = Color.LightSteelBlue;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;
            this.AllowUserToOrderColumns = true;
            this.AllowUserToResizeColumns = true;
            this.MultiSelect = false;
            this.RowHeadersVisible = false;
            this.BackgroundColor = Share.ColLight;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.Dock = DockStyle.Fill;
            this.ReadOnly = true;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            this.TabStop = false;
            this.screenWidth = (Program.FormMain.Width - 0x1c) - this.VerticalScrollBar.Width;
        }

        public void ClearSel()
        {
            this.ClearSelection();
            this.curRow = -1;
        }

        private void Me_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        /*
        private void Me_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.hit = this.HitTest(e.X, e.Y);
                if (this.hit.Type == DataGridViewHitTestType.Cell)
                {
                    this.curRow = this.Rows[this.hit.RowIndex].Index;
                }
            }
        }
        */

        public void resizeColumns()
        {
            int i;
            int colNum = this.Columns.Count;
            int[] colWidths = new int[colNum + 1];
            int totalColWidth = 0;
            int currentCol = colNum - 1;

            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            currentCol = colNum - 1;
            for (i = 0; i <= currentCol; i++)
            {
                if (this.Columns[i].Visible)
                {
                    colWidths[i] = this.Columns[i].Width;
                    totalColWidth += colWidths[i];
                }
            }
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            currentCol = colNum - 1;
            for (i = 0; i <= currentCol; i++)
            {
                if (this.Columns[i].Visible)
                {
                    this.Columns[i].Width = (int)Math.Round((double)((((double)colWidths[i]) / ((double)totalColWidth)) * this.screenWidth));
                }
            }
        }

        public void setData(DataTable dt)
        {
            this.Rows.Clear();
            for (int row = 0; row < dt.Rows.Count; row++)
            {
                this.Rows.Add();
                for (int col = 0; col < this.ColumnCount; col++)
                {
                    this[col, row].Value = dt.Rows[row][col];
                }
            }
        }

        private void ShowScrollBars(object sender, EventArgs e)
        {
            if (!this.VerticalScrollBar.Visible)
            {
                int width = this.VerticalScrollBar.Width;
                Point point = new Point((this.ClientRectangle.Width - width) - this.BORDERWIDTH, 2);
                this.VerticalScrollBar.Location = point;
                Size size = new Size(width, (this.ClientRectangle.Height - this.BOTTOMOFFSET) - this.BORDERWIDTH);
                this.VerticalScrollBar.Size = size;
                this.VerticalScrollBar.Show();
            }
        }

    }

}
