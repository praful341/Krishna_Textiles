namespace BLL.TPV
{
    public class SProc
    {
        #region "Config"
        public static string User_Perm_Master_GetFullDetail = "User_Perm_Master_GetFullDetail";
        public static string User_Permission_Save = "User_Permission_Save";
        public static string User_Permission_Copy_Save = "User_Permission_Copy_Save";
        public static string UserAuth_Menu_Form_GetData = "UserAuth_Menu_Form_GetData";
        public static string UserAuth_Master_Save = "UserAuth_Master_Save";
        public static string User_Perm_GetFullDetail = "User_Perm_GetFullDetail";
        public static string Confir_Login_History_Save = "Confir_Login_History_Save";
        public static string Config_Single_Setting_Save = "Config_Single_Setting_Save";
        public static string Config_Single_Setting_GetData = "Config_Single_Setting_GetData";
        public static string Config_Single_Setting_CopySave = "Config_Single_Setting_CopySave";
        public static string Config_Single_Setting_Delete = "Config_Single_Setting_Delete";
        public static string Config_Menu_Master_GetData = "Config_Menu_Master_GetData";
        public static string Config_Menu_Permission_GetData = "Config_Menu_Permission_GetData";
        public static string Config_Menu_Permission_Save = "Config_Menu_Permission_Save";
        public static string MST_Employee_GetCompanyWiseData = "MST_Employee_GetCompanyWiseData";
        #endregion

        #region "Master"
        public static string Branch_Permission_GetData = "MST_Branch_Permission_GetData";
        public static string Location_Permission_GetData = "MST_Location_Permission_GetData";
        public static string Department_Permission_GetData = "MST_Department_Permission_GetData";
        public static string Company_Permission_GetData = "MST_Company_Permission_GetData";

        public static string FILL_COMBO = "FILL_COMBO";
        public static string Check_Login = "Check_Login";
        public static string Form_Master_Save = "Form_Master_Save";
        public static string Form_Master_Delete = "Form_Master_Delete";
        public static string Form_Master_GetData = "Form_Master_GetData";
        public static string MST_Branch_Save = "MST_Branch_Save";
        public static string MST_Branch_GetData = "MST_Branch_GetData";
        public static string MST_City_Save = "MST_City_Save";
        public static string MST_City_GetData = "MST_City_GetData";
        public static string MST_Company_Save = "MST_Company_Save";
        public static string MST_Company_GetData = "MST_Company_GetData";
        public static string MST_Config_Form_Save = "MST_Config_Form_Save";
        public static string MST_Config_Form_GetData = "MST_Config_Form_GetData";
        public static string MST_Config_Role_Save = "MST_Config_Role_Save";
        public static string MST_Config_Role_GetData = "MST_Config_Role_GetData";
        public static string MST_Country_Save = "MST_Country_Save";
        public static string MST_Country_GetData = "MST_Country_GetData";
        public static string MST_Department_Save = "MST_Department_Save";
        public static string MST_Department_GetData = "MST_Department_GetData";
        public static string MST_Designation_Save = "MST_Designation_Save";
        public static string MST_Designation_GetData = "MST_Designation_GetData";
        public static string MST_Employee_Save = "MST_Employee_Save";
        public static string MST_Employee_GetData = "MST_Employee_GetData";
        public static string MST_HR_Employee_Master_GetByParam = "MST_HR_Employee_Master_GetByParam";
        public static string MST_Location_Save = "MST_Location_Save";
        public static string MST_Location_GetData = "MST_Location_GetData";
        public static string MST_Menu_Save = "MST_Menu_Save";
        public static string MST_Menu_GetData = "MST_Menu_GetData";
        public static string MST_State_Save = "MST_State_Save";
        public static string MST_State_GetData = "MST_State_GetData";
        public static string MST_User_Save = "MST_User_Save";
        public static string MST_User_GetData = "MST_User_GetData";
        public static string MST_User_Type_GetData = "MST_User_Type_GetData";
        public static string MST_Theme_Save = "MST_Theme_Save";
        public static string MST_Theme_GetData = "MST_Theme_GetData";
        public static string MST_Config_Permission_Save = "MST_Config_Permission_Save";
        public static string MST_UserAuth_CheckPermission = "MST_UserAuth_CheckPermission";
        public static string MST_User_GetUser = "MST_User_GetUser";
        public static string MST_Financial_Year_Save = "MST_Financial_Year_Save";
        public static string MST_Financial_Year_GetData = "MST_Financial_Year_GetData";
        public static string MST_Preference_Save = "MST_Preference_Save";
        public static string MST_Preference_GetData = "MST_Preference_GetData";
        public static string MST_Get_FormID = "MST_Get_FormID";
        public static string MST_Get_All_Data = "MST_Get_All_Data";
        public static string MST_Get_LetestPrice = "MST_Get_LetestPrice";
        public static string MST_Settings_GetData = "MST_Settings_GetData";
        public static string MST_Config_Process_Save = "MST_Config_Process_Save";
        public static string MST_config_Emp_GetData = "MST_config_Emp_GetData";
        public static string MST_Config_Process_GetData = "MST_Config_Process_GetData";
        public static string MST_Config_PartyBroker_Save = "MST_Config_PartyBroker_Save";
        public static string MST_Config_PartyBroker_GetData = "MST_Config_PartyBroker_GetData";
        public static string MST_Bank_Save = "MST_Bank_Save";
        public static string MST_Bank_GetData = "MST_Bank_GetData";
        public static string MST_IDProof_Save = "MST_IDProof_Save";
        public static string MST_IDProof_GetData = "MST_IDProof_GetData";
        public static string MST_HrEmployee_GetData = "MST_HrEmployee_GetData";
        public static string MFG_MST_DepartmentType_Save = "MFG_MST_DepartmentType_Save";
        public static string MFG_MST_DepartmentType_GetData = "MFG_MST_DepartmentType_GetData";
        public static string MST_Distinct_Bank_GetData = "MST_Distinct_Bank_GetData";

        public static string MST_Unit_Master_Search_GetData = "MST_Unit_Master_Search_GetData";
        public static string MST_Unit_Master_GetData = "MST_Unit_Master_GetData";
        public static string MST_Unit_Master_Save = "MST_Unit_Master_Save";

        public static string MST_GST_Master_Search_GetData = "MST_GST_Master_Search_GetData";
        public static string MST_GST_Master_GetData = "MST_GST_Master_GetData";
        public static string MST_GST_Master_Save = "MST_GST_Master_Save";

        public static string MST_Item_Group_Master_Search_GetData = "MST_Item_Group_Master_Search_GetData";
        public static string MST_Item_Group_Master_GetData = "MST_Item_Group_Master_GetData";
        public static string MST_Item_Group_Master_Save = "MST_Item_Group_Master_Save";

        public static string MST_Color_GetData = "MST_Color_GetData";
        public static string MST_Color_Save = "MST_Color_Save";

        public static string MST_Size_GetData = "MST_Size_GetData";
        public static string MST_Size_Save = "MST_Size_Save";
        public static string MST_Courier_GetData = "MST_Courier_GetData";
        public static string MST_Courier_Save = "MST_Courier_Save";

        public static string MST_HSN_Master_Search_GetData = "MST_HSN_Master_Search_GetData";
        public static string MST_HSN_Master_GetData = "MST_HSN_Master_GetData";
        public static string MST_HSN_Master_Save = "MST_HSN_Master_Save";

        public static string MST_Ledger_Group_Master_Search_GetData = "MST_Ledger_Group_Master_Search_GetData";
        public static string MST_Ledger_Group_Master_GetData = "MST_Ledger_Group_Master_GetData";
        public static string MST_Ledger_Group_Master_Save = "MST_Ledger_Group_Master_Save";

        public static string MST_Ledger_Save = "MST_Ledger_Save";
        public static string MST_Ledger_GetData = "MST_Ledger_GetData";
        public static string MST_CashBank_Ledger_GetData = "MST_CashBank_Ledger_GetData";
        public static string MST_CashBank_Without_Ledger_GetData = "MST_CashBank_Without_Ledger_GetData";

        public static string MST_Item_Master_GetData = "MST_Item_Master_GetData";
        public static string MST_Item_Master_Save = "MST_Item_Master_Save";
        public static string MST_Item_Master_Delete = "MST_Item_Master_Delete";
        public static string MST_Item_Cat_Master_Save = "MST_Item_Cat_Master_Save";
        public static string MST_Item_Cat_Master_GetData = "MST_Item_Cat_Master_GetData";
        public static string MST_Item_Cat_Master_Search_GetData = "MST_Item_Cat_Master_Search_GetData";

        public static string MST_Party_Save = "MST_Party_Save";
        public static string MST_Party_GetData = "MST_Party_GetData";
        public static string MST_Party_Update = "MST_Party_Update";

        #endregion "Master"    

        #region "Transaction"

        #region Janged Entry

        public static string TRN_Janged_Entry_GetData = "TRN_Janged_Entry_GetData";
        public static string TRN_Janged_Entry_GetDetailsData = "TRN_Janged_Entry_GetDetailsData";
        public static string TRN_janged_Save = "TRN_janged_Save";
        public static string TRN_Janged_Details_Save = "TRN_Janged_Details_Save";
        public static string TRN_Janged_Entry_Delete = "TRN_Janged_Entry_Delete";
        public static string TRN_Purchase_Voucher_No_GetData = "TRN_Purchase_Voucher_No_GetData";

        #endregion "Janged Entry"    

        #region Purchase Entry

        public static string TRN_Janged_Voucher_Entry_GetData = "TRN_Janged_Voucher_Entry_GetData";
        public static string TRN_Purchase_GetData = "TRN_Purchase_GetData";
        public static string TRN_Purchase_GetDetailsData = "TRN_Purchase_GetDetailsData";
        public static string TRN_Purchase_Save = "TRN_Purchase_Save";
        public static string TRN_Purchase_Detail_Save = "TRN_Purchase_Detail_Save";
        public static string TRN_Purchase_Delete = "TRN_Purchase_Delete";

        #endregion Purchase Entry

        #region Sale Invoice Entry

        public static string TRN_SaleInvoice_Save = "TRN_SaleInvoice_Save";
        public static string TRN_SaleInvoice_Details_Save = "TRN_SaleInvoice_Details_Save";
        public static string TRN_SaleInvoice_GetData = "TRN_SaleInvoice_GetData";
        public static string TRN_SaleInvoice_GetDetailsData = "TRN_SaleInvoice_GetDetailsData";
        public static string TRN_Generate_OrderNo = "TRN_Generate_OrderNo";
        public static string TRN_SaleInvoice_Delete = "TRN_SaleInvoice_Delete";
        public static string TRN_ShippingAddress_GetData = "TRN_ShippingAddress_GetData";
        public static string TRN_Get_Invoice_No = "TRN_Get_Invoice_No";
        public static string TRN_SaleRate_GetData = "TRN_SaleRate_GetData";

        #endregion Sale Invoice Entry

        #region Courier Rate

        public static string MST_Courier_Rate_GetData = "MST_Courier_Rate_GetData";
        public static string MST_Courier_Rate_Save = "MST_Courier_Rate_Save";

        #endregion Courier Rate

        #region Dispatch Entry

        public static string TRN_Dispatch_SearchData = "TRN_Dispatch_SearchData";
        public static string TRN_Dispatch_Save = "TRN_Dispatch_Save";
        public static string MST_Courier_Collect_GetData = "MST_Courier_Collect_GetData";

        #endregion Dispatch Entry

        #region Opening Stock

        public static string TRN_Opening_GetData = "TRN_Opening_GetData";
        public static string TRN_Opening_Save = "TRN_Opening_Save";
        public static string TRN_Opening_CheckData = "TRN_Opening_CheckData";

        #endregion Opening Stock

        #region Sale Return Entry

        public static string TRN_SaleReturn_Save = "TRN_SaleReturn_Save";
        public static string TRN_SaleReturn_Details_Save = "TRN_SaleReturn_Details_Save";
        public static string TRN_SaleReturn_GetData = "TRN_SaleReturn_GetData";
        public static string TRN_SaleReturn_GetDetailsData = "TRN_SaleReturn_GetDetailsData";
        public static string TRN_SaleReturn_Delete = "TRN_SaleReturn_Delete";

        #endregion Sale Invoice Entry

        #region Purchase Return Entry

        public static string TRN_PurchaseReturn_Save = "TRN_PurchaseReturn_Save";
        public static string TRN_PurchaseReturn_Detail_Save = "TRN_PurchaseReturn_Detail_Save";
        public static string TRN_PurchaseReturn_GetData = "TRN_PurchaseReturn_GetData";
        public static string TRN_PurchaseReturn_GetDetailsData = "TRN_PurchaseReturn_GetDetailsData";
        public static string TRN_PurchaseReturn_Delete = "TRN_PurchaseReturn_Delete";

        #endregion Purchase Return Entry

        #region Payment Receipt Entry

        public static string TRN_Payment_Receipt_Save = "TRN_Payment_Receipt_Save";
        public static string TRN_Payment_OS_Invoice_Wise = "TRN_Payment_OS_Invoice_Wise";
        public static string TRN_Referance_Payment_SearchData = "TRN_Referance_Payment_SearchData";
        public static string TRN_Referance_Payment_Update = "TRN_Referance_Payment_Update";
        #endregion Payment Receipt Entry

        #endregion

        #region "Reports"

        public static string MST_Report_GetData = "MST_Report_GetData";
        public static string MST_Report_Save = "MST_Report_Save";
        public static string MST_Report_Detail_Save = "MST_Report_Detail_Save";
        public static string MST_Report_Setting_Save = "MST_Report_Setting_Save";
        public static string MST_Report_Detail_GetData = "MST_Report_Detail_GetData";
        public static string MST_Report_Setting_GetData = "MST_Report_Setting_GetData";
        public static string MST_Report_Authentication_GetData = "MST_Report_Authentication_GetData";
        public static string MST_Report_Authentication_Save = "MST_Report_Authentication_Save";
        public static string MST_Report_UserAuth_Permission = "MST_Report_UserAuth_Permission";
        public static string MST_Report_Detail_Delete = "MST_Report_Detail_Delete";
        public static string MST_Report_Delete = "MST_Report_Delete";
        public static string MST_Report_Setting_Delete = "MST_Report_Setting_Delete";
        public static string MST_Report_Setting_Del_Template = "MST_Report_Setting_Del_Template";

        #endregion "Reports"
    }
}
