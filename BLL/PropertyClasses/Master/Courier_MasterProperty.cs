using System;

namespace BLL.PropertyClasses.Master
{
    public class Courier_MasterProperty
    {
        public Int64 courier_id { get; set; }
        public string courier_name { get; set; }
        public Int64? mobile_no_1 { get; set; }
        public Int64? mobile_no_2 { get; set; }
        public string tracking_link { get; set; }
        public decimal? weight { get; set; }
        public decimal? rate { get; set; }
        public int active { get; set; }
        public Int64 courier_rate_id { get; set; }
        public int form_id { get; set; }
    }
}
