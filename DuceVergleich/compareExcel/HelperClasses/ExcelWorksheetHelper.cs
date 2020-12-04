using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace compareExcel.HelperClasses
{
    public class ExcelWorksheetHelper
    {
        private static Excel.Workbook myWorkBook { get; set; }
        private static Excel.Application myExcelApplication { get; set; }
        private static Excel.Worksheet myExcelWorksheet { get; set; }
        private static Excel.Workbooks workBooks { get; set; }
        public static Excel.Worksheet ExcelWorksheet { get { return myExcelWorksheet; } }
        public static Excel.Range Range { get { return range; } }
        private static Excel.Range range { get; set; }
        public static Excel.Workbooks ParentWorkBooks { get { return workBooks; } set { workBooks = value; } }
        public static string ExcelFileName { get { return sourceExcelPath; } }
        private static string sourceExcelPath = @"C:\Users\Kay\source\repos\DuceVergleich\compareExcel\Aymon.xlsx";
        public void InitializeExcelWorkbook()
        {
            myExcelApplication = new Excel.Application();
            myExcelApplication.Visible = false;
            ParentWorkBooks = myExcelApplication.Workbooks;
            myWorkBook = ParentWorkBooks.Open(SourceExcelPath);
            myExcelWorksheet = (Excel.Worksheet)myWorkBook.Sheets[1];
        }
        public static List<CellInformation> GetRangeCellInformation()
        {
            List<CellInformation> cellInformation = new List<CellInformation>();
            range = myExcelWorksheet.UsedRange;
            object[,] valueArray = (object[,])range.get_Value(
                Excel.XlRangeValueDataType.xlRangeValueDefault);
            for (int row = 1; row <= myExcelWorksheet.UsedRange.Rows.Count; ++row)
            {
                for (int col = 1; col <= myExcelWorksheet.UsedRange.Columns.Count; ++col)
                {
                    string data = string.Empty;
                    try
                    {
                        data = valueArray[row, col].ToString();
                    }
                    catch
                    {
                        data = null;
                    }
                    cellInformation.Add(new CellInformation
                    {
                        XValue = row,
                        YValue = col,
                        Data = data
                    });
                }
            }
            return cellInformation;
        }
    }
}
