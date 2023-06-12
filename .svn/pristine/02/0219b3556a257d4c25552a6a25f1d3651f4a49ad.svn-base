using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DLL
{
    class OperationSql
    {
        SqlConnection Connection = new SqlConnection();
        SqlCommand Command = new SqlCommand();
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        SqlTransaction Transaction;

        #region Private Method
        public void ConnectionBifercation(string pStrConnectionString)
        {
            SqlConnectionStringBuilder Str = new SqlConnectionStringBuilder(pStrConnectionString);
            GlobalDec.gStrDBDataSource = Str.DataSource;
            GlobalDec.gStrDBUserName = Str.UserID;
            GlobalDec.gStrDBPassWord = Str.Password;
            GlobalDec.gStrDBName = Str.InitialCatalog;
            Str = null;
        }
        private void DisposeAllConnObjects(SqlConnection pConn)
        {
            if (Command != null)
            {
                Command.Dispose();
                Command = null;
            }
            if (DataAdapter != null)
            {
                DataAdapter.Dispose();
                DataAdapter = null;
            }
            if (pConn != null)
            {
                if (pConn.State == System.Data.ConnectionState.Open)
                {
                    pConn.Close();
                    pConn.Dispose();
                    pConn = null;
                }
            }
            else
            {
                pConn = null;
            }
        }

        private void CreateAllConnObjects(string pStrConnectionString)
        {
            try
            {
                Connection = new SqlConnection();
                Connection.ConnectionString = pStrConnectionString;
                if (Connection.State == System.Data.ConnectionState.Closed)
                {
                    Connection.Open();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Can't Connect To [ " + Connection.DataSource + " ] Server  " + Ex.Message);
                return;
            }
            Command = new SqlCommand();
            DataAdapter = new SqlDataAdapter();
        }

        #endregion

        #region FillDataTable

        public void FillDataTable(string pStrConnectionString, DataTable pDTab, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit, string pStrPrimaryKeys = "")
        {
            try
            {
                if (pEnumTran == GlobalDec.EnumTran.Start || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    CreateAllConnObjects(pStrConnectionString);
                    Transaction = Connection.BeginTransaction("SampleTransaction");
                }
                //CreateAllConnObjects(pStrConnectionString);
                Command = Connection.CreateCommand();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = pStrCommandText;
                Command.Connection = Connection;
                Command.CommandTimeout = 50000;
                Command.CommandType = pEnmCommandType;
                Command.Transaction = Transaction;

                if (pEnmCommandType == CommandType.StoredProcedure && pParamList != null)
                {
                    for (int i = 0; i < pParamList.Length; i++)
                    {
                        if (pParamList[i] != null)
                            Command.Parameters.Add(pParamList[i]);
                    }
                }

                if (pDTab != null)
                {
                    pDTab.Rows.Clear();
                    pDTab.Columns.Clear();
                }
                DataAdapter.SelectCommand = Command;

                DataAdapter.Fill(pDTab);
                if (pEnumTran == GlobalDec.EnumTran.Stop || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    Transaction.Commit();
                    DisposeAllConnObjects(Connection);
                }
            }
            catch (SqlException ex)
            {
                Transaction.Rollback();
                DisposeAllConnObjects(Connection);
                MessageBox.Show(ex.Message.ToString());
                throw ex;
            }
            finally
            {
                //if (Transaction != null)
                //    Transaction.Rollback();
                //DisposeAllConnObjects(Connection);
                if (pStrPrimaryKeys != "")
                {
                    string[] StrArray;
                    StrArray = pStrPrimaryKeys.Split(',');
                    DataColumn[] DataColumnPrimaryKey;
                    DataColumnPrimaryKey = new DataColumn[StrArray.GetUpperBound(0) + 1];
                    for (int IntCount = 0; IntCount <= StrArray.GetUpperBound(0); IntCount++)
                    {
                        DataColumnPrimaryKey[IntCount] = pDTab.Columns[IntCount];
                    }
                    pDTab.PrimaryKey = DataColumnPrimaryKey;
                    DataColumnPrimaryKey = null;
                }
            }
        }

        #endregion

        #region FillDataset

        public void FillDataSet(string pStrConnectionString, DataSet pDs, string pStrTableName, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit, string pStrPrimaryKeys = "")
        {
            //FillDataTable(pStrConnectionString, pDs.Tables[pStrTableName], pStrCommandText, pEnmCommandType, null, pStrPrimaryKeys);
            FillDataset(pStrConnectionString, pDs, pStrCommandText, pEnmCommandType, pParamList, pEnumTran, pStrPrimaryKeys, pStrTableName);
        }

        public void FillDataset(string pStrConnectionString, DataSet pDTab, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit, string pStrPrimaryKeys = "", string pStrTableName = "")
        {
            try
            {
                if (pEnumTran == GlobalDec.EnumTran.Start || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    CreateAllConnObjects(pStrConnectionString);
                    Transaction = Connection.BeginTransaction("SampleTransaction");
                }
                //CreateAllConnObjects(pStrConnectionString);
                Command = Connection.CreateCommand();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = pStrCommandText;
                Command.Connection = Connection;
                Command.CommandTimeout = 50000;
                Command.CommandType = pEnmCommandType;
                Command.Transaction = Transaction;

                if (pEnmCommandType == CommandType.StoredProcedure && pParamList != null)
                {
                    for (int i = 0; i < pParamList.Length; i++)
                    {
                        if (pParamList[i] != null)
                            Command.Parameters.Add(pParamList[i]);
                    }
                }

                //if (pDTab.Tables.Count > 0)
                //{
                //    pDTab.Tables[0].Rows.Clear();
                //    pDTab.Tables[0].Columns.Clear();
                //}

                DataAdapter.SelectCommand = Command;

                DataAdapter.Fill(pDTab);
                if (pStrTableName.Length > 0)
                {
                    if (pDTab.Tables.Count > 0)
                    {
                        pDTab.Tables[0].TableName = pStrTableName;
                    }
                }
                if (pEnumTran == GlobalDec.EnumTran.Stop || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    Transaction.Commit();
                    DisposeAllConnObjects(Connection);
                }
            }
            catch (SqlException ex)
            {
                Transaction.Rollback();
                DisposeAllConnObjects(Connection);
                MessageBox.Show(ex.Message.ToString());
                throw ex;
            }
            finally
            {
                //DisposeAllConnObjects(Connection);
                if (pStrPrimaryKeys != "")
                {
                    string[] StrArray;
                    StrArray = pStrPrimaryKeys.Split(',');
                    DataColumn[] DataColumnPrimaryKey;
                    DataColumnPrimaryKey = new DataColumn[StrArray.GetUpperBound(0) + 1];
                    for (int IntCount = 0; IntCount <= StrArray.GetUpperBound(0); IntCount++)
                    {
                        //    DataColumnPrimaryKey[IntCount] = pDTab.Columns[IntCount];
                    }
                    //  pDTab.PrimaryKey = DataColumnPrimaryKey;
                    DataColumnPrimaryKey = null;
                }
            }
        }

        #endregion

        #region FillComboByParameter
        public void FillComboByParameter(string pStrConnectionString, DataSet pDs, string pStrTableName, string pStrDBTableName, string pStrField, string pStrCriteria, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit, string pStrPrimaryKeys = "")
        {
            string StrQuery = "Select " + pStrField + " From " + pStrDBTableName + " Where 1=1 " + pStrCriteria + "";
            FillDataSet(pStrConnectionString, pDs, pStrTableName, StrQuery, CommandType.Text, null, pEnumTran, pStrPrimaryKeys);
        }

        public void FillComboByParameter(string pStrConnectionString, DataTable pDTab, string pStrDBTableName, string pStrField, string pStrCriteria, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit, string pStrPrimaryKeys = "")
        {
            string StrQuery = "Select " + pStrField + " From " + pStrDBTableName + " Where 1=1 " + pStrCriteria + "";
            FillDataTable(pStrConnectionString, pDTab, StrQuery, CommandType.Text, null, pEnumTran, pStrPrimaryKeys);
        }

        #endregion

        #region GetDataRow
        public DataRow GetDataRow(string pStrConnectionString, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit)
        {
            DataTable DTab = new DataTable();
            DataRow DRow = null;
            try
            {
                FillDataTable(pStrConnectionString, DTab, pStrCommandText, pEnmCommandType, pParamList, pEnumTran);
                if (DTab != null)
                {
                    if (DTab.Rows.Count > 0)
                    {
                        DRow = DTab.Rows[0];
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                DTab = null;
                DisposeAllConnObjects(Connection);
            }
            return DRow;
        }
        public DataRow GetDataRow(string pStrConnectionString, string pStrTableName, string pStrField, string pStrCriteria)
        {
            DataTable DTab = new DataTable();
            DataRow DRow = null;
            try
            {
                //string StrQuery = "Select " + pStrField + " From " + pStrTableName + " Where 1=1 " + pStrCriteria + "";

                string Field = "REPLACE(CONVERT(varchar(11),getdate(),106),' ','/')";

                string StrQuery = "Select " + Field + "";

                DRow = GetDataRow(pStrConnectionString, StrQuery, CommandType.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                DTab = null;
                DisposeAllConnObjects(Connection);
            }
            return DRow;
        }

        #endregion

        #region FindNewID

        public int FindNewID(string pStrConnectionString, string pStrTableName, string pStrField, string pStrCriteria)
        {
            int IntRes = 0;

            string StrQuery = "Select IsNull(" + pStrField + ",0) As ID From " + pStrTableName + " Where 1=1 " + pStrCriteria + "";

            DataRow DRow = GetDataRow(pStrConnectionString, StrQuery, CommandType.Text);

            if (DRow != null)
            {
                IntRes = Convert.ToInt32(DRow["ID"].ToString()) + 1;
            }
            DRow = null;
            return IntRes;
        }
        public Int64 FindNewIDInt64(string pStrConnectionString, string pStrTableName, string pStrField, string pStrCriteria)
        {
            Int64 IntRes = 0;

            string StrQuery = "Select IsNull(" + pStrField + ",0) As ID From " + pStrTableName + " Where 1=1 " + pStrCriteria + "";

            DataRow DRow = GetDataRow(pStrConnectionString, StrQuery, CommandType.Text);

            if (DRow != null)
            {
                IntRes = Convert.ToInt64(DRow["ID"].ToString()) + 1;
            }
            DRow = null;
            return IntRes;
        }
        public int FindSrNo(string pStrConnectionString, string pStrTableName, string pStrField, string pStrCriteria)
        {
            int IntRes = 0;

            string StrQuery = "Select IsNull(" + pStrField + ",0) As ID From " + pStrTableName + " Where 1=1 " + pStrCriteria + "";

            DataRow DRow = GetDataRow(pStrConnectionString, StrQuery, CommandType.Text);

            if (DRow != null)
            {
                IntRes = Convert.ToInt32(DRow["ID"].ToString());
            }
            DRow = null;
            return IntRes;
        }

        #endregion

        #region FindText
        public string FindText(string pStrConnectionString, string pStrTableName, string pStrField, string pStrCriteria)
        {
            string StrRes = "";

            string StrQuery = "Select " + pStrField + " As ID From " + pStrTableName + " Where 1=1 " + pStrCriteria + "";

            DataRow DRow = GetDataRow(pStrConnectionString, StrQuery, CommandType.Text);

            if (DRow != null)
            {
                StrRes = DRow["ID"].ToString();
            }
            DRow = null;
            return StrRes;
        }
        #endregion

        #region SQLDataReader
        public SqlDataReader ExeReader(string pStrConnectionString, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit)
        {
            try
            {
                SqlDataReader dr;
                if (pEnumTran == GlobalDec.EnumTran.Start || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    CreateAllConnObjects(pStrConnectionString);
                    Transaction = Connection.BeginTransaction("SampleTransaction");
                }
                //CreateAllConnObjects(pStrConnectionString);
                Command = Connection.CreateCommand();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = pStrCommandText;
                Command.Connection = Connection;

                Command.CommandType = pEnmCommandType;

                if (pEnmCommandType == CommandType.StoredProcedure && pParamList != null)
                {
                    for (int i = 0; i < pParamList.Length; i++)
                    {
                        if (pParamList[i] != null)
                            Command.Parameters.Add(pParamList[i]);
                    }
                }
                dr = Command.ExecuteReader();
                if (pEnumTran == GlobalDec.EnumTran.Stop || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    Transaction.Commit();
                    DisposeAllConnObjects(Connection);
                }
                return dr;
            }
            catch (SqlException ex)
            {

                Transaction.Rollback();
                DisposeAllConnObjects(Connection);
                MessageBox.Show(ex.Message.ToString());
                throw ex;
            }
            finally
            {
                //DisposeAllConnObjects(Connection);
            }
        }
        #endregion

        #region Execute Scaler
        public string ExecuteScalar(string pStrConnectionString, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit)
        {
            string Str = "";
            try
            {
                if (pEnumTran == GlobalDec.EnumTran.Start || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    CreateAllConnObjects(pStrConnectionString);
                    Transaction = Connection.BeginTransaction("SampleTransaction");
                }
                //CreateAllConnObjects(pStrConnectionString);
                Command = Connection.CreateCommand();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = pStrCommandText;
                Command.Connection = Connection;
                Command.Transaction = Transaction;
                Command.CommandType = pEnmCommandType;

                if (pEnmCommandType == CommandType.StoredProcedure && pParamList != null)
                {
                    for (int i = 0; i < pParamList.Length; i++)
                    {
                        if (pParamList[i] != null)
                            Command.Parameters.Add(pParamList[i]);
                    }
                }
                Str = Command.ExecuteScalar().ToString();
                if (pEnumTran == GlobalDec.EnumTran.Stop || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    Transaction.Commit();
                    DisposeAllConnObjects(Connection);
                }
            }
            catch (SqlException ex)
            {
                Transaction.Rollback();
                DisposeAllConnObjects(Connection);
                MessageBox.Show(ex.Message.ToString());
                throw ex;
            }
            finally
            {
                //DisposeAllConnObjects(Connection);
            }
            if (Str.Length == 0)
            {
                Str = "";
            }
            return Str;
        }
        #endregion

        #region Execute Non Query
        public int ExecuteNonQuery(string pStrConnectionString, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit)
        {
            int IntResult = 0;
            try
            {
                if (pEnumTran == GlobalDec.EnumTran.Start || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    CreateAllConnObjects(pStrConnectionString);
                    Transaction = Connection.BeginTransaction("SampleTransaction");
                }
                //CreateAllConnObjects(pStrConnectionString);
                //Transaction = Connection.BeginTransaction("SampleTransaction");
                Command = Connection.CreateCommand();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = pStrCommandText;
                Command.Connection = Connection;
                Command.Transaction = Transaction;
                if (pEnmCommandType == CommandType.StoredProcedure && pParamList != null)
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < pParamList.Length; i++)
                    {
                        if (pParamList[i] != null)
                            Command.Parameters.Add(pParamList[i]);
                    }
                }
                else if (pEnmCommandType == CommandType.Text)
                {
                    Command.CommandType = CommandType.Text;
                }
                IntResult = Command.ExecuteNonQuery();
                //Transaction.Commit();
                if (pEnumTran == GlobalDec.EnumTran.Stop || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    Transaction.Commit();
                    DisposeAllConnObjects(Connection);
                }
            }
            catch (SqlException ex)
            {
                Transaction.Rollback();
                DisposeAllConnObjects(Connection);
                MessageBox.Show(ex.Message.ToString());
                throw ex;
            }

            return IntResult;
        }
        public ArrayList ExecuteNonQueryWithRetunValues(ArrayList AL, string pStrConnectionString, string pStrCommandText, CommandType pEnmCommandType, SqlParameter[] pParamList = null, GlobalDec.EnumTran pEnumTran = GlobalDec.EnumTran.WithCommit)
        {
            int IntResult = 0;
            try
            {
                if (pEnumTran == GlobalDec.EnumTran.Start || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    CreateAllConnObjects(pStrConnectionString);
                    Transaction = Connection.BeginTransaction("SampleTransaction");
                }
                //CreateAllConnObjects(pStrConnectionString);
                Command = Connection.CreateCommand();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = pStrCommandText;
                Command.Connection = Connection;

                if (pEnmCommandType == CommandType.StoredProcedure && pParamList != null)
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < pParamList.Length; i++)
                    {
                        if (pParamList[i] != null)
                        {
                            Command.Parameters.Add(pParamList[i]);
                        }
                    }
                }
                else if (pEnmCommandType == CommandType.Text)
                {
                    Command.CommandType = CommandType.Text;
                }

                IntResult = Command.ExecuteNonQuery();
                AL.Clear();
                foreach (SqlParameter iParam in pParamList)
                {
                    if (iParam.Direction == ParameterDirection.Output || iParam.Direction == ParameterDirection.InputOutput || iParam.Direction == ParameterDirection.ReturnValue)
                    {
                        AL.Add(iParam.Value);
                    }
                }
                if (pEnumTran == GlobalDec.EnumTran.Stop || pEnumTran == GlobalDec.EnumTran.WithCommit)
                {
                    Transaction.Commit();
                    DisposeAllConnObjects(Connection);
                }
            }
            catch (SqlException ex)
            {
                Transaction.Rollback();
                DisposeAllConnObjects(Connection);
                MessageBox.Show(ex.Message.ToString());
                throw ex;
            }
            finally
            {
                //DisposeAllConnObjects(Connection);
            }
            return AL;
        }
        #endregion

        public void BeginTransaction(string ConnectionString)
        {
            CreateAllConnObjects(ConnectionString);
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction.Commit();
            DisposeAllConnObjects(Connection);
        }
        public void RollBack()
        {
            Transaction.Rollback();
            DisposeAllConnObjects(Connection);
        }
    }
}
