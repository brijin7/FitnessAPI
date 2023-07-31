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
using static Fitness.Models.BusinessObject.LiveConfig.BOL_MstrLiveConfig;

namespace Fitness.Models.DataAccessLayer.LiveConfig
{
    
    public class DAL_MstrLiveConfig : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);
        /// <summary>
        /// this method is used to insert details in LiveConfig in db
        /// </summary>
        /// <param name="Input">InsertLiveConfig_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertLiveConfigMasterAsync(InsertLiveConfig_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter gymownerId = new SqlParameter
                {
                    ParameterName = "gymownerId",
                    Value = Input.gymownerId,
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
                SqlParameter liveurl = new SqlParameter
                {
                    ParameterName = "liveurl",
                    Value = Input.liveurl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size=100
                };
                SqlParameter livedate = new SqlParameter
                {
                    ParameterName = "livedate",
                    Value = DateTime.Parse(Input.livedate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime
                };
                SqlParameter purposename = new SqlParameter
                {
                    ParameterName = "purposename",
                    Value = Input.purposename,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size=50

                };
                SqlParameter trainingTypeId = new SqlParameter
                {
                    ParameterName = "trainingTypeId",
                    Value = Input.trainingTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter slotId = new SqlParameter
                {
                    ParameterName = "slotId",
                    Value = Input.slotId,
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
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
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

                SqlParameter[] allParameters = { QueryType, gymownerId, branchId,liveurl, livedate, purposename, trainingTypeId, slotId, trainerId, categoryId,createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrLiveConfig", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DB_Response> UD_SmsSendForAllUSerAsync(SendSmsForAllUSerLiveUrl_In Input)
        {
            try
            {
                
                SqlParameter gymownerId = new SqlParameter
                {
                    ParameterName = "gymownerId",
                    Value = Input.gymownerId,
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
                SqlParameter SMSBody = new SqlParameter
                {
                    ParameterName = "SMSBody",
                    Value = Input.SMSBody,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size=200
                };
                SqlParameter[] allParameters = {  gymownerId, branchId,SMSBody};

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("SendSmsForLiveConfig", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch LiveConfig details from db
        /// </summary>
        /// <param name="Input">GetCategoryMstr_In class as input parameter</param>
        /// <returns>list of GetCategoryMstr_Out as output</returns>
        public async Task<List<GetLiveConfigMstr_Out>> UD_GetLiveConfigMstrAsync()
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getLiveConfig",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter[] allParameters = { queryType };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrLiveConfig", allParameters);

                List<GetLiveConfigMstr_Out> lstOfOutput = new List<GetLiveConfigMstr_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetLiveConfigMstr_Out Output = new GetLiveConfigMstr_Out();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.gymownerId = (int)(dr["gymownerId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.liveurl = dr["liveurl"].ToString();
                    Output.livedate = dr["livedate"].ToString();
                    Output.purposename = dr["purposename"].ToString();
                    Output.activeStatus = dr["activeStatus"].ToString();
                    Output.trainerId = (int)(dr["trainerId"]);
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeNameId = (int)(dr["trainingTypeNameId"]);
                    Output.slotId = (int)(dr["slotId"]);
                    Output.trainerName = dr["trainerName"].ToString();
                    Output.SlotTime = dr["SlotTime"].ToString();
                    Output.categoryName = dr["categoryName"].ToString();
                    Output.configName = dr["configName"].ToString();

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
        /// this method is used to fetch LiveConfig details from db
        /// </summary>
        /// <param name="Input">GetCategoryMstr_In class as input parameter</param>
        /// <returns>list of GetCategoryMstr_Out as output</returns>
        public async Task<List<GetLiveConfigMstr_Out>> UD_GetLiveDateConfigMstrAsync(GetLiveConfigMstr_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getLiveDateConfig",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
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
                SqlParameter trainerId = new SqlParameter
                {
                    ParameterName = "trainerId",
                    Value = Input.trainerId,
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
                SqlParameter slotId = new SqlParameter
                {
                    ParameterName = "slotId",
                    Value = Input.slotId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter date = new SqlParameter
                {
                    ParameterName = "date",
                    Value = DateTime.Parse(Input.date, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };

                SqlParameter[] allParameters = { queryType, branchId, categoryId, slotId, trainingTypeId, trainerId,date };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrLiveConfig", allParameters);

                List<GetLiveConfigMstr_Out> lstOfOutput = new List<GetLiveConfigMstr_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetLiveConfigMstr_Out Output = new GetLiveConfigMstr_Out();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.gymownerId = (int)(dr["gymownerId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.liveurl = dr["liveurl"].ToString();
                    Output.livedate = dr["livedate"].ToString();
                    Output.purposename = dr["purposename"].ToString();
                    Output.trainerId = (int)(dr["trainerId"]);
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeNameId = (int)(dr["trainingTypeNameId"]);
                    Output.slotId = (int)(dr["slotId"]);
                    Output.trainerName = dr["trainerName"].ToString();
                    Output.SlotTime = dr["SlotTime"].ToString();
                    Output.categoryName = dr["categoryName"].ToString();
                    Output.configName = dr["configName"].ToString();
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
        /// this method is used to fetch LiveConfig details from db
        /// </summary>
        /// <param name="Input">GetCategoryMstr_In class as input parameter</param>
        /// <returns>list of GetCategoryMstr_Out as output</returns>
        public async Task<List<GetLiveConfigMstr_Out>> UD_GetLiveBranchownerConfigMstrAsync(GetLiveBranchownerConfigMstr_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getBranchownerConfig",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter gymownerId = new SqlParameter
                {
                    ParameterName = "gymownerId",
                    Value = Input.gymownerId,
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

                SqlParameter[] allParameters = { queryType, branchId, gymownerId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrLiveConfig", allParameters);

                List<GetLiveConfigMstr_Out> lstOfOutput = new List<GetLiveConfigMstr_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetLiveConfigMstr_Out Output = new GetLiveConfigMstr_Out();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.gymownerId = (int)(dr["gymownerId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.liveurl = dr["liveurl"].ToString();
                    Output.livedate = dr["livedate"].ToString();
                    Output.purposename = dr["purposename"].ToString();
                    Output.activeStatus = dr["activeStatus"].ToString();
                    Output.trainerId = (int)(dr["trainerId"]);
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeNameId = (int)(dr["trainingTypeNameId"]);
                    Output.slotId = (int)(dr["slotId"]);
                    Output.trainerName = dr["trainerName"].ToString();
                    Output.SlotTime = dr["SlotTime"].ToString();
                    Output.categoryName = dr["categoryName"].ToString();
                    Output.configName = dr["configName"].ToString();

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
        /// this method is used to update LiveConfig details in db
        /// </summary>
        /// <param name="Input">UpdateCategoryMstr_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateLiveConfigMstrAsync(UpdateLiveConfigMstr_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Update",
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
                SqlParameter gymownerId = new SqlParameter
                {
                    ParameterName = "gymownerId",
                    Value = Input.gymownerId,
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
                SqlParameter liveurl = new SqlParameter
                {
                    ParameterName = "liveurl",
                    Value = Input.liveurl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter livedate = new SqlParameter
                {
                    ParameterName = "livedate",
                    Value = DateTime.Parse(Input.livedate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime
                };
                SqlParameter purposename = new SqlParameter
                {
                    ParameterName = "purposename",
                    Value = Input.purposename,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter trainingTypeId = new SqlParameter
                {
                    ParameterName = "trainingTypeId",
                    Value = Input.trainingTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter slotId = new SqlParameter
                {
                    ParameterName = "slotId",
                    Value = Input.slotId,
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
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
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

                SqlParameter[] allParameters = { QueryType, uniqueId, gymownerId, branchId, liveurl, livedate, purposename, trainingTypeId, slotId, trainerId, categoryId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrLiveConfig", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate LiveConfig master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateCategoryMstr_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateLiveConfigMstrAsyn(ActivateOrInactivateLiveConfigMstr_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
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
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { QueryType, updatedBy, uniqueId };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrLiveConfig", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
