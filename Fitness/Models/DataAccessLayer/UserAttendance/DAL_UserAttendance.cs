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
using Newtonsoft.Json.Linq;
using static Fitness.Models.BusinessObject.UserAttendance.BOL_UserAttendance;

namespace Fitness.Models.DataAccessLayer.UserAttendance
{
    public class DAL_UserAttendance : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);
        /// <summary>
        /// this method is used to fetch UserAttendance details from db
        /// </summary>
        /// <param name="Input">GetUserAttendance_In class as input parameter</param>
        /// <returns>list of GetUserAttendance_Out as output</returns>
        public async Task<JArray> UD_GetUserAttendanceAsync(GetUserAttendance_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getUserAttendance",
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
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };

                SqlParameter trainerId = new SqlParameter
                {
                    ParameterName = "trainerId",
                    Value = Input.trainerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, trainerId, userId };

                return await GetResultFromGetDataTableFromUSPAsync("usp_GetTran_UserAttendance", allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// this method is used to fetch UserAttendance details from db
        /// </summary>
        /// <param name="Input">GetUserAttendance_In class as input parameter</param>
        /// <returns>list of GetUserAttendance_Out as output</returns>
        public async Task<JArray> UD_GetTrainerBasedUsersAsync(GetTrainerBasedUsers_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getTrainerBasedUser",
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
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter trainerId = new SqlParameter
                {
                    ParameterName = "trainerId",
                    Value = Input.trainerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, trainerId };

                return await GetResultFromGetDataTableFromUSPAsync("usp_GetTran_UserAttendance", allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to insert details in categorymstr in db
        /// </summary>
        /// <param name="Input">InsertCategory_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertUserAttendanceAsync(InsertUserAttendance_In Input)
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
              
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter logDate = new SqlParameter
                {
                    ParameterName = "logDate",
                    Value = DateTime.Parse(Input.logDate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 200
                };
                SqlParameter inTime = new SqlParameter
                {
                    ParameterName = "inTime",
                    Value = Input.inTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, gymOwnerId, branchId, userId, logDate, inTime, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_TranUserAttendance", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to update categorymstr details in db
        /// </summary>
        /// <param name="Input">UpdateCategoryMstr_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateUserAttendanceMstrAsync(UpdateUserAttendance_In Input)
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
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter UniqueId = new SqlParameter
                {
                    ParameterName = "uniqueId",
                    Value = Input.UniqueId,
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
                SqlParameter outTime = new SqlParameter
                {
                    ParameterName = "outTime",
                    Value = Input.outTime == "" ? null : Input.outTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter inTime = new SqlParameter
                {
                    ParameterName = "inTime",
                    Value = Input.inTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };

                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, userId, gymOwnerId, branchId, outTime, inTime, UniqueId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_TranUserAttendance", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<DB_Response> UD_UpdateUserAttendanceByTrainerMstrAsync(UpdateUserAttendanceByTrainer_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "UpdateByTrainer",
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
                SqlParameter logDate = new SqlParameter
                {
                    ParameterName = "logDate",
                    Value = DateTime.Parse(Input.logDate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 200
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
                SqlParameter OutTime = new SqlParameter
                {
                    ParameterName = "OutTime",
                    Value = Input.OutTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter inTime = new SqlParameter
                {
                    ParameterName = "inTime",
                    Value = Input.inTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };

                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, userId, logDate, gymOwnerId, branchId, OutTime, inTime, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_TranUserAttendance", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}