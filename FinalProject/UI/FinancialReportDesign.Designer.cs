namespace FinalProject.UI
{
    partial class FinancialReportDesign
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crystalReportViewerFinance = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerFinance
            // 
            this.crystalReportViewerFinance.ActiveViewIndex = -1;
            this.crystalReportViewerFinance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerFinance.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerFinance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerFinance.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerFinance.Name = "crystalReportViewerFinance";
            this.crystalReportViewerFinance.Size = new System.Drawing.Size(1063, 692);
            this.crystalReportViewerFinance.TabIndex = 0;
            // 
            // FinancialReportDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 692);
            this.Controls.Add(this.crystalReportViewerFinance);
            this.Name = "FinancialReportDesign";
            this.Text = "FinancialReportDesign";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerFinance;
    }
}