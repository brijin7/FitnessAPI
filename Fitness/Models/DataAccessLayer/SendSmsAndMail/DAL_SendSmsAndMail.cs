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
using static Fitness.Models.BusinessObject.SendSmsAndMail.BOL_SendSmsAndMail;
using static Fitness.Models.BusinessObject.ConfigMaster.BOL_MstrConfig;

namespace Fitness.Models.DataAccessLayer.SendSmsAndMail
{
    public class DAL_SendSmsAndMail : SqlHelper
    {
        /// <summary>
        /// this method is used to Thos Method Is Used For Send Sms 
        /// </summary>
        /// <param name="Input"> Insert Sign Up  Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_SendSmsandMailAsyc(SendSmsandMailClass Input)
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
                SqlParameter mobileNo = new SqlParameter
                {
                    ParameterName = "MobileNo",
                    Value = Input.mobileNo,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 15
                };
               
                SqlParameter[] allParameters = { queryType ,mobileNo };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrSendAndVerifyOtp", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<List<User>> UD_GetMstrBranchAsync(SendSmsandMailClass Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetMstrUser",
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
              
                SqlParameter[] allParameters = { queryType, userId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrUser", allParameters);

                List<User> lstOfOutput = new List<User>();
                foreach (DataRow dr in dt.Rows)
                {
                    User Output = new User();
                   
                    Output.userId = dr["userId"].ToString();
                    Output.userName = dr["userName"].ToString();
                    Output.mailId = dr["mailId"].ToString();
                    Output.mobileNo = dr["mobileNo"].ToString();

                    lstOfOutput.Add(Output);
                }


                return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<User> UD_GetMstrBranchsAsync(string userIds)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetMstrUser",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = userIds,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType, userId };

                DataTable dt = GetDataTableFromUSP("usp_GetMstrUser", allParameters);

                List<User> lstOfOutput = new List<User>();
                foreach (DataRow dr in dt.Rows)
                {
                    User Output = new User();

                    Output.userId = dr["userId"].ToString();
                    Output.userName = dr["userName"].ToString();
                    Output.mailId = dr["mailId"].ToString();
                    Output.mobileNo = dr["mobileNo"].ToString();

                    lstOfOutput.Add(Output);
                }


                return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<User>> UD_GetMstrBranchBasedOnMobileNoAsync(string mobileNos)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetMstrUserBasedOnMobileNo",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter mobileNo = new SqlParameter
                {
                    ParameterName = "mobileNo",
                    Value = mobileNos,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType, mobileNo };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrUser", allParameters);

                List<User> lstOfOutput = new List<User>();
                foreach (DataRow dr in dt.Rows)
                {
                    User Output = new User();

                    Output.userId = dr["userId"].ToString();
                    Output.userName = dr["userName"].ToString();
                    Output.mailId = dr["mailId"].ToString();
                    Output.mobileNo = dr["mobileNo"].ToString();

                    lstOfOutput.Add(Output);
                }


                return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public  List<User> UD_GetMstrBranchBasedOnMobileNo(string mobileNos)
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
                    Value = mobileNos,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size=50
                };

                SqlParameter[] allParameters = { queryType, mobileNo };

                DataTable dt = GetDataTableFromUSP("usp_GetMstrUser", allParameters);

                List<User> lstOfOutput = new List<User>();
                foreach (DataRow dr in dt.Rows)
                {
                    User Output = new User();

                    Output.userId = dr["userId"].ToString();
                    Output.userName = dr["userName"].ToString();
                    Output.mailId = dr["mailId"].ToString();
                    Output.mobileNo = dr["mobileNo"].ToString();

                    lstOfOutput.Add(Output);
                }


                return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Message> UD_GetMessageTemplate(string messageHeaders, string templateTypes)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getMessge",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter messageHeader = new SqlParameter
                {
                    ParameterName = "messageHeader",
                    Value = messageHeaders,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                SqlParameter templateType = new SqlParameter
                {
                    ParameterName = "templateType",
                    Value = templateTypes,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };

                SqlParameter[] allParameters = { queryType, messageHeader, templateType };

                DataTable dt = GetDataTableFromUSP("usp_GetMstrMessageTemplate", allParameters);

                List<Message> lstOfOutput = new List<Message>();
                foreach (DataRow dr in dt.Rows)
                {
                    Message Output = new Message();

                    Output.messageBody = dr["messageBody"].ToString();
                    Output.messageHeader = dr["messageHeader"].ToString();
                    Output.subject = dr["subject"].ToString();
                    Output.templateType = dr["templateType"].ToString();

                    lstOfOutput.Add(Output);
                }


                return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<DB_Response> UD_SentSMSAsync(SendSmsNotificationClass Input)
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
                SqlParameter mobileNo = new SqlParameter
                {
                    ParameterName = "mobileNo",
                    Value = Input.mobileNo,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                };
                SqlParameter link = new SqlParameter
                {
                    ParameterName = "link",
                    Value = Input.link,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 500
                };
                SqlParameter Userid = new SqlParameter
                {
                    ParameterName = "Userid",
                    Value = Input.Userid,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                };

                SqlParameter[] allParameters = { QueryType, mobileNo,link, Userid };

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