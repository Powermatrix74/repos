using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using Office = Microsoft.Office.Core;
using compareExcel.HelperClasses;

namespace compareExcel
{
    public partial class ThisWorkbook
    {
    


        private void ThisWorkbook_Startup(object sender, System.EventArgs e)
        {
            //myWorkBook = (sender as Excel.Workbook).Sheets[0].Activate();
        }

        private void ThisWorkbook_Shutdown(object sender, System.EventArgs e)
        {
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


        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisWorkbook_Startup);
            this.Shutdown += new System.EventHandler(ThisWorkbook_Shutdown);
        }

        #endregion

    }
}
