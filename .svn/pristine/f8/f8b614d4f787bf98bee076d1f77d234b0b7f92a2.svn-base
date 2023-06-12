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
    public partial class CheckEdit : DevExpress.XtraEditors.CheckEdit
    {
        #region Data Members

        #endregion

        #region Constructor
        public CheckEdit()
        {
            InitializeComponent();
            base.Properties.AppearanceReadOnly.BackColor = Color.FromArgb(245, 245, 247);
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

        #region Procedures / Functions

        #endregion
    }
}
