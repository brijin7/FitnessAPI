using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Fitness.Models.DataAccessLayer;
using Fitness.Models.CommonModels;
using static Fitness.Models.BusinessObject.BOL_MstrConfigType;
using System.Data;
using System.Web.Http.ModelBinding;
using System.Linq;
using Microsoft.Ajax.Utilities;

namespace Fitness.Controllers.ConfigType
{
    //[Authorize]
    [RoutePrefix("api/configType")]
    public class mstrConfigTypeController : ApiController
    {
        readonly DAL_MstrConfigurationType DAL = new DAL_MstrConfigurationType();

        #region GetConfigType
        /// <summary>
        /// this method is used to get config type
        /// </summary>
        /// <param name="In">Input parameter</param>
        /// <returns>IHttpActionResult as output</returns>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetConfigTypeAsync()
        {
            try
            {
                DataTable dtbl = await DAL.UD_GetConfigTypeAsync();

                if (dtbl == null || dtbl.Rows.Count == 0)
                {
                    API_SuccessOrErrorOrInfo API_InfoRes = new API_SuccessOrErrorOrInfo()
                    {
                        StatusCode = 0,
                        Response = "No ConfigType Found !!!",
                    };

                    return Content(HttpStatusCode.OK, API_InfoRes);
                }
                else
                {
                    List<GetConfigType_Out> LstOut = new List<GetConfigType_Out>();

                    foreach (DataRow row in dtbl.Rows)
                    {
                        GetConfigType_Out SingleOut = new GetConfigType_Out()
                        {

                            activeStatus = row["activeStatus"].ToString(),
                            typeName = row["typeName"].ToString(),
                            typeId = (int)row["typeId"],
                        };
                        LstOut.Add(SingleOut);
                    }

                    API_Success<GetConfigType_Out> API_SuccessRes = new API_Success<GetConfigType_Out>()
                    {
                        StatusCode = 1,
                        Response = LstOut
                    };
                    return Ok(API_SuccessRes);
                }
            }
            catch (Exception Ex)
            {
                return GetErrorResponse(Ex);
            }
        }
        #endregion
        #region ddlConfigType
        /// <summary>
        /// this method is used to ddl config type
        /// </summary>
        /// <param name="In">Input parameter</param>
        /// <returns>IHttpActionResult as output</returns>
        [HttpGet]
        [Route("getDropDownDetails")]
        public async Task<IHttpActionResult> ddlConfigTypeAsync()
        {
            try
            {


                DataTable dtbl = await DAL.UD_ddlConfigTypeAsync();

                if (dtbl == null || dtbl.Rows.Count == 0)
                {
                    API_SuccessOrErrorOrInfo API_InfoRes = new API_SuccessOrErrorOrInfo()
                    {
                        StatusCode = 0,
                        Response = "No ConfigType Found !!!",
                    };

                    return Content(HttpStatusCode.OK, API_InfoRes);
                }
                else
                {
                    List<ddlConfigType_Out> LstOut = new List<ddlConfigType_Out>();

                    foreach (DataRow row in dtbl.Rows)
                    {
                        ddlConfigType_Out SingleOut = new ddlConfigType_Out()
                        {
                            typeName = row["typeName"].ToString(),
                            typeId = (int)row["typeId"],
                        };
                        LstOut.Add(SingleOut);
                    }

                    API_Success<ddlConfigType_Out> API_SuccessRes = new API_Success<ddlConfigType_Out>()
                    {
                        StatusCode = 1,
                        Response = LstOut
                    };
                    return Ok(API_SuccessRes);
                }
            }
            catch (Exception Ex)
            {
                return GetErrorResponse(Ex);
            }
        }
        #endregion
        #region InsertConfigType
        /// <summary>
        /// this method is used to insert config type
        /// </summary>
        /// <param name="In">Input parameter</param>
        /// <returns>IHttpActionResult as output</returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IHttpActionResult> InsertConfigTypeAsync([FromBody] InsertConfigType_In Input)
        {
            try
            {
                if (Input == null || !ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL.UD_InsertConfigTypeAsync(Input);
                return GetDBSuccessOrInfoResponse(DB_res, "Create");
            }
            catch (Exception Ex)
            {
                return GetErrorResponse(Ex);
            }
        }
        #endregion
        #region UpdateConfigType
        /// <summary>
        /// this method is use to update configtype
        /// </summary>
        /// <param name="In">UpdateConfigType_In class as input parameter</param>
        /// <returns>IHttpActionResult as output</returns>
        [HttpPost]
        [Route("update")]
        public async Task<IHttpActionResult> InsertConfigTypeAsync([FromBody] UpdateConfigType_In Input)
        {
            try
            {
                if (Input == null || !ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL.UD_UpdateConfigTypeAsync(Input);
                return GetDBSuccessOrInfoResponse(DB_res, "Update");
            }
            catch (Exception Ex)
            {
                return GetErrorResponse(Ex);
            }
        }
        #endregion
        #region ActivateInActiveConfigType
        /// <summary>
        /// this method is used to activate inactive configtype 
        /// </summary>
        /// <param name="In">ActivateConfigType_In class as input</param>
        /// <returns>IHttpActionResult as output</returns>
        [HttpPost]
        [Route("activeOrInActive")]
        public async Task<IHttpActionResult> ActivateConfigTypeAsync([FromBody] ActivateOrInactivateConfigType_In Input)
        {
            try
            {
                if (Input == null || !ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                DB_Response DB_res = await DAL.UD_ActivateConfigTypeAsync(Input);
                return GetDBSuccessOrInfoResponse(DB_res, "Update");
            }
            catch (Exception Ex)
            {
                return GetErrorResponse(Ex);
            }
        }
        #endregion

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
