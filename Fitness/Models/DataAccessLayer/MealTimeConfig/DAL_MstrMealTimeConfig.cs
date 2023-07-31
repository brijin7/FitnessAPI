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
using static Fitness.Models.BusinessObject.MealTimeConfig.BOL_MstrMealTimeConfig;
namespace Fitness.Models.DataAccessLayer.MealTimeConfig
{
    public class DAL_MstrMealTimeConfig : SqlHelper
    {

        /// <summary>
        /// this method is used to insert details in MealTimeConfig in db
        /// </summary>
        /// <param name="Input">InsertMealTimeConfig_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertMealTimeConfigAsync(InsertMealTimeConfig_In Input)
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
                SqlParameter mealTypeId = new SqlParameter
                {
                    ParameterName = "mealTypeId",
                    Value = Input.mealTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter timeInHrs = new SqlParameter
                {
                    ParameterName = "timeInHrs",
                    Value = Input.timeInHrs,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 150
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType, gymOwnerId, mealTypeId, timeInHrs,createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrMealTimeConfig", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to insert details in MealTimeConfig in db
        /// </summary>
        /// <param name="Input">UpdateMealTimeConfig_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_UpdateMealTimeConfigAsync(UpdateMealTimeConfig_In Input)
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

                SqlParameter mealTypeId = new SqlParameter
                {
                    ParameterName = "mealTypeId",
                    Value = Input.mealTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter timeInHrs = new SqlParameter
                {
                    ParameterName = "timeInHrs",
                    Value = Input.timeInHrs,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 150
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType, gymOwnerId, uniqueId, mealTypeId, timeInHrs, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrMealTimeConfig", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch Meal Time Config from db
        /// </summary>
        /// <returns>list of MealTimeConfig_Out as output</returns>
        public async Task<List<MealTimeConfig_Out>> UD_GetMealTimeConfigAsync(MealTimeConfig_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getMealTimeConfig",
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrMealTimeConfig", allParameters);

                List<MealTimeConfig_Out> lstOfOutput = new List<MealTimeConfig_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    MealTimeConfig_Out Output = new MealTimeConfig_Out();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.mealTypeId = (int)(dr["mealTypeId"]);
                    Output.mealTypeName = Convert.ToString(dr["mealTypeName"]);
                    Output.timeInHrs = (int)(dr["timeInHrs"]);
                    
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