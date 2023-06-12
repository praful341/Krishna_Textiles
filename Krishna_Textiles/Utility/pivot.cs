using System;
using System.Data;
using System.Linq;

namespace DERP
{
    public class pivot
    {
        private DataTable _SourceTable = new DataTable();
        public pivot(DataTable SourceTable)
        {
            _SourceTable = SourceTable;
        }

        public DataTable PivotDataSuper(string[] RowFields, string[] DataField, AggregateFunction Aggregate, params string[] ColumnFields)
        {
            DataTable dt = new DataTable();

            string Separator = "_";
            dt = new DataView(_SourceTable).ToTable(true, RowFields);
            // Gets the list of columns .(dot) separated.
            var ColList = (from x in _SourceTable.AsEnumerable()
                           select new
                           {
                               Name = ColumnFields.Select(n => x.Field<object>(n))
                                   .Aggregate((a, b) => a += Separator + b.ToString())
                           })
                               .Distinct()
                               .OrderBy(m => m.Name);

            foreach (var col in ColList)
            {
                foreach (string item in DataField)
                {
                    dt.Columns.Add((col.Name.ToString()).Trim().Replace(' ', '_') + "_" + (item).Trim());  // Cretes the result columns.//
                }
            }


            for (int r = 0; r < dt.Rows.Count; r++)
            {
                foreach (var col in ColList)
                {
                    string strFilter = " 1=1 ";
                    foreach (string row in RowFields)
                    {

                        strFilter = strFilter + " and " + row + " ='" + dt.Rows[r][row].ToString() + "' ";
                    }

                    string[] strColValues = col.Name.ToString().Split(Separator.ToCharArray(), StringSplitOptions.None);
                    for (int i = 0; i < ColumnFields.Length; i++)
                        strFilter += " and " + ColumnFields[i] + " = '" + strColValues[i] + "'";

                    foreach (string item in DataField)
                    {
                        dt.Rows[r][(col.Name.ToString()).Trim().Replace(' ', '_') + "_" + (item).Trim()] = GetData(strFilter, item, Aggregate);
                    }
                }
            }
            return dt;
        }



        public DataTable PivotDataSuperPlus(string[] RowFields, string[] DataField, AggregateFunction[] AggregateFunctions, params string[] ColumnFields)
        {
            DataTable dt = new DataTable();

            string Separator = "_";
            dt = new DataView(_SourceTable).ToTable(true, RowFields);
            // Gets the list of columns .(dot) separated.
            var ColList = (from x in _SourceTable.AsEnumerable()
                           select new
                           {
                               Name = ColumnFields.Select(n => x.Field<object>(n))
                                   .Aggregate((a, b) => a += Separator + b.ToString())
                           })
                               .Distinct()
                               .OrderBy(m => m.Name);
            if (ColumnFields.Length == 0)
            {
                foreach (string item in DataField)
                {
                    dt.Columns.Add((item).Trim());  // Cretes the result columns.//
                }
            }
            else
            {
                foreach (var col in ColList)
                {
                    foreach (string item in DataField)
                    {
                        dt.Columns.Add((col.Name.ToString()).Trim().Replace(' ', '_') + "_" + (item).Trim());  // Cretes the result columns.//
                    }
                }
            }

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                if (ColumnFields.Length == 0)
                {

                    string strFilter = " 1=1 ";
                    foreach (string row in RowFields)
                    {

                        strFilter = strFilter + " and " + row + " ='" + dt.Rows[r][row].ToString() + "' ";
                    }

                    //string[] strColValues = col.Name.ToString().Split(Separator.ToCharArray(), StringSplitOptions.None);
                    //  for (int i = 0; i < ColumnFields.Length; i++)
                    //    strFilter += " and " + ColumnFields[i] + " = '" + strColValues[i] + "'";
                    int x = 0;
                    foreach (string item in DataField)
                    {
                        dt.Rows[r][(item).Trim()] = GetData(strFilter, item, AggregateFunctions[x]);
                        x++;
                    }


                }
                else
                {
                    foreach (var col in ColList)
                    {
                        string strFilter = " 1=1 ";
                        foreach (string row in RowFields)
                        {

                            strFilter = strFilter + " and " + row + " ='" + dt.Rows[r][row].ToString() + "' ";
                        }

                        string[] strColValues = col.Name.ToString().Split(Separator.ToCharArray(), StringSplitOptions.None);
                        for (int i = 0; i < ColumnFields.Length; i++)
                            //strFilter += " and " + ColumnFields[i] + " = '" + strColValues[i] + "'";
                            strFilter += " and " + ColumnFields[i] + " = '" + col.Name.ToString() + "'";
                        int x = 0;
                        foreach (string item in DataField)
                        {
                            dt.Rows[r][(col.Name.ToString()).Trim().Replace(' ', '_') + "_" + (item).Trim()] = GetData(strFilter, item, AggregateFunctions[x]);
                            x++;
                        }
                    }
                }
            }
            return dt;
        }


