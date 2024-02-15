using System;

namespace BLL.PropertyClasses.Master
{
    public class GST_MasterProperty
    {
        public Int64 gst_id { get; set; }
        public string gst_name { get; set; }
        public decimal gst_rate { get; set; }
        public int active { get; set; }
    }
}
