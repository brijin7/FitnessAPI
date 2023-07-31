using Fitness.Helper;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Fitness.App_Start;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.SignUpandSignIn.BOL_SignUpandSignIn;
using Newtonsoft.Json.Linq;

namespace Fitness.Models.DataAccessLayer.SignUpandSignIn
{
    public class DAL_SignUpandSignIn :SqlHelper
    {
        /// this method is used to fetch SignIn details from db
        /// </summary>
        /// <param name="Input">GetMstrUser_In class as input parameter</param>
        /// <returns>list of GetMstrUser_Out as output</returns>
        public async Task<JArray> UD_GetMstrSignInAsync(InsertMstrUserSignIn_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "signIn",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter mobileNo = new SqlParameter
                {
                    ParameterName = "mobileNo",
                    Value = Input.mobileNo,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter[] allParameters = { queryType, mobileNo };

                //     DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrUser", allParameters);

                //List<InsertMstrUserSignIn_Out> lstOfOutput = new List<InsertMstrUserSignIn_Out>();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    InsertMstrUserSignIn_Out Output = new InsertMstrUserSignIn_Out();
                //    Output.userId = Convert.ToInt32(dr["userId"]);
                //    Output.roleId = dr["roleId"].ToString();
                //    Output.roleName = dr["roleName"].ToString();
                //    Output.UserName = dr["UserName"].ToString();
                //    Output.roleName = dr["roleName"].ToString();
                //    Output.mobileNo = dr["mobileNo"].ToString();
                //    Output.Image = dr["Image"].ToString();
                //    Output.mailId = dr["mailId"].ToString();
                //    Output.activeStatus = dr["activeStatus"].ToString();
                //    Output.gymOwnerId = dr["gymOwnerId"].ToString();
                //    Output.branchId = dr["branchId"].ToString();
                //    lstOfOutput.Add(Output);
                //}

                //return lstOfOutput;

                return await GetResultFromGetDataTableFromUSPAsync("usp_GetMstrUser", allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to Insert Sign Up For Users details in db
        /// </summary>
        /// <param name="Input"> Insert Sign Up  Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertMstrUserSignUpAsyc(InsertMstrUserSignUp_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "signUp",
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
                SqlParameter mailId = new SqlParameter
                {
                    ParameterName = "mailId",
                    Value = Input.mailId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };

                SqlParameter[] allParameters = { queryType, mobileNo, mailId };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrSignUp", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// this method is used to Update Password For Users details in db
        /// </summary>
        /// <param name="Input"> Update Password Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateMstrUserPasswordAsyc(UpdateMstrUserPassword_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "updatePassword",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
               
                SqlParameter passWord = new SqlParameter
                {
                    ParameterName = "passWord",
                    Value = StrEncryption.Encrypt(Input.passWord),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };

                SqlParameter[] allParameters = { queryType, userId, passWord };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrUser", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}