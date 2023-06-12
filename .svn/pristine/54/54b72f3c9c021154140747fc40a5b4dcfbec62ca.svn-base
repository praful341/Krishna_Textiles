using System.Collections;
using System.Data;
namespace DLL
{

    public class Request
    {
        public Request()
        {
            _CollectionParameters = new ArrayList();
        }
        ~Request()
        {
            _CollectionParameters = null;
        }

        private ArrayList _CollectionParameters;

        public ArrayList CollectionParameters
        {
            get { return _CollectionParameters; }
            set { _CollectionParameters = value; }
        }

        private string _CommandText;

        public string CommandText
        {
            get { return _CommandText; }
            set { _CommandText = value; }
        }

        private CommandType _CommandType;

        public CommandType CommandType
        {
            get { return _CommandType; }
            set { _CommandType = value; }
        }
        private int _REF_CUR_OUT = 1;
        public int REF_CUR_OUT
        {
            get { return _REF_CUR_OUT; }
            set { _REF_CUR_OUT = value; }
        }
        public void AddParams(string pStrParameterName, object pObjParameterValue, DbType pDbType = DbType.String, ParameterDirection pParameterDirection = System.Data.ParameterDirection.Input)
        {
            ParameterInformation Param = new ParameterInformation();
            Param.ParameterName = pStrParameterName;
            Param.ParameterValue = pObjParameterValue;
            Param.ParameterType = pDbType;
            Param.ParameterDirection = pParameterDirection;
            _CollectionParameters.Add(Param);
            Param = null;
        }
    }
    public class ParameterInformation
    {
        private string _ParameterName;
        /// <summary>
        /// Input Parameter Name
        /// </summary>
        public string ParameterName
        {
            get { return _ParameterName; }
            set { _ParameterName = value; }
        }
        private object _ParameterValue;
        /// <summary>
        /// Input Parameter Value
        /// </summary>
        public object ParameterValue
        {
            get { return _ParameterValue; }
            set { _ParameterValue = value; }
        }
        private DbType _ParameterType;
        /// <summary>
        /// Parameter DataType
        /// </summary>
        public DbType ParameterType
        {
            get { return _ParameterType; }
            set { _ParameterType = value; }
        }
        private ParameterDirection _ParameterDirection;
        /// <summary>
        /// Parameter Direction Input/Output
        /// </summary>
        public ParameterDirection ParameterDirection
        {
            get { return _ParameterDirection; }
            set { _ParameterDirection = value; }
        }
        public ParameterInformation()
        {
        }
        public ParameterInformation(string pStrParameterName, object pObjParameterValue, DbType pDbType = DbType.String, ParameterDirection pParameterDirection = System.Data.ParameterDirection.Input)
        {
            ParameterName = pStrParameterName;
            ParameterValue = pObjParameterValue;
            ParameterType = pDbType;
            ParameterDirection = pParameterDirection;
        }
    }
}
