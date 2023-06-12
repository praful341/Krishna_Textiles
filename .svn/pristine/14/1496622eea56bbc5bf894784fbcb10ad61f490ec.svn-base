using BLL.PropertyClasses.Utility;
using DLL;
using System.Data;
namespace BLL.FunctionClasses.Utility
{
    public class Settings
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Operation

        public Request AddSettingsParams(Settings_Property pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("VERSION_", pClsProperty.version, DbType.String);
            Request.AddParams("EXE_COPY_PATH_", pClsProperty.exe_copy_path, DbType.String);
            Request.AddParams("SENDER_EMAIL_", pClsProperty.sender_email, DbType.String);
            Request.AddParams("SENDER_PASSWORD_", pClsProperty.sender_password, DbType.String);
            Request.AddParams("SMTPSERVER_", pClsProperty.smtpserver, DbType.String);
            Request.AddParams("SMTPPORT_", pClsProperty.smtpport, DbType.Int32);
            //Request.AddParams("RAPNET_USERNAME_", pClsProperty.RapNet_UserName, DbType.String);
            //Request.AddParams("RAPNET_PASSWORD_", pClsProperty.RapNet_Password, DbType.String);
            //Request.AddParams("IS_GRACE_APPLICABLE_", pClsProperty.IS_Grace_Applicable, DbType.Int32);
            Request.AddParams("IS_ENABLE_SSL_", pClsProperty.is_enable_ssl, DbType.Int32);
            //Request.AddParams("ADVANCE_SALARY_LIMIT_PER_", pClsProperty.Advance_Salary_Limit_Per, DbType.Double);
            //Request.AddParams("ADVANCE_DEDUCTION_LIMIT_PER_", pClsProperty.Advance_Deduction_Limit_Per, DbType.Double);
            //Request.AddParams("ATTENDANCE_UPDATE_DUE_DAYS_", pClsProperty.Attendance_Update_Due_Days, DbType.Int32);
            //Request.AddParams("ATTENDANCE_ABSENT_LIMIT_", pClsProperty.Attendance_Absent_Limit, DbType.Int32);
            //Request.AddParams("MINOR_AGE_LIMIT_", pClsProperty.Minor_Age_Limit, DbType.Int32);
            //Request.AddParams("Allow_Developer_ENTRY_", pClsProperty.Allow_Developer_Entry, DbType.Int32);
            Request.AddParams("ALLOW_EMAIL_SEND_", pClsProperty.allow_email_send, DbType.Int32);
            //Request.AddParams("ALLOW_SIEVE_PCS_VALIDATION_", pClsProperty.ALLOW_SIEVE_PCS_VALIDATION, DbType.Int32);
            //Request.AddParams("MINIMUM_WORKING_HOURS_", pClsProperty.Minimum_Working_Hours, DbType.Double);
            //Request.AddParams("IS_PAYHEAD_DYNAMIC_", pClsProperty.IS_PAYHEAD_DYNAMIC, DbType.Int32);
            //Request.AddParams("IDLE_MODE_EXE_CLOSE_", pClsProperty.IDLE_MODE_EXE_CLOSE, DbType.Int32);
            //Request.AddParams("IS_BARCODE_PRINT_", pClsProperty.Is_Barcode_Print, DbType.Int32);
            //Request.AddParams("DOLLAR_RATE_", pClsProperty.DOLLAR_RATE, DbType.Double);
            //Request.AddParams("PROCESS_COST_", pClsProperty.PROCESS_COST, DbType.Double);
            //Request.AddParams("OVER_HEAD_", pClsProperty.OVER_HEAD, DbType.Double);
            //Request.AddParams("PREVIOUS_YEAR_PRESENT_LIMIT_", pClsProperty.PREVIOUS_YEAR_PRESENT_LIMIT, DbType.Int32);
            //Request.AddParams("CURRENT_MONTH_PRESENT_LIMIT_", pClsProperty.CURRENT_MONTH_PRESENT_LIMIT, DbType.Int32);

            //Request.AddParams("MAX_PRED_PLAN_", pClsProperty.MAX_PRED_PLAN, DbType.Int32);
            //Request.AddParams("MAX_RECORD_LIVESTOCK_", pClsProperty.MAX_RECORD_LIVESTOCK, DbType.Int32);

            Request.AddParams("GUEST_HOSTNAME_", pClsProperty.guest_hostname, DbType.String);
            Request.AddParams("GUEST_PORT_", pClsProperty.guest_port, DbType.String);
            Request.AddParams("GUEST_SERVICENAME_", pClsProperty.guest_servicename, DbType.String);
            Request.AddParams("GUEST_USERNAME_", pClsProperty.guest_username, DbType.String);
            Request.AddParams("GUEST_PASSWORD_", pClsProperty.guest_password, DbType.String);



            Request.AddParams("WEB_HOSTNAME_", pClsProperty.WEB_HOSTNAME, DbType.Int32);
            Request.AddParams("WEB_DATABASE_", pClsProperty.WEB_DATABASE, DbType.Int32);
            Request.AddParams("WEB_USERNAME_", pClsProperty.WEB_USERNAME, DbType.Int32);
            Request.AddParams("WEB_PASSWORD_", pClsProperty.WEB_PASSWORD, DbType.Int32);


            Request.AddParams("ALLOW_TIME_DIFF_", pClsProperty.ALLOW_TIME_DIFF, DbType.Int32);

            Request.CommandText = "";// BLL.TPV.SProc.Settings_Save;
            Request.CommandType = CommandType.StoredProcedure;

            return Request;
        }

