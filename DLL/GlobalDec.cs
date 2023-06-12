using System;
using System.Data.SqlClient;
namespace DLL
{
    public class GlobalDec
    {
        public static SqlConnection Connection;

        private static bool _gBoolSwapDatabase = true;
        public static bool gBoolSwapDatabase
        {
            get { return _gBoolSwapDatabase; }
            set { _gBoolSwapDatabase = value; }
        }
        public enum EnumDBProvider
        {
            None = 0,
            SqlClient = 1,
            OracleClient = 2
        }
        public enum EnumTran
        {
            Start = 0,
            Continue = 1,
            Stop = 2,
            WithCommit = 3
        }
        public static EnumDBProvider GetDBProvider(string DBProviderName)
        {
            if (DBProviderName.ToUpper() == "SYSTEM.DATA.SQLCLIENT")
            {
                return EnumDBProvider.SqlClient;
            }
            return EnumDBProvider.None;
        }
        private static string _gStrDBName;

        public static string gStrDBName
        {
            get
            {

                InterfaceLayer Ope = new InterfaceLayer();

                return _gStrDBName;

            }
            set { _gStrDBName = value; }
        }
        private static string _gStrDBDataSource;

        public static string gStrDBDataSource
        {
            get { return _gStrDBDataSource; }
            set { _gStrDBDataSource = value; }
        }
        private static string _gStrDBUserName;

        public static string gStrDBUserName
        {
            get { return _gStrDBUserName; }
            set { _gStrDBUserName = value; }
        }

        private static string _gStrDBPassWord;
        public static string gStrDBPassWord
        {
            get { return _gStrDBPassWord; }
            set { _gStrDBPassWord = value; }
        }

        public static void CreateConncetion(string ConnectionString)
        {
            Connection = new SqlConnection();
            try
            {
                Connection.ConnectionString = ConnectionString;
                if (Connection.State == System.Data.ConnectionState.Closed)
                {
                    Connection.Open();
                }
            }
            catch (Exception)
            {
                return;
            }
            return;
        }

        public static void CloseConnection()
        {
            try
            {

                if (Connection != null)
                {
                    if (Connection.State == System.Data.ConnectionState.Open)
                    {
                        Connection.Close();
                        Connection.Dispose();
                        Connection = null;
                    }
                }
                else
                {
                    Connection = null;
                }
            }
            catch (SqlException)
            {
            }
        }
    }
}
