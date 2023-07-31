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
using static Fitness.Models.BusinessObject.SingleLogin.BOL_SingleLogin;
namespace Fitness.Models.DataAccessLayer.SingleLogin
{
    public class DAL_SingleLogin : SqlHelper
    {
        readonly private string LoginAndReLoginProcedureName;
        readonly private string GetSessionIdProcedureName;
        public DAL_SingleLogin()
        {
            LoginAndReLoginProcedureName = "usp_SingleLogin";
            GetSessionIdProcedureName = "usp_GetUserSessionId";
        }

        /// <summary>
        /// this method is used to Login 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<DB_Response> UD_UpdateSingleLoginAsync(UpdateSingleLogin_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter()
                {
                    ParameterName = "QueryType",
                    Value = "Login",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                };
                SqlParameter SessionId = new SqlParameter()
                {
                    ParameterName = "SessionId",
                    Value = Input.SessionId.Trim(),
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                };
                SqlParameter UserId = new SqlParameter()
                {
                    ParameterName = "UserId",
                    Value = Input.UserId,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] parameterArr = { QueryType, SessionId, UserId };

                return await GetResponseFromExecuteNonQueryAsync(LoginAndReLoginProcedureName, parameterArr);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// this method is used to ReLogin 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<DB_Response> UD_UpdateSingleReLoginAsync(UpdateSingleReLogin_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter()
                {
                    ParameterName = "QueryType",
                    Value = "ReLogin",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                };
                SqlParameter SessionId = new SqlParameter()
                {
                    ParameterName = "SessionId",
                    Value = Input.SessionId.Trim(),
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                };
                SqlParameter UserId = new SqlParameter()
                {
                    ParameterName = "UserId",
                    Value = Input.UserId,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] parameterArr = { QueryType, SessionId, UserId };

                return await GetResponseFromExecuteNonQueryAsync(LoginAndReLoginProcedureName, parameterArr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to get sessionID of a user   
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<JArray> UD_GetUserSessionId (GetUserSessionId_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter()
                {
                    ParameterName = "QueryType",
                    Value = "GetSessioId",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                };
         
                SqlParameter UserId = new SqlParameter()
                {
                    ParameterName = "UserId",
                    Value = Input.UserId,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter SessionId = new SqlParameter()
                {
                    ParameterName = "SessionId",
                    Value = Input.SessionId.Trim(),
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                };
                SqlParameter[] parameterArr = { QueryType, UserId, SessionId };

                return await GetResultFromGetDataTableFromUSPAsync(GetSessionIdProcedureName, parameterArr);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}