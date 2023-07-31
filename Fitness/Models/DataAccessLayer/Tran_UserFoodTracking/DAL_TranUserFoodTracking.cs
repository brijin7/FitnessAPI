using Fitness.Helper;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.Tran_UserFoodTracking.BOL_TranUserFoodTracking;

namespace Fitness.Models.DataAccessLayer.DAL_TranUserFoodTracking
{
    public class DAL_TranUserFoodTracking : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);
        /// <summary>
        /// this method is used for insert
        /// </summary>
        /// <param name="Input">InsertTranUserFoodTracking_In class as update</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertTranUserFoodTracking(InsertTranUserFoodTracking_In Input)
        {
            try
            {
                int InsertCount = 0;
                int totalDataForInsert = Input.lstTranUserFoodTracking.Count;

                foreach (UserFoodTracking item in Input.lstTranUserFoodTracking)
                {
                    if (await InsertTranUserFoodTrackingAsync("Insert", item) == 1)
                    {
                        InsertCount++;
                    }
                    //else
                    //{
                    //    ErrorMessage += $"'{res.Response}',";
                    //}
                }


                DB_Response response = new DB_Response();

                if (InsertCount == totalDataForInsert)
                {
                    response = new DB_Response()
                    {
                        StatusCode = 1,
                        Response = "Food items Inserted Successfully !!!."
                    };
                }
                else
                {
                    response = new DB_Response()
                    {
                        StatusCode = 0,
                        Response = "Food items Already Exists !!!."
                    };
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task<int> InsertTranUserFoodTrackingAsync(string Qtype, UserFoodTracking Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = Qtype,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter foodMenuId = new SqlParameter
                {
                    ParameterName = "foodMenuId",
                    Value = Input.foodMenuId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter mealtypeId = new SqlParameter
                {
                    ParameterName = "mealtypeId",
                    Value = Input.mealtypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter consumingStatus = new SqlParameter
                {
                    ParameterName = "consumingStatus",
                    Value = Input.consumingStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };
                SqlParameter date = new SqlParameter
                {
                    ParameterName = "date",
                    Value = Input.date,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, userId, bookingId, foodMenuId, mealtypeId, consumingStatus, date, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                DB_Response response = await ExecuteNonQueryAsync("usp_TranUserFoodTracking", ListOfParameter);

                return response.StatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<string> GetPublicUserFoodMenuAsync(GetListUserDietFoodMenu_In Input)
        {
            try
            {
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter date = new SqlParameter
                {
                    ParameterName = "date",
                    Value = Input.date,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };
				SqlParameter gymOwnerId = new SqlParameter
				{
					ParameterName = "gymOwnerId",
					Value = Input.gymOwnerId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int,
				};


				SqlParameter[] allParameters = { userId, date ,gymOwnerId };


                DataTable dt = await GetDataTableFromUSPAsync("GetUserConsumingDietList", allParameters);

                return dt.Rows[0]["UserConsumingDietList"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetOnedateDietFoodMenu_OutNew>> GetOneDateUserFoodMenuAsync(GetOnedateDietFoodMenu_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getDateFoodCalories",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter date = new SqlParameter
                {
                    ParameterName = "date",
                    Value = DateTime.Parse(Input.date, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };


                SqlParameter[] allParameters = { queryType, userId, date };


                DataTable dt = await GetDataTableFromUSPAsync("usp_GetDashboardDatas", allParameters);

                List<GetOnedateDietFoodMenu_OutNew> lstOfOutput = new List<GetOnedateDietFoodMenu_OutNew>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetOnedateDietFoodMenu_OutNew Output = new GetOnedateDietFoodMenu_OutNew();
                    Output.TotalCalories = (int)(dr["TotalCalories"]);
                    Output.ConsumedCalories = (int)(dr["ConsumedCalories"]);
                    Output.bookingId = (int)(dr["bookingId"]);
                  
                    lstOfOutput.Add(Output);
                }

                return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetTwodateDietFoodMenu_OutNew>> GetTwoDateUserFoodMenuAsync(GetTwodateDietFoodMenu_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getTwoDateFoodCalories",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter Fromdate = new SqlParameter
                {
                    ParameterName = "Fromdate",
                    Value = DateTime.Parse(Input.Fromdate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };
                SqlParameter Todate = new SqlParameter
                {
                    ParameterName = "Todate",
                    Value = DateTime.Parse(Input.Todate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };


                SqlParameter[] allParameters = { queryType, userId, Fromdate, Todate };


                DataTable dt = await GetDataTableFromUSPAsync("usp_GetDashboardDatas", allParameters);

                List<GetTwodateDietFoodMenu_OutNew> lstOfOutput = new List<GetTwodateDietFoodMenu_OutNew>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetTwodateDietFoodMenu_OutNew Output = new GetTwodateDietFoodMenu_OutNew();
                    Output.TotalCalories = (int)(dr["TotalCalories"]);
                    Output.ConsumedCalories = (int)(dr["ConsumedCalories"]);
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.DateOfDay = dr["DateOfDay"].ToString();
                    Output.DaysName = dr["DaysName"].ToString();
                    lstOfOutput.Add(Output);
                }

                return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}