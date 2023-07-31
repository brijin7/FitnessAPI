using Fitness.Models.CommonModels;
using Fitness.Models.DataAccessLayer.CategorySlot;
using Fitness.Models.DataAccessLayer.FitnessCategorySlot;
using Fitness.Models.DataAccessLayer.OwnerMaster;
using Fitness.Models.DataAccessLayer.TrainerDetails;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using static Fitness.Models.BusinessObject.CategorySlot.BOL_CategorySlot;


namespace Fitness.Controllers.CategorySlot
{ 
     //[Authorize]
    [RoutePrefix("api/categorySlot")]
    public class CategorySlotController : ApiController
    {
        readonly DAL_CategorySlot DAL_CategorySlot = new DAL_CategorySlot();
        /// <summary>
        /// this method is used to get  details
        /// </summary>
        /// <param name="Input">GetCategorySlots_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetMstrCategorySlotAsync([FromUri] GetCategorySlots_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                string categorySlot = await DAL_CategorySlot.UD_GetCategorySlotAsync(Input);
                if (!string.IsNullOrEmpty(categorySlot))
                {
                    if (categorySlot != "No Data Found")
                    {
                        var result = JsonConvert.DeserializeObject(categorySlot);
                        CategorySlots_Out output = new CategorySlots_Out()
                        {
                            StatusCode = 1,
                            CategorySlot = result
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
        /// this method is used to get  details
        /// </summary>
        /// <param name="Input">GetCategorySlots_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getCategorySlotDetails")]
        public async Task<IHttpActionResult> GetCategorySlotDetailsAsync(GetCategorySlotsDetails_In Input)
        {
            try
            {
                var listOfGetMstrOwner_Out = await DAL_CategorySlot.UD_GetMstrCategorySlotDetails(Input);

                return GetSuccessOrFailureResForJArray(listOfGetMstrOwner_Out, "No Records Found In CategorySlot!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IHttpActionResult> InsertCategorySlotsAsync([FromBody] InsertCategorySlots_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_CategorySlot.UD_InsertCategorySlot(Input);

                return GetDBSuccessOrInfoResponse(DB_res, "Create");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        /// <summary>
        /// this method is used to update OwnerMaster
        /// </summary>
        /// <param name="Input">UpdateMstrOwner_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public async Task<IHttpActionResult> UpdateMstrcategorySlotAsync([FromBody] UpdateCategorySlots_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_CategorySlot.UD_UpdateCategorySlot(Input);
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
