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
using static Fitness.Models.BusinessObject.TrainingType.BOL_MstrTrainingType;

namespace Fitness.Models.DataAccessLayer.TrainingType
{
    public class DAL_TrainingType : SqlHelper
    {

        /// <summary>
        /// this method is used to insert details in TrainingType in db
        /// </summary>
        /// <param name="Input">InsertTrainingType_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertMstrTrainingTypeAsync(InsertTrainingType_In Input)
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
                SqlParameter trainingTypeNameId = new SqlParameter
                {
                    ParameterName = "trainingTypeNameId",
                    Value = Input.trainingTypeNameId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 150
                };
                SqlParameter description = new SqlParameter
                {
                    ParameterName = "description",
                    Value = Input.description==""?null: Input.description,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter imageUrl = new SqlParameter
                {
                    ParameterName = "imageUrl",
                    Value = Input.imageUrl == "" ? null : Input.imageUrl,
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

                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, trainingTypeNameId, description, imageUrl,
                        createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrTrainingType", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch trainingType details from db
        /// </summary>
        /// <param name="Input">GetTrainingType_In class as input parameter</param>
        /// <returns>list of GetTrainingType_Out as output</returns>
        public async Task<List<GetTrainingType_Out>> UD_GetTrainingTypeAsync(ddlTrainingType_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getTrainingType",
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
                SqlParameter[] allParameters = { queryType,gymOwnerId,branchId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrTrainingType", allParameters);

                List<GetTrainingType_Out> lstOfOutput = new List<GetTrainingType_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetTrainingType_Out Output = new GetTrainingType_Out();
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.trainingTypeNameId = (int)(dr["trainingTypeNameId"]);
                    Output.trainingTypeName = dr["trainingTypeName"].ToString();
                    Output.description = Convert.ToString(dr["description"]);
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
        /// this method is used to fetch trainingType details from db
        /// </summary>
        /// Created By Abhinaya 
        /// Created Date 02-DEC-2022
        /// <param name="Input">GetTrainingType_In class as input parameter</param>
        /// <returns>list of GetTrainingType_Out as output</returns>
        public async Task<List<ddlTrainingType_Out>> UD_ddlTrainingTypeTypeAsync(ddlTrainingType_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "ddlTrainingType",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                }; SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType , branchId ,gymOwnerId};

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrTrainingType", allParameters);

                List<ddlTrainingType_Out> lstOfOutput = new List<ddlTrainingType_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    ddlTrainingType_Out Output = new ddlTrainingType_Out();
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeNameId = (int)(dr["trainingTypeNameId"]);
                    Output.trainingTypeName = dr["trainingTypeName"].ToString();
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
        /// this method is used to update trainingType details in db
        /// </summary>
        /// <param name="Input">UpdateTrainingType_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdatetrainingTypeAsync(UpdateTrainingType_In Input)
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
                SqlParameter trainingTypeId = new SqlParameter
                {
                    ParameterName = "trainingTypeId",
                    Value = Input.trainingTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
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
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter trainingTypeNameId = new SqlParameter
                {
                    ParameterName = "trainingTypeNameId",
                    Value = Input.trainingTypeNameId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter imageUrl = new SqlParameter
                {
                    ParameterName = "imageUrl",
                    Value = Input.imageUrl == "" ? null : Input.imageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter description = new SqlParameter
                {
                    ParameterName = "description",
                    Value = Input.description == "" ? null : Input.description,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter[] allParameters = { queryType, trainingTypeId, gymOwnerId, branchId, trainingTypeNameId, imageUrl, description, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrTrainingType", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate DietType master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateTrainingType_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateTrainingTypeMstrAsyn(ActivateOrInactivateTrainingType_In Input)
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
                SqlParameter trainingTypeId = new SqlParameter
                {
                    ParameterName = "trainingTypeId",
                    Value = Input.trainingTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType, trainingTypeId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrTrainingType", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}