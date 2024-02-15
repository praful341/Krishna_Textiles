using BLL.FunctionClasses.Utility;
using Account_Management.Class;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Account_Management.Utility
{
    public partial class FrmEmailSend : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        delegate void deltest();
        BLL.Validation Val = new BLL.Validation();
        public string mStrSubject = "";
        public string mStrAttachments = "";

        DataTable DTab = new DataTable();

        #region Property Settings

        public FrmEmailSend()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            Val.frmGenSetForPopup(this);
            AttachFormEvents();
            DTab = new DataTable();
            DTab.Columns.Add(new DataColumn("FILE_NAME", typeof(String)));
            DTab.Columns.Add(new DataColumn("FILE_PATH", typeof(String)));
            DTab.Columns.Add(new DataColumn("SIZE", typeof(String)));

            txtToAddress.Focus();

            this.ShowDialog();
        }

        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = false;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        #endregion

        #region Events

        private void BtnAttachment_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open = new OpenFileDialog();
            if (Open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AddRow(Open.FileName);
            }
            Open.Dispose();
            Open = null;
        }


        private void FrmEmailSend_Load(object sender, EventArgs e)
        {

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Blue");

            foreach (string Str in mStrAttachments.Split(','))
            {
                AddRow(Str);
            }

            txtSubject.Text = mStrSubject;

            string StrBody = @"<html><body><p><P>
                                <P>
                                <P>
                                <P>
                                <P>
                                <P><STRONG><FONT face=Verdana color=#000080 size=2>Dear All</FONT></STRONG></P>
                                <P><STRONG><FONT face=Verdana size=2>{0}</FONT></STRONG></P>
                                <P><STRONG><FONT face=Verdana size=2></FONT></STRONG>&nbsp;</P>
                                <P><STRONG><FONT face=Verdana size=2></FONT></STRONG>&nbsp;</P>
                                <P><STRONG><FONT face=Verdana color=#535353 size=2>Thanks &amp; Regards</FONT></STRONG></P>
                                <P><STRONG><FONT face=Verdana color=#535353 size=2>{1}</FONT></STRONG></P>
                                <P><STRONG><FONT face=Verdana color=#0000ff size=2>KAKADIAM</FONT></STRONG></P>
                                <P><STRONG><FONT face=Verdana color=#0000ff size=2>{2}</FONT></STRONG></P>
                                <P><STRONG><FONT face=Verdana size=2>M # <FONT color=#408080>{3}</FONT></FONT></STRONG></P>
                                <P><STRONG><FONT face=Verdana size=2></FONT></STRONG>&nbsp;</P>
                                <P></P><BR>
                                <P></P><BR>
                                <P></P><BR>
                                <P></P><BR>
                                <P></P><BR></p></br></body></html>";

            string StrEMailBody = string.Format(StrBody,
                       "<< write note >>",
                       BLL.GlobalDec.gEmployeeProperty.user_name,
                       BLL.GlobalDec.gEmployeeProperty.location_name,
                       BLL.GlobalDec.gEmployeeProperty.mobile_no
                       );

            ContHtml.setHtml(StrEMailBody);
            txtToAddress.Focus();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        private void FrmEmailSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(null, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Global.gMainFormRef.Activate();
            Global.gMainFormRef.Focus();
            this.Hide();
            this.Close();
            this.Dispose();
        }

        private void btnGridDelete_Click(object sender, EventArgs e)
        {
            DTab.Rows.RemoveAt(GrdDet.FocusedRowHandle);
            DTab.AcceptChanges();
            SetDataBinding();
            CalculateTotalSize();
        }

        private void GrdDet_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            if (e.Clicks == 2)
            {
                string FilePath = Val.ToString(GrdDet.GetRowCellValue(GrdDet.FocusedRowHandle, "FILE_PATH"));
                System.Diagnostics.Process.Start(FilePath, "CMD");
            }
        }

        #endregion

        #region Operation

        public void AddRow(string pStrfilePath)
        {
            if (pStrfilePath.Length == 0)
            {
                return;
            }
            FileInfo FInfo = new FileInfo(pStrfilePath);

            bool IsExists = false;


            foreach (DataRow DROw in DTab.Rows)
            {
                if (Val.ToString(DROw["FILE_PATH"]) == pStrfilePath)
                {
                    IsExists = true;
                    break;
                }
            }

            if (IsExists == false)
            {
                double Size = System.Math.Round(Val.Val((FInfo.Length / 1024)) / 1024, 3);
                if (Size > 25)
                {
                    Global.Message("Your File Size Is Greater Than 25 MB. Please Select less 25 MB Size");
                    return;
                }
                DataRow DRow = DTab.NewRow();
                DRow["FILE_PATH"] = pStrfilePath;
                DRow["FILE_NAME"] = FInfo.Name.ToString();
                DRow["SIZE"] = Size.ToString() + " MB";
                DTab.Rows.Add(DRow);
                SetDataBinding();
            }
            CalculateTotalSize();
        }

        public void SetDataBinding()
        {
            MainGridDetail.DataSource = DTab;
            MainGridDetail.Refresh();
        }

        public void CalculateTotalSize()
        {
            double DouSize = 0;
            foreach (DataRow DROw in DTab.Rows)
            {
                string Str = Val.ToString(DROw["SIZE"]).Replace("MB", "").Replace(" ", "");

                DouSize = DouSize + Val.Val(Str);
            }
            if (DouSize != 0)
            {
                lblTotalSize.Text = DouSize.ToString() + " MB";
            }
            else
            {
                lblTotalSize.Text = "0.00 MB";
            }
        }

        public void SendEmail()
        {
            try
            {
                if (Val.Val(lblTotalSize.Text.Replace("MB", "").Replace(" ", "")) > 25)
                {
                    Global.Message("Your Total Files Size Greater Than 25 MB.");
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                string pStrBody = ContHtml.getHtml();

                string pStrAttachment = "";

                foreach (DataRow DROw in DTab.Rows)
                {
                    pStrAttachment = pStrAttachment + Val.ToString(DROw["FILE_PATH"]) + ",";
                }
                if (pStrAttachment.Length != 0)
                {
                    pStrAttachment = pStrAttachment.Substring(0, pStrAttachment.Length - 1);
                }

                string StrRes = EmailSendUtility.SendEMail(txtToAddress.Text, txtSubject.Text, pStrBody, txtCcMail.Text, "", txtBccEmail.Text, pStrAttachment);
                this.Cursor = Cursors.Default;
                Global.Message(StrRes);
                btnClose_Click(null, null);
            }
            catch (Exception E)
            {
                Global.Message(E.Message);
            }
        }

        public void Callme()
        {
            Invoke((MethodInvoker)delegate { activityIndicator.isRunning = false; });
            Invoke((MethodInvoker)delegate { activityIndicator.Visible = false; });
            Invoke((MethodInvoker)delegate { this.Close(); });
        }
        #endregion
    }
}
