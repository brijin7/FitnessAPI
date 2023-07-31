using Fitness.Models.CommonModels;
using Fitness.Models.DataAccessLayer.UserMenuAccess;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using static Fitness.Models.BusinessObject.UserMenuAccess.BOL_MstrUserMenuAccess;
namespace Fitness.Controllers.UserMenuAccess
{

                  //[Authorize]
    [RoutePrefix("api/userMenuAccess")]
    public class MstrUserMenuAccessController : ApiController
    {
        readonly DAL_MstrUserAccessMenu MenuAccess = new DAL_MstrUserAccessMenu();

        /// <summary>
        /// this method is used to get Roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getRoles")]
        public async Task<IHttpActionResult> GetRoles()
        {
            try
            {
                JArray OutJArray = await MenuAccess.UD_GetRolesAsync();
                return GetSuccessOrFailureResForJArray(OutJArray, "No Employee Found !!!."); ;
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        /// <summary>
        /// this method is used to get Employee Details
        /// </summary>
        /// <param name="Input">GetEmployee_In Class as Input</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getEmployee")]
        public async Task<IHttpActionResult> GetEmployee([FromUri] GetEmployee_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                JArray OutJArray = await MenuAccess.UD_GetEmployeeAsync(Input);
                return GetSuccessOrFailureResForJArray(OutJArray, "No Employee Found !!!."); ;
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        /// <summary>
        /// this method is used to get Menu Options
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getMenuOptions")]
        public async Task<IHttpActionResult> GetMenuOptions([FromUri] GetAllOptionsName_In Input)
        {
            try
            {
                JArray OutJArray = await MenuAccess.UD_GetMenuOptionsAsync(Input);
                return GetSuccessOrFailureResForJArray(OutJArray, "No Menu Options Found !!!."); ;
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        /// <summary>
        /// this method is used to get Menu Options
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getMenuOptionsForUpdate")]
        public async Task<IHttpActionResult> GetMenuOptionsForUpdate([FromUri] GetAllOptionsNameForUpdate_In Input)
        {
            try
            {
                JArray OutJArray = await MenuAccess.UD_GetMenuOptionsForUpdateAsync(Input);
                return GetSuccessOrFailureResForJArray(OutJArray, "No Menu Options Found !!!."); ;
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        /// <summary>
        /// this method is used to Get EmpName For GV
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getEmpNameForGV")]
        public async Task<IHttpActionResult> GetEmpNameForGV([FromUri] GetEmpNameForGV_In Input)
        {
            try
            {
                JArray OutJArray = await MenuAccess.UD_GetEmpNameForGV(Input);
                return GetSuccessOrFailureResForJArray(OutJArray, "No Employee Details Found !!!."); ;
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }


        /// <summary>
        /// this method is used to insert Menu Access
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IHttpActionResult> InsertMenuOptions([FromBody] InsertMenuAccess_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response res = await MenuAccess.UD_InsertUserAccessAsync(Input);

                return GetDBSuccessOrInfoResponse(res, "Create");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }


        /// <summary>
        /// this method is used to Update Menu Access
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public async Task<IHttpActionResult> UpdateMenuOptions([FromBody] UpdateMenuAccess_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response res = await MenuAccess.UD_UpdateUserAccessAsync(Input);

                return GetDBSuccessOrInfoResponse(res, "");
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
