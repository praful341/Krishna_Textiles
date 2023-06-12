using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class MemoEdit : DevExpress.XtraEditors.MemoEdit
    {
        #region Data Members
        private bool m_blnAllowCommaSeperator;
        #endregion

        #region Constructor
        public MemoEdit()
        {
            InitializeComponent();

            base.Properties.AppearanceReadOnly.BackColor = Color.FromArgb(245, 245, 247);
        }
        #endregion

        #region Properties
        public bool AllowCommaSeperator
        {
            get { return m_blnAllowCommaSeperator; }
            set { m_blnAllowCommaSeperator = value; }
        }
        #endregion

        #region Events
        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
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
        }

        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyUp(e);

            //if ((e.KeyCode == Keys.C) && (e.Control))
            //{
            //    Clipboard.SetText(this.SelectedText);
            //}

            //if ((e.KeyCode == Keys.V) && (e.Control))
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
                base.BackColor = Color.FromArgb(245, 245, 247);
            }
        }
        #endregion

        #region Procedures/Functions

        #endregion
    }
}
