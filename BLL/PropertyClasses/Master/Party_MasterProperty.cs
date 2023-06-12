namespace BLL.PropertyClasses.Master
{
    public class Party_MasterProperty
    {
        public int party_id { get; set; }
        public string party_shortname { get; set; }
        public string party_name { get; set; }
        public string init_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string party_type { get; set; }
        public string business_type { get; set; }
        public string address { get; set; }
        public string pincode { get; set; }
        public int? city_id { get; set; }
        public int? state_id { get; set; }
        public int? country_id { get; set; }
        public int? manager_id { get; set; }
        public string phone1country { get; set; }
        public string phone1city { get; set; }
        public string phone1 { get; set; }
        public string mobile1country { get; set; }
        public string mobile1 { get; set; }
        public string fax { get; set; }
        public string website { get; set; }
        public string primary_email { get; set; }
        public string secondary_email { get; set; }
        public double? discount { get; set; }
        public int? category_id { get; set; }
        public string aadhar_no { get; set; }
        public string pancard_no { get; set; }
        public string aadhar_path { get; set; }
        public string pan_path { get; set; }
        public string tds_circle { get; set; }
        public string vat_no { get; set; }
        public string vat_date { get; set; }
        public string gst_no { get; set; }
        public string gst_date { get; set; }
        public string cst_no { get; set; }
        public string cst_date { get; set; }
        public string tan_no { get; set; }
        public string tan_date { get; set; }
        public string service_tax_no { get; set; }
        public string service_tax_date { get; set; }
        public string registration_source { get; set; }
        public bool? active { get; set; }
        public string remarks { get; set; }
        public int? sequence_no { get; set; }
        public string qbc { get; set; }
        public bool? factory { get; set; }
        public bool? is_outside { get; set; }
        public bool? is_autoconfirm { get; set; }
        public bool? is_rejection { get; set; }
        public bool? is_imp_exp_party { get; set; }
        public int? broker_id { get; set; }
        public int IDProof_ID { get; set; }
        public string IDProof_No { get; set; }
        public string party_bussiness_type { get; set; }
        public string broker_category { get; set; }
        public string behavior { get; set; }
    }
}
