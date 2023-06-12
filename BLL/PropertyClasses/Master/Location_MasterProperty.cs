namespace BLL.PropertyClasses.Master
{
    public class Location_MasterProperty
    {
        public int location_id { get; set; }
        public string location_shortname { get; set; }
        public string location_name { get; set; }
        public string address { get; set; }
        public int? city_id { get; set; }
        public int? state_id { get; set; }
        public int? country_id { get; set; }
        public bool? active { get; set; }
        public string remarks { get; set; }
    }
}
