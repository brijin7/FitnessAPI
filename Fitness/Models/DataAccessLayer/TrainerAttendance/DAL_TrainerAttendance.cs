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
using static Fitness.Models.BusinessObject.TrainerAttendance.BOL_UserAttendance;

namespace Fitness.Models.DataAccessLayer.TrainerAttendance
{

    public class DAL_TrainerAttendance : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);
        /// <summary>
        /// this method is used to fetch TrainerAttendance details from db
        /// </summary>
        /// <param name="Input">GetTrainerAttendance_In class as input parameter</param>
        /// <returns>list of GetTrainerAttendance_Out as output</returns>
        public async Task<JArray> UD_GetTrainerAttendanceAsync(GetTrainerAttendance_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getTrainerAttendance",
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
                SqlParameter date = new SqlParameter
                {
                    ParameterName = "date",
                    Value = DateTime.Parse(Input.date, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 200
                };

                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, date };

                return await GetResultFromGetDataTableFromUSPAsync("usp_GetTran_TrainerAttendance", allParameters);
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
        public async Task<DB_Response> UD_InsertTrainerAttendanceAsync(InsertTrainerAttendance_In Input)
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
                SqlParameter empId = new SqlParameter
                {
                    ParameterName = "empId",
                    Value = Input.empId,
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

                SqlParameter[] allParameters = { QueryType, gymOwnerId, branchId, empId, logDate, inTime, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_TranTrainerAttendance", ListOfParameter);
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
        public async Task<DB_Response> UD_UpdateTrainerAttendanceMstrAsync(UpdateTrainerAttendance_In Input)
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
                SqlParameter empId = new SqlParameter
                {
                    ParameterName = "empId",
                    Value = Input.empId,
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

                SqlParameter[] allParameters = { QueryType, empId, gymOwnerId, branchId, outTime, inTime, UniqueId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_TranTrainerAttendance", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}