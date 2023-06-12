using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class BranchMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public int Save(Branch_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@branch_id", pClsProperty.branch_id, DbType.Int64);
            Request.AddParams("@branch_shortname", pClsProperty.branch_shortname, DbType.String);
            Request.AddParams("@branch_name", pClsProperty.branch_name, DbType.String);
            Request.AddParams("@location_id", pClsProperty.location_id, DbType.Int64);
            Request.AddParams("@company_id", pClsProperty.company_id, DbType.Int64);
            Request.AddParams("@city_id", pClsProperty.city_id, DbType.Int64);
            Request.AddParams("@state_id", pClsProperty.state_id, DbType.Int32);
            Request.AddParams("@country_id", pClsProperty.country_id, DbType.Int32);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);
            Request.AddParams("@remarks", pClsProperty.remarks, DbType.String);
            Request.AddParams("@st_no", pClsProperty.st_no, DbType.String);
            Request.AddParams("@pan_no", pClsProperty.pan_no, DbType.String);
            Request.AddParams("@cst_no", pClsProperty.cst_no, DbType.String);
            Request.AddParams("@pincode", pClsProperty.pincode, DbType.String);
            Request.AddParams("@address", pClsProperty.address, DbType.String);
            Request.AddParams("@phone_no", pClsProperty.phone_no, DbType.String);
            Request.AddParams("@vat_no", pClsProperty.vat_no, DbType.String);
            Request.AddParams("@epcg_no", pClsProperty.epcg_no, DbType.String);
            Request.AddParams("@pf_no", pClsProperty.pf_no, DbType.String);
            Request.AddParams("@ward_no", pClsProperty.ward_no, DbType.String);
            Request.AddParams("@excise_no", pClsProperty.excise_no, DbType.String);
            Request.AddParams("@tin_no", pClsProperty.tin_no, DbType.String);
            Request.AddParams("@tan_no", pClsProperty.tan_no, DbType.String);
            Request.AddParams("@esic_no", pClsProperty.esic_no, DbType.String);
            Request.AddParams("@licence_no", pClsProperty.licence_no, DbType.String);
            Request.AddParams("@pt_no", pClsProperty.pt_no, DbType.String);
            Request.AddParams("@cpt_no", pClsProperty.cpt_no, DbType.String);
            Request.AddParams("@reg_no", pClsProperty.reg_no, DbType.String);
            Request.AddParams("@it_pa_no", pClsProperty.it_pa_no, DbType.String);
            Request.AddParams("@esic_local_office", pClsProperty.esic_local_office, DbType.String);
            Request.AddParams("@pf_group_code", pClsProperty.pf_group_code, DbType.String);
            Request.AddParams("@cin_no", pClsProperty.cin_no, DbType.String);
            Request.AddParams("@esic_coverage_date", pClsProperty.esic_coverage_date, DbType.String);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.AddParams("@cgst_per", pClsProperty.cgst_per, DbType.Decimal);
            Request.AddParams("@sgst_per", pClsProperty.sgst_per, DbType.Decimal);
            Request.AddParams("@igst_per", pClsProperty.igst_per, DbType.Decimal);
            Request.AddParams("@ledger_id", pClsProperty.ledger_id, DbType.Int32);
            Request.AddParams("@gst_no", pClsProperty.gst_no, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Branch_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        public DataTable GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", active, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Branch_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }
        public string ISExists(string BranchName, Int64 BranchId)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Branch", "branch_name", "AND branch_name = '" + BranchName + "' AND NOT branch_id =" + BranchId));
        }
    }
}
