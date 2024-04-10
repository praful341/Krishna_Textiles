﻿using System;

namespace BLL.PropertyClasses.Transaction
{
    public class Journal_EntryProperty
    {
        public int company_id { get; set; }
        public int branch_id { get; set; }
        public int location_id { get; set; }
        public int department_id { get; set; }
        public string Journal_date { get; set; }
        public int form_id { get; set; }
        public int sr_no { get; set; }
        public Int64 ledger_id { get; set; }
        public Int64 voucher_no { get; set; }
        public decimal credit_amount { get; set; }
        public decimal debit_amount { get; set; }
        public Int64 union_id { get; set; }
        public string remarks { get; set; }
        public int flag { get; set; }
    }
}
