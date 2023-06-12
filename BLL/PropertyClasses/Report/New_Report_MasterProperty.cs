namespace BLL.PropertyClasses.Report
{//asds


    public class New_Report_MasterProperty
    {
        public int Report_code { get; set; }
        public string Report_Name { get; set; }
        public string Report_Group_Name { get; set; }
        public string Form_Name { get; set; }
        public int Sequence_No { get; set; }
        public int Active { get; set; }
        public string Remark { get; set; }
        public string Disp_In { get; set; }
        public string Section_Name { get; set; }
    }

    public class New_Report_DetailProperty
    {
        public int Report_code { get; set; }
        public string Report_Type { get; set; }
        public string Procedure_Name { get; set; }
        public string Report_Header_Name { get; set; }
        public string Rpt_Name { get; set; }
        public string Default_Order_By { get; set; }
        public string Default_Group_By { get; set; }
        public int Active { get; set; }
        public string Remark { get; set; }
        public int Is_Pivot { get; set; }
        public string Font_Name { get; set; }
        public double Font_Size { get; set; }
        public string Page_Orientation { get; set; }
        public string Page_Kind { get; set; }
        public double Autofit { get; set; }
    }

    public class New_Report_SettingsProperty
    {
        public int Report_code { get; set; }
        public string Report_Type { get; set; }
        public int Field_No { get; set; }
        public string Field_Name { get; set; }
        public string Column_Name { get; set; }
        public string Aggregate { get; set; }
        public string Alignment { get; set; }
        public string Format { get; set; }
        public int Width { get; set; }
        public int Column_Width { get; set; }
        public int Visible { get; set; }
        public int IsMerge { get; set; }
        public string MergeOn { get; set; }
        public string Type { get; set; }
        public int Sequence_No { get; set; }
        public int Active { get; set; }
        public string Remark { get; set; }
        public int Is_Group { get; set; }
        public int Is_Row_Area { get; set; }
        public int Is_Column_Area { get; set; }
        public int Is_Data_Area { get; set; }
        public string Order_By { get; set; }
        public int Is_Unbound { get; set; }
        public string Expression { get; set; }
        public string Bands { get; set; }
        public string Themes_Name { get; set; }
        public int user_id { get; set; }
    }
}
