using System;

namespace BLL.PropertyClasses.Transaction
{
    public class SaleReturn_Property
    {
        #region "Master" 
        public int invoice_id { get; set; }
        public int company_id { get; set; }
        public int branch_id { get; set; }
        public int location_id { get; set; }
        public int department_id { get; set; }
        public string return_date { get; set; }
        public string sale_type { get; set; }
        public string order_no { get; set; }
        public Int64 gst_id { get; set; }
        public Int64 total_pcs { get; set; }
        public decimal gross_amount { get; set; }
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
        public Int64 ledger_id { get; set; }
        public Int64 employee_id { get; set; }
        public decimal weight { get; set; }
        public Int64 pin_code { get; set; }
        public int term_days { get; set; }
        public string due_date { get; set; }
        public string shipping_address { get; set; }
        public decimal shipping_amount { get; set; }
        public string remarks { get; set; }

        #endregion

        #region "Details"
        public int sr_no { get; set; }
        public Int64 sale_return_id { get; set; }
        public Int64 return_detail_id { get; set; }
        public Int64 item_id { get; set; }
        public Int64 color_id { get; set; }
        public Int64 size_id { get; set; }
        public Int64 unit_id { get; set; }
        public int pcs { get; set; }
        public decimal purchase_rate { get; set; }
        public decimal purchase_amount { get; set; }
        public decimal sale_rate { get; set; }
        public decimal sale_amount { get; set; }
        public int old_pcs { get; set; }
        public int flag { get; set; }
        public Int64 old_item_id { get; set; }
        public Int64 old_color_id { get; set; }
        public Int64 old_size_id { get; set; }
        public Int64 old_unit_id { get; set; }

        #endregion
    }
}
