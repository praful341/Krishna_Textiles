using System;

namespace BLL.PropertyClasses.Master
{
    public class User_MasterProperty
    {
        public int user_id { get; set; }
        public int company_id { get; set; }
        public int branch_id { get; set; }
        public int location_id { get; set; }
        public int department_id { get; set; }
        public int? state_id { get; set; }
        public string company_name { get; set; }
        public string branch_name { get; set; }
        public string location_name { get; set; }
        public string department_name { get; set; }
        public string user_name { get; set; }
        public string user_type { get; set; }
        public string password { get; set; }
        public int? employee_id { get; set; }
        public int? party_id { get; set; }
        public int? role_id { get; set; }
        public string role_name { get; set; }
        public string role_type { get; set; }
        public string theme { get; set; }
        public bool? active { get; set; }
        public int? sequence_no { get; set; }
        public string gFinancialYear { get; set; }
        public Int64 gFinancialYear_Code { get; set; }
        public int? currency_id { get; set; }
        public int? secondary_currency_id { get; set; }
        public int? rate_type_id { get; set; }
        public int? sale_rate_type_id { get; set; }
        public int delivery_type_id { get; set; }
        public string mobile_no { get; set; }
        public decimal cgst_per { get; set; }
        public decimal sgst_per { get; set; }
        public decimal igst_per { get; set; }
        public bool? is_deleted { get; set; }
    }
}
