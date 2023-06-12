using System;
using System.Data.SqlClient;

namespace BLL
{
    public class ListError
    {
        #region " Data Members "
        private int m_numErrorCode;
        private string m_strErrorMessage;
        private int m_numTokenNo;
        #endregion

        #region " Properties "
        public int Code
        {
            get { return m_numErrorCode; }
            set { m_numErrorCode = value; }
        }

        public string Message
        {
            get { return m_strErrorMessage; }
            set { m_strErrorMessage = value; }
        }

        public int TokenNo
        {
            get { return m_numTokenNo; }
            set { m_numTokenNo = value; }
        }
        #endregion

        #region " Constructors "
        public ListError(int p_numErrorCode, string p_strErrorMessage)
        {
            m_numErrorCode = p_numErrorCode;
            m_strErrorMessage = p_strErrorMessage;

            GetMessage();
        }

        public ListError(Exception p_expError)
        {
            m_numErrorCode = 5;
            m_strErrorMessage = p_expError.Message;

            GetMessage();
        }
        public ListError(string p_strErrorMessage)
        {
            m_numErrorCode = 5;
            m_strErrorMessage = p_strErrorMessage;

            GetMessage();
        }

        public ListError(SqlCommand p_cmdSQL)
        {
            m_numErrorCode = Convert.ToInt32(p_cmdSQL.Parameters["@ErrorCode"].Value);
            m_strErrorMessage = p_cmdSQL.Parameters["@ErrorMessage"].Value.ToString();

            GetMessage();
        }

        //For Notification Only
        public ListError(int p_numTokenNo, int p_numErrorCode, string p_strErrorMessage)
        {
            m_numTokenNo = p_numTokenNo;
            m_numErrorCode = p_numErrorCode;
            m_strErrorMessage = p_strErrorMessage;

            GetMessage();
        }
        #endregion

        #region " Functions / Procedures "
        private void GetMessage()
        {
            switch (m_numErrorCode)
            {
                case 1:
                    m_strErrorMessage = "Connection to the database could not be established.";
                    break;
                case 2:
                    m_strErrorMessage = "Data not found for " + m_strErrorMessage;
                    break;
                case 3:
                    m_strErrorMessage = "Parent key not found for " + m_strErrorMessage;
                    break;
                case 4:
                    m_strErrorMessage = "Child records exists for " + m_strErrorMessage;
                    break;
                case 5:
                    m_strErrorMessage = m_strErrorMessage + ".";
                    break;
                case 6:
                    m_strErrorMessage = "Unique constraint violated for " + m_strErrorMessage;
                    break;
                case 7:
                    m_strErrorMessage = "Username and/or password is invalid.";
                    break;
                case 8:
                    m_strErrorMessage = "To date must be always greater than From date";
                    break;
                case 9:
                    m_strErrorMessage = m_strErrorMessage + " cannot be greater than current date.";
                    break;
                case 10:
                    m_strErrorMessage = "Receive date cannot be less than issue date" + (m_strErrorMessage == string.Empty ? "" : " for " + m_strErrorMessage + ".");
                    break;
                case 11:
                    m_strErrorMessage = "Invalid " + m_strErrorMessage + ".";
                    break;
                case 12:
                    m_strErrorMessage = m_strErrorMessage + " cannot be blank.";
                    break;
                case 13:
                    m_strErrorMessage = "Please select " + m_strErrorMessage + ".";
                    break;
                case 14:
                    m_strErrorMessage = "Please specify " + m_strErrorMessage + ".";
                    break;
                case 15:
                    m_strErrorMessage = m_strErrorMessage + " must be greater than 0.";
                    break;
                case 16:
                    m_strErrorMessage = m_strErrorMessage + " difference must be equal to 0.";
                    break;
                case 17:
                    m_strErrorMessage = m_strErrorMessage + " not found.";
                    break;
                case 18:
                    m_strErrorMessage = "Duplicate " + m_strErrorMessage + " found.";
                    break;
                case 19:
                    m_strErrorMessage = "No " + m_strErrorMessage + " available.";
                    break;
                case 20:
                    m_strErrorMessage = "No row selected in " + m_strErrorMessage + " grid.";
                    break;
                case 21:
                    m_strErrorMessage = "Atleast 1 " + m_strErrorMessage + " must be select in grid.";
                    break;
                case 22:
                    m_strErrorMessage = "Atleast 1 " + m_strErrorMessage + " must be enter in grid";
                    break;
                case 23:
                    m_strErrorMessage = m_strErrorMessage + " already exist in grid.";
                    break;
                case 24:
                    m_strErrorMessage = "Multiple record found while single record needed" + (m_strErrorMessage == string.Empty ? "" : " for " + m_strErrorMessage + ".");
                    break;
                case 25:
                    m_strErrorMessage = m_strErrorMessage + " should contain value between 0 to 100.";
                    break;
                case 26:
                    m_strErrorMessage = "Start date must be always greater than End date";
                    break;
                case 27:
                    m_strErrorMessage = "Only 1 default" + (m_strErrorMessage == string.Empty ? "" : " " + m_strErrorMessage) + " allow";
                    break;
                case 28:
                    m_strErrorMessage = m_strErrorMessage + " stone(s) are already sold.";
                    break;
                case 29:
                    m_strErrorMessage = "Invalid " + m_strErrorMessage + " found.";
                    break;
                case 30:
                    m_strErrorMessage = "Error In Save " + m_strErrorMessage + " Details.";
                    break;
                case 31:
                    m_strErrorMessage = "Can't Transfer Same Company, Branch, Location And Department.";
                    break;
                case 32:
                    m_strErrorMessage = "Opening stock already exists in Same Company, Branch, Location And Department.";
                    break;
                case 33:
                    m_strErrorMessage = "Plz Check " + m_strErrorMessage + " more than outstanding pcs.";
                    break;
                case 34:
                    m_strErrorMessage = "Plz Check " + m_strErrorMessage + " more than outstanding carat.";
                    break;
                case 35:
                    m_strErrorMessage = "Can't Transfer Same Department.";
                    break;
                case 36:
                    m_strErrorMessage = "Transfer Carat not Equal to Balance Carat.";
                    break;
            }

            if (m_numErrorCode <= 100)
            {
                m_strErrorMessage = m_numErrorCode + " : " + m_strErrorMessage;
            }
        }
        #endregion
    }
}