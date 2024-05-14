namespace Account_Management.Transaction
{
    partial class FrmPaymentGivenSearch
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.MainGrid = new DevExpress.XtraGrid.GridControl();
            this.ContextMNExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MNExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportTEXT = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.GrdDet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepMethod = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.clmRSAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepOrderNo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ClmLotSrNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClmInvoiceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepDueDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClmDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblLedgerID = new DevExpress.XtraEditors.LabelControl();
            this.lblAmount = new DevExpress.XtraEditors.LabelControl();
            this.lblLedger = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).BeginInit();
            this.ContextMNExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepDueDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepDueDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 393);
            this.panel5.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(559, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 393);
            this.panel3.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 383);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(549, 10);
            this.panel4.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 338);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 45);
            this.panel1.TabIndex = 0;
            // 
            // BtnSave
            // 
            this.BtnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.BtnSave.Appearance.Options.UseFont = true;
            this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSave.Location = new System.Drawing.Point(219, 6);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(102, 34);
            this.BtnSave.TabIndex = 14;
            this.BtnSave.Text = "&OK";
            this.BtnSave.ToolTip = "Click TO Calculate EMI As Per Month Bases & Suggested List Also";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // MainGrid
            // 
            this.MainGrid.ContextMenuStrip = this.ContextMNExport;
            this.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGrid.Location = new System.Drawing.Point(2, 2);
            this.MainGrid.MainView = this.GrdDet;
            this.MainGrid.Name = "MainGrid";
            this.MainGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepMethod,
            this.RepDueDate,
            this.RepOrderNo,
            this.RepDelete});
            this.MainGrid.Size = new System.Drawing.Size(545, 297);
            this.MainGrid.TabIndex = 1;
            this.MainGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrdDet});
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
            this.MNExportTEXT.Click += new System.EventHandler(this.MNExportTEXT_Click);
            // 
            // MNExportHTML
            // 
            this.MNExportHTML.Name = "MNExportHTML";
            this.MNExportHTML.Size = new System.Drawing.Size(129, 22);
            this.MNExportHTML.Text = "To HTML";
            this.MNExportHTML.Click += new System.EventHandler(this.MNExportHTML_Click);
            // 
            // MNExportRTF
            // 
            this.MNExportRTF.Name = "MNExportRTF";
            this.MNExportRTF.Size = new System.Drawing.Size(129, 22);
            this.MNExportRTF.Text = "To RTF";
            this.MNExportRTF.Click += new System.EventHandler(this.MNExportRTF_Click);
            // 
            // MNExportCSV
            // 
            this.MNExportCSV.Name = "MNExportCSV";
            this.MNExportCSV.Size = new System.Drawing.Size(129, 22);
            this.MNExportCSV.Text = "To CSV";
            this.MNExportCSV.Click += new System.EventHandler(this.MNExportCSV_Click);
            // 
            // GrdDet
            // 
            this.GrdDet.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GrdDet.Appearance.FocusedCell.Font = new System.Drawing.Font("Verdana", 9F);
            this.GrdDet.Appearance.FocusedCell.Options.UseBackColor = true;
            this.GrdDet.Appearance.FocusedCell.Options.UseFont = true;
            this.GrdDet.Appearance.FocusedRow.BackColor = System.Drawing.Color.White;
            this.GrdDet.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.White;
            this.GrdDet.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 9F);
            this.GrdDet.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.GrdDet.Appearance.FocusedRow.Options.UseBackColor = true;
            this.GrdDet.Appearance.FocusedRow.Options.UseFont = true;
            this.GrdDet.Appearance.FocusedRow.Options.UseForeColor = true;
            this.GrdDet.Appearance.FooterPanel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.GrdDet.Appearance.FooterPanel.Options.UseFont = true;
            this.GrdDet.Appearance.HeaderPanel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.GrdDet.Appearance.HeaderPanel.Options.UseFont = true;
            this.GrdDet.Appearance.Row.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.GrdDet.Appearance.Row.Options.UseFont = true;
            this.GrdDet.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.GrdDet.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.GrdDet.Appearance.SelectedRow.Options.UseBackColor = true;
            this.GrdDet.Appearance.SelectedRow.Options.UseFont = true;
            this.GrdDet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.clmRSAmount,
            this.gridColumn8,
            this.ClmLotSrNo,
            this.ClmInvoiceID,
            this.gridColumn1,
            this.gridColumn3,
            this.ClmDelete});
            this.GrdDet.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GrdDet.GridControl = this.MainGrid;
            this.GrdDet.Name = "GrdDet";
            this.GrdDet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.GrdDet.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.GrdDet.OptionsCustomization.AllowColumnMoving = false;
            this.GrdDet.OptionsCustomization.AllowFilter = false;
            this.GrdDet.OptionsCustomization.AllowGroup = false;
            this.GrdDet.OptionsCustomization.AllowSort = false;
            this.GrdDet.OptionsNavigation.EnterMoveNextColumn = true;
            this.GrdDet.OptionsView.ColumnAutoWidth = false;
            this.GrdDet.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.GrdDet.OptionsView.ShowFooter = true;
            this.GrdDet.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "Method";
            this.gridColumn2.ColumnEdit = this.RepMethod;
            this.gridColumn2.FieldName = "method";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 117;
            // 
            // RepMethod
            // 
            this.RepMethod.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.RepMethod.Appearance.Options.UseFont = true;
            this.RepMethod.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.RepMethod.AppearanceDropDown.Options.UseFont = true;
            this.RepMethod.AutoHeight = false;
            this.RepMethod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepMethod.Name = "RepMethod";
            this.RepMethod.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // clmRSAmount
            // 
            this.clmRSAmount.Caption = "Amount";
            this.clmRSAmount.FieldName = "amount";
            this.clmRSAmount.Name = "clmRSAmount";
            this.clmRSAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clmRSAmount.Visible = true;
            this.clmRSAmount.VisibleIndex = 4;
            this.clmRSAmount.Width = 94;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.Caption = "Pur. Bill No";
            this.gridColumn8.ColumnEdit = this.RepOrderNo;
            this.gridColumn8.FieldName = "purchase_bill_no";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 98;
            // 
            // RepOrderNo
            // 
            this.RepOrderNo.AutoHeight = false;
            this.RepOrderNo.Name = "RepOrderNo";
            this.RepOrderNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RepOrderNo_KeyPress);
            // 
            // ClmLotSrNo
            // 
            this.ClmLotSrNo.Caption = "Sr No";
            this.ClmLotSrNo.FieldName = "sr_no";
            this.ClmLotSrNo.Name = "ClmLotSrNo";
            this.ClmLotSrNo.OptionsColumn.AllowEdit = false;
            this.ClmLotSrNo.OptionsColumn.AllowFocus = false;
            this.ClmLotSrNo.OptionsColumn.AllowMove = false;
            this.ClmLotSrNo.Visible = true;
            this.ClmLotSrNo.VisibleIndex = 1;
            this.ClmLotSrNo.Width = 46;
            // 
            // ClmInvoiceID
            // 
            this.ClmInvoiceID.Caption = "Purchase ID";
            this.ClmInvoiceID.FieldName = "purchase_id";
            this.ClmInvoiceID.Name = "ClmInvoiceID";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Payment Date";
            this.gridColumn1.ColumnEdit = this.RepDueDate;
            this.gridColumn1.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "payment_date";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 106;
            // 
            // RepDueDate
            // 
            this.RepDueDate.AutoHeight = false;
            this.RepDueDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepDueDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepDueDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.RepDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.RepDueDate.EditFormat.FormatString = "dd/MM/yyyy";
            this.RepDueDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.RepDueDate.Mask.EditMask = "";
            this.RepDueDate.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.RepDueDate.Name = "RepDueDate";
            this.RepDueDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RepDueDate_KeyDown);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Payment ID";
            this.gridColumn3.FieldName = "payment_id";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // ClmDelete
            // 
            this.ClmDelete.Caption = "Del";
            this.ClmDelete.ColumnEdit = this.RepDelete;
            this.ClmDelete.FieldName = "ClmDelete";
            this.ClmDelete.Name = "ClmDelete";
            this.ClmDelete.OptionsColumn.AllowMove = false;
            this.ClmDelete.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.ClmDelete.Visible = true;
            this.ClmDelete.VisibleIndex = 0;
            this.ClmDelete.Width = 29;
            // 
            // RepDelete
            // 
            this.RepDelete.AutoHeight = false;
            editorButtonImageOptions2.ImageUri.Uri = "Cancel;Size16x16;Colored";
            this.RepDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Delete", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "Delete This Row", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.RepDelete.Name = "RepDelete";
            this.RepDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.RepDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.RepDelete_ButtonClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.lblLedgerID);
            this.panelControl1.Controls.Add(this.lblAmount);
            this.panelControl1.Controls.Add(this.lblLedger);
            this.panelControl1.Controls.Add(this.labelControl18);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(10, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(549, 37);
            this.panelControl1.TabIndex = 15;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(402, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 16);
            this.labelControl2.TabIndex = 524;
            this.labelControl2.Text = "Rs.";
            // 
            // lblLedgerID
            // 
            this.lblLedgerID.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLedgerID.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblLedgerID.Appearance.Options.UseFont = true;
            this.lblLedgerID.Appearance.Options.UseForeColor = true;
            this.lblLedgerID.Location = new System.Drawing.Point(210, 9);
            this.lblLedgerID.Name = "lblLedgerID";
            this.lblLedgerID.Size = new System.Drawing.Size(70, 16);
            this.lblLedgerID.TabIndex = 523;
            this.lblLedgerID.Text = "Ledger ID";
            this.lblLedgerID.Visible = false;
            // 
            // lblAmount
            // 
            this.lblAmount.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblAmount.Appearance.Options.UseFont = true;
            this.lblAmount.Appearance.Options.UseForeColor = true;
            this.lblAmount.Location = new System.Drawing.Point(431, 9);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(57, 16);
            this.lblAmount.TabIndex = 522;
            this.lblAmount.Text = "Amount";
            // 
            // lblLedger
            // 
            this.lblLedger.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLedger.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblLedger.Appearance.Options.UseFont = true;
            this.lblLedger.Appearance.Options.UseForeColor = true;
            this.lblLedger.Location = new System.Drawing.Point(87, 9);
            this.lblLedger.Name = "lblLedger";
            this.lblLedger.Size = new System.Drawing.Size(50, 16);
            this.lblLedger.TabIndex = 521;
            this.lblLedger.Text = "Ledger";
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl18.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl18.Appearance.Options.UseFont = true;
            this.labelControl18.Appearance.Options.UseForeColor = true;
            this.labelControl18.Location = new System.Drawing.Point(21, 9);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(59, 16);
            this.labelControl18.TabIndex = 520;
            this.labelControl18.Text = "Ledger :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(330, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 16);
            this.labelControl1.TabIndex = 519;
            this.labelControl1.Text = "Amount :";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.MainGrid);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(10, 37);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(549, 301);
            this.panelControl2.TabIndex = 16;
            // 
            // FrmPaymentGivenSearch
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 393);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.KeyPreview = true;
            this.Name = "FrmPaymentGivenSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill-By-bill Adjustment of Amount";
            this.Load += new System.EventHandler(this.FrmPaymentReceiptSearch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPaymentReceiptSearch_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).EndInit();
            this.ContextMNExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepDueDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepDueDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl MainGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView GrdDet;
        private DevExpress.XtraEditors.SimpleButton BtnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn clmRSAmount;
        private System.Windows.Forms.ContextMenuStrip ContextMNExport;
        private System.Windows.Forms.ToolStripMenuItem MNExportExcel;
        private System.Windows.Forms.ToolStripMenuItem MNExportPDF;
        private System.Windows.Forms.ToolStripMenuItem MNExportTEXT;
        private System.Windows.Forms.ToolStripMenuItem MNExportHTML;
        private System.Windows.Forms.ToolStripMenuItem MNExportRTF;
        private System.Windows.Forms.ToolStripMenuItem MNExportCSV;
        private DevExpress.XtraGrid.Columns.GridColumn ClmLotSrNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox RepMethod;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit RepDueDate;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblAmount;
        private DevExpress.XtraEditors.LabelControl lblLedger;
        private DevExpress.XtraEditors.LabelControl lblLedgerID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RepOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn ClmInvoiceID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn ClmDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit RepDelete;
    }
}