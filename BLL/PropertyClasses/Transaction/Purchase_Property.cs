using System;

namespace BLL.PropertyClasses.Transaction
{
    public class Purchase_Property
    {
        #region "Master" 
        public int company_id { get; set; }
        public int branch_id { get; set; }
        public int location_id { get; set; }
        public int department_id { get; set; }
        public string purchase_date { get; set; }
        public Int64 gst_id { get; set; }
        public Int64 total_pcs { get; set; }
        public decimal gross_amount { get; set; }
        public string purchase_bill_no { get; set; }
        public decimal cgst_rate { get; set; }
        public decimal cgst_amount { get; set; }
        public decimal sgst_rate { get; set; }
        public decimal sgst_amount { get; set; }
        public decimal igst_rate { get; set; }
        public decimal igst_amount { get; set; }
        public decimal net_amount { get; set; }
        public decimal discount_per { get; set; }
        public decimal discount_amount { get; set; }
        public decimal round_of_amount { get; set; }
        public int form_id { get; set; }
        public int ledger_id { get; set; }
        public int term_days { get; set; }
        public string due_date { get; set; }

        #endregion

        #region "Details"
        public int sr_no { get; set; }
        public Int64 purchase_id { get; set; }
        public Int64 purchase_detail_id { get; set; }
        public Int64 janged_id { get; set; }
        public Int64 janged_detail_id { get; set; }
        public Int64 item_id { get; set; }
        public Int64 color_id { get; set; }
        public Int64 size_id { get; set; }
        public Int64 unit_id { get; set; }
        public int pcs { get; set; }
        public decimal rate { get; set; }
        public decimal amount { get; set; }
        public decimal discount { get; set; }
        public Int64 voucher_no { get; set; }
        public string remarks { get; set; }
        public int old_pcs { get; set; }
        public int flag { get; set; }
        public Int64 old_item_id { get; set; }
        public Int64 old_color_id { get; set; }
        public Int64 old_size_id { get; set; }
        public Int64 old_unit_id { get; set; }
        #endregion
    }
}
