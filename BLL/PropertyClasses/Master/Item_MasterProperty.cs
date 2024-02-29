using System;

namespace BLL.PropertyClasses.Master
{
    public class Item_MasterProperty
    {
        public Int64 item_detail_id { get; set; }
        public Int64 item_id { get; set; }
        public string item_name { get; set; }
        public string item_shortname { get; set; }
        public Int64 item_group_id { get; set; }
        public Int64 hsn_id { get; set; }
        public Int64 item_category_id { get; set; }
        public int active { get; set; }
        public string remark { get; set; }
        public Int64 unit_id { get; set; }
        public decimal last_purchase_rate { get; set; }
        public string item_codification { get; set; }
        public double disc_per { get; set; }
        public decimal sale_rate { get; set; }
        public int stock_limit { get; set; }
        public int pcs_in_box { get; set; }
        public Int64 company_id { get; set; }
        public Int64 branch_id { get; set; }
        public Int64 location_id { get; set; }
    }
}
