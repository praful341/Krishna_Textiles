namespace BLL.PropertyClasses.Master
{
    public class Preference_MasterProperty
    {
        public int user_preference_id { get; set; }
        public int default_rate_type_id { get; set; }
        public int default_currency_id { get; set; }
        public int secondary_currency_id { get; set; }
        public int user_id { get; set; }
        public string format_weight { get; set; }
        public string format_rate { get; set; }
        public string format_percent { get; set; }
        public string format_amount { get; set; }
        public int delivery_type_id { get; set; }
    }
}
