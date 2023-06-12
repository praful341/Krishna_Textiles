using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Mask;

namespace CustomControls
{
    public partial class TextEdit : DevExpress.XtraEditors.TextEdit
    {
        #region Data Members
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
        private System.DateTime m_datMinDate;
        private System.DateTime m_datMaxDate;
        private bool m_blnCheckMinMaxBounds;
        private TextBoxFunction m_TextType = TextBoxFunction.Allow_AlphaNumerics;
        private bool m_blnAllowCommaSeperator;
        private bool m_blnAllowDeSelectText;
        #endregion

        #region Constructor
        public TextEdit()
        {
            InitializeComponent();

            m_blnAllowDeSelectText = false;
            base.Properties.AppearanceReadOnly.BackColor = Color.FromArgb(245, 245, 247);
        }
        #endregion

        #region Properties
        public bool AllowCommaSeperator
        {
            get { return m_blnAllowCommaSeperator; }
            set { m_blnAllowCommaSeperator = value; }
        }
        public bool AllowDeSelectText
        {
            get { return m_blnAllowDeSelectText; }
            set { m_blnAllowDeSelectText = value; }
        }
        #endregion

        #region Events
        protected override void InitLayout()
        {
            base.InitLayout();

            if (base.Properties.Mask.MaskType == DevExpress.XtraEditors.Mask.MaskType.Numeric)
            {
                base.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            if (!m_blnAllowDeSelectText)
                base.SelectAll();

            if (!base.Properties.ReadOnly)
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
            else if (e.KeyCode == Keys.Back)
            {
                if (this.Properties.Mask.MaskType == MaskType.DateTime)
                {
                    e.SuppressKeyPress = true;

                    if (this.Enabled && this.Properties.ReadOnly == false)
                    {
                        this.Text = null;
                    }
                }
            }
            else if (e.KeyCode == Keys.T)
            {
                if (this.Properties.Mask.MaskType == MaskType.DateTime)
                {
                    if (this.Enabled && this.Properties.ReadOnly == false)
                    {
                        this.EditValue = DateTime.Now;
                    }
                }
            }
        }

        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyUp(e);

            //if ((e.KeyCode == Keys.C) & (e.Control))
            //{
            //    Clipboard.SetText(this.SelectedText);
            //}

            //if ((e.KeyCode == Keys.V) & (e.Control) & !this.Properties.ReadOnly)
            //{
            //    this.SelectedText = Clipboard.GetText(TextDataFormat.Text);
            //}
            if (base.Enabled && base.Properties.ReadOnly == false)
            {
                if (e.Control && e.KeyCode == Keys.V)
                {
                    if (m_blnAllowCommaSeperator)
                    {
                        IDataObject clipData = Clipboard.GetDataObject();
                        String Data = clipData.GetData(System.Windows.Forms.DataFormats.Text).ToString();
                        String str1 = Data.Replace("\r\n", ",");
                        str1 = str1.Trim();
                        str1 = str1.TrimEnd();
                        str1 = str1.TrimStart();
                        str1 = str1.TrimEnd(',');
                        str1 = str1.TrimStart(',');
                        base.Text = str1;
                    }
                }
            }
        }

        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            base.OnValidating(e);
            SendKeys.Flush();

            if (!base.Properties.ReadOnly)
            {
                base.BackColor = Color.White;
            }
            else
            {
                base.BackColor = Color.FromArgb(255, 247, 245, 241);
            }
        }

        protected override void OnSpin(DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            //MyBase.OnSpin(e)
            e.Handled = false;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            SendKeys.Flush();

            if (base.Enabled)
            {
                base.BackColor = Color.White;
            }
            else
            {
                base.BackColor = Color.FromArgb(255, 235, 231, 220);
            }
        }
        #endregion

        #region Procedures / Functions

        #endregion
    }
}
