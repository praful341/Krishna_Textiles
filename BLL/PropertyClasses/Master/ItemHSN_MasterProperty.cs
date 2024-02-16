using System;

namespace BLL.PropertyClasses.Master
{
    public class ItemHSN_MasterProperty
    {
        public Int64 hsn_id { get; set; }
        public string hsn_name { get; set; }
        public string hsn_code { get; set; }
        public string igst_date { get; set; }
        public double igst_rate { get; set; }
        public string sgst_date { get; set; }
        public double sgst_rate { get; set; }
        public string cgst_date { get; set; }
        public double cgst_rate { get; set; }
        public int active { get; set; }
        public string remark { get; set; }
        public decimal gst_rate { get; set; }
    }
}
