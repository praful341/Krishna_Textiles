namespace Account_Management.Transaction
{
    partial class FrmDispatchEntry
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.grdDispatchEntry = new DevExpress.XtraGrid.GridControl();
            this.ContextMNExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MNExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportTEXT = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvDispatchEntry = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clmDispatchID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmInvoiceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmInvoiceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmDispatchDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepRecDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.clmFromCourierID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepFromCourier = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.clmToCourierID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepToCourier = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.clmAWBNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmPaidAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmShippigAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.clmRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.CmbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtpFromDate = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.backgroundWorker_DispatchEntry = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDispatchEntry)).BeginInit();
            this.ContextMNExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispatchEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepRecDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepRecDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepFromCourier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepToCourier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.panelControl4);
            this.panelControl3.Controls.Add(this.panelControl1);
            this.panelControl3.Controls.Add(this.panelControl2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1008, 673);
            this.panelControl3.TabIndex = 99;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.grdDispatchEntry);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(2, 51);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(1004, 576);
            this.panelControl4.TabIndex = 103;
            // 
            // grdDispatchEntry
            // 
            this.grdDispatchEntry.ContextMenuStrip = this.ContextMNExport;
            this.grdDispatchEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDispatchEntry.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridLevelNode1.RelationName = "Level1";
            this.grdDispatchEntry.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdDispatchEntry.Location = new System.Drawing.Point(2, 2);
            this.grdDispatchEntry.MainView = this.dgvDispatchEntry;
            this.grdDispatchEntry.Name = "grdDispatchEntry";
            this.grdDispatchEntry.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepRecDate,
            this.RepFromCourier,
            this.RepToCourier,
            this.RepStatus});
            this.grdDispatchEntry.Size = new System.Drawing.Size(1000, 572);
            this.grdDispatchEntry.TabIndex = 100;
            this.grdDispatchEntry.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDispatchEntry});
            // 
            // ContextMNExport
            // 
            this.ContextMNExport.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.ContextMNExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MNExportExcel,
            this.MNExportPDF,
            this.MNExportTEXT,
            this.MNExportHTML,
            this.MNExportRTF,
            this.MNExportCSV});
            this.ContextMNExport.Name = "ContextExport";
            this.ContextMNExport.Size = new System.Drawing.Size(130, 136);
            // 
            // MNExportExcel
            // 
            this.MNExportExcel.Name = "MNExportExcel";
            this.MNExportExcel.Size = new System.Drawing.Size(129, 22);
            this.MNExportExcel.Text = "To Excel";
            this.MNExportExcel.Click += new System.EventHandler(this.MNExportExcel_Click);
            // 
            // MNExportPDF
            // 
            this.MNExportPDF.Name = "MNExportPDF";
            this.MNExportPDF.Size = new System.Drawing.Size(129, 22);
            this.MNExportPDF.Text = "To PDF";
            this.MNExportPDF.Click += new System.EventHandler(this.MNExportPDF_Click);
            // 
            // MNExportTEXT
            // 
            this.MNExportTEXT.Name = "MNExportTEXT";
            this.MNExportTEXT.Size = new System.Drawing.Size(129, 22);
            this.MNExportTEXT.Text = "To TEXT";
            // 
            // MNExportHTML
            // 
            this.MNExportHTML.Name = "MNExportHTML";
            this.MNExportHTML.Size = new System.Drawing.Size(129, 22);
            this.MNExportHTML.Text = "To HTML";
            // 
            // MNExportRTF
            // 
            this.MNExportRTF.Name = "MNExportRTF";
            this.MNExportRTF.Size = new System.Drawing.Size(129, 22);
            this.MNExportRTF.Text = "To RTF";
            // 
            // MNExportCSV
            // 
            this.MNExportCSV.Name = "MNExportCSV";
            this.MNExportCSV.Size = new System.Drawing.Size(129, 22);
            this.MNExportCSV.Text = "To CSV";
            // 
            // dgvDispatchEntry
            // 
            this.dgvDispatchEntry.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.dgvDispatchEntry.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.dgvDispatchEntry.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.dgvDispatchEntry.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.dgvDispatchEntry.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.dgvDispatchEntry.Appearance.FooterPanel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvDispatchEntry.Appearance.FooterPanel.Options.UseFont = true;
            this.dgvDispatchEntry.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvDispatchEntry.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgvDispatchEntry.Appearance.Row.Font = new System.Drawing.Font("Cambria", 9F);
            this.dgvDispatchEntry.Appearance.Row.Options.UseFont = true;
            this.dgvDispatchEntry.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clmDispatchID,
            this.clmInvoiceId,
            this.clmInvoiceDate,
            this.clmOrderNo,
            this.clmEmployeeID,
            this.clmEmployeeName,
            this.clmWeight,
            this.clmDispatchDate,
            this.clmFromCourierID,
            this.clmToCourierID,
            this.clmAWBNo,
            this.clmPaidAmt,
            this.clmShippigAmt,
            this.clmStatus,
            this.clmRemark});
            this.dgvDispatchEntry.GridControl = this.grdDispatchEntry;
            this.dgvDispatchEntry.Name = "dgvDispatchEntry";
            this.dgvDispatchEntry.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvDispatchEntry.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvDispatchEntry.OptionsCustomization.AllowColumnMoving = false;
            this.dgvDispatchEntry.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvDispatchEntry.OptionsNavigation.EnterMoveNextColumn = true;
            this.dgvDispatchEntry.OptionsView.ColumnAutoWidth = false;
            this.dgvDispatchEntry.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.dgvDispatchEntry.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.dgvDispatchEntry.OptionsView.ShowAutoFilterRow = true;
            this.dgvDispatchEntry.OptionsView.ShowFooter = true;
            this.dgvDispatchEntry.OptionsView.ShowGroupedColumns = true;
            this.dgvDispatchEntry.OptionsView.ShowGroupPanel = false;
            this.dgvDispatchEntry.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.dgvDispatchEntry_FocusedColumnChanged);
            // 
            // clmDispatchID
            // 
            this.clmDispatchID.Caption = "DISPATCH ID";
            this.clmDispatchID.FieldName = "dispatch_id";
            this.clmDispatchID.Name = "clmDispatchID";
            this.clmDispatchID.OptionsColumn.AllowEdit = false;
            this.clmDispatchID.OptionsColumn.AllowFocus = false;
            this.clmDispatchID.OptionsColumn.AllowMove = false;
            this.clmDispatchID.Width = 89;
            // 
            // clmInvoiceId
            // 
            this.clmInvoiceId.Caption = "INVOICE ID";
            this.clmInvoiceId.FieldName = "invoice_id";
            this.clmInvoiceId.Name = "clmInvoiceId";
            this.clmInvoiceId.OptionsColumn.AllowEdit = false;
            this.clmInvoiceId.OptionsColumn.AllowFocus = false;
            this.clmInvoiceId.OptionsColumn.AllowMove = false;
            // 
            // clmInvoiceDate
            // 
            this.clmInvoiceDate.Caption = "ORDER DATE";
            this.clmInvoiceDate.FieldName = "invoice_date";
            this.clmInvoiceDate.Name = "clmInvoiceDate";
            this.clmInvoiceDate.OptionsColumn.AllowEdit = false;
            this.clmInvoiceDate.OptionsColumn.AllowFocus = false;
            this.clmInvoiceDate.OptionsColumn.AllowMove = false;
            this.clmInvoiceDate.Visible = true;
            this.clmInvoiceDate.VisibleIndex = 0;
            this.clmInvoiceDate.Width = 100;
            // 
            // clmOrderNo
            // 
            this.clmOrderNo.Caption = "ORDER NO";
            this.clmOrderNo.FieldName = "order_no";
            this.clmOrderNo.Name = "clmOrderNo";
            this.clmOrderNo.OptionsColumn.AllowEdit = false;
            this.clmOrderNo.OptionsColumn.AllowFocus = false;
            this.clmOrderNo.OptionsColumn.AllowMove = false;
            this.clmOrderNo.Visible = true;
            this.clmOrderNo.VisibleIndex = 1;
            // 
            // clmEmployeeID
            // 
            this.clmEmployeeID.Caption = "EMPLOYEE ID";
            this.clmEmployeeID.FieldName = "employee_id";
            this.clmEmployeeID.Name = "clmEmployeeID";
            this.clmEmployeeID.OptionsColumn.AllowEdit = false;
            this.clmEmployeeID.OptionsColumn.AllowFocus = false;
            this.clmEmployeeID.OptionsColumn.AllowMove = false;
            this.clmEmployeeID.Width = 91;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Caption = "EMPLOYEE NAME";
            this.clmEmployeeName.FieldName = "employee_name";
            this.clmEmployeeName.Name = "clmEmployeeName";
            this.clmEmployeeName.OptionsColumn.AllowEdit = false;
            this.clmEmployeeName.OptionsColumn.AllowFocus = false;
            this.clmEmployeeName.OptionsColumn.AllowMove = false;
            this.clmEmployeeName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.clmEmployeeName.Visible = true;
            this.clmEmployeeName.VisibleIndex = 2;
            this.clmEmployeeName.Width = 140;
            // 
            // clmWeight
            // 
            this.clmWeight.AppearanceCell.Options.UseTextOptions = true;
            this.clmWeight.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.clmWeight.AppearanceHeader.Options.UseTextOptions = true;
            this.clmWeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.clmWeight.Caption = "WEIGHT";
            this.clmWeight.FieldName = "weight";
            this.clmWeight.Name = "clmWeight";
            this.clmWeight.OptionsColumn.AllowEdit = false;
            this.clmWeight.OptionsColumn.AllowFocus = false;
            this.clmWeight.OptionsColumn.AllowMove = false;
            this.clmWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clmWeight.Visible = true;
            this.clmWeight.VisibleIndex = 3;
            this.clmWeight.Width = 87;
            // 
            // clmDispatchDate
            // 
            this.clmDispatchDate.Caption = "DISPATCH DATE";
            this.clmDispatchDate.ColumnEdit = this.RepRecDate;
            this.clmDispatchDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.clmDispatchDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clmDispatchDate.FieldName = "dispatch_date";
            this.clmDispatchDate.Name = "clmDispatchDate";
            this.clmDispatchDate.Visible = true;
            this.clmDispatchDate.VisibleIndex = 4;
            this.clmDispatchDate.Width = 78;
            // 
            // RepRecDate
            // 
            this.RepRecDate.AutoHeight = false;
            this.RepRecDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepRecDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepRecDate.CalendarTimeProperties.TouchUIMaxValue = new System.DateTime(9999, 12, 31, 0, 0, 0, 0);
            this.RepRecDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.RepRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.RepRecDate.EditFormat.FormatString = "dd/MM/yyyy";
            this.RepRecDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.RepRecDate.Mask.EditMask = "dd/MM/yyyy";
            this.RepRecDate.Mask.UseMaskAsDisplayFormat = true;
            this.RepRecDate.MaxValue = new System.DateTime(9999, 12, 31, 0, 0, 0, 0);
            this.RepRecDate.Name = "RepRecDate";
            // 
            // clmFromCourierID
            // 
            this.clmFromCourierID.Caption = "PICKUP";
            this.clmFromCourierID.ColumnEdit = this.RepFromCourier;
            this.clmFromCourierID.FieldName = "from_courier_id";
            this.clmFromCourierID.Name = "clmFromCourierID";
            this.clmFromCourierID.Visible = true;
            this.clmFromCourierID.VisibleIndex = 5;
            this.clmFromCourierID.Width = 115;
            // 
            // RepFromCourier
            // 
            this.RepFromCourier.AutoHeight = false;
            this.RepFromCourier.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepFromCourier.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("from_courier_id", "From Courier ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("from_courier_name", "From Courier")});
            this.RepFromCourier.Name = "RepFromCourier";
            this.RepFromCourier.NullText = "";
            this.RepFromCourier.ShowHeader = false;
            // 
            // clmToCourierID
            // 
            this.clmToCourierID.AppearanceCell.Options.UseTextOptions = true;
            this.clmToCourierID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.clmToCourierID.Caption = "SHIPPER";
            this.clmToCourierID.ColumnEdit = this.RepToCourier;
            this.clmToCourierID.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.clmToCourierID.FieldName = "to_courier_id";
            this.clmToCourierID.Name = "clmToCourierID";
            this.clmToCourierID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clmToCourierID.Visible = true;
            this.clmToCourierID.VisibleIndex = 6;
            this.clmToCourierID.Width = 99;
            // 
            // RepToCourier
            // 
            this.RepToCourier.AutoHeight = false;
            this.RepToCourier.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepToCourier.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("to_courier_id", "To Courier ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("to_courier_name", "To Courier")});
            this.RepToCourier.Name = "RepToCourier";
            this.RepToCourier.NullText = "";
            this.RepToCourier.ShowHeader = false;
            // 
            // clmAWBNo
            // 
            this.clmAWBNo.Caption = "AWB NO";
            this.clmAWBNo.FieldName = "awb_no";
            this.clmAWBNo.Name = "clmAWBNo";
            this.clmAWBNo.Visible = true;
            this.clmAWBNo.VisibleIndex = 7;
            this.clmAWBNo.Width = 81;
            // 
            // clmPaidAmt
            // 
            this.clmPaidAmt.Caption = "PAID";
            this.clmPaidAmt.FieldName = "collect_rate";
            this.clmPaidAmt.Name = "clmPaidAmt";
            this.clmPaidAmt.OptionsColumn.AllowEdit = false;
            this.clmPaidAmt.OptionsColumn.AllowFocus = false;
            this.clmPaidAmt.OptionsColumn.AllowMove = false;
            this.clmPaidAmt.Visible = true;
            this.clmPaidAmt.VisibleIndex = 8;
            // 
            // clmShippigAmt
            // 
            this.clmShippigAmt.Caption = "COLLECTED";
            this.clmShippigAmt.FieldName = "shipping_amount";
            this.clmShippigAmt.Name = "clmShippigAmt";
            this.clmShippigAmt.OptionsColumn.AllowEdit = false;
            this.clmShippigAmt.OptionsColumn.AllowFocus = false;
            this.clmShippigAmt.OptionsColumn.AllowMove = false;
            this.clmShippigAmt.Visible = true;
            this.clmShippigAmt.VisibleIndex = 9;
            this.clmShippigAmt.Width = 110;
            // 
            // clmStatus
            // 
            this.clmStatus.Caption = "STATUS";
            this.clmStatus.ColumnEdit = this.RepStatus;
            this.clmStatus.FieldName = "status";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.Visible = true;
            this.clmStatus.VisibleIndex = 10;
            // 
            // RepStatus
            // 
            this.RepStatus.AutoHeight = false;
            this.RepStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepStatus.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("status", "Status")});
            this.RepStatus.Name = "RepStatus";
            this.RepStatus.NullText = "";
            this.RepStatus.ShowHeader = false;
            // 
            // clmRemark
            // 
            this.clmRemark.Caption = "REMARKS";
            this.clmRemark.FieldName = "remarks";
            this.clmRemark.Name = "clmRemark";
            this.clmRemark.Visible = true;
            this.clmRemark.VisibleIndex = 11;
            this.clmRemark.Width = 259;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.CmbStatus);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.dtpToDate);
            this.panelControl1.Controls.Add(this.dtpFromDate);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1004, 49);
            this.panelControl1.TabIndex = 102;
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.ImageOptions.Image = global::Account_Management.Properties.Resources.Search;
            this.btnSearch.Location = new System.Drawing.Point(577, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 32);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "S&earch";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // CmbStatus
            // 
            this.CmbStatus.EnterMoveNextControl = true;
            this.CmbStatus.Location = new System.Drawing.Point(442, 13);
            this.CmbStatus.Name = "CmbStatus";
            this.CmbStatus.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbStatus.Properties.Appearance.Options.UseFont = true;
            this.CmbStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold);
            this.CmbStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.CmbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbStatus.Properties.Items.AddRange(new object[] {
            "ALL",
            "PENDING",
            "COMPLETED"});
            this.CmbStatus.Properties.PopupSizeable = true;
            this.CmbStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CmbStatus.Size = new System.Drawing.Size(116, 20);
            this.CmbStatus.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(381, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Status";
            // 
            // dtpToDate
            // 
            this.dtpToDate.EditValue = null;
            this.dtpToDate.Location = new System.Drawing.Point(256, 13);
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
            this.dtpToDate.TabIndex = 1;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.EditValue = null;
            this.dtpFromDate.Location = new System.Drawing.Point(100, 13);
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
            this.dtpFromDate.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(225, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "From Date";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Controls.Add(this.btnClear);
            this.panelControl2.Controls.Add(this.btnExit);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 627);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1004, 44);
            this.panelControl2.TabIndex = 101;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = global::Account_Management.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(672, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 32);
            this.btnSave.TabIndex = 540;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.ImageOptions.Image = global::Account_Management.Properties.Resources.Clear;
            this.btnClear.Location = new System.Drawing.Point(780, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 32);
            this.btnClear.TabIndex = 541;
            this.btnClear.Text = "&Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.ImageOptions.Image = global::Account_Management.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(888, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 32);
            this.btnExit.TabIndex = 542;
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // backgroundWorker_DispatchEntry
            // 
            this.backgroundWorker_DispatchEntry.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DispatchEntry_DoWork);
            this.backgroundWorker_DispatchEntry.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_DispatchEntry_RunWorkerCompleted);
            // 
            // FrmDispatchEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 673);
            this.Controls.Add(this.panelControl3);
            this.Name = "FrmDispatchEntry";
            this.Text = "Dispatch Entry";
            this.Load += new System.EventHandler(this.FrmDispatchEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDispatchEntry)).EndInit();
            this.ContextMNExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispatchEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepRecDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepRecDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepFromCourier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepToCourier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl grdDispatchEntry;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDispatchEntry;
        private DevExpress.XtraGrid.Columns.GridColumn clmDispatchID;
        private DevExpress.XtraGrid.Columns.GridColumn clmOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn clmEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn clmEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn clmWeight;
        private DevExpress.XtraGrid.Columns.GridColumn clmToCourierID;
        private DevExpress.XtraGrid.Columns.GridColumn clmAWBNo;
        private DevExpress.XtraGrid.Columns.GridColumn clmPaidAmt;
        private DevExpress.XtraGrid.Columns.GridColumn clmShippigAmt;
        private DevExpress.XtraGrid.Columns.GridColumn clmRemark;
        private DevExpress.XtraGrid.Columns.GridColumn clmInvoiceId;
        private DevExpress.XtraGrid.Columns.GridColumn clmInvoiceDate;
        private DevExpress.XtraGrid.Columns.GridColumn clmDispatchDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit RepRecDate;
        private DevExpress.XtraGrid.Columns.GridColumn clmFromCourierID;
        private System.ComponentModel.BackgroundWorker backgroundWorker_DispatchEntry;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.DateEdit dtpToDate;
        private DevExpress.XtraEditors.DateEdit dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit CmbStatus;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.ContextMenuStrip ContextMNExport;
        private System.Windows.Forms.ToolStripMenuItem MNExportExcel;
        private System.Windows.Forms.ToolStripMenuItem MNExportPDF;
        private System.Windows.Forms.ToolStripMenuItem MNExportTEXT;
        private System.Windows.Forms.ToolStripMenuItem MNExportHTML;
        private System.Windows.Forms.ToolStripMenuItem MNExportRTF;
        private System.Windows.Forms.ToolStripMenuItem MNExportCSV;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit RepFromCourier;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit RepToCourier;
        private DevExpress.XtraGrid.Columns.GridColumn clmStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit RepStatus;
    }
}