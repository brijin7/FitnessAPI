using Fitness.Models.CommonModels;
using Fitness.Models.DataAccessLayer.DashBoardForBranchAdmin;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using static Fitness.Models.BusinessObject.DashBoardForBranchAdmin.BOL_DashBoardForBranchAdmin;

namespace Fitness.Controllers.DashBoardForBranchAdmin
{        
                       //[Authorize]
    [RoutePrefix("api/dashBoardForBranch")]
   
    public class getDashBoardForBranchAdminController : ApiController
    {
        readonly DAL_DashBoardForBranchAdmin DAL = new DAL_DashBoardForBranchAdmin();

        /// <summary>
        /// this method is used to get the count of Booking and Enquiries
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getBookingEnquiresCount")]
        public async Task<IHttpActionResult> GetBookingEnquiresCountAsync([FromUri] GetBookingAndEnquiryCount_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                JArray Response = await DAL.UD_GetBookingAndEnquiryCountAsync(Input);

                return GetSuccessOrFailureResForJArray(Response, "No Records Found !!!.");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to get the GetBookingListBasedOnGymAndBranch list
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getBookinglist")]
        public async Task<IHttpActionResult> GetBookingListBasedOnGymAndBranchAsync([FromUri] GetBookingListBasedOnGymAndBranch_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                JArray Response = await DAL.UD_GetBookingListBasedOnGymAndBranchAsync(Input);

                return GetSuccessOrFailureResForJArray(Response, "No Booking Found !!!.");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to get the GetBookingListBasedOnGymAndBranch list
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getEnquirylist")]
        public async Task<IHttpActionResult> GetEnquiryListBasedOnGymAndBranchAsync([FromUri] GetEnquiryListBasedOnGymAndBranch_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                JArray Response = await DAL.UD_GetEnquiryListBasedOnGymAndBranchAsync(Input);

                return GetSuccessOrFailureResForJArray(Response, "No Enquiry Found !!!.");
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
    }
}
