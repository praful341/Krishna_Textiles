namespace BLL.PropertyClasses.Master
{
    public class State_MasterProperty
    {
        public int state_id { get; set; }
        public int? country_id { get; set; }
        public string state_name { get; set; }
        public bool? active { get; set; }
        public int? sequence_no { get; set; }
        public string remarks { get; set; }
    }
}
