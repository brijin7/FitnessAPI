using Fitness.Helper;
using Fitness.Models.CommonModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.CategoryDietPlan.BOL_CategoryDietPlan;

namespace Fitness.Models.DataAccessLayer.CategoryDietPlan
{
    public class DAL_CategoryDietPlan : SqlHelper
    {
        readonly private static string GetProcedureName;
        static DAL_CategoryDietPlan()
        {
            GetProcedureName = "usp_GetMstrCategoryDietPlan";
        }
        /// <summary>
        /// this method is used to insert details in CategoryDietPlan in db
        /// </summary>
        /// <param name="Input">InsertCategoryDietPlan_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertCategoryDietPlanMenu(InsertCategoryDietPlan_In Input)
        {
            try
            {
                int InsertCount = 0;
                int totalDataForInsert = Input.lstWorkOutFoodMenu.Count;

                foreach (CategoryDietPlans item in Input.lstWorkOutFoodMenu)
                {
                    if (await InsertCategoryDietPlanAsync("Insert", item) == 1)
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
                    int status = 0;
                    if (InsertCount == 0)
                    {
                        status = 0;
                        Res = "Food Items Is Already Exists !!!";
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
        /// <summary>
        /// This method is used  Insert Category Diet Plan
        /// </summary>
        /// <param name="Qtype"></param>
        /// <param name="Input">CategoryDietPlans</param>
        /// <returns></returns>
        private async Task<int> InsertCategoryDietPlanAsync(string Qtype, CategoryDietPlans Input)

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
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
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
                SqlParameter foodItemId = new SqlParameter
                {
                    ParameterName = "foodItemId",
                    Value = Input.foodItemId,
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
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter activeStatus = new SqlParameter
                {
                    ParameterName = "activeStatus",
                    Value = Input.activeStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size=2
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType,gymOwnerId,branchId, mealTypeId,
                    foodItemId, dietTimeId, categoryId, activeStatus, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                DB_Response response = await ExecuteNonQueryAsync("usp_MstrCategoryDietPlan", ListOfParameter);

                return response.StatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This Method Is Used For Update Category Diet Plan
        /// </summary>
        /// <param name="Input">UpdateCategoryDietPlan_In</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_UpdateCategoryDietPlanMenu(UpdateCategoryDietPlan_In Input)
        {
            try
            {
                int InsertCount = 0;
                int totalDataForInsert = Input.lstWorkOutFoodMenu.Count;

                foreach (UpdateCategoryDietPlan item in Input.lstWorkOutFoodMenu)
                {
                    if (await UpdateCategoryDietPlanAsync("Update", item) == 1)
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
                        Response = "Food Items Updated Successfully !!!."
                    };
                }
                else
                {
                    string Res = string.Empty;
                    int status = 0;
                    status = 0;
                    Res = "Food Items Is Already Exists !!!";

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

        /// <summary>
        /// this method is used to update FoodDietTime details in db
        /// </summary>
        /// <param name="Input">UpdateFoodDietTime_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        private async Task<int> UpdateCategoryDietPlanAsync(string Qtype, UpdateCategoryDietPlan Input)

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
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
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
                SqlParameter mealTypeId = new SqlParameter
                {
                    ParameterName = "mealTypeId",
                    Value = Input.mealTypeId,
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
                SqlParameter dietTimeId = new SqlParameter
                {
                    ParameterName = "dietTimeId",
                    Value = Input.dietTimeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter activeStatus = new SqlParameter
                {
                    ParameterName = "activeStatus",
                    Value = Input.activeStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 2
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId,branchId,
                    uniqueId, mealTypeId, foodItemId, dietTimeId, activeStatus, categoryId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                DB_Response response = await ExecuteNonQueryAsync("usp_MstrCategoryDietPlan", ListOfParameter);

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
        public async Task<string> UD_GetCategoryDietPlanAsync(CategoryDietPlan_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getMstrCategoryDietPlan",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, categoryId,gymOwnerId,branchId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrCategoryDietPlan", allParameters);
                return dt.Rows[0]["CategoryDietPlan"].ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// This Method is Used For Get Category Based On Insert data
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<JArray> UD_GetCategoryAsync(Category_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getMstrCategory",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType , branchId ,gymOwnerId};

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        } /// <summary>
        /// This Method is Used For Get Category Based On Insert data
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<JArray> UD_GetWeekDaysAsync()
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getWeekDays",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
               
                SqlParameter[] allParameters = { queryType };

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<string> UD_GetPublicCategoryDietPlanAsync(CategoryDietPlan_In Input)
        {
            try
            {
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = {  categoryId, gymOwnerId, branchId };

                DataTable dt = await GetDataTableFromUSPAsync("GetPublicCategoryDietPlan", allParameters);
                return dt.Rows[0]["CategoryDietPlan"].ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}