using System.Data;
using System.Windows.Forms;

namespace Account_Management.Class
{
    public class FrmSearchProperty
    {
        private DataTable _dtTable;
        public DataTable dtTable
        {
            get { return _dtTable; }
            set { _dtTable = value; }
        }


        private DataSet _dataSet;

        public DataSet dataSet
        {
            get { return _dataSet; }
            set { _dataSet = value; }
        }


        private string _SearchField;
        public string SearchField
        {
            get { return _SearchField; }
            set { _SearchField = value; }
        }

        // Add : 21-05-2014 : Narendra
        private string _SearchText;
        public string SearchText
        {
            get { return _SearchText; }
            set { _SearchText = value; }
        }
        //----------------------------

        private DataGridViewRow _dtrow;

        public DataGridViewRow dtrow
        {
            get { return _dtrow; }
            set { _dtrow = value; }
        }

        private bool _FlagEsc;
        public bool FlagEsc
        {
            get { return _FlagEsc; }
            set { _FlagEsc = value; }
        }

        private System.ComponentModel.ListSortDirection _SearchOrder;
        public System.ComponentModel.ListSortDirection SearchOrder
        {
            get { return _SearchOrder; }
            set { _SearchOrder = value; }
        }

        public FrmSearchProperty()
        {
            _SearchOrder = System.ComponentModel.ListSortDirection.Ascending;
        }
    }
}
