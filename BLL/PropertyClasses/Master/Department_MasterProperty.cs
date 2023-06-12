using System;

namespace BLL.PropertyClasses.Master
{
    public class Department_MasterProperty
    {
        public int Department_Id { get; set; }
        public string Department_Name { get; set; }
        public string Department_ShortName { get; set; }
        public Int64 Company_Id { get; set; }
        public Int64 Branch_Id { get; set; }
        public Int64 Location_Id { get; set; }
        public Int64 Employee_Id { get; set; }
        public int department_type_id { get; set; }
        public int Sequence_No { get; set; }
        public int Active { get; set; }
        public string Remark { get; set; }
    }
}
