using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Fitness.Helper
{
    public static class CommonMethods
    {
        /// <summary>
        /// this method is used to convert from excel to datatable
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static DataTable ConvertExcelToDataTable(HttpPostedFile Input)
        {
            try
            {
                DataTable dt = new DataTable();
                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    IApplication application = excelEngine.Excel;
                    application.DefaultVersion = ExcelVersion.Xlsx;

                    IWorkbook workbook = application.Workbooks.Open(Input.InputStream);
                    IWorksheet worksheet = workbook.Worksheets[0];

                    dt = worksheet.ExportDataTable(1, 1, 1000, 24, ExcelExportDataTableOptions.ColumnNames);


                    IEnumerable<DataRow> result = from myRow in dt.AsEnumerable()
                                 where myRow.Field<string>("mobileNo") != null  && myRow.Field<string>("mailId") !=null
                                 select myRow;

                    DataTable filteredDb = result.CopyToDataTable<DataRow>();
                    return filteredDb;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}