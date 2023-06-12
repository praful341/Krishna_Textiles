namespace BLL.PropertyClasses.Master
{
    public class ConfigProcess_MasterProperty
    {
        public string type { get; set; }
        public int process_id { get; set; }
        public int company_id { get; set; }
        public int location_id { get; set; }
        public int branch_id { get; set; }
        public int employee_id { get; set; }
        public bool? active { get; set; }
    }
}
