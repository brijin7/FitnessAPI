using static Fitness.Models.BusinessObject.SendandVerifyOtp.BOL_SendandVerifyOtp;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Fitness.Models.DataAccessLayer.SendandVerifyOtp;
using Fitness.Models.DataAccessLayer.SendSmsAndMail;
using Fitness.Models.DataAccessLayer.UserNotification;
using static Fitness.Models.BusinessObject.SendSmsAndMail.BOL_SendSmsAndMail;
using static Fitness.Models.BusinessObject.UserNotification.BOL_mstrUserNotification;
using System.Net.Mail;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace Fitness.Controllers.SendandVerifyOtp
{
   //[Authorize]
    [RoutePrefix("api")]
    public class SendandVerifyOtpController : ApiController
    {
        string BaseUrl = ConfigurationManager.ConnectionStrings["BaseUrl"].ConnectionString;
        readonly DAL_SendandVerifyOtp DAL_SendandVerifyOtp = new DAL_SendandVerifyOtp();
        readonly DAL_SendSmsAndMail DAL_SendSmsAndMail = new DAL_SendSmsAndMail();
        readonly DAL_mstrUserNotificationcs DAL_UserNotificationcs = new DAL_mstrUserNotificationcs();
        private void SendFireBaseNotification(string Title, string body, string UserId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    SendNotification Insert = new SendNotification
                    {
                        userId = UserId.Trim(),
                        title = Title.Trim(),
                        body = body
                    };
                    HttpResponseMessage response = client.PostAsJsonAsync("fireBaseNotification", Insert).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var FitnessList = response.Content.ReadAsStringAsync().Result;
                        int StatusCode = Convert.ToInt32(JObject.Parse(FitnessList)["statusCode"].ToString());
                        string ResponseMsg = JObject.Parse(FitnessList)["response"].ToString();
                        //InsertUserNotificationAsyc(UserId.Trim(), body.Trim());
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void SendSmsAndMailAsyc(string MobileNo, string OTP)
        {
            try
            {
                DB_Response DB_res;
                string Subject = string.Empty;
                string MessageHeader = string.Empty;
                string Mailbody = string.Empty;
                string SMSbody = string.Empty;
                string MailbodyRe = string.Empty;
                string SMSbodyRE = string.Empty;

                //To Get  UserName
                var listOfGetMstrTax_Out = DAL_SendSmsAndMail.UD_GetMstrBranchBasedOnMobileNo(MobileNo);
                List<User> User = new List<User>();
                User = listOfGetMstrTax_Out.ToList();
                var firstItem = User.ElementAt(0);
                string UserName = firstItem.userName.ToString();
                string UserID = firstItem.userId.ToString();

                //To Get Mail Subject and Body
                var listMeassgeMail = DAL_SendSmsAndMail.UD_GetMessageTemplate("OTP","M");
                List<Message> Mail = new List<Message>();
                Mail = listMeassgeMail.ToList();
                //To Get SMS MessageHeader and Body
                var listMeassgeSMS = DAL_SendSmsAndMail.UD_GetMessageTemplate("OTP", "S");
                List<Message> SMS = new List<Message>();
                SMS = listMeassgeSMS.ToList();
                if (Mail.Count > 0)
                {
                    var MailItem = Mail.ElementAt(0);
                    Mailbody = MailItem.messageBody.ToString();
                    Subject = MailItem.subject.ToString();
                    if (UserName.ToString().Trim() != "")
                    {
                        MailbodyRe = Mailbody.Replace("[user]", UserName);
                    }
                    else
                    {
                        MailbodyRe = Mailbody.Replace("[user]", "user");
                        
                    }
                    MailbodyRe = MailbodyRe.Replace("[OTP]", OTP);
                }
                if(SMS.Count > 0)
                {
                    var SMSItem = SMS.ElementAt(0);
                    SMSbody = SMSItem.messageBody.ToString();
                    MessageHeader = SMSItem.messageHeader.ToString();
                    if (UserName.ToString().Trim() != "")
                    {
                        SMSbodyRE = SMSbody.Replace("[user]", UserName);
                    }
                    else
                    {
                        SMSbodyRE = SMSbody.Replace("[user]", "user");
                    }
                    SMSbodyRE = SMSbodyRE.Replace("[OTP]", OTP);
                    SendFireBaseNotification(MessageHeader, SMSbodyRE, UserID);
                    //SendSmsAsyc(MobileNo, Subject, body);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void InsertUserNotificationAsyc(string userid, string notification)
        {
            try
            {
                DB_Response DB_res;
                string Subject = string.Empty;
                string body = string.Empty;
                var listOfGetMstrTax_Out = DAL_UserNotificationcs.UD_InsertMstrUserNotificationAsyc(userid, notification);
            }
            catch (Exception ex)
            {

            }
        }

        private void SendSmsAsyc(string MobileNo, string Title, string body)
        {
            string BaseUrl = "https://www.fast2sms.com/dev/";
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "a6glxX1HCyPnQio9tRh3Wdzp7JDMje5ZsTvBNcFYOwumUV4LArxBWAMHP2CK1VeU4shmjuqNg89rp76Y");
                    SendSmSBulk Insert = new SendSmSBulk
                    {
                        route = "v3",
                        sender_id = "FTWSMS",
                        message = body,
                        language = "english",
                        flash = "0",
                        numbers = MobileNo,

                    };
                    HttpResponseMessage response = client.PostAsJsonAsync("bulkV2", Insert).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var FitnessList = response.Content.ReadAsStringAsync().Result;
                        //int StatusCode = Convert.ToInt32(JObject.Parse(FitnessList)["statusCode"].ToString());
                        // string ResponseMsg = JObject.Parse(FitnessList)["response"].ToString();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// this methos is used Send Otp
        /// </summary>
        /// <param name="Input">InsertMstrUserSendOtp_In</param>
        /// <returns></returns>
        [HttpPost]
        [Route("sendOtp")]
        public async Task<IHttpActionResult> InsertMstrUserSendOtpAsyc([FromBody] InsertMstrUserSendOtp_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_SendandVerifyOtp.UD_InsertMstrUserSendOtpAsyc(Input);
                if (DB_res.StatusCode == 1)
                {
                    string[] Response = DB_res.Response.Split('~');
                    //SendSmsAndMailAsyc(Input.mobileNo, Response[0]);

                }

                return GetDBSuccessOrInfoResponse(DB_res, "Create");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        /// <summary>
        /// thos method is used to Verify Otp
        /// </summary>
        /// <param name="Input">InsertMstrUserVerifyOtp_In</param>
        /// <returns></returns>
        [HttpPost]
        [Route("verifyOtp")]
        public async Task<IHttpActionResult> InsertMstrUserVerifyOtpAsyc([FromBody] InsertMstrUserVerifyOtp_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_SendandVerifyOtp.UD_InsertMstrUserVerifyOtpAsyc(Input);

                return GetDBSuccessOrInfoResponse(DB_res, "");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }



        /// <summary>
        /// this method is used to check if user entered all the required fields
        /// </summary>
        /// <param name="ModelState">model state parameter</param>
        /// <param name="isValid">boolean isvalid or not</param>
        /// <param name="API_InfoRes">API response parameter</param>
        private IHttpActionResult GetModelResponse(dynamic Input, ModelStateDictionary ModelState)
        {
            string[] Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToArray();
            string message = string.Join($" | ", Errors.Where(x => !string.IsNullOrEmpty(x)).ToArray());

            var msg = ModelState.SelectMany(s => s.Value.Errors).Select(e => e.Exception == null ? "" : e.Exception.Message.ToString()).ToArray();
            string ExceptionMessage = string.Join($" | ", msg.Where(x => !string.IsNullOrEmpty(x)).ToArray());

            API_SuccessOrErrorOrInfo API_InfoRes;
            if (Input != null)
            {
                API_InfoRes = new API_SuccessOrErrorOrInfo()
                {
                    StatusCode = 0,
                    Response = $"{message} {ExceptionMessage}",
                };
            }
            else
            {
                API_InfoRes = new API_SuccessOrErrorOrInfo()
                {
                    StatusCode = 0,
                    Response = "Must Pass All Parameters",
                };
            }
            return Content(HttpStatusCode.BadRequest, API_InfoRes);
        }
        /// <summary>
        /// this method is used to get success or no records found response
        /// </summary>
        /// <param name="DB_res">DB_Response class as input parameter</param>
        /// <param name="CUD">CUD Create Update Delete</param>
        /// <returns></returns>
        private IHttpActionResult GetDBSuccessOrInfoResponse(DB_Response DB_res, string CUD)
        {
            if (DB_res.StatusCode == 0)
            {
                API_SuccessOrErrorOrInfo API_InfoRes = new API_SuccessOrErrorOrInfo()
                {
                    StatusCode = DB_res.StatusCode,
                    Response = DB_res.Response
                };
                return Content(HttpStatusCode.OK, API_InfoRes);
            }
            else
            {
                API_SuccessOrErrorOrInfo API_SuccessRes = new API_SuccessOrErrorOrInfo()
                {
                    StatusCode = DB_res.StatusCode,
                    Response = DB_res.Response
                };
                if (CUD == "Create")
                {
                    return Content(HttpStatusCode.Created, API_SuccessRes);
                }
                else
                {
                    return Ok(API_SuccessRes);
                }

            }
        }
        /// <summary>
        /// this method is used to get error response
        /// </summary>
        /// <param name="Exception">Exception class as input parameter</param>
        /// <returns></returns>
        private IHttpActionResult GetErrorResponse(Exception Exception)
        {
            API_SuccessOrErrorOrInfo API_ErrorRes = new API_SuccessOrErrorOrInfo()
            {
                StatusCode = 0,
                Response = Exception.Message.ToString(),
            };
            return Content(HttpStatusCode.InternalServerError, API_ErrorRes);
        }

        /// <summary>
        /// this method is used to get responses for getmethods
        /// </summary>
        /// <typeparam name="T">dynamic type i.e string, int etc </typeparam>
        /// <param name="list">pass the list of classes</param>
        /// <param name="Message">if there is no records in list show message</param>
        /// <returns></returns>
        private IHttpActionResult GetSuccessOrFailureResForSelect<T>(dynamic list, string Message)
        {
            if (list.Count > 0)
            {
                API_Success<T> API_SuccessRes = new API_Success<T>()
                {
                    StatusCode = 1,
                    Response = list
                };
                return Ok(API_SuccessRes);
            }
            else
            {
                API_SuccessOrErrorOrInfo API_InfoRes = new API_SuccessOrErrorOrInfo()
                {
                    StatusCode = 0,
                    Response = Message,
                };

                return Content(HttpStatusCode.OK, API_InfoRes);
            }
        }
    }
}
