using static Fitness.Models.BusinessObject.LiveConfig.BOL_MstrLiveConfig;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Fitness.Models.DataAccessLayer.LiveConfig;
using Fitness.Models.DataAccessLayer.SendSmsAndMail;
using Fitness.Models.DataAccessLayer.UserNotification;
using static Fitness.Models.BusinessObject.UserNotification.BOL_mstrUserNotification;
using static Fitness.Models.BusinessObject.SendSmsAndMail.BOL_SendSmsAndMail;
using System.Net.Mail;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace Fitness.Controllers.LiveConfig
{

   //[Authorize]
    [RoutePrefix("api/liveConfig")]
    public class mstrLiveConfigController : ApiController
    {
        IFormatProvider obj = new System.Globalization.CultureInfo("en-GB", true);
        readonly DAL_MstrLiveConfig DAL_MstrLiveConfig = new DAL_MstrLiveConfig();
        string BaseUrl = ConfigurationManager.ConnectionStrings["BaseUrl"].ConnectionString;
        readonly DAL_mstrUserNotificationcs DAL_UserNotificationcs = new DAL_mstrUserNotificationcs();
        readonly DAL_SendSmsAndMail DAL_SendSmsAndMail = new DAL_SendSmsAndMail();

        /// <summary>
        /// this method is used to get categorymaster details
        /// </summary>
        /// <param name="Input">GetCategoryMstr_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetLiveConfigMasterAsync()
        {
            try
            {
                var listOfGetCategoryMstr_Out = await DAL_MstrLiveConfig.UD_GetLiveConfigMstrAsync();

                return GetSuccessOrFailureResForSelect<GetLiveConfigMstr_Out>(listOfGetCategoryMstr_Out, "No Records Found In Live Config Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to get categorymaster details
        /// </summary>
        /// <param name="Input">GetCategoryMstr_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("LiveDate")]
        public async Task<IHttpActionResult> GetLiveDateConfigMasterAsync([FromUri] GetLiveConfigMstr_In Input)
        {
            try
            {

                var listOfGetCategoryMstr_Out = await DAL_MstrLiveConfig.UD_GetLiveDateConfigMstrAsync(Input);

                return GetSuccessOrFailureResForSelect<GetLiveConfigMstr_Out>(listOfGetCategoryMstr_Out, "No Records Found In Live Config Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        /// <summary>
        /// this method is used to get categorymaster details
        /// </summary>
        /// <param name="Input">GetCategoryMstr_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("LiveBranchowner")]
        public async Task<IHttpActionResult> GetLiveBranchownerConfigMasterAsync([FromUri] GetLiveBranchownerConfigMstr_In Input)
        {
            try
            {

                var listOfGetCategoryMstr_Out = await DAL_MstrLiveConfig.UD_GetLiveBranchownerConfigMstrAsync(Input);

                return GetSuccessOrFailureResForSelect<GetLiveConfigMstr_Out>(listOfGetCategoryMstr_Out, "No Records Found In Live Config Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }


        /// <summary>
        /// this method is used to insert categorymaster
        /// </summary>
        /// <param name="Input">InsertCategory_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IHttpActionResult> InsertCategoryMasterAsync([FromBody] InsertLiveConfig_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrLiveConfig.UD_InsertLiveConfigMasterAsync(Input);
                if (DB_res.StatusCode == 1)
                {
                    string Subject = string.Empty;
                    string MessageHeader = string.Empty;
                    string Mailbody = string.Empty;
                    string SMSbody = string.Empty;
                    string MailbodyRe = string.Empty;
                    string SMSbodyRE = string.Empty;
                    string Title = string.Empty;

                    //To Get SMS MessageHeader and Body
                    var listMeassgeSMS = DAL_SendSmsAndMail.UD_GetMessageTemplate("live stream", "S");
                    List<Message> SMS = new List<Message>();
                    SMS = listMeassgeSMS.ToList();
                    if (SMS.Count > 0)
                    {
                        var SMSItem = SMS.ElementAt(0);
                        SMSbody = SMSItem.messageBody.ToString();
                        MessageHeader = SMSItem.messageHeader.ToString();
                        SMSbodyRE = SMSbody.Replace("[user]", "User");
                        SMSbodyRE = SMSbodyRE.Replace("[purpose]", Input.purposename);
                        SMSbodyRE = SMSbodyRE.Replace("[liveUrl]", Input.liveurl);
                        SMSbodyRE = SMSbodyRE.Replace("[date]", Input.livedate);
                        DateTime now = DateTime.Parse(Input.livedate,obj);
                        string s = now.DayOfWeek.ToString();
                        SMSbodyRE = SMSbodyRE.Replace("[day]", s);
                        string body = string.Empty;

                        //SendFireBaseNotification(MessageHeader, SMSbodyRE);
                        SendSmsForAllUSerLiveUrl_In Input1 = new SendSmsForAllUSerLiveUrl_In();
                        Input1.branchId = Input.branchId;
                        Input1.gymownerId = Input.gymownerId;
                        Input1.SMSBody = SMSbodyRE;
                        //DB_Response DB_res1 = await DAL_MstrLiveConfig.UD_SmsSendForAllUSerAsync(Input1);
                    }

                }

                return GetDBSuccessOrInfoResponse(DB_res, "Create");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        private void SendFireBaseNotification(string Title, string body)
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
                        title = Title,
                        body = body.Trim()
                    };
                    HttpResponseMessage response = client.PostAsJsonAsync("fireBaseNotificationBoardCast", Insert).Result;
                    
                    if (response.IsSuccessStatusCode)
                    {
                        var FitnessList = response.Content.ReadAsStringAsync().Result;
                        int StatusCode = Convert.ToInt32(JObject.Parse(FitnessList)["statusCode"].ToString());
                        string ResponseMsg = JObject.Parse(FitnessList)["response"].ToString();
                        //InsertUserNotificationAsyc("0", body.Trim());
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

        /// <summary>
        /// this method is used to update CategoryMaster
        /// </summary>
        /// <param name="Input">UpdateCategoryMstr_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public async Task<IHttpActionResult> UpdateCategoryMasterAsync([FromBody] UpdateLiveConfigMstr_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrLiveConfig.UD_UpdateLiveConfigMstrAsync(Input);
                return GetDBSuccessOrInfoResponse(DB_res, "");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        [HttpPost]
        [Route("activeOrInActive")]
        public async Task<IHttpActionResult> ActiveOrInactiveCategoryMasterAsync([FromBody] ActivateOrInactivateLiveConfigMstr_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrLiveConfig.UD_ActivateOrInactivateLiveConfigMstrAsyn(Input);
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