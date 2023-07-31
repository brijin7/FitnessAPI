﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Fitness.Models.BusinessObject.Tran_UserWorkOutPlan.BOL_UserWorkOutPlan;
using Fitness.Models.CommonModels;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Fitness.Models.DataAccessLayer.Tran_UserWorkOutPlan;


namespace Fitness.Controllers.Tran_UserWorkOutPlan
{
  //[Authorize]
    [RoutePrefix("api/UserWorkOutPlan")]
    public class Tran_UserWorkOutPlanController : ApiController
    {
        readonly DAL_UserWorkOutPlan DAL_MstrWorkOutType = new DAL_UserWorkOutPlan();

        /// <summary>
        /// this method is used to get Work Out Plan Category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetTran_WorkoutPlanAsync([FromUri] GetTran_WorkoutPlan_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetMstrWorkoutType_Out = await DAL_MstrWorkOutType.UD_GetTran_WorkoutPlanAsync(Input);

                return GetSuccessOrFailureResForSelect<GetTran_WorkoutPlan_Out>(listOfGetMstrWorkoutType_Out, "No Records Found In WorkOut Plan!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to get Work Out Plan Category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetWorkoutTypesOnCategory")]
        public async Task<IHttpActionResult> GetTran_WorkoutPlanOnCategoryAsync([FromUri] GetTran_WorkoutPlanOnCategory_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetMstrWorkoutType_Out = await DAL_MstrWorkOutType.UD_GetTran_WorkoutPlanOnCategoryAsync(Input);

                return GetSuccessOrFailureResForSelect<GetTran_WorkoutPlan_Out>(listOfGetMstrWorkoutType_Out, "No Records Found In WorkOut Type!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to get Work Out Plan Category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCategoryTypeBasedonDateDay")]
        public async Task<IHttpActionResult> GetTran_WorkoutPlanBasedonDateDayAsync([FromUri] GetTran_CategoryTypeBasedonDateDay_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetMstrWorkoutType_Out = await DAL_MstrWorkOutType.UD_GetTran_WorkoutPlanBasedonDateDayAsync(Input);

                return GetSuccessOrFailureResForSelect<GetTran_CategoryTypeBasedonDateDay_Out>(listOfGetMstrWorkoutType_Out, "No Records Found In WorkOut Plan!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        [HttpGet]
        [Route("GetCategoryTypeBasedonDateDayCategory")]
        public async Task<IHttpActionResult> GetTran_WorkoutPlanBasedonDateDayCategoryAsync([FromUri] GetTran_CategoryTypeBasedonDateDayCategory_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetMstrWorkoutType_Out = await DAL_MstrWorkOutType.UD_GetTran_WorkoutPlanBasedonDateDayCategoryAsync(Input);

                return GetSuccessOrFailureResForSelect<GetTran_CategoryTypeBasedonDateDayCategory_Out>(listOfGetMstrWorkoutType_Out, "No Records Found In WorkOut Plan!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to get Work Out Plan Category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetWorkoutTypeBasedonDateDay")]
        public async Task<IHttpActionResult> GetTran_WorkoutPlanOnCategoryBasedonDateDayAsync([FromUri] GetTran_WorkoutTypeBasedonDateDay_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetMstrWorkoutType_Out = await DAL_MstrWorkOutType.UD_GetTran_WorkoutPlanOnCategoryBasedonDateDayAsync(Input);

                return GetSuccessOrFailureResForSelect<GetTran_WorkoutTypeBasedonDateDay_Out>(listOfGetMstrWorkoutType_Out, "No Records Found In WorkOut Type!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// this method is used to get Work Out Plan Category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSetTypeBasedonDate")]
        public async Task<IHttpActionResult> GetTran_SetTypeBasedonDateDayAsync([FromUri] GetTran_SetTypeBasedonDateDay_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetMstrWorkoutType_Out = await DAL_MstrWorkOutType.UD_GetTran_SetTypeBasedonDateDayAsync(Input);

                return GetSuccessOrFailureResForSelect<GetTran_SetType_Out>(listOfGetMstrWorkoutType_Out, "No Records Found In WorkOut Type!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetWorkPlanBasedBookingIdandDay")]
        public async Task<IHttpActionResult> GetTran_SetTypeBasedonBookingIdandDayAsync([FromUri] GetTran_WorkoutPlanBasedBookingIdandDay_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfGetMstrWorkoutType_Out = await DAL_MstrWorkOutType.UD_GetTran_WorkoutPlanBasedBookingIdandDayAsync(Input);

                return GetSuccessOrFailureResForSelect<GetTran_WorkoutPlan_Out>(listOfGetMstrWorkoutType_Out, "No Records Found In WorkOut Type!!!");
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
        public async Task<IHttpActionResult> InsertTran_WorkoutPlanAsyc([FromBody] InsertTranrWorkoutPlan_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrWorkOutType.UD_InsertTranWorkoutPlane(Input);

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
        public async Task<IHttpActionResult> UpdateTran_WorkoutPlanAsyc([FromBody] UpdateTran_WorkoutPlan_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrWorkOutType.UD_UpdateTran_WorkoutPlanAsyc(Input);
                return GetDBSuccessOrInfoResponse(DB_res, "");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }


        /// <summary>
        /// this method is used to update DietPlanApproveStatus Type Master
        /// </summary>
        /// <param name="Input">UpdateTran_DietPlanApproveStatus_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateApproveStatus")]
        public async Task<IHttpActionResult> UpdateTran_DietPlanApproveStatusAsyc([FromBody] UpdateTran_DietPlanApproveStatus_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrWorkOutType.UD_UpdateTran_DietPlanAsyc(Input);
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
