using DLL;
using System.Data;

namespace BLL
{
    public class FillCombo
    {
        InterfaceLayer Ope = new InterfaceLayer();
        public enum TABLE
        {
            Company_Master = 1,
            Branch_Master = 2,
            Location_Master = 3,
            Department_Master = 4,
            Form_Master = 5,
            Ledger_Master = 6,
            Menu_Master = 7,
            Kapan_Master = 8,
            Cut_Master = 9,
            Rough_Sieve_Master = 10,
            Purity_Master = 11,
            Employee_Master = 12
        }

        public int user_id;
        public int company_id;
        public int branch_id;
        public int location_id;
        public int department_id;
        public int kapan_id;
        public int cut_id;
        public int rough_sieve_id;
        public int purity_id;

        public DataTable FillCmb(TABLE tenum)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("@user_id", user_id, DbType.Int32);
            Request.AddParams("@company_id", company_id, DbType.Int32);
            Request.AddParams("@branch_id", branch_id, DbType.Int32);
            Request.AddParams("@location_id", location_id, DbType.Int32);
            Request.AddParams("@department_id", department_id, DbType.Int32);
            Request.AddParams("@Ope", tenum.ToString(), DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Get_All_Data;
            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public DataTable DTab_Transaction_Type()
        {
            DataTable DTab = new DataTable();
            DTab.Columns.Add("Transaction_Type", typeof(string));
            DataRow Dr = DTab.NewRow();
            Dr[0] = "Cash";
            DTab.Rows.Add(Dr);
            Dr = DTab.NewRow();
            Dr[0] = "Bank";
            DTab.Rows.Add(Dr);
            return DTab;
        }
    }
}
