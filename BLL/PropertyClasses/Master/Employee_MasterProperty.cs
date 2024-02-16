using System;

namespace BLL.PropertyClasses.Master
{
    public class Employee_MasterProperty
    {
        public int employee_id { get; set; }
        public string employee_code { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string short_name { get; set; }
        public int? company_id { get; set; }
        public int? branch_id { get; set; }
        public int? location_id { get; set; }
        public int? department_id { get; set; }
        public int? designation_id { get; set; }
        public int? sub_process_id { get; set; }
        public string email { get; set; }
        public string email_password { get; set; }
        public int? sale_premium { get; set; }
        public int? sale_discount { get; set; }
        public string aadhar_no { get; set; }
        public string emp_address { get; set; }
        public string joining_date { get; set; }
        public string leave_date { get; set; }
        public string reference_by { get; set; }
        public string reference_mobile { get; set; }
        public string employee_mobile { get; set; }
        public bool? active { get; set; }
        public string remarks { get; set; }
        public string Company_Multi { get; set; }
        public string Branch_Multi { get; set; }
        public string Location_Multi { get; set; }
        public string Department_Multi { get; set; }
        public string dob { get; set; }
        public int age { get; set; }
        public Int64 salary { get; set; }
        public string pancard_no { get; set; }
    }
}
