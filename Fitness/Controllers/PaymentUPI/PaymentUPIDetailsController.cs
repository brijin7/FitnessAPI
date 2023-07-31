using Fitness.Models.CommonModels;
using Fitness.Models.DataAccessLayer.PaymentUPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using static Fitness.Models.BusinessObject.PaymentUPI.BOL_PaymentUPIDetails;
using System.Data;
using Newtonsoft.Json;
namespace Fitness.Controllers.PaymentUPI
{
                  //[Authorize]
    [RoutePrefix("api/PaymentUPI")]
    public class PaymentUPIDetailsController : ApiController
    {
        readonly DAL_PaymentUPIDetails DAL_PaymentUPIDetails = new DAL_PaymentUPIDetails();

        /// <summary>
        /// this method is used to Get Price Details
        /// </summary>
        /// <param name="Input">GetUserFoodMenu_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetMstrUserAsync([FromUri] GetPaymentUPIDetails_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                string PaymentUPIDetails = await DAL_PaymentUPIDetails.GetPaymentUPIDetailsAsync(Input);
                if (!string.IsNullOrEmpty(PaymentUPIDetails))
                {
                    if (PaymentUPIDetails != "No Data Found")
                    {
                        var result = JsonConvert.DeserializeObject(PaymentUPIDetails);
                        GetPaymentUPIDetails_Out output = new GetPaymentUPIDetails_Out()
                        {
                            StatusCode = 1,
                            PaymentUPIDetails = result
                        };
                        return Ok(output);
                    }
                    else
                    {
                        DB_Response res = new DB_Response()
                        {
                            StatusCode = 0,
                            Response = "No Records Found !!!."
                        };
                        return Content(HttpStatusCode.NotFound, res);

                    }

                }
                else
                {
                    DB_Response res = new DB_Response()
                    {
                        StatusCode = 0,
                        Response = "No Records Found !!!."
                    };
                    return Content(HttpStatusCode.NotFound, res);
                }
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Input">InsertPaymentUPIDetails_In</param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IHttpActionResult> InsertPaymentUPIAsync([FromBody] InsertPaymentUPIDetails_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_PaymentUPIDetails.UD_InsertPaymentUPIDetailsAsync(Input);

                return GetDBSuccessOrInfoResponse(DB_res, "Create");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        ///// <summary>
        ///// this method is used to update FitnessCategoryPriceMaster
        ///// </summary>
        ///// <param name="Input">UpdatePaymentUPIDetails_In class as input parameter</param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("update")]
        //public async Task<IHttpActionResult> UpdatePaymentUPIDetailsAsync([FromBody] UpdatePaymentUPIDetails_In Input)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return GetModelResponse(Input, ModelState);
        //        }

        //        DB_Response DB_res = await DAL_PaymentUPIDetails.UD_UpdatePaymentUPIDetailsAsync(Input);
        //        return GetDBSuccessOrInfoResponse(DB_res, "");
        //    }
        //    catch (Exception ex)
        //    {
        //        return GetErrorResponse(ex);
        //    }
        //}


        ///// <summary>
        ///// Update Active Status
        ///// </summary>
        ///// <param name="Input"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("activeOrInActive")]
        //public async Task<IHttpActionResult> ActivateOrInactivateActivateOrInactivatePaymentUPIDetailsAsync([FromBody] ActivateOrInactivatePaymentUPIDetails_In Input)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return GetModelResponse(Input, ModelState);
        //        }

        //        DB_Response DB_res = await DAL_PaymentUPIDetails.UD_ActivateOrInactivateMstrFitnessCategoryPriceAsyc(Input);
        //        return GetDBSuccessOrInfoResponse(DB_res, "");
        //    }
        //    catch (Exception ex)
        //    {
        //        return GetErrorResponse(ex);
        //    }
        //}

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