        public int Save(Settings_Property pClsProperty)
        {
            Request Request = AddSettingsParams(pClsProperty);
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public Settings_Property GetDataByPK()
        {
            Request Request = new Request();

            Request.CommandText = BLL.TPV.SProc.MST_Settings_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            if (DRow == null)
            {
                return null;
            }
            Settings_Property Property = new Settings_Property();
            Property.version = Val.ToString(DRow["version"]);
            Property.exe_copy_path = Val.ToString(DRow["exe_copy_path"]);

            Property.smtpserver = Val.ToString(DRow["smtpserver"]);
            Property.smtpport = Val.ToInt(DRow["smtpport"]);
            Property.sender_email = Val.ToString(DRow["sender_email"]);
            Property.email_from_for_user = Val.ToString(DRow["email_from_for_user"]);
            if (Val.ToString(DRow["sender_password"]) != "")
            {
                Property.sender_password = BLL.GlobalDec.Decrypt(Val.ToString(DRow["sender_password"]), true);
            }
            else
            {
                Property.sender_password = "";
            }
            //Property.RapNet_UserName = Val.ToString(DRow["RAPNET_USERNAME"]);
            //if (Val.ToString(DRow["RAPNET_PASSWORD"]) != "")
            //{
            //    Property.RapNet_Password = BLL.GlobalDec.Decrypt(Val.ToString(DRow["RAPNET_PASSWORD"]), true);
            //}
            //else
            //{
            //    Property.RapNet_Password = "";
            //}
            //Property.IS_Grace_Applicable = Val.ToInt(DRow["IS_GRACE_APPLICABLE"]);

            Property.is_enable_ssl = Val.ToBooleanToInt(DRow["is_enable_ssl"]);

            //Property.Advance_Salary_Limit_Per = Val.ToInt(DRow["ADVANCE_SALARY_LIMIT_PER"]);
            //Property.Advance_Deduction_Limit_Per = Val.ToInt(DRow["ADVANCE_DEDUCTION_LIMIT_PER"]);

            //Property.Attendance_Update_Due_Days = Val.ToInt(DRow["ATTENDANCE_UPDATE_DUE_DAYS"]);
            //Property.Attendance_Absent_Limit = Val.ToInt(DRow["ATTENDANCE_ABSENT_LIMIT"]);
            //Property.Minor_Age_Limit = Val.ToInt(DRow["MINOR_AGE_LIMIT"]);
            //Property.Allow_Developer_Entry = Val.ToInt(DRow["Allow_Developer_ENTRY"]);
            Property.allow_email_send = Val.ToInt(DRow["allow_email_send"]);
            //Property.EXE_UPDATE_MESSAGE_PATH = Val.ToString(DRow["EXE_UPDATE_MESSAGE_PATH"]);
            //Property.Minimum_Working_Hours = Val.Val(DRow["MINIMUM_WORKING_HOURS"]);
            //Property.ALLOW_SIEVE_PCS_VALIDATION = Val.ToInt(DRow["ALLOW_SIEVE_PCS_VALIDATION"]);
            //Property.IS_PAYHEAD_DYNAMIC = Val.ToInt(DRow["IS_PAYHEAD_DYNAMIC"]);
            //Property.IDLE_MODE_EXE_CLOSE = Val.ToInt(DRow["IDLE_MODE_EXE_CLOSE"]);
            //Property.Is_Barcode_Print = Val.ToInt(DRow["IS_BARCODE_PRINT"]);

            //Property.DOLLAR_RATE = Val.Val(DRow["DOLLAR_RATE"]);
            //Property.PROCESS_COST = Val.Val(DRow["PROCESS_COST"]);
            //Property.OVER_HEAD = Val.Val(DRow["OVER_HEAD"]);

            //Property.PREVIOUS_YEAR_PRESENT_LIMIT = Val.ToInt(DRow["PREVIOUS_YEAR_PRESENT_LIMIT"]);
            //Property.CURRENT_MONTH_PRESENT_LIMIT = Val.ToInt(DRow["CURRENT_MONTH_PRESENT_LIMIT"]);

            //Property.MAX_PRED_PLAN = Val.ToInt(DRow["MAX_PRED_PLAN"]);

            //Property.MAX_RECORD_LIVESTOCK = Val.ToInt(DRow["MAX_RECORD_LIVESTOCK"]);

            //Property.ALLOW_TIME_DIFF = Val.ToInt(DRow["ALLOW_TIME_DIFF"]);

            //Property.guest_hostname = BLL.GlobalDec.Decrypt(Val.ToString(DRow["guest_hostname"]), true);
            //Property.guest_port = BLL.GlobalDec.Decrypt(Val.ToString(DRow["guest_port"]), true);
            //Property.guest_servicename = BLL.GlobalDec.Decrypt(Val.ToString(DRow["guest_servicename"]), true);
            //Property.guest_username = BLL.GlobalDec.Decrypt(Val.ToString(DRow["guest_username"]), true);
            // Property.guest_password = BLL.GlobalDec.Decrypt(Val.ToString(DRow["guest_password"]), true);
            //Property.PROD_SUMMARY_SETTING = BLL.GlobalDec.Decrypt(Val.ToString(DRow["PRODSUMMAYCONG"]), true);
            //Property.ADDTIONAL_GST_RATE_PER = Val.Val(DRow["ADDTIONAL_GST_RATE_PER"]);

            /*Property.WEB_HOSTNAME = BLL.GlobalDec.Decrypt(Val.ToString(DRow["WEB_HOSTNAME"]), true);
            Property.WEB_DATABASE = BLL.GlobalDec.Decrypt(Val.ToString(DRow["WEB_DATABASE"]), true);
            Property.WEB_USERNAME = BLL.GlobalDec.Decrypt(Val.ToString(DRow["WEB_USERNAME"]), true);
            Property.WEB_PASSWORD = BLL.GlobalDec.Decrypt(Val.ToString(DRow["WEB_PASSWORD"]), true);*/

            return Property;
        }

        #endregion
    }
}
