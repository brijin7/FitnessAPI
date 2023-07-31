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
using static Fitness.Models.BusinessObject.Fooditem.BOL_MstrFoodItem;

namespace Fitness.Models.DataAccessLayer.Fooditem
{
    public class DAL_MstrFoodItem : SqlHelper
    {

        /// <summary>
        /// this method is used to insert details in Fooditem in db
        /// </summary>
        /// <param name="Input">InsertFooditem_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertMstrFooditemAsync(InsertFooditem_In Input)
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
                SqlParameter dietTypeId = new SqlParameter
                {
                    ParameterName = "dietTypeId",
                    Value = Input.dietTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter foodItemName = new SqlParameter
                {
                    ParameterName = "foodItemName",
                    Value = Input.foodItemName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter unit = new SqlParameter
                {
                    ParameterName = "unit",
                    Value = Input.unit,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter servingIn = new SqlParameter
                {
                    ParameterName = "servingIn",
                    Value = Input.servingIn,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter protein = new SqlParameter
                {
                    ParameterName = "protein",
                    Value = Input.protein,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                };
                SqlParameter carbs = new SqlParameter
                {
                    ParameterName = "carbs",
                    Value = Input.carbs,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                };
                SqlParameter fat = new SqlParameter
                {
                    ParameterName = "fat",
                    Value = Input.fat,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                };
                SqlParameter calories = new SqlParameter
                {
                    ParameterName = "calories",
                    Value = Input.calories,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter imageUrl = new SqlParameter
                {
                    ParameterName = "imageUrl",
                    Value = Input.imageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };

                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType,gymOwnerId,  dietTypeId, foodItemName, unit, servingIn,protein,
                    carbs,fat,calories, imageUrl,createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrFoodItem", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch Fooditem details from db
        /// </summary>
        /// <param name="Input">GetFooditem_In class as input parameter</param>
        /// <returns>list of GetFooditem_Out as output</returns>
        public async Task<List<GetFooditem_Out>> UD_GetFooditemAsync(GetFooditem_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getFoodItem",
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
                SqlParameter[] allParameters = {queryType, gymOwnerId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrFoodItem", allParameters);

                List<GetFooditem_Out> lstOfOutput = new List<GetFooditem_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetFooditem_Out Output = new GetFooditem_Out();
                    Output.foodItemId = (int)(dr["foodItemId"]);
                    Output.dietTypeId = (int)(dr["dietTypeId"]);
                    Output.foodItemName = Convert.ToString(dr["foodItemName"]);
                    Output.unit = (int)(dr["unit"]);
                    Output.servingIn = (int)(dr["servingIn"]);
                    Output.servingInName = dr["servingInName"].ToString();
                    Output.unitName = dr["unitName"].ToString();
                    Output.protein = Convert.ToDecimal(dr["protein"]);
                    Output.carbs = Convert.ToDecimal(dr["carbs"]);
                    Output.fat = Convert.ToDecimal(dr["fat"]);
                    Output.calories = Convert.ToUInt16(dr["calories"]);
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.activeStatus = dr["activeStatus"].ToString();
                    lstOfOutput.Add(Output);
                }

                return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }




        /// <summary>
        /// this method is used to fetch Fooditem details from db
        /// </summary>
        /// <param name="Input">GetFooditem_In class as input parameter</param>
        /// <returns>list of GetFooditem_Out as output</returns>
        public async Task<List<ddlGetFooditem_Out>> ddlUD_GetFooditemAsync(GetFooditem_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "ddlgetFoodItem",
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrFoodItem", allParameters);

                List<ddlGetFooditem_Out> lstOfOutput = new List<ddlGetFooditem_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    ddlGetFooditem_Out Output = new ddlGetFooditem_Out();
                    Output.dietTypeId = (int)(dr["dietTypeId"]);
                    Output.foodItemId = (int)(dr["foodItemId"]);
                    Output.foodItemName = Convert.ToString(dr["foodItemName"]);              
                    lstOfOutput.Add(Output);
                }

                return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to update Fooditem details in db
        /// </summary>
        /// <param name="Input">UpdateFooditem_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateFooditemAsync(UpdateFooditem_In Input)
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
                SqlParameter foodItemId = new SqlParameter
                {
                    ParameterName = "foodItemId",
                    Value = Input.foodItemId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter dietTypeId = new SqlParameter
                {
                    ParameterName = "dietTypeId",
                    Value = Input.dietTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter foodItemName = new SqlParameter
                {
                    ParameterName = "foodItemName",
                    Value = Input.foodItemName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter unit = new SqlParameter
                {
                    ParameterName = "unit",
                    Value = Input.unit,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter servingIn = new SqlParameter
                {
                    ParameterName = "servingIn",
                    Value = Input.servingIn,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter protein = new SqlParameter
                {
                    ParameterName = "protein",
                    Value = Input.protein,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                };
                SqlParameter carbs = new SqlParameter
                {
                    ParameterName = "carbs",
                    Value = Input.carbs,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                };
                SqlParameter fat = new SqlParameter
                {
                    ParameterName = "fat",
                    Value = Input.fat,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                };
                SqlParameter calories = new SqlParameter
                {
                    ParameterName = "calories",
                    Value = Input.calories,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter imageUrl = new SqlParameter
                {
                    ParameterName = "imageUrl",
                    Value = Input.imageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType ,gymOwnerId, foodItemId, dietTypeId, foodItemName, unit, servingIn,protein,
                    carbs,fat,calories, imageUrl, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrFoodItem", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate Fooditem master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateFooditem_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateFooditemMstrAsyn(ActivateOrInactivateFooditem_In Input)
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
                SqlParameter foodItemId = new SqlParameter
                {
                    ParameterName = "foodItemId",
                    Value = Input.foodItemId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType, foodItemId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrFoodItem", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}