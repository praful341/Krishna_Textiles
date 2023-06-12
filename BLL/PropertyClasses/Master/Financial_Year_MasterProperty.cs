using System;
namespace BLL.PropertyClasses.Master
{
    public class Financial_Year_MasterProperty
    {
        public Int64 Fin_Year_ID { get; set; }
        public string Financial_year { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public string Short_Name { get; set; }
        public Int64 Active { get; set; }
        public Int64 Start_YearMonth { get; set; }
        public Int64 End_YearMonth { get; set; }
    }
}
