using System;

namespace BLL.PropertyClasses.Transaction
{
    public class StockJournalProperty
    {
        public int company_id { get; set; }
        public int branch_id { get; set; }
        public int location_id { get; set; }
        public int department_id { get; set; }
        public string journal_date { get; set; }
        public int form_id { get; set; }

        public int from_srno { get; set; }
        public int stock_journal_id { get; set; }
        public int from_item_id { get; set; }
        public int from_color_id { get; set; }
        public int from_size_id { get; set; }
        public decimal from_pcs { get; set; }
        public decimal from_rate { get; set; }
        public decimal from_amount { get; set; }

        public int to_srno { get; set; }
        public int to_item_id { get; set; }
        public int to_color_id { get; set; }
        public int to_size_id { get; set; }
        public decimal to_pcs { get; set; }
        public decimal to_rate { get; set; }
        public decimal to_amount { get; set; }

        public string remarks { get; set; }
        public int flag { get; set; }
        public Int64 union_id { get; set; }
    }
}
