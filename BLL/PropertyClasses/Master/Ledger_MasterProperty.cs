using System;

namespace BLL.PropertyClasses.Master
{
    public class Ledger_MasterProperty
    {
        public Int64 ledger_id { get; set; }
        public string ledger_name { get; set; }
        public decimal opening_balance { get; set; }
        public Int64 ledger_group_id { get; set; }
        public string ledger_type { get; set; }
        public string ledger_print_name { get; set; }
        public string party_address1 { get; set; }
        public string party_address2 { get; set; }
        public string party_address3 { get; set; }
        public string party_address4 { get; set; }
        public string party_pincode { get; set; }
        public Int64? party_county_id { get; set; }
        public Int64? party_city_id { get; set; }
        public Int64? party_state_id { get; set; }
        public string party_mobile1 { get; set; }
        public string party_mobile2 { get; set; }
        public string party_email { get; set; }
        public string bank_name { get; set; }
        public string bank_branch { get; set; }
        public string bank_ifsc { get; set; }
        public string bank_account_no { get; set; }
        public string bank_account_type { get; set; }
        public string party_pan_no { get; set; }
        public string gst_no { get; set; }
        public bool? active { get; set; }
        public string remark { get; set; }
        public string bank_acc_name { get; set; }
    }
}
