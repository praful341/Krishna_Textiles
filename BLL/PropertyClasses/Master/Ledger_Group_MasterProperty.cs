using System;

namespace BLL.PropertyClasses.Master
{
    public class Ledger_Group_MasterProperty
    {
        public Int64 ledger_group_id { get; set; }
        public string ledger_group_name { get; set; }
        public int active { get; set; }
        public string remark { get; set; }
    }
}
