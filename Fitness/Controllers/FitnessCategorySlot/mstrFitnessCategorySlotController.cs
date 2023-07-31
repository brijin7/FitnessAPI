using Fitness.Models.CommonModels;
using Fitness.Models.DataAccessLayer.FitnessCategorySlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Fitness.Models.BusinessObject.FitnessCategorySlot.BOL_FitnessCategorySlot;
using System.Web.Http.ModelBinding;
using System.Threading.Tasks;

namespace Fitness.Controllers.FitnessCategorySlot
{
    //[Authorize]
    [RoutePrefix("api/fitnessCategorySlots")]
    public class mstrFitnessCategorySlotController : ApiController
    {
        readonly DAL_FitnessCategorySlot DAL_FitnessCategorySlot = new DAL_FitnessCategorySlot();
        /// <summary>
        /// this method is used to get fitness category slots 
        /// </summary>
        /// <param name="Input">GetFintnessCategorySlots_In as input paramter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getCategoryPriceSlot")]
        public async Task<IHttpActionResult> GetFintnessCategorySlotsAsync([FromUri] GetFintnessCategorySlots_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                var list = await DAL_FitnessCategorySlot.GetFintnessCategorysingleSlotsAsync(Input);

                return GetSuccessOrFailureResForSelect<GetFintnessCategorySlots_Out>(list, "No Slots Details Found !!!.");
            }
            catch (Exception Ex)
            {
                return GetErrorResponse(Ex);
            }
        }
        [HttpGet]
        [Route("getAvailableSlotForPublic")]
        public async Task<IHttpActionResult> GetFintnessCategoryAvailableSlotsAsync([FromUri] GetFintnessCategoryAvailableSlots_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                var list = await DAL_FitnessCategorySlot.GetFintnessCategoryAvailableSlotsAsync(Input);

                return GetSuccessOrFailureResForSelect<GetFintnessCategoryAvailableSlots_Out>(list, "No Slots Details Found !!!.");
            }
            catch (Exception Ex)
            {
                return GetErrorResponse(Ex);
            }
        }
        [HttpPost]
        [Route("insert")]
        public async Task<IHttpActionResult> InsertFintnessCategorySlotsAsync([FromBody] InsertFintnessCategorySlots_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_FitnessCategorySlot.UD_InsertFitnessCategorySlot(Input);

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
    }
}
