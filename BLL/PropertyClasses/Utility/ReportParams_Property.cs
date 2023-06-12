namespace BLL.PropertyClasses.Report
{
    public class ReportParams_Property
    {
        public string company_id { get; set; }
        public string branch_id { get; set; }
        public string location_id { get; set; }
        public string department_id { get; set; }
        public string cut_id { get; set; }
        public string kapan_id { get; set; }
        public bool IsCurrent { get; set; }
        public string From_Date { get; set; }
        public string To_Date { get; set; }
        public string Group_By_Tag { get; set; }
        public string rate_date { get; set; }
        public int rate_type_id { get; set; }
        public int currency_id { get; set; }
        public string ledger_id { get; set; }
        public string party_id { get; set; }
        public string Cash_Type { get; set; }
        public int fYear { get; set; }
        public int tYear { get; set; }
        public int fMonth { get; set; }
        public int tMonth { get; set; }
        public int punch_miss_flag { get; set; }

    }
}
