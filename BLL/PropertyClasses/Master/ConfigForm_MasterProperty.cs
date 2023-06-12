namespace BLL.PropertyClasses.Master
{
    public class ConfigForm_MasterProperty
    {
        public int form_id { get; set; }
        public string form_name { get; set; }
        public string form_group_name { get; set; }
        public string caption { get; set; }
        public int main_menu { get; set; }
        public string sub_menu { get; set; }
        public string menu { get; set; }
        public int? sequenceno { get; set; }
        public bool? active { get; set; }
        public string Icon { get; set; }
        public string Level1 { get; set; }
        public string Level2 { get; set; }
        public string Param { get; set; }
        public string remarks { get; set; }
    }
}
