using Account_Management.Class;
using Account_Management.MDI;
using BLL;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Utility;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Account_Management
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        Validation Val = new Validation();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            //string Name = GlobalDec.Decrypt("ZZrewCal9Ig/fWV4s//tmA==", true);
            //string Name1 = GlobalDec.Decrypt("hiF4OgAMMCMfwPT8AGNQrg==", true);
            //string Name2 = GlobalDec.Decrypt("1m1aoLWd69HR1weotAkwaw==", true);
            //string Name3 = GlobalDec.Decrypt("1DwL2KYsao4=", true);
            //string Name4 = GlobalDec.Decrypt("n47TmcAYNn6bZ+SDLKim0w==", true);

            //string Name2 = GlobalDec.Encrypt("sql5061.site4now.net", true);
            //string Name7 = GlobalDec.Encrypt("SAURASHTRA02", true);
            //string Name8 = GlobalDec.Encrypt("DB_A6D894_Mahakal_admin", true);
            //string Name9 = GlobalDec.Encrypt("SAURASHTRA", true);

            //string Name3 = GlobalDec.Decrypt("1QqQomlTTSVJlo8viYAky6as6Lk+lSz0", true);
            //string Name4 = GlobalDec.Decrypt("0rW5m3tTWItlPCk2IfB4BQ==", true);
            //string Name5 = GlobalDec.Decrypt("0rW5m3tTWIt7w4f4A02qjiFUfP8it9WO", true);
            //string Name6 = GlobalDec.Decrypt("u4JnY3Ap1sPR1weotAkwaw==", true);

            Global.gStrStrHostName = BLL.GlobalDec.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ServerHostName"].ToString(), true);
            Global.gStrStrServiceName = BLL.GlobalDec.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ServerServiceName"].ToString(), true);
            Global.gStrStrUserName = BLL.GlobalDec.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ServerUserName"].ToString(), true);
            Global.gStrStrPasssword = BLL.GlobalDec.Decrypt(System.Configuration.ConfigurationManager.AppSettings["ServerPassWord"].ToString(), true);

            BLL.DBConnections.ConnectionString = "Data Source=" + Global.gStrStrHostName + ";Initial Catalog=" + Global.gStrStrServiceName + ";User ID=" + Global.gStrStrUserName + ";Password=" + Global.gStrStrPasssword + ";";
            BLL.DBConnections.ProviderName = "System.Data.SqlClient";

            //if (GlobalDec.gStrComputerIP == "192.168.1.116" || GlobalDec.gStrComputerIP == "192.168.1.111" || GlobalDec.gStrComputerIP == "192.168.1.112" || GlobalDec.gStrComputerIP == "192.168.1.13" || GlobalDec.gStrComputerIP == "192.168.29.176" || GlobalDec.gStrComputerIP == "194.168.1.34" || GlobalDec.gStrComputerIP == "194.168.1.37" || GlobalDec.gStrComputerIP == "192.168.29.175")
            //{
            //    txtUserName.Text = "PRAFUL";
            //    txtPassword.Text = "123";
            //}
            //txtUserName.Text = "SHAKTI";
            //txtPassword.Text = "123";
            //btnLogin_Click(null, null);

            GlobalDec.gEmployeeProperty.is_deleted = false;
            try
            {
                String[] Str1 = Application.StartupPath.Split('\\');

                String FilePath = Str1[0].ToString();
                for (int i = 1; i < Str1.Length - 1; i++)
                {
                    FilePath = FilePath + "\\" + Str1[i].ToString();
                }

                string path = Application.StartupPath;
                DirectoryInfo di = new DirectoryInfo(path);
                FileInfo fi = di.Parent.GetFiles("DiamondVersion.txt").FirstOrDefault();
                string contents = File.ReadAllText(fi.FullName);
                string version = string.Join(".", contents.Split('\\').FirstOrDefault().Replace("D", "").ToCharArray());
                if (!string.IsNullOrEmpty(version))
                {
                    lblVersion.Text = version;
                }
                else
                {
                    string path_error = Application.StartupPath;
                    DirectoryInfo di_error = new DirectoryInfo(path);
                    FileInfo fi_error = di.Parent.GetFiles("DiamondVersion.txt").FirstOrDefault();
                    string contents_error = File.ReadAllText(fi.FullName);
                    string version_error = string.Join(".", contents.Split('\\').FirstOrDefault().Replace("D", "").ToCharArray());
                    lblVersion.Text = version_error;
                }
            }
            catch (Exception Ex)
            {
                if (System.IO.File.Exists(Application.StartupPath + "\\DiamondVersion.txt") == true)
                {
                    string[] Str = System.IO.File.ReadAllLines(Application.StartupPath + "\\DiamondVersion.txt");
                    if (Str.Length == 0)
                    {
                        return;
                    }
                    if (Str[0].Length == 0)
                    {
                        return;
                    }

                    this.lblVersion.Text = Val.ToString(Str[0]);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length == 0)
            {
                Global.Confirm("Please Enter UserName");
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text.Length == 0)
            {
                Global.Confirm("Please Enter Password");
                txtPassword.Focus();
                return;
            }

            Global.gStrVersion = lblVersion.Text;

            this.Cursor = Cursors.WaitCursor;

            Login objLogin = new Login();
            int IntRes = objLogin.CheckLogin(txtUserName.Text, GlobalDec.Encrypt(txtPassword.Text, true));

            this.Cursor = Cursors.Default;
            if (IntRes == -1)
            {
                Global.Confirm("Enter Valid UserName And Password");
                txtUserName.Focus();
                return;
            }
            else
            {
                FinancialYearMaster ObjFinancial = new FinancialYearMaster();
                DataTable tdt = ObjFinancial.GetData();
                GlobalDec.gEmployeeProperty.gFinancialYear = Val.ToString(tdt.Rows[0]["financial_year"]);
                GlobalDec.gEmployeeProperty.gFinancialYear_Code = Val.ToInt64(tdt.Rows[0]["fin_year_id"]);

                MDIMain MainForm = new MDIMain();
                BLL.FormPer ObjPer = new BLL.FormPer();
                Global.gMainFormRef = MainForm;
                this.Hide();
                MainForm.ShowDialog();
                //FrmHomePage MainForm = new FrmHomePage();
                //BLL.FormPer ObjPer = new BLL.FormPer();
                //Global.gMainFormRef = MainForm;
                //this.Hide();
                //MainForm.ShowDialog();
                this.Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //    this.Close();

            if (e.Shift && e.KeyCode == Keys.Delete)
            {
                Global.Message("avc");
            }


            //if (e.Control && e.Shift && e.Alt && e.KeyCode == Keys.X)
            //{
            //    GlobalDec.gEmployeeProperty.is_deleted = true;
            //    btnLogin.ForeColor = Color.Blue;
            //    btnLogin.ForeColor = Color.Blue;
            //    btnCancel.ForeColor = Color.Blue;
            //    btnCancel.ForeColor = Color.Blue;
            //}
            //else if (e.Control && e.Shift && e.Alt && e.KeyCode == Keys.Z)
            //{
            //    GlobalDec.gEmployeeProperty.is_deleted = false;
            //    btnLogin.ForeColor = Color.Black;
            //    btnLogin.ForeColor = Color.Black;
            //    btnCancel.ForeColor = Color.Black;
            //    btnCancel.ForeColor = Color.Black;
            //}
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.Alt && e.KeyCode == Keys.X)
            {
                GlobalDec.gEmployeeProperty.is_deleted = true;
                btnLogin.ForeColor = Color.Blue;
                btnLogin.ForeColor = Color.Blue;
                btnCancel.ForeColor = Color.Blue;
                btnCancel.ForeColor = Color.Blue;
            }
            else if (e.Shift && e.Alt && e.KeyCode == Keys.Z)
            {
                GlobalDec.gEmployeeProperty.is_deleted = false;
                btnLogin.ForeColor = Color.Black;
                btnLogin.ForeColor = Color.Black;
                btnCancel.ForeColor = Color.Black;
                btnCancel.ForeColor = Color.Black;
            }
        }
    }
}
