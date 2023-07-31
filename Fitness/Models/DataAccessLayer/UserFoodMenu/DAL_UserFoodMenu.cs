using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.UserFoodMenu.BOL_UserFoodMenu;
using Fitness.Helper;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Fitness.Models.DataAccessLayer.UserFoodMenu
{
    public class DAL_UserFoodMenu : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);
        /// <summary>
        /// this method is used to insert details in categorymstr in db
        /// </summary>
        /// <param name="Input">InsertUserFoodMenu_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertUserFoodMenuAsync(InsertUserFoodMenu_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter dietTimeId = new SqlParameter
                {
                    ParameterName = "dietTimeId",
                    Value = Input.dietTimeId,
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
                SqlParameter foodItemId = new SqlParameter
                {
                    ParameterName = "foodItemId",
                    Value = Input.foodItemId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter foodItemName = new SqlParameter
                {
                    ParameterName = "foodItemName",
                    Value = Input.foodItemName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter fromTime = new SqlParameter
                {
                    ParameterName = "fromTime",
                    Value = Input.fromTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter ToTime = new SqlParameter
                {
                    ParameterName = "ToTime",
                    Value = Input.ToTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, userId, bookingId, dietTimeId, dietTypeId, foodItemId, foodItemName, fromTime, ToTime, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrUserFoodMenu", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to update details in categorymstr in db
        /// </summary>
        /// <param name="Input">UpdateUserFoodMenu_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_UpdateUserFoodMenuAsync(UpdateUserFoodMenu_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter dietTimeId = new SqlParameter
                {
                    ParameterName = "dietTimeId",
                    Value = Input.dietTimeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter uniqueId = new SqlParameter
                {
                    ParameterName = "uniqueId",
                    Value = Input.uniqueId,
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
                SqlParameter UserfoodDietTimeId = new SqlParameter
                {
                    ParameterName = "UserfoodDietTimeId",
                    Value = Input.UserfoodDietTimeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter foodItemName = new SqlParameter
                {
                    ParameterName = "foodItemName",
                    Value = Input.foodItemName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter fromTime = new SqlParameter
                {
                    ParameterName = "fromTime",
                    Value = Input.fromTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter ToTime = new SqlParameter
                {
                    ParameterName = "ToTime",
                    Value = Input.ToTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, dietTimeId, uniqueId, foodItemId, foodItemName, UserfoodDietTimeId, fromTime, ToTime, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrUserFoodMenu", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to update details in categorymstr in db
        /// </summary>
        /// <param name="Input">UpdateUserFoodMenu_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_DeleteUserFoodMenuAsync(DeleteUserFoodMenu_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "delete",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter uniqueId = new SqlParameter
                {
                    ParameterName = "uniqueId",
                    Value = Input.uniqueId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter UserFoodDietTimeId = new SqlParameter
                {
                    ParameterName = "UserFoodDietTimeId",
                    Value = Input.UserFoodDietTimeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };


                SqlParameter[] allParameters = { QueryType, uniqueId, UserFoodDietTimeId };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrUserFoodMenu", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> GetUserFoodMenuAsync(GetUserFoodMenu_In Input)
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
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter[] allParameters = { userId, bookingId, gymOwnerId };


                DataTable dt = await GetDataTableFromUSPAsync("GetFooditemEdit", allParameters);
                return dt.Rows[0]["UserFoodMenu"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<string> GetInsertUserFoodMenuAsync(GetInsertUserFoodMenu_In Input)
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
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter DietType = new SqlParameter
                {
                    ParameterName = "DietType",
                    Value = Input.DietType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter WakeUpTime = new SqlParameter
                {
                    ParameterName = "WakeUpTime",
                    Value = Input.WakeUpTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                };
                SqlParameter fromDate = new SqlParameter
                {
                    ParameterName = "fromDate",
                    Value = DateTime.Parse(Input.fromDate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };

                SqlParameter ToDate = new SqlParameter
                {
                    ParameterName = "ToDate",
                    Value = DateTime.Parse(Input.ToDate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter TotalCalories = new SqlParameter
                {
                    ParameterName = "TotalCalories",
                    Value = Input.TotalCalories,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter[] allParameters = { userId,  bookingId,DietType,
                    WakeUpTime,fromDate,ToDate,TotalCalories,createdBy,gymOwnerId};


                DataTable dt = await GetDataTableFromUSPAsync("GetFooditem", allParameters);

                return dt.Rows[0]["UserFoodMenu"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<string> GetUserFoodMenuAsync(GetListUserFoodMenu_In Input)
        {
            try
            {
                string Date = Input.fromDate != null ? DateTime.Parse(Input.fromDate, objEnglishDate).ToString() : Input.fromDate;
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

                SqlParameter fromDate = new SqlParameter
                {

                    ParameterName = "fromDate",
                    Value = Date,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };

                SqlParameter mealTypeId = new SqlParameter
                {
                    ParameterName = "mealTypeId",
                    Value = Input.mealTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter[] allParameters = { userId, bookingId, mealTypeId, fromDate, gymOwnerId };


                DataTable dt = await GetDataTableFromUSPAsync("GetUserDietList", allParameters);

                return dt.Rows[0]["UserDietList"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<string> GetPublicUserFoodMenuAsync(GetListPublicUserFoodMenu_In Input)
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
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter fromDate = new SqlParameter
                {
                    ParameterName = "fromDate",
                    Value = Input.fromDate,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime,
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };

                SqlParameter[] allParameters = { userId, bookingId, fromDate, gymOwnerId };


                DataTable dt = await GetDataTableFromUSPAsync("GetPublicUserDietList", allParameters);

                return dt.Rows[0]["UserPublicDietList"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GetPublicUserFoodMenuForCatgoryAsync(GetListPublicUserFoodMenuBasedCategory_In Input)
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
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter fromDate = new SqlParameter
                {
                    ParameterName = "fromDate",
                    Value = Input.fromDate,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime,
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };

                SqlParameter[] allParameters = { userId, bookingId, categoryId, fromDate, gymOwnerId };


                DataTable dt = await GetDataTableFromUSPAsync("GetPublicUserDietListWebBasedOnCategory", allParameters);

                return dt.Rows[0]["UserPublicDietList"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}