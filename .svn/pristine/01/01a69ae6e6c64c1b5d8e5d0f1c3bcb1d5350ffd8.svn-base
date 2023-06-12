using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class Single_Setting
    {
        Validation Val = new Validation();
        InterfaceLayer Ope = new InterfaceLayer();



        #region Other Function

        public int Save(Single_SettingProperty pClsProperty)
        {
            Request Request = new Request();

            //Request.AddParams("FORM_CODE_", pClsProperty.FORM_CODE, DbType.Int32);
            //Request.AddParams("LOCATION_CODE_", pClsProperty.LOCATION_CODE, DbType.Int32);
            //Request.AddParams("IS_SHAPE_", pClsProperty.IS_SHAPE, DbType.Int32);
            //Request.AddParams("IS_COLOR_", pClsProperty.IS_COLOR, DbType.Int32);
            //Request.AddParams("IS_CLARITY_", pClsProperty.IS_CLARITY, DbType.Int32);
            //Request.AddParams("IS_CUT_", pClsProperty.IS_CUT, DbType.Int32);
            //Request.AddParams("IS_POLISH_", pClsProperty.IS_POLISH, DbType.Int32);
            //Request.AddParams("IS_SYMMETRY_", pClsProperty.IS_SYMMETRY, DbType.Int32);
            //Request.AddParams("IS_FLUORESCENCE_", pClsProperty.IS_FLUORESCENCE, DbType.Int32);
            //Request.AddParams("IS_QUALITY_", pClsProperty.IS_QUALITY, DbType.Int32);
            //Request.AddParams("IS_RAP_RATE_", pClsProperty.IS_RAP_RATE, DbType.Int32);
            //Request.AddParams("IS_RAP_DISC_", pClsProperty.IS_RAP_DISC, DbType.Int32);
            //Request.AddParams("IS_PRICE_PER_CARAT_", pClsProperty.IS_PRICE_PER_CARAT, DbType.Int32);
            //Request.AddParams("IS_AMOUNT_", pClsProperty.IS_AMOUNT, DbType.Int32);

            Request.CommandText = "SL_SETTING_SINGLE_SAVE";
            Request.CommandType = CommandType.StoredProcedure;
            int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            return IntRes;
        }

        public DataTable Getdata(Int32 PFormCode)
        {
            DataTable DtPreView = new DataTable();
            Request Request = new Request();
            Request.CommandType = CommandType.StoredProcedure;
            Request.CommandText = "SL_SETTING_SINGLE_GETDATA";
            Request.AddParams("FORM_CODE_", PFormCode, DbType.Int64);

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DtPreView, Request);

            return DtPreView;
        }

        public int SaveSingleSettings(Single_SettingProperty pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            try
            {
                int IntRes = 0;
                Request Request = new Request();

                Request.AddParams("@form_id", pClsProperty.form_id, DbType.Int32);
                Request.AddParams("@role_id", pClsProperty.role_id, DbType.Int32);
                Request.AddParams("@column_name", pClsProperty.column_name, DbType.String);
                Request.AddParams("@caption", pClsProperty.caption, DbType.String);
                Request.AddParams("@field_no", pClsProperty.field_no, DbType.Int32);
                Request.AddParams("@is_visible", pClsProperty.is_visible, DbType.Int32);
                Request.AddParams("@is_compulsory", pClsProperty.is_compulsory, DbType.Int32);
                Request.AddParams("@tab_index", pClsProperty.tab_index, DbType.Int32);
                Request.AddParams("@is_editable", pClsProperty.is_editable, DbType.Int32);
                Request.AddParams("@is_newrow", pClsProperty.is_newrow, DbType.Int32);
                Request.AddParams("@is_control", pClsProperty.is_control, DbType.Int32);
                Request.AddParams("@column_type", pClsProperty.column_type, DbType.String);
                Request.AddParams("@gridname", pClsProperty.gridname, DbType.String);
                Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
                Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
                Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
                Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

                Request.CommandText = BLL.TPV.SProc.Config_Single_Setting_Save; // "SINGLE_SETTINGS_SAVE";
                Request.CommandType = CommandType.StoredProcedure;
                if (Conn != null)
                    IntRes = Conn.Inter1.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, Request, pEnum);
                else
                    IntRes = Ope.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, Request);
                return IntRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveCopyThemeName(Single_SettingProperty pClsProperty)
        {
            Request Request = new Request();

            //Request.AddParams("FROM_EMPLOYEE_CODE_", pClsProperty.EMPLOYEE_CODE, DbType.Int32);
            //Request.AddParams("TO_EMPLOYEE_CODE_", pClsProperty.TO_EMPLOYEE_CODE, DbType.Int32);
            //Request.AddParams("THEMES_NAME_", pClsProperty.Theme_Name, DbType.String);
            //Request.AddParams("OWN_THEMES_NAME_", pClsProperty.COLUMN_NAME, DbType.String);
            //Request.AddParams("REPORT_CODE_", pClsProperty.FORM_CODE, DbType.Int32);
            //Request.AddParams("REPORT_TYPE_", pClsProperty.Report_Type, DbType.String);

            Request.CommandText = "TRAD_COPY_REPORT_SETTINGS";
            Request.CommandType = CommandType.StoredProcedure;
            int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            return IntRes;
        }

        public int DeleteThemeName(Single_SettingProperty pClsProperty)
        {
            Request Request = new Request();

            //Request.AddParams("EMPLOYEE_CODE_", pClsProperty.EMPLOYEE_CODE, DbType.Int32);
            //Request.AddParams("THEMES_NAME_", pClsProperty.Theme_Name, DbType.String);
            //Request.AddParams("REPORT_CODE_", pClsProperty.FORM_CODE, DbType.Int32);
            //Request.AddParams("REPORT_TYPE_", pClsProperty.Report_Type, DbType.String);

            Request.CommandText = "TRAD_DELETE_REPORT_SETTINGS";
            Request.CommandType = CommandType.StoredProcedure;
            int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            return IntRes;
        }



        public DataTable GetData(Single_SettingProperty pClsProperty)
        {
            DataTable DtPreView = new DataTable();
            Request Request = new Request();
            Request.CommandType = CommandType.StoredProcedure;
            Request.CommandText = BLL.TPV.SProc.Config_Single_Setting_GetData;
            Request.AddParams("@role_id", pClsProperty.role_id, DbType.Int32);
            Request.AddParams("@form_id", pClsProperty.form_id, DbType.Int32);

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DtPreView, Request);
            return DtPreView;
        }

        public int DeleteSingleSettings(Single_SettingProperty pClsProperty)
        {
            DataTable DtPreView = new DataTable();
            Request Request = new Request();
            Request.CommandType = CommandType.StoredProcedure;
            Request.CommandText = BLL.TPV.SProc.Config_Single_Setting_Delete;
            Request.AddParams("@role_id", pClsProperty.role_id, DbType.Int32);
            Request.AddParams("@form_id", pClsProperty.form_id, DbType.Int32);
            Request.AddParams("@field_no", pClsProperty.field_no, DbType.Int32);

            int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            return IntRes;
        }

        public int CopySingleSettings(Int32 Role_Id, Int32 Copy_Role_Id, int FormId, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            try
            {
                int IntRes = 0;
                Request Request = new Request();

                Request.AddParams("@role_id", Role_Id, DbType.Int32);
                Request.AddParams("@copy_role_id", Copy_Role_Id, DbType.Int32);
                Request.AddParams("@form_id", FormId, DbType.Int32);

                Request.CommandText = BLL.TPV.SProc.Config_Single_Setting_CopySave;
                Request.CommandType = CommandType.StoredProcedure;
                if (Conn != null)
                    IntRes = Conn.Inter1.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, Request, pEnum);
                else
                    IntRes = Ope.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, Request);
                return IntRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

