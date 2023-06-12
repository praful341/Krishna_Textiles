namespace Krishna_Textiles.Report
{
    partial class FrmPReportViewer
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
            this.components = new System.ComponentModel.Container();
            this.PrintingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.DgvPivot = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pnlRefresh = new DevExpress.XtraEditors.PanelControl();
            this.lblDateTime = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.PictureActivator = new DevExpress.XtraEditors.PictureEdit();
            this.lblGroupBy = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.lblReportHeader = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.lblFilter = new DevExpress.XtraEditors.LabelControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.ToText = new System.Windows.Forms.ToolStripMenuItem();
            this.ToHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.ToRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.ToPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.EmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrientationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbOrientation = new System.Windows.Forms.ToolStripComboBox();
            this.ExpandAllGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbExpand = new System.Windows.Forms.ToolStripComboBox();
            this.ExpandTool = new System.Windows.Forms.ToolStripMenuItem();
            this.Collapse = new System.Windows.Forms.ToolStripMenuItem();
            this.AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MNRemoveGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PrintingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPivot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRefresh)).BeginInit();
            this.pnlRefresh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureActivator.Properties)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvPivot
            // 
            this.DgvPivot.ActiveFilterString = "";
            this.DgvPivot.Appearance.ColumnHeaderArea.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvPivot.Appearance.ColumnHeaderArea.ForeColor = System.Drawing.Color.Black;
            this.DgvPivot.Appearance.ColumnHeaderArea.Options.UseFont = true;
            this.DgvPivot.Appearance.ColumnHeaderArea.Options.UseForeColor = true;
            this.DgvPivot.Appearance.ColumnHeaderArea.Options.UseTextOptions = true;
            this.DgvPivot.Appearance.ColumnHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DgvPivot.Appearance.DataHeaderArea.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvPivot.Appearance.DataHeaderArea.Options.UseFont = true;
            this.DgvPivot.Appearance.DataHeaderArea.Options.UseTextOptions = true;
            this.DgvPivot.Appearance.DataHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DgvPivot.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvPivot.Appearance.FieldHeader.Options.UseFont = true;
            this.DgvPivot.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvPivot.Appearance.FieldValue.Options.UseFont = true;
            this.DgvPivot.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvPivot.Appearance.FieldValueGrandTotal.Options.UseFont = true;
            this.DgvPivot.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvPivot.Appearance.FieldValueTotal.Options.UseFont = true;
            this.DgvPivot.Appearance.FilterHeaderArea.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvPivot.Appearance.FilterHeaderArea.Options.UseFont = true;
            this.DgvPivot.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvPivot.Appearance.GrandTotalCell.Options.UseFont = true;
            this.DgvPivot.Appearance.HeaderArea.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvPivot.Appearance.HeaderArea.Options.UseFont = true;
            this.DgvPivot.Appearance.HeaderArea.Options.UseTextOptions = true;
            this.DgvPivot.Appearance.HeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DgvPivot.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvPivot.Appearance.TotalCell.Options.UseFont = true;
            this.DgvPivot.AppearancePrint.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DgvPivot.AppearancePrint.CustomTotalCell.Options.UseFont = true;
            this.DgvPivot.AppearancePrint.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DgvPivot.AppearancePrint.FieldHeader.Options.UseFont = true;
            this.DgvPivot.AppearancePrint.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DgvPivot.AppearancePrint.FieldValueGrandTotal.Options.UseFont = true;
            this.DgvPivot.AppearancePrint.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DgvPivot.AppearancePrint.FieldValueTotal.Options.UseFont = true;
            this.DgvPivot.AppearancePrint.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DgvPivot.AppearancePrint.GrandTotalCell.Options.UseFont = true;
            this.DgvPivot.AppearancePrint.HeaderGroupLine.BackColor = System.Drawing.Color.LightGray;
            this.DgvPivot.AppearancePrint.HeaderGroupLine.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DgvPivot.AppearancePrint.HeaderGroupLine.Options.UseBackColor = true;
            this.DgvPivot.AppearancePrint.HeaderGroupLine.Options.UseFont = true;
            this.DgvPivot.AppearancePrint.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DgvPivot.AppearancePrint.TotalCell.Options.UseFont = true;
            this.DgvPivot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPivot.Location = new System.Drawing.Point(0, 96);
            this.DgvPivot.Name = "DgvPivot";
            this.DgvPivot.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.DgvPivot.OptionsView.ShowColumnTotals = false;
            this.DgvPivot.Size = new System.Drawing.Size(1016, 470);
            this.DgvPivot.TabIndex = 6;
            this.DgvPivot.CustomSummary += new DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventHandler(this.DgvPivot_CustomSummary);
            this.DgvPivot.CustomCellDisplayText += new DevExpress.XtraPivotGrid.PivotCellDisplayTextEventHandler(this.DgvPivot_CustomCellDisplayText);
            this.DgvPivot.CellClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.DgvPivot_CellClick);
            this.DgvPivot.CustomDrawCell += new DevExpress.XtraPivotGrid.PivotCustomDrawCellEventHandler(this.DgvPivot_CustomDrawCell);
            this.DgvPivot.CustomAppearance += new DevExpress.XtraPivotGrid.PivotCustomAppearanceEventHandler(this.DgvPivot_CustomAppearance);
            // 
            // pnlRefresh
            // 
            this.pnlRefresh.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.pnlRefresh.Controls.Add(this.lblDateTime);
            this.pnlRefresh.Controls.Add(this.label3);
            this.pnlRefresh.Controls.Add(this.panelControl1);
            this.pnlRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRefresh.Location = new System.Drawing.Point(0, 25);
            this.pnlRefresh.Name = "pnlRefresh";
            this.pnlRefresh.Size = new System.Drawing.Size(1016, 71);
            this.pnlRefresh.TabIndex = 64;
            // 
            // lblDateTime
            // 
            this.lblDateTime.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateTime.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(102)))), ((int)(((byte)(183)))));
            this.lblDateTime.Appearance.Options.UseFont = true;
            this.lblDateTime.Appearance.Options.UseForeColor = true;
            this.lblDateTime.Appearance.Options.UseTextOptions = true;
            this.lblDateTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblDateTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDateTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDateTime.Location = new System.Drawing.Point(838, 35);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(176, 34);
            this.lblDateTime.TabIndex = 67;
            this.lblDateTime.Text = "Date";
            // 
            // label3
            // 
            this.label3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Appearance.Options.UseFont = true;
            this.label3.Appearance.Options.UseForeColor = true;
            this.label3.Appearance.Options.UseTextOptions = true;
            this.label3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.label3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(838, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 31);
            this.label3.TabIndex = 66;
            this.label3.Text = "Print";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.panelControl1.Controls.Add(this.PictureActivator);
            this.panelControl1.Controls.Add(this.lblGroupBy);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.lblReportHeader);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.lblFilter);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(836, 67);
            this.panelControl1.TabIndex = 65;
            // 
            // PictureActivator
            // 
            this.PictureActivator.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureActivator.Location = new System.Drawing.Point(588, 33);
            this.PictureActivator.Name = "PictureActivator";
            this.PictureActivator.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.PictureActivator.Size = new System.Drawing.Size(30, 30);
            this.PictureActivator.TabIndex = 37;
            // 
            // lblGroupBy
            // 
            this.lblGroupBy.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupBy.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(102)))), ((int)(((byte)(183)))));
            this.lblGroupBy.Appearance.Options.UseFont = true;
            this.lblGroupBy.Appearance.Options.UseForeColor = true;
            this.lblGroupBy.Location = new System.Drawing.Point(571, 5);
            this.lblGroupBy.Name = "lblGroupBy";
            this.lblGroupBy.Size = new System.Drawing.Size(56, 14);
            this.lblGroupBy.TabIndex = 33;
            this.lblGroupBy.Text = "Group By";
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.label2.Appearance.Options.UseFont = true;
            this.label2.Appearance.Options.UseForeColor = true;
            this.label2.Location = new System.Drawing.Point(501, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 32;
            this.label2.Text = "Group By :";
            // 
            // lblReportHeader
            // 
            this.lblReportHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblReportHeader.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(102)))), ((int)(((byte)(183)))));
            this.lblReportHeader.Appearance.Options.UseFont = true;
            this.lblReportHeader.Appearance.Options.UseForeColor = true;
            this.lblReportHeader.Location = new System.Drawing.Point(100, 5);
            this.lblReportHeader.Name = "lblReportHeader";
            this.lblReportHeader.Size = new System.Drawing.Size(80, 14);
            this.lblReportHeader.TabIndex = 30;
            this.lblReportHeader.Text = "Report Name";
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Appearance.Options.UseForeColor = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 14);
            this.label1.TabIndex = 29;
            this.label1.Text = "Report Name :";
            // 
            // lblFilter
            // 
            this.lblFilter.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilter.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(102)))), ((int)(((byte)(183)))));
            this.lblFilter.Appearance.Options.UseFont = true;
            this.lblFilter.Appearance.Options.UseForeColor = true;
            this.lblFilter.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFilter.Location = new System.Drawing.Point(2, 18);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(832, 47);
            this.lblFilter.TabIndex = 34;
            this.lblFilter.Text = "Filter By";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.OrientationToolStripMenuItem,
            this.cmbOrientation,
            this.ExpandAllGroupsToolStripMenuItem,
            this.cmbExpand,
            this.ExpandTool,
            this.Collapse,
            this.AToolStripMenuItem,
            this.MNRemoveGroup,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 25);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "MenuStrip1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintToolStripMenuItem,
            this.toolStripMenuItem4,
            this.EmailToolStripMenuItem});
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(98, 21);
            this.toolStripMenuItem2.Text = "Print && Export";
            // 
            // PrintToolStripMenuItem
            // 
            this.PrintToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem";
            this.PrintToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.PrintToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.PrintToolStripMenuItem.Text = "Print";
            this.PrintToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToExcel,
            this.ToText,
            this.ToHTML,
            this.ToRTF,
            this.ToPDF});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuItem4.Text = "Export";
            // 
            // ToExcel
            // 
            this.ToExcel.Name = "ToExcel";
            this.ToExcel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.ToExcel.Size = new System.Drawing.Size(162, 22);
            this.ToExcel.Tag = "Excel";
            this.ToExcel.Text = "To Excel";
            this.ToExcel.Click += new System.EventHandler(this.ToExcel_Click);
            // 
            // ToText
            // 
            this.ToText.Name = "ToText";
            this.ToText.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.ToText.Size = new System.Drawing.Size(162, 22);
            this.ToText.Text = "To Text";
            this.ToText.Visible = false;
            this.ToText.Click += new System.EventHandler(this.ToText_Click);
            // 
            // ToHTML
            // 
            this.ToHTML.Name = "ToHTML";
            this.ToHTML.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.ToHTML.Size = new System.Drawing.Size(162, 22);
            this.ToHTML.Text = "To HTML";
            this.ToHTML.Visible = false;
            this.ToHTML.Click += new System.EventHandler(this.ToHTML_Click);
            // 
            // ToRTF
            // 
            this.ToRTF.Name = "ToRTF";
            this.ToRTF.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.ToRTF.Size = new System.Drawing.Size(162, 22);
            this.ToRTF.Text = "To RTF";
            this.ToRTF.Visible = false;
            this.ToRTF.Click += new System.EventHandler(this.ToRTF_Click);
            // 
            // ToPDF
            // 
            this.ToPDF.Name = "ToPDF";
            this.ToPDF.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.ToPDF.Size = new System.Drawing.Size(162, 22);
            this.ToPDF.Text = "To PDF";
            this.ToPDF.Click += new System.EventHandler(this.ToPDF_Click);
            // 
            // EmailToolStripMenuItem
            // 
            this.EmailToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.EmailToolStripMenuItem.Name = "EmailToolStripMenuItem";
            this.EmailToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.EmailToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.EmailToolStripMenuItem.Text = "Email";
            this.EmailToolStripMenuItem.Click += new System.EventHandler(this.EmailToolStripMenuItem_Click);
            // 
            // OrientationToolStripMenuItem
            // 
            this.OrientationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.OrientationToolStripMenuItem.Name = "OrientationToolStripMenuItem";
            this.OrientationToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
            this.OrientationToolStripMenuItem.Text = "Orientation";
            // 
            // cmbOrientation
            // 
            this.cmbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrientation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbOrientation.ForeColor = System.Drawing.Color.Black;
            this.cmbOrientation.Items.AddRange(new object[] {
            "Landscape",
            "Portrait"});
            this.cmbOrientation.Name = "cmbOrientation";
            this.cmbOrientation.Size = new System.Drawing.Size(121, 21);
            // 
            // ExpandAllGroupsToolStripMenuItem
            // 
            this.ExpandAllGroupsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ExpandAllGroupsToolStripMenuItem.Name = "ExpandAllGroupsToolStripMenuItem";
            this.ExpandAllGroupsToolStripMenuItem.Size = new System.Drawing.Size(120, 21);
            this.ExpandAllGroupsToolStripMenuItem.Text = "Expand All Groups";
            // 
            // cmbExpand
            // 
            this.cmbExpand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExpand.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbExpand.ForeColor = System.Drawing.Color.Black;
            this.cmbExpand.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbExpand.Name = "cmbExpand";
            this.cmbExpand.Size = new System.Drawing.Size(121, 21);
            // 
            // ExpandTool
            // 
            this.ExpandTool.ForeColor = System.Drawing.Color.White;
            this.ExpandTool.Name = "ExpandTool";
            this.ExpandTool.Size = new System.Drawing.Size(60, 21);
            this.ExpandTool.Text = "Expand";
            this.ExpandTool.Click += new System.EventHandler(this.ExpandTool_Click);
            // 
            // Collapse
            // 
            this.Collapse.ForeColor = System.Drawing.Color.White;
            this.Collapse.Name = "Collapse";
            this.Collapse.Size = new System.Drawing.Size(66, 21);
            this.Collapse.Text = "Collapse";
            this.Collapse.Click += new System.EventHandler(this.Collapse_Click);
            // 
            // AToolStripMenuItem
            // 
            this.AToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.AToolStripMenuItem.Name = "AToolStripMenuItem";
            this.AToolStripMenuItem.Size = new System.Drawing.Size(127, 21);
            this.AToolStripMenuItem.Text = "Auto Column Width";
            this.AToolStripMenuItem.Click += new System.EventHandler(this.AToolStripMenuItem_Click);
            // 
            // MNRemoveGroup
            // 
            this.MNRemoveGroup.ForeColor = System.Drawing.Color.White;
            this.MNRemoveGroup.Name = "MNRemoveGroup";
            this.MNRemoveGroup.Size = new System.Drawing.Size(103, 21);
            this.MNRemoveGroup.Text = "Disable Groups";
            this.MNRemoveGroup.Click += new System.EventHandler(this.MNRemoveGroup_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(40, 21);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // FrmPReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 566);
            this.Controls.Add(this.DgvPivot);
            this.Controls.Add(this.pnlRefresh);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FrmPReportViewer";
            this.Text = "REPORT VIEWER";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PrintingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPivot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRefresh)).EndInit();
            this.pnlRefresh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureActivator.Properties)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraPrinting.PrintingSystem PrintingSystem1;
        public DevExpress.XtraPivotGrid.PivotGridControl DgvPivot;
        private DevExpress.XtraEditors.PanelControl pnlRefresh;
        internal System.Windows.Forms.MenuStrip menuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem PrintToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem ToExcel;
        internal System.Windows.Forms.ToolStripMenuItem ToText;
        internal System.Windows.Forms.ToolStripMenuItem ToHTML;
        internal System.Windows.Forms.ToolStripMenuItem ToRTF;
        internal System.Windows.Forms.ToolStripMenuItem ToPDF;
        internal System.Windows.Forms.ToolStripMenuItem EmailToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem OrientationToolStripMenuItem;
        public System.Windows.Forms.ToolStripComboBox cmbOrientation;
        internal System.Windows.Forms.ToolStripMenuItem ExpandAllGroupsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripComboBox cmbExpand;
        internal System.Windows.Forms.ToolStripMenuItem ExpandTool;
        internal System.Windows.Forms.ToolStripMenuItem Collapse;
        internal System.Windows.Forms.ToolStripMenuItem AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MNRemoveGroup;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private DevExpress.XtraEditors.PictureEdit PictureActivator;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        internal DevExpress.XtraEditors.LabelControl lblGroupBy;
        internal DevExpress.XtraEditors.LabelControl label2;
        internal DevExpress.XtraEditors.LabelControl lblReportHeader;
        internal DevExpress.XtraEditors.LabelControl label1;
        internal DevExpress.XtraEditors.LabelControl lblFilter;
        internal DevExpress.XtraEditors.LabelControl lblDateTime;
        internal DevExpress.XtraEditors.LabelControl label3;
    }
}