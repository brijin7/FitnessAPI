using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Data;
using Newtonsoft.Json;
using Fitness.Models.DataAccessLayer.TrainerTracking;
using static Fitness.Models.BusinessObject.TrainerTracking.BOL_TrainerTracking;
using static Fitness.Models.BusinessObject.TrainerAttendance.BOL_UserAttendance;
using Newtonsoft.Json.Linq;

namespace Fitness.Controllers.TrainerTracking
{   //[Authorize]
    [RoutePrefix("api/trainerTracking")]
    public class Tran_TrainerTrackingController : ApiController
    {

        readonly DAL_TrainerTracking DAL_TrainerTracking = new DAL_TrainerTracking();


        [HttpGet]
        [Route("GetTrainerWorkOutOverall")]
        public async Task<IHttpActionResult> GetTrainerWorkOutOverallAsync([FromUri] GetTrainerWorkOutOverall_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                string TrainerDetails = await DAL_TrainerTracking.GetTrainerWorkoutOverallAsync(Input);
                if (!string.IsNullOrEmpty(TrainerDetails))
                {
                    if (TrainerDetails != "No Data Found")
                    {
                        var result = JsonConvert.DeserializeObject(TrainerDetails);
                        GetTrainerWorkOutOverall_Out output = new GetTrainerWorkOutOverall_Out()
                        {
                            StatusCode = 1,
                            TrainerDetails = result
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
        [Route("GetTrainerWorkOutList")]
        public async Task<IHttpActionResult> GetTrainerWorkoutListAsync([FromUri] GetTrainerWorkOutList_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                string TrainerDetails = await DAL_TrainerTracking.GetTrainerWorkoutListAsync(Input);
                if (!string.IsNullOrEmpty(TrainerDetails))
                {
                    if (TrainerDetails != "No Data Found")
                    {
                        var result = JsonConvert.DeserializeObject(TrainerDetails);
                        GetTrainerWorkOutList_Out output = new GetTrainerWorkOutList_Out()
                        {
                            StatusCode = 1,
                            TrainerDetails = result
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
        [Route("GetTrainerslotcompletedList")]
        public async Task<IHttpActionResult> UD_GetTrainerslotcompletedAsync([FromUri] GetTrainerslotcompletedList_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfTrainerAttendance_Out = await DAL_TrainerTracking.GetTrainerslotcompletedAsync(Input);

                return GetSuccessOrFailureResForJArray(listOfTrainerAttendance_Out, "No Records Found In Trainer Tracking!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }
        /// <summary>
        /// this method is used to update Trainer Workout
        /// </summary>
        /// <param name="Input">UpdateTran_WorkoutPlan_In class as input parameter</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public async Task<IHttpActionResult> UpdateTrainerWorkoutAsync([FromBody] UpdateTrainerWorkout_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_TrainerTracking.UpdateTrainerWorkoutAsync(Input);
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