using System;

namespace BLL.PropertyClasses.Transaction
{
    public class PaymentGiven_Property
    {
        public Int64 payment_id { get; set; }
        public Int64 voucher_no { get; set; }
        public Int64 company_id { get; set; }
        public Int64 branch_id { get; set; }
        public Int64 location_id { get; set; }
        public Int64 department_id { get; set; }
        public Int64 union_id { get; set; }
        public string payment_date { get; set; }
        public string payment_type { get; set; }
        public Int64 sr_no { get; set; }
        public Int64 invoice_id { get; set; }
        public Int64 purchase_return_id { get; set; }
        public string method { get; set; }
        public string reference { get; set; }
        public Int64 ledger_id { get; set; }
        public Int64 bank_id { get; set; }
        public Int64 currency_id { get; set; }
        public decimal credit_amount { get; set; }
        public Int64 against_ledger_id { get; set; }
        public decimal debit_amount { get; set; }
        public string remarks { get; set; }
        public Int64 form_id { get; set; }
    }
}
