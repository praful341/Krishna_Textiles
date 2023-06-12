using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class MaskedBox : TextBox
    {

        #region Data Member
        public enum TextBoxFunction
        {
            Allow_Numbers = 1,
            Allow_Characters = 2,
            Allow_AlphaNumerics = 3,
            Allow_EMails = 4,
            Allow_Dates = 5,
            Allow_AlphaNumericsExtended = 6
        }

        private byte m_Decimal;
        private string m_DateFormat;
        private decimal m_numMinValue;
        private decimal m_numMaxValue;
        private DateTime m_datMinDate;

        private DateTime m_datMaxDate;
        private Boolean m_blnCheckMinMaxBounds;
        private TextBoxFunction m_TextType = TextBoxFunction.Allow_AlphaNumerics;
        #endregion

        #region Properties
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                SetFormat();
            }
        }

        public TextBoxFunction TextBoxStyle
        {
            get { return m_TextType; }
            set { m_TextType = value; }
        }

        public byte DecimalPlaces
        {
            get { return m_Decimal; }
            set
            {
                m_Decimal = value;
                if (m_Decimal > 15)
                {
                    m_Decimal = 15;
                }
                else if (m_Decimal < 0)
                {
                    m_Decimal = 0;
                }
            }
        }

        public string DateFormat
        {
            get { return m_DateFormat; }
            set { m_DateFormat = value; }
        }

        public decimal MinValue
        {
            get { return m_numMinValue; }
            set { m_numMinValue = value; }
        }

        public decimal MaxValue
        {
            get { return m_numMaxValue; }
            set { m_numMaxValue = value; }
        }

        public bool CheckBounds
        {
            get { return m_blnCheckMinMaxBounds; }
            set { m_blnCheckMinMaxBounds = value; }
        }

        public System.DateTime MinDate
        {
            get { return m_datMinDate; }
            set { m_datMinDate = value; }
        }

        public System.DateTime MaxDate
        {
            get { return m_datMaxDate; }
            set { m_datMaxDate = value; }
        }
        #endregion

        #region Events
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            base.SelectAll();

            if (!this.ReadOnly)
            {
                base.BackColor = Color.LemonChiffon;
            }
        }

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyCode == Keys.T)
            {
                if (TextBoxStyle == TextBoxFunction.Allow_Dates)
                {
                    if (this.Enabled && !this.ReadOnly)
                    {
                        this.Text = DateTime.Now.ToString();
                    }
                }
            }
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            int numCode = (int)(e.KeyChar);
            if (numCode != 8)
            {
                if (TextBoxStyle == TextBoxFunction.Allow_Numbers)
                {
                    e.Handled = AllowNumbers(numCode);
                }
                else if (TextBoxStyle == TextBoxFunction.Allow_AlphaNumerics)
                {
                    e.Handled = AllowAlpha(numCode);
                }
                else if (TextBoxStyle == TextBoxFunction.Allow_Characters)
                {
                    e.Handled = AllowChr(numCode);
                }
                else if (TextBoxStyle == TextBoxFunction.Allow_EMails)
                {
                    e.Handled = AllowEmail(numCode);
                }
                else if (TextBoxStyle == TextBoxFunction.Allow_Dates)
                {
                    e.Handled = AllowDate(numCode);
                }
            }
        }

        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if ((e.KeyCode == Keys.C) && (e.Control))
            {
                Clipboard.SetText(this.SelectedText);
            }
            if ((e.KeyCode == Keys.V) && (e.Control))
            {
                this.SelectedText = Clipboard.GetText(TextDataFormat.Text);
            }
        }

        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            base.OnValidating(e);
            SendKeys.Flush();
            SetFormat();
            if (CheckBounds & TextBoxStyle == TextBoxFunction.Allow_Numbers)
            {
                if ((Convert.ToDecimal(Text) < MinValue) || (Convert.ToDecimal(Text) > MaxValue))
                {
                    MessageBox.Show("Value must be between " + MinValue.ToString().Trim() + " and " + MaxValue.ToString().Trim(), "Invalid Value.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification, false);
                    e.Cancel = true;
                }
            }
            else if (CheckBounds & TextBoxStyle == TextBoxFunction.Allow_Dates)
            {
                if (!((Text) == string.Empty))
                {
                    if (Convert.ToDateTime(Text) < MaxDate || Convert.ToDateTime(Text) > MinDate)
                    {
                        MessageBox.Show("Start date " + MaxDate + " - " + "End Date " + MinDate + "of a period for a financial year should fall in the range of dates specified for that financial year.", "dates specified", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification, false);
                        e.Cancel = true;
                    }
                    else if (Convert.ToDateTime(Text) > DateTime.Today.Date)
                    {
                        MessageBox.Show("Transaction date should be grather than current date " + Convert.ToDateTime(Text), "Invalid Date.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification, false);
                        e.Cancel = true;
                    }
                }
            }
            if (!this.ReadOnly)
            {
                this.BackColor = Color.White;
            }
            else
            {
                this.BackColor = Color.FromArgb(245, 245, 247);
            }
        }
        #endregion

        #region Function/Procedure

        private void SetFormat()
        {
            if (m_TextType == TextBoxFunction.Allow_Dates)
            {
                FormatAsDate();
            }
            else if (m_TextType == TextBoxFunction.Allow_Numbers)
            {
                FormatAsDecimal();
            }
            else if (m_TextType == TextBoxFunction.Allow_EMails)
            {
                CheckValidEmail();
            }
        }

        private void FormatAsDecimal()
        {
            //base.Text = Strings.FormatNumber(Conversion.Val(System.Text), m_Decimal, TriState.True, TriState.UseDefault, TriState.False);
            base.Text = string.Format(base.Text, m_Decimal, true);
        }

        private void FormatAsDate()
        {
            try
            {
                string strTemp = string.Empty;
                System.DateTime mydate = default(System.DateTime);

                if (!string.IsNullOrEmpty(base.Text))
                {
                    if (base.Text.Contains("/") == false && base.Text.Contains("-") == false)
                    {
                        string str = base.Text;
                        if (base.Text.Length <= 2)
                        {
                            strTemp = base.Text + "/" + (DateTime.Today.Month) + "/" + (DateTime.Today.Year);
                        }
                        else if (base.Text.Length <= 4)
                        {
                            // strTemp = Strings.Left(base.Text, 2) + "/" + Strings.Right(base.Text, base.Text.Length - 2) + "/" + (DateTime.Today);
                            strTemp = Left(base.Text, 2) + "/" + Right(base.Text, base.Text.Length - 2) + "/" + (DateTime.Today.Year);
                        }
                        else if (base.Text.Length <= 6 || base.Text.Length == 8)
                        {
                            //  strTemp = Strings.Left(base.Text, 2) + "/" + Strings.Mid(base.Text, 3, 2) + "/" + Strings.Right(base.Text, base.Text.Length - 4);
                            strTemp = Left(base.Text, 2) + "/" + Mid(base.Text, 2, 2) + "/" + Right(base.Text, base.Text.Length - 4);
                        }

                        if (strTemp != string.Empty)
                            base.Text = strTemp;

                        if (IsDate(strTemp))
                        {
                            mydate = Convert.ToDateTime(strTemp);
                            strTemp = mydate.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            this.Focus();
                            return;
                        }
                    }
                    else
                    {
                        string[] dtSpt = null;
                        if (base.Text.Contains("/"))
                        {
                            dtSpt = base.Text.Split('/');
                        }
                        else
                        {
                            dtSpt = base.Text.Split('-');
                        }

                        switch (dtSpt.Length)
                        {
                            case 2:
                                // Month and day are given
                                mydate = Convert.ToDateTime(dtSpt[0] + "/" + dtSpt[1] + "/" + (DateTime.Today));
                                break;
                            case 3:
                                // month and day are given
                                // check if year is given
                                if (string.IsNullOrEmpty(dtSpt[2]))
                                {
                                    // if not append year of system date.
                                    mydate = Convert.ToDateTime(dtSpt[0] + "/" + dtSpt[1] + "/" + (DateTime.Today));
                                    strTemp = mydate.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    mydate = Convert.ToDateTime(dtSpt[0] + "/" + dtSpt[1] + "/" + dtSpt[2]);
                                    strTemp = mydate.ToString("dd/MM/yyyy");
                                }

                                break;
                            default:
                                this.Focus();
                                return;
                        }
                    }

                    if (string.IsNullOrEmpty(m_DateFormat))
                    {
                        //base.Text = String.Format("dd/MM/yyyy", mydate);
                        base.Text = DateTime.ParseExact(strTemp, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        base.Text = String.Format(m_DateFormat, mydate);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Focus();
            }
        }

        private void CheckValidEmail()
        {
            if (base.Text.Trim() == string.Empty)
            {
                return;
            }

            bool blnInvalid = false;

            base.Text = base.Text.Trim();

            try
            {
                int numAtPosition = 0;

                if (base.Text.StartsWith("@") || base.Text.StartsWith(".") || base.Text.StartsWith("-") || base.Text.StartsWith("_"))
                {
                    // address begins with @ or - or . or _
                    blnInvalid = true;
                }
                else if (base.Text.EndsWith("@") || base.Text.EndsWith(".") || base.Text.EndsWith("-") || base.Text.EndsWith("_"))
                {
                    // address ends with @ or - or . or _
                    blnInvalid = true;
                }
                else
                {
                    if (!base.Text.Contains("@"))
                    {
                        // address does not have @ sign
                        blnInvalid = true;
                    }
                    else
                    {
                        if (base.Text.IndexOf("@") != base.Text.LastIndexOf("@"))
                        {
                            // address has multiple at signs
                            blnInvalid = true;
                        }
                        else
                        {
                            numAtPosition = base.Text.IndexOf("@");
                            string numCharBeforeAt = base.Text.Substring(numAtPosition - 1, 1);
                            string numCharAfterAt = base.Text.Substring(numAtPosition + 1, 1);

                            if (numCharAfterAt == "." || numCharAfterAt == "-" || numCharAfterAt == "_")
                            {
                                // character after @ sign cannot be . or - or _
                                blnInvalid = true;
                            }
                            else
                            {
                                if (numCharBeforeAt == "." || numCharBeforeAt == "-" || numCharBeforeAt == "_")
                                {
                                    // character before @ sign cannot be . or - or _
                                    blnInvalid = true;
                                }
                                else
                                {
                                    if (base.Text.IndexOf(".", numAtPosition) == -1)
                                    {
                                        // no . after @ sign
                                        blnInvalid = true;
                                    }
                                    else
                                    {
                                        int numCounter = 0;

                                        for (numCounter = numAtPosition + 1; numCounter <= (base.Text.Length) - 1; numCounter++)
                                        {
                                            if (base.Text.Substring(numCounter, 1) == "." || base.Text.Substring(numCounter, 1) == "_" || base.Text.Substring(numCounter, 1) == "-")
                                            {
                                                if (base.Text.Substring(numCounter + 1, 1) == "." || base.Text.Substring(numCounter + 1, 1) == "_" || base.Text.Substring(numCounter + 1, 1) == "-")
                                                {
                                                    // successive . or - or _ found after atsign
                                                    blnInvalid = true;
                                                    break; // TODO: might not be correct. Was : Exit For
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                if (blnInvalid)
                {
                    this.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Focus();
            }
        }

        public bool IsDate(string InputDate)
        {
            bool isdate = true;
            try
            {
                DateTime dt = DateTime.Parse(InputDate);
            }
            catch
            {

                isdate = false;
            }
            return isdate;
        }

        private bool IsNumber(int p_KeyCode)
        {
            if ((p_KeyCode >= 48 && p_KeyCode <= 57))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsCharacter(int p_KeyCode)
        {
            if ((p_KeyCode >= 65 && p_KeyCode <= 90) || (p_KeyCode >= 97 && p_KeyCode <= 122))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool AllowAlpha(int p_KeyCode)
        {
            bool functionReturnValue = false;
            if ((p_KeyCode >= 32 && p_KeyCode <= 126) || p_KeyCode == 8)
            {
                functionReturnValue = false;
            }
            else
            {
                functionReturnValue = true;
            }
            return functionReturnValue;
        }

        private bool AllowNumbers(int p_KeyCode)
        {
            bool functionReturnValue = false;
            if (IsNumber(p_KeyCode) || p_KeyCode == 43 || p_KeyCode == 45 || p_KeyCode == 46)
            {
                functionReturnValue = false;
            }
            else
            {
                functionReturnValue = true;
            }
            return functionReturnValue;
        }

        private bool AllowChr(int p_KeyCode)
        {
            bool functionReturnValue = false;
            if (IsCharacter(p_KeyCode) || p_KeyCode == 32)
            {
                functionReturnValue = false;
            }
            else
            {
                functionReturnValue = true;
            }
            return functionReturnValue;
        }

        private bool AllowDate(int p_KeyCode)
        {
            if (IsNumber(p_KeyCode) || p_KeyCode == 47 || p_KeyCode == 45 || p_KeyCode == 58)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool AllowEmail(int p_KeyCode)
        {
            bool functionReturnValue = false;
            if (IsCharacter(p_KeyCode) || IsNumber(p_KeyCode) || p_KeyCode == 45 || p_KeyCode == 46 || p_KeyCode == 64 || p_KeyCode == 95)
            {
                functionReturnValue = false;
            }
            else
            {
                functionReturnValue = true;
            }
            return functionReturnValue;
        }

        public static string Left(string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }

        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = param.Substring(param.Length - length, length);
            //return the result of the operation
            return result;
        }

        public static string Mid(string param, int startIndex, int length)
        {
            //start at the specified index in the string ang get N number of
            //characters depending on the lenght and assign it to a variable
            string result = param.Substring(startIndex, length);
            //return the result of the operation
            return result;
        }

        public static string Mid(string param, int startIndex)
        {
            //start at the specified index and return all characters after it
            //and assign it to a variable
            string result = param.Substring(startIndex);
            //return the result of the operation
            return result;
        }

        #endregion
    }
}
