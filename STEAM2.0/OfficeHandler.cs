using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ex = Microsoft.Office.Interop.Excel;

namespace STEAM2._0
{
    static class OfficeHandler
    {

        public static DataTable createTable(params string[] colNames)
        {
            DataTable Table = new DataTable();

            foreach (string s in colNames)
            {
                Table.Columns.Add(s);
            }

            return Table;
        }
        public static void exportExcel(DataTable dt)
        {
            ex.Application xlApp = new ex.Application();
            ex.Workbook xlWb = xlApp.Workbooks.Add();
            ex.Worksheet ws = xlApp.ActiveSheet;
            

            int i = 1;
            foreach(DataColumn col in dt.Columns)
            {
                ws.Cells[1, i] = col.ColumnName;
                i++;
            }

            i = 2;
            foreach(DataRow row in dt.Rows)
            {
                for(int j = 1; j<dt.Columns.Count+1;j++)
                {
                    double value = double.Parse(row[j-1].ToString());

                    ws.Cells[i, j] = value;
                }               

                i++;
            }

            xlApp.Visible = true;
        }
    }
}