        public static DataTable GetDistinctRecords(DataTable dt, string[] Columns)
        {
            DataTable dtUniqRecords = new DataTable();
            dtUniqRecords = dt.DefaultView.ToTable(true, Columns);
            return dtUniqRecords;
        }

        /// <summary>
        /// Retrives the data for matching RowField value and ColumnFields values with Aggregate function applied on them.
        /// </summary>
        /// <param name="Filter">DataTable Filter condition as a string</param>
        /// <param name="DataField">The column name which needs to spread out in Data Part of the Pivoted table</param>
        /// <param name="Aggregate">Enumeration to determine which function to apply to aggregate the data</param>
        /// <returns></returns>
        /// 

        private object GetData(string Filter, string DataField, AggregateFunction Aggregate)
        {
            try
            {
                DataTable dtFilter = _SourceTable.Copy();
                dtFilter.Columns[DataField].DefaultValue = "0";
                dtFilter = GetFilteredTable(_SourceTable, Filter);
                DataRow[] FilteredRows = dtFilter.Select(Filter);

                object[] objList = FilteredRows.Select(x => x.Field<object>(DataField)).ToArray();

                switch (Aggregate)
                {
                    case AggregateFunction.Average:
                        return GetAverage(objList);
                    case AggregateFunction.Count:
                        return objList.Count();
                    case AggregateFunction.Exists:
                        return (objList.Count() == 0) ? "False" : "True";
                    case AggregateFunction.First:
                        return GetFirst(objList);
                    case AggregateFunction.Last:
                        return GetLast(objList);
                    case AggregateFunction.Max:
                        return GetMax(objList);
                    case AggregateFunction.Min:
                        return GetMin(objList);
                    case AggregateFunction.Sum:
                        return GetSum(objList);                   
                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                return "#Error";
            }
            return null;
        }
        public static DataTable GetFilteredTable(
    DataTable sourceTable, string selectFilter)
        {
            var filteredTable = sourceTable.Clone();
            var rows = sourceTable.Select(selectFilter);
            foreach (DataRow row in rows)
            {
                filteredTable.ImportRow(row);
            }
            return filteredTable;
        }

        private object GetAverage(object[] objList)
        {
            return objList.Count() == 0 ? null : (object)Math.Round((Convert.ToDecimal(GetSum(objList)) / objList.Count()), 0);
        }
        private object GetSum(object[] objList)
        {
            return objList.Count() == 0 ? 0 : (object)(objList.Aggregate(new decimal(), (x, y) => x += Convert.ToDecimal(y)));
        }
        private object GetFirst(object[] objList)
        {
            return (objList.Count() == 0) ? null : objList.First();
        }
        private object GetLast(object[] objList)
        {
            return (objList.Count() == 0) ? null : objList.Last();
        }
        private object GetMax(object[] objList)
        {
            return (objList.Count() == 0) ? null : objList.Max();
        }
        private object GetMin(object[] objList)
        {
            return (objList.Count() == 0) ? null : objList.Min();
        }
        //private object Default(object[] objList)
        //{
        //    return (objList.Count() == 0) ? null : Math.Round(Convert.ToDecimal(objList.Select), 0);
        //}
    }
    public enum AggregateFunction
    {
        Count = 1,
        Sum = 2,
        First = 3,
        Last = 4,
        Average = 5,
        Max = 6,
        Min = 7,
        Exists = 8
    }
}
