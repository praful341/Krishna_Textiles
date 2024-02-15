using System;
using System.Data;
using System.Windows.Forms;

namespace Account_Management.UserControls
{
    public partial class RPTMultiSelect : UserControl
    {
        public RPTMultiSelect()
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


                //ListFrom.Co.Clear();
                //ListTo.Columns.Clear();

                if (DTab == null)
                {
                    return;
                }

                ListFrom.ColumnWidth = ListFrom.Width;
                ListTo.ColumnWidth = ListTo.Width;

                foreach (DataRow DRow in _DTab.Rows)
                {
                    ListViewItem ListViewItem = new ListViewItem();
                    ListViewItem.Text = DRow["COLUMN_NAME"].ToString().ToUpper();
                    ListViewItem.Tag = DRow["FIELD_NAME"].ToString().ToUpper();
                    ListFrom.Items.Add(ListViewItem);

                    //if (DRow["IS_GROUP"].ToString() == "1")
                    //{
                    //    ListViewItem = new ListViewItem();
                    //ListViewItem ListViewItem = new ListViewItem();
                    //    ListViewItem.Text = DRow["COLUMN_NAME"].ToString().ToUpper();
                    //    ListViewItem.Tag = DRow["FIELD_NAME"].ToString();
                    //     ListFrom.Items.Add(ListViewItem);
                    //ListFrom.Items.Add(new ListViewItem() { Text = DRow["COLUMN_NAME"].ToString().ToUpper(),Tag = DRow["FIELD_NAME"].ToString() });
                    //}
                }
            }
        }

        public void RemoveRows(string StrItem)
        {
            foreach (ListViewItem Item in ListFrom.Items)
            {
                if (Item.Tag.ToString().Contains(StrItem))
                {
                    ListFrom.Items.Remove(Item);
                }
            }
        }

        public string GetTextValue
        {
            get
            {

                string StrValue = "";
                foreach (ListViewItem Item in ListTo.Items)
                {
                    StrValue = StrValue + Item.Text.ToString() + ",";
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

                string StrValue = "";
                foreach (ListViewItem Item in ListTo.Items)
                {
                    StrValue = StrValue + Item.Tag.ToString() + ",";
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
                if (Default == null)
                {
                    return;
                }
                string[] StrSplit = Default.Split(',');

                for (int IntI = 0; IntI < StrSplit.Length; IntI++)
                {
                    foreach (ListViewItem iTem in ListFrom.Items)
                    {
                        if (iTem.Text.ToUpper() == StrSplit[IntI].ToUpper() || iTem.Tag.ToString().ToUpper() == StrSplit[IntI].ToUpper())
                        {
                            iTem.Selected = true;
                            BtnFW_Click(null, null);
                            break;
                        }
                    }
                }
            }
        }

        private void BtnFW_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem iTem in ListFrom.SelectedItems)
            {
                ListViewItem ToITem = new ListViewItem();
                ToITem.Text = iTem.Text;
                ToITem.Tag = iTem.Tag;

                bool ISExists = false;
                foreach (ListViewItem iTem2 in ListTo.Items)
                {
                    if (ToITem.Text == iTem2.Text)
                    {
                        ISExists = true;
                        break;
                    }
                }
                if (ISExists == false)
                {
                    ListTo.Items.Add(ToITem);
                }
            }
        }

        private void BtnBW_Click(object sender, EventArgs e)
        {
            //foreach (int iTem in ListTo.SelectedIndices)
            //{
            //ListViewItem FromITem = new ListViewItem();
            //FromITem.Text = iTem.Text;
            if (ListTo.SelectedItem != null)
                ListTo.Items.Remove(ListTo.Items[ListTo.SelectedIndex]);
            //ListFrom.Items.Add(FromITem);
            //}
        }

        private void BtnUP_Click(object sender, EventArgs e)
        {
            if (ListTo.SelectedItems.Count == 0)
            {
                return;
            }
            var currentIndex = ListTo.SelectedIndex;
            var item = ListTo.SelectedItems[0];
            if (currentIndex > 0)
            {
                ListTo.Items.RemoveAt(currentIndex);
                ListTo.Items.Insert(currentIndex - 1, item);
            }
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            if (ListTo.SelectedItems.Count == 0)
            {
                return;
            }
            var currentIndex = ListTo.SelectedIndex;
            var item = ListTo.SelectedItems[0];
            if (currentIndex < ListTo.Items.Count - 1)
            {
                ListTo.Items.RemoveAt(currentIndex);
                ListTo.Items.Insert(currentIndex + 1, item);
            }
        }

        private void ListFrom_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BtnFW_Click(sender, null);
        }

        private void ListTo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BtnBW_Click(sender, null);
        }
    }
}
