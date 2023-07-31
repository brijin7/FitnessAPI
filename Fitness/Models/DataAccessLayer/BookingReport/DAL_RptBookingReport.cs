using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.BookingReport.BOL_RptBookingReport;
using Fitness.Helper;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace Fitness.Models.DataAccessLayer.BookingReport
{
    public class DAL_RptBookingReport : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);
        /// <summary>
        /// this method is used to get BookingReport form database
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<List<GetBookingReport_Out>> UD_GetBookingReport(GetBookingReport_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "QueryType",
                    Value = "GetBookingReport",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter BranchId = new SqlParameter
                {
                    ParameterName = "BranchId",
                    Value = Input.BranchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter GymOwnerId = new SqlParameter
                {
                    ParameterName = "GymOwnerId",
                    Value = Input.GymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter CategoryId = new SqlParameter
                {
                    ParameterName = "CategoryId",
                    Value = Input.CategoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter FromDate = new SqlParameter
                {
                    ParameterName = "FromDate",
                    Value = DateTime.Parse(Input.FromDate.ToString(), objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime
                };
                SqlParameter ToDate = new SqlParameter
                {
                    ParameterName = "ToDate",
                    Value = DateTime.Parse(Input.ToDate.ToString(), objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime
                };


                SqlParameter[] allParameters = { queryType, BranchId, GymOwnerId, CategoryId, FromDate, ToDate };
                DataTable dt = await GetDataTableFromUSPAsync("usp_GetBookingReports", allParameters);

                string OutJson = JsonConvert.SerializeObject(dt);
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                return javaScriptSerializer.Deserialize<List<GetBookingReport_Out>>(OutJson);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}