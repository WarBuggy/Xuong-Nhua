namespace Xuong_Nhua.Pane.Base
{
    partial class PaneBase
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblTitle = new System.Windows.Forms.Label();
            this.PaneGrid = new System.Windows.Forms.Panel();
            this.PaneControl = new System.Windows.Forms.Panel();
            this.ButDelete = new Xuong_Nhua.Theme.ThemeButton();
            this.ButUpdate = new Xuong_Nhua.Theme.ThemeButton();
            this.ButInsert = new Xuong_Nhua.Theme.ThemeButton();
            this.ButView = new Xuong_Nhua.Theme.ThemeButton();
            this.PaneSum = new System.Windows.Forms.Panel();
            this.PaneSelect = new System.Windows.Forms.Panel();
            this.PaneInput = new System.Windows.Forms.Panel();
            this.PaneControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.SystemColors.Control;
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblTitle.Location = new System.Drawing.Point(0, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(1465, 40);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "TITLE HERE";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PaneGrid
            // 
            this.PaneGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.PaneGrid.Location = new System.Drawing.Point(0, 40);
            this.PaneGrid.Name = "PaneGrid";
            this.PaneGrid.Size = new System.Drawing.Size(1465, 594);
            this.PaneGrid.TabIndex = 1;
            // 
            // PaneControl
            // 
            this.PaneControl.Controls.Add(this.ButDelete);
            this.PaneControl.Controls.Add(this.ButUpdate);
            this.PaneControl.Controls.Add(this.ButInsert);
            this.PaneControl.Controls.Add(this.ButView);
            this.PaneControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.PaneControl.Location = new System.Drawing.Point(0, 634);
            this.PaneControl.Name = "PaneControl";
            this.PaneControl.Size = new System.Drawing.Size(1465, 33);
            this.PaneControl.TabIndex = 2;
            // 
            // ButDelete
            // 
            this.ButDelete.Location = new System.Drawing.Point(348, 3);
            this.ButDelete.Name = "ButDelete";
            this.ButDelete.Size = new System.Drawing.Size(106, 26);
            this.ButDelete.TabIndex = 3;
            // 
            // ButUpdate
            // 
            this.ButUpdate.Location = new System.Drawing.Point(236, 3);
            this.ButUpdate.Name = "ButUpdate";
            this.ButUpdate.Size = new System.Drawing.Size(106, 26);
            this.ButUpdate.TabIndex = 2;
            // 
            // ButInsert
            // 
            this.ButInsert.Location = new System.Drawing.Point(124, 3);
            this.ButInsert.Name = "ButInsert";
            this.ButInsert.Size = new System.Drawing.Size(106, 26);
            this.ButInsert.TabIndex = 1;
            // 
            // ButView
            // 
            this.ButView.Location = new System.Drawing.Point(12, 3);
            this.ButView.Name = "ButView";
            this.ButView.Size = new System.Drawing.Size(106, 26);
            this.ButView.TabIndex = 0;
            // 
            // PaneSum
            // 
            this.PaneSum.AutoSize = true;
            this.PaneSum.BackColor = System.Drawing.SystemColors.Control;
            this.PaneSum.Dock = System.Windows.Forms.DockStyle.Top;
            this.PaneSum.Location = new System.Drawing.Point(0, 634);
            this.PaneSum.Name = "PaneSum";
            this.PaneSum.Size = new System.Drawing.Size(1465, 0);
            this.PaneSum.TabIndex = 3;
            // 
            // PaneSelect
            // 
            this.PaneSelect.AutoSize = true;
            this.PaneSelect.BackColor = System.Drawing.SystemColors.Control;
            this.PaneSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.PaneSelect.Location = new System.Drawing.Point(0, 634);
            this.PaneSelect.Name = "PaneSelect";
            this.PaneSelect.Size = new System.Drawing.Size(1465, 0);
            this.PaneSelect.TabIndex = 4;
            // 
            // PaneInput
            // 
            this.PaneInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PaneInput.Location = new System.Drawing.Point(0, 667);
            this.PaneInput.Name = "PaneInput";
            this.PaneInput.Size = new System.Drawing.Size(1465, 249);
            this.PaneInput.TabIndex = 5;
            // 
            // PaneBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.PaneInput);
            this.Controls.Add(this.PaneControl);
            this.Controls.Add(this.PaneSelect);
            this.Controls.Add(this.PaneSum);
            this.Controls.Add(this.PaneGrid);
            this.Controls.Add(this.LblTitle);
            this.Name = "PaneBase";
            this.Size = new System.Drawing.Size(1465, 916);
            this.Load += new System.EventHandler(this.PaneBase_Load);
            this.PaneControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Panel PaneGrid;
        private System.Windows.Forms.Panel PaneControl;
        private Theme.ThemeButton ButDelete;
        private Theme.ThemeButton ButUpdate;
        private Theme.ThemeButton ButInsert;
        private Theme.ThemeButton ButView;
        private System.Windows.Forms.Panel PaneSum;
        private System.Windows.Forms.Panel PaneSelect;
        private System.Windows.Forms.Panel PaneInput;




    }
}
