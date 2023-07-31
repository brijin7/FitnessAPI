using static Fitness.Models.BusinessObject.SubscriptionBooking.BOL_SubscriptionBooking;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Fitness.Models.DataAccessLayer.SubscriptionBooking;
using static Fitness.Models.BusinessObject.SendSmsAndMail.BOL_SendSmsAndMail;
using Fitness.Models.DataAccessLayer.SendSmsAndMail;
using System.Net.Mail;
using System.Web.Http.Cors;

namespace Fitness.Controllers.SubscriptionBooking
{
                  //[Authorize]
    [RoutePrefix("api")]

    public class SubscriptionBookingController : ApiController
    {
        readonly DAL_SubscriptionBooking DAL_SubscriptionBooking = new DAL_SubscriptionBooking();
        readonly DAL_SendSmsAndMail DAL_SendSmsAndMail = new DAL_SendSmsAndMail();
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
                    Response = "Mail Sent Successfully",
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
        [HttpPost]
        [Route("SubscriptionBooking")]
        public async Task<IHttpActionResult> InsertSubscriptionBookingBookingAsyc([FromBody] InsertSubscriptionBooking_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_SubscriptionBooking.UD_InsertSubscriptionBookingAsyc(Input);
                if (DB_res.StatusCode == 1)
                {
                    if (Input.paymentStatus == "P")
                    {
                        string Subject = string.Empty;
                        string body = string.Empty;
                        var listOfGetMstrTax_Out =  DAL_SendSmsAndMail.UD_GetMstrBranchsAsync(Input.userId.ToString());
                        if (listOfGetMstrTax_Out.Count > 0)
                        {
                            List<User> User = new List<User>();
                            User = listOfGetMstrTax_Out.ToList();
                            var firstItem = User.ElementAt(0);
                            string UserName = firstItem.userName.ToString();
                            string UserID = firstItem.userId.ToString();
                            string mail = firstItem.mailId.ToString();
                            if (UserName.Trim() != "")
                            {
                                body = "Dear " + UserName + " ,Thank You for Booking, Your Booking is successfull.";
                            }
                            else if (UserName.Trim() != null)
                            {
                                body = "Dear " + UserName + " ,Thank You for Booking, Your Booking is successfull.";
                            }
                            else
                            {
                                body = "Dear  User ,Thank You for Booking, Your Booking is successfull.";
                            }

                            Subject = "Your Booking  is confirmed";

                            if (mail.ToString().Trim() != "")
                            {
                                SendMailAsync(mail, Subject, body);
                            }

                        }

                    }
                }

                return GetDBSuccessOrInfoResponse(DB_res, "Create");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }


        /// <summary>
        /// this method is used to get Booking details
        /// </summary>
        /// <param name="Input">GetBooking_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("AllSubspBookingDetails")]
        public async Task<IHttpActionResult> GetAllBookingDetailsAsync()
        {
            try
            {
                var listOfGetCategoryMstr_Out = await DAL_SubscriptionBooking.UD_GetSubspBookingAsync();

                return GetSuccessOrFailureResForSelect<GetSubspBooking_Out>(listOfGetCategoryMstr_Out, "No Records Found In Booking!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to get Booking details
        /// </summary>
        /// <param name="Input">GetUserBooking_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("UserSubspBookingDetails")]
        public async Task<IHttpActionResult> GetUserSubspBookingDetailsAsync([FromUri] GetUserSubspBooking_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetCategoryMstr_Out = await DAL_SubscriptionBooking.UD_GetUserSubspBookingAsync(Input);

                return GetSuccessOrFailureResForSelect<GetSubspBooking_Out>(listOfGetCategoryMstr_Out, "No Records Found For this User In Booking!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to get Booking details
        /// </summary>
        /// <param name="Input">GetUserBooking_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("BranchOwnerSubspBookingDetails")]
        public async Task<IHttpActionResult> GetBranchOwnerSubspBookingDetailsAsync([FromUri] GetBranchOwnerSubspBooking_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetCategoryMstr_Out = await DAL_SubscriptionBooking.UD_GetBranchOwnerSubspBookingAsync(Input);

                return GetSuccessOrFailureResForSelect<GetSubspBooking_Out>(listOfGetCategoryMstr_Out, "No Records Found For this User In Booking!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to get Booking details
        /// </summary>
        /// <param name="Input">GetUserBooking_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("BookingIdBasedSubspBookingDetails")]
        public async Task<IHttpActionResult> GetBookingIdBasedSubspBookingDetailsAsync([FromUri] GetBookingIdSubspBooking_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetCategoryMstr_Out = await DAL_SubscriptionBooking.UD_GetBookingIdSubspBookingAsync(Input);

                return GetSuccessOrFailureResForSelect<GetSubspBooking_Out>(listOfGetCategoryMstr_Out, "No Records Found For this User In Booking!!!");
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
