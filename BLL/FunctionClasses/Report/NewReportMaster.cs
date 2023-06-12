using BLL.PropertyClasses.Report;
using DLL;
using System.Data;

namespace BLL.FunctionClasses.Report
{
    public class NewReportMaster
    {
        BLL.Validation Val = new Validation();

        #region Property Settings

        InterfaceLayer Ope = new InterfaceLayer();
        private DataSet _DS = new DataSet();

        public DataSet DS
        {
            get { return _DS; }
            set { _DS = value; }
        }
        public string TableNameDetail
        {
            get { return BLL.TPV.Table.New_Report_Detail; }
        }
        public string TableNameSettings
        {
            get { return BLL.TPV.Table.New_Report_Settings; }
        }
        #endregion
        public int FindNewID()
        {
            return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, BLL.TPV.Table.MST_Report, "MAX(report_code)", "");
        }
        public void GetReportDetail(int pIntReportCode)
        {
            Request Request = new Request();
            Request.AddParams("@report_code", pIntReportCode, DbType.Int32);
            Request.AddParams("@report_type", "", DbType.String);
            Request.CommandText = BLL.TPV.SProc.MST_Report_Detail_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableNameDetail, Request);
        }
        int i = 0;
        public void GetReportSettings(int pIntReportCode, string pStrReportType, int pStruserId)
        {
            if (i == 0)
            {
                Request Request = new Request();
                Request.AddParams("@report_code", pIntReportCode, DbType.Int32);
                Request.AddParams("@report_type", pStrReportType.ToUpper(), DbType.String);
                Request.AddParams("@user_id", pStruserId, DbType.Int32);
                Request.CommandText = BLL.TPV.SProc.MST_Report_Setting_GetData;
                Request.CommandType = CommandType.StoredProcedure;
                Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableNameSettings, Request);
                i = i + 1;
            }
            else
            {
                DS.Tables[1].Rows.Clear();
                Request Request = new Request();
                Request.AddParams("@report_code", pIntReportCode, DbType.Int32);
                Request.AddParams("@report_type", pStrReportType.ToUpper(), DbType.String);
                Request.AddParams("@user_id", pStruserId, DbType.Int32);
                Request.CommandText = BLL.TPV.SProc.MST_Report_Setting_GetData;
                Request.CommandType = CommandType.StoredProcedure;
                Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableNameSettings, Request);
            }
        }
        public DataTable GetDataForSearchMaster(int pIntReportCode = 0, string pStrReportGroup = null, int pIntEmployeeCode = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("@report_code", pIntReportCode, DbType.Int32);
            Request.AddParams("@role_id", GlobalDec.gEmployeeProperty.role_id, DbType.Int32);
            Request.AddParams("@report_group_name", pStrReportGroup, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Report_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public DataTable GetDataForSearchDetail(int pIntReportCode = 0)
        {
            GetReportDetail(pIntReportCode);
            DataTable Dtab = DS.Tables[3];
            return Dtab;
        }
        public DataTable GetDataForSearchDetailReport(int pIntReportCode = 0)
        {
            GetReportDetail(pIntReportCode);
            DataTable Dtab = DS.Tables[0];
            return Dtab;
        }
        public DataTable GetDataForSearchSettings(int pIntReportCode = 0, string pStrReportType = null, int pIntuser_id = 0)
        {
            DataTable DTab = new DataTable();
            GetReportSettings(pIntReportCode, pStrReportType, pIntuser_id);
            //DTab = DS.Tables[1];
            //DataTable Dtab_New = DTab.Select("report_type = '" + pStrReportType + "'").CopyToDataTable();
            if (DS.Tables[1].Select("report_type = '" + pStrReportType + "'").Length > 0)
            {
                DTab = DS.Tables[1].Select("report_type = '" + pStrReportType + "'").CopyToDataTable();
            }
            else
            {
                DTab = DS.Tables[1];
            }

            return DTab;
        }
        public New_Report_MasterProperty Save(New_Report_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@report_code", pClsProperty.Report_code, DbType.Int32);
            Request.AddParams("@report_name", pClsProperty.Report_Name, DbType.String);
            Request.AddParams("@report_group_name", pClsProperty.Report_Group_Name, DbType.String);
            Request.AddParams("@form_name", pClsProperty.Form_Name, DbType.String);
            Request.AddParams("@sequence_no", pClsProperty.Sequence_No, DbType.Int32);
            Request.AddParams("@active", pClsProperty.Active, DbType.Int32);
            Request.AddParams("@remark", pClsProperty.Remark, DbType.String);
            Request.AddParams("@disp_in", pClsProperty.Disp_In, DbType.String);
            Request.AddParams("@section", pClsProperty.Section_Name, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Report_Save;
            Request.CommandType = CommandType.StoredProcedure;
            //return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            DataTable p_dtbMasterId = new DataTable();

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, p_dtbMasterId, Request);

            if (p_dtbMasterId != null)
            {
                if (p_dtbMasterId.Rows.Count > 0)
                {
                    pClsProperty.Report_code = Val.ToInt32(p_dtbMasterId.Rows[0][0]);
                }
            }
            else
            {
                pClsProperty.Report_code = 0;
            }
            return pClsProperty;
        }
        public int SaveReportDetail(New_Report_DetailProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@report_code", pClsProperty.Report_code, DbType.Int32);
            Request.AddParams("@report_type", pClsProperty.Report_Type.ToUpper(), DbType.String);
            Request.AddParams("@procedure_name", pClsProperty.Procedure_Name, DbType.String);
            Request.AddParams("@report_header_name", pClsProperty.Report_Header_Name, DbType.String);
            Request.AddParams("@rpt_name", pClsProperty.Rpt_Name, DbType.String);
            Request.AddParams("@default_order_by", pClsProperty.Default_Order_By, DbType.String);
            Request.AddParams("@default_group_by", pClsProperty.Default_Group_By, DbType.String);
            Request.AddParams("@is_pivot", pClsProperty.Is_Pivot, DbType.Int32);
            Request.AddParams("@active", pClsProperty.Active, DbType.Int32);
            Request.AddParams("@remark", pClsProperty.Remark, DbType.String);
            Request.AddParams("@font_size", pClsProperty.Font_Size, DbType.Double);
            Request.AddParams("@font_name", pClsProperty.Font_Name, DbType.String);
            Request.AddParams("@page_orientation", pClsProperty.Page_Orientation, DbType.String);
            Request.AddParams("@page_kind", pClsProperty.Page_Kind, DbType.String);
            Request.AddParams("@autofit", pClsProperty.Autofit, DbType.Double);

            Request.CommandText = BLL.TPV.SProc.MST_Report_Detail_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public int SaveReportSettings(New_Report_SettingsProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@report_code", pClsProperty.Report_code, DbType.Int32);
            Request.AddParams("@report_type", pClsProperty.Report_Type.ToUpper(), DbType.String);
            Request.AddParams("@field_no", pClsProperty.Field_No, DbType.Int32);
            Request.AddParams("@field_name", pClsProperty.Field_Name, DbType.String);
            Request.AddParams("@column_name", pClsProperty.Column_Name, DbType.String);
            Request.AddParams("@sequence_no", pClsProperty.Sequence_No, DbType.Int32);
            Request.AddParams("@aggregate", pClsProperty.Aggregate, DbType.String);
            Request.AddParams("@width", pClsProperty.Width, DbType.Int32);
            Request.AddParams("@visible", pClsProperty.Visible, DbType.Int32);
            Request.AddParams("@ismerge", pClsProperty.IsMerge, DbType.Int32);
            Request.AddParams("@mergeon", pClsProperty.MergeOn, DbType.String);
            Request.AddParams("@active", pClsProperty.Active, DbType.Int32);
            Request.AddParams("@is_group", pClsProperty.Is_Group, DbType.Int32);
            Request.AddParams("@is_row_area", pClsProperty.Is_Row_Area, DbType.Int32);
            Request.AddParams("@is_column_area", pClsProperty.Is_Column_Area, DbType.Int32);
            Request.AddParams("@is_data_area", pClsProperty.Is_Data_Area, DbType.Int32);
            Request.AddParams("@order_by", pClsProperty.Order_By, DbType.String);
            Request.AddParams("@remark", pClsProperty.Remark, DbType.String);
            Request.AddParams("@type", pClsProperty.Type, DbType.String);
            Request.AddParams("@is_unbound", pClsProperty.Is_Unbound, DbType.Int32);
            Request.AddParams("@expression", pClsProperty.Expression, DbType.String);
            Request.AddParams("@bands", pClsProperty.Bands, DbType.String);

            Request.AddParams("@theme_name", pClsProperty.Themes_Name, DbType.Int32);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.String);
            Request.AddParams("@format", pClsProperty.Format, DbType.String);
            Request.AddParams("@alignment", pClsProperty.Alignment, DbType.String);
            Request.AddParams("@column_width", pClsProperty.Column_Width, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Report_Setting_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable GetReportSettings_For_Template(int pIntReportCode, string pStrReportType)
        {
            DataTable DtResult = new DataTable();
            Request Request = new Request();
            Request.AddParams("@report_code", pIntReportCode, DbType.Int32);
            Request.AddParams("@report_type", pStrReportType.ToUpper(), DbType.String);
            Request.CommandText = BLL.TPV.SProc.MST_Report_Setting_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DtResult, Request);

            return DtResult;
        }
        public int DeleteReportSettings_Template(New_Report_SettingsProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@report_code", pClsProperty.Report_code, DbType.Int32);
            Request.AddParams("@report_type", pClsProperty.Report_Type.ToUpper(), DbType.String);
            Request.AddParams("@field_no", pClsProperty.Field_No, DbType.Int32);
            Request.AddParams("@theme_name", pClsProperty.Themes_Name, DbType.String);
            Request.AddParams("@user_id", pClsProperty.user_id, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Report_Setting_Del_Template;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public New_Report_MasterProperty GetReportMasterProperty_ForTemplate(int pIntReportCode, string pStrReportGroup = null)
        {
            Request Request = new Request();
            Request.AddParams("@report_code", pIntReportCode, DbType.Int32);
            Request.AddParams("@report_group_name", pStrReportGroup, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Report_GetData;
            Request.CommandType = CommandType.StoredProcedure;

            DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            New_Report_MasterProperty New_Report_MasterProperty = new New_Report_MasterProperty();
            New_Report_MasterProperty.Report_code = Val.ToInt(DRow["report_code"]);
            New_Report_MasterProperty.Report_Name = Val.ToString(DRow["report_name"]);
            New_Report_MasterProperty.Report_Group_Name = Val.ToString(DRow["report_group_name"]);
            New_Report_MasterProperty.Form_Name = Val.ToString(DRow["form_name"]);
            New_Report_MasterProperty.Sequence_No = Val.ToInt(DRow["sequence_no"]);
            New_Report_MasterProperty.Active = Val.ToInt(DRow["active"]);
            New_Report_MasterProperty.Remark = Val.ToString(DRow["remark"]);

            DRow = null;
            return New_Report_MasterProperty;
        }
        public int Delete(int pIntReportCode)
        {
            Request Request = new Request();

            Request.AddParams("@report_code", pIntReportCode, DbType.Int32);
            Request.CommandText = BLL.TPV.SProc.MST_Report_Delete;

            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public int DeleteSettings(New_Report_SettingsProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@report_code", pClsProperty.Report_code, DbType.Int32);
            Request.AddParams("@report_type", pClsProperty.Report_Type.ToUpper(), DbType.String);
            Request.AddParams("@field_no", pClsProperty.Field_No, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Report_Setting_Delete;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public int DeleteDetail(New_Report_DetailProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@report_code", pClsProperty.Report_code, DbType.Int32);
            Request.AddParams("@report_type", pClsProperty.Report_Type.ToUpper(), DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Report_Detail_Delete;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public New_Report_MasterProperty GetReportMasterProperty(int pIntReportCode, string pStrReportGroup = null)
        {
            Request Request = new Request();
            Request.AddParams("@report_code", pIntReportCode, DbType.Int32);
            Request.AddParams("@report_group_name", pStrReportGroup, DbType.String);
            Request.AddParams("@role_id", GlobalDec.gEmployeeProperty.role_id, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Report_GetData;
            Request.CommandType = CommandType.StoredProcedure;

            DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            New_Report_MasterProperty New_Report_MasterProperty = new New_Report_MasterProperty();
            New_Report_MasterProperty.Report_code = Val.ToInt(DRow["report_code"]);
            New_Report_MasterProperty.Report_Name = Val.ToString(DRow["report_name"]);
            New_Report_MasterProperty.Report_Group_Name = Val.ToString(DRow["report_group_name"]);
            New_Report_MasterProperty.Form_Name = Val.ToString(DRow["form_name"]);
            New_Report_MasterProperty.Sequence_No = Val.ToInt(DRow["sequence_no"]);
            New_Report_MasterProperty.Active = Val.ToInt(DRow["active"]);
            New_Report_MasterProperty.Remark = Val.ToString(DRow["remark"]);
            New_Report_MasterProperty.Disp_In = Val.ToString(DRow["disp_in"]);
            New_Report_MasterProperty.Section_Name = Val.ToString(DRow["section"]);

            DRow = null;
            return New_Report_MasterProperty;
        }

        public New_Report_DetailProperty GetReportDetailProperty(int pIntReportCode, string pStrReportType)
        {
            Request Request = new Request();
            Request.AddParams("@report_code", pIntReportCode, DbType.Int32);
            Request.AddParams("@report_type", pStrReportType, DbType.Int32);
            Request.CommandText = BLL.TPV.SProc.MST_Report_Detail_GetData;
            Request.CommandType = CommandType.StoredProcedure;

            DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            New_Report_DetailProperty New_Report_DetailProperty = new New_Report_DetailProperty();
            New_Report_DetailProperty.Report_code = Val.ToInt(DRow["report_code"]);
            New_Report_DetailProperty.Report_Type = Val.ToString(DRow["report_type"]);
            New_Report_DetailProperty.Procedure_Name = Val.ToString(DRow["procedure_name"]);
            New_Report_DetailProperty.Report_Header_Name = Val.ToString(DRow["report_header_name"]);
            New_Report_DetailProperty.Rpt_Name = Val.ToString(DRow["rpt_name"]);
            New_Report_DetailProperty.Default_Order_By = Val.ToString(DRow["default_order_by"]);
            New_Report_DetailProperty.Default_Group_By = Val.ToString(DRow["default_group_by"]);
            New_Report_DetailProperty.Active = Val.ToInt(DRow["active"]);
            New_Report_DetailProperty.Remark = Val.ToString(DRow["remark"]);
            New_Report_DetailProperty.Is_Pivot = Val.ToInt(DRow["is_pivot"]);
            New_Report_DetailProperty.Font_Name = Val.ToString(DRow["font_name"]);
            New_Report_DetailProperty.Font_Size = Val.Val(DRow["font_size"]);
            New_Report_DetailProperty.Page_Orientation = Val.ToString(DRow["page_orientation"]);
            New_Report_DetailProperty.Autofit = Val.Val(DRow["autofit"]);
            New_Report_DetailProperty.Page_Kind = Val.ToString(DRow["page_kind"]);

            DRow = null;
            return New_Report_DetailProperty;
        }
    }
}
