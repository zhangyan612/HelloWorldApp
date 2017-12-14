using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using OfficeOpenXml;

namespace HelloWorldApp
{
    public class ExcelReader
    {
        public static DataTable ReadExcel(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            DataTable dt = new DataTable();

            using (ExcelPackage xlPackage = new ExcelPackage(file))
            {
                // get the first worksheet in the workbook
                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.First();

                int RowEnd = worksheet.Dimension.End.Row;
                int ColEnd = worksheet.Dimension.End.Column;

                for (int row = 1; row <= RowEnd; row++)
                {
                    DataRow dr = dt.NewRow();
                    for (int col = 1; col <= ColEnd; col++)
                    {
                        if (row == 1)
                            dt.Columns.Add("Columns " + col);
                        dr[col - 1] = worksheet.Cells[row, col].Value;
                    }
                    dt.Rows.Add(dr);
                }
            }; 
            return dt;
        }
    }
}
