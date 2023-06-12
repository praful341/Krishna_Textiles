using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BLL
{
    public class General
    {
        #region " General "
        public static object NVLRet(object p_CheckValue, object p_value)
        {
            if (p_CheckValue == DBNull.Value)
                return p_value;
            else if (p_CheckValue == null)
                return p_value;
            else
                return p_CheckValue;
        }

        public static object NVLRet(object p_CheckValue)
        {
            if (p_CheckValue == DBNull.Value)
                return DBNull.Value;
            else if (p_CheckValue == null)
                return DBNull.Value;
            else if (p_CheckValue.GetType() == typeof(DateTime))
            {
                if (Convert.ToDateTime(p_CheckValue) == DateTime.MinValue)
                    return DBNull.Value;
            }
            else if (p_CheckValue.ToString() == "")
                return DBNull.Value;
            else if (p_CheckValue.ToString() == "0")
                return DBNull.Value;

            return p_CheckValue;
        }
        #endregion

        #region " Errors "
        public static bool ShowErrors(List<ListError> p_lstErrors)
        {
            if (p_lstErrors.Count > 0)
            {
                frmErrorList objfrmErrors = new frmErrorList(p_lstErrors);
                objfrmErrors.ShowDialog();
                objfrmErrors.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ShowErrors(List<ListError> p_lstErrors, bool p_IsblnForExpNotification, ref SqlConnection p_cnnLSSales)
        {
            if (p_lstErrors.Count > 0)
            {
                frmErrorList objfrmErrors = new frmErrorList(p_lstErrors, p_IsblnForExpNotification, ref p_cnnLSSales);
                objfrmErrors.ShowDialog();
                objfrmErrors.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ShowErrors(Exception ex)
        {
            frmErrorList objfrmErrors = new frmErrorList(new ListError(5, ex.Message));
            objfrmErrors.ShowDialog();
            objfrmErrors.Dispose();
        }

        public static void ShowErrors(string p_strErrorMessage)
        {
            frmErrorList objfrmErrors = new frmErrorList(new ListError(5, p_strErrorMessage));
            objfrmErrors.ShowDialog();
            objfrmErrors.Dispose();
        }

        public static bool ShowErrors(int p_numErrorCode, string p_strErrorMessage)
        {
            if (p_numErrorCode == 0)
            {
                return false;
            }
            else
            {
                frmErrorList objfrmErrors = new frmErrorList(new ListError(p_numErrorCode, p_strErrorMessage));
                objfrmErrors.ShowDialog();
                objfrmErrors.Dispose();
                return true;
            }
        }

        public static bool CopyErrors(List<ListError> p_lstCopyToErrors, List<ListError> p_lstCopyFromErrors)
        {
            if (p_lstCopyFromErrors.Count > 0)
            {
                foreach (ListError objError in p_lstCopyFromErrors)
                {
                    p_lstCopyToErrors.Add(objError);
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public static void FullSizeForm(DevExpress.XtraEditors.XtraForm p_frmForm)
        {
            p_frmForm.Top = 0;
            p_frmForm.Left = 0;
            int screenwidth, screenheight;
            screenwidth = Screen.PrimaryScreen.Bounds.Width;
            screenheight = Screen.PrimaryScreen.Bounds.Height;
            p_frmForm.Width = screenwidth - 20;
            p_frmForm.Height = screenheight - 135;

            p_frmForm.Location = new System.Drawing.Point(7, 3);
        }

        #endregion

        #region " Form Functions "
        public static bool ShowForm(string strChildFormName, Form frmMDIParent)
        {
            foreach (Form objfrm in frmMDIParent.MdiChildren)
            {
                if (objfrm.Name.Equals(strChildFormName))
                {
                    objfrm.Show();
                    objfrm.BringToFront();
                    objfrm.Select();
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region " Encryption/Decryption "
        public static string Encrypt(string strToEncrypt, bool blnUseHashing)
        {
            byte[] bytKeyArray;
            byte[] bytToEncryptArray = UTF8Encoding.UTF8.GetBytes(strToEncrypt);
            string key = "DnKTech123";
            if (blnUseHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                bytKeyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
            {
                bytKeyArray = UTF8Encoding.UTF8.GetBytes(key);
            }
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = bytKeyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(bytToEncryptArray, 0, bytToEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static String Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            string key = "DnKTech123";

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion

        #region " Data "
        public static bool GetData(ref SqlConnection p_cnnSQL, string p_strSQL, ref DataTable p_dtbTable)
        {
            p_dtbTable = new DataTable();
            SqlCommand cmdFetch = new SqlCommand();
            SqlDataAdapter dapFetch = new SqlDataAdapter();
            bool blnReturn = true;
            try
            {
                if (p_cnnSQL.State != ConnectionState.Open)
                    p_cnnSQL.Open();

                cmdFetch.Connection = p_cnnSQL;
                cmdFetch.CommandType = CommandType.Text;
                cmdFetch.CommandText = p_strSQL;
                dapFetch = new SqlDataAdapter(cmdFetch);
                dapFetch.Fill(p_dtbTable);
            }
            catch (Exception ex)
            {
                ShowErrors(ex);
                blnReturn = false;
            }

            return blnReturn;
        }
        #endregion
    }
}
