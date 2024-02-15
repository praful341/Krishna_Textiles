using Account_Management.Class;
using System;
using System.Windows.Forms;

namespace Account_Management.Search
{
    public partial class FrmExpressionEditor : DevExpress.XtraEditors.XtraForm
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();

        #region Property Settings

        private string _FieldName;

        public string FieldName
        {
            get { return _FieldName; }
            set { _FieldName = value; }
        }

        private string _Expression;

        public string Expression
        {
            get { return _Expression; }
            set { _Expression = value; }
        }


        private string _Default_Expression;

        public string Default_Expression
        {
            get { return _Default_Expression; }
            set { _Default_Expression = value; }
        }
        #endregion

        #region Constructor

        public FrmExpressionEditor()
        {
            InitializeComponent();
        }

        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        private void FrmExpressionEditor_Load(object sender, EventArgs e)
        {
            FillControl();
        }
        #endregion

        #region Events

        private void FrmExpressionEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FrmExpressionEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                lblClose_Click(null, null);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton BtnClick = (DevExpress.XtraEditors.SimpleButton)sender;
            SetText(BtnClick.Text);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListField_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListField.SelectedItems.Count != 0)
            {
                SetText(ListField.SelectedItems[0].Text);
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Operation

        public void FillControl()
        {
            txtExpression.Text = Default_Expression;

            if (ListField.Columns.Count == 0)
            {
                ListField.SetBounds(500, 2000, Val.ToInt(100), Val.ToInt(200));
            }
            foreach (string str in FieldName.Split(','))
            {
                if (str != "")
                {
                    ListViewItem ListViewItem = new ListViewItem();
                    ListViewItem.Text = "[" + str + "]";
                    ListViewItem.Tag = str;
                    ListField.Items.Add(ListViewItem);
                }
            }
        }
        public void SetText(string Str)
        {
            try
            {
                if (Str == "IIF")
                {
                    txtExpression.Text = txtExpression.Text.Insert(txtExpression.SelectionStart, "IIF ( condition ,true, false )");
                    txtExpression.Focus();
                }
                else
                {
                    txtExpression.Text = txtExpression.Text.Insert(txtExpression.SelectionStart, Str);
                    txtExpression.Focus();
                }
            }
            catch (Exception Ex)
            {
                Global.Message(Ex.Message);
            }
        }
        #endregion        
    }
}
