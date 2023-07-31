using Fitness.Helper;
using Fitness.Models.CommonModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.Fooditem.BOL_MstrFoodDietTime;
using Fitness.Helper;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Fitness.Models.DataAccessLayer.Fooditem
{
    public class DAL_MstrFoodDietTime : SqlHelper
    {
        /// <summary>
        /// this method is used to insert details in FoodDietTime in db
        /// </summary>
        /// <param name="Input">InsertFoodDietTime_In class as input parameter</param>
        /// <returns></returns>

        public async Task<DB_Response> UD_InsertFoodDietTime(InsertFoodDietTime_In Input)
        {
            try
            {
                int InsertCount = 0;
                int totalDataForInsert = Input.lstFoodDietTime.Count;

                foreach (FoodDietTime item in Input.lstFoodDietTime)
                {
                    if (await InsertFoodDietTimeAsync("Insert", item) == 1)
                    {
                        InsertCount++;
                    }
                }

                DB_Response response = new DB_Response();

                if (InsertCount == totalDataForInsert)
                {
                    response = new DB_Response()
                    {
                        StatusCode = 1,
                        Response = "Food Items Inserted Successfully !!!."
                    };
                }
                else
                {
                    string Res = string.Empty;
                    int status=0;
                    if(InsertCount == 0)
                    {
                        status = 0;
                           Res = "Food Diet Time Is Already Exists !!!";
                    }
                    else
                    {
                        status = 1;
                        Res = "Food Items Updated Successfully !!!.";
                    }
                    response = new DB_Response()
                    {
                     
                       StatusCode = status,
                        Response = Res


                    };
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<int> InsertFoodDietTimeAsync(string Qtype, FoodDietTime Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter mealType = new SqlParameter
                {
                    ParameterName = "mealType",
                    Value = Input.mealType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter foodItemId = new SqlParameter
                {
                    ParameterName = "foodItemId",
                    Value = Input.foodItemId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, mealType, foodItemId, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                DB_Response response = await ExecuteNonQueryAsync("usp_MstrFoodDietTime", ListOfParameter);

                return response.StatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch FoodDietTime details from db
        /// </summary>
        /// <param name="Input">GetFoodDietTime_In class as input parameter</param>
        /// <returns>list of GetFoodDietTime_Out as output</returns>
        public async Task<string> UD_GetFoodDietTimeAsync(GetFoodDietTime_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getMstrFoodDietTime",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrFoodDietTime", allParameters);
                return dt.Rows[0]["FoodDietTime"].ToString();
            
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch  FoodDietTime details for DropDown from db
        /// </summary>
        /// <param name="Input">GetFoodDietTime_In class as input parameter</param>
        /// <returns>list of GetFoodDietTime_Out as output</returns>
        public async Task<JArray> UD_ddlFoodDietTimeAsync(GetFoodDietTime_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "ddlMstrFoodDietTime",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId };
                return await GetResultFromGetDataTableFromUSPAsync("usp_GetMstrFoodDietTime", allParameters);

                //DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrFoodDietTime", allParameters);

                //List<ddlFoodDietTime_Out> lstOfOutput = new List<ddlFoodDietTime_Out>();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    ddlFoodDietTime_Out Output = new ddlFoodDietTime_Out();
                //    Output.uniqueId = dr["uniqueId"].ToString();
                //    Output.mealTypeName = dr["mealTypeName"].ToString();
                //    lstOfOutput.Add(Output);
                //}

                //return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch FoodDietTime details from db
        /// </summary>
        /// <param name="Input">GetFoodDietTime_In class as input parameter</param>
        /// <returns>list of GetFoodDietTime_Out as output</returns>
        public async Task<JArray> UD_GetMealtypebasedFoodItemAsync(GetMealtypebasedFoodItem_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "MealtypebasedFoodItem",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter mealType = new SqlParameter
                {
                    ParameterName = "mealType",
                    Value = Input.mealType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType , mealType, gymOwnerId };

                return await GetResultFromGetDataTableFromUSPAsync("usp_GetMstrFoodDietTime", allParameters);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch  FoodDietTime details for DropDown from db
        /// </summary>
        /// <param name="Input">GetFoodDietTime_In class as input parameter</param>
        /// <returns>list of GetFoodDietTime_Out as output</returns>
        public async Task<JArray> UD_FoodDietTimeAsync(FoodDietTime_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "MstrFoodDietTime",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                  SqlParameter foodItemId = new SqlParameter
                {
                    ParameterName = "foodItemId",
                    Value = Input.foodItemId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType , foodItemId, gymOwnerId };

                return await GetResultFromGetDataTableFromUSPAsync("usp_GetMstrFoodDietTime", allParameters);

                //DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrFoodDietTime", allParameters);

                //List<FoodDietTime_Out> lstOfOutput = new List<FoodDietTime_Out>();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    FoodDietTime_Out Output = new FoodDietTime_Out();
                //    Output.uniqueId = (int)(dr["uniqueId"]);
                //    Output.foodItemId = (int)(dr["foodItemId"]);
                //    Output.foodItemName = dr["foodItemName"].ToString();
                //    Output.mealType = dr["mealType"].ToString();
                //    Output.mealTypeName = dr["mealTypeName"].ToString();
                //    Output.activeStatus = dr["activeStatus"].ToString();
                //    lstOfOutput.Add(Output);
                //}

                //return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to update FoodDietTime details in db
        /// </summary>
        /// <param name="Input">UpdateFoodDietTime_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateFoodDietTimeAsync(UpdateFoodDietTime_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100

                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter uniqueId = new SqlParameter
                {
                    ParameterName = "uniqueId",
                    Value = Input.uniqueId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter mealType = new SqlParameter
                {
                    ParameterName = "mealType",
                    Value = Input.mealType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter foodItemId = new SqlParameter
                {
                    ParameterName = "foodItemId",
                    Value = Input.foodItemId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, uniqueId, mealType, foodItemId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrFoodDietTime", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate FoodDietTime master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateFoodDietTime_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateFoodDietTimeMstrAsyn(ActivateOrInactivateFoodDietTime_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = Input.queryType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter uniqueId = new SqlParameter
                {
                    ParameterName = "uniqueId",
                    Value = Input.uniqueId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType, uniqueId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrFoodDietTime", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}