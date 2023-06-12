using System;
using System.Data;
//using System.Data.OracleClient;
using System.Data.SqlClient;

namespace DLL
{
    public class InterfaceLayer
    {
        private string _gStrDBName;
        public string gStrDBName
        {
            get
            {
                return GlobalDec.gStrDBName;
            }
            set { _gStrDBName = value; }
        }
        private string _gStrDBDataSource;

        public string gStrDBDataSource
        {
            get { return GlobalDec.gStrDBDataSource; }
            set { _gStrDBDataSource = value; }
        }
        private string _gStrDBUserName;
        public string gStrDBUserName
        {
            get { return GlobalDec.gStrDBUserName; }
            set { _gStrDBUserName = value; }
        }
        private string _gStrDBPassWord;
        public string gStrDBPassWord
        {
            get { return GlobalDec.gStrDBPassWord; }
            set { _gStrDBPassWord = value; }
        }
        OperationSql OpeSql = new OperationSql();
        private void ClearParams(Request pRequest = null)
        {
            if (pRequest != null)
            {
                if (pRequest.CollectionParameters != null)
                {
                    pRequest.CollectionParameters.Clear();
                }
                pRequest.CollectionParameters = null;
                pRequest = null;
            }
        }
        #region Get Params
        private SqlParameter[] GetSqlParams(Request pRequest)
        {
            if (pRequest.CollectionParameters != null)
            {
                int IntI = 0;
                SqlParameter[] GetPara = new SqlParameter[pRequest.CollectionParameters.Count];
                foreach (ParameterInformation Params in pRequest.CollectionParameters)
                {
                    GetPara[IntI] = new SqlParameter(Params.ParameterName, Params.ParameterType);
                    GetPara[IntI].Value = Params.ParameterValue;
                    GetPara[IntI].Direction = Params.ParameterDirection;
                    IntI++;
                }
                ClearParams(pRequest);
                return GetPara;
            }
            return null;
        }

        #endregion

        #region Get Data For Fill Combo

        #region Connection String Bifercation
        public void ConnectionBifercation(string pStrConnectionString, string DBProviderName)
        {
            if (OpeSql == null) OpeSql = new OperationSql();
            OpeSql.ConnectionBifercation(pStrConnectionString);
            OpeSql = null;
        }
        #endregion

        #region FillComboByParameter
        public void GetDataForCombo(string pStrConnectionString, string DBProviderName, DataSet pDs, string pStrTableName, string pStrDBTableName, string pStrField, string pStrCriteria, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit, string pStrPrimaryKeys = "")
        {
            try
            {
                if (OpeSql == null) OpeSql = new OperationSql();
                OpeSql.FillComboByParameter(pStrConnectionString, pDs, pStrTableName, pStrDBTableName, pStrField, pStrCriteria, pEnumTran, pStrPrimaryKeys);
                if (pEnumTran == GlobalDec.EnumTran.Stop || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    OpeSql = null;
                }
            }
            catch (Exception ex)
            {
                OpeSql = null;
                throw ex;
            }
        }
        public void GetDataForCombo(string pStrConnectionString, string DBProviderName, DataTable pDTab, string pStrDBTableName, string pStrField, string pStrCriteria, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit, string pStrPrimaryKeys = "")
        {
            OpeSql = new OperationSql();
            OpeSql.FillComboByParameter(pStrConnectionString, pDTab, pStrDBTableName, pStrField, pStrCriteria, pEnumTran, pStrPrimaryKeys);
            OpeSql = null;
        }
        #endregion

        #endregion

        #region Get Dataset
        /// <summary>
        /// Get Dataset
        /// </summary>
        public void GetDataSet(string pStrConnectionString, string DBProviderName, DataSet pDs, string pStrTableName, Request pRequest, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit, string pStrPrimaryKeys = "")
        {
            try
            {
                if (OpeSql == null) OpeSql = new OperationSql();
                OpeSql.FillDataSet(pStrConnectionString, pDs, pStrTableName, pRequest.CommandText, pRequest.CommandType, GetSqlParams(pRequest), pEnumTran, pStrPrimaryKeys);
                if (pEnumTran == GlobalDec.EnumTran.Stop || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    OpeSql = null;
                }
            }
            catch (Exception ex)
            {
                OpeSql = null;
                throw ex;
            }
        }
        #endregion

        #region GetDataSetByParameter

        public void GetDataSetByParameter(string pStrConnectionString, string DBProviderName, DataSet pDs, string pStrTableName, string pStrDBTableName, string pStrField, string pStrCriteria, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit, string pStrPrimaryKeys = "")
        {
            try
            {
                if (OpeSql == null) OpeSql = new OperationSql();
                OpeSql.FillComboByParameter(pStrConnectionString, pDs, pStrTableName, pStrDBTableName, pStrField, pStrCriteria, pEnumTran, pStrPrimaryKeys);
                if (pEnumTran == GlobalDec.EnumTran.Stop || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    OpeSql = null;
                }
                ClearParams();
            }
            catch (Exception ex)
            {
                OpeSql = null;
                throw ex;
            }
        }

        #endregion

        #region GetDataTable
        public void GetDataTable(string pStrConnectionString, string DBProviderName, DataTable pDTab, Request pRequest, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit, string pStrPrimaryKeys = "")
        {
            try
            {
                if (OpeSql == null) OpeSql = new OperationSql();
                OpeSql.FillDataTable(pStrConnectionString, pDTab, pRequest.CommandText, pRequest.CommandType, GetSqlParams(pRequest), pEnumTran, pStrPrimaryKeys);
                if (pEnumTran == GlobalDec.EnumTran.Stop || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    OpeSql = null;
                }
                ClearParams(pRequest);
            }
            catch (Exception ex)
            {
                OpeSql = null;
                throw ex;
            }
        }

        #endregion

        //#region GetDataTable_New
        //public DataTable GetDataTable_New(string pStrConnectionString, string DBProviderName, DataTable pDTab, Request pRequest, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit, string pStrPrimaryKeys = "")
        //{
        //    OpeSql = new OperationSql();
        //    OpeSql.FillDataTable(pStrConnectionString, pDTab, pRequest.CommandText, pRequest.CommandType, GetSqlParams(pRequest), pEnumTran, pStrPrimaryKeys);
        //    OpeSql = null;
        //    ClearParams(pRequest);
        //    return pDTab;
        //}
        //#endregion

        #region GetDataRow
        public DataRow GetDataRow(string pStrConnectionString, string DBProviderName, Request pRequest, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit)
        {
            try
            {
                DataRow DRow = null;
                if (OpeSql == null) OpeSql = new OperationSql();
                DRow = OpeSql.GetDataRow(pStrConnectionString, pRequest.CommandText, pRequest.CommandType, GetSqlParams(pRequest), pEnumTran);
                if (pEnumTran == GlobalDec.EnumTran.Stop || pEnumTran == GlobalDec.EnumTran.WithCommit || DRow == null)
                {
                    OpeSql = null;
                }
                ClearParams(pRequest);
                return DRow;
            }
            catch (Exception ex)
            {
                OpeSql = null;
                throw ex;
            }
        }
        public DataRow GetDataRow(string pStrConnectionString, string DBProviderName, string pStrTableName, string pStrField, string pStrCriteria)
        {
            DataRow DRow = null;
            if (OpeSql == null) OpeSql = new OperationSql();
            DRow = OpeSql.GetDataRow(pStrConnectionString, pStrTableName, pStrField, pStrCriteria);
            OpeSql = null;
            ClearParams();
            return DRow;
        }
        #endregion

        #region FindNewID
        public int FindNewID(string pStrConnectionString, string DBProviderName, string pStrTableName, string pStrField, string pStrCriteria)
        {
            int IntRes = 0;
            OpeSql = new OperationSql();
            IntRes = OpeSql.FindNewID(pStrConnectionString, pStrTableName, pStrField, pStrCriteria);
            OpeSql = null;
            return IntRes;
        }
        public Int64 FindNewIDInt64(string pStrConnectionString, string DBProviderName, string pStrTableName, string pStrField, string pStrCriteria)
        {
            Int64 IntRes = 0;
            OpeSql = new OperationSql();
            IntRes = OpeSql.FindNewIDInt64(pStrConnectionString, pStrTableName, pStrField, pStrCriteria);
            OpeSql = null;
            return IntRes;
        }
        public int FindSrNo(string pStrConnectionString, string DBProviderName, string pStrTableName, string pStrField, string pStrCriteria)
        {
            int IntRes = 0;
            OpeSql = new OperationSql();
            IntRes = OpeSql.FindSrNo(pStrConnectionString, pStrTableName, pStrField, pStrCriteria);
            OpeSql = null;
            return IntRes;
        }
        #endregion

