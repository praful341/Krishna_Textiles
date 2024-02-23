﻿using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;
namespace BLL.FunctionClasses.Master
{
    public class ItemHSNMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Other Function

        public int Save(ItemHSN_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@hsn_id", pClsProperty.hsn_id, DbType.Int64);
            Request.AddParams("@hsn_code", pClsProperty.hsn_code, DbType.String);
            Request.AddParams("@hsn_name", pClsProperty.hsn_name, DbType.String);
            Request.AddParams("@igst_date", pClsProperty.igst_date, DbType.Date);
            Request.AddParams("@igst_rate", pClsProperty.igst_rate, DbType.Double);
            Request.AddParams("@sgst_date", pClsProperty.sgst_date, DbType.Date);
            Request.AddParams("@sgst_rate", pClsProperty.sgst_rate, DbType.Double);
            Request.AddParams("@cgst_date", pClsProperty.cgst_date, DbType.Date);
            Request.AddParams("@cgst_rate", pClsProperty.cgst_rate, DbType.Double);
            Request.AddParams("@remark", pClsProperty.remark, DbType.String);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);
            Request.AddParams("@gst_rate", pClsProperty.gst_rate, DbType.Decimal);

            Request.CommandText = BLL.TPV.SProc.MST_HSN_Master_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@active", 1, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_HSN_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public DataTable GetData_UnitType()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@active", 1, DbType.Int32);

            Request.CommandText = BLL.TPV.SProc.MST_Unit_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = BLL.TPV.SProc.MST_HSN_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        public string ISExists(string HSNCode, Int64 HSNID)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "MST_Item_HSN", "hsn_code", "AND hsn_code = '" + HSNCode + "' AND NOT hsn_id =" + HSNID));
        }

        #endregion

    }
}

