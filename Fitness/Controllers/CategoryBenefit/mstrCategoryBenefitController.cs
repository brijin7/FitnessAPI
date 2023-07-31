using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Fitness.Models.DataAccessLayer.CategoryBenefit;
using static Fitness.Models.BusinessObject.CategoryBenefit.BOL_MstrCategoryBenefit;

namespace Fitness.Controllers.CategoryBenefit
{
    //[Authorize]
    [RoutePrefix("api/categoryBenefitMaster")]

    public class mstrCategoryBenefitController : ApiController
    {
        readonly DAL_MstrCategoryBenefit DAL_CategoryBenefitMaster = new DAL_MstrCategoryBenefit();

        /// <summary>
        /// this method is used to get CategoryBenefitmaster details
        /// </summary>
        /// <param name="Input">GetCategoryBenefitMstr_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetCategoryBenefitMasterAsync([FromUri] GetCategoryBenefitMstr_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetCategoryBenefitMstr_Out = await DAL_CategoryBenefitMaster.UD_GetCategoryBenefitMstrAsync(Input);

                return GetSuccessOrFailureResForSelect<GetCategoryBenefitMstr_Out>(listOfGetCategoryBenefitMstr_Out, "No Records Found In CategoryBenefit Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to get CategoryBenefitmaster details
        /// </summary>
        /// <param name="Input">GetCategoryBenefitMstr_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCategoryBenefit")]
        public async Task<IHttpActionResult> GetCategoryBenefitMasterActiveAsync([FromUri] GetCategoryBenefitMstr_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetCategoryBenefitMstr_Out = await DAL_CategoryBenefitMaster.UD_GetCategoryBenefitActiveMstrAsync(Input);

                return GetSuccessOrFailureResForSelect<GetCategoryBenefitMstr_Out>(listOfGetCategoryBenefitMstr_Out, "No Records Found In CategoryBenefit Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        [HttpGet]
        [Route("GetCategoryBenefitDep")]
        public async Task<IHttpActionResult> GetCategoryBenefitDepMasterActiveAsync([FromUri] GetCategoryBenefitMstr_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetCategoryBenefitMstr_Out = await DAL_CategoryBenefitMaster.UD_GetCategoryBenefitDepActiveMstrAsync(Input);

                return GetSuccessOrFailureResForSelect<GetCategoryBenefitMstr_Out>(listOfGetCategoryBenefitMstr_Out, "No Records Found In CategoryBenefit Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// this method is used to get CategoryBenefitmaster details
        /// </summary>
        /// <param name="Input">GetCategoryBenefitMstr_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCategoryBenefitBasedOnBranch")]
        public async Task<IHttpActionResult> ddlCategoryBenefitMasterActiveAsync([FromUri] ddlCategoryBenefitMstr_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetCategoryBenefitMstr_Out = await DAL_CategoryBenefitMaster.UD_ddlCategoryBenefitMstrAsync(Input);

                return GetSuccessOrFailureResForSelect<GetCategoryBenefitMstr_Out>(listOfGetCategoryBenefitMstr_Out, "No Records Found In CategoryBenefit Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        [HttpGet]
        [Route("GetCategoryBenefitBasedOnType")]
        public async Task<IHttpActionResult> ddlGetCategoryBenefitBasedOnTypeAsync([FromUri] CategoryBenefitBasedOnType Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetCategoryBenefitMstr_Out = await DAL_CategoryBenefitMaster.UD_CategoryBenefitMstrTypeAsync(Input);

                return GetSuccessOrFailureResForSelect<GetCategoryBenefitMstr_Out>(listOfGetCategoryBenefitMstr_Out, "No Records Found In CategoryBenefit Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        /// <summary>
        /// this method is used to insert CategoryBenefitmaster
        /// </summary>
        /// <param name="Input">InsertCategoryBenefit_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IHttpActionResult> InsertCategoryBenefitMasterAsync([FromBody] InsertCategoryBenefit_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_CategoryBenefitMaster.UD_InsertCategoryBenefitMasterAsync(Input);

                return GetDBSuccessOrInfoResponse(DB_res, "Create");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }


        /// <summary>
        /// this method is used to update CategoryBenefitMaster
        /// </summary>
        /// <param name="Input">UpdateCategoryBenefitMstr_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public async Task<IHttpActionResult> UpdateCategoryBenefitMasterAsync([FromBody] UpdateCategoryBenefitMstr_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_CategoryBenefitMaster.UD_UpdateCategoryBenefitMstrAsync(Input);
                return GetDBSuccessOrInfoResponse(DB_res, "");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        [HttpPost]
        [Route("activeOrInActive")]
        public async Task<IHttpActionResult> ActiveOrInactiveCategoryMasterAsync([FromBody] ActivateOrInactivateCategoryBenefitMstr_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_CategoryBenefitMaster.UD_ActivateOrInactivateCategoryBenefitMstrAsyn(Input);
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