        #region FindText
        public string FindText(string pStrConnectionString, string DBProviderName, string pStrTableName, string pStrField, string pStrCriteria)
        {
            string Str = "";
            OpeSql = new OperationSql();
            Str = OpeSql.FindText(pStrConnectionString, pStrTableName, pStrField, pStrCriteria);
            OpeSql = null;
            return Str;
        }
        #endregion

        #region Execute Scaler
        public string ExecuteScalar(string pStrConnectionString, string DBProviderName, Request pRequest, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit)
        {
            try
            {
                string StrResult = "";
                if (OpeSql == null) OpeSql = new OperationSql();
                StrResult = OpeSql.ExecuteScalar(pStrConnectionString, pRequest.CommandText, pRequest.CommandType, GetSqlParams(pRequest), pEnumTran);
                if (pEnumTran == GlobalDec.EnumTran.Stop || pEnumTran == GlobalDec.EnumTran.WithCommit || StrResult == null)
                {
                    OpeSql = null;
                }
                ClearParams(pRequest);
                return StrResult;
            }
            catch (Exception ex)
            {
                OpeSql = null;
                throw ex;
            }
        }
        #endregion

        #region Execute Non Query
        public int ExecuteNonQuery(string pStrConnectionString, string DBProviderName, Request pRequest, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit)
        {
            try
            {
                int IntResult = 0;
                if (OpeSql == null) OpeSql = new OperationSql();
                IntResult = OpeSql.ExecuteNonQuery(pStrConnectionString, pRequest.CommandText, pRequest.CommandType, GetSqlParams(pRequest), pEnumTran);
                if (pEnumTran == GlobalDec.EnumTran.Stop || pEnumTran == GlobalDec.EnumTran.WithCommit || IntResult == -1)
                {
                    OpeSql = null;
                }
                ClearParams(pRequest);
                return IntResult;
            }
            catch (Exception ex)
            {
                OpeSql = null;
                throw ex;
            }
        }
        public void Commit(string pStrConnectionString, string DBProviderName)
        {
            OpeSql.Commit();
            OpeSql = null;
        }
        public void Rollback(string pStrConnectionString, string DBProviderName)
        {
            OpeSql.RollBack();
            OpeSql = null;
        }
        #endregion

        #region Other
        public string ENCODE_DECODE(string pStr, string pStrToEncodeOrDecode)
        {
            int IntPos;
            string StrPass;
            string StrECode;
            string StrDCode;
            char ChrSingle;

            StrECode = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StrDCode = ")(*&^%$#@!";

            for (int IntLen = 1; IntLen <= 52; IntLen++)
            {
                StrDCode = StrDCode + (Char)(IntLen + 160);
            }

            StrPass = "";
            for (int IntCnt = 0; IntCnt <= pStr.Trim().Length - 1; IntCnt++)
            {
                ChrSingle = char.Parse(pStr.Substring(IntCnt, 1));
                if (pStrToEncodeOrDecode == "E")
                {
                    IntPos = StrECode.IndexOf(ChrSingle, 0);
                }
                else
                {
                    IntPos = StrDCode.IndexOf(ChrSingle, 0);
                }
                if (pStrToEncodeOrDecode == "E")
                {
                    StrPass = StrPass + StrDCode.Substring(IntPos, 1);
                }
                else
                {
                    StrPass = StrPass + StrECode.Substring(IntPos, 1);
                }
            }
            return StrPass;
        }
        #endregion
        public void BeginTransaction(string pStrConnectionString)
        {
            OpeSql = new DLL.OperationSql();
            OpeSql.BeginTransaction(pStrConnectionString);
        }

        public void Commit()
        {
            OpeSql.Commit();
            OpeSql = null;
        }
        public void Rollback()
        {
            OpeSql.RollBack();
            OpeSql = null;
        }
    }
}
