using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class ConfigFormMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        public int Save(ConfigForm_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@form_id", pClsProperty.form_id, DbType.Int32);
            Request.AddParams("@form_name", pClsProperty.form_name, DbType.String);
            Request.AddParams("@form_group_name", pClsProperty.form_group_name, DbType.String);
            Request.AddParams("@caption", pClsProperty.caption, DbType.String);
            Request.AddParams("@main_menu", pClsProperty.main_menu, DbType.Int64);
            Request.AddParams("@sub_menu", pClsProperty.sub_menu.Length == 0 ? (object)DBNull.Value : pClsProperty.sub_menu, DbType.String);
            Request.AddParams("@parent_btn_name", pClsProperty.menu.Length == 0 ? (object)DBNull.Value : pClsProperty.menu, DbType.String);
            Request.AddParams("@icon", pClsProperty.Icon.Length == 0 ? (object)DBNull.Value : pClsProperty.Icon, DbType.String);
            Request.AddParams("@param", pClsProperty.Param.Length == 0 ? (object)DBNull.Value : pClsProperty.Param, DbType.String);
            Request.AddParams("@level1", pClsProperty.Level1.Length == 0 ? (object)DBNull.Value : pClsProperty.Level1, DbType.String);
            Request.AddParams("@level2", pClsProperty.Level2.Length == 0 ? (object)DBNull.Value : pClsProperty.Level2, DbType.String);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);
            Request.AddParams("@remarks", pClsProperty.remarks, DbType.String);
            Request.AddParams("@sequence_no", pClsProperty.sequenceno, DbType.Int32);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(Val.DBDate(GlobalDec.gStr_SystemDate)), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Config_Form_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.MST_Config_Form_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@Active", active, DbType.Int32);
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public string ISExists(string ConfigFormName, Int64 FormId)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Config_Form", "form_name", "AND form_name = '" + ConfigFormName + "' AND NOT form_id =" + FormId));
        }
    }
}
