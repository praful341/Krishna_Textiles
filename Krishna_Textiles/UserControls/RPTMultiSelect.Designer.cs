namespace Krishna_Textiles.UserControls
{
    partial class RPTMultiSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPTMultiSelect));
            this.ListFrom = new DevExpress.XtraEditors.ListBoxControl();
            this.ListTo = new DevExpress.XtraEditors.ListBoxControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.BtnDown = new DevExpress.XtraEditors.SimpleButton();
            this.BtnBW = new DevExpress.XtraEditors.SimpleButton();
            this.BtnUP = new DevExpress.XtraEditors.SimpleButton();
            this.BtnFW = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ListFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListFrom
            // 
            this.ListFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListFrom.HorizontalScrollbar = true;
            this.ListFrom.Location = new System.Drawing.Point(2, 2);
            this.ListFrom.Name = "ListFrom";
            this.ListFrom.Size = new System.Drawing.Size(146, 196);
            this.ListFrom.TabIndex = 0;
            this.ListFrom.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListFrom_MouseDoubleClick);
            // 
            // ListTo
            // 
            this.ListTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListTo.HorizontalScrollbar = true;
            this.ListTo.Location = new System.Drawing.Point(2, 2);
            this.ListTo.Name = "ListTo";
            this.ListTo.Size = new System.Drawing.Size(146, 196);
            this.ListTo.TabIndex = 1;
            this.ListTo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListTo_MouseDoubleClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.BtnDown);
            this.panelControl1.Controls.Add(this.BtnBW);
            this.panelControl1.Controls.Add(this.BtnUP);
            this.panelControl1.Controls.Add(this.BtnFW);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(150, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(56, 200);
            this.panelControl1.TabIndex = 2;
            // 
            // BtnDown
            // 
            this.BtnDown.Image = ((System.Drawing.Image)(resources.GetObject("BtnDown.Image")));
            this.BtnDown.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnDown.Location = new System.Drawing.Point(5, 154);
            this.BtnDown.Name = "BtnDown";
            this.BtnDown.Size = new System.Drawing.Size(44, 30);
            this.BtnDown.TabIndex = 3;
            this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // BtnBW
            // 
            this.BtnBW.Image = ((System.Drawing.Image)(resources.GetObject("BtnBW.Image")));
            this.BtnBW.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnBW.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnBW.Location = new System.Drawing.Point(5, 54);
            this.BtnBW.Name = "BtnBW";
            this.BtnBW.Size = new System.Drawing.Size(44, 30);
            this.BtnBW.TabIndex = 2;
            this.BtnBW.Text = "simpleButton3";
            this.BtnBW.Click += new System.EventHandler(this.BtnBW_Click);
            // 
            // BtnUP
            // 
            this.BtnUP.Image = ((System.Drawing.Image)(resources.GetObject("BtnUP.Image")));
            this.BtnUP.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnUP.Location = new System.Drawing.Point(5, 117);
            this.BtnUP.Name = "BtnUP";
            this.BtnUP.Size = new System.Drawing.Size(44, 30);
            this.BtnUP.TabIndex = 1;
            this.BtnUP.Click += new System.EventHandler(this.BtnUP_Click);
            // 
            // BtnFW
            // 
            this.BtnFW.Image = ((System.Drawing.Image)(resources.GetObject("BtnFW.Image")));
            this.BtnFW.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnFW.Location = new System.Drawing.Point(5, 14);
            this.BtnFW.Name = "BtnFW";
            this.BtnFW.Size = new System.Drawing.Size(44, 30);
            this.BtnFW.TabIndex = 0;
            this.BtnFW.Click += new System.EventHandler(this.BtnFW_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.ListFrom);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(150, 200);
            this.panelControl2.TabIndex = 3;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.ListTo);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(206, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(150, 200);
            this.panelControl3.TabIndex = 4;
            // 
            // RPTMultiSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Name = "RPTMultiSelect";
            this.Size = new System.Drawing.Size(356, 200);
            ((System.ComponentModel.ISupportInitialize)(this.ListFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton BtnDown;
        private DevExpress.XtraEditors.SimpleButton BtnBW;
        private DevExpress.XtraEditors.SimpleButton BtnUP;
        private DevExpress.XtraEditors.SimpleButton BtnFW;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        public DevExpress.XtraEditors.ListBoxControl ListFrom;
        public DevExpress.XtraEditors.ListBoxControl ListTo;
    }
}
