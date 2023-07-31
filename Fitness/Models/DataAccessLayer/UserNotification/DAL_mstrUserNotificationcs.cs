using Fitness.Helper;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Fitness.App_Start;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.UserNotification.BOL_mstrUserNotification;


namespace Fitness.Models.DataAccessLayer.UserNotification
{
    public class DAL_mstrUserNotificationcs : SqlHelper
    {
       
        /// <summary>
        /// this method is used to Insert Send OTP For Users details in db
        /// </summary>
        /// <param name="Input"> Insert Sign Up  Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertMstrUserNotificationAsyc(string userIds, string notifications)
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
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = userIds,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter notification = new SqlParameter
                {
                    ParameterName = "notification",
                    Value = notifications,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 10000
                };

                SqlParameter[] allParameters = { queryType, userId, notification };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrUserNotification", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// this method is used to Insert Send OTP For Users details in db
        /// </summary>
        /// <param name="Input"> Insert Sign Up  Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateMstrUserNotificationAsyc(UpdateMstrUserNotification_In Input)
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
                SqlParameter notificationId = new SqlParameter
                {
                    ParameterName = "notificationId",
                    Value = Input.notificationId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, notificationId};
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrUserNotification", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// this method is used to fetch FitnessCatogoryPrice  details from db
        /// </summary>
        /// <param name="Input">GetPriceDetails_In class as input parameter</param>
        /// <returns>list of GetPriceDetails_Out as output</returns>

        public async Task<JArray> GetMstrUserNotificationAsync(GetMstrUserNotification_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getUserNotification",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter readstatus = new SqlParameter
                {
                    ParameterName = "readstatus",
                    Value = Input.readstatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                };

                SqlParameter[] allParameters = { queryType, userId, readstatus };
                return await GetResultFromGetDataTableFromUSPAsync("usp_GetMstrUserNotification", allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}