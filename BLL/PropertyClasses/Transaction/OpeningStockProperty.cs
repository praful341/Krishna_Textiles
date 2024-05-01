using System;

namespace BLL.PropertyClasses.Transaction
{
    public class OpeningStockProperty
    {
        #region "Master"
        public Int64 opening_id { get; set; }
        public string opening_date { get; set; }
        public Int64 item_id { get; set; }
        public Int64 color_id { get; set; }
        public Int64 size_id { get; set; }
        public decimal opening_pcs { get; set; }
        public decimal opening_rate { get; set; }
        #endregion
    }
}
