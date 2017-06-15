namespace Xuong_Nhua.InputControl
{
    partial class PaneInputControl
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
            this.Pane = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // Pane
            // 
            this.Pane.AutoSize = true;
            this.Pane.BackColor = System.Drawing.Color.Transparent;
            this.Pane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pane.Location = new System.Drawing.Point(0, 0);
            this.Pane.Name = "Pane";
            this.Pane.Size = new System.Drawing.Size(197, 77);
            this.Pane.TabIndex = 0;
            // 
            // PaneInputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Pane);
            this.Name = "PaneInputControl";
            this.Size = new System.Drawing.Size(197, 77);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Pane;



    }
}
