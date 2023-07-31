using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Fitness.Helper;
using Fitness.Models.CommonModels;

using static Fitness.Models.BusinessObject.TrainerReassign.BOL_TrainerReassign;
using Newtonsoft.Json.Linq;

namespace Fitness.Models.DataAccessLayer.TrainerReassign
{
    public class DAL_TrainerReassign : SqlHelper
    {
        
        IFormatProvider obj = new System.Globalization.CultureInfo("en-GB", true);
        readonly private static string GetProcedureName;
        static DAL_TrainerReassign()
        {
            GetProcedureName = "usp_GetMstrTrainerReassign";
        }
        /// <summary>
        /// this method is used for insert
        /// </summary>
        /// <param name="Input">InsertFintnessCategorySlots_In class as update</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertTrainerReassign(InsertTrainerReassign_In Input)
        {
            try
            {
                int InsertCount = 0;
                int totalDataForInsert = Input.lstTrainerReAssign.Count;

                foreach (TrainerReassigns item in Input.lstTrainerReAssign)
                {
                    if (await InsertTrainerAssignAsync("Insert", item) == 1)
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
                        Response = " Trainer ReAssigned Successfully !!!."
                    };
                }
                else
                {
                    response = new DB_Response()
                    {
                        StatusCode = 0,
                        Response = $"'{InsertCount}' Trainer ReAssigned  Out Of '{totalDataForInsert} ',Trainer Reassign Details Is Already Exists !!!"
                    };
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task<int> InsertTrainerAssignAsync(string QType, TrainerReassigns Input)
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
                SqlParameter newTrainerId = new SqlParameter
                {
                    ParameterName = "newTrainerId",
                    Value = Input.newTrainerId,
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

                SqlParameter oldTrainerId = new SqlParameter
                {
                    ParameterName = "oldTrainerId",
                    Value = Input.oldTrainerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter fromDate = new SqlParameter
                {
                    ParameterName = "fromDate",
                    Value = DateTime.Parse(Input.fromDate, obj),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter toDate = new SqlParameter
                {
                    ParameterName = "toDate",
                    Value = DateTime.Parse(Input.toDate, obj),
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

                SqlParameter[] allParameters = { QueryType, branchId, newTrainerId, gymOwnerId,slotId,
                     categoryId, trainingTypeId, oldTrainerId,createdBy,fromDate,toDate};

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                DB_Response response = await ExecuteNonQueryAsync("usp_MstrTrainerReAssign", ListOfParameter);

                return response.StatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<JArray> UD_GetMstrTrainerReassign(GetAbsentTrainer_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = Input.queryType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size=100
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
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter trainingTypeId = new SqlParameter
                {
                    ParameterName = "trainingTypeId",
                    Value = Input.trainingTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter trainerId = new SqlParameter
                {
                    ParameterName = "trainerId",
                    Value = Input.trainerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter slotId = new SqlParameter
                {
                    ParameterName = "slotId",
                    Value = Input.slotId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size=150
                };
                SqlParameter getdate = new SqlParameter
                {
                    ParameterName = "getdate",
                    Value = Input.getdate,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };

                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, categoryId, trainingTypeId, trainerId, slotId, getdate };

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}