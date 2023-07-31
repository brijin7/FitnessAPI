using Fitness.Models.CommonModels;
using Fitness.Models.DataAccessLayer.GetGymOwnerAndBranch;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using static Fitness.Models.BusinessObject.GetGymOwnerAndBranch.BOL_GetGymOwnerAndBranch;

namespace Fitness.Controllers.GetGymOwnerAndBranch
{
    [RoutePrefix("api/getGymownerIdAndBranchId")]
    public class GetGymownerIdAndBranchIdController : ApiController
    {
        readonly DAL_getGymOwnerAndBranch DAL = new DAL_getGymOwnerAndBranch();

        /// <summary>
        /// this method is used to get gymowner
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("gymowner")]
        public async Task<IHttpActionResult> GetGymOwnerIdAsync()
        {
            try
            {
                var Result = await DAL.UD_GetGymOwnerIdAsync();

                return GetSuccessOrFailureResForJArray(Result, "No Gymowner Found !!!.");
            }
            catch (Exception Ex)
            {
                return GetErrorResponse(Ex);
            }

        }
        /// <summary>
        /// this method is used to get gymowner
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("branch")]
        public async Task<IHttpActionResult> GetBranchIdAsync([FromUri]GetBranchId Input)
        {
            try
            {
                var Result = await DAL.UD_GetBranchIdAsync(Input);

                return GetSuccessOrFailureResForJArray(Result, "No Branch Found !!!.");
            }
            catch (Exception Ex)
            {
                return GetErrorResponse(Ex);
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
