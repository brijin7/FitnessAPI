using static Fitness.Models.BusinessObject.UserMaster.BOL_MstrUser;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Fitness.Models.DataAccessLayer.UserMaster;
using Fitness.Models.DataAccessLayer.SendSmsAndMail;
using static Fitness.Models.BusinessObject.SendSmsAndMail.BOL_SendSmsAndMail;
using Fitness.Models.DataAccessLayer.UserNotification;
using static Fitness.Models.BusinessObject.UserNotification.BOL_mstrUserNotification;
using System.Net.Mail;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace Fitness.Controllers
{
    //[Authorize]
    [RoutePrefix("api/user")]
    public class mstrUserController : ApiController
    {
        readonly DAL_MstrUser DAL_MstrUser = new DAL_MstrUser();
        readonly DAL_SendSmsAndMail DAL_SendSmsAndMail = new DAL_SendSmsAndMail();
        readonly DAL_mstrUserNotificationcs DAL_UserNotificationcs = new DAL_mstrUserNotificationcs();
        string BaseUrl = ConfigurationManager.ConnectionStrings["BaseUrl"].ConnectionString;
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
                throw;
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
                        title = Title.Trim(),
                        body = body.Trim()
                    };
                    HttpResponseMessage response = client.PostAsJsonAsync("fireBaseNotification", Insert).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var FitnessList = response.Content.ReadAsStringAsync().Result;
                        int StatusCode = Convert.ToInt32(JObject.Parse(FitnessList)["statusCode"].ToString());
                        string ResponseMsg = JObject.Parse(FitnessList)["response"].ToString();
                        InsertUserNotificationAsyc(UserId.Trim(), body.Trim());
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
        private void SendSmsAndMailAsyc(string MobileNo, string MailId, string Title, string bodysms,string bodyMail, string MessageHeader)
        {
            try
            {
                DB_Response DB_res;

                var listOfGetMstrTax_Out = DAL_SendSmsAndMail.UD_GetMstrBranchBasedOnMobileNo(MobileNo);
                if (listOfGetMstrTax_Out.Count < 0)
                {
                    listOfGetMstrTax_Out = DAL_SendSmsAndMail.UD_GetMstrBranchBasedOnMobileNo(MailId);

                }
                if (listOfGetMstrTax_Out.Count > 0)
                {
                    List<User> User = new List<User>();
                    User = listOfGetMstrTax_Out.ToList();
                    var firstItem = User.ElementAt(0);
                    string UserName = firstItem.userName.ToString();
                    string UserID = firstItem.userId.ToString();

                    SendFireBaseNotification(Title, bodysms, UserID);
                }
                if (MailId.ToString().Trim() != "")
                {
                    SendMailAsync(MailId, MessageHeader, bodyMail);
                }


            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// this method is used to get User Master details
        /// </summary>
        /// <param name="Input">GetMstrUserList_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetMstrUserAsync([FromUri] GetMstrUserList_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfMstrUserList_Out = await DAL_MstrUser.UD_GetMstrUserAsync(Input);

                return GetSuccessOrFailureResForSelect<GetMstrUserList_Out>(listOfMstrUserList_Out, "No Records Found In User Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to get User Master details
        /// </summary>
        /// <param name="Input">GetMstrUserList_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetaAdminUser")]
        public async Task<IHttpActionResult> GetMstrAdminUserAsync([FromUri] GetMstrAdminUserList_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfMstrUserList_Out = await DAL_MstrUser.UD_GetMstrAdminUserAsync(Input);

                return GetSuccessOrFailureResForSelect<GetMstrAdminUserList_Out>(listOfMstrUserList_Out, "No Records Found In User Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to update Employee Master
        /// </summary>
        /// <param name="Input">UpdateMstrEmployee_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertAdminUser")]
        public async Task<IHttpActionResult> InsertMstrUserProfileAsync([FromBody] InserteMstrUserProfile_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrUser.UD_InsertMstrUserProfileAsyc(Input);
                if (DB_res.StatusCode == 1)
                {
                    string Subject = string.Empty;
                    string MessageHeader = string.Empty;
                    string Mailbody = string.Empty;
                    string SMSbody = string.Empty;
                    string MailbodyRe = string.Empty;
                    string SMSbodyRE = string.Empty;
                    //To Get Mail Subject and Body
                    var listMeassgeMail = DAL_SendSmsAndMail.UD_GetMessageTemplate("Enquiry", "M");
                    List<Message> EnquiryMail = new List<Message>();
                    EnquiryMail = listMeassgeMail.ToList();
                    //To Get SMS MessageHeader and Body
                    var listMeassgeSMS = DAL_SendSmsAndMail.UD_GetMessageTemplate("Enquiry", "S");
                    List<Message> EnquirySMS = new List<Message>();
                    EnquirySMS = listMeassgeSMS.ToList();

                  
                    if (Input.enquiryReason != "")
                    {
                        if (EnquiryMail.Count > 0)
                        {
                            var MailItem = EnquiryMail.ElementAt(0);
                            Mailbody = MailItem.messageBody.ToString();
                            Subject = MailItem.subject.ToString();
                            if (Input.firstName != "")
                            {
                                MailbodyRe = Mailbody.Replace("[user]", Input.firstName + "-" + Input.lastName);
                             
                            }
                            
                            else
                            {
                                MailbodyRe = Mailbody.Replace("[user]", "user");
                            }
                           
                        }
                        if (EnquirySMS.Count > 0)
                        {
                            var SMSItem = EnquirySMS.ElementAt(0);
                            SMSbody = SMSItem.messageBody.ToString();
                            MessageHeader = SMSItem.messageHeader.ToString();
                            if (Input.firstName != "")
                            {
                                SMSbodyRE = SMSbody.Replace("[user]", Input.firstName + "-" + Input.lastName);

                            }

                            else
                            {
                                SMSbodyRE = SMSbody.Replace("[user]", "user");
                            }
                            //SendSmsAsyc(MobileNo, Subject, body);
                        }
                        
                       
                        SendSmsAndMailAsyc(Input.mobileNo, Input.mailId, Subject, SMSbodyRE, MailbodyRe, MessageHeader);

                    }
                    //To Get Mail Subject and Body
                    var listMeassgeFollowMail = DAL_SendSmsAndMail.UD_GetMessageTemplate("Follow Up", "M");
                    List<Message> FollowUpMail = new List<Message>();
                    FollowUpMail = listMeassgeFollowMail.ToList();
                    //To Get SMS MessageHeader and Body
                    var listMeassgeFollowSMS = DAL_SendSmsAndMail.UD_GetMessageTemplate("Follow Up", "S");
                    List<Message> FollowUPSMS = new List<Message>();
                    FollowUPSMS = listMeassgeFollowSMS.ToList();
                      Subject = string.Empty;
                     MessageHeader = string.Empty;
                     Mailbody = string.Empty;
                     SMSbody = string.Empty;
                     MailbodyRe = string.Empty;
                     SMSbodyRE = string.Empty;
                    if (Input.followUpStatus != 0)
                    {
                        if (FollowUpMail.Count > 0)
                        {
                            var MailItem = FollowUpMail.ElementAt(0);
                            Mailbody = MailItem.messageBody.ToString();
                            Subject = MailItem.subject.ToString();
                            if (Input.firstName != "")
                            {
                                MailbodyRe = Mailbody.Replace("[user]", Input.firstName + "-" + Input.lastName);

                            }

                            else
                            {
                                MailbodyRe = Mailbody.Replace("[user]", "user");
                            }

                        }
                        if (FollowUPSMS.Count > 0)
                        {
                            var SMSItem = FollowUPSMS.ElementAt(0);
                            SMSbody = SMSItem.messageBody.ToString();
                            MessageHeader = SMSItem.messageHeader.ToString();
                            if (Input.firstName != "")
                            {
                                SMSbodyRE = SMSbody.Replace("[user]", Input.firstName + "-" + Input.lastName);

                            }

                            else
                            {
                                SMSbodyRE = SMSbody.Replace("[user]", "user");
                            }
                            //SendSmsAsyc(MobileNo, Subject, body);
                        }
                        SendSmsAndMailAsyc(Input.mobileNo, Input.mailId, Subject, SMSbodyRE, MailbodyRe, MessageHeader);
                    }

                }
                return GetDBSuccessOrInfoResponse(DB_res, "");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        /// <summary>
        /// this method is used to update Employee Master
        /// </summary>
        /// <param name="Input">UpdateMstrEmployee_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateAdminUser")]
        public async Task<IHttpActionResult> UpdateMstrAdminUserProfileAsync([FromBody] UpdateMstrAdminUserProfile_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrUser.UD_UpdateMstrAdminUserProfileAsyc(Input);
                return GetDBSuccessOrInfoResponse(DB_res, "");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        /// <summary>
        /// this method is used to update Employee Master
        /// </summary>
        /// <param name="Input">UpdateMstrEmployee_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public async Task<IHttpActionResult> UpdateMstrUserProfileAsync([FromBody] UpdateMstrUserProfile_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrUser.UD_UpdateMstrUserProfileAsyc(Input);
                return GetDBSuccessOrInfoResponse(DB_res, "");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to update Employee Master
        /// </summary>
        /// <param name="Input">UpdateMstrEmployee_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateregistrationToken")]
        public async Task<IHttpActionResult> UpdateMstrregistrationTokenAsync([FromBody] UpdateMstrregistrationToken_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrUser.UD_UpdateMstrregistrationTokenAsyc(Input);
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
