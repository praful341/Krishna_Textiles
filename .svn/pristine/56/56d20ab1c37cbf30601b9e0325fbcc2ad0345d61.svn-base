using System;
using System.Data;
using System.Linq;

namespace Krishna_Textiles.UserControls
{
    public partial class ContReportGroupSelectDev : DevExpress.XtraEditors.XtraUserControl
    {
        public ContReportGroupSelectDev()
        {
            InitializeComponent();
        }

        private DataTable _DTab = new DataTable();

        public DataTable DTab
        {
            get { return _DTab; }
            set
            {
                _DTab = value;

                if (_DTab == null)
                {
                    return;
                }

                ListTo.Items.Clear();
                ListFrom.Items.Clear();

                if (DTab == null)
                {
                    return;
                }
                else
                {
                    //-----------Praful-------------Start

                    //DTab = DTab.AsEnumerable().Where(m => m.Field<decimal?>("IS_GROUP").ToString() == "1").CopyToDataTable();

                    //-----------Praful-------------End
                }

                //-----------Praful-------------Start
                if (DTab.AsEnumerable().Where(m => m.Field<bool?>("is_group") == true).Count() > 0)
                {
                    ListFrom.DisplayMember = "column_name";
                    ListFrom.ValueMember = "field_name";
                    ListFrom.DataSource = DTab.AsEnumerable().Where(m => m.Field<bool?>("is_group") == true).CopyToDataTable();

                    ListTo.DisplayMember = "column_name";
                    ListTo.ValueMember = "field_name";
                    ListTo.DataSource = DTab.Clone();
                }
                else
                {
                    ListFrom.DisplayMember = "column_name";
                    ListFrom.ValueMember = "field_name";
                    ListFrom.DataSource = null;

                    ListTo.DisplayMember = "column_name";
                    ListTo.ValueMember = "field_name";
                    ListTo.DataSource = null;
                }
                //-----------Praful-------------End
            }
        }

        public void RemoveRows(string StrItem)
        {
            DataTable dt_From = (DataTable)ListFrom.DataSource;

            int row_count = ListFrom.SelectedItems.Count - 1;

            for (int i = row_count; i >= 0; i--)
            {
                if (dt_From.Rows[i]["field_name"].ToString().Contains(StrItem))
                {
                    DataRow dr_New = dt_From.NewRow();
                    dr_New["field_name"] = StrItem;
                    dt_From.Rows.Add(dr_New);
                }
            }
        }

        public string GetTextValue
        {
            get
            {
                DataTable dt_ListTo = ((DataTable)ListTo.DataSource);
                string StrValue = "";
                if (dt_ListTo != null)
                {
                    foreach (DataRow Item in dt_ListTo.Rows)
                    {
                        StrValue = StrValue + Item["column_name"].ToString() + ",";
                    }
                }
                if (StrValue != "")
                {
                    StrValue = StrValue.Substring(0, StrValue.Length - 1);
                }
                return StrValue;
            }
        }

        public string GetTagValue
        {
            get
            {
                DataTable dt_ListTo = ((DataTable)ListTo.DataSource);
                string StrValue = "";
                if (dt_ListTo != null)
                {
                    foreach (DataRow Item in dt_ListTo.Rows)
                    {
                        StrValue = StrValue + Item["field_name"].ToString() + ",";
                    }
                }
                if (StrValue != "")
                {
                    StrValue = StrValue.Substring(0, StrValue.Length - 1);
                }
                return StrValue;
            }
        }


        private string _Default;

        public string Default
        {
            get { return _Default; }
            set
            {
                _Default = value;
                if (Default == null || Default == "")
                {
                    return;
                }
                DataTable dt_ListFrom = (DataTable)ListFrom.DataSource;
                string[] StrSplit = Default.Split(',');

                int cnt = 0;

                if (dt_ListFrom != null)
                {
                    if (dt_ListFrom.Rows.Count > 0)
                    {
                        for (int IntI = 0; IntI < StrSplit.Length; IntI++)
                        {
                            cnt = 0;

                            foreach (DataRow iTem in dt_ListFrom.Rows)
                            {
                                if (iTem["field_name"].ToString().ToUpper() == StrSplit[IntI].ToUpper() || iTem["column_name"].ToString().ToUpper() == StrSplit[IntI].ToUpper())
                                {
                                    ListFrom.SelectedIndex = cnt;
                                    MoveRight_Click(null, null);
                                    break;
                                }
                                cnt++;
                            }
                        }
                    }
                }

            }
        }

