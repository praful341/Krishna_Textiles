using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CustomControls
{
    public partial class LookUpEdit : DevExpress.XtraEditors.LookUpEdit
    {

        #region Data Members
        private bool m_ShowAutoPopup = true;
        #endregion

        #region Properties
        public bool ShowAutoPopup
        {
            get
            {
                return m_ShowAutoPopup;
            }
            set
            {
                m_ShowAutoPopup = value;
            }
        }
        #endregion

        #region Constructor
        public LookUpEdit()
        {
            InitializeComponent();

            base.Properties.AppearanceReadOnly.BackColor = Color.FromArgb(245, 245, 247);
            base.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            m_ShowAutoPopup = true;
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
            else if (e.KeyData == Keys.Delete)
            {
                base.CancelPopup();
                base.EditValue = System.DBNull.Value;
                e.Handled = true;
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

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (m_ShowAutoPopup)
            {
                base.ShowPopup();
            }
        }
        #endregion

        #region Procedures / Functions

        #endregion
    }
}
