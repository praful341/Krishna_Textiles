using System;

namespace BLL.PropertyClasses.Transaction
{
    public class DispatchEntry_Property
    {
        public string from_date { get; set; }
        public string to_date { get; set; }
        public string status { get; set; }

        public Int64 dispatch_id { get; set; }
        public Int64 fin_year_id { get; set; }
        public int company_id { get; set; }
        public int branch_id { get; set; }
        public int location_id { get; set; }
        public int department_id { get; set; }
        public Int64 invoice_id { get; set; }
        public string order_date { get; set; }
        public string order_no { get; set; }
        public Int64 employee_id { get; set; }
        public string dispatch_date { get; set; }
        public string dispatch_time { get; set; }
        public Int64 from_courier_id { get; set; }
        public Int64 to_courier_id { get; set; }
        public string awb_no { get; set; }
        public decimal paid_amount { get; set; }
        public decimal shipping_amount { get; set; }
        public string remarks { get; set; }
        public int form_id { get; set; }
    }
}
