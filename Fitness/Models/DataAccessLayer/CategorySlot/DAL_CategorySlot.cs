using Fitness.Helper;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.CategorySlot.BOL_CategorySlot;
using Newtonsoft.Json.Linq;
using static Fitness.Models.BusinessObject.OwnerMaster.BOL_MstrOwner;

namespace Fitness.Models.DataAccessLayer.CategorySlot
{
    public class DAL_CategorySlot : SqlHelper
    {
        readonly private static string GetProcedureName;
        static DAL_CategorySlot()
        {
            GetProcedureName = "usp_GetMstrCategorySlot";
        }
        /// <summary>
        /// this method is used for insert
        /// </summary>
        /// <param name="Input">InsertFintnessCategorySlots_In class as update</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertCategorySlot(InsertCategorySlots_In Input)
        {
            try
            {
                int InsertCount = 0;
                int totalDataForInsert = Input.lstOfCategorySlots.Count;
                string res = string.Empty;
                string[] respo;
                foreach (CategorySlots item in Input.lstOfCategorySlots)
                {
                    DB_Response ds = await InsertCategorySlotsAsync("Insert", item);
                    if (ds.StatusCode == 1)
                    {
                        InsertCount++;
                        res += ds.Response + ',';
                    }
                    else
                    {
                        res += ds.Response + ',';
                    }
                  
                }

                DB_Response response = new DB_Response();

                if (InsertCount == totalDataForInsert)
                {
                    response = new DB_Response()
                    {
                        StatusCode = 1,
                        Response = " Category Slots Inserted Successfully !!!."
                    };
                }
                else
                {
                    response = new DB_Response()
                    {
                        StatusCode = 0,
                        Response = $"{res}"
                    };
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task<DB_Response> InsertCategorySlotsAsync(string QType, CategorySlots Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = QType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter slotId = new SqlParameter
                {
                    ParameterName = "slotId",
                    Value = Input.slotId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter gymStrength = new SqlParameter
                {
                    ParameterName = "gymStrength",
                    Value = Input.gymStrength,
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
                SqlParameter trainingTypeId = new SqlParameter
                {
                    ParameterName = "trainingTypeId",
                    Value = Input.trainingTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
            
                SqlParameter trainerId = new SqlParameter
                {
                    ParameterName = "trainerId",
                    Value = Input.trainerId,
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
                
                SqlParameter[] allParameters = { QueryType, branchId, gymStrength, gymOwnerId,slotId,
                     categoryId, trainingTypeId, trainerId,createdBy};

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                DB_Response response = await ExecuteNonQueryAsync("usp_MstrCategorySlot", ListOfParameter);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<DB_Response> UD_UpdateCategorySlot(UpdateCategorySlots_In Input)
        {
            try
            {
                int InsertCount = 0;
                int totalDataForInsert = Input.lstOfCategorySlots.Count;
                string res=string.Empty;
                string[] respo;
                foreach (UpdateCategorySlots item in Input.lstOfCategorySlots)
                {
                    DB_Response ds = await UD_UpdateMstrSlotAsyc(item);
                    if (ds.StatusCode == 1)
                    {
                        InsertCount++;
                        res += ds.Response + ',';
                    }
                    else
                    {
                        res += ds.Response + ',';
                    }

                }

                DB_Response response = new DB_Response();

                if (InsertCount == totalDataForInsert)
                {
                    response = new DB_Response()
                    {
                        StatusCode = 1,
                        Response = " Category Slots Updated Successfully !!!."
                    };
                }
                else
                {
                    respo = res.Split(',');
                    response = new DB_Response()
                    {
                        StatusCode = 0,
                        Response = $"{res}"
                    };
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<DB_Response> UD_UpdateMstrSlotAsyc(UpdateCategorySlots Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter slotId = new SqlParameter
                {
                    ParameterName = "slotId",
                    Value = Input.slotId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter categorySlotId = new SqlParameter
                {
                    ParameterName = "categorySlotId",
                    Value = Input.categorySlotId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter gymStrength = new SqlParameter
                {
                    ParameterName = "gymStrength",
                    Value = Input.gymStrength,
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
                SqlParameter trainingTypeId = new SqlParameter
                {
                    ParameterName = "trainingTypeId",
                    Value = Input.trainingTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter trainerId = new SqlParameter
                {
                    ParameterName = "trainerId",
                    Value = Input.trainerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter activeStatus = new SqlParameter
                {
                    ParameterName = "activeStatus",
                    Value = Input.activeStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };

                SqlParameter[] allParameters = { QueryType,categorySlotId, branchId, gymStrength, gymOwnerId,slotId,
                     categoryId, trainingTypeId, trainerId,updatedBy,activeStatus };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);


                DB_Response response = await ExecuteNonQueryAsync("usp_MstrCategorySlot", ListOfParameter);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> UD_GetCategorySlotAsync(GetCategorySlots_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetMstrCategorySlot",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value =Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
               

                SqlParameter[] allParameters = { queryType , gymOwnerId, branchId };

                DataTable dt = await GetDataTableFromUSPAsync(GetProcedureName, allParameters);

                return dt.Rows[0]["CategorySlot"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<JArray> UD_GetMstrCategorySlotDetails(GetCategorySlotsDetails_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetMstrCategorySlotDetails",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
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
                     SqlParameter trainingTypeId = new SqlParameter
                {
                    ParameterName = "trainingTypeId",
                    Value = Input.trainingTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                     SqlParameter trainerId = new SqlParameter
                {
                    ParameterName = "trainerId",
                    Value = Input.trainerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };


                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, categoryId, trainingTypeId, trainerId };

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}