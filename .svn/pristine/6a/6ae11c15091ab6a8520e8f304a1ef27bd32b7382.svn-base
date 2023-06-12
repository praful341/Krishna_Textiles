using System;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BLL
{
    public class Validation
    {
        #region Enumaration
        public enum DateFormat
        {
            MMDDYYYY = 0,
            MMDDYY = 1,
            DDMMYYYY = 2,
            DDMMYY = 3,
            YYYYDDMM = 4,
            YYDDMM = 5,
            YYYYMMDD = 6,
            YYMMDD = 7,
            DDMMMYYYY = 8,
        }
        public enum TimeFormat
        {
            HHMMTT = 0,
            HHMMSSTT = 1,
            HHMMSS = 2,
        }

        #endregion

        #region Conversion Utility

        public double Round(double pDouCarat, int pIntDecimal)
        {
            return Math.Round(pDouCarat, pIntDecimal);
        }
        public double ToDouble(object pObj)
        {
            double Answer = 0;
            if (pObj == null) return Answer;
            if (pObj.ToString().ToUpper() == "NAN")
            {
                return 0.00;
            }
            if (double.TryParse(pObj.ToString(), out Answer))
            {
                return Answer;
            }
            else
            {
                return Answer;
            }
        }

        public string PropertText(object pObj)
        {
            if (pObj == null) return "";
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ToString(pObj).ToLower());
        }

        public long ToLong(object pObj)
        {
            long Answer = 0;
            if (pObj == null) return Answer;
            if (pObj.ToString().ToUpper() == "NAN")
            {
                return 0;
            }
            if (long.TryParse(pObj.ToString(), out Answer))
            {
                return Answer;
            }
            else
            {
                return Answer;
            }
        }

        public double Val(object pObj)
        {
            return ToDouble(pObj);
        }

        public int ToInt(object pObj)
        {
            int Answer = 0;
            if (pObj == null) return Answer;
            if (int.TryParse(pObj.ToString(), out Answer))
            {
                return Answer;
            }
            else
            {
                return Answer;
            }
        }

        public Int16 ToInt16(object pObj)
        {
            Int16 Answer = 0;
            if (pObj == null) return Answer;
            if (Int16.TryParse(pObj.ToString(), out Answer))
            {
                return Answer;
            }
            else
            {
                return Answer;
            }
        }

        public Int32 ToInt32(object pObj)
        {
            Int32 Answer = 0;
            if (pObj == null) return Answer;
            if (Int32.TryParse(pObj.ToString(), out Answer))
            {
                return Answer;
            }
            else
            {
                return Answer;
            }
        }

        public Int64 ToInt64(object pObj)
        {
            Int64 Answer = 0;
            if (pObj == null) return Answer;
            if (Int64.TryParse(pObj.ToString(), out Answer))
            {
                return Answer;
            }
            else
            {
                return Answer;
            }
        }

        public decimal ToDecimal(object pObj)
        {
            decimal Answer = 0;
            if (pObj == null) return Answer;
            if (decimal.TryParse(pObj.ToString(), out Answer))
            {
                return Answer;
            }
            else
            {
                return Answer;
            }
        }

        public string ToString(object pObj)
        {
            //string Answer = "";
            //if (pObj == null || pObj.ToString().ToUpper() == "NAN") 
            if (pObj == null)
                return "";
            return pObj.ToString();
        }

        public string GetFullTime12()
        {
            return DateTime.Now.ToString("hh:mm:ss:fff tt");
        }
        public string GetShortTime12()
        {
            return DateTime.Now.ToString("hh:mm:ss tt");
        }
        public string GetFullTime24()
        {
            return DateTime.Now.ToString("HH:mm:ss:fff");
        }
        public string GetShortTime24()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        public string ToDate(object pObj, DateFormat pDateFormat)
        {

            if (pObj == null || pObj.ToString() == "")
            {
                return "";
            }

            DateTime DT;

            if (DateTime.TryParse(pObj.ToString(), out DT))
            {
                if (pDateFormat == DateFormat.DDMMYY)
                {
                    return DateTime.Parse(pObj.ToString()).ToString("dd/MM/yy");
                }
                else if (pDateFormat == DateFormat.DDMMYYYY)
                {
                    return DateTime.Parse(pObj.ToString()).ToString("dd/MM/yyyy");
                }
                else if (pDateFormat == DateFormat.MMDDYY)
                {
                    return DateTime.Parse(pObj.ToString()).ToString("MM/dd/yy");
                }
                else if (pDateFormat == DateFormat.MMDDYYYY)
                {
                    return DateTime.Parse(pObj.ToString()).ToString("MM/dd/yyyy");
                }
                else if (pDateFormat == DateFormat.YYDDMM)
                {
                    return DateTime.Parse(pObj.ToString()).ToString("yy/dd/MM");
                }
                else if (pDateFormat == DateFormat.YYMMDD)
                {
                    return DateTime.Parse(pObj.ToString()).ToString("yy/MM/dd");
                }
                else if (pDateFormat == DateFormat.YYYYDDMM)
                {
                    return DateTime.Parse(pObj.ToString()).ToString("yyyy/dd/MM");
                }
                else if (pDateFormat == DateFormat.YYYYMMDD)
                {
                    return DateTime.Parse(pObj.ToString()).ToString("yyyy/MM/dd");
                }
                //else if (pDateFormat == DateFormat.DDMMMYYYY)
                //{
                //    return DateTime.Parse(pObj.ToString()).ToString("dd MMM yyyy");
                //}
                else if (pDateFormat == DateFormat.DDMMMYYYY)
                {
                    return DateTime.Parse(pObj.ToString()).ToString("dd/MMM/yyyy");
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public DateTime StringToDate(object pObj, DateFormat pDateFormat)
        {
            string StrDate = ToDate(pObj, pDateFormat);
            return DateTime.Parse(StrDate);
        }

        public DateTime StringToTime(object pObj, TimeFormat pTimeFormat)
        {
            string StrDate = ToTime(pObj, pTimeFormat);
            return DateTime.Parse(StrDate);
        }

        public string DBDate(string pStrDate)
        {
            return ToDate(pStrDate, DateFormat.DDMMMYYYY);
        }

        public string DBTime(string pStrDate)
        {
            return ToTime(pStrDate, TimeFormat.HHMMSSTT);
        }

        public string ToTime(object pObj, TimeFormat pTimeFormat)
        {

            if (pObj == null || pObj.ToString() == "")
            {
                return "";
            }

            DateTime DT;

            if (DateTime.TryParse(pObj.ToString(), out DT))
            {
                if (pTimeFormat == TimeFormat.HHMMSS)
                {
                    return DateTime.Parse(pObj.ToString()).ToString("hh:mm:ss");
                }

                else if (pTimeFormat == TimeFormat.HHMMSSTT)
                {
                    return DateTime.Parse(pObj.ToString()).ToString("hh:mm:ss tt");
                }
                else if (pTimeFormat == TimeFormat.HHMMTT)
                {
                    return DateTime.Parse(pObj.ToString()).ToString("hh:mm tt");
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }




        public Boolean ToBoolean(object pObj)
        {
            if (pObj == null || pObj.ToString() == "")
            {
                return false;
            }
            bool Answer = false;
            bool.TryParse(pObj.ToString(), out Answer);
            return Answer;
        }

        public int ToBooleanToInt(object pObj)
        {
            if (pObj == null || pObj.ToString() == "")
            {
                return 0;
            }
            bool Answer = false;
            bool.TryParse(pObj.ToString(), out Answer);
            if (Answer == false)
                return 0;
            else
                return 1;
        }



        #endregion

        #region Check Utility

        public bool ISDate(object pObj)
        {
            if (pObj == null || pObj.ToString() == "")
            {
                return false;
            }
            DateTime Answer;
            if (DateTime.TryParse(pObj.ToString(), out Answer))
            {
                return true;
            }
            return false;
        }

        public bool ISTime(object pObj)
        {
            if (pObj == null || pObj.ToString() == "")
            {
                return false;
            }
            DateTime Answer;
            if (DateTime.TryParse(pObj.ToString(), out Answer))
            {
                return true;
            }
            return false;
        }

        public bool ISNumeric(object pObj)
        {
            if (pObj == null || pObj.ToString() == "")
            {
                return false;
            }
            double Answer;
            if (double.TryParse(pObj.ToString(), out Answer))
            {
                return true;
            }
            return false;
        }

        public static bool IsAlphaNumeric(string pStr)
        {
            bool BlnValid = true;

            String StrAN = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < pStr.Length; i++)
            {
                if (StrAN.IndexOf(pStr[i]) < 0)
                {
                    BlnValid = false;
                    break;
                }
            }
            return BlnValid;
        }

        #endregion

        #region Encryption

        public string Encrypt(string ToEncrypt, string Key)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(ToEncrypt);
            //System.Configuration.AppSettingsReader settingsReader = new     AppSettingsReader();

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tDes = new TripleDESCryptoServiceProvider();
            tDes.Key = keyArray;
            tDes.Mode = CipherMode.ECB;
            tDes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tDes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tDes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public string Decrypt(string cypherString, string Key)
        {
            byte[] keyArray;
            byte[] toDecryptArray = Convert.FromBase64String(cypherString);
            //byte[] toEncryptArray = Convert.FromBase64String(cypherString);
            //System.Configuration.AppSettingsReader settingReader = new     AppSettingsReader();

            MD5CryptoServiceProvider hashmd = new MD5CryptoServiceProvider();
            keyArray = hashmd.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
            hashmd.Clear();

            TripleDESCryptoServiceProvider tDes = new TripleDESCryptoServiceProvider();
            tDes.Key = keyArray;
            tDes.Mode = CipherMode.ECB;
            tDes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tDes.CreateDecryptor();
            try
            {
                byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);

                tDes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Datatable Search

        public string SearchText(DataTable DTab, string pStrSearchKeyField, string pStrSearchValueField, string pStrReturnField)
        {
            if (DTab == null)
            {
                return "";
            }
            string StrQuery = "";
            string StrResult = "";
            string[] Key = pStrSearchKeyField.Split(',');
            string[] Value = pStrSearchValueField.Split(',');

            for (int IntI = 0; IntI < Key.Length; IntI++)
            {
                if (IntI == 0)
                {
                    StrQuery = Key[IntI].ToString() + " = '" + Value[IntI].ToString() + "'";
                }
                else
                {
                    StrQuery += " AND " + Key[IntI].ToString() + " = '" + Value[IntI].ToString() + "'";
                }
            }

            DataRow[] result = DTab.Select(StrQuery);

            if (result != null && result.Length != 0)
            {
                StrResult = result[0][pStrReturnField].ToString();
            }

            Key = null;
            Value = null;
            result = null;

            return StrResult;
        }


        #endregion

        #region Format

        /// <summary>
        /// To Format String With Object Expression
        /// </summary>
        /// <param name="Expression"></param>
        /// <param name="Style"></param>
        /// <returns></returns>
        public string Format(object Expression, string Style)
        {
            if (Style.IndexOf('#') != -1)
            {
                if (Style.IndexOf('.') != -1)
                {
                    double douval = this.ToDouble(Expression);
                    return Microsoft.VisualBasic.Strings.Format(douval, Style);
                }
                else
                {
                    Int64 int64val = ToInt64(this.ToString(Expression));
                    return Microsoft.VisualBasic.Strings.Format(int64val, Style);
                }
            }
            else
            {
                return Microsoft.VisualBasic.Strings.Format(Expression, Style);
            }
        }

        public string FormatWithSeperator(object Expression)
        {
            if (Expression == null)
            {
                return "";
            }
            double Answer = Val(Expression.ToString());

            if (Answer == 0)
            {
                return "";
            }

            System.Globalization.NumberFormatInfo info = new System.Globalization.NumberFormatInfo(); // Use For Number Formate Saperator;
            info.NumberGroupSizes = new int[] { 3, 2 }; // Use For Number Formate Saperator;      

            //return Answer < 0 ? String.Format("{0:N2}", Math.Round((Answer * -1), 2), " Cr") : String.Format("{0:N2}", Math.Round(Answer, 2), " Dr");
            return Answer < 0 ? String.Format(info, "{0:#,#.#0}", Math.Round((Answer * -1), 2), " Cr") : String.Format(info, "{0:#,#.#0}", Math.Round((Answer), 2), " Dr");
        }

        public string Trim(object Expression)
        {
            return ToString(Expression).Replace(" ", "");
            //return Microsoft.VisualBasic.Strings.Trim(ToString(Expression));
        }

        public string LTrim(object Expression)
        {
            return Microsoft.VisualBasic.Strings.LTrim(ToString(Expression));
        }

        public string RTrim(object Expression)
        {
            return Microsoft.VisualBasic.Strings.RTrim(ToString(Expression));
        }

        public string SetCrDr(object Expression, bool IsThousandSeperator = false)
        {
            if (Expression == null)
            {
                return "";
            }
            double Answer = Val(Expression.ToString());

            if (IsThousandSeperator == false)
            {
                return Answer < 0 ? Math.Round((Answer * -1), 2).ToString() : Math.Round(Answer, 2).ToString();
            }
            else
            {
                System.Globalization.NumberFormatInfo info = new System.Globalization.NumberFormatInfo(); // Use For Number Formate Saperator;
                info.NumberGroupSizes = new int[] { 3, 2 }; // Use For Number Formate Saperator;      

                //return Answer < 0 ? String.Format("{0:N2}", Math.Round((Answer * -1), 2), " Cr") : String.Format("{0:N2}", Math.Round(Answer, 2), " Dr");
                return Answer < 0 ? String.Format(info, "{0:#,#.#0}{1}", Math.Round((Answer * -1), 2), " Cr") : String.Format(info, "{0:#,#.#0}{1}", Math.Round(Answer, 2), " Dr");

                //return Answer < 0 ? String.Format("{0:N2} {1}", Math.Round((Answer * -1), 2)," Cr") : String.Format("{0:N2} {1}", Math.Round(Answer, 2)," Dr");
            }


            //return Microsoft.VisualBasic.Strings.Trim(ToString(Expression));
        }

        #endregion

        #region Form Events

        public void FormKeyDownEvent(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (((Form)sender).ActiveControl.GetType().FullName.ToString().IndexOf("UltraGrid") != -1 | ((Form)sender).ActiveControl.Parent.GetType().FullName.IndexOf("UltraGrid") != -1)
                {
                }
                else
                {
                    //  SendKeys.Send("{TAB}");
                }
            }
        }

        public void frmGenSet(Form pFrm)
        {
            Form Frm = pFrm;
            Frm.FormBorderStyle = FormBorderStyle.None;
            Frm.KeyPreview = true;
            Frm.Name = Frm.Name.ToUpper();
            Frm.StartPosition = FormStartPosition.CenterScreen;
            Frm.MaximizeBox = false;
            Frm.MinimizeBox = false;
            Frm.ControlBox = true;
            Frm.AutoScaleMode = AutoScaleMode.None;
            Frm.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        public void frmGenSetForPopup(Form pFrm)
        {
            Form Frm = pFrm;
            Frm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Frm.KeyPreview = true;
            Frm.Name = Frm.Name.ToUpper();
            Frm.StartPosition = FormStartPosition.CenterScreen;
            Frm.MaximizeBox = false;
            Frm.MinimizeBox = false;
            Frm.ControlBox = true;
            Frm.AutoScaleMode = AutoScaleMode.None;
        }

        public void frmResize(Form pFrm)
        {
            pFrm.WindowState = FormWindowState.Normal;
        }

        #endregion

        #region MessageBox

        //public void PrnMsg(string Str)
        //{
        //    Message(Str);
        //}

        public DialogResult Conf(string pStrDispMsg, string pStrMessageCaption)
        {
            return MessageBox.Show(pStrDispMsg, pStrMessageCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        public DialogResult Conf(string pStrDispMsg)
        {
            return MessageBox.Show(pStrDispMsg, BLL.GlobalDec.gStrMsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }


        public string InputBox(string pStrPrompt)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(pStrPrompt, "Remark", "", 300, 300);
        }

        //public void Message(string pStrMessage)
        //{
        //    MessageBox.Show(pStrMessage.ToString(), BLL.GlobalDec.gStrMsgTitle);
        //}

        //public void Message(string pStrMessage, string pStrMessageCaption)
        //{
        //    MessageBox.Show(pStrMessage.ToString(), pStrMessageCaption);
        //}

        //public void Message(string pStrMessage, string pStrMessageCaption, MessageBoxIcon pMsgBoxIcon)
        //{
        //    MessageBox.Show(pStrMessage.ToString(), pStrMessageCaption, MessageBoxButtons.OK, pMsgBoxIcon);
        //}

        //public void Message(string pStrMessage, string pStrMessageCaption, MessageBoxButtons pMsgBoxButton, MessageBoxIcon pMsgBoxIcon)
        //{
        //    MessageBox.Show(pStrMessage.ToString(), pStrMessageCaption, pMsgBoxButton, pMsgBoxIcon);
        //}

        public string Left(String pStr, int pLength)
        {
            if (pStr == null || pStr.Length == 0)
            {
                return "";
            }
            return Microsoft.VisualBasic.Strings.Left(pStr, pLength);
        }

        public string Right(String pStr, int pLength)
        {
            if (pStr == null || pStr.Length == 0)
            {
                return "";
            }
            return Microsoft.VisualBasic.Strings.Right(pStr, pLength);
        }


        #endregion

        #region Date Diff

        public double DateDiff(Microsoft.VisualBasic.DateInterval pDateInterval, string pStrStartDateTime, string pStrEndDateTime, bool pBoolIncludeSundays = true)
        {
            long Result = 0;
            try
            {
                if (pStrStartDateTime == "" || pStrEndDateTime == "")
                {
                    return 0;
                }
                DateTime StartDate = DateTime.Parse(pStrStartDateTime);
                DateTime EndDate = DateTime.Parse(pStrEndDateTime);

                if (pBoolIncludeSundays == true)
                {
                    Result = Microsoft.VisualBasic.DateAndTime.DateDiff(pDateInterval, StartDate, EndDate);
                }
                else
                {

                    double calcBusinessDays = 1 + ((EndDate - StartDate).TotalDays * 6 - (StartDate.DayOfWeek - EndDate.DayOfWeek) * 2) / 7;

                    if ((int)EndDate.DayOfWeek == 6) calcBusinessDays--;
                    if ((int)StartDate.DayOfWeek == 0) calcBusinessDays--;

                    return Val(Math.Round(calcBusinessDays, 0));
                }


            }
            catch
            {
                Result = -1;

            }
            return Val(Result);

            //try
            //{
            //    DateTime StartmDate = DateTime.Parse(pStrStartDateTime);
            //    DateTime EndDate = DateTime.Parse(pStrEndDateTime);

            //    TimeSpan Span = EndDate.Subtract(StartmDate);


            //    if (pDateInterval == Microsoft.VisualBasic.DateInterval.Minute)
            //    {
            //        return Span.TotalMinutes;
            //    }
            //    else if (pDateInterval == Microsoft.VisualBasic.DateInterval.Hour)
            //    {
            //        return Span.TotalHours;
            //    }
            //    else if (pDateInterval == Microsoft.VisualBasic.DateInterval.Second)
            //    {
            //        return Span.TotalSeconds;
            //    }
            //    else if (pDateInterval == Microsoft.VisualBasic.DateInterval.Day)
            //    {
            //        return Span.TotalDays;
            //    }
            //    else if (pDateInterval ==  Microsoft.VisualBasic.DateInterval.Month)
            //    {
            //        return Span.TotalDays / 12;
            //    }
            //    else if (pDateInterval == Microsoft.VisualBasic.DateInterval.Year)
            //    {
            //        return Span.TotalDays / 365;
            //    }

            //    else
            //        return 0;

            //}
            //catch
            //{
            //    return 0;
            //}
        }

        #endregion



    }
}
