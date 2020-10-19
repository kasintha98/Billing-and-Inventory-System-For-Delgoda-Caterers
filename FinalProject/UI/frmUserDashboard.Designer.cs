namespace FinalProject
{
    partial class frmUserDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserDashboard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesFormsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dealersAndCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAppLName = new System.Windows.Forms.Label();
            this.lblApp2Name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAppFName = new System.Windows.Forms.Label();
            this.lblLoggedInUser = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.lblLoggedUser = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseToolStripMenuItem,
            this.salesFormsToolStripMenuItem,
            this.inventoryToolStripMenuItem,
            this.dealersAndCustomersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1443, 44);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(167, 40);
            this.purchaseToolStripMenuItem.Text = "Purchase";
            this.purchaseToolStripMenuItem.Click += new System.EventHandler(this.purchaseToolStripMenuItem_Click);
            // 
            // salesFormsToolStripMenuItem
            // 
            this.salesFormsToolStripMenuItem.Name = "salesFormsToolStripMenuItem";
            this.salesFormsToolStripMenuItem.Size = new System.Drawing.Size(108, 40);
            this.salesFormsToolStripMenuItem.Text = "Sales";
            this.salesFormsToolStripMenuItem.Click += new System.EventHandler(this.salesFormsToolStripMenuItem_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(178, 40);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            this.inventoryToolStripMenuItem.Click += new System.EventHandler(this.inventoryToolStripMenuItem_Click);
            // 
            // dealersAndCustomersToolStripMenuItem
            // 
            this.dealersAndCustomersToolStripMenuItem.Name = "dealersAndCustomersToolStripMenuItem";
            this.dealersAndCustomersToolStripMenuItem.Size = new System.Drawing.Size(380, 40);
            this.dealersAndCustomersToolStripMenuItem.Text = "Dealers And Customers";
            this.dealersAndCustomersToolStripMenuItem.Click += new System.EventHandler(this.dealersAndCustomersToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(851, 468);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 24);
            this.label2.TabIndex = 16;
            this.label2.Text = "Billing and Inventory Management System";
            // 
            // lblAppLName
            // 
            this.lblAppLName.AutoSize = true;
            this.lblAppLName.BackColor = System.Drawing.Color.Transparent;
            this.lblAppLName.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppLName.ForeColor = System.Drawing.Color.Navy;
            this.lblAppLName.Location = new System.Drawing.Point(861, 412);
            this.lblAppLName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppLName.Name = "lblAppLName";
            this.lblAppLName.Size = new System.Drawing.Size(305, 46);
            this.lblAppLName.TabIndex = 15;
            this.lblAppLName.Text = "Family Restaurent";
            // 
            // lblApp2Name
            // 
            this.lblApp2Name.AutoSize = true;
            this.lblApp2Name.BackColor = System.Drawing.Color.Transparent;
            this.lblApp2Name.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApp2Name.ForeColor = System.Drawing.Color.Navy;
            this.lblApp2Name.Location = new System.Drawing.Point(979, 355);
            this.lblApp2Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApp2Name.Name = "lblApp2Name";
            this.lblApp2Name.Size = new System.Drawing.Size(86, 46);
            this.lblApp2Name.TabIndex = 14;
            this.lblApp2Name.Text = "And";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.label1.Location = new System.Drawing.Point(933, 422);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 46);
            this.label1.TabIndex = 13;
            this.label1.Text = "&";
            // 
            // lblAppFName
            // 
            this.lblAppFName.AutoSize = true;
            this.lblAppFName.BackColor = System.Drawing.Color.Transparent;
            this.lblAppFName.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFName.ForeColor = System.Drawing.Color.Navy;
            this.lblAppFName.Location = new System.Drawing.Point(861, 294);
            this.lblAppFName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppFName.Name = "lblAppFName";
            this.lblAppFName.Size = new System.Drawing.Size(294, 46);
            this.lblAppFName.TabIndex = 12;
            this.lblAppFName.Text = "Delgoda Caterers";
            // 
            // lblLoggedInUser
            // 
            this.lblLoggedInUser.AutoSize = true;
            this.lblLoggedInUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggedInUser.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblLoggedInUser.Location = new System.Drawing.Point(69, 30);
            this.lblLoggedInUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoggedInUser.Name = "lblLoggedInUser";
            this.lblLoggedInUser.Size = new System.Drawing.Size(0, 23);
            this.lblLoggedInUser.TabIndex = 11;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlFooter.Controls.Add(this.lblFooter);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 559);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1443, 43);
            this.pnlFooter.TabIndex = 9;
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.ForeColor = System.Drawing.Color.White;
            this.lblFooter.Location = new System.Drawing.Point(851, 11);
            this.lblFooter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(280, 23);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "Developed By Team DotNet";
            // 
            // lblLoggedUser
            // 
            this.lblLoggedUser.AutoSize = true;
            this.lblLoggedUser.BackColor = System.Drawing.Color.Transparent;
            this.lblLoggedUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggedUser.ForeColor = System.Drawing.Color.Green;
            this.lblLoggedUser.Location = new System.Drawing.Point(79, 53);
            this.lblLoggedUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoggedUser.Name = "lblLoggedUser";
            this.lblLoggedUser.Size = new System.Drawing.Size(0, 20);
            this.lblLoggedUser.TabIndex = 17;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Red;
            this.lblUser.Location = new System.Drawing.Point(16, 50);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(55, 23);
            this.lblUser.TabIndex = 10;
            this.lblUser.Text = "User :";
            // 
            // frmUserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1443, 602);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblLoggedUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAppLName);
            this.Controls.Add(this.lblApp2Name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAppFName);
            this.Controls.Add(this.lblLoggedInUser);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUserDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUserDashboard_FormClosed);
            this.Load += new System.EventHandler(this.frmUserDashboard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesFormsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAppLName;
        private System.Windows.Forms.Label lblApp2Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAppFName;
        private System.Windows.Forms.Label lblLoggedInUser;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.ToolStripMenuItem dealersAndCustomersToolStripMenuItem;
        private System.Windows.Forms.Label lblLoggedUser;
        private System.Windows.Forms.Label lblUser;
    }
}