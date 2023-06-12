namespace Krishna_Textiles.UserControls
{
    partial class ContReportGroupSelectDev
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContReportGroupSelectDev));
            this.ListFrom = new DevExpress.XtraEditors.ListBoxControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.MoveDown = new DevExpress.XtraEditors.SimpleButton();
            this.MoveUp = new DevExpress.XtraEditors.SimpleButton();
            this.MoveLeft = new DevExpress.XtraEditors.SimpleButton();
            this.MoveRight = new DevExpress.XtraEditors.SimpleButton();
            this.ListTo = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.ListFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListTo)).BeginInit();
            this.SuspendLayout();
            // 
            // ListFrom
            // 
            this.ListFrom.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListFrom.Appearance.Options.UseFont = true;
            this.ListFrom.Cursor = System.Windows.Forms.Cursors.Default;
            this.ListFrom.Dock = System.Windows.Forms.DockStyle.Left;
            this.ListFrom.Location = new System.Drawing.Point(0, 0);
            this.ListFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListFrom.Name = "ListFrom";
            this.ListFrom.Size = new System.Drawing.Size(179, 188);
            this.ListFrom.TabIndex = 4;
            this.ListFrom.DoubleClick += new System.EventHandler(this.ListFrom_DoubleClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.MoveDown);
            this.panelControl1.Controls.Add(this.MoveUp);
            this.panelControl1.Controls.Add(this.MoveLeft);
            this.panelControl1.Controls.Add(this.MoveRight);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(179, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(51, 188);
            this.panelControl1.TabIndex = 6;
            // 
            // MoveDown
            // 
            this.MoveDown.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MoveDown.ImageOptions.Image")));
            this.MoveDown.Location = new System.Drawing.Point(8, 147);
            this.MoveDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MoveDown.Name = "MoveDown";
            this.MoveDown.Size = new System.Drawing.Size(36, 32);
            this.MoveDown.TabIndex = 3;
            this.MoveDown.Click += new System.EventHandler(this.MoveDown_Click);
            // 
            // MoveUp
            // 
            this.MoveUp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MoveUp.ImageOptions.Image")));
            this.MoveUp.Location = new System.Drawing.Point(8, 107);
            this.MoveUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MoveUp.Name = "MoveUp";
            this.MoveUp.Size = new System.Drawing.Size(36, 32);
            this.MoveUp.TabIndex = 2;
            this.MoveUp.Click += new System.EventHandler(this.MoveUp_Click);
            // 
            // MoveLeft
            // 
            this.MoveLeft.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MoveLeft.ImageOptions.Image")));
            this.MoveLeft.Location = new System.Drawing.Point(8, 46);
            this.MoveLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MoveLeft.Name = "MoveLeft";
            this.MoveLeft.Size = new System.Drawing.Size(36, 32);
            this.MoveLeft.TabIndex = 1;
            this.MoveLeft.Click += new System.EventHandler(this.MoveLeft_Click);
            // 
            // MoveRight
            // 
            this.MoveRight.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MoveRight.ImageOptions.Image")));
            this.MoveRight.Location = new System.Drawing.Point(8, 6);
            this.MoveRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MoveRight.Name = "MoveRight";
            this.MoveRight.Size = new System.Drawing.Size(36, 32);
            this.MoveRight.TabIndex = 0;
            this.MoveRight.Click += new System.EventHandler(this.MoveRight_Click);
            // 
            // ListTo
            // 
            this.ListTo.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListTo.Appearance.Options.UseFont = true;
            this.ListTo.Cursor = System.Windows.Forms.Cursors.Default;
            this.ListTo.Dock = System.Windows.Forms.DockStyle.Left;
            this.ListTo.Location = new System.Drawing.Point(230, 0);
            this.ListTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListTo.Name = "ListTo";
            this.ListTo.Size = new System.Drawing.Size(179, 188);
            this.ListTo.TabIndex = 7;
            this.ListTo.DoubleClick += new System.EventHandler(this.ListTo_DoubleClick);
            // 
            // ContReportGroupSelectDev
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListTo);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ListFrom);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ContReportGroupSelectDev";
            this.Size = new System.Drawing.Size(411, 188);
            ((System.ComponentModel.ISupportInitialize)(this.ListFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListTo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl ListFrom;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton MoveDown;
        private DevExpress.XtraEditors.SimpleButton MoveUp;
        private DevExpress.XtraEditors.SimpleButton MoveLeft;
        private DevExpress.XtraEditors.SimpleButton MoveRight;
        private DevExpress.XtraEditors.ListBoxControl ListTo;
    }
}
