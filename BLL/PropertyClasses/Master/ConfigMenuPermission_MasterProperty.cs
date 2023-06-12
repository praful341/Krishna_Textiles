using System;

namespace BLL.PropertyClasses.Master
{
    public class ConfigMenuPermission_MasterProperty
    {
        public Int64 menu_detail_id { get; set; }
        public int menu_id { get; set; }
        public int role_id { get; set; }
        public bool is_permisson { get; set; }
    }
}
