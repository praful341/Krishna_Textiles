using System;

namespace BLL.PropertyClasses.Master
{
    public class Bank_MasterProperty
    {
        public string bank_name { get; set; }
        public Int64 bank_id { get; set; }
        public string bank_account_name { get; set; }
        public string bank_account_no { get; set; }
        public string bank_ifsc { get; set; }
        public string bank_cheque { get; set; }
        public string bank_atm { get; set; }
        public Int64 branch_id { get; set; }
    }
}
