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
    public partial class LabelControl : DevExpress.XtraEditors.LabelControl
    {
        private LabelType m_ModeType = LabelType.Normal;
        private event EventHandler LabelTypeChanged;

        public LabelControl()
        {
            InitializeComponent();
        }

        public enum LabelType
        {
            Normal = 1,
            AddMode = 2,
            EditMode = 3
        }

        public LabelType LabelMode
        {
            get
            {
                return m_ModeType;
            }
            set
            {
                m_ModeType = value;
                this.OnLabelTypeChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnLabelTypeChanged(EventArgs e)
        {
            if (LabelTypeChanged != null)
            {
                LabelTypeChanged(this, e);
            }

            if (this.m_ModeType == LabelType.AddMode)
            {
                this.ForeColor = Color.Red;
                this.Text = "Add Mode";
            }
            else if (this.m_ModeType == LabelType.EditMode)
            {
                this.ForeColor = Color.Blue;
                this.Text = "Edit Mode";
            }
            else
            {
                this.ForeColor = Color.Black;
            }
        }
    }
}
