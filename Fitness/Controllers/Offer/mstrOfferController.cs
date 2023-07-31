﻿using static Fitness.Models.BusinessObject.Offer.BOL_MstrOffer;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Fitness.Models.DataAccessLayer.Offer;
namespace Fitness.Controllers.Offer
{
    //[Authorize]
    [RoutePrefix("api/offer")]
    public class mstrOfferController : ApiController
    {
        readonly DAL_MstrOffer DAL_MstrOffer = new DAL_MstrOffer();


        /// <summary>
        /// this method is used to get Offer details
        /// </summary>
        /// <param name="Input">GetOffer_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetOfferMasterAsync([FromUri] GetOffer_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetConfigMstr_Out = await DAL_MstrOffer.UD_GetOfferAsync(Input);

                return GetSuccessOrFailureResForSelect<GetOffer_Out>(listOfGetConfigMstr_Out, "No Records Found In Offer Master !!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to get Offer details
        /// </summary>
        /// <param name="Input">GetOffer_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetddlOffer")]
        public async Task<IHttpActionResult> GetddlOfferMasterAsync([FromUri] GetOffer_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetConfigMstr_Out = await DAL_MstrOffer.UD_GetddlOfferAsync(Input);

                return GetSuccessOrFailureResForSelect<GetddlOffer_Out>(listOfGetConfigMstr_Out, "No Records Found In Offer Master !!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }


        /// <summary>
        /// this method is used to insert Offer
        /// </summary>
        /// <param name="Input">InsertOffer_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IHttpActionResult> InsertOfferMasterAsync([FromBody] InsertOffer_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrOffer.UD_InsertMstrOfferAsync(Input);

                return GetDBSuccessOrInfoResponse(DB_res, "Create");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }




        /// <summary>
        /// this method is used to update Offer master
        /// </summary>
        /// <param name="Input">UpdateOffer_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public async Task<IHttpActionResult> UpdateOfferMasterAsync([FromBody] UpdateOffer_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrOffer.UD_UpdateOfferAsync(Input);
                return GetDBSuccessOrInfoResponse(DB_res, "");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }


        /// <summary>
        /// this method is used to Active InActive Offer master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateOffer_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("activeOrInActive")]
        public async Task<IHttpActionResult> ActivateOrInactivateOfferAsync([FromBody] ActivateOrInactivateOffer_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrOffer.UD_ActivateOrInactivateOfferMstrAsyn(Input);
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
