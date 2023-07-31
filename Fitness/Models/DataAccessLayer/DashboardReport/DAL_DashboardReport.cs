using Fitness.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.DashboardReport.BOL_DashboardReport;
namespace Fitness.Models.DataAccessLayer.DashboardReport
{
    public class DAL_DashboardReport : SqlHelper
    {
        readonly string ProcedureName;
        public DAL_DashboardReport()
        {
            ProcedureName = "usp_DashboardReportDateBased";
        }
        /// <summary>
        /// this method is used to combine all the result into single JObjcet
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<JArray> GetDashBoardDetailsAsync(DashboardInput Input)
        {
            try
            {
                DataTable activities;
                DataTable foodConsumptionDetails;
                DataTable caloriesDetails;

                activities = await GetDashBoardReportResultAsync("Activities", Input.FromDate, Input.ToDate, Input.UserId);
                foodConsumptionDetails = await GetDashBoardReportResultAsync("FoodConsumptionDetails", Input.FromDate, Input.ToDate, Input.UserId);
                caloriesDetails = await GetDashBoardReportResultAsync("CaloriesDetails", Input.FromDate, Input.ToDate, Input.UserId);

                if (activities.Rows.Count == 0 &&
                   foodConsumptionDetails.Rows.Count == 0 &&
                   caloriesDetails.Rows.Count == 0)
                {
                    return new JArray();
                }

                var activitiesDtls = await GetResultForActivities("activities", activities, "");
                var caloriesDtls = await GetResultForActivities("caloriesDetails", caloriesDetails, "");
                var foodNutriants = await GetResultForActivities("foodNutriants", foodConsumptionDetails, "");


                var resultOptions = new
                {
                    foodNutriants,
                    activitiesDtls,
                    caloriesDtls,
                };
                string sObjects = JsonConvert.SerializeObject(resultOptions, Formatting.Indented);

                return JsonConvert.DeserializeObject<JArray>($"[{sObjects}]");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// this method is used to get the result from datatable
        /// </summary>
        /// <param name="CategoryName">from which Table you want to get datatale</param>
        /// <param name="dt">Input details</param>
        /// <param name="Type">QueryType</param>
        /// <returns></returns>
        private async Task<dynamic> GetResultForActivities(string CategoryName, DataTable dt, string Type)
        {
            try
            {
                if (CategoryName == "activities")
                {
                    return await Task.Run(
                             () => dt.AsEnumerable()
                                     .Select(row => new
                                     {
                                         day = row.Field<string>("day"),
                                         Allocated = row.Field<int>("Allocated"),
                                         Completed = row.Field<int>("Completed"),
                                         date = row.Field<DateTime>("date").ToString("yyyy-MM-dd"),
                                     }));
                }
                else if (CategoryName == "caloriesDetails")
                {
                    return await Task.Run(
                             () => dt.AsEnumerable()
                                     .Select(row => new
                                     {
                                         caloriesIntake = row.Field<int>("caloriesIntake"),
                                         caloriesBurnt = row.Field<int>("caloriesBurnt"),
                                         day = row.Field<string>("day"),
                                         date = row.Field<DateTime>("date").ToString("yyyy-MM-dd"),
                                     }));
                }
                else if (CategoryName == "foodNutriants")
                {
                    return await Task.Run(
                      () => dt.AsEnumerable().Select(row => new
                      {
                          protein = row.Field<decimal>("protein"),
                          carbs = row.Field<decimal>("carbs"),
                          fat = row.Field<decimal>("fat"),
                          calories = row.Field<int>("calories"),
                          day = row.Field<string>("Day"),
                          date = row.Field<DateTime>("date").ToString("yyyy-MM-dd"),
                      }));
                }
                else
                {
                    return new ArrayList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to retrive details from database
        /// </summary>
        /// <param name="qType">QueryType</param>
        /// <param name="fDate">FromDate</param>
        /// <param name="tDate">ToDate</param>
        /// <param name="uId">UserId</param>
        /// <returns></returns>
        private async Task<DataTable> GetDashBoardReportResultAsync(string qType, string fDate, string tDate, int uId)
        {
            try
            {
                SqlParameter queryType = new SqlParameter()
                {
                    ParameterName = "QueryType",
                    Value = qType,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                };

                SqlParameter fromDate = new SqlParameter()
                {
                    ParameterName = "FromDate",
                    Value = fDate,
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter toDate = new SqlParameter()
                {
                    ParameterName = "ToDate",
                    Value = tDate,
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter userId = new SqlParameter()
                {
                    ParameterName = "UserId",
                    Value = uId,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    queryType,
                    fromDate,
                    toDate,
                    userId,
                };

                return await base.GetDataTableFromUSPAsync(this.ProcedureName, sqlParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}