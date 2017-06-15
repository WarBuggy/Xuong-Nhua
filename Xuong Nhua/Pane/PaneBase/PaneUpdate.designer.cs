namespace Xuong_Nhua.Pane.Base
{
    partial class PaneUpdate
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
            this.ButSecondary = new Xuong_Nhua.Theme.ThemeButton();
            this.ButPrimary = new Xuong_Nhua.Theme.ThemeButton();
            this.PaneButOutter = new System.Windows.Forms.Panel();
            this.PaneControl = new System.Windows.Forms.FlowLayoutPanel();
            this.PaneTitle = new System.Windows.Forms.Panel();
            this.LblUpdateTitle = new System.Windows.Forms.Label();
            this.PaneButOutter.SuspendLayout();
            this.PaneTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButSecondary
            // 
            this.ButSecondary.Location = new System.Drawing.Point(115, 3);
            this.ButSecondary.Name = "ButSecondary";
            this.ButSecondary.Size = new System.Drawing.Size(106, 26);
            this.ButSecondary.TabIndex = 1;
            // 
            // ButPrimary
            // 
            this.ButPrimary.Location = new System.Drawing.Point(3, 3);
            this.ButPrimary.Name = "ButPrimary";
            this.ButPrimary.Size = new System.Drawing.Size(106, 26);
            this.ButPrimary.TabIndex = 0;
            // 
            // PaneButOutter
            // 
            this.PaneButOutter.BackColor = System.Drawing.Color.Transparent;
            this.PaneButOutter.Controls.Add(this.ButSecondary);
            this.PaneButOutter.Controls.Add(this.ButPrimary);
            this.PaneButOutter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PaneButOutter.Location = new System.Drawing.Point(0, 44);
            this.PaneButOutter.Name = "PaneButOutter";
            this.PaneButOutter.Size = new System.Drawing.Size(604, 32);
            this.PaneButOutter.TabIndex = 1;
            // 
            // PaneControl
            // 
            this.PaneControl.AutoSize = true;
            this.PaneControl.BackColor = System.Drawing.Color.Transparent;
            this.PaneControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.PaneControl.Location = new System.Drawing.Point(0, 44);
            this.PaneControl.Name = "PaneControl";
            this.PaneControl.Size = new System.Drawing.Size(604, 0);
            this.PaneControl.TabIndex = 2;
            // 
            // PaneTitle
            // 
            this.PaneTitle.Controls.Add(this.LblUpdateTitle);
            this.PaneTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PaneTitle.Location = new System.Drawing.Point(0, 0);
            this.PaneTitle.Name = "PaneTitle";
            this.PaneTitle.Size = new System.Drawing.Size(604, 44);
            this.PaneTitle.TabIndex = 3;
            // 
            // LblUpdateTitle
            // 
            this.LblUpdateTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblUpdateTitle.Location = new System.Drawing.Point(0, 0);
            this.LblUpdateTitle.Name = "LblUpdateTitle";
            this.LblUpdateTitle.Size = new System.Drawing.Size(604, 41);
            this.LblUpdateTitle.TabIndex = 0;
            this.LblUpdateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PaneUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.PaneButOutter);
            this.Controls.Add(this.PaneControl);
            this.Controls.Add(this.PaneTitle);
            this.Name = "PaneUpdate";
            this.Size = new System.Drawing.Size(604, 76);
            this.PaneButOutter.ResumeLayout(false);
            this.PaneTitle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Theme.ThemeButton ButPrimary;
        private Theme.ThemeButton ButSecondary;
        private System.Windows.Forms.Panel PaneButOutter;
        private System.Windows.Forms.FlowLayoutPanel PaneControl;
        private System.Windows.Forms.Panel PaneTitle;
        private System.Windows.Forms.Label LblUpdateTitle;
    }
}
