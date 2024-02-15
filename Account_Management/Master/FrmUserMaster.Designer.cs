namespace Account_Management.Master
{
    partial class FrmUserMaster
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
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.chkPasswordShow = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.lueDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl38 = new DevExpress.XtraEditors.LabelControl();
            this.lueBranch = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl30 = new DevExpress.XtraEditors.LabelControl();
            this.lueCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.lueLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.lueUserType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.lueRoleId = new DevExpress.XtraEditors.LookUpEdit();
            this.luePartyId = new DevExpress.XtraEditors.LookUpEdit();
            this.lueEmpId = new DevExpress.XtraEditors.LookUpEdit();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtSequenceNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtTheme = new DevExpress.XtraEditors.TextEdit();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl29 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl28 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.lblMode = new DevExpress.XtraEditors.LabelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dgvUserMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clmuser_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmuser_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmpassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmemployee_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmparty_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmrole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmUser_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmrole_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmtheme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmpartyid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmCompanyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmBranchId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmbranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmLocationId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmDepartmentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClmUserTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdEmployeeMaster = new DevExpress.XtraGrid.GridControl();
            this.ContextMNExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MNExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportTEXT = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.LEDGER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LEDGER_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHERE_PER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tblDeptRights = new DevExpress.XtraTab.XtraTabPage();
            this.CmbMaritalStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.txtBloodGroup = new DevExpress.XtraEditors.TextEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.DTAnniversaryDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.txtOccupation = new DevExpress.XtraEditors.TextEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.txtIdentityMark = new DevExpress.XtraEditors.TextEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.txtVehicalNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.txtNationality = new DevExpress.XtraEditors.TextEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPasswordShow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUserType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueRoleId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePartyId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueEmpId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSequenceNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTheme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeMaster)).BeginInit();
            this.ContextMNExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbMaritalStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBloodGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTAnniversaryDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTAnniversaryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOccupation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdentityMark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicalNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNationality.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.chkPasswordShow);
            this.panelControl5.Controls.Add(this.labelControl10);
            this.panelControl5.Controls.Add(this.labelControl9);
            this.panelControl5.Controls.Add(this.labelControl7);
            this.panelControl5.Controls.Add(this.labelControl8);
            this.panelControl5.Controls.Add(this.lueDepartment);
            this.panelControl5.Controls.Add(this.labelControl38);
            this.panelControl5.Controls.Add(this.lueBranch);
            this.panelControl5.Controls.Add(this.labelControl30);
            this.panelControl5.Controls.Add(this.lueCompany);
            this.panelControl5.Controls.Add(this.lueLocation);
            this.panelControl5.Controls.Add(this.labelControl13);
            this.panelControl5.Controls.Add(this.labelControl23);
            this.panelControl5.Controls.Add(this.lueUserType);
            this.panelControl5.Controls.Add(this.labelControl5);
            this.panelControl5.Controls.Add(this.labelControl6);
            this.panelControl5.Controls.Add(this.labelControl12);
            this.panelControl5.Controls.Add(this.labelControl11);
            this.panelControl5.Controls.Add(this.lueRoleId);
            this.panelControl5.Controls.Add(this.luePartyId);
            this.panelControl5.Controls.Add(this.lueEmpId);
            this.panelControl5.Controls.Add(this.chkActive);
            this.panelControl5.Controls.Add(this.txtSequenceNo);
            this.panelControl5.Controls.Add(this.labelControl4);
            this.panelControl5.Controls.Add(this.txtTheme);
            this.panelControl5.Controls.Add(this.labelControl22);
            this.panelControl5.Controls.Add(this.labelControl3);
            this.panelControl5.Controls.Add(this.labelControl1);
            this.panelControl5.Controls.Add(this.txtUserName);
            this.panelControl5.Controls.Add(this.labelControl29);
            this.panelControl5.Controls.Add(this.txtPassword);
            this.panelControl5.Controls.Add(this.labelControl28);
            this.panelControl5.Controls.Add(this.labelControl2);
            this.panelControl5.Controls.Add(this.panelControl6);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(288, 22);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(727, 481);
            this.panelControl5.TabIndex = 13;
            // 
            // chkPasswordShow
            // 
            this.chkPasswordShow.EnterMoveNextControl = true;
            this.chkPasswordShow.Location = new System.Drawing.Point(373, 33);
            this.chkPasswordShow.Name = "chkPasswordShow";
            this.chkPasswordShow.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPasswordShow.Properties.Appearance.Options.UseFont = true;
            this.chkPasswordShow.Properties.Caption = "Show";
            this.chkPasswordShow.Size = new System.Drawing.Size(80, 20);
            this.chkPasswordShow.TabIndex = 460;
            this.chkPasswordShow.CheckedChanged += new System.EventHandler(this.chkPasswordShow_CheckedChanged);
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Appearance.Options.UseForeColor = true;
            this.labelControl10.Location = new System.Drawing.Point(157, 191);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(9, 14);
            this.labelControl10.TabIndex = 458;
            this.labelControl10.Text = "*";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Appearance.Options.UseForeColor = true;
            this.labelControl9.Location = new System.Drawing.Point(157, 140);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(9, 14);
            this.labelControl9.TabIndex = 457;
            this.labelControl9.Text = "*";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(157, 166);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(9, 14);
            this.labelControl7.TabIndex = 456;
            this.labelControl7.Text = "*";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseForeColor = true;
            this.labelControl8.Location = new System.Drawing.Point(157, 192);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(9, 14);
            this.labelControl8.TabIndex = 455;
            this.labelControl8.Text = "*";
            // 
            // lueDepartment
            // 
            this.lueDepartment.EnterMoveNextControl = true;
            this.lueDepartment.Location = new System.Drawing.Point(169, 192);
            this.lueDepartment.Name = "lueDepartment";
            this.lueDepartment.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueDepartment.Properties.Appearance.Options.UseFont = true;
            this.lueDepartment.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9F);
            this.lueDepartment.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueDepartment.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueDepartment.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueDepartment.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDepartment.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("department_name", "Department Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("department_id", "Department Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueDepartment.Properties.NullText = "";
            this.lueDepartment.Properties.ShowHeader = false;
            this.lueDepartment.Size = new System.Drawing.Size(187, 20);
            this.lueDepartment.TabIndex = 11;
            // 
            // labelControl38
            // 
            this.labelControl38.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl38.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl38.Appearance.Options.UseFont = true;
            this.labelControl38.Appearance.Options.UseForeColor = true;
            this.labelControl38.Location = new System.Drawing.Point(7, 196);
            this.labelControl38.Name = "labelControl38";
            this.labelControl38.Size = new System.Drawing.Size(143, 16);
            this.labelControl38.TabIndex = 454;
            this.labelControl38.Text = "Default Department";
            // 
            // lueBranch
            // 
            this.lueBranch.EnterMoveNextControl = true;
            this.lueBranch.Location = new System.Drawing.Point(169, 140);
            this.lueBranch.Name = "lueBranch";
            this.lueBranch.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueBranch.Properties.Appearance.Options.UseFont = true;
            this.lueBranch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9F);
            this.lueBranch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueBranch.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueBranch.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueBranch.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBranch.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("branch_name", "Branch Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("branch_id", "Branch Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueBranch.Properties.NullText = "";
            this.lueBranch.Properties.ShowHeader = false;
            this.lueBranch.Size = new System.Drawing.Size(187, 20);
            this.lueBranch.TabIndex = 9;
            // 
            // labelControl30
            // 
            this.labelControl30.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl30.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl30.Appearance.Options.UseFont = true;
            this.labelControl30.Appearance.Options.UseForeColor = true;
            this.labelControl30.Location = new System.Drawing.Point(7, 144);
            this.labelControl30.Name = "labelControl30";
            this.labelControl30.Size = new System.Drawing.Size(107, 16);
            this.labelControl30.TabIndex = 453;
            this.labelControl30.Text = "Default Branch";
            // 
            // lueCompany
            // 
            this.lueCompany.EnterMoveNextControl = true;
            this.lueCompany.Location = new System.Drawing.Point(169, 114);
            this.lueCompany.Name = "lueCompany";
            this.lueCompany.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueCompany.Properties.Appearance.Options.UseFont = true;
            this.lueCompany.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9F);
            this.lueCompany.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueCompany.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueCompany.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueCompany.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("company_name", "Company Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("company_id", "Company Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueCompany.Properties.NullText = "";
            this.lueCompany.Properties.ShowHeader = false;
            this.lueCompany.Size = new System.Drawing.Size(187, 20);
            this.lueCompany.TabIndex = 8;
            // 
            // lueLocation
            // 
            this.lueLocation.EnterMoveNextControl = true;
            this.lueLocation.Location = new System.Drawing.Point(169, 166);
            this.lueLocation.Name = "lueLocation";
            this.lueLocation.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueLocation.Properties.Appearance.Options.UseFont = true;
            this.lueLocation.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9F);
            this.lueLocation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueLocation.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueLocation.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueLocation.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueLocation.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("location_name", "Location Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("location_id", "Location Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueLocation.Properties.NullText = "";
            this.lueLocation.Properties.ShowHeader = false;
            this.lueLocation.Size = new System.Drawing.Size(187, 20);
            this.lueLocation.TabIndex = 10;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Appearance.Options.UseForeColor = true;
            this.labelControl13.Location = new System.Drawing.Point(7, 118);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(125, 16);
            this.labelControl13.TabIndex = 452;
            this.labelControl13.Text = "Default Company";
            // 
            // labelControl23
            // 
            this.labelControl23.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl23.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl23.Appearance.Options.UseFont = true;
            this.labelControl23.Appearance.Options.UseForeColor = true;
            this.labelControl23.Location = new System.Drawing.Point(7, 170);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(114, 16);
            this.labelControl23.TabIndex = 451;
            this.labelControl23.Text = "Defaut Location";
            // 
            // lueUserType
            // 
            this.lueUserType.EnterMoveNextControl = true;
            this.lueUserType.Location = new System.Drawing.Point(169, 61);
            this.lueUserType.Name = "lueUserType";
            this.lueUserType.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueUserType.Properties.Appearance.Options.UseFont = true;
            this.lueUserType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lueUserType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueUserType.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueUserType.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueUserType.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueUserType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueUserType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("user_type", "User Type"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("usertype_id", "UserType Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueUserType.Properties.NullText = "";
            this.lueUserType.Properties.ShowHeader = false;
            this.lueUserType.Size = new System.Drawing.Size(187, 20);
            this.lueUserType.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(7, 64);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 16);
            this.labelControl5.TabIndex = 446;
            this.labelControl5.Text = "User Type";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(501, 83);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(6, 13);
            this.labelControl6.TabIndex = 444;
            this.labelControl6.Text = "*";
            this.labelControl6.Visible = false;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.Location = new System.Drawing.Point(157, 32);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(9, 14);
            this.labelControl12.TabIndex = 443;
            this.labelControl12.Text = "*";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Appearance.Options.UseForeColor = true;
            this.labelControl11.Location = new System.Drawing.Point(157, 6);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(9, 14);
            this.labelControl11.TabIndex = 442;
            this.labelControl11.Text = "*";
            // 
            // lueRoleId
            // 
            this.lueRoleId.EnterMoveNextControl = true;
            this.lueRoleId.Location = new System.Drawing.Point(169, 87);
            this.lueRoleId.Name = "lueRoleId";
            this.lueRoleId.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueRoleId.Properties.Appearance.Options.UseFont = true;
            this.lueRoleId.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lueRoleId.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueRoleId.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueRoleId.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueRoleId.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueRoleId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueRoleId.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("role_name", "Role"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("role_id", "Role ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueRoleId.Properties.NullText = "";
            this.lueRoleId.Properties.ShowHeader = false;
            this.lueRoleId.Size = new System.Drawing.Size(187, 20);
            this.lueRoleId.TabIndex = 5;
            // 
            // luePartyId
            // 
            this.luePartyId.EnterMoveNextControl = true;
            this.luePartyId.Location = new System.Drawing.Point(510, 114);
            this.luePartyId.Name = "luePartyId";
            this.luePartyId.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.luePartyId.Properties.Appearance.Options.UseFont = true;
            this.luePartyId.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.luePartyId.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.luePartyId.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luePartyId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePartyId.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("party_name", "Party Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("party_id", "Party Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.luePartyId.Properties.NullText = "";
            this.luePartyId.Properties.ShowHeader = false;
            this.luePartyId.Size = new System.Drawing.Size(187, 20);
            this.luePartyId.TabIndex = 4;
            this.luePartyId.Visible = false;
            // 
            // lueEmpId
            // 
            this.lueEmpId.EnterMoveNextControl = true;
            this.lueEmpId.Location = new System.Drawing.Point(510, 83);
            this.lueEmpId.Name = "lueEmpId";
            this.lueEmpId.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueEmpId.Properties.Appearance.Options.UseFont = true;
            this.lueEmpId.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueEmpId.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueEmpId.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueEmpId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueEmpId.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("employee_name", "Employee Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("employee_id", "Emp ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueEmpId.Properties.NullText = "";
            this.lueEmpId.Properties.ShowHeader = false;
            this.lueEmpId.Size = new System.Drawing.Size(187, 20);
            this.lueEmpId.TabIndex = 2;
            this.lueEmpId.Visible = false;
            // 
            // chkActive
            // 
            this.chkActive.EnterMoveNextControl = true;
            this.chkActive.Location = new System.Drawing.Point(373, 6);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Properties.Appearance.Options.UseFont = true;
            this.chkActive.Properties.Caption = "Active";
            this.chkActive.Size = new System.Drawing.Size(80, 20);
            this.chkActive.TabIndex = 12;
            // 
            // txtSequenceNo
            // 
            this.txtSequenceNo.EnterMoveNextControl = true;
            this.txtSequenceNo.Location = new System.Drawing.Point(510, 166);
            this.txtSequenceNo.Name = "txtSequenceNo";
            this.txtSequenceNo.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSequenceNo.Properties.Appearance.Options.UseFont = true;
            this.txtSequenceNo.Size = new System.Drawing.Size(187, 20);
            this.txtSequenceNo.TabIndex = 7;
            this.txtSequenceNo.Visible = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(404, 164);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(94, 16);
            this.labelControl4.TabIndex = 103;
            this.labelControl4.Text = "Sequence No";
            this.labelControl4.Visible = false;
            // 
            // txtTheme
            // 
            this.txtTheme.EnterMoveNextControl = true;
            this.txtTheme.Location = new System.Drawing.Point(510, 140);
            this.txtTheme.Name = "txtTheme";
            this.txtTheme.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTheme.Properties.Appearance.Options.UseFont = true;
            this.txtTheme.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTheme.Size = new System.Drawing.Size(187, 20);
            this.txtTheme.TabIndex = 6;
            this.txtTheme.Visible = false;
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl22.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl22.Appearance.Options.UseFont = true;
            this.labelControl22.Appearance.Options.UseForeColor = true;
            this.labelControl22.Location = new System.Drawing.Point(404, 138);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(49, 16);
            this.labelControl22.TabIndex = 102;
            this.labelControl22.Text = "Theme";
            this.labelControl22.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(7, 90);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(31, 16);
            this.labelControl3.TabIndex = 100;
            this.labelControl3.Text = "Role";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(401, 116);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 16);
            this.labelControl1.TabIndex = 98;
            this.labelControl1.Text = "Party";
            this.labelControl1.Visible = false;
            // 
            // txtUserName
            // 
            this.txtUserName.EnterMoveNextControl = true;
            this.txtUserName.Location = new System.Drawing.Point(169, 6);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Size = new System.Drawing.Size(187, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // labelControl29
            // 
            this.labelControl29.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl29.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl29.Appearance.Options.UseFont = true;
            this.labelControl29.Appearance.Options.UseForeColor = true;
            this.labelControl29.Location = new System.Drawing.Point(7, 9);
            this.labelControl29.Name = "labelControl29";
            this.labelControl29.Size = new System.Drawing.Size(79, 16);
            this.labelControl29.TabIndex = 96;
            this.labelControl29.Text = "User Name";
            // 
            // txtPassword
            // 
            this.txtPassword.EnterMoveNextControl = true;
            this.txtPassword.Location = new System.Drawing.Point(169, 32);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(187, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // labelControl28
            // 
            this.labelControl28.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl28.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl28.Appearance.Options.UseFont = true;
            this.labelControl28.Appearance.Options.UseForeColor = true;
            this.labelControl28.Location = new System.Drawing.Point(7, 36);
            this.labelControl28.Name = "labelControl28";
            this.labelControl28.Size = new System.Drawing.Size(70, 16);
            this.labelControl28.TabIndex = 95;
            this.labelControl28.Text = "Password";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(401, 87);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 91;
            this.labelControl2.Text = "Employee";
            this.labelControl2.Visible = false;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.lblMode);
            this.panelControl6.Controls.Add(this.btnExit);
            this.panelControl6.Controls.Add(this.btnClear);
            this.panelControl6.Controls.Add(this.btnSave);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl6.Location = new System.Drawing.Point(2, 431);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(723, 48);
            this.panelControl6.TabIndex = 9;
            // 
            // lblMode
            // 
            this.lblMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMode.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Appearance.Options.UseFont = true;
            this.lblMode.Appearance.Options.UseForeColor = true;
            this.lblMode.Location = new System.Drawing.Point(319, 16);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(63, 13);
            this.lblMode.TabIndex = 433;
            this.lblMode.Text = "Add Mode";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.ImageOptions.Image = global::Account_Management.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(615, 7);
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
            this.btnClear.Location = new System.Drawing.Point(507, 7);
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
            this.btnSave.Location = new System.Drawing.Point(399, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelControl4
            // 
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(288, 503);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(727, 11);
            this.panelControl4.TabIndex = 12;
            // 
            // panelControl3
            // 
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(1015, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(11, 514);
            this.panelControl3.TabIndex = 11;
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(277, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(11, 514);
            this.panelControl2.TabIndex = 10;
            // 
            // dgvUserMaster
            // 
            this.dgvUserMaster.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.dgvUserMaster.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.dgvUserMaster.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.dgvUserMaster.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.dgvUserMaster.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.dgvUserMaster.Appearance.FooterPanel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvUserMaster.Appearance.FooterPanel.Options.UseFont = true;
            this.dgvUserMaster.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvUserMaster.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgvUserMaster.Appearance.Row.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.dgvUserMaster.Appearance.Row.Options.UseFont = true;
            this.dgvUserMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clmuser_id,
            this.clmuser_name,
            this.clmpassword,
            this.clmemployee_id,
            this.clmparty_name,
            this.clmrole,
            this.clmActive,
            this.clmUser_type,
            this.clmrole_id,
            this.clmtheme,
            this.clmEmpName,
            this.clmpartyid,
            this.clmCompanyId,
            this.clmCompany,
            this.clmBranchId,
            this.clmbranch,
            this.clmLocationId,
            this.clmLocation,
            this.clmDepartmentId,
            this.clmDepartment,
            this.ClmUserTypeID});
            this.dgvUserMaster.GridControl = this.grdEmployeeMaster;
            this.dgvUserMaster.Name = "dgvUserMaster";
            this.dgvUserMaster.OptionsBehavior.Editable = false;
            this.dgvUserMaster.OptionsBehavior.ReadOnly = true;
            this.dgvUserMaster.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvUserMaster.OptionsView.ColumnAutoWidth = false;
            this.dgvUserMaster.OptionsView.ShowAutoFilterRow = true;
            this.dgvUserMaster.OptionsView.ShowFooter = true;
            this.dgvUserMaster.OptionsView.ShowGroupPanel = false;
            this.dgvUserMaster.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.dgvUserMaster_RowClick);
            // 
            // clmuser_id
            // 
            this.clmuser_id.Caption = "User Id";
            this.clmuser_id.FieldName = "user_id";
            this.clmuser_id.Name = "clmuser_id";
            this.clmuser_id.OptionsColumn.AllowEdit = false;
            this.clmuser_id.Width = 77;
            // 
            // clmuser_name
            // 
            this.clmuser_name.Caption = "User Name";
            this.clmuser_name.FieldName = "user_name";
            this.clmuser_name.Name = "clmuser_name";
            this.clmuser_name.OptionsColumn.AllowEdit = false;
            this.clmuser_name.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.clmuser_name.Visible = true;
            this.clmuser_name.VisibleIndex = 0;
            this.clmuser_name.Width = 139;
            // 
            // clmpassword
            // 
            this.clmpassword.Caption = "Password";
            this.clmpassword.FieldName = "password";
            this.clmpassword.Name = "clmpassword";
            this.clmpassword.OptionsColumn.AllowEdit = false;
            this.clmpassword.Width = 86;
            // 
            // clmemployee_id
            // 
            this.clmemployee_id.Caption = "Employee Id";
            this.clmemployee_id.FieldName = "employee_id";
            this.clmemployee_id.Name = "clmemployee_id";
            this.clmemployee_id.OptionsColumn.AllowEdit = false;
            this.clmemployee_id.Width = 71;
            // 
            // clmparty_name
            // 
            this.clmparty_name.Caption = "Party Name";
            this.clmparty_name.FieldName = "party_name";
            this.clmparty_name.Name = "clmparty_name";
            this.clmparty_name.OptionsColumn.AllowEdit = false;
            this.clmparty_name.Width = 62;
            // 
            // clmrole
            // 
            this.clmrole.Caption = "Role";
            this.clmrole.FieldName = "role_name";
            this.clmrole.Name = "clmrole";
            this.clmrole.OptionsColumn.AllowEdit = false;
            this.clmrole.Visible = true;
            this.clmrole.VisibleIndex = 6;
            this.clmrole.Width = 106;
            // 
            // clmActive
            // 
            this.clmActive.Caption = "Active";
            this.clmActive.FieldName = "active";
            this.clmActive.Name = "clmActive";
            this.clmActive.OptionsColumn.AllowEdit = false;
            this.clmActive.Visible = true;
            this.clmActive.VisibleIndex = 7;
            // 
            // clmUser_type
            // 
            this.clmUser_type.Caption = "User Type";
            this.clmUser_type.FieldName = "user_type";
            this.clmUser_type.Name = "clmUser_type";
            this.clmUser_type.OptionsColumn.AllowEdit = false;
            this.clmUser_type.Visible = true;
            this.clmUser_type.VisibleIndex = 1;
            this.clmUser_type.Width = 99;
            // 
            // clmrole_id
            // 
            this.clmrole_id.Caption = "Role Id";
            this.clmrole_id.FieldName = "role_id";
            this.clmrole_id.Name = "clmrole_id";
            this.clmrole_id.OptionsColumn.AllowEdit = false;
            // 
            // clmtheme
            // 
            this.clmtheme.Caption = "Theme";
            this.clmtheme.FieldName = "theme";
            this.clmtheme.Name = "clmtheme";
            this.clmtheme.OptionsColumn.AllowEdit = false;
            // 
            // clmEmpName
            // 
            this.clmEmpName.Caption = "Emp Name";
            this.clmEmpName.FieldName = "employee_name";
            this.clmEmpName.Name = "clmEmpName";
            this.clmEmpName.OptionsColumn.AllowEdit = false;
            // 
            // clmpartyid
            // 
            this.clmpartyid.Caption = "Party Id";
            this.clmpartyid.FieldName = "party_id";
            this.clmpartyid.Name = "clmpartyid";
            this.clmpartyid.OptionsColumn.AllowEdit = false;
            // 
            // clmCompanyId
            // 
            this.clmCompanyId.Caption = "Company Id";
            this.clmCompanyId.FieldName = "default_company_id";
            this.clmCompanyId.Name = "clmCompanyId";
            this.clmCompanyId.OptionsColumn.AllowEdit = false;
            // 
            // clmCompany
            // 
            this.clmCompany.Caption = "Company";
            this.clmCompany.FieldName = "company_name";
            this.clmCompany.Name = "clmCompany";
            this.clmCompany.OptionsColumn.AllowEdit = false;
            this.clmCompany.Visible = true;
            this.clmCompany.VisibleIndex = 2;
            // 
            // clmBranchId
            // 
            this.clmBranchId.Caption = "Branch Id";
            this.clmBranchId.FieldName = "default_branch_id";
            this.clmBranchId.Name = "clmBranchId";
            this.clmBranchId.OptionsColumn.AllowEdit = false;
            // 
            // clmbranch
            // 
            this.clmbranch.Caption = "Branch";
            this.clmbranch.FieldName = "branch_name";
            this.clmbranch.Name = "clmbranch";
            this.clmbranch.OptionsColumn.AllowEdit = false;
            this.clmbranch.Visible = true;
            this.clmbranch.VisibleIndex = 3;
            // 
            // clmLocationId
            // 
            this.clmLocationId.Caption = "Location Id";
            this.clmLocationId.FieldName = "default_location_id";
            this.clmLocationId.Name = "clmLocationId";
            this.clmLocationId.OptionsColumn.AllowEdit = false;
            // 
            // clmLocation
            // 
            this.clmLocation.Caption = "Location";
            this.clmLocation.FieldName = "location_name";
            this.clmLocation.Name = "clmLocation";
            this.clmLocation.OptionsColumn.AllowEdit = false;
            this.clmLocation.Visible = true;
            this.clmLocation.VisibleIndex = 4;
            // 
            // clmDepartmentId
            // 
            this.clmDepartmentId.Caption = "Department Id";
            this.clmDepartmentId.FieldName = "default_department_id";
            this.clmDepartmentId.Name = "clmDepartmentId";
            this.clmDepartmentId.OptionsColumn.AllowEdit = false;
            // 
            // clmDepartment
            // 
            this.clmDepartment.Caption = "Department";
            this.clmDepartment.FieldName = "department_name";
            this.clmDepartment.Name = "clmDepartment";
            this.clmDepartment.OptionsColumn.AllowEdit = false;
            this.clmDepartment.Visible = true;
            this.clmDepartment.VisibleIndex = 5;
            this.clmDepartment.Width = 104;
            // 
            // ClmUserTypeID
            // 
            this.ClmUserTypeID.Caption = "user Type ID";
            this.ClmUserTypeID.FieldName = "usertype_id";
            this.ClmUserTypeID.Name = "ClmUserTypeID";
            // 
            // grdEmployeeMaster
            // 
            this.grdEmployeeMaster.ContextMenuStrip = this.ContextMNExport;
            this.grdEmployeeMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEmployeeMaster.Location = new System.Drawing.Point(0, 0);
            this.grdEmployeeMaster.MainView = this.dgvUserMaster;
            this.grdEmployeeMaster.Name = "grdEmployeeMaster";
            this.grdEmployeeMaster.Size = new System.Drawing.Size(268, 487);
            this.grdEmployeeMaster.TabIndex = 14;
            this.grdEmployeeMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvUserMaster});
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
            this.MNExportHTML.Click += new System.EventHandler(this.MNExportHTML_Click);
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
            this.dockPanel1.ID = new System.Guid("d6e3ca33-077e-4857-9c9f-bad2282ff8f5");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(277, 200);
            this.dockPanel1.Size = new System.Drawing.Size(277, 514);
            this.dockPanel1.Text = "User Master";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.grdEmployeeMaster);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(268, 487);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(288, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(727, 22);
            this.panelControl1.TabIndex = 13;
            // 
            // tblDeptRights
            // 
            this.tblDeptRights.Appearance.Header.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblDeptRights.Appearance.Header.Options.UseFont = true;
            this.tblDeptRights.Name = "tblDeptRights";
            this.tblDeptRights.Size = new System.Drawing.Size(717, 401);
            // 
            // CmbMaritalStatus
            // 
            this.CmbMaritalStatus.EditValue = "Select";
            this.CmbMaritalStatus.EnterMoveNextControl = true;
            this.CmbMaritalStatus.Location = new System.Drawing.Point(137, 13);
            this.CmbMaritalStatus.Name = "CmbMaritalStatus";
            this.CmbMaritalStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.CmbMaritalStatus.Properties.Appearance.Options.UseFont = true;
            this.CmbMaritalStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbMaritalStatus.Properties.Items.AddRange(new object[] {
            "Select",
            "UNMARRIED",
            "MARRIED",
            "WIDOW",
            "DIVORCED"});
            this.CmbMaritalStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CmbMaritalStatus.Size = new System.Drawing.Size(188, 20);
            this.CmbMaritalStatus.TabIndex = 0;
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Appearance.Options.UseForeColor = true;
            this.labelControl14.Location = new System.Drawing.Point(13, 16);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(96, 17);
            this.labelControl14.TabIndex = 91;
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Appearance.Options.UseForeColor = true;
            this.labelControl15.Location = new System.Drawing.Point(13, 41);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(89, 17);
            this.labelControl15.TabIndex = 101;
            // 
            // txtBloodGroup
            // 
            this.txtBloodGroup.EnterMoveNextControl = true;
            this.txtBloodGroup.Location = new System.Drawing.Point(137, 38);
            this.txtBloodGroup.Name = "txtBloodGroup";
            this.txtBloodGroup.Properties.Appearance.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBloodGroup.Properties.Appearance.Options.UseFont = true;
            this.txtBloodGroup.Size = new System.Drawing.Size(188, 22);
            this.txtBloodGroup.TabIndex = 1;
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl16.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl16.Appearance.Options.UseFont = true;
            this.labelControl16.Appearance.Options.UseForeColor = true;
            this.labelControl16.Location = new System.Drawing.Point(13, 66);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(87, 17);
            this.labelControl16.TabIndex = 52;
            // 
            // DTAnniversaryDate
            // 
            this.DTAnniversaryDate.EditValue = null;
            this.DTAnniversaryDate.EnterMoveNextControl = true;
            this.DTAnniversaryDate.Location = new System.Drawing.Point(137, 63);
            this.DTAnniversaryDate.Name = "DTAnniversaryDate";
            this.DTAnniversaryDate.Properties.Appearance.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTAnniversaryDate.Properties.Appearance.Options.UseFont = true;
            this.DTAnniversaryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DTAnniversaryDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DTAnniversaryDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.DTAnniversaryDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.DTAnniversaryDate.Size = new System.Drawing.Size(188, 22);
            this.DTAnniversaryDate.TabIndex = 2;
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl17.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl17.Appearance.Options.UseFont = true;
            this.labelControl17.Appearance.Options.UseForeColor = true;
            this.labelControl17.Location = new System.Drawing.Point(13, 91);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(78, 17);
            this.labelControl17.TabIndex = 54;
            // 
            // txtOccupation
            // 
            this.txtOccupation.EnterMoveNextControl = true;
            this.txtOccupation.Location = new System.Drawing.Point(137, 88);
            this.txtOccupation.Name = "txtOccupation";
            this.txtOccupation.Properties.Appearance.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOccupation.Properties.Appearance.Options.UseFont = true;
            this.txtOccupation.Size = new System.Drawing.Size(188, 22);
            this.txtOccupation.TabIndex = 3;
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl18.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl18.Appearance.Options.UseFont = true;
            this.labelControl18.Appearance.Options.UseForeColor = true;
            this.labelControl18.Location = new System.Drawing.Point(13, 141);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(95, 17);
            this.labelControl18.TabIndex = 56;
            // 
            // txtIdentityMark
            // 
            this.txtIdentityMark.EnterMoveNextControl = true;
            this.txtIdentityMark.Location = new System.Drawing.Point(137, 138);
            this.txtIdentityMark.Name = "txtIdentityMark";
            this.txtIdentityMark.Properties.Appearance.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityMark.Properties.Appearance.Options.UseFont = true;
            this.txtIdentityMark.Size = new System.Drawing.Size(188, 22);
            this.txtIdentityMark.TabIndex = 5;
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl19.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl19.Appearance.Options.UseFont = true;
            this.labelControl19.Appearance.Options.UseForeColor = true;
            this.labelControl19.Location = new System.Drawing.Point(13, 116);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(77, 17);
            this.labelControl19.TabIndex = 58;
            // 
            // txtVehicalNo
            // 
            this.txtVehicalNo.EnterMoveNextControl = true;
            this.txtVehicalNo.Location = new System.Drawing.Point(137, 113);
            this.txtVehicalNo.Name = "txtVehicalNo";
            this.txtVehicalNo.Properties.Appearance.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehicalNo.Properties.Appearance.Options.UseFont = true;
            this.txtVehicalNo.Size = new System.Drawing.Size(188, 22);
            this.txtVehicalNo.TabIndex = 4;
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl20.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl20.Appearance.Options.UseFont = true;
            this.labelControl20.Appearance.Options.UseForeColor = true;
            this.labelControl20.Location = new System.Drawing.Point(13, 166);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(78, 17);
            this.labelControl20.TabIndex = 60;
            // 
            // txtNationality
            // 
            this.txtNationality.EnterMoveNextControl = true;
            this.txtNationality.Location = new System.Drawing.Point(137, 163);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Properties.Appearance.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNationality.Properties.Appearance.Options.UseFont = true;
            this.txtNationality.Size = new System.Drawing.Size(188, 22);
            this.txtNationality.TabIndex = 6;
            // 
            // labelControl21
            // 
            this.labelControl21.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl21.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl21.Appearance.Options.UseFont = true;
            this.labelControl21.Appearance.Options.UseForeColor = true;
            this.labelControl21.Location = new System.Drawing.Point(13, 191);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(59, 17);
            this.labelControl21.TabIndex = 62;
            // 
            // FrmUserMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 514);
            this.Controls.Add(this.panelControl5);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.dockPanel1);
            this.KeyPreview = true;
            this.Name = "FrmUserMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Master";
            this.Load += new System.EventHandler(this.FrmUserMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPasswordShow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUserType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueRoleId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePartyId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueEmpId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSequenceNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTheme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.panelControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeMaster)).EndInit();
            this.ContextMNExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbMaritalStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBloodGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTAnniversaryDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTAnniversaryDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOccupation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdentityMark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicalNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNationality.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvUserMaster;
        private DevExpress.XtraGrid.Columns.GridColumn clmuser_id;
        private DevExpress.XtraGrid.Columns.GridColumn clmuser_name;
        private DevExpress.XtraGrid.Columns.GridColumn clmpassword;
        private DevExpress.XtraGrid.Columns.GridColumn clmemployee_id;
        private DevExpress.XtraGrid.GridControl grdEmployeeMaster;
        private System.Windows.Forms.DataGridViewTextBoxColumn LEDGER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LEDGER_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHERE_PER;
        private DevExpress.XtraGrid.Columns.GridColumn clmparty_name;
        private DevExpress.XtraGrid.Columns.GridColumn clmrole;
        private DevExpress.XtraGrid.Columns.GridColumn clmActive;
        private DevExpress.XtraGrid.Columns.GridColumn clmUser_type;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraTab.XtraTabPage tblDeptRights;
        private DevExpress.XtraEditors.ComboBoxEdit CmbMaritalStatus;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.TextEdit txtBloodGroup;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.DateEdit DTAnniversaryDate;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.TextEdit txtOccupation;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.TextEdit txtIdentityMark;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.TextEdit txtVehicalNo;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.TextEdit txtNationality;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.TextEdit txtSequenceNo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtTheme;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labelControl29;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl labelControl28;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.LabelControl lblMode;
        private DevExpress.XtraEditors.LookUpEdit lueRoleId;
        private DevExpress.XtraEditors.LookUpEdit luePartyId;
        private DevExpress.XtraEditors.LookUpEdit lueEmpId;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraGrid.Columns.GridColumn clmrole_id;
        private DevExpress.XtraGrid.Columns.GridColumn clmtheme;
        private DevExpress.XtraEditors.LookUpEdit lueUserType;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.Columns.GridColumn clmEmpName;
        private DevExpress.XtraGrid.Columns.GridColumn clmpartyid;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LookUpEdit lueDepartment;
        private DevExpress.XtraEditors.LabelControl labelControl38;
        private DevExpress.XtraEditors.LookUpEdit lueBranch;
        private DevExpress.XtraEditors.LabelControl labelControl30;
        private DevExpress.XtraEditors.LookUpEdit lueCompany;
        private DevExpress.XtraEditors.LookUpEdit lueLocation;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraGrid.Columns.GridColumn clmCompanyId;
        private DevExpress.XtraGrid.Columns.GridColumn clmCompany;
        private DevExpress.XtraGrid.Columns.GridColumn clmBranchId;
        private DevExpress.XtraGrid.Columns.GridColumn clmbranch;
        private DevExpress.XtraGrid.Columns.GridColumn clmLocationId;
        private DevExpress.XtraGrid.Columns.GridColumn clmLocation;
        private DevExpress.XtraGrid.Columns.GridColumn clmDepartmentId;
        private DevExpress.XtraGrid.Columns.GridColumn clmDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn ClmUserTypeID;
        private DevExpress.XtraEditors.CheckEdit chkPasswordShow;
        private System.Windows.Forms.ToolStripMenuItem MNExportCSV;
        private System.Windows.Forms.ToolStripMenuItem MNExportRTF;
        private System.Windows.Forms.ToolStripMenuItem MNExportHTML;
        private System.Windows.Forms.ToolStripMenuItem MNExportTEXT;
        private System.Windows.Forms.ToolStripMenuItem MNExportPDF;
        private System.Windows.Forms.ToolStripMenuItem MNExportExcel;
        private System.Windows.Forms.ContextMenuStrip ContextMNExport;
    }
}