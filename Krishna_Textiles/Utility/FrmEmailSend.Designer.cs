namespace Krishna_Textiles.Utility
{
    partial class FrmEmailSend
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmailSend));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.LabelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.LabelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ContHtml = new Krishna_Textiles.UserControls.UCHTMLEditor();
            this.txtSubject = new DevExpress.XtraEditors.TextEdit();
            this.txtBccEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtToAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtCcMail = new DevExpress.XtraEditors.TextEdit();
            this.activityIndicator = new iFormControls.iFormLoadingLoop(this.components);
            this.MainGridDetail = new DevExpress.XtraGrid.GridControl();
            this.GrdDet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Delete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnGridDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.FileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FilePath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Size = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.BtnAttachment = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalSize = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBccEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCcMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGridDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelControl2
            // 
            this.LabelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelControl2.Appearance.Options.UseFont = true;
            this.LabelControl2.Location = new System.Drawing.Point(8, 128);
            this.LabelControl2.Name = "LabelControl2";
            this.LabelControl2.Size = new System.Drawing.Size(49, 13);
            this.LabelControl2.TabIndex = 6;
            this.LabelControl2.Text = "Subject :";
            // 
            // LabelControl1
            // 
            this.LabelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelControl1.Appearance.Options.UseFont = true;
            this.LabelControl1.Location = new System.Drawing.Point(8, 41);
            this.LabelControl1.Name = "LabelControl1";
            this.LabelControl1.Size = new System.Drawing.Size(20, 13);
            this.LabelControl1.TabIndex = 0;
            this.LabelControl1.Text = "To :";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Location = new System.Drawing.Point(152, 519);
            this.btnClose.LookAndFeel.SkinName = "Money Twins";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Cl&ose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSend
            // 
            this.btnSend.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Appearance.Options.UseFont = true;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.Location = new System.Drawing.Point(70, 519);
            this.btnSend.LookAndFeel.SkinName = "Money Twins";
            this.btnSend.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(76, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "&Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.Controls.Add(this.ContHtml);
            this.groupControl1.Controls.Add(this.txtSubject);
            this.groupControl1.Controls.Add(this.txtBccEmail);
            this.groupControl1.Controls.Add(this.txtToAddress);
            this.groupControl1.Controls.Add(this.txtCcMail);
            this.groupControl1.Controls.Add(this.activityIndicator);
            this.groupControl1.Controls.Add(this.MainGridDetail);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.btnClose);
            this.groupControl1.Controls.Add(this.BtnAttachment);
            this.groupControl1.Controls.Add(this.btnSend);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.LabelControl1);
            this.groupControl1.Controls.Add(this.lblTotalSize);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.LabelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.LookAndFeel.SkinName = "Blue";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(888, 549);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Send EMail";
            // 
            // ContHtml
            // 
            this.ContHtml.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContHtml.Location = new System.Drawing.Point(70, 192);
            this.ContHtml.Name = "ContHtml";
            this.ContHtml.Size = new System.Drawing.Size(810, 321);
            this.ContHtml.TabIndex = 7;
            // 
            // txtSubject
            // 
            this.txtSubject.EnterMoveNextControl = true;
            this.txtSubject.Location = new System.Drawing.Point(70, 125);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Properties.Appearance.Options.UseFont = true;
            this.txtSubject.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSubject.Size = new System.Drawing.Size(494, 20);
            this.txtSubject.TabIndex = 3;
            // 
            // txtBccEmail
            // 
            this.txtBccEmail.EnterMoveNextControl = true;
            this.txtBccEmail.Location = new System.Drawing.Point(70, 96);
            this.txtBccEmail.Name = "txtBccEmail";
            this.txtBccEmail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBccEmail.Properties.Appearance.Options.UseFont = true;
            this.txtBccEmail.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBccEmail.Size = new System.Drawing.Size(494, 20);
            this.txtBccEmail.TabIndex = 2;
            // 
            // txtToAddress
            // 
            this.txtToAddress.EnterMoveNextControl = true;
            this.txtToAddress.Location = new System.Drawing.Point(70, 38);
            this.txtToAddress.Name = "txtToAddress";
            this.txtToAddress.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToAddress.Properties.Appearance.Options.UseFont = true;
            this.txtToAddress.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtToAddress.Size = new System.Drawing.Size(494, 20);
            this.txtToAddress.TabIndex = 0;
            // 
            // txtCcMail
            // 
            this.txtCcMail.EnterMoveNextControl = true;
            this.txtCcMail.Location = new System.Drawing.Point(70, 67);
            this.txtCcMail.Name = "txtCcMail";
            this.txtCcMail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCcMail.Properties.Appearance.Options.UseFont = true;
            this.txtCcMail.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCcMail.Size = new System.Drawing.Size(494, 20);
            this.txtCcMail.TabIndex = 1;
            // 
            // activityIndicator
            // 
            this.activityIndicator.Color = System.Drawing.Color.Teal;
            this.activityIndicator.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityIndicator.ForeColor = System.Drawing.Color.Teal;
            this.activityIndicator.InnerCircleRadius = 8;
            this.activityIndicator.isRunning = false;
            this.activityIndicator.Location = new System.Drawing.Point(5, 519);
            this.activityIndicator.LoopDensity = 10;
            this.activityIndicator.LoopLineThickness = 4;
            this.activityIndicator.Name = "activityIndicator";
            this.activityIndicator.OuterCircleRadius = 10;
            this.activityIndicator.RotationSpeed = 100;
            this.activityIndicator.Size = new System.Drawing.Size(30, 26);
            this.activityIndicator.TabIndex = 6;
            this.activityIndicator.Text = "Loading";
            this.activityIndicator.Visible = false;
            // 
            // MainGridDetail
            // 
            this.MainGridDetail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridLevelNode2.RelationName = "Level2";
            gridLevelNode1.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            gridLevelNode1.RelationName = "Level1";
            this.MainGridDetail.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.MainGridDetail.Location = new System.Drawing.Point(575, 25);
            this.MainGridDetail.LookAndFeel.SkinName = "Money Twins";
            this.MainGridDetail.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MainGridDetail.MainView = this.GrdDet;
            this.MainGridDetail.Name = "MainGridDetail";
            this.MainGridDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnGridDelete});
            this.MainGridDetail.Size = new System.Drawing.Size(305, 143);
            this.MainGridDetail.TabIndex = 5;
            this.MainGridDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GrdDet});
            // 
            // GrdDet
            // 
            this.GrdDet.Appearance.HeaderPanel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.GrdDet.Appearance.HeaderPanel.Options.UseFont = true;
            this.GrdDet.Appearance.Row.Font = new System.Drawing.Font("Verdana", 9F);
            this.GrdDet.Appearance.Row.Options.UseFont = true;
            this.GrdDet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Delete,
            this.FileName,
            this.FilePath,
            this.Size});
            this.GrdDet.GridControl = this.MainGridDetail;
            this.GrdDet.Name = "GrdDet";
            this.GrdDet.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GrdDet.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.GrdDet.OptionsView.ColumnAutoWidth = false;
            this.GrdDet.OptionsView.ShowGroupPanel = false;
            this.GrdDet.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GrdDet_RowClick);
            // 
            // Delete
            // 
            this.Delete.ColumnEdit = this.btnGridDelete;
            this.Delete.Name = "Delete";
            this.Delete.Tag = "BtnDelete";
            this.Delete.Visible = true;
            this.Delete.VisibleIndex = 2;
            this.Delete.Width = 35;
            // 
            // btnGridDelete
            // 
            this.btnGridDelete.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.btnGridDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnGridDelete.Name = "btnGridDelete";
            this.btnGridDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnGridDelete.Click += new System.EventHandler(this.btnGridDelete_Click);
            // 
            // FileName
            // 
            this.FileName.Caption = "File";
            this.FileName.FieldName = "FILE_NAME";
            this.FileName.Name = global::Krishna_Textiles.Properties.Settings.Default.ORIGINAL_FILENAME;
            this.FileName.OptionsColumn.AllowEdit = false;
            this.FileName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.FileName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.FileName.Visible = true;
            this.FileName.VisibleIndex = 0;
            this.FileName.Width = 161;
            // 
            // FilePath
            // 
            this.FilePath.Caption = "Path";
            this.FilePath.FieldName = "FILE_PATH";
            this.FilePath.Name = global::Krishna_Textiles.Properties.Settings.Default.UPLOADED_FILENAME;
            this.FilePath.OptionsColumn.AllowEdit = false;
            this.FilePath.Width = 250;
            // 
            // Size
            // 
            this.Size.Caption = "Size";
            this.Size.FieldName = "SIZE";
            this.Size.Name = global::Krishna_Textiles.Properties.Settings.Default.UPLOAD_BY_USERNAME;
            this.Size.OptionsColumn.AllowEdit = false;
            this.Size.Visible = true;
            this.Size.VisibleIndex = 1;
            this.Size.Width = 72;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(8, 99);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(25, 13);
            this.labelControl6.TabIndex = 4;
            this.labelControl6.Text = "Bcc :";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(8, 70);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(19, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Cc :";
            // 
            // BtnAttachment
            // 
            this.BtnAttachment.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAttachment.Appearance.Options.UseFont = true;
            this.BtnAttachment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAttachment.Location = new System.Drawing.Point(463, 153);
            this.BtnAttachment.LookAndFeel.SkinName = "Money Twins";
            this.BtnAttachment.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnAttachment.Name = "BtnAttachment";
            this.BtnAttachment.Size = new System.Drawing.Size(101, 33);
            this.BtnAttachment.TabIndex = 4;
            this.BtnAttachment.Text = "Attachment";
            this.BtnAttachment.Click += new System.EventHandler(this.BtnAttachment_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(575, 174);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(176, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "NOTE : Double Click To Open File";
            // 
            // lblTotalSize
            // 
            this.lblTotalSize.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSize.Appearance.Options.UseFont = true;
            this.lblTotalSize.Location = new System.Drawing.Point(825, 174);
            this.lblTotalSize.Name = "lblTotalSize";
            this.lblTotalSize.Size = new System.Drawing.Size(55, 13);
            this.lblTotalSize.TabIndex = 6;
            this.lblTotalSize.Text = "Total Size";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(8, 192);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(56, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Message :";
            // 
            // FrmEmailSend
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(888, 549);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmEmailSend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email Send Utility";
            this.Load += new System.EventHandler(this.FrmEmailSend_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEmailSend_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBccEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCcMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGridDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl LabelControl2;
        internal DevExpress.XtraEditors.LabelControl LabelControl1;
        internal DevExpress.XtraEditors.SimpleButton btnClose;
        internal DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private UserControls.UCHTMLEditor uchtmlEditor2;
        internal DevExpress.XtraEditors.LabelControl labelControl4;
        internal DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraGrid.GridControl MainGridDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView GrdDet;
        private DevExpress.XtraGrid.Columns.GridColumn FileName;
        private DevExpress.XtraGrid.Columns.GridColumn FilePath;
        private DevExpress.XtraGrid.Columns.GridColumn Size;
        private DevExpress.XtraGrid.Columns.GridColumn Delete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnGridDelete;
        internal DevExpress.XtraEditors.SimpleButton BtnAttachment;
        private iFormControls.iFormLoadingLoop activityIndicator;
        internal DevExpress.XtraEditors.LabelControl labelControl3;
        internal DevExpress.XtraEditors.LabelControl lblTotalSize;
        internal DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtSubject;
        private DevExpress.XtraEditors.TextEdit txtBccEmail;
        private DevExpress.XtraEditors.TextEdit txtToAddress;
        private DevExpress.XtraEditors.TextEdit txtCcMail;
        private UserControls.UCHTMLEditor ContHtml;
        //private UserControls.UCHTMLEditor uchtmlEditor2;
        //private DNKControlLib.dTextBox txtToAddress;
        //private DNKControlLib.dTextBox txtBccEmail;
        //private DNKControlLib.dTextBox txtCcMail;
        //private DNKControlLib.dTextBox txtSubject;
    }
}