using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BLL
{
    public partial class frmErrorList : DevExpress.XtraEditors.XtraForm
    {

        #region " Data Members "
        private static SqlConnection m_cnnLSSales;
        private List<ListError> m_lstErrorList;
        int a, b;
        bool m_IsblnForExpNotification = false;
        Point newPoint = new Point();
        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        #endregion

        #region " Constructer "
        public frmErrorList()
        {
            InitializeComponent();
        }

        public frmErrorList(List<ListError> p_lstErrorList)
        {
            InitializeComponent();

            m_lstErrorList = p_lstErrorList;
        }

        public frmErrorList(List<ListError> p_lstErrorList, bool p_IsblnForExpNotification, ref SqlConnection p_cnnLSSales)
        {
            InitializeComponent();

            m_cnnLSSales = p_cnnLSSales;
            m_lstErrorList = p_lstErrorList;
            m_IsblnForExpNotification = p_IsblnForExpNotification;
        }

        public frmErrorList(ListError p_objError)
        {
            InitializeComponent();
            m_lstErrorList = new List<ListError>();
            m_lstErrorList.Add(p_objError);
        }
        #endregion

        #region " Event Handle "
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pcbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmErrorList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                this.Close();
            }
        }
        private void frmErrorList_Load(object sender, EventArgs e)
        {
            if (m_IsblnForExpNotification)
                lblTitle.Text = " NOTIFICATION MESSAGE";
            else
                lblTitle.Text = "  MESSAGE / ERROR LIST";

            gridDetails.DataSource = m_lstErrorList;
        }
        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            a = Control.MousePosition.X - this.Location.X;
            b = Control.MousePosition.Y - this.Location.Y;
        }
        private void lblTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                newPoint = System.Windows.Forms.Control.MousePosition;
                newPoint.X = newPoint.X - a;
                newPoint.Y = newPoint.Y - b;
                this.Location = newPoint;
            }
        }
        private void lblResize_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.SetBounds(this.Location.X, this.Location.Y, (System.Windows.Forms.Control.MousePosition.X - (this.Left)) + 10, (System.Windows.Forms.Control.MousePosition.Y - this.Top) + 10);
                this.Refresh();
            }
        }
        #endregion
    }
}