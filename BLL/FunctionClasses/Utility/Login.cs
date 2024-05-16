using DLL;
using System.Data;

namespace BLL.FunctionClasses.Utility
{
    public class Login
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Other Function
        public int CheckLogin(string UserName, string Password)
        {
            DataRow Drow;
            Request Request = new Request();
            Request.AddParams("@UserName", UserName, DbType.String);
            Request.AddParams("@Password", Password, DbType.String);

            Request.CommandText = BLL.TPV.SProc.Check_Login;
            Request.CommandType = CommandType.StoredProcedure;
            Drow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            if (Drow == null)
            {
                return -1;
            }
            else
            {
                GlobalDec.gEmployeeProperty.company_id = Val.ToInt32(Drow["company_id"]);
                GlobalDec.gEmployeeProperty.branch_id = Val.ToInt32(Drow["branch_id"]);
                GlobalDec.gEmployeeProperty.location_id = Val.ToInt32(Drow["location_id"]);
                GlobalDec.gEmployeeProperty.department_id = Val.ToInt32(Drow["department_id"]);
                GlobalDec.gEmployeeProperty.company_name = Val.ToString(Drow["company_name"]);
                GlobalDec.gEmployeeProperty.branch_name = Val.ToString(Drow["branch_name"]);
                GlobalDec.gEmployeeProperty.location_name = Val.ToString(Drow["location_name"]);
                GlobalDec.gEmployeeProperty.department_name = Val.ToString(Drow["department_name"]);
                GlobalDec.gEmployeeProperty.user_id = Val.ToInt32(Drow["user_id"]);
                GlobalDec.gEmployeeProperty.user_name = Val.ToString(Drow["user_name"]);
                GlobalDec.gEmployeeProperty.user_type = Val.ToString(Drow["user_type"]);
                GlobalDec.gEmployeeProperty.password = GlobalDec.Decrypt(Val.ToString(Drow["password"]), true);
                GlobalDec.gEmployeeProperty.employee_id = Val.ToInt32(Drow["employee_id"]);
                GlobalDec.gEmployeeProperty.party_id = Val.ToInt32(Drow["party_id"]);
                GlobalDec.gEmployeeProperty.theme = Val.ToString(Drow["Theme"]);
                GlobalDec.gEmployeeProperty.role_id = Val.ToInt32(Drow["role_id"]);
                GlobalDec.gEmployeeProperty.role_name = Val.ToString(Drow["role_name"]);
                GlobalDec.gEmployeeProperty.role_type = Val.ToString(Drow["role_type"]);
                GlobalDec.gEmployeeProperty.mobile_no = Val.ToString(Drow["mobile_no"]);
                GlobalDec.gEmployeeProperty.state_id = Val.ToInt(Drow["state_id"]);
                GlobalDec.gEmployeeProperty.cgst_per = Val.ToDecimal(Drow["cgst_per"]);
                GlobalDec.gEmployeeProperty.sgst_per = Val.ToDecimal(Drow["sgst_per"]);
                GlobalDec.gEmployeeProperty.igst_per = Val.ToDecimal(Drow["igst_per"]);

                //DataTable p_DtbUserPreference = new UserAuthentication().GetData_Single_User_General_Preferences_Settings(Val.ToInt(GlobalDec.gEmployeeProperty.user_id));

                int IntRes = new UserAuthentication().Save_Login_History();

                //if (p_DtbUserPreference.Rows.Count > 0)
                //{
                //    DataRow DRow = p_DtbUserPreference.Rows[0];
                //    GlobalDec.gEmployeeProperty.currency_id = Val.ToInt32(DRow["currency_id"]);
                //    GlobalDec.gEmployeeProperty.secondary_currency_id = Val.ToInt32(DRow["secondary_currency_id"]);
                //    GlobalDec.gEmployeeProperty.rate_type_id = Val.ToInt32(DRow["rate_type_id"]);
                //    GlobalDec.gEmployeeProperty.sale_rate_type_id = Val.ToInt32(DRow["sale_rate_type_id"]);
                //    GlobalDec.gEmployeeProperty.delivery_type_id = Val.ToInt32(DRow["delivery_type_id"]);
                //}
                //else
                //{
                //    GlobalDec.gEmployeeProperty.currency_id = 0;
                //    GlobalDec.gEmployeeProperty.secondary_currency_id = 0;
                //    GlobalDec.gEmployeeProperty.rate_type_id = 0;
                //    GlobalDec.gEmployeeProperty.sale_rate_type_id = 0;
                //}
                return 1;
            }
        }
    }
    #endregion
}


