using BLL.FunctionClasses.Report;
using System;
using System.Data;
using System.Windows.Forms;
using Global = Account_Management.Class.Global;
namespace Account_Management.Report
{
    public partial class FrmReportListNew : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        string mStrReportGroup = string.Empty;
        BLL.FunctionClasses.Master.EmployeeMaster ObjEmployeeRight = new BLL.FunctionClasses.Master.EmployeeMaster();

        #region Counstructor
        public FrmReportListNew()
        {
            InitializeComponent();
        }

        public void ShowForm(string pStrReportGroup)
        {
            mStrReportGroup = pStrReportGroup;
            Val.frmGenSet(this);
            AttachFormEvents();
            lblTitle.Text = mStrReportGroup + " Reports..";
            this.Text = mStrReportGroup + " Reports..";
            GetData();
            this.Show();
        }

        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Operation

        private void GetData()
        {
            DataTable DTab = new NewReportMaster().GetDataForSearchMaster(0, mStrReportGroup, BLL.GlobalDec.gEmployeeProperty.user_id);

            DgvMainGrd.DataSource = DTab;
            DgvMainGrd.Refresh();
            dgvSearch.Columns["report_code"].Visible = false;
            dgvSearch.Columns["report_group_name"].Visible = false;
            dgvSearch.Columns["form_name"].Visible = false;
            dgvSearch.Columns["sequence_no"].Visible = false;
            dgvSearch.Columns["active"].Visible = false;
            dgvSearch.Columns["remark"].Visible = false;
            dgvSearch.Columns["disp_in"].Visible = false;
            dgvSearch.Columns["Section"].GroupIndex = 1;
            dgvSearch.Columns["Section"].Visible = false;
        }

        #endregion

        private void dgvSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string StrForm = dgvSearch.GetRowCellValue(dgvSearch.FocusedRowHandle, "form_name").ToString();
                string StrReportCode = dgvSearch.GetRowCellValue(dgvSearch.FocusedRowHandle, "report_code").ToString();
                Global.OpenForm(StrForm, StrReportCode);
            }

            if (e.KeyCode == Keys.E && e.Control == true)
            {
                FrmNewReportMaster FrmNewReportMaster = new FrmNewReportMaster();
                FrmNewReportMaster.MdiParent = Global.gMainFormRef;

                FrmNewReportMaster.StrReportGroupName = dgvSearch.GetRowCellValue(dgvSearch.FocusedRowHandle, "report_group_name").ToString();
                int IntReportCode = Val.ToInt(dgvSearch.GetRowCellValue(dgvSearch.FocusedRowHandle, "report_code").ToString());
                FrmNewReportMaster.ShowForm(IntReportCode);
            }
            if (e.KeyCode == Keys.A && e.Control == true)
            {
                FrmNewReportMaster FrmNewReportMaster = new FrmNewReportMaster();
                FrmNewReportMaster.MdiParent = Global.gMainFormRef;
                FrmNewReportMaster.ShowForm(0);
            }
        }

        private void dgvSearch_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSearch.FocusedRowHandle != -1)
            {
                string StrForm = Val.ToString(dgvSearch.GetRowCellValue(dgvSearch.FocusedRowHandle, "form_name"));
                string StrReportCode = Val.ToString(dgvSearch.GetRowCellValue(dgvSearch.FocusedRowHandle, "report_code"));

                if (StrForm == "" && StrReportCode == "")
                    return;
                Global.OpenForm(StrForm, StrReportCode);
            }
        }
    }
}
