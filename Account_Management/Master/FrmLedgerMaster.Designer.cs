namespace Account_Management
{
    partial class FrmLedgerMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dgvLedgerMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clmledger_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmledgername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmPartyEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmaddress1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmcountry_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmcountry_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmstate_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmstate_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmcity_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmcity_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmpincode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmLedgerPrinName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmLedgerType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmPartyAddress2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmPartyAddress3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmPartyAddress4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmOpeningBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmLedgerGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmLedgerGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmBankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmBankBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmBankIFSC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmBankAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmPartyPanNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmGSTNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmBankAccType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmBankAccName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmOpeningDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdLedgerMaster = new DevExpress.XtraGrid.GridControl();
            this.ContextMNExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MNExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportTEXT = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.LEDGER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LEDGER_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHERE_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblMode = new DevExpress.XtraEditors.LabelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.TabRegisterDetail = new DevExpress.XtraTab.XtraTabControl();
            this.tblGeneralDetail = new DevExpress.XtraTab.XtraTabPage();
            this.dtpOpeningDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtAddress4 = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress2 = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress1 = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress3 = new DevExpress.XtraEditors.TextEdit();
            this.lueLedgerGroup = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtOpeningBalance = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtBankAccName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl35 = new DevExpress.XtraEditors.LabelControl();
            this.CmbBankAccType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
            this.txtBankBranch = new DevExpress.XtraEditors.TextEdit();
            this.labelControl51 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl55 = new DevExpress.XtraEditors.LabelControl();
            this.txtBankIFSC = new DevExpress.XtraEditors.TextEdit();
            this.labelControl56 = new DevExpress.XtraEditors.LabelControl();
            this.txtBankName = new DevExpress.XtraEditors.TextEdit();
            this.txtBankAccNo = new DevExpress.XtraEditors.TextEdit();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl49 = new DevExpress.XtraEditors.LabelControl();
            this.txtPanNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl53 = new DevExpress.XtraEditors.LabelControl();
            this.txtGSTNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl54 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl37 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl39 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl43 = new DevExpress.XtraEditors.LabelControl();
            this.txtLedgerPrintName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.lueLedgerType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl41 = new DevExpress.XtraEditors.LabelControl();
            this.txtMobileNo1 = new DevExpress.XtraEditors.TextEdit();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.lueCity = new DevExpress.XtraEditors.LookUpEdit();
            this.lueState = new DevExpress.XtraEditors.LookUpEdit();
            this.txtZipCode = new DevExpress.XtraEditors.TextEdit();
            this.lueCountry = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.txtLedgerName = new DevExpress.XtraEditors.TextEdit();
            this.txtMobileNo2 = new DevExpress.XtraEditors.TextEdit();
            this.txtEmailID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl30 = new DevExpress.XtraEditors.LabelControl();
            this.CmbOpeningType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ClmOpeningType = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedgerMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLedgerMaster)).BeginInit();
            this.ContextMNExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabRegisterDetail)).BeginInit();
            this.TabRegisterDetail.SuspendLayout();
            this.tblGeneralDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOpeningDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOpeningDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLedgerGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOpeningBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankAccName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbBankAccType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankIFSC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankAccNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPanNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGSTNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLedgerPrintName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLedgerType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZipCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLedgerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbOpeningType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl4
            // 
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(278, 662);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(945, 11);
            this.panelControl4.TabIndex = 12;
            // 
            // panelControl3
            // 
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(1223, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(11, 673);
            this.panelControl3.TabIndex = 11;
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(267, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(11, 673);
            this.panelControl2.TabIndex = 10;
            // 
            // dgvLedgerMaster
            // 
            this.dgvLedgerMaster.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.dgvLedgerMaster.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.dgvLedgerMaster.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.dgvLedgerMaster.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.dgvLedgerMaster.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.dgvLedgerMaster.Appearance.FooterPanel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvLedgerMaster.Appearance.FooterPanel.Options.UseFont = true;
            this.dgvLedgerMaster.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvLedgerMaster.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgvLedgerMaster.Appearance.Row.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.dgvLedgerMaster.Appearance.Row.Options.UseFont = true;
            this.dgvLedgerMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clmledger_id,
            this.clmledgername,
            this.clmActive,
            this.clmRemark,
            this.clmPartyEmail,
            this.clmaddress1,
            this.clmcountry_id,
            this.clmcountry_name,
            this.clmstate_id,
            this.clmstate_name,
            this.clmcity_id,
            this.clmcity_name,
            this.clmpincode,
            this.clmLedgerPrinName,
            this.clmLedgerType,
            this.clmPartyAddress2,
            this.clmPartyAddress3,
            this.clmPartyAddress4,
            this.clmOpeningBalance,
            this.clmLedgerGroupID,
            this.clmLedgerGroupName,
            this.clmBankName,
            this.clmBankBranch,
            this.clmBankIFSC,
            this.clmBankAccNo,
            this.clmPartyPanNo,
            this.clmGSTNo,
            this.clmBankAccType,
            this.clmBankAccName,
            this.clmOpeningDate,
            this.ClmOpeningType});
            this.dgvLedgerMaster.GridControl = this.grdLedgerMaster;
            this.dgvLedgerMaster.Name = "dgvLedgerMaster";
            this.dgvLedgerMaster.OptionsBehavior.Editable = false;
            this.dgvLedgerMaster.OptionsBehavior.ReadOnly = true;
            this.dgvLedgerMaster.OptionsView.ColumnAutoWidth = false;
            this.dgvLedgerMaster.OptionsView.ShowAutoFilterRow = true;
            this.dgvLedgerMaster.OptionsView.ShowFooter = true;
            this.dgvLedgerMaster.OptionsView.ShowGroupPanel = false;
            this.dgvLedgerMaster.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.dgvLedgerMaster_RowClick);
            // 
            // clmledger_id
            // 
            this.clmledger_id.Caption = "Party Id";
            this.clmledger_id.FieldName = "ledger_id";
            this.clmledger_id.Name = "clmledger_id";
            this.clmledger_id.OptionsColumn.AllowEdit = false;
            this.clmledger_id.Width = 77;
            // 
            // clmledgername
            // 
            this.clmledgername.Caption = "Ledger";
            this.clmledgername.FieldName = "ledger_name";
            this.clmledgername.Name = "clmledgername";
            this.clmledgername.OptionsColumn.AllowEdit = false;
            this.clmledgername.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.clmledgername.Visible = true;
            this.clmledgername.VisibleIndex = 0;
            this.clmledgername.Width = 119;
            // 
            // clmActive
            // 
            this.clmActive.Caption = "Active";
            this.clmActive.FieldName = "active";
            this.clmActive.Name = "clmActive";
            this.clmActive.OptionsColumn.AllowEdit = false;
            this.clmActive.Width = 86;
            // 
            // clmRemark
            // 
            this.clmRemark.Caption = "Remark";
            this.clmRemark.FieldName = "remark";
            this.clmRemark.Name = "clmRemark";
            this.clmRemark.OptionsColumn.AllowEdit = false;
            this.clmRemark.Visible = true;
            this.clmRemark.VisibleIndex = 15;
            this.clmRemark.Width = 71;
            // 
            // clmPartyEmail
            // 
            this.clmPartyEmail.Caption = "Party Email";
            this.clmPartyEmail.FieldName = "party_email";
            this.clmPartyEmail.Name = "clmPartyEmail";
            this.clmPartyEmail.OptionsColumn.AllowEdit = false;
            this.clmPartyEmail.Width = 20;
            // 
            // clmaddress1
            // 
            this.clmaddress1.Caption = "Address 1";
            this.clmaddress1.FieldName = "party_address1";
            this.clmaddress1.Name = "clmaddress1";
            this.clmaddress1.OptionsColumn.AllowEdit = false;
            this.clmaddress1.Visible = true;
            this.clmaddress1.VisibleIndex = 3;
            this.clmaddress1.Width = 78;
            // 
            // clmcountry_id
            // 
            this.clmcountry_id.Caption = "Country ID";
            this.clmcountry_id.FieldName = "party_county_id";
            this.clmcountry_id.Name = "clmcountry_id";
            this.clmcountry_id.OptionsColumn.AllowEdit = false;
            this.clmcountry_id.Width = 20;
            // 
            // clmcountry_name
            // 
            this.clmcountry_name.Caption = "Country";
            this.clmcountry_name.FieldName = "country_name";
            this.clmcountry_name.Name = "clmcountry_name";
            this.clmcountry_name.OptionsColumn.AllowEdit = false;
            this.clmcountry_name.Visible = true;
            this.clmcountry_name.VisibleIndex = 10;
            this.clmcountry_name.Width = 85;
            // 
            // clmstate_id
            // 
            this.clmstate_id.Caption = "State ID";
            this.clmstate_id.FieldName = "party_state_id";
            this.clmstate_id.Name = "clmstate_id";
            this.clmstate_id.OptionsColumn.AllowEdit = false;
            this.clmstate_id.Width = 20;
            // 
            // clmstate_name
            // 
            this.clmstate_name.Caption = "State";
            this.clmstate_name.FieldName = "state_name";
            this.clmstate_name.Name = "clmstate_name";
            this.clmstate_name.OptionsColumn.AllowEdit = false;
            this.clmstate_name.Visible = true;
            this.clmstate_name.VisibleIndex = 11;
            this.clmstate_name.Width = 94;
            // 
            // clmcity_id
            // 
            this.clmcity_id.Caption = "City ID";
            this.clmcity_id.FieldName = "party_city_id";
            this.clmcity_id.Name = "clmcity_id";
            this.clmcity_id.OptionsColumn.AllowEdit = false;
            this.clmcity_id.Width = 20;
            // 
            // clmcity_name
            // 
            this.clmcity_name.Caption = "City";
            this.clmcity_name.FieldName = "city_name";
            this.clmcity_name.Name = "clmcity_name";
            this.clmcity_name.OptionsColumn.AllowEdit = false;
            this.clmcity_name.Visible = true;
            this.clmcity_name.VisibleIndex = 12;
            this.clmcity_name.Width = 93;
            // 
            // clmpincode
            // 
            this.clmpincode.Caption = "ZipCode";
            this.clmpincode.FieldName = "party_pincode";
            this.clmpincode.Name = "clmpincode";
            this.clmpincode.OptionsColumn.AllowEdit = false;
            this.clmpincode.Width = 20;
            // 
            // clmLedgerPrinName
            // 
            this.clmLedgerPrinName.Caption = "Ledger Pint";
            this.clmLedgerPrinName.FieldName = "ledger_print_name";
            this.clmLedgerPrinName.Name = "clmLedgerPrinName";
            this.clmLedgerPrinName.OptionsColumn.AllowEdit = false;
            this.clmLedgerPrinName.Width = 20;
            // 
            // clmLedgerType
            // 
            this.clmLedgerType.Caption = "Ledger Type";
            this.clmLedgerType.FieldName = "ledger_type";
            this.clmLedgerType.Name = "clmLedgerType";
            this.clmLedgerType.OptionsColumn.AllowEdit = false;
            this.clmLedgerType.Visible = true;
            this.clmLedgerType.VisibleIndex = 2;
            this.clmLedgerType.Width = 93;
            // 
            // clmPartyAddress2
            // 
            this.clmPartyAddress2.Caption = "Address 2";
            this.clmPartyAddress2.FieldName = "party_address2";
            this.clmPartyAddress2.Name = "clmPartyAddress2";
            this.clmPartyAddress2.Visible = true;
            this.clmPartyAddress2.VisibleIndex = 4;
            // 
            // clmPartyAddress3
            // 
            this.clmPartyAddress3.Caption = "Address 3";
            this.clmPartyAddress3.FieldName = "party_address3";
            this.clmPartyAddress3.Name = "clmPartyAddress3";
            this.clmPartyAddress3.Visible = true;
            this.clmPartyAddress3.VisibleIndex = 5;
            // 
            // clmPartyAddress4
            // 
            this.clmPartyAddress4.Caption = "Address 4";
            this.clmPartyAddress4.FieldName = "party_address4";
            this.clmPartyAddress4.Name = "clmPartyAddress4";
            this.clmPartyAddress4.Visible = true;
            this.clmPartyAddress4.VisibleIndex = 6;
            // 
            // clmOpeningBalance
            // 
            this.clmOpeningBalance.Caption = "Opening Balance";
            this.clmOpeningBalance.FieldName = "opening_balance";
            this.clmOpeningBalance.Name = "clmOpeningBalance";
            this.clmOpeningBalance.Visible = true;
            this.clmOpeningBalance.VisibleIndex = 8;
            this.clmOpeningBalance.Width = 123;
            // 
            // clmLedgerGroupID
            // 
            this.clmLedgerGroupID.Caption = "Ledger Group ID";
            this.clmLedgerGroupID.FieldName = "ledger_group_id";
            this.clmLedgerGroupID.Name = "clmLedgerGroupID";
            // 
            // clmLedgerGroupName
            // 
            this.clmLedgerGroupName.Caption = "Ledger Group";
            this.clmLedgerGroupName.FieldName = "ledger_group_name";
            this.clmLedgerGroupName.Name = "clmLedgerGroupName";
            this.clmLedgerGroupName.Visible = true;
            this.clmLedgerGroupName.VisibleIndex = 1;
            this.clmLedgerGroupName.Width = 97;
            // 
            // clmBankName
            // 
            this.clmBankName.Caption = "Bank";
            this.clmBankName.FieldName = "bank_name";
            this.clmBankName.Name = "clmBankName";
            this.clmBankName.Visible = true;
            this.clmBankName.VisibleIndex = 16;
            // 
            // clmBankBranch
            // 
            this.clmBankBranch.Caption = "Bank Branch";
            this.clmBankBranch.FieldName = "bank_branch";
            this.clmBankBranch.Name = "clmBankBranch";
            this.clmBankBranch.Visible = true;
            this.clmBankBranch.VisibleIndex = 17;
            this.clmBankBranch.Width = 106;
            // 
            // clmBankIFSC
            // 
            this.clmBankIFSC.Caption = "Bank IFSC";
            this.clmBankIFSC.FieldName = "bank_ifsc";
            this.clmBankIFSC.Name = "clmBankIFSC";
            this.clmBankIFSC.Visible = true;
            this.clmBankIFSC.VisibleIndex = 18;
            // 
            // clmBankAccNo
            // 
            this.clmBankAccNo.Caption = "bank Acc No";
            this.clmBankAccNo.FieldName = "bank_account_no";
            this.clmBankAccNo.Name = "clmBankAccNo";
            this.clmBankAccNo.Visible = true;
            this.clmBankAccNo.VisibleIndex = 19;
            this.clmBankAccNo.Width = 104;
            // 
            // clmPartyPanNo
            // 
            this.clmPartyPanNo.Caption = "Pan No";
            this.clmPartyPanNo.FieldName = "party_pan_no";
            this.clmPartyPanNo.Name = "clmPartyPanNo";
            this.clmPartyPanNo.Visible = true;
            this.clmPartyPanNo.VisibleIndex = 13;
            // 
            // clmGSTNo
            // 
            this.clmGSTNo.Caption = "GST No";
            this.clmGSTNo.FieldName = "gst_no";
            this.clmGSTNo.Name = "clmGSTNo";
            this.clmGSTNo.Visible = true;
            this.clmGSTNo.VisibleIndex = 14;
            // 
            // clmBankAccType
            // 
            this.clmBankAccType.Caption = "Bank Acc Type";
            this.clmBankAccType.FieldName = "bank_account_type";
            this.clmBankAccType.Name = "clmBankAccType";
            this.clmBankAccType.Visible = true;
            this.clmBankAccType.VisibleIndex = 20;
            this.clmBankAccType.Width = 116;
            // 
            // clmBankAccName
            // 
            this.clmBankAccName.Caption = "Bank Acc Name";
            this.clmBankAccName.FieldName = "bank_acc_name";
            this.clmBankAccName.Name = "clmBankAccName";
            this.clmBankAccName.Visible = true;
            this.clmBankAccName.VisibleIndex = 21;
            this.clmBankAccName.Width = 107;
            // 
            // clmOpeningDate
            // 
            this.clmOpeningDate.Caption = "Opening Date";
            this.clmOpeningDate.FieldName = "opening_date";
            this.clmOpeningDate.Name = "clmOpeningDate";
            this.clmOpeningDate.Visible = true;
            this.clmOpeningDate.VisibleIndex = 9;
            this.clmOpeningDate.Width = 93;
            // 
            // grdLedgerMaster
            // 
            this.grdLedgerMaster.ContextMenuStrip = this.ContextMNExport;
            this.grdLedgerMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLedgerMaster.Location = new System.Drawing.Point(0, 0);
            this.grdLedgerMaster.MainView = this.dgvLedgerMaster;
            this.grdLedgerMaster.Name = "grdLedgerMaster";
            this.grdLedgerMaster.Size = new System.Drawing.Size(258, 646);
            this.grdLedgerMaster.TabIndex = 14;
            this.grdLedgerMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvLedgerMaster});
            // 
            // ContextMNExport
            // 
            this.ContextMNExport.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.ContextMNExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MNExportExcel,
            this.MNExportPDF,
            this.MNExportTEXT,
            this.MNExportHTML,
            this.MNExportCSV,
            this.MNExportRTF});
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
            // MNExportCSV
            // 
            this.MNExportCSV.Name = "MNExportCSV";
            this.MNExportCSV.Size = new System.Drawing.Size(129, 22);
            this.MNExportCSV.Text = "To CSV";
            this.MNExportCSV.Click += new System.EventHandler(this.MNExportCSV_Click);
            // 
            // MNExportRTF
            // 
            this.MNExportRTF.Name = "MNExportRTF";
            this.MNExportRTF.Size = new System.Drawing.Size(129, 22);
            this.MNExportRTF.Text = "To RTF";
            this.MNExportRTF.Click += new System.EventHandler(this.MNExportRTF_Click);
            // 
            // LEDGER_NAME
            // 
            this.LEDGER_NAME.HeaderText = "Ledger Name";
            this.LEDGER_NAME.Name = "LEDGER_NAME";
            this.LEDGER_NAME.Width = 106;
            // 
            // LEDGER_CODE
            // 
            this.LEDGER_CODE.HeaderText = "Ledger Code";
            this.LEDGER_CODE.Name = "LEDGER_CODE";
            this.LEDGER_CODE.Visible = false;
            this.LEDGER_CODE.Width = 102;
            // 
            // SHERE_PER
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SHERE_PER.DefaultCellStyle = dataGridViewCellStyle1;
            this.SHERE_PER.HeaderText = "Shere(%)";
            this.SHERE_PER.Name = "SHERE_PER";
            this.SHERE_PER.Width = 88;
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(278, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(945, 22);
            this.panelControl1.TabIndex = 13;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("1b51fcc9-7b5e-4f08-b54c-db6335b6338a");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(267, 200);
            this.dockPanel1.Size = new System.Drawing.Size(267, 673);
            this.dockPanel1.Text = "Ledger Master";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.grdLedgerMaster);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(258, 646);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.btnExit);
            this.panelControl6.Controls.Add(this.btnClear);
            this.panelControl6.Controls.Add(this.btnSave);
            this.panelControl6.Controls.Add(this.lblMode);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl6.Location = new System.Drawing.Point(2, 590);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(941, 48);
            this.panelControl6.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.ImageOptions.Image = global::Account_Management.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(832, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 32);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.ImageOptions.Image = global::Account_Management.Properties.Resources.Clear;
            this.btnClear.Location = new System.Drawing.Point(724, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 32);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "&Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = global::Account_Management.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(616, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMode
            // 
            this.lblMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMode.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Appearance.Options.UseFont = true;
            this.lblMode.Appearance.Options.UseForeColor = true;
            this.lblMode.Location = new System.Drawing.Point(535, 17);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(63, 13);
            this.lblMode.TabIndex = 430;
            this.lblMode.Text = "Add Mode";
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.TabRegisterDetail);
            this.panelControl5.Controls.Add(this.panelControl6);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(278, 22);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(945, 640);
            this.panelControl5.TabIndex = 13;
            // 
            // TabRegisterDetail
            // 
            this.TabRegisterDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabRegisterDetail.Location = new System.Drawing.Point(2, 2);
            this.TabRegisterDetail.Name = "TabRegisterDetail";
            this.TabRegisterDetail.SelectedTabPage = this.tblGeneralDetail;
            this.TabRegisterDetail.Size = new System.Drawing.Size(941, 588);
            this.TabRegisterDetail.TabIndex = 0;
            this.TabRegisterDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tblGeneralDetail});
            // 
            // tblGeneralDetail
            // 
            this.tblGeneralDetail.Appearance.Header.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblGeneralDetail.Appearance.Header.Options.UseFont = true;
            this.tblGeneralDetail.Appearance.PageClient.BackColor = System.Drawing.Color.SlateGray;
            this.tblGeneralDetail.Appearance.PageClient.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tblGeneralDetail.Appearance.PageClient.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tblGeneralDetail.Appearance.PageClient.Options.UseBackColor = true;
            this.tblGeneralDetail.Appearance.PageClient.Options.UseBorderColor = true;
            this.tblGeneralDetail.Controls.Add(this.dtpOpeningDate);
            this.tblGeneralDetail.Controls.Add(this.labelControl11);
            this.tblGeneralDetail.Controls.Add(this.txtAddress4);
            this.tblGeneralDetail.Controls.Add(this.txtAddress2);
            this.tblGeneralDetail.Controls.Add(this.txtAddress1);
            this.tblGeneralDetail.Controls.Add(this.txtAddress3);
            this.tblGeneralDetail.Controls.Add(this.lueLedgerGroup);
            this.tblGeneralDetail.Controls.Add(this.labelControl2);
            this.tblGeneralDetail.Controls.Add(this.labelControl1);
            this.tblGeneralDetail.Controls.Add(this.txtOpeningBalance);
            this.tblGeneralDetail.Controls.Add(this.groupControl1);
            this.tblGeneralDetail.Controls.Add(this.txtRemark);
            this.tblGeneralDetail.Controls.Add(this.labelControl49);
            this.tblGeneralDetail.Controls.Add(this.txtPanNo);
            this.tblGeneralDetail.Controls.Add(this.labelControl53);
            this.tblGeneralDetail.Controls.Add(this.txtGSTNo);
            this.tblGeneralDetail.Controls.Add(this.labelControl54);
            this.tblGeneralDetail.Controls.Add(this.labelControl3);
            this.tblGeneralDetail.Controls.Add(this.labelControl37);
            this.tblGeneralDetail.Controls.Add(this.labelControl39);
            this.tblGeneralDetail.Controls.Add(this.labelControl43);
            this.tblGeneralDetail.Controls.Add(this.txtLedgerPrintName);
            this.tblGeneralDetail.Controls.Add(this.labelControl15);
            this.tblGeneralDetail.Controls.Add(this.lueLedgerType);
            this.tblGeneralDetail.Controls.Add(this.labelControl41);
            this.tblGeneralDetail.Controls.Add(this.txtMobileNo1);
            this.tblGeneralDetail.Controls.Add(this.chkActive);
            this.tblGeneralDetail.Controls.Add(this.labelControl4);
            this.tblGeneralDetail.Controls.Add(this.labelControl12);
            this.tblGeneralDetail.Controls.Add(this.lueCity);
            this.tblGeneralDetail.Controls.Add(this.lueState);
            this.tblGeneralDetail.Controls.Add(this.txtZipCode);
            this.tblGeneralDetail.Controls.Add(this.lueCountry);
            this.tblGeneralDetail.Controls.Add(this.labelControl10);
            this.tblGeneralDetail.Controls.Add(this.labelControl9);
            this.tblGeneralDetail.Controls.Add(this.labelControl8);
            this.tblGeneralDetail.Controls.Add(this.labelControl6);
            this.tblGeneralDetail.Controls.Add(this.labelControl7);
            this.tblGeneralDetail.Controls.Add(this.labelControl22);
            this.tblGeneralDetail.Controls.Add(this.txtLedgerName);
            this.tblGeneralDetail.Controls.Add(this.txtMobileNo2);
            this.tblGeneralDetail.Controls.Add(this.txtEmailID);
            this.tblGeneralDetail.Controls.Add(this.labelControl30);
            this.tblGeneralDetail.Controls.Add(this.CmbOpeningType);
            this.tblGeneralDetail.Name = "tblGeneralDetail";
            this.tblGeneralDetail.Size = new System.Drawing.Size(935, 560);
            this.tblGeneralDetail.Text = "GENERAL DETAIL";
            // 
            // dtpOpeningDate
            // 
            this.dtpOpeningDate.EditValue = null;
            this.dtpOpeningDate.Location = new System.Drawing.Point(466, 216);
            this.dtpOpeningDate.Name = "dtpOpeningDate";
            this.dtpOpeningDate.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold);
            this.dtpOpeningDate.Properties.Appearance.Options.UseFont = true;
            this.dtpOpeningDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold);
            this.dtpOpeningDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpOpeningDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOpeningDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOpeningDate.Size = new System.Drawing.Size(187, 20);
            this.dtpOpeningDate.TabIndex = 20;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Appearance.Options.UseForeColor = true;
            this.labelControl11.Location = new System.Drawing.Point(325, 218);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(98, 16);
            this.labelControl11.TabIndex = 578;
            this.labelControl11.Text = "Opening Date";
            // 
            // txtAddress4
            // 
            this.txtAddress4.EnterMoveNextControl = true;
            this.txtAddress4.Location = new System.Drawing.Point(466, 86);
            this.txtAddress4.Name = "txtAddress4";
            this.txtAddress4.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress4.Properties.Appearance.Options.UseFont = true;
            this.txtAddress4.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress4.Properties.MaxLength = 25;
            this.txtAddress4.Size = new System.Drawing.Size(187, 20);
            this.txtAddress4.TabIndex = 14;
            // 
            // txtAddress2
            // 
            this.txtAddress2.EnterMoveNextControl = true;
            this.txtAddress2.Location = new System.Drawing.Point(466, 34);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress2.Properties.Appearance.Options.UseFont = true;
            this.txtAddress2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress2.Properties.MaxLength = 25;
            this.txtAddress2.Size = new System.Drawing.Size(187, 20);
            this.txtAddress2.TabIndex = 12;
            // 
            // txtAddress1
            // 
            this.txtAddress1.EnterMoveNextControl = true;
            this.txtAddress1.Location = new System.Drawing.Point(466, 8);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress1.Properties.Appearance.Options.UseFont = true;
            this.txtAddress1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress1.Properties.MaxLength = 25;
            this.txtAddress1.Size = new System.Drawing.Size(187, 20);
            this.txtAddress1.TabIndex = 11;
            // 
            // txtAddress3
            // 
            this.txtAddress3.EnterMoveNextControl = true;
            this.txtAddress3.Location = new System.Drawing.Point(466, 60);
            this.txtAddress3.Name = "txtAddress3";
            this.txtAddress3.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress3.Properties.Appearance.Options.UseFont = true;
            this.txtAddress3.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress3.Properties.MaxLength = 25;
            this.txtAddress3.Size = new System.Drawing.Size(187, 20);
            this.txtAddress3.TabIndex = 13;
            // 
            // lueLedgerGroup
            // 
            this.lueLedgerGroup.EnterMoveNextControl = true;
            this.lueLedgerGroup.Location = new System.Drawing.Point(116, 34);
            this.lueLedgerGroup.Name = "lueLedgerGroup";
            this.lueLedgerGroup.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueLedgerGroup.Properties.Appearance.Options.UseFont = true;
            this.lueLedgerGroup.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.lueLedgerGroup.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueLedgerGroup.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueLedgerGroup.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueLedgerGroup.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueLedgerGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueLedgerGroup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ledger_group_name", "Ledger Group"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ledger_group_id", "Ledger Group Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueLedgerGroup.Properties.NullText = "";
            this.lueLedgerGroup.Properties.ShowHeader = false;
            this.lueLedgerGroup.Size = new System.Drawing.Size(187, 20);
            this.lueLedgerGroup.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(11, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 16);
            this.labelControl2.TabIndex = 577;
            this.labelControl2.Text = "Group";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(325, 191);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 16);
            this.labelControl1.TabIndex = 575;
            this.labelControl1.Text = "Ope. Bal.";
            // 
            // txtOpeningBalance
            // 
            this.txtOpeningBalance.EnterMoveNextControl = true;
            this.txtOpeningBalance.Location = new System.Drawing.Point(466, 189);
            this.txtOpeningBalance.Name = "txtOpeningBalance";
            this.txtOpeningBalance.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpeningBalance.Properties.Appearance.Options.UseFont = true;
            this.txtOpeningBalance.Size = new System.Drawing.Size(187, 20);
            this.txtOpeningBalance.TabIndex = 19;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtBankAccName);
            this.groupControl1.Controls.Add(this.labelControl35);
            this.groupControl1.Controls.Add(this.CmbBankAccType);
            this.groupControl1.Controls.Add(this.labelControl25);
            this.groupControl1.Controls.Add(this.txtBankBranch);
            this.groupControl1.Controls.Add(this.labelControl51);
            this.groupControl1.Controls.Add(this.labelControl55);
            this.groupControl1.Controls.Add(this.txtBankIFSC);
            this.groupControl1.Controls.Add(this.labelControl56);
            this.groupControl1.Controls.Add(this.txtBankName);
            this.groupControl1.Controls.Add(this.txtBankAccNo);
            this.groupControl1.Location = new System.Drawing.Point(325, 245);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(328, 183);
            this.groupControl1.TabIndex = 573;
            this.groupControl1.Text = "Bank Details";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(8, 25);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(66, 17);
            this.labelControl5.TabIndex = 57;
            this.labelControl5.Text = "Acc Name";
            // 
            // txtBankAccName
            // 
            this.txtBankAccName.EnterMoveNextControl = true;
            this.txtBankAccName.Location = new System.Drawing.Point(89, 24);
            this.txtBankAccName.Name = "txtBankAccName";
            this.txtBankAccName.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankAccName.Properties.Appearance.Options.UseFont = true;
            this.txtBankAccName.Size = new System.Drawing.Size(221, 20);
            this.txtBankAccName.TabIndex = 0;
            // 
            // labelControl35
            // 
            this.labelControl35.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl35.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl35.Appearance.Options.UseFont = true;
            this.labelControl35.Appearance.Options.UseForeColor = true;
            this.labelControl35.Location = new System.Drawing.Point(8, 149);
            this.labelControl35.Name = "labelControl35";
            this.labelControl35.Size = new System.Drawing.Size(62, 17);
            this.labelControl35.TabIndex = 55;
            this.labelControl35.Text = "Acc Type";
            // 
            // CmbBankAccType
            // 
            this.CmbBankAccType.EnterMoveNextControl = true;
            this.CmbBankAccType.Location = new System.Drawing.Point(89, 148);
            this.CmbBankAccType.Name = "CmbBankAccType";
            this.CmbBankAccType.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBankAccType.Properties.Appearance.Options.UseFont = true;
            this.CmbBankAccType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold);
            this.CmbBankAccType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.CmbBankAccType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbBankAccType.Properties.Items.AddRange(new object[] {
            "CURRENT",
            "SAVING"});
            this.CmbBankAccType.Properties.PopupSizeable = true;
            this.CmbBankAccType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CmbBankAccType.Size = new System.Drawing.Size(117, 20);
            this.CmbBankAccType.TabIndex = 5;
            // 
            // labelControl25
            // 
            this.labelControl25.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl25.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl25.Appearance.Options.UseFont = true;
            this.labelControl25.Appearance.Options.UseForeColor = true;
            this.labelControl25.Location = new System.Drawing.Point(8, 50);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new System.Drawing.Size(39, 17);
            this.labelControl25.TabIndex = 50;
            this.labelControl25.Text = "Name";
            // 
            // txtBankBranch
            // 
            this.txtBankBranch.EnterMoveNextControl = true;
            this.txtBankBranch.Location = new System.Drawing.Point(89, 74);
            this.txtBankBranch.Name = "txtBankBranch";
            this.txtBankBranch.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankBranch.Properties.Appearance.Options.UseFont = true;
            this.txtBankBranch.Size = new System.Drawing.Size(221, 20);
            this.txtBankBranch.TabIndex = 2;
            // 
            // labelControl51
            // 
            this.labelControl51.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl51.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl51.Appearance.Options.UseFont = true;
            this.labelControl51.Appearance.Options.UseForeColor = true;
            this.labelControl51.Location = new System.Drawing.Point(8, 75);
            this.labelControl51.Name = "labelControl51";
            this.labelControl51.Size = new System.Drawing.Size(50, 17);
            this.labelControl51.TabIndex = 49;
            this.labelControl51.Text = "Branch";
            // 
            // labelControl55
            // 
            this.labelControl55.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl55.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl55.Appearance.Options.UseFont = true;
            this.labelControl55.Appearance.Options.UseForeColor = true;
            this.labelControl55.Location = new System.Drawing.Point(8, 100);
            this.labelControl55.Name = "labelControl55";
            this.labelControl55.Size = new System.Drawing.Size(30, 17);
            this.labelControl55.TabIndex = 51;
            this.labelControl55.Text = "IFSC";
            // 
            // txtBankIFSC
            // 
            this.txtBankIFSC.EnterMoveNextControl = true;
            this.txtBankIFSC.Location = new System.Drawing.Point(89, 99);
            this.txtBankIFSC.Name = "txtBankIFSC";
            this.txtBankIFSC.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankIFSC.Properties.Appearance.Options.UseFont = true;
            this.txtBankIFSC.Size = new System.Drawing.Size(221, 20);
            this.txtBankIFSC.TabIndex = 3;
            // 
            // labelControl56
            // 
            this.labelControl56.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl56.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl56.Appearance.Options.UseFont = true;
            this.labelControl56.Appearance.Options.UseForeColor = true;
            this.labelControl56.Location = new System.Drawing.Point(8, 124);
            this.labelControl56.Name = "labelControl56";
            this.labelControl56.Size = new System.Drawing.Size(46, 17);
            this.labelControl56.TabIndex = 52;
            this.labelControl56.Text = "Acc No";
            // 
            // txtBankName
            // 
            this.txtBankName.EnterMoveNextControl = true;
            this.txtBankName.Location = new System.Drawing.Point(89, 49);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankName.Properties.Appearance.Options.UseFont = true;
            this.txtBankName.Size = new System.Drawing.Size(221, 20);
            this.txtBankName.TabIndex = 1;
            // 
            // txtBankAccNo
            // 
            this.txtBankAccNo.EnterMoveNextControl = true;
            this.txtBankAccNo.Location = new System.Drawing.Point(89, 123);
            this.txtBankAccNo.Name = "txtBankAccNo";
            this.txtBankAccNo.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankAccNo.Properties.Appearance.Options.UseFont = true;
            this.txtBankAccNo.Size = new System.Drawing.Size(221, 20);
            this.txtBankAccNo.TabIndex = 4;
            // 
            // txtRemark
            // 
            this.txtRemark.EditValue = "";
            this.txtRemark.EnterMoveNextControl = true;
            this.txtRemark.Location = new System.Drawing.Point(116, 268);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Properties.Appearance.Options.UseFont = true;
            this.txtRemark.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemark.Size = new System.Drawing.Size(187, 49);
            this.txtRemark.TabIndex = 10;
            // 
            // labelControl49
            // 
            this.labelControl49.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl49.Appearance.Options.UseFont = true;
            this.labelControl49.Location = new System.Drawing.Point(11, 282);
            this.labelControl49.Name = "labelControl49";
            this.labelControl49.Size = new System.Drawing.Size(55, 16);
            this.labelControl49.TabIndex = 572;
            this.labelControl49.Text = "Remark";
            // 
            // txtPanNo
            // 
            this.txtPanNo.EnterMoveNextControl = true;
            this.txtPanNo.Location = new System.Drawing.Point(116, 242);
            this.txtPanNo.Name = "txtPanNo";
            this.txtPanNo.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPanNo.Properties.Appearance.Options.UseFont = true;
            this.txtPanNo.Properties.MaxLength = 10;
            this.txtPanNo.Size = new System.Drawing.Size(187, 20);
            this.txtPanNo.TabIndex = 9;
            // 
            // labelControl53
            // 
            this.labelControl53.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl53.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl53.Appearance.Options.UseFont = true;
            this.labelControl53.Appearance.Options.UseForeColor = true;
            this.labelControl53.Location = new System.Drawing.Point(11, 244);
            this.labelControl53.Name = "labelControl53";
            this.labelControl53.Size = new System.Drawing.Size(47, 14);
            this.labelControl53.TabIndex = 570;
            this.labelControl53.Text = "Pan No";
            // 
            // txtGSTNo
            // 
            this.txtGSTNo.EnterMoveNextControl = true;
            this.txtGSTNo.Location = new System.Drawing.Point(116, 216);
            this.txtGSTNo.Name = "txtGSTNo";
            this.txtGSTNo.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGSTNo.Properties.Appearance.Options.UseFont = true;
            this.txtGSTNo.Size = new System.Drawing.Size(187, 20);
            this.txtGSTNo.TabIndex = 8;
            // 
            // labelControl54
            // 
            this.labelControl54.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl54.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl54.Appearance.Options.UseFont = true;
            this.labelControl54.Appearance.Options.UseForeColor = true;
            this.labelControl54.Location = new System.Drawing.Point(11, 218);
            this.labelControl54.Name = "labelControl54";
            this.labelControl54.Size = new System.Drawing.Size(49, 14);
            this.labelControl54.TabIndex = 569;
            this.labelControl54.Text = "GST No";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(325, 85);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 16);
            this.labelControl3.TabIndex = 566;
            this.labelControl3.Text = "Address4";
            // 
            // labelControl37
            // 
            this.labelControl37.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl37.Appearance.Options.UseFont = true;
            this.labelControl37.Location = new System.Drawing.Point(325, 35);
            this.labelControl37.Name = "labelControl37";
            this.labelControl37.Size = new System.Drawing.Size(68, 16);
            this.labelControl37.TabIndex = 565;
            this.labelControl37.Text = "Address2";
            // 
            // labelControl39
            // 
            this.labelControl39.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl39.Appearance.Options.UseFont = true;
            this.labelControl39.Location = new System.Drawing.Point(325, 61);
            this.labelControl39.Name = "labelControl39";
            this.labelControl39.Size = new System.Drawing.Size(68, 16);
            this.labelControl39.TabIndex = 564;
            this.labelControl39.Text = "Address3";
            // 
            // labelControl43
            // 
            this.labelControl43.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl43.Appearance.Options.UseFont = true;
            this.labelControl43.Location = new System.Drawing.Point(325, 9);
            this.labelControl43.Name = "labelControl43";
            this.labelControl43.Size = new System.Drawing.Size(68, 16);
            this.labelControl43.TabIndex = 563;
            this.labelControl43.Text = "Address1";
            // 
            // txtLedgerPrintName
            // 
            this.txtLedgerPrintName.EnterMoveNextControl = true;
            this.txtLedgerPrintName.Location = new System.Drawing.Point(116, 86);
            this.txtLedgerPrintName.Name = "txtLedgerPrintName";
            this.txtLedgerPrintName.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLedgerPrintName.Properties.Appearance.Options.UseFont = true;
            this.txtLedgerPrintName.Size = new System.Drawing.Size(187, 20);
            this.txtLedgerPrintName.TabIndex = 3;
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Appearance.Options.UseForeColor = true;
            this.labelControl15.Location = new System.Drawing.Point(11, 85);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(80, 16);
            this.labelControl15.TabIndex = 522;
            this.labelControl15.Text = "Print Name";
            // 
            // lueLedgerType
            // 
            this.lueLedgerType.EnterMoveNextControl = true;
            this.lueLedgerType.Location = new System.Drawing.Point(116, 60);
            this.lueLedgerType.Name = "lueLedgerType";
            this.lueLedgerType.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueLedgerType.Properties.Appearance.Options.UseFont = true;
            this.lueLedgerType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.lueLedgerType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueLedgerType.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueLedgerType.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueLedgerType.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueLedgerType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueLedgerType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ledger_type", "Ledger Type")});
            this.lueLedgerType.Properties.NullText = "";
            this.lueLedgerType.Properties.ShowHeader = false;
            this.lueLedgerType.Size = new System.Drawing.Size(187, 20);
            this.lueLedgerType.TabIndex = 2;
            // 
            // labelControl41
            // 
            this.labelControl41.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl41.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl41.Appearance.Options.UseFont = true;
            this.labelControl41.Appearance.Options.UseForeColor = true;
            this.labelControl41.Location = new System.Drawing.Point(11, 139);
            this.labelControl41.Name = "labelControl41";
            this.labelControl41.Size = new System.Drawing.Size(83, 16);
            this.labelControl41.TabIndex = 503;
            this.labelControl41.Text = "Mobile No 1";
            // 
            // txtMobileNo1
            // 
            this.txtMobileNo1.EnterMoveNextControl = true;
            this.txtMobileNo1.Location = new System.Drawing.Point(116, 138);
            this.txtMobileNo1.Name = "txtMobileNo1";
            this.txtMobileNo1.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo1.Properties.Appearance.Options.UseFont = true;
            this.txtMobileNo1.Size = new System.Drawing.Size(187, 20);
            this.txtMobileNo1.TabIndex = 5;
            // 
            // chkActive
            // 
            this.chkActive.EditValue = true;
            this.chkActive.EnterMoveNextControl = true;
            this.chkActive.Location = new System.Drawing.Point(659, 6);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Properties.Appearance.Options.UseFont = true;
            this.chkActive.Properties.Caption = "Active";
            this.chkActive.Size = new System.Drawing.Size(75, 20);
            this.chkActive.TabIndex = 21;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Verdana", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(103, 8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(9, 16);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "*";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.Location = new System.Drawing.Point(11, 113);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(59, 16);
            this.labelControl12.TabIndex = 486;
            this.labelControl12.Text = "PinCode";
            // 
            // lueCity
            // 
            this.lueCity.EnterMoveNextControl = true;
            this.lueCity.Location = new System.Drawing.Point(466, 163);
            this.lueCity.Name = "lueCity";
            this.lueCity.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueCity.Properties.Appearance.Options.UseFont = true;
            this.lueCity.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold);
            this.lueCity.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueCity.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueCity.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueCity.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCity.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("city_name", "City Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CITY_CODE", "CITY CODE", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueCity.Properties.NullText = "";
            this.lueCity.Properties.ShowHeader = false;
            this.lueCity.Size = new System.Drawing.Size(187, 20);
            this.lueCity.TabIndex = 17;
            // 
            // lueState
            // 
            this.lueState.EnterMoveNextControl = true;
            this.lueState.Location = new System.Drawing.Point(466, 138);
            this.lueState.Name = "lueState";
            this.lueState.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueState.Properties.Appearance.Options.UseFont = true;
            this.lueState.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold);
            this.lueState.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueState.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueState.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueState.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueState.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("state_name", "State Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("state_id", "STATE ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueState.Properties.NullText = "";
            this.lueState.Properties.ShowHeader = false;
            this.lueState.Size = new System.Drawing.Size(187, 20);
            this.lueState.TabIndex = 16;
            // 
            // txtZipCode
            // 
            this.txtZipCode.EnterMoveNextControl = true;
            this.txtZipCode.Location = new System.Drawing.Point(116, 112);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZipCode.Properties.Appearance.Options.UseFont = true;
            this.txtZipCode.Size = new System.Drawing.Size(187, 20);
            this.txtZipCode.TabIndex = 4;
            // 
            // lueCountry
            // 
            this.lueCountry.EnterMoveNextControl = true;
            this.lueCountry.Location = new System.Drawing.Point(466, 112);
            this.lueCountry.Name = "lueCountry";
            this.lueCountry.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueCountry.Properties.Appearance.Options.UseFont = true;
            this.lueCountry.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold);
            this.lueCountry.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueCountry.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueCountry.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueCountry.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCountry.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("country_name", "Country Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("country_id", "COUNTRY ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueCountry.Properties.NullText = "";
            this.lueCountry.Properties.ShowHeader = false;
            this.lueCountry.Size = new System.Drawing.Size(187, 20);
            this.lueCountry.TabIndex = 15;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Appearance.Options.UseForeColor = true;
            this.labelControl10.Location = new System.Drawing.Point(325, 139);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(39, 16);
            this.labelControl10.TabIndex = 484;
            this.labelControl10.Text = "State";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Appearance.Options.UseForeColor = true;
            this.labelControl9.Location = new System.Drawing.Point(325, 165);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(29, 16);
            this.labelControl9.TabIndex = 483;
            this.labelControl9.Text = "City";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseForeColor = true;
            this.labelControl8.Location = new System.Drawing.Point(325, 113);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(58, 16);
            this.labelControl8.TabIndex = 482;
            this.labelControl8.Text = "Country";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(11, 9);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(42, 16);
            this.labelControl6.TabIndex = 471;
            this.labelControl6.Text = "Name";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(11, 165);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(83, 16);
            this.labelControl7.TabIndex = 488;
            this.labelControl7.Text = "Mobile No 2";
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl22.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl22.Appearance.Options.UseFont = true;
            this.labelControl22.Appearance.Options.UseForeColor = true;
            this.labelControl22.Location = new System.Drawing.Point(11, 61);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(35, 16);
            this.labelControl22.TabIndex = 490;
            this.labelControl22.Text = "Type";
            // 
            // txtLedgerName
            // 
            this.txtLedgerName.EnterMoveNextControl = true;
            this.txtLedgerName.Location = new System.Drawing.Point(116, 8);
            this.txtLedgerName.Name = "txtLedgerName";
            this.txtLedgerName.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLedgerName.Properties.Appearance.Options.UseFont = true;
            this.txtLedgerName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLedgerName.Size = new System.Drawing.Size(187, 20);
            this.txtLedgerName.TabIndex = 0;
            // 
            // txtMobileNo2
            // 
            this.txtMobileNo2.EnterMoveNextControl = true;
            this.txtMobileNo2.Location = new System.Drawing.Point(116, 164);
            this.txtMobileNo2.Name = "txtMobileNo2";
            this.txtMobileNo2.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo2.Properties.Appearance.Options.UseFont = true;
            this.txtMobileNo2.Size = new System.Drawing.Size(187, 20);
            this.txtMobileNo2.TabIndex = 6;
            // 
            // txtEmailID
            // 
            this.txtEmailID.EnterMoveNextControl = true;
            this.txtEmailID.Location = new System.Drawing.Point(116, 190);
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailID.Properties.Appearance.Options.UseFont = true;
            this.txtEmailID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmailID.Size = new System.Drawing.Size(187, 20);
            this.txtEmailID.TabIndex = 7;
            // 
            // labelControl30
            // 
            this.labelControl30.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl30.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl30.Appearance.Options.UseFont = true;
            this.labelControl30.Appearance.Options.UseForeColor = true;
            this.labelControl30.Location = new System.Drawing.Point(11, 191);
            this.labelControl30.Name = "labelControl30";
            this.labelControl30.Size = new System.Drawing.Size(60, 16);
            this.labelControl30.TabIndex = 480;
            this.labelControl30.Text = "Email ID";
            // 
            // CmbOpeningType
            // 
            this.CmbOpeningType.EditValue = "DR";
            this.CmbOpeningType.Location = new System.Drawing.Point(408, 189);
            this.CmbOpeningType.Name = "CmbOpeningType";
            this.CmbOpeningType.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbOpeningType.Properties.Appearance.Options.UseFont = true;
            this.CmbOpeningType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.CmbOpeningType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.CmbOpeningType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbOpeningType.Properties.Items.AddRange(new object[] {
            "DR",
            "CR"});
            this.CmbOpeningType.Properties.PopupSizeable = true;
            this.CmbOpeningType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CmbOpeningType.Size = new System.Drawing.Size(52, 20);
            this.CmbOpeningType.TabIndex = 18;
            // 
            // ClmOpeningType
            // 
            this.ClmOpeningType.Caption = "Opening Type";
            this.ClmOpeningType.FieldName = "opening_type";
            this.ClmOpeningType.Name = "ClmOpeningType";
            this.ClmOpeningType.Visible = true;
            this.ClmOpeningType.VisibleIndex = 7;
            this.ClmOpeningType.Width = 94;
            // 
            // FrmLedgerMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 673);
            this.Controls.Add(this.panelControl5);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.dockPanel1);
            this.KeyPreview = true;
            this.Name = "FrmLedgerMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ledger Master";
            this.Load += new System.EventHandler(this.FrmLedgerMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedgerMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLedgerMaster)).EndInit();
            this.ContextMNExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.panelControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabRegisterDetail)).EndInit();
            this.TabRegisterDetail.ResumeLayout(false);
            this.tblGeneralDetail.ResumeLayout(false);
            this.tblGeneralDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOpeningDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOpeningDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLedgerGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOpeningBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankAccName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbBankAccType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankIFSC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankAccNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPanNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGSTNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLedgerPrintName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLedgerType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZipCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLedgerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbOpeningType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvLedgerMaster;
        private DevExpress.XtraGrid.Columns.GridColumn clmledger_id;
        private DevExpress.XtraGrid.Columns.GridColumn clmledgername;
        private DevExpress.XtraGrid.Columns.GridColumn clmActive;
        private DevExpress.XtraGrid.Columns.GridColumn clmRemark;
        private DevExpress.XtraGrid.GridControl grdLedgerMaster;
        private System.Windows.Forms.DataGridViewTextBoxColumn LEDGER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LEDGER_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHERE_PER;
        private DevExpress.XtraGrid.Columns.GridColumn clmPartyEmail;
        private DevExpress.XtraGrid.Columns.GridColumn clmaddress1;
        private DevExpress.XtraGrid.Columns.GridColumn clmcountry_id;
        private DevExpress.XtraGrid.Columns.GridColumn clmcountry_name;
        private DevExpress.XtraGrid.Columns.GridColumn clmstate_id;
        private DevExpress.XtraGrid.Columns.GridColumn clmstate_name;
        private DevExpress.XtraGrid.Columns.GridColumn clmcity_id;
        private DevExpress.XtraGrid.Columns.GridColumn clmcity_name;
        private DevExpress.XtraGrid.Columns.GridColumn clmpincode;
        private DevExpress.XtraGrid.Columns.GridColumn clmLedgerPrinName;
        private DevExpress.XtraGrid.Columns.GridColumn clmLedgerType;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl lblMode;
        private DevExpress.XtraTab.XtraTabPage tblGeneralDetail;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LookUpEdit lueCity;
        private DevExpress.XtraEditors.LookUpEdit lueState;
        private DevExpress.XtraEditors.TextEdit txtZipCode;
        private DevExpress.XtraEditors.LookUpEdit lueCountry;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtLedgerName;
        private DevExpress.XtraEditors.TextEdit txtMobileNo2;
        private DevExpress.XtraEditors.TextEdit txtEmailID;
        private DevExpress.XtraEditors.LabelControl labelControl30;
        private DevExpress.XtraEditors.LabelControl labelControl41;
        private DevExpress.XtraEditors.TextEdit txtMobileNo1;
        private DevExpress.XtraEditors.TextEdit txtLedgerPrintName;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraTab.XtraTabControl TabRegisterDetail;
        private System.Windows.Forms.ContextMenuStrip ContextMNExport;
        private System.Windows.Forms.ToolStripMenuItem MNExportExcel;
        private System.Windows.Forms.ToolStripMenuItem MNExportPDF;
        private System.Windows.Forms.ToolStripMenuItem MNExportTEXT;
        private System.Windows.Forms.ToolStripMenuItem MNExportHTML;
        private System.Windows.Forms.ToolStripMenuItem MNExportRTF;
        private System.Windows.Forms.ToolStripMenuItem MNExportCSV;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl37;
        private DevExpress.XtraEditors.LabelControl labelControl39;
        private DevExpress.XtraEditors.LabelControl labelControl43;
        private DevExpress.XtraEditors.TextEdit txtPanNo;
        private DevExpress.XtraEditors.LabelControl labelControl53;
        private DevExpress.XtraEditors.TextEdit txtGSTNo;
        private DevExpress.XtraEditors.LabelControl labelControl54;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.LabelControl labelControl49;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.TextEdit txtBankBranch;
        private DevExpress.XtraEditors.LabelControl labelControl51;
        private DevExpress.XtraEditors.LabelControl labelControl55;
        private DevExpress.XtraEditors.TextEdit txtBankIFSC;
        private DevExpress.XtraEditors.LabelControl labelControl56;
        private DevExpress.XtraEditors.TextEdit txtBankName;
        private DevExpress.XtraEditors.TextEdit txtBankAccNo;
        private DevExpress.XtraEditors.LookUpEdit lueLedgerType;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtOpeningBalance;
        private DevExpress.XtraEditors.LookUpEdit lueLedgerGroup;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn clmPartyAddress2;
        private DevExpress.XtraGrid.Columns.GridColumn clmPartyAddress3;
        private DevExpress.XtraGrid.Columns.GridColumn clmPartyAddress4;
        private DevExpress.XtraGrid.Columns.GridColumn clmOpeningBalance;
        private DevExpress.XtraGrid.Columns.GridColumn clmLedgerGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn clmLedgerGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn clmBankName;
        private DevExpress.XtraGrid.Columns.GridColumn clmBankBranch;
        private DevExpress.XtraGrid.Columns.GridColumn clmBankIFSC;
        private DevExpress.XtraGrid.Columns.GridColumn clmBankAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn clmPartyPanNo;
        private DevExpress.XtraGrid.Columns.GridColumn clmGSTNo;
        private DevExpress.XtraEditors.TextEdit txtAddress4;
        private DevExpress.XtraEditors.TextEdit txtAddress2;
        private DevExpress.XtraEditors.TextEdit txtAddress1;
        private DevExpress.XtraEditors.TextEdit txtAddress3;
        private DevExpress.XtraEditors.LabelControl labelControl35;
        private DevExpress.XtraEditors.ComboBoxEdit CmbBankAccType;
        private DevExpress.XtraGrid.Columns.GridColumn clmBankAccType;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtBankAccName;
        private DevExpress.XtraGrid.Columns.GridColumn clmBankAccName;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.DateEdit dtpOpeningDate;
        private DevExpress.XtraGrid.Columns.GridColumn clmOpeningDate;
        private DevExpress.XtraEditors.ComboBoxEdit CmbOpeningType;
        private DevExpress.XtraGrid.Columns.GridColumn ClmOpeningType;
    }
}