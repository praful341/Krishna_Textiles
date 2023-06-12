namespace Krishna_Textiles.Master
{
    partial class FrmConfigPermission
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
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.grdConfigCompanyRights = new DevExpress.XtraGrid.GridControl();
            this.dgvConfigCompanyRights = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clmEmployeeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtUName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl38 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl30 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.lblMode = new DevExpress.XtraEditors.LabelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lueCompany = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lueBranch = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lueLocation = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lueDepartment = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.ContextMNExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MNExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportTEXT = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdConfigCompanyRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigCompanyRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.ContextMNExport.SuspendLayout();
            this.SuspendLayout();
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
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("3bb28a50-3462-431b-903a-c2d867175d8f");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(248, 200);
            this.dockPanel1.Size = new System.Drawing.Size(248, 430);
            this.dockPanel1.Text = "Config Permission";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.grdConfigCompanyRights);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(239, 403);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // grdConfigCompanyRights
            // 
            this.grdConfigCompanyRights.ContextMenuStrip = this.ContextMNExport;
            this.grdConfigCompanyRights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdConfigCompanyRights.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridLevelNode1.RelationName = "Level1";
            this.grdConfigCompanyRights.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdConfigCompanyRights.Location = new System.Drawing.Point(0, 0);
            this.grdConfigCompanyRights.MainView = this.dgvConfigCompanyRights;
            this.grdConfigCompanyRights.Name = "grdConfigCompanyRights";
            this.grdConfigCompanyRights.Size = new System.Drawing.Size(239, 403);
            this.grdConfigCompanyRights.TabIndex = 18;
            this.grdConfigCompanyRights.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvConfigCompanyRights});
            // 
            // dgvConfigCompanyRights
            // 
            this.dgvConfigCompanyRights.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.dgvConfigCompanyRights.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.dgvConfigCompanyRights.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.dgvConfigCompanyRights.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.dgvConfigCompanyRights.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.dgvConfigCompanyRights.Appearance.FooterPanel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvConfigCompanyRights.Appearance.FooterPanel.Options.UseFont = true;
            this.dgvConfigCompanyRights.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvConfigCompanyRights.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgvConfigCompanyRights.Appearance.Row.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvConfigCompanyRights.Appearance.Row.Options.UseFont = true;
            this.dgvConfigCompanyRights.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clmEmployeeId,
            this.clmEmployeeName,
            this.clmActive,
            this.clmUserName});
            this.dgvConfigCompanyRights.GridControl = this.grdConfigCompanyRights;
            this.dgvConfigCompanyRights.Name = "dgvConfigCompanyRights";
            this.dgvConfigCompanyRights.OptionsBehavior.Editable = false;
            this.dgvConfigCompanyRights.OptionsBehavior.ReadOnly = true;
            this.dgvConfigCompanyRights.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvConfigCompanyRights.OptionsView.ColumnAutoWidth = false;
            this.dgvConfigCompanyRights.OptionsView.ShowAutoFilterRow = true;
            this.dgvConfigCompanyRights.OptionsView.ShowFooter = true;
            this.dgvConfigCompanyRights.OptionsView.ShowGroupPanel = false;
            this.dgvConfigCompanyRights.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgvConfigCompanyRights_FocusedRowChanged_1);
            // 
            // clmEmployeeId
            // 
            this.clmEmployeeId.Caption = "User Id";
            this.clmEmployeeId.FieldName = "user_id";
            this.clmEmployeeId.Name = "clmEmployeeId";
            this.clmEmployeeId.OptionsColumn.AllowEdit = false;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Caption = "Employee Name";
            this.clmEmployeeName.FieldName = "employee_name";
            this.clmEmployeeName.Name = "clmEmployeeName";
            this.clmEmployeeName.OptionsColumn.AllowEdit = false;
            this.clmEmployeeName.Visible = true;
            this.clmEmployeeName.VisibleIndex = 1;
            // 
            // clmActive
            // 
            this.clmActive.Caption = "Active";
            this.clmActive.FieldName = "active";
            this.clmActive.Name = "clmActive";
            this.clmActive.OptionsColumn.AllowEdit = false;
            // 
            // clmUserName
            // 
            this.clmUserName.Caption = "User Name";
            this.clmUserName.FieldName = "user_name";
            this.clmUserName.Name = "clmUserName";
            this.clmUserName.OptionsColumn.AllowEdit = false;
            this.clmUserName.Visible = true;
            this.clmUserName.VisibleIndex = 0;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.labelControl2);
            this.panelControl5.Controls.Add(this.txtUName);
            this.panelControl5.Controls.Add(this.labelControl1);
            this.panelControl5.Controls.Add(this.labelControl38);
            this.panelControl5.Controls.Add(this.labelControl30);
            this.panelControl5.Controls.Add(this.labelControl3);
            this.panelControl5.Controls.Add(this.labelControl22);
            this.panelControl5.Controls.Add(this.panelControl6);
            this.panelControl5.Controls.Add(this.lueCompany);
            this.panelControl5.Controls.Add(this.lueBranch);
            this.panelControl5.Controls.Add(this.lueLocation);
            this.panelControl5.Controls.Add(this.lueDepartment);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(259, 11);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(667, 408);
            this.panelControl5.TabIndex = 26;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(70, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(6, 13);
            this.labelControl2.TabIndex = 419;
            this.labelControl2.Text = "*";
            // 
            // txtUName
            // 
            this.txtUName.EnterMoveNextControl = true;
            this.txtUName.Location = new System.Drawing.Point(78, 9);
            this.txtUName.Name = "txtUName";
            this.txtUName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUName.Properties.Appearance.Options.UseFont = true;
            this.txtUName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUName.Size = new System.Drawing.Size(187, 20);
            this.txtUName.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(8, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 58;
            this.labelControl1.Text = "User Name";
            // 
            // labelControl38
            // 
            this.labelControl38.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl38.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl38.Appearance.Options.UseFont = true;
            this.labelControl38.Appearance.Options.UseForeColor = true;
            this.labelControl38.Location = new System.Drawing.Point(8, 117);
            this.labelControl38.Name = "labelControl38";
            this.labelControl38.Size = new System.Drawing.Size(57, 13);
            this.labelControl38.TabIndex = 56;
            this.labelControl38.Text = "Department";
            // 
            // labelControl30
            // 
            this.labelControl30.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl30.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl30.Appearance.Options.UseFont = true;
            this.labelControl30.Appearance.Options.UseForeColor = true;
            this.labelControl30.Location = new System.Drawing.Point(8, 61);
            this.labelControl30.Name = "labelControl30";
            this.labelControl30.Size = new System.Drawing.Size(33, 13);
            this.labelControl30.TabIndex = 55;
            this.labelControl30.Text = "Branch";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(8, 39);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 13);
            this.labelControl3.TabIndex = 54;
            this.labelControl3.Text = "Company";
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl22.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl22.Appearance.Options.UseFont = true;
            this.labelControl22.Appearance.Options.UseForeColor = true;
            this.labelControl22.Location = new System.Drawing.Point(8, 87);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(40, 13);
            this.labelControl22.TabIndex = 53;
            this.labelControl22.Text = "Location";
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.lblMode);
            this.panelControl6.Controls.Add(this.btnExit);
            this.panelControl6.Controls.Add(this.btnClear);
            this.panelControl6.Controls.Add(this.btnSave);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl6.Location = new System.Drawing.Point(2, 358);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(663, 48);
            this.panelControl6.TabIndex = 9;
            // 
            // lblMode
            // 
            this.lblMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMode.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Appearance.Options.UseFont = true;
            this.lblMode.Appearance.Options.UseForeColor = true;
            this.lblMode.Location = new System.Drawing.Point(267, 14);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(63, 13);
            this.lblMode.TabIndex = 12;
            this.lblMode.Text = "Add Mode";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.ImageOptions.Image = global::Krishna_Textiles.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(556, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 32);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.ImageOptions.Image = global::Krishna_Textiles.Properties.Resources.Clear;
            this.btnClear.Location = new System.Drawing.Point(448, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 32);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "&Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = global::Krishna_Textiles.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(340, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lueCompany
            // 
            this.lueCompany.Location = new System.Drawing.Point(78, 35);
            this.lueCompany.Name = "lueCompany";
            this.lueCompany.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueCompany.Properties.Appearance.Options.UseFont = true;
            this.lueCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCompany.Size = new System.Drawing.Size(187, 20);
            this.lueCompany.TabIndex = 1;
            // 
            // lueBranch
            // 
            this.lueBranch.Location = new System.Drawing.Point(78, 61);
            this.lueBranch.Name = "lueBranch";
            this.lueBranch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueBranch.Properties.Appearance.Options.UseFont = true;
            this.lueBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBranch.Size = new System.Drawing.Size(187, 20);
            this.lueBranch.TabIndex = 2;
            // 
            // lueLocation
            // 
            this.lueLocation.Location = new System.Drawing.Point(78, 87);
            this.lueLocation.Name = "lueLocation";
            this.lueLocation.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueLocation.Properties.Appearance.Options.UseFont = true;
            this.lueLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueLocation.Size = new System.Drawing.Size(187, 20);
            this.lueLocation.TabIndex = 3;
            // 
            // lueDepartment
            // 
            this.lueDepartment.Location = new System.Drawing.Point(78, 113);
            this.lueDepartment.Name = "lueDepartment";
            this.lueDepartment.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueDepartment.Properties.Appearance.Options.UseFont = true;
            this.lueDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDepartment.Size = new System.Drawing.Size(187, 20);
            this.lueDepartment.TabIndex = 4;
            // 
            // panelControl4
            // 
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(259, 419);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(667, 11);
            this.panelControl4.TabIndex = 25;
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(259, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(667, 11);
            this.panelControl1.TabIndex = 23;
            // 
            // panelControl3
            // 
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(926, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(11, 430);
            this.panelControl3.TabIndex = 24;
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(248, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(11, 430);
            this.panelControl2.TabIndex = 22;
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
            this.ContextMNExport.Size = new System.Drawing.Size(153, 158);
            // 
            // MNExportExcel
            // 
            this.MNExportExcel.Name = "MNExportExcel";
            this.MNExportExcel.Size = new System.Drawing.Size(152, 22);
            this.MNExportExcel.Text = "To Excel";
            this.MNExportExcel.Click += new System.EventHandler(this.MNExportExcel_Click);
            // 
            // MNExportPDF
            // 
            this.MNExportPDF.Name = "MNExportPDF";
            this.MNExportPDF.Size = new System.Drawing.Size(152, 22);
            this.MNExportPDF.Text = "To PDF";
            this.MNExportPDF.Click += new System.EventHandler(this.MNExportPDF_Click);
            // 
            // MNExportTEXT
            // 
            this.MNExportTEXT.Name = "MNExportTEXT";
            this.MNExportTEXT.Size = new System.Drawing.Size(152, 22);
            this.MNExportTEXT.Text = "To TEXT";
            this.MNExportTEXT.Click += new System.EventHandler(this.MNExportTEXT_Click);
            // 
            // MNExportHTML
            // 
            this.MNExportHTML.Name = "MNExportHTML";
            this.MNExportHTML.Size = new System.Drawing.Size(152, 22);
            this.MNExportHTML.Text = "To HTML";
            this.MNExportHTML.Click += new System.EventHandler(this.MNExportHTML_Click);
            // 
            // MNExportRTF
            // 
            this.MNExportRTF.Name = "MNExportRTF";
            this.MNExportRTF.Size = new System.Drawing.Size(152, 22);
            this.MNExportRTF.Text = "To RTF";
            this.MNExportRTF.Click += new System.EventHandler(this.MNExportRTF_Click);
            // 
            // MNExportCSV
            // 
            this.MNExportCSV.Name = "MNExportCSV";
            this.MNExportCSV.Size = new System.Drawing.Size(152, 22);
            this.MNExportCSV.Text = "To CSV";
            this.MNExportCSV.Click += new System.EventHandler(this.MNExportCSV_Click);
            // 
            // FrmConfigPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 430);
            this.Controls.Add(this.panelControl5);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "FrmConfigPermission";
            this.Text = "Config Permission";
            this.Load += new System.EventHandler(this.FrmConfigPermission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdConfigCompanyRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigCompanyRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.panelControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.ContextMNExport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl grdConfigCompanyRights;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvConfigCompanyRights;
        private DevExpress.XtraGrid.Columns.GridColumn clmEmployeeId;
        private DevExpress.XtraGrid.Columns.GridColumn clmEmployeeName;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.LabelControl lblMode;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl38;
        private DevExpress.XtraEditors.LabelControl labelControl30;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit lueCompany;
        private DevExpress.XtraEditors.CheckedComboBoxEdit lueBranch;
        private DevExpress.XtraEditors.CheckedComboBoxEdit lueLocation;
        private DevExpress.XtraEditors.CheckedComboBoxEdit lueDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn clmActive;
        private DevExpress.XtraGrid.Columns.GridColumn clmUserName;
        private DevExpress.XtraEditors.TextEdit txtUName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ContextMenuStrip ContextMNExport;
        private System.Windows.Forms.ToolStripMenuItem MNExportExcel;
        private System.Windows.Forms.ToolStripMenuItem MNExportPDF;
        private System.Windows.Forms.ToolStripMenuItem MNExportTEXT;
        private System.Windows.Forms.ToolStripMenuItem MNExportHTML;
        private System.Windows.Forms.ToolStripMenuItem MNExportRTF;
        private System.Windows.Forms.ToolStripMenuItem MNExportCSV;
    }
}