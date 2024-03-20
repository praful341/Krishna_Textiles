namespace Account_Management.Transaction
{
    partial class FrmSaleInvoiceSearch
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
            this.clmRSAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClmLotSrNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).BeginInit();
            this.ContextMNExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainGrid
            // 
            this.MainGrid.ContextMenuStrip = this.ContextMNExport;
            this.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGrid.Location = new System.Drawing.Point(2, 2);
            this.MainGrid.MainView = this.GrdDet;
            this.MainGrid.Name = "MainGrid";
            this.MainGrid.Size = new System.Drawing.Size(595, 345);
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
            this.GrdDet.Appearance.FocusedCell.Font = new System.Drawing.Font("Verdana", 9F);
            this.GrdDet.Appearance.FocusedCell.Options.UseFont = true;
            this.GrdDet.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 9F);
            this.GrdDet.Appearance.FocusedRow.Options.UseFont = true;
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
            this.gridColumn1});
            this.GrdDet.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GrdDet.GridControl = this.MainGrid;
            this.GrdDet.Name = "GrdDet";
            this.GrdDet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.GrdDet.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.GrdDet.OptionsBehavior.Editable = false;
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
            this.gridColumn2.Caption = "Invoice ID";
            this.gridColumn2.FieldName = "invoice_id";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 83;
            // 
            // clmRSAmount
            // 
            this.clmRSAmount.Caption = "OS Amount";
            this.clmRSAmount.FieldName = "os_amount";
            this.clmRSAmount.Name = "clmRSAmount";
            this.clmRSAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clmRSAmount.Visible = true;
            this.clmRSAmount.VisibleIndex = 2;
            this.clmRSAmount.Width = 106;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.Caption = "Order No";
            this.gridColumn8.FieldName = "order_no";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 117;
            // 
            // ClmLotSrNo
            // 
            this.ClmLotSrNo.Caption = "Details";
            this.ClmLotSrNo.FieldName = "details";
            this.ClmLotSrNo.Name = "ClmLotSrNo";
            this.ClmLotSrNo.Visible = true;
            this.ClmLotSrNo.VisibleIndex = 4;
            this.ClmLotSrNo.Width = 150;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Due Date";
            this.gridColumn1.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "due_date";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 119;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.MainGrid);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(599, 349);
            this.panelControl2.TabIndex = 16;
            // 
            // FrmSaleInvoiceSearch
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 349);
            this.Controls.Add(this.panelControl2);
            this.KeyPreview = true;
            this.Name = "FrmSaleInvoiceSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SALE INVOICE SEARCH";
            this.Load += new System.EventHandler(this.FrmJangedConfirm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmJangedConfirm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).EndInit();
            this.ContextMNExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl MainGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView GrdDet;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
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
    }
}