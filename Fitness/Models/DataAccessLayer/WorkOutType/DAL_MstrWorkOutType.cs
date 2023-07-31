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
using static Fitness.Models.BusinessObject.WorkOutType.BOL_MstrWorkoutType;

namespace Fitness.Models.DataAccessLayer.WorkOutType
{
    public class DAL_MstrWorkOutType : SqlHelper
    {
        /// <summary>
        /// this method is used to fetch configmaster details from db
        /// </summary>
        /// <param name="Input">GetMstrWorkoutType_In class as input parameter</param>
        /// <returns>list of GetMstrWorkoutType_Out as output</returns>
        public async Task<List<GetMstrWorkoutType_Out>> UD_GetMstrWorkoutTypeAsync(GetMstrWorkoutType_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetWorkOutType",
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrWorkOutType", allParameters);

                List<GetMstrWorkoutType_Out> lstOfOutput = new List<GetMstrWorkoutType_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetMstrWorkoutType_Out Output = new GetMstrWorkoutType_Out();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.workoutTypeId = (int)(dr["workoutTypeId"]);
                    Output.workoutCatTypeId = (int)(dr["workoutCatTypeId"]);
                    Output.workoutTypeName = dr["workoutTypeName"].ToString();
                    Output.workoutType = dr["workoutType"].ToString();
                    Output.description = dr["description"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.video = dr["video"].ToString();
                    Output.calories = dr["calories"].ToString();
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
        /// this method is used to fetch configmaster details from db
        /// </summary>
        /// <param name="Input">GetMstrWorkoutType_In class as input parameter</param>
        /// <returns>list of GetMstrWorkoutType_Out as output</returns>
        public async Task<List<GetMstrWorkoutTypeSub_Out>> UD_GetMstrWorkoutTypeSubAsync(GetMstrWorkoutTypeSub_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetWorkOutSubCategory",
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
                SqlParameter workoutCatTypeId = new SqlParameter
                {
                    ParameterName = "workoutCatTypeId",
                    Value = Input.workoutCatTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, workoutCatTypeId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrWorkOutType", allParameters);

                List<GetMstrWorkoutTypeSub_Out> lstOfOutput = new List<GetMstrWorkoutTypeSub_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetMstrWorkoutTypeSub_Out Output = new GetMstrWorkoutTypeSub_Out();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.workoutTypeId = (int)(dr["workoutTypeId"]);
                    Output.workoutCatTypeId = (int)(dr["workoutCatTypeId"]);
                    Output.workoutTypeName = dr["workoutTypeName"].ToString();
                    Output.workoutType = dr["workoutType"].ToString();
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
        /// this method is used to update WorkOutTypemaster details in db
        /// </summary>
        /// <param name="Input"> Update WorkOutType Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateMstrWorkoutTypeAsyc(UpdateMstrWorkoutType_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
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
                    SqlDbType = SqlDbType.Int,
                    Size = 50
                };
                SqlParameter workoutType = new SqlParameter
                {
                    ParameterName = "workoutType",
                    Value = Input.workoutType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter description = new SqlParameter
                {
                    ParameterName = "description",
                    Value = Input.description == "" ? null : Input.description,
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
                SqlParameter video = new SqlParameter
                {
                    ParameterName = "video",
                    Value = Input.video == "" ? null : Input.video,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 200
                };
                SqlParameter calories = new SqlParameter
                {
                    ParameterName = "calories",
                    Value = Input.calories == "" ? null : Input.calories,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId,
                    workoutTypeId,  workoutCatTypeId,workoutType, description, imageUrl, video,calories, updatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrWorkOutType", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// this method is used to Insert WorkoutType details in db
        /// </summary>
        /// <param name="Input"> Insert WorkoutType Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertMstrWorkoutTypeAsyc(InsertMstrWorkoutType_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
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

                SqlParameter workoutCatTypeId = new SqlParameter
                {
                    ParameterName = "workoutCatTypeId",
                    Value = Input.workoutCatTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 50
                };
                SqlParameter workoutType = new SqlParameter
                {
                    ParameterName = "workoutType",
                    Value = Input.workoutType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter description = new SqlParameter
                {
                    ParameterName = "description",
                    Value = Input.description==""?null : Input.description,
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
                SqlParameter video = new SqlParameter
                {
                    ParameterName = "video",
                    Value = Input.video == "" ? null : Input.video,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 200
                };
                SqlParameter calories = new SqlParameter
                {
                    ParameterName = "calories",
                    Value = Input.calories == "" ? null : Input.calories,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };

                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId
                    , workoutCatTypeId,workoutType, description, imageUrl, video,calories, createdBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrWorkOutType", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate WorkoutType master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateMstrWorkoutType_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateMstrWorkoutTypAsyc(ActivateOrInactivateMstrWorkoutType_In Input)
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
                SqlParameter workoutTypeId = new SqlParameter
                {
                    ParameterName = "workoutTypeId",
                    Value = Input.workoutTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };


                SqlParameter[] allParameters = { queryType, workoutTypeId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrWorkOutType", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}