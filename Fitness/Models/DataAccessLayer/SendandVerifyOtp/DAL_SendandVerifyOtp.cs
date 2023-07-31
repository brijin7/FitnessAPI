using Fitness.Helper;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Fitness.App_Start;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.SendandVerifyOtp.BOL_SendandVerifyOtp;

namespace Fitness.Models.DataAccessLayer.SendandVerifyOtp
{
    public class DAL_SendandVerifyOtp :SqlHelper
    {
        /// <summary>
        /// this method is used to Insert Send OTP For Users details in db
        /// </summary>
        /// <param name="Input"> Insert Sign Up  Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertMstrUserSendOtpAsyc(InsertMstrUserSendOtp_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = Input.queryType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter mobileNo = new SqlParameter
                {
                    ParameterName = "mobileNo",
                    Value = Input.mobileNo,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 15
                };


                SqlParameter[] allParameters = { queryType, mobileNo };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrSendAndVerifyOtp", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// this method is used to Insert Verify OTP For Users details in db
        /// </summary>
        /// <param name="Input"> Insert Sign Up  Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertMstrUserVerifyOtpAsyc(InsertMstrUserVerifyOtp_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "verifyOtp",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter mobileNo = new SqlParameter
                {
                    ParameterName = "mobileNo",
                    Value = Input.mobileNo,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 15
                };
                SqlParameter otp = new SqlParameter
                {
                    ParameterName = "otp",
                    Value = Input.otp,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };


                SqlParameter[] allParameters = { queryType, mobileNo, otp };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrSendAndVerifyOtp", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}