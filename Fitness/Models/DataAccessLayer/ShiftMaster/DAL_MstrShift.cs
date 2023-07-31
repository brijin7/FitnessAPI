using Fitness.Helper;
using Fitness.Models.CommonModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.ShiftMaster.BOL_MstrShift;

namespace Fitness.Models.DataAccessLayer.ShiftMaster
{
    public class DAL_MstrShift : SqlHelper
    {
        readonly private static string GetProcedureName;
        static DAL_MstrShift()
        {
            GetProcedureName = "usp_GetMstrShift";
        }
        /// <summary>
        /// this method is used to insert details in Shiftmstr in db
        /// </summary>
        /// <param name="Input">InsertShift_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertShiftMasterAsync(InsertShift_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "QueryType",
                    Value = "Insert",
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
                SqlParameter shiftName = new SqlParameter
                {
                    ParameterName = "shiftName",
                    Value = Input.shiftName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter startTime = new SqlParameter
                {
                    ParameterName = "startTime",
                    Value = Input.startTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter endTime = new SqlParameter
                {
                    ParameterName = "endTime",
                    Value = Input.endTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter breakStartTime = new SqlParameter
                {
                    ParameterName = "breakStartTime",
                    Value = Input.breakStartTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter breakEndTime = new SqlParameter
                {
                    ParameterName = "breakEndTime",
                    Value = Input.breakEndTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter gracePeriod = new SqlParameter
                {
                    ParameterName = "gracePeriod",
                    Value = Input.gracePeriod,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, branchId, shiftName, startTime, endTime, breakStartTime, breakEndTime, gracePeriod, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrShift", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch Shiftmstr details from db
        /// </summary>
        /// <param name="Input">GetShiftMstr_In class as input parameter</param>
        /// <returns>list of GetShiftMstr_Out as output</returns>
        public async Task<JArray> UD_GetShiftMstrAsync()
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getShift",
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
        /// <summary>
        /// this method is used to fetch Shiftmstr details based on branch from db
        /// </summary>
        /// <param name="Input">GetShiftMstr_In class as input parameter</param>
        /// <returns>list of GetShiftMstr_Out as output</returns>
        public async Task<JArray> UD_GetShiftMstrBasedOnBranchAsync(GetShiftMstr_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getShiftBasedOnBranch",
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
                SqlParameter[] allParameters = { queryType, branchId };

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// this method is used to fetch ddlShiftmstr details from db
        /// </summary>
        /// <param name="Input">GetddlShiftMstr_In class as input parameter</param>
        /// <returns>list of GetddlShiftMstr_Out as output</returns>
        public async Task<JArray> UD_GetddlShiftMstrAsync(ddlGetShiftMstr_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "ddlgetShift",
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
                SqlParameter[] allParameters = { queryType, branchId };

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to update Shiftmstr details in db
        /// </summary>
        /// <param name="Input">UpdateShiftMstr_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateShiftMstrAsync(UpdateShiftMstr_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "QueryType",
                    Value = "Update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter shiftId = new SqlParameter
                {
                    ParameterName = "shiftId",
                    Value = Input.shiftId,
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
                SqlParameter shiftName = new SqlParameter
                {
                    ParameterName = "shiftName",
                    Value = Input.shiftName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter startTime = new SqlParameter
                {
                    ParameterName = "startTime",
                    Value = Input.startTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter endTime = new SqlParameter
                {
                    ParameterName = "endTime",
                    Value = Input.endTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter breakStartTime = new SqlParameter
                {
                    ParameterName = "breakStartTime",
                    Value = Input.breakStartTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter breakEndTime = new SqlParameter
                {
                    ParameterName = "breakEndTime",
                    Value = Input.breakEndTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter gracePeriod = new SqlParameter
                {
                    ParameterName = "gracePeriod",
                    Value = Input.gracePeriod,
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

                SqlParameter[] allParameters = { QueryType, shiftId, branchId, shiftName, startTime, endTime, breakStartTime, breakEndTime, gracePeriod, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrShift", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate Shift master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateShiftMstr_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateShiftMstrAsyn(ActivateOrInactivateShiftMstr_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "QueryType",
                    Value = Input.QueryType,
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
                SqlParameter shiftId = new SqlParameter
                {
                    ParameterName = "shiftId",
                    Value = Input.shiftId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { QueryType, updatedBy, shiftId };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrShift", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}