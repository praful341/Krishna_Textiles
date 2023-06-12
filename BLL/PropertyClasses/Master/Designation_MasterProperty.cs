namespace BLL.PropertyClasses.Master
{
    public class Designation_MasterProperty
    {
        public int designation_id { get; set; }
        public string designation_shortname { get; set; }
        public string designation { get; set; }
        public bool? active { get; set; }
        public int? sequence_no { get; set; }
        public string remarks { get; set; }
    }
}
