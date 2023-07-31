using static Fitness.Models.BusinessObject.SignUpandSignIn.BOL_SignUpandSignIn;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Fitness.Models.DataAccessLayer.SignUpandSignIn;
using Fitness.Models.DataAccessLayer.SendSmsAndMail;
using static Fitness.Models.BusinessObject.SendSmsAndMail.BOL_SendSmsAndMail;
using System.Net.Mail;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace Fitness.Controllers.SignUpandSignIn
{
                  //[Authorize]
    [RoutePrefix("api")]
    public class SignUpandSignInController : ApiController
    {
        readonly DAL_SignUpandSignIn DAL_SignUpandSignIn = new DAL_SignUpandSignIn();

        readonly DAL_SendSmsAndMail DAL_SendSmsAndMail = new DAL_SendSmsAndMail();
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
                        title = "SignUp",
                        body = body.Trim()
                    };
                    HttpResponseMessage response = client.PostAsJsonAsync("fireBaseNotification", Insert).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var FitnessList = response.Content.ReadAsStringAsync().Result;
                        int StatusCode = Convert.ToInt32(JObject.Parse(FitnessList)["statusCode"].ToString());
                        string ResponseMsg = JObject.Parse(FitnessList)["response"].ToString();


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
        public void SendSmsAndMailAsyc(string MobileNo, string MailId)
        {
            try
            {
                DB_Response DB_res;
                string Subject = string.Empty;
                string body = string.Empty;
                if (MobileNo != "")
                {
                    var listOfGetMstrTax_Out = DAL_SendSmsAndMail.UD_GetMstrBranchBasedOnMobileNo(MobileNo);
                    if (listOfGetMstrTax_Out.Count <= 0)
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
                        if (UserName.Trim() != "")
                        {
                            body = "Dear " + UserName + " ,Thank You for SignUp, Your SignUp is successfull.";
                        }
                        else if (UserName.Trim() != null)
                        {
                            body = "Dear " + UserName + " ,Thank You for SignUp, Your SignUp is successfull.";
                        }
                        else
                        {
                            body = "Dear  User ,Thank You for SignUp, Your SignUp is successfull.";
                        }
                        Subject = "Your SignUp  is confirmed";
                        if (MailId != null && MailId != "")
                        {
                            SendMailAsync(MailId, Subject, body);
                        }
                        // SendFireBaseNotification(Subject, body, UserID);
                    }
                }

                


            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// this method is used to get  sign In User Master details
        /// </summary>
        /// <param name="Input">GetMstrUser_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("signIn")]
        public async Task<IHttpActionResult> GetMstrUserSignInAsync([FromUri] InsertMstrUserSignIn_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetMstrUserSignIn_Out = await DAL_SignUpandSignIn.UD_GetMstrSignInAsync(Input);

                return GetSuccessOrFailureResForJArray(listOfGetMstrUserSignIn_Out, "Enter valid MobileNo/MailId/Password !!!");
                //return GetSuccessOrFailureResForSelect<InsertMstrUserSignIn_Out>(listOfGetMstrUserSignIn_Out, "Enter valid MobileNo/MailId/Password !!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        /// <summary>
        /// this method is used to Sign Up
        /// </summary>
        /// <param name="Input">InsertMstrUserSignUp_In</param>
        /// <returns></returns>
        [HttpPost]
        [Route("signUp")]
        public async Task<IHttpActionResult> InsertMstrUserSignUpAsyc([FromBody] InsertMstrUserSignUp_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_SignUpandSignIn.UD_InsertMstrUserSignUpAsyc(Input);
                if (DB_res.StatusCode == 1)
                {

                    SendSmsAndMailAsyc(Input.mobileNo, Input.mailId);

                }
                return GetDBSuccessOrInfoResponse(DB_res, "Create");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }


        /// <summary>
        /// this method is used to Sign Up
        /// </summary>
        /// <param name="Input">UpdateMstrUserPassword_In</param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdatePassword")]
        public async Task<IHttpActionResult> UpdatePasswordAsyc([FromBody] UpdateMstrUserPassword_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_SignUpandSignIn.UD_UpdateMstrUserPasswordAsyc(Input);

                return GetDBSuccessOrInfoResponse(DB_res, "Create");
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

        /// <summary>
        /// this method is used to return JArray As Response
        /// </summary>
        /// <param name="JsonArray"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        private IHttpActionResult GetSuccessOrFailureResForJArray(JArray JsonArray, string Message)
        {
            if (JsonArray.Count > 0)
            {
                API_JArraySuccess JArraySuccess = new API_JArraySuccess()
                {
                    StatusCode = 1,
                    Response = JsonArray
                };
                return Ok(JArraySuccess);
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
