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
using static Fitness.Models.BusinessObject.CategoryWorkOutPlan.BOL_CategoryWorkOutPlan;

namespace Fitness.Models.DataAccessLayer.CategoryWorkOutPlan
{
    public class DAL_CategoryWorkOutPlan : SqlHelper
    {
        readonly private static string GetProcedureName;
        static DAL_CategoryWorkOutPlan()
        {
            GetProcedureName = "usp_GetMstrWorkOutPlan";
        }
        /// <summary>
        /// this method is used to insert details in Insert CategoryWorkOutPlan in db
        /// </summary>
        /// <param name="Input">InsertCategoryWorkOutPlan_In class as input parameter</param>
        /// <returns></returns>

        public async Task<DB_Response> UD_InsertCategoryWorkOutPlan(InsertCategoryWorkOutPlan_In Input)
        {
            try
            {
                int InsertCount = 0;
                int totalDataForInsert = Input.lstWorkOutFoodMenu.Count;

                foreach (CategoryWorkOutPlans item in Input.lstWorkOutFoodMenu)
                {
                    if (await InsertCategoryWorkOutPlanAsync("Insert", item) == 1)
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
                        Response = "WorkOut Inserted Successfully !!!."
                    };
                }
                else
                {
                    string Res = string.Empty;
                    int status = 0;
                    if (InsertCount == 0)
                    {
                        status = 0;
                        Res = "WorkOut Is Already Exists !!!";
                    }
                    else
                    {
                        status = 1;
                        Res = "WorkOut Updated Successfully !!!.";
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
        /// This Method Is Used For  Insert Method
        /// </summary>
        /// <param name="Qtype"></param>
        /// <param name="Input"> CategoryWorkOutPlans</param>
        /// <returns></returns>
        private async Task<int> InsertCategoryWorkOutPlanAsync(string Qtype, CategoryWorkOutPlans Input)

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
                SqlParameter workoutTypeId = new SqlParameter
                {
                    ParameterName = "workoutTypeId",
                    Value = Input.workoutTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter workoutCatTypeId = new SqlParameter
                {
                    ParameterName = "workoutCatTypeId",
                    Value = Input.workoutCatTypeId,
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
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType,gymOwnerId,branchId, workoutTypeId,
                    workoutCatTypeId, categoryId, activeStatus, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                DB_Response response = await ExecuteNonQueryAsync("usp_MstrCategoryWorkOutPlan", ListOfParameter);

                return response.StatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This Method Is Used For Update Categoryworkoutplan 
        /// </summary>
        /// <param name="Input"> UpdateCategoryWorkOutPlan_In</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_UpdateCategoryWorkOutPlan(UpdateCategoryWorkOutPlan_In Input)
        {
            try
            {
                int InsertCount = 0;
                int totalDataForInsert = Input.lstWorkOutFoodMenu.Count;

                foreach (UpdateCategoryWorkOutPlan item in Input.lstWorkOutFoodMenu)
                {
                    if (await UpdateCategoryWorkOutPlanAsync("Update", item) == 1)
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
                        Response = "WorkOut Updated Successfully !!!."
                    };
                }
                else
                {
                    string Res = string.Empty;
                    int status = 0;
                    status = 0;
                    Res = "WorkOut Is Already Exists !!!";

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
        private async Task<int> UpdateCategoryWorkOutPlanAsync(string Qtype, UpdateCategoryWorkOutPlan Input)

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
             
                SqlParameter workoutTypeId = new SqlParameter
                {
                    ParameterName = "workoutTypeId",
                    Value = Input.workoutTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter workoutCatTypeId = new SqlParameter
                {
                    ParameterName = "workoutCatTypeId",
                    Value = Input.workoutCatTypeId,
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
                    uniqueId, workoutTypeId, workoutCatTypeId, activeStatus, categoryId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                DB_Response response = await ExecuteNonQueryAsync("usp_MstrCategoryWorkOutPlan", ListOfParameter);

                return response.StatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch getMstrCategoryWorkOutPlan details from db
        /// </summary>
        /// <param name="Input">CategoryWorkOutPlan_In class as input parameter</param>
        /// <returns>list of Jarray as output</returns>
        public async Task<string> UD_GetCategoryWorkOutPlanAsync(CategoryWorkOutPlan_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getMstrCategoryWorkOutPlan",
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
                SqlParameter[] allParameters = { queryType, categoryId, gymOwnerId, branchId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrWorkOutPlan", allParameters);
                return dt.Rows[0]["CategoryWorkOutPlan"].ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// this method is used to fetch getMstrCategoryWorkOutPlan details from db
        /// </summary>
        /// <param name="Input">CategoryWorkOutPlan_In class as input parameter</param>
        /// <returns>list of Jarray as output</returns>
        public async Task<string> UD_GetPublicCategoryWorkOutPlanAsync(CategoryWorkOutPlan_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetPublicCategoryWorkOutPlan",
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
                SqlParameter[] allParameters = { queryType, categoryId, gymOwnerId, branchId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrWorkOutPlan", allParameters);
                return dt.Rows[0]["CategoryWorkOutPlan"].ToString();

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
        public async Task<string> UD_GetWorkOutMstrAsync(CategoryWorkOut_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getMstrWorkOut",
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
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrWorkOutPlan", allParameters);
                return dt.Rows[0]["CategoryWorkOutPlan"].ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<JArray> UD_GetCategoryAsync(CategoryWorkOut_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getMstrCategoryWorkOut",
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
                SqlParameter[] allParameters = { queryType, branchId, gymOwnerId };

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}