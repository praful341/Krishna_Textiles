using DLL;
using System.Collections;
using System.Data;

namespace BLL
{
    /// <summary> Class Implementation For 
    /// Checking Form Level Permission For A Login User In A Perticular 
    /// Department
    /// </summary>
    public class FormPer
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();


        private string _FormName = "";
        /// <summary>
        /// Form Name
        /// </summary>
        public string FormName
        {
            get { return _FormName; }
            set
            {
                _FormName = value;
                SetFormPer();
            }
        }

        public int Start_Menu_Code { get; set; }
        private int _StartMenuCode = 0;
        /// <summary>
        /// Start Menu Name
        /// </summary>
        public int StartMenuCode
        {
            get { return _StartMenuCode; }
            set
            {
                _StartMenuCode = value;
                //SetStartMenu();
            }
        }

        private int _Report_Code;
        /// <summary>
        /// Form Name
        /// </summary>
        public int Report_Code
        {
            get { return _Report_Code; }
            set
            {
                _Report_Code = value;
                SetReportPer();
            }
        }

        public int form_id { get; set; }

        private Hashtable _FormHashTable = new Hashtable();
        /// <summary>
        /// Hash Table For Store Password
        /// </summary>
        public Hashtable FormHashTable
        {
            get { return _FormHashTable; }
            set { _FormHashTable = value; }
        }

        private string _FormPassWord = string.Empty;
        /// <summary>Property FormPassWord
        /// Get Form Level PassWord String
        /// Of A User
        /// </summary>
        public string FormPassWord
        {
            get { return _FormPassWord; }
        }

        private bool _AllowInsert = false;
        /// <summary>Property AllowInsert
        /// Check Form Level Insert Permission
        /// Of A User And Return True Or False Based 
        /// On Given Permission
        /// </summary>
        public bool AllowInsert
        {
            get { return _AllowInsert; }
        }
        private bool _AllowUpdate = false;
        /// <summary>Property AllowUpdate
        /// Check Form Level Update Permission
        /// Of A User And Return True Or False Based 
        /// On Given Permission
        /// </summary>
        public bool AllowUpdate
        {
            get { return _AllowUpdate; }
        }
        private bool _AllowDelete = false;
        /// <summary>Property AllowDelete
        /// Check Form Level Delete Permission
        /// Of A User And Return True Or False Based 
        /// On Given Permission
        /// </summary>

        public bool AllowDelete
        {
            get { return _AllowDelete; }
        }
        private bool _AllowView = false;
        /// <summary>Property AllowView
        /// Check Form Level View Permission
        /// Of A User And Return True Or False Based 
        /// On Given Permission
        /// </summary>
        public bool AllowView
        {
            get { return _AllowView; }
        }

        private bool _AllowPrint;

        public bool AllowPrint
        {
            get { return _AllowPrint; }
            set { _AllowPrint = value; }
        }

        private bool _AllowExp;

        public bool AllowExp
        {
            get { return _AllowExp; }
            set { _AllowExp = value; }
        }

        private bool _AllowEMail;

        public bool AllowEMail
        {
            get { return _AllowEMail; }
            set { _AllowEMail = value; }
        }

        /// <summary>Method That Set Form Level Permission
        /// 
        /// </summary>        
        public void SetFormPer()
        {
            Request Request = new DLL.Request();

            Request.AddParams("@role_id", GlobalDec.gEmployeeProperty.role_id, DbType.Int32);
            Request.AddParams("@form_name", _FormName, DbType.String);
            Request.CommandText = BLL.TPV.SProc.MST_UserAuth_CheckPermission;
            Request.CommandType = CommandType.StoredProcedure;

            DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            if (DRow == null)
            {
                _AllowInsert = false;
                _AllowUpdate = false;
                _AllowDelete = false;
                _AllowView = false;
                _AllowPrint = false;
                _AllowEMail = false;
                _AllowExp = false;
                _FormPassWord = string.Empty;
            }
            else
            {
                form_id = Val.ToInt(DRow["form_id"]);
                _AllowInsert = Val.ToString(DRow["allow_edit"]) == "True" ? true : false;
                _AllowUpdate = Val.ToString(DRow["allow_add"]) == "True" ? true : false;
                _AllowDelete = Val.ToString(DRow["allow_delete"]) == "True" ? true : false;
                _AllowView = Val.ToString(DRow["allow_view"]) == "True" ? true : false;
                _AllowExp = Val.ToString(DRow["allow_export"]) == "True" ? true : false;
                _AllowPrint = Val.ToString(DRow["allow_print"]) == "True" ? true : false;
                _AllowEMail = Val.ToString(DRow["allow_email"]) == "True" ? true : false;
                SetHashPass(_FormPassWord);
            }
        }

        public void SetReportPer()
        {
            Request Request = new DLL.Request();
            Request.AddParams("@report_code", _Report_Code, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Report_UserAuth_Permission;
            Request.CommandType = CommandType.StoredProcedure;

            DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            if (DRow == null)
            {
                _AllowPrint = false;
                _AllowEMail = false;
                _AllowExp = false;
                _FormPassWord = "";
            }
            else
            {
                _AllowPrint = Val.ToString(DRow["allow_print"]) == "True" ? true : false;
                _AllowEMail = Val.ToString(DRow["allow_email"]) == "True" ? true : false;
                _AllowExp = Val.ToString(DRow["allow_export"]) == "True" ? true : false;
            }
        }

        private void SetHashPass(string pStrPass)
        {
            string[] StrToken = pStrPass.Split(',');
            if (_FormHashTable.Keys.Count != 0)
            {
                _FormHashTable.Clear();
                _FormHashTable = null;
            }
            for (int IntI = 0; IntI < StrToken.Length; IntI++)
            {
                string[] StrSub = StrToken[IntI].Split('=');
                if (_FormHashTable == null)
                {
                    _FormHashTable = new Hashtable();
                }
                if (StrSub.Length > 1)
                {
                    _FormHashTable.Add(StrSub[0].ToString(), StrSub[1].ToString());
                }
                else if (StrSub.Length == 1)
                {
                    _FormPassWord = StrSub[0].ToString();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GetSubPass(string pKey)
        {
            string Result = "";
            foreach (object Obj in _FormHashTable.Keys)
            {
                if (Obj.ToString().Equals(pKey))
                {
                    Result = _FormHashTable[Obj].ToString();
                    break;
                }
            }
            return Result;
        }

        /// <summary> Method Use To Check Permission form Wise
        /// 
        /// </summary>
        /// <returns>Return True if user have Permmistion </returns>
        public bool CheckPermission()
        {
            if (AllowView == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Method For Check User Password
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public bool CheckFormPass(string pStr)
        {
            if (pStr == "")
            {
                return false;
            }
            if (FormPassWord == pStr.ToUpper())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method For Check User Password
        /// </summary>
        /// <param name="pStrPass"></param>
        /// <param name="pStrWork"></param>
        /// <returns></returns>
        public bool CheckFormPass(string pStrPass, string pStrWork)
        {
            if (pStrPass == "")
            {
                return false;
            }

            if (pStrPass == GetSubPass(pStrWork))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
