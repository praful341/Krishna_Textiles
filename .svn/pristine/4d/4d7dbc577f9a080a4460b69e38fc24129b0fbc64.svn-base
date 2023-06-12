using Krishna_Textiles.Class;
using DevExpress.XtraGrid;
using System;
using System.Data;
using System.Windows.Forms;

namespace Krishna_Textiles.Search
{
    public partial class FrmSearchNew : DevExpress.XtraEditors.XtraForm
    {
        BLL.Validation Val = new BLL.Validation();
        public DataTable DTab;
        public string ColumnsToHide = "";
        public string ColumnsToVisible = "";
        public bool AllowMultiSelect = false;
        public string ColumnHeaderCaptions = "";
        public string SearchText = "";
        public string SearchField = "";
        public string ValueMember = "";
        public string SelectedValue = "";
        public string SummaryColumn = "";
        public DataRow DRow { get; set; }

        public FrmSearchNew()
        {
            InitializeComponent();
        }
        private void FrmSearch_Load(object sender, EventArgs e)
        {
            try
            {
                ChkAll.Visible = false;

                if (AllowMultiSelect == true)
                {
                    ChkAll.Visible = true;
                    if (DTab.Columns.Contains("SEL") == false)
                    {
                        DTab.Columns.Add(new DataColumn("SEL", typeof(bool)));
                    }
                    DTab.Columns["SEL"].SetOrdinal(0);
                }

                MainGrid.DataSource = DTab;
                MainGrid.Refresh();

                foreach (DevExpress.XtraGrid.Columns.GridColumn Col in GrdDet.Columns)
                {
                    if (Col.FieldName.ToUpper() == "SEL")
                    {
                        Col.OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        Col.OptionsColumn.AllowEdit = false;
                    }
                }
                string[] split = ColumnHeaderCaptions.Split(',');
                for (int IntI = 0; IntI < split.Length; IntI++)
                {
                    if (split[IntI] == "")
                    {
                        continue;
                    }
                    string[] ColSplit = split[IntI].Split('=');
                    GrdDet.Columns[ColSplit[0]].Caption = ColSplit[1];
                }

                if (ColumnsToHide.Length != 0)
                {
                    foreach (DevExpress.XtraGrid.Columns.GridColumn Column in this.GrdDet.Columns)
                    {
                        string[] splitColumnHide = ColumnsToHide.Split(',');


                        for (int IntI = 0; IntI < splitColumnHide.Length; IntI++)
                        {
                            if (splitColumnHide[IntI].ToUpper() == Column.FieldName.ToString().ToUpper())
                            {
                                Column.Visible = false;
                            }
                        }
                    }
                }
                else if (ColumnsToVisible.Length != 0)
                {
                    foreach (DevExpress.XtraGrid.Columns.GridColumn Column in this.GrdDet.Columns)
                    {
                        Column.Visible = false;

                        string[] splitColumnVisible = ColumnsToVisible.Split(',');

                        for (int IntI = 0; IntI < splitColumnVisible.Length; IntI++)
                        {
                            if (splitColumnVisible[IntI].ToUpper() == Column.FieldName.ToString().ToUpper())
                            {
                                Column.Visible = true;
                            }
                        }
                    }
                }
                GrdDet.BestFitColumns();
                CustomSummary(GrdDet);
                txtSeach.Text = SearchText;
                txtSeach.SelectionStart = txtSeach.Text.Length;
                txtSeach.SelectionLength = 0;
                txtSeach.DeselectAll();
                txtSeach.Focus();
            }
            catch (Exception ex)
            {
                Global.ErrorMessage(ex.Message);
            }
        }
        public void CustomSummary(DevExpress.XtraGrid.Views.Grid.GridView GrdDet)
        {
            try
            {
                if (SummaryColumn == null)
                    return;
                if (SummaryColumn == "")
                    return;
                String[] StrColumn = SummaryColumn.Split(',');
                String StrC = "'XYZ'";
                foreach (String Str in StrColumn)
                {
                    if (Str == "")
                        continue;
                    String[] StrSummary = Str.Split('=');

                    StrC = StrC + StrSummary[0].Trim().ToUpper();

                    AddSummary(GrdDet, StrSummary[0], StrSummary[1]);
                }

                foreach (DevExpress.XtraGrid.Columns.GridColumn Column in this.GrdDet.Columns)
                {
                    if (!StrC.Contains("'" + Column.FieldName.ToString().ToUpper() + "',"))
                    {
                        if (Column.Visible)
                        {
                            GridSummaryItem ItemSummary = GrdDet.Columns[Column.FieldName.ToString().ToUpper()].SummaryItem;

                            GrdDet.Columns[Column.FieldName.ToString().ToUpper()].Summary.Remove(ItemSummary);

                            GrdDet.Columns[Column.FieldName.ToString().ToUpper()].Summary.Add(DevExpress.Data.SummaryItemType.Count, Column.FieldName.ToString().ToUpper(), "Count={0}");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }
        public void AddSummary(DevExpress.XtraGrid.Views.Grid.GridView GrdDet, String ColumnName, String SummaryType)
        {
            if (ColumnName == "" || SummaryType == "")
                return;

            ColumnName = ColumnName.Trim().ToUpper();

            GridSummaryItem ItemSummary = GrdDet.Columns[ColumnName].SummaryItem;

            GrdDet.Columns[ColumnName].Summary.Remove(ItemSummary);

            if (SummaryType.Trim().ToUpper() == "SUM")
            {
                GrdDet.Columns[ColumnName].Summary.Add(DevExpress.Data.SummaryItemType.Sum, ColumnName, "Sum={0}");
            }
            else if (SummaryType.Trim().ToUpper() == "COUNT")
            {
                GrdDet.Columns[ColumnName].Summary.Add(DevExpress.Data.SummaryItemType.Count, ColumnName, "Count={0}");
            }
            else
            {
                GrdDet.Columns[ColumnName].Summary.Add(DevExpress.Data.SummaryItemType.Min, ColumnName, "MIN={0}");
            }
            GrdDet.PostEditor();
        }
        private void SelectRow()
        {
            try
            {
                if (AllowMultiSelect == false)
                {
                    if ((GrdDet.SelectedRowsCount > 0))
                    {
                        DRow = GrdDet.GetDataRow(GrdDet.GetSelectedRows()[0]);
                        this.Close();
                        SendKeys.Send("{TAB}");
                    }
                    else
                    {
                        DRow = null;
                        Global.ErrorMessage("No row selected.");
                        this.Close();
                    }
                }
                else if (AllowMultiSelect == true)
                {
                    SelectedValue = "";
                    for (int IntI = 0; IntI < GrdDet.RowCount; IntI++)
                    {
                        if (Val.ToBoolean(GrdDet.GetRowCellValue(IntI, "SEL")) == true)
                        {
                            SelectedValue = SelectedValue + Val.ToString(GrdDet.GetRowCellValue(IntI, ValueMember)) + ",";
                        }
                    }

                    if (SelectedValue.Length != 0)
                    {
                        SelectedValue = SelectedValue.Substring(0, SelectedValue.Length - 1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void GrdDet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectRow();
            }
        }
        private void GrdDet_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                if (AllowMultiSelect == false)
                {
                    SelectRow();
                }

            }
        }
        private void FrmSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SelectRow();
            }
            else if (e.KeyCode == Keys.Down)
            {
                GrdDet.FocusedRowHandle = GrdDet.FocusedRowHandle + 1;
            }
            else if (e.KeyCode == Keys.Up)
            {
                GrdDet.FocusedRowHandle = GrdDet.FocusedRowHandle - 1;
            }
        }
        private void ChangeData()
        {
            try
            {
                DataView myDataView = new DataView(DTab);
                string[] StrSplit = SearchField.Split(',');

                string RowFilter = "";
                for (int IntI = 0; IntI < StrSplit.Length; IntI++)
                {
                    RowFilter += " Convert(" + StrSplit[IntI] + ",'System.String')" + " Like " + "'" + txtSeach.Text + "%' ";

                    if (IntI != StrSplit.Length - 1)
                    {
                        RowFilter += " Or ";
                    }
                }
                myDataView.RowFilter = RowFilter;
                MainGrid.DataSource = myDataView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            ChangeData();
        }
        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow DRow in DTab.Rows)
            {
                DRow["SEL"] = ChkAll.Checked;
            }
        }
        private void GrdDet_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SEL")
            {
                if (Val.ToBoolean(GrdDet.GetRowCellValue(e.RowHandle, "SEL")) == true)
                {
                    GrdDet.SetRowCellValue(e.RowHandle, "SEL", false);
                }
                else
                {
                    GrdDet.SetRowCellValue(e.RowHandle, "SEL", true);
                }
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            SelectRow();
            this.Hide();
        }
        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (GrdDet.RowCount > 0)
                {
                    Global.Export("xls", GrdDet);
                }
            }
            catch (Exception Ex)
            { MessageBox.Show(Ex.ToString()); }
        }
    }
}