namespace Account_Management.Report
{
    partial class FrmAccountLedger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccountLedger));
            this.PrintingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.GridMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.ToExcelx = new System.Windows.Forms.ToolStripMenuItem();
            this.ToExcelXlsxFast = new System.Windows.Forms.ToolStripMenuItem();
            this.ToText = new System.Windows.Forms.ToolStripMenuItem();
            this.ToHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.ToRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.ToPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.EmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.CmbPageKind = new System.Windows.Forms.ToolStripComboBox();
            this.cmbOrientation = new System.Windows.Forms.ToolStripComboBox();
            this.ExpandAllGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbExpand = new System.Windows.Forms.ToolStripComboBox();
            this.ExpandTool = new System.Windows.Forms.ToolStripMenuItem();
            this.Collapse = new System.Windows.Forms.ToolStripMenuItem();
            this.AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MNRemoveGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MNGroupEnableDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.MNFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.MNColumnChooser = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmExportData = new System.Windows.Forms.ToolStripMenuItem();
            this.MNUExit = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker_HRReport = new System.ComponentModel.BackgroundWorker();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dtpToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtpFromDate = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lueLedger = new DevExpress.XtraEditors.LookUpEdit();
            this.label32 = new System.Windows.Forms.Label();
            this.BtnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.BtnReset = new DevExpress.XtraEditors.SimpleButton();
            this.BtnExport = new DevExpress.XtraEditors.SimpleButton();
            this.BtnGenerateReport = new DevExpress.XtraEditors.SimpleButton();
            this.GrdAccountLedger = new DevExpress.XtraGrid.GridControl();
            this.DgvAccountLedger = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.PrintingSystem1)).BeginInit();
            this.GridMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLedger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdAccountLedger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAccountLedger)).BeginInit();
            this.SuspendLayout();
            // 
            // GridMenuStrip
            // 
            this.GridMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.GridMenuStrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem12,
            this.CmbPageKind,
            this.cmbOrientation,
            this.ExpandAllGroupsToolStripMenuItem,
            this.cmbExpand,
            this.ExpandTool,
            this.Collapse,
            this.AToolStripMenuItem,
            this.MNRemoveGroup,
            this.MNUExit});
            this.GridMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.GridMenuStrip.Name = "GridMenuStrip";
            this.GridMenuStrip.Size = new System.Drawing.Size(1304, 25);
            this.GridMenuStrip.TabIndex = 35;
            this.GridMenuStrip.Text = "MenuStrip1";
            this.GridMenuStrip.Visible = false;
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
            this.ToExcelx,
            this.ToExcelXlsxFast,
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
            this.ToExcel.Size = new System.Drawing.Size(256, 22);
            this.ToExcel.Tag = "Excel";
            this.ToExcel.Text = "To Excel 97-2003 (.xls)";
            this.ToExcel.Click += new System.EventHandler(this.ToExcel_Click);
            // 
            // ToExcelx
            // 
            this.ToExcelx.Name = "ToExcelx";
            this.ToExcelx.Size = new System.Drawing.Size(256, 22);
            this.ToExcelx.Text = "To Excel 2007 Onwards (.xlsx)";
            this.ToExcelx.Click += new System.EventHandler(this.ToExcelx_Click);
            // 
            // ToExcelXlsxFast
            // 
            this.ToExcelXlsxFast.Name = "ToExcelXlsxFast";
            this.ToExcelXlsxFast.Size = new System.Drawing.Size(256, 22);
            this.ToExcelXlsxFast.Text = "To Excel Fast Without Formating";
            this.ToExcelXlsxFast.ToolTipText = "Use when data less then 60000.Without Formula And Grouping. Only Column Row forma" +
    "t.";
            this.ToExcelXlsxFast.Visible = false;
            // 
            // ToText
            // 
            this.ToText.Name = "ToText";
            this.ToText.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.ToText.Size = new System.Drawing.Size(256, 22);
            this.ToText.Text = "To Text";
            this.ToText.Visible = false;
            this.ToText.Click += new System.EventHandler(this.ToText_Click);
            // 
            // ToHTML
            // 
            this.ToHTML.Name = "ToHTML";
            this.ToHTML.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.ToHTML.Size = new System.Drawing.Size(256, 22);
            this.ToHTML.Text = "To HTML";
            this.ToHTML.Visible = false;
            this.ToHTML.Click += new System.EventHandler(this.ToHTML_Click);
            // 
            // ToRTF
            // 
            this.ToRTF.Name = "ToRTF";
            this.ToRTF.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.ToRTF.Size = new System.Drawing.Size(256, 22);
            this.ToRTF.Text = "To RTF";
            this.ToRTF.Visible = false;
            this.ToRTF.Click += new System.EventHandler(this.ToRTF_Click);
            // 
            // ToPDF
            // 
            this.ToPDF.Name = "ToPDF";
            this.ToPDF.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.ToPDF.Size = new System.Drawing.Size(256, 22);
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
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(83, 21);
            this.toolStripMenuItem12.Text = "Orientation";
            // 
            // CmbPageKind
            // 
            this.CmbPageKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPageKind.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.CmbPageKind.ForeColor = System.Drawing.Color.Black;
            this.CmbPageKind.Items.AddRange(new object[] {
            "Landscape",
            "Portrait"});
            this.CmbPageKind.Name = "CmbPageKind";
            this.CmbPageKind.Size = new System.Drawing.Size(121, 21);
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
            this.MNRemoveGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MNGroupEnableDisable,
            this.MNFilter,
            this.MNColumnChooser,
            this.TsmExportData});
            this.MNRemoveGroup.ForeColor = System.Drawing.Color.White;
            this.MNRemoveGroup.Name = "MNRemoveGroup";
            this.MNRemoveGroup.Size = new System.Drawing.Size(53, 21);
            this.MNRemoveGroup.Text = "Utility";
            // 
            // MNGroupEnableDisable
            // 
            this.MNGroupEnableDisable.BackColor = System.Drawing.Color.White;
            this.MNGroupEnableDisable.Name = "MNGroupEnableDisable";
            this.MNGroupEnableDisable.Size = new System.Drawing.Size(201, 22);
            this.MNGroupEnableDisable.Text = "Group Enable / Disable";
            this.MNGroupEnableDisable.Click += new System.EventHandler(this.MNGroupEnableDisable_Click);
            // 
            // MNFilter
            // 
            this.MNFilter.BackColor = System.Drawing.Color.White;
            this.MNFilter.Name = "MNFilter";
            this.MNFilter.Size = new System.Drawing.Size(201, 22);
            this.MNFilter.Text = "Add Filter";
            this.MNFilter.Click += new System.EventHandler(this.MNFilter_Click);
            // 
            // MNColumnChooser
            // 
            this.MNColumnChooser.BackColor = System.Drawing.Color.White;
            this.MNColumnChooser.Name = "MNColumnChooser";
            this.MNColumnChooser.Size = new System.Drawing.Size(201, 22);
            this.MNColumnChooser.Text = "Column Chooser";
            // 
            // TsmExportData
            // 
            this.TsmExportData.BackColor = System.Drawing.Color.White;
            this.TsmExportData.Name = "TsmExportData";
            this.TsmExportData.Size = new System.Drawing.Size(201, 22);
            this.TsmExportData.Text = "Export Data";
            this.TsmExportData.Visible = false;
            this.TsmExportData.Click += new System.EventHandler(this.TsmExportData_Click);
            // 
            // MNUExit
            // 
            this.MNUExit.ForeColor = System.Drawing.Color.White;
            this.MNUExit.Name = "MNUExit";
            this.MNUExit.Size = new System.Drawing.Size(40, 21);
            this.MNUExit.Text = "Exit";
            this.MNUExit.Click += new System.EventHandler(this.MNUExit_Click);
            // 
            // backgroundWorker_HRReport
            // 
            this.backgroundWorker_HRReport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_HRReport_DoWork);
            this.backgroundWorker_HRReport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_HRReport_RunWorkerCompleted);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.panelControl2.Controls.Add(this.dtpToDate);
            this.panelControl2.Controls.Add(this.dtpFromDate);
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Controls.Add(this.lueLedger);
            this.panelControl2.Controls.Add(this.label32);
            this.panelControl2.Controls.Add(this.BtnPrint);
            this.panelControl2.Controls.Add(this.BtnReset);
            this.panelControl2.Controls.Add(this.BtnExport);
            this.panelControl2.Controls.Add(this.BtnGenerateReport);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1304, 49);
            this.panelControl2.TabIndex = 65;
            // 
            // dtpToDate
            // 
            this.dtpToDate.EditValue = null;
            this.dtpToDate.Location = new System.Drawing.Point(307, 13);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold);
            this.dtpToDate.Properties.Appearance.Options.UseFont = true;
            this.dtpToDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold);
            this.dtpToDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpToDate.Size = new System.Drawing.Size(119, 20);
            this.dtpToDate.TabIndex = 71;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.EditValue = null;
            this.dtpFromDate.Location = new System.Drawing.Point(103, 13);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold);
            this.dtpFromDate.Properties.Appearance.Options.UseFont = true;
            this.dtpFromDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold);
            this.dtpFromDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFromDate.Size = new System.Drawing.Size(119, 20);
            this.dtpFromDate.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(228, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 69;
            this.label2.Text = "To Date : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 68;
            this.label1.Text = "From Date : ";
            // 
            // lueLedger
            // 
            this.lueLedger.EnterMoveNextControl = true;
            this.lueLedger.Location = new System.Drawing.Point(504, 13);
            this.lueLedger.Name = "lueLedger";
            this.lueLedger.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueLedger.Properties.Appearance.Options.UseFont = true;
            this.lueLedger.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold);
            this.lueLedger.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueLedger.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueLedger.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueLedger.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueLedger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.lueLedger.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ledger_name", "Ledger Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ledger_id", "Ledger ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueLedger.Properties.NullText = "";
            this.lueLedger.Properties.ShowHeader = false;
            this.lueLedger.Size = new System.Drawing.Size(229, 20);
            this.lueLedger.TabIndex = 66;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.label32.Location = new System.Drawing.Point(432, 15);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(67, 16);
            this.label32.TabIndex = 67;
            this.label32.Text = "Account";
            // 
            // BtnPrint
            // 
            this.BtnPrint.Appearance.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrint.Appearance.Options.UseFont = true;
            this.BtnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrint.ImageOptions.Image")));
            this.BtnPrint.Location = new System.Drawing.Point(885, 5);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(41, 37);
            this.BtnPrint.TabIndex = 11;
            this.BtnPrint.TabStop = false;
            this.BtnPrint.ToolTip = "To Print";
            this.BtnPrint.Visible = false;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.Appearance.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.Appearance.Options.UseFont = true;
            this.BtnReset.ImageOptions.Image = global::Account_Management.Properties.Resources.Clear;
            this.BtnReset.Location = new System.Drawing.Point(791, 5);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(41, 37);
            this.BtnReset.TabIndex = 9;
            this.BtnReset.TabStop = false;
            this.BtnReset.ToolTip = "To Clear";
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Appearance.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExport.Appearance.Options.UseFont = true;
            this.BtnExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExport.ImageOptions.Image")));
            this.BtnExport.Location = new System.Drawing.Point(838, 5);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(41, 37);
            this.BtnExport.TabIndex = 10;
            this.BtnExport.TabStop = false;
            this.BtnExport.ToolTip = "To Export to Excel";
            this.BtnExport.Visible = false;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // BtnGenerateReport
            // 
            this.BtnGenerateReport.Appearance.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerateReport.Appearance.Options.UseFont = true;
            this.BtnGenerateReport.ImageOptions.Image = global::Account_Management.Properties.Resources.Report_final;
            this.BtnGenerateReport.Location = new System.Drawing.Point(744, 5);
            this.BtnGenerateReport.Name = "BtnGenerateReport";
            this.BtnGenerateReport.Size = new System.Drawing.Size(39, 37);
            this.BtnGenerateReport.TabIndex = 8;
            this.BtnGenerateReport.TabStop = false;
            this.BtnGenerateReport.ToolTip = "To Generate Report";
            this.BtnGenerateReport.Click += new System.EventHandler(this.BtnGenerateReport_Click);
            // 
            // GrdAccountLedger
            // 
            this.GrdAccountLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdAccountLedger.Location = new System.Drawing.Point(0, 49);
            this.GrdAccountLedger.MainView = this.DgvAccountLedger;
            this.GrdAccountLedger.Name = "GrdAccountLedger";
            this.GrdAccountLedger.Size = new System.Drawing.Size(1304, 625);
            this.GrdAccountLedger.TabIndex = 66;
            this.GrdAccountLedger.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DgvAccountLedger});
            // 
            // DgvAccountLedger
            // 
            this.DgvAccountLedger.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.DgvAccountLedger.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.DgvAccountLedger.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.DgvAccountLedger.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold);
            this.DgvAccountLedger.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.DgvAccountLedger.Appearance.FooterPanel.Options.UseFont = true;
            this.DgvAccountLedger.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold);
            this.DgvAccountLedger.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.DgvAccountLedger.Appearance.HeaderPanel.Options.UseFont = true;
            this.DgvAccountLedger.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.DgvAccountLedger.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DgvAccountLedger.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.DgvAccountLedger.Appearance.Row.Options.UseFont = true;
            this.DgvAccountLedger.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn4,
            this.bandedGridColumn5,
            this.bandedGridColumn6,
            this.bandedGridColumn7,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.DgvAccountLedger.GridControl = this.GrdAccountLedger;
            this.DgvAccountLedger.GroupFormat = "{1} {2}";
            this.DgvAccountLedger.Name = "DgvAccountLedger";
            this.DgvAccountLedger.OptionsBehavior.AutoExpandAllGroups = true;
            this.DgvAccountLedger.OptionsBehavior.Editable = false;
            this.DgvAccountLedger.OptionsPrint.AutoResetPrintDocument = false;
            this.DgvAccountLedger.OptionsPrint.AutoWidth = false;
            this.DgvAccountLedger.OptionsPrint.ExpandAllGroups = false;
            this.DgvAccountLedger.OptionsSelection.MultiSelect = true;
            this.DgvAccountLedger.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.DgvAccountLedger.OptionsView.ColumnAutoWidth = false;
            this.DgvAccountLedger.OptionsView.EnableAppearanceEvenRow = true;
            this.DgvAccountLedger.OptionsView.EnableAppearanceOddRow = true;
            this.DgvAccountLedger.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.DgvAccountLedger.OptionsView.ShowAutoFilterRow = true;
            this.DgvAccountLedger.OptionsView.ShowFooter = true;
            this.DgvAccountLedger.OptionsView.ShowGroupPanel = false;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "Date";
            this.bandedGridColumn1.FieldName = "invoice_date";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn1.VisibleIndex = 0;
            this.bandedGridColumn1.Width = 84;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.Caption = "Type";
            this.bandedGridColumn2.FieldName = "type";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.VisibleIndex = 1;
            this.bandedGridColumn2.Width = 78;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.Caption = "Vch/Bill No";
            this.bandedGridColumn3.FieldName = "invoice_no";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            this.bandedGridColumn3.VisibleIndex = 2;
            this.bandedGridColumn3.Width = 96;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "Debit(Rs.)";
            this.bandedGridColumn4.FieldName = "debit_amount";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.bandedGridColumn4.Visible = true;
            this.bandedGridColumn4.VisibleIndex = 4;
            this.bandedGridColumn4.Width = 101;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.Caption = "Credit(Rs.)";
            this.bandedGridColumn5.FieldName = "credit_amount";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.bandedGridColumn5.Visible = true;
            this.bandedGridColumn5.VisibleIndex = 5;
            this.bandedGridColumn5.Width = 101;
            // 
            // bandedGridColumn6
            // 
            this.bandedGridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.bandedGridColumn6.Caption = "Balance(Rs.)";
            this.bandedGridColumn6.FieldName = "balance_";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.Visible = true;
            this.bandedGridColumn6.VisibleIndex = 6;
            this.bandedGridColumn6.Width = 101;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn7.Caption = "Short Narration";
            this.bandedGridColumn7.FieldName = "remarks";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.Visible = true;
            this.bandedGridColumn7.VisibleIndex = 7;
            this.bandedGridColumn7.Width = 353;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Account";
            this.gridColumn1.FieldName = "account";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 205;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Invoice ID";
            this.gridColumn2.FieldName = "invoice_id";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Payment ID";
            this.gridColumn3.FieldName = "payment_id";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // FrmAccountLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 674);
            this.Controls.Add(this.GrdAccountLedger);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.GridMenuStrip);
            this.KeyPreview = true;
            this.Name = "FrmAccountLedger";
            this.Text = "ACCOUNT LEDGER";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmGReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PrintingSystem1)).EndInit();
            this.GridMenuStrip.ResumeLayout(false);
            this.GridMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLedger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdAccountLedger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAccountLedger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraPrinting.PrintingSystem PrintingSystem1;
        internal System.Windows.Forms.MenuStrip GridMenuStrip;
        internal System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem PrintToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        internal System.Windows.Forms.ToolStripMenuItem ToExcel;
        private System.Windows.Forms.ToolStripMenuItem ToExcelx;
        internal System.Windows.Forms.ToolStripMenuItem ToText;
        internal System.Windows.Forms.ToolStripMenuItem ToHTML;
        internal System.Windows.Forms.ToolStripMenuItem ToRTF;
        internal System.Windows.Forms.ToolStripMenuItem ToPDF;
        internal System.Windows.Forms.ToolStripMenuItem EmailToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        public System.Windows.Forms.ToolStripComboBox CmbPageKind;
        public System.Windows.Forms.ToolStripComboBox cmbOrientation;
        internal System.Windows.Forms.ToolStripMenuItem ExpandAllGroupsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripComboBox cmbExpand;
        internal System.Windows.Forms.ToolStripMenuItem ExpandTool;
        internal System.Windows.Forms.ToolStripMenuItem Collapse;
        internal System.Windows.Forms.ToolStripMenuItem AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MNRemoveGroup;
        private System.Windows.Forms.ToolStripMenuItem MNGroupEnableDisable;
        private System.Windows.Forms.ToolStripMenuItem MNFilter;
        private System.Windows.Forms.ToolStripMenuItem MNColumnChooser;
        private System.Windows.Forms.ToolStripMenuItem TsmExportData;
        private System.Windows.Forms.ToolStripMenuItem MNUExit;
        private System.Windows.Forms.ToolStripMenuItem ToExcelXlsxFast;
        private System.ComponentModel.BackgroundWorker backgroundWorker_HRReport;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton BtnPrint;
        private DevExpress.XtraEditors.SimpleButton BtnReset;
        private DevExpress.XtraEditors.SimpleButton BtnExport;
        private DevExpress.XtraEditors.SimpleButton BtnGenerateReport;
        public DevExpress.XtraGrid.GridControl GrdAccountLedger;
        private DevExpress.XtraEditors.LookUpEdit lueLedger;
        private System.Windows.Forms.Label label32;
        private DevExpress.XtraEditors.DateEdit dtpToDate;
        private DevExpress.XtraEditors.DateEdit dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Views.Grid.GridView DgvAccountLedger;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}