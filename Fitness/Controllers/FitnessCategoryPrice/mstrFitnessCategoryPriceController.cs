using static Fitness.Models.BusinessObject.FitnessCategoryPrice.BOL_MstrFitnessCategoryPrice;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Fitness.Models.DataAccessLayer.FitnessCategoryPrice;
using System.Net.Http.Headers;
using System.Data;
using Newtonsoft.Json;
using Fitness.Models.BusinessObject.FitnessCategoryPrice;

namespace Fitness.Controllers
{
    //[Authorize]
    [RoutePrefix("api/fitnessCategoryPrice")]
    public class mstrFitnessCategoryPriceController : ApiController
    {
        readonly DAL_MstrFitnessCatogoryPrice DAL_MstrFitnessCatogoryPrice = new DAL_MstrFitnessCatogoryPrice();
        /// <summary>
        /// this method is used to get FitnessCategoryPrice Master details
        /// </summary>
        /// <param name="Input">GetMstrFitnessCategoryPrice_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetMstrFitnessCategoryPriceAsync([FromUri] GetMstrFitnessCategoryPrice_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetMstrFitnessCategoryPrice_Out = await DAL_MstrFitnessCatogoryPrice.UD_GetMstrFitnessCategoryPriceAsync(Input);

                return GetSuccessOrFailureResForSelect<GetMstrFitnessCategoryPrice_Out>(listOfGetMstrFitnessCategoryPrice_Out, "No Records Found In Fitness Category Price Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to Get Price Details
        /// </summary>
        /// <param name="Input">GetUserFoodMenu_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPriceDetails")]
        public async Task<IHttpActionResult> GetMstrUserAsync([FromUri] GetPriceDetails_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                string GetPriceDetails = await DAL_MstrFitnessCatogoryPrice.GetPriceDetailsAsync(Input);
                if (!string.IsNullOrEmpty(GetPriceDetails))
                {
                    if (GetPriceDetails != "No Data Found")
                    {
                        var result = JsonConvert.DeserializeObject(GetPriceDetails);
                        GetPriceDetails_Out output = new GetPriceDetails_Out()
                        {
                            StatusCode = 1,
                            GetPriceDetails = result
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




        [HttpGet]
        [Route("GetPriceOnPublicWeb")]
        public async Task<IHttpActionResult> GetGetPriceOnPublicWebAsync([FromUri] GetPriceOnPublicWeb_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetPriceOnPublicWeb_Out = await DAL_MstrFitnessCatogoryPrice.UD_GetPriceOnPublicWebAsync(Input);

                return GetSuccessOrFailureResForSelect<GetPriceOnPublicWeb_Out>(listOfGetPriceOnPublicWeb_Out, "No Records Found In Fitness Category Price Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }


        /// <summary>
        /// Used to Get FitnessCategoryPrice Based on Category / Duration
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPriceOnCategory")]
        public async Task<IHttpActionResult> GetMstrFitnessCategoryPriceOnCategoryAsync([FromUri] GetMstrFitnessCategoryPriceonCategory Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetMstrFitnessCategoryPrice_Out = await DAL_MstrFitnessCatogoryPrice.UD_GetMstrFitnessCategoryPriceOnCategoryAsync(Input);

                return GetSuccessOrFailureResForSelect<GetMstrFitnessCategoryPrice_Out>(listOfGetMstrFitnessCategoryPrice_Out, "No Records Found In Fitness Category Price Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// Used to Get FitnessCategoryPrice Based on Category / Duration
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPriceOnDuration")]
        public async Task<IHttpActionResult> GetMstrFitnessCategoryPriceOnDurationAsync([FromUri] GetMstrFitnessCategoryPriceonDuration Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetMstrFitnessCategoryPrice_Out = await DAL_MstrFitnessCatogoryPrice.UD_GetMstrFitnessCategoryPriceOnDurationAsync(Input);

                return GetSuccessOrFailureResForSelect<GetMstrFitnessCategoryPrice_Out>(listOfGetMstrFitnessCategoryPrice_Out, "No Records Found In Fitness Category Price Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// Used to Get FitnessCategoryPrice Based on Category / Duration
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFitnessCategoryPriceDetailsForSlot")]
        public async Task<IHttpActionResult> GetMstrFitnessCategoryPriceOnDurationAsync([FromUri] GetMstrFitnessCategoryPriceDetailsForSlot_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetMstrFitnessCategoryPrice_Out = await DAL_MstrFitnessCatogoryPrice.UD_GetMstrFitnessCategoryPriceDetailsForSlotAsync(Input);

                return GetSuccessOrFailureResForSelect<GetMstrFitnessCategoryPriceDetailsForSlot_Out>(listOfGetMstrFitnessCategoryPrice_Out, "No Records Found In Fitness Category Price Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        [HttpGet]
        [Route("GetTax")]
        public async Task<IHttpActionResult> GetMstrFitnessCategorytaxAsync([FromUri] GetMstrFitnessCategorytax_In Input)
        {
            try
            {

                List<GetMstrFitnessCategorytax_Out> lst = new List<GetMstrFitnessCategorytax_Out>();
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://ttdc.in/node/gst/myapp/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("gst/" + Input.netAmount + "/" + 0 + "/" + Input.taxPercentage + "/" + 2 + "");

                    if (response.IsSuccessStatusCode)
                    {

                        var ResponseMsg = response.Content.ReadAsStringAsync().Result;
                        string[] BCharge = ResponseMsg.Split(':');
                        string[] bamt = BCharge[1].ToString().Split(',');
                        string[] bgst = BCharge[2].ToString().Split('}');
                        lst.AddRange(new List<GetMstrFitnessCategorytax_Out>
                        {
                            new GetMstrFitnessCategorytax_Out { netAmount=bamt[0] ,tax=bgst[0]}

                        });


                    }
                }
                return GetSuccessOrFailureResForSelect<GetMstrFitnessCategorytax_Out>(lst, "Invalid !!!");

            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Input">InsertMstrFitnessCategoryPrice_In</param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IHttpActionResult> InsertMstrFitnessCategoryPriceAsync([FromBody] InsertMstrFitnessCategoryPrice_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrFitnessCatogoryPrice.UD_InsertMstrFitnessCategoryPriceAsyc(Input);

                return GetDBSuccessOrInfoResponse(DB_res, "Create");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to update FitnessCategoryPriceMaster
        /// </summary>
        /// <param name="Input">UpdateMstrFitnessCategoryPrice_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public async Task<IHttpActionResult> UpdateMstrFitnessCategoryPriceAsync([FromBody] UpdateMstrFitnessCategoryPrice_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrFitnessCatogoryPrice.UD_UpdateMstrFitnessCategoryPriceAsyc(Input);
                return GetDBSuccessOrInfoResponse(DB_res, "");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        /// <summary>
        /// Update Active Status
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("activeOrInActive")]
        public async Task<IHttpActionResult> ActivateOrInactivateMstrFitnessCategoryPriceAsync([FromBody] ActivateOrInactivateMstrFitnessCategoryPrice_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrFitnessCatogoryPrice.UD_ActivateOrInactivateMstrFitnessCategoryPriceAsyc(Input);
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
