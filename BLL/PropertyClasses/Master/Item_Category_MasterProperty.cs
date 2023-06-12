using System;

namespace BLL.PropertyClasses.Master
{
    public class Item_Category_MasterProperty
    {
        public Int64 item_category_id { get; set; }
        public string item_category_name { get; set; }
        public int active { get; set; }
        public string remark { get; set; }
        public int is_consumable { get; set; }
        public int is_repairable { get; set; }
    }
}
