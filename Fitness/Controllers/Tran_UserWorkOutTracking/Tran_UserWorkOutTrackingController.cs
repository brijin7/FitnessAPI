using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Fitness.Models.BusinessObject.Tran_UserWorkOutTracking.BOL_UserWorkOutTracking;
using Fitness.Models.CommonModels;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Fitness.Models.DataAccessLayer.Tran_UserWorkOutTracking;

namespace Fitness.Controllers.Tran_UserWorkOutTracking
{
                    //[Authorize]
    [RoutePrefix("api/UserWorkOutTracking")]
    public class Tran_UserWorkOutTrackingController : ApiController
    {
        readonly DAL_UserWorkOutTracking DAL_MstrWorkOutType = new DAL_UserWorkOutTracking();

        /// <summary>
        /// this method is used to get Work Out Tracking Category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetTran_WorkoutTrackingAsync([FromUri] GetTran_WorkoutTracking_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetMstrWorkoutType_Out = await DAL_MstrWorkOutType.UD_GetTran_WorkoutTrackingAsync(Input);

                return GetSuccessOrFailureResForSelect<GetTran_WorkoutTracking_Out>(listOfGetMstrWorkoutType_Out, "No Records Found In WorkOut Tracking!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to get Work Out Tracking Category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTranUserWorkOutTrackingBasedonDateDay")]
        public async Task<IHttpActionResult> GetTran_WorkoutTrackingBasedonDateDayAsync([FromUri] GetTran_WorkoutTrackingBasedonDateDay_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetMstrWorkoutType_Out = await DAL_MstrWorkOutType.UD_GetTran_WorkoutTrackingBasedonDateDayAsync(Input);

                return GetSuccessOrFailureResForSelect<GetTran_WorkoutTrackingBasedonDateDay_Out>(listOfGetMstrWorkoutType_Out, "No Records Found In WorkOut Tracking!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to get Work Out Tracking Category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTranUserWorkOutTrackingBasedonDateDayCategoryIdWorkoutTypeId")]
        public async Task<IHttpActionResult> GetTran_WorkoutTrackingBasedonDateDayCategoryIdWorkoutTypeIdAsync([FromUri] GetTran_WorkoutTrackingBasedonDateDayCategoryIdWorkoutTypeId_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetMstrWorkoutType_Out = await DAL_MstrWorkOutType.UD_GetTran_WorkoutTrackingBasedonDateDayCategoryIdWorkoutTypeIdAsync(Input);

                return GetSuccessOrFailureResForSelect<GetTran_WorkoutTrackingBasedonDateDayCategoryIdWorkoutTypeId_Out>(listOfGetMstrWorkoutType_Out, "No Records Found In WorkOut Tracking!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }


        /// <summary>
        /// this method is used to get categorymaster details
        /// </summary>
        /// <param name="Input">GetCategoryMstr_In class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("AllDateBasedWorkoutPlane")]
        public async Task<IHttpActionResult> GetAllDateBasedeWorkoutPlaneMasterAsync([FromUri] GetTwodateWorkoutPlane_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetCategoryMstr_Out = await DAL_MstrWorkOutType.GetTwoDateUserFoodMenuAsync(Input);

                return GetSuccessOrFailureResForSelect<GetTwodateWorkoutPlaneOutNew>(listOfGetCategoryMstr_Out, "No Records Found In WorkOut Plane Master!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }



        /// <summary>
        /// This Method Used For Insert WorkOut Type Master
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IHttpActionResult> InsertTran_WorkoutTrackingAsyc([FromBody] InsertTran_WorkoutTracking_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrWorkOutType.UD_InsertTran_WorkoutTrackingAsyc(Input);

                return GetDBSuccessOrInfoResponse(DB_res, "Create");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to update WorkOut Type Master
        /// </summary>
        /// <param name="Input">UpdateMstrWorkoutType_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public async Task<IHttpActionResult> UpdateTran_WorkoutTrackingAsyc([FromBody] UpdateTran_WorkoutTracking_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrWorkOutType.UD_UpdateTran_WorkoutTrackingAsyc(Input);
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
