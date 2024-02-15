namespace BLL.PropertyClasses.Transaction
{
    public class Janged_EntryProperty
    {
        #region "Master"
        public int company_id { get; set; }
        public int branch_id { get; set; }
        public int location_id { get; set; }
        public int department_id { get; set; }
        public string invoice_date { get; set; }
        public int delivery_type_id { get; set; }
        public decimal cgst_rate { get; set; }
        public decimal cgst_amount { get; set; }
        public decimal sgst_rate { get; set; }
        public decimal sgst_amount { get; set; }
        public decimal igst_rate { get; set; }
        public decimal igst_amount { get; set; }
        public decimal net_amount { get; set; }
        public decimal exchange_rate { get; set; }
        public int form_id { get; set; }
        public int Bill_To_Party_Id { get; set; }
        public int Shipped_To_Party_Id { get; set; }
        public int Refrenace_Id { get; set; }
        public int Broker_Id { get; set; }
        public int Term_Days { get; set; }
        public int memo_master_id { get; set; }
        public int memo_id { get; set; }
        public int demand_master_id { get; set; }
        public int Add_On_Days { get; set; }
        public string due_date { get; set; }
        public int final_Term_Days { get; set; }
        public string final_due_date { get; set; }
        public string Special_Remark { get; set; }
        public string Client_Remark { get; set; }
        public string Payment_Remark { get; set; }
        public string cod { get; set; }
        public decimal Gross_Amount { get; set; }
        public decimal Brokerage_Per { get; set; }
        public decimal Brokerage_Amt { get; set; }
        public decimal Discount_Per { get; set; }
        public decimal Discount_Amt { get; set; }
        public decimal Interest_Per { get; set; }
        public decimal Interest_Amt { get; set; }
        public decimal Shipping_Charge { get; set; }
        public int Currency_ID { get; set; }
        public string Currency_Type { get; set; }
        public int Seller_ID { get; set; }

        #endregion

        #region "Details"

        public int invoice_id { get; set; }
        public int invoice_detail_id { get; set; }
        public int assort_id { get; set; }
        public int sieve_id { get; set; }
        public int sub_sieve_id { get; set; }
        public int pcs { get; set; }
        public decimal carat { get; set; }
        public decimal rej_carat { get; set; }
        public decimal rej_percentage { get; set; }
        public decimal rate { get; set; }
        public decimal amount { get; set; }
        public decimal discount { get; set; }
        public string invoice_No { get; set; }
        public decimal total_pcs { get; set; }
        public decimal total_carat { get; set; }
        public string remarks { get; set; }
        public decimal old_carat { get; set; }
        public decimal old_rej_carat { get; set; }
        public decimal old_rej_percentage { get; set; }
        public int old_pcs { get; set; }
        public int flag { get; set; }
        public int old_assort_id { get; set; }
        public int old_sieve_id { get; set; }
        public int old_sub_sieve_id { get; set; }
        public decimal current_rate { get; set; }
        public decimal current_amount { get; set; }
        public decimal loss_carat { get; set; }
        public decimal old_loss_carat { get; set; }
        public int is_memo { get; set; }
        public decimal purchase_rate { get; set; }
        public decimal purchase_amount { get; set; }
        #endregion
    }
}