        private void MoveRight_Click(object sender, EventArgs e)
        {

            DataTable dt_From = (DataTable)ListFrom.DataSource;

            int row_count = ListFrom.SelectedItems.Count - 1;

            for (int i = row_count; i >= 0; i--)
            {
                bool ISExists = false;

                foreach (DataRowView iTem2 in ListTo.Items)
                {
                    if (((DataRowView)ListFrom.SelectedItems[i]).Row["field_name"] == iTem2.Row["field_name"])
                    {
                        ISExists = true;
                        break;
                    }
                }
                if (ISExists == false)
                {
                    ((DataTable)ListTo.DataSource).Rows.Add(((DataRowView)ListFrom.SelectedItems[i]).Row.ItemArray);
                    (dt_From).Rows.Remove(((DataRowView)ListFrom.SelectedItems[i]).Row);
                }
            }

            ListFrom.DataSource = dt_From;
            ListFrom.Refresh();
        }

        private void MoveLeft_Click(object sender, EventArgs e)
        {

            DataTable dt_To = (DataTable)ListTo.DataSource;

            int row_count = ListTo.SelectedItems.Count - 1;

            for (int i = row_count; i >= 0; i--)
            {
                bool ISExists = false;

                foreach (DataRowView iTem2 in ListFrom.Items)
                {
                    if (((DataRowView)ListTo.SelectedItems[i]).Row["field_name"] == iTem2.Row["field_name"])
                    {
                        ISExists = true;
                        break;
                    }
                }
                if (ISExists == false)
                {
                    ((DataTable)ListFrom.DataSource).Rows.Add(((DataRowView)ListTo.SelectedItems[i]).Row.ItemArray);
                    (dt_To).Rows.Remove(((DataRowView)ListTo.SelectedItems[i]).Row);
                }
            }

            ListTo.DataSource = dt_To;
            ListTo.Refresh();
        }

        private void MoveUp_Click(object sender, EventArgs e)
        {
            DataTable dt_To = (DataTable)ListTo.DataSource;

            if (ListTo.SelectedItems.Count == 0)
            {
                return;
            }
            var currentIndex = ListTo.SelectedIndex;
            DataRow dr_Sel = dt_To.NewRow();

            dr_Sel.ItemArray = dt_To.Rows[currentIndex].ItemArray;

            if (currentIndex > 0)
            {
                dt_To.Rows.InsertAt(dr_Sel, currentIndex - 1);
                dt_To.Rows.RemoveAt(currentIndex + 1);
                ListTo.SelectedIndex = currentIndex - 1;
            }
            else if (currentIndex == 0)
            {
                dt_To.Rows.InsertAt(dr_Sel, dt_To.Rows.Count + 1);
                dt_To.Rows.RemoveAt(currentIndex);
                ListTo.SelectedIndex = dt_To.Rows.Count;
            }
        }

        private void MoveDown_Click(object sender, EventArgs e)
        {
            DataTable dt_To = (DataTable)ListTo.DataSource;

            if (ListTo.SelectedItems.Count == 0)
            {
                return;
            }
            var currentIndex = ListTo.SelectedIndex;
            DataRow dr_Sel = dt_To.NewRow();

            dr_Sel.ItemArray = dt_To.Rows[currentIndex].ItemArray;

            if (currentIndex < dt_To.Rows.Count - 1)
            {
                dt_To.Rows.InsertAt(dr_Sel, currentIndex + 2);
                dt_To.Rows.RemoveAt(currentIndex);
                ListTo.SelectedIndex = currentIndex + 1;
            }
            else if (currentIndex == dt_To.Rows.Count - 1)
            {
                dt_To.Rows.InsertAt(dr_Sel, 0);
                dt_To.Rows.RemoveAt(currentIndex + 1);
                ListTo.SelectedIndex = 0;
            }
        }

        private void ListFrom_DoubleClick(object sender, EventArgs e)
        {
            MoveRight_Click(sender, null);
        }

        private void ListTo_DoubleClick(object sender, EventArgs e)
        {
            MoveLeft_Click(sender, null);
        }
    }
}
