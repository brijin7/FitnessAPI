using static Fitness.Models.BusinessObject.SendSmsAndMail.BOL_SendSmsAndMail;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Fitness.Models.DataAccessLayer.SendSmsAndMail;
using Fitness.Models.DataAccessLayer.UserNotification;
using static Fitness.Models.BusinessObject.UserNotification.BOL_mstrUserNotification;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Configuration;
using Fitness.Models.DataAccessLayer.SendandVerifyOtp;
using static Fitness.Models.BusinessObject.SendandVerifyOtp.BOL_SendandVerifyOtp;
using System.Xml.Linq;

namespace Fitness.Controllers.SendSmsandMail
{
   //[Authorize]
    [RoutePrefix("api")]
    public class SendSmsAndMailController : ApiController
    {
        string BaseUrl = ConfigurationManager.ConnectionStrings["BaseUrl"].ConnectionString;
        readonly DAL_SendSmsAndMail DAL_SendSmsAndMail = new DAL_SendSmsAndMail();
        readonly DAL_mstrUserNotificationcs DAL_UserNotificationcs = new DAL_mstrUserNotificationcs();
        /// <summary>
        /// This Method Used For Insert Tax Master
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>

        private void SendMailAsync(string ToMailId, string subject, string Body)
        {
            try
            {
                System.Text.StringBuilder sbText = new System.Text.StringBuilder();
                sbText.Append(Body);
                sbText.Append("<br />");
                MailMessage message = new MailMessage();
                message.From = new MailAddress("prematixdev@gmail.com");
                message.To.Add(new MailAddress(ToMailId));
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = sbText.ToString();
                message.Priority = MailPriority.High;
                SmtpClient objClient = new SmtpClient("smtp.gmail.com", 587);
                objClient.EnableSsl = true;
                objClient.UseDefaultCredentials = true;
                objClient.Credentials = new System.Net.NetworkCredential("prematixdev@gmail.com", "idtlecnxjsdtfjsm");
                objClient.ServicePoint.MaxIdleTime = 1;
                objClient.ServicePoint.ConnectionLimit = 1;
                objClient.Send(message);
                DB_Response DB_res = new DB_Response()
                {
                    StatusCode = (int)(1),
                    Response = "Mail / Sms Sent Successfully",
                };
            }
            catch (Exception ex)
            {
                DB_Response DB_res = new DB_Response()
                {
                    StatusCode = (int)(1),
                    Response = "Enter Valid MailId",
                };
            }
        }

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
                        title = Title,
                        body = body
                    };
                    HttpResponseMessage response = client.PostAsJsonAsync("fireBaseNotification", Insert).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var FitnessList = response.Content.ReadAsStringAsync().Result;
                        int StatusCode = Convert.ToInt32(JObject.Parse(FitnessList)["statusCode"].ToString());
                        string ResponseMsg = JObject.Parse(FitnessList)["response"].ToString();
                        InsertUserNotificationAsyc(UserId.Trim(), body.Trim());

                        if (StatusCode == 1)
                        {
                            DB_Response DB_res = new DB_Response()
                            {
                                StatusCode = StatusCode,
                                Response = ResponseMsg,
                            };
                        }
                        else
                        {
                            DB_Response DB_res = new DB_Response()
                            {
                                StatusCode = StatusCode,
                                Response = ResponseMsg,
                            };
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                DB_Response DB_res = new DB_Response()
                {
                    StatusCode = (int)(1),
                    Response = "Enter Valid MobileNo",
                };
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


        [HttpPost]
        [Route("sendSmsandMail")]
        public async Task<IHttpActionResult> SendSmsAndMailAsyc([FromBody] SendSmsandMailClass Input)
        {
            try
            {
                DB_Response DB_res;

                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                string Subject = string.Empty;
                string MessageHeader = string.Empty;
                string Mailbody = string.Empty;
                string SMSbody = string.Empty;
                string MailbodyRe = string.Empty;
                string SMSbodyRE = string.Empty;

                //To Get  UserName
                var listOfGetMstrTax_Out = await DAL_SendSmsAndMail.UD_GetMstrBranchAsync(Input);
                List<User> User = new List<User>();
                User = listOfGetMstrTax_Out;
                var firstItem = User.ElementAt(0);
                string UserName = firstItem.userName.ToString();

                //To Get Mail Subject and Body
                var listMeassgeMail = DAL_SendSmsAndMail.UD_GetMessageTemplate("Customised Plan", "M");
                List<Message> Mail = new List<Message>();
                Mail = listMeassgeMail.ToList();

                //To Get SMS MessageHeader and Body
                var listMeassgeSMS = DAL_SendSmsAndMail.UD_GetMessageTemplate("Customised Plan", "S");
                List<Message> SMS = new List<Message>();
                SMS = listMeassgeSMS.ToList();
                if (Mail.Count > 0)
                {

                    var MailItem = Mail.ElementAt(0);
                    Mailbody = MailItem.messageBody.ToString();
                    Subject = MailItem.subject.ToString();
                    if (Input.queryType == "SendSMSAndMailForPlan")
                    {
                        if (UserName.ToString().Trim() != "")
                        {
                            MailbodyRe = Mailbody.Replace("[user]", UserName);
                        }
                        else
                        {

                            MailbodyRe = Mailbody.Replace("[user]", "user");
                        }

                    }
                    if (Input.mailId != "")
                    {
                        SendMailAsync(Input.mailId, Subject, MailbodyRe);
                        DB_res = new DB_Response()
                        {
                            StatusCode = (int)(1),
                            Response = "Mail / Sms Sent Successfully",
                        };
                    }
                }
                if (SMS.Count > 0)
                {
                    var SMSItem = SMS.ElementAt(0);
                    SMSbody = SMSItem.messageBody.ToString();
                    MessageHeader = SMSItem.messageHeader.ToString();
                    if (Input.queryType == "SendSMSAndMailForPlan")
                    {
                        if (UserName.ToString().Trim() != "")
                        {
                            SMSbodyRE = SMSbody.Replace("[user]", UserName);

                        }
                        else
                        {
                            SMSbodyRE = SMSbody.Replace("[user]", "user");

                        }


                        SendFireBaseNotification(MessageHeader, SMSbodyRE, Input.userId);
                    }
                    if (Input.mobileNo != "")
                    {
                        if (Input.mobileNo.Length > 9)
                        {
                            DB_res = await DAL_SendSmsAndMail.UD_SendSmsandMailAsyc(Input);
                        }
                        else
                        {
                            DB_res = new DB_Response()
                            {
                                StatusCode = (int)(0),
                                Response = "Enter Valid MobileNo",
                            };
                        }

                    }

                }

                DB_res = new DB_Response()
                {
                    StatusCode = (int)(1),
                    Response = "Mail / Sms Sent Successfully",
                };

                return GetDBSuccessOrInfoResponse(DB_res, "");

            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        [HttpPost]
        [Route("sendBookingNotification")]
        public async Task<IHttpActionResult> InsertMstrUserBookingNotificationAsyc([FromBody] SendSmsNotificationClass Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_SendSmsAndMail.UD_SentSMSAsync(Input);             
               
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
                return Content(HttpStatusCode.BadRequest, API_InfoRes);
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
