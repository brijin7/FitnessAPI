﻿using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Data;
using Newtonsoft.Json;
using Fitness.Models.DataAccessLayer.TrainerDetails;
using static Fitness.Models.BusinessObject.TrainerDetails.BOL_MstrTrainerDetails;
using Fitness.Models.DataAccessLayer.FitnessCategorySlot;
using static Fitness.Models.BusinessObject.FitnessCategorySlot.BOL_FitnessCategorySlot;
using Fitness.Models.DataAccessLayer.CategorySlot;
using static Fitness.Models.BusinessObject.CategorySlot.BOL_CategorySlot;
using Newtonsoft.Json.Linq;

namespace Fitness.Controllers.TrainerDetails
{    //[Authorize]
	[RoutePrefix("api/trainerDetails")]
	public class MstrTrainerDetailsController : ApiController
	{
		readonly DAL_MstrTrainerDetails DAL_MstrTrainerDetails = new DAL_MstrTrainerDetails();


		[HttpGet]
		[Route("")]
		public async Task<IHttpActionResult> GetMstrTrainerDetailsAsync([FromUri] GetMstrTrainerDetails_In Input)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return GetModelResponse(Input, ModelState);
				}
				string TrainerDetails = await DAL_MstrTrainerDetails.GetTrainerDetailsAsync(Input);
				if (!string.IsNullOrEmpty(TrainerDetails))
				{
					if (TrainerDetails != "No Data Found")
					{
						var result = JsonConvert.DeserializeObject(TrainerDetails);
						GetMstrTrainerDetails_Out output = new GetMstrTrainerDetails_Out()
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


        /// <summary>
        /// this method is used to get GetTrainerDetailsApproval 
        /// </summary>
        /// <param name="Input">GetTrainerDetailsApproval class as input parameter</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTrainerDetailsApproval")]
        public async Task<IHttpActionResult> UD_GetTrainerDetailsApprovalAsync([FromUri] GetMstrTrainerDetailsApproval_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }
                var listOfTrainerAttendance_Out = await DAL_MstrTrainerDetails.GetTrainerDetailsApprovalAsync(Input);

                return GetSuccessOrFailureResForJArray(listOfTrainerAttendance_Out, "No Records Found In Trainer Details!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        [HttpGet]
        [Route("getTrainerSpecialist")]
        public async Task<IHttpActionResult> GetCategorySlotDetailsAsync([FromUri] GetMstrTrainerDetails_In Input)
        {
            try
            {
                var listOfGetMstrOwner_Out = await DAL_MstrTrainerDetails.GetTrainerSpecialistAsync(Input);

                return GetSuccessOrFailureResForJArray(listOfGetMstrOwner_Out, "No Records Found In Trainer Details!!!");
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        [HttpPost]
		[Route("insert")]
		public async Task<IHttpActionResult> InsertMstrTraineDetailsrAsyc([FromBody] InsertMstrTrainerDetails_In Input)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return GetModelResponse(Input, ModelState);
				}

				DB_Response DB_res = await DAL_MstrTrainerDetails.UD_InsertMstrTrainerDetailsAsyc(Input);

				return GetDBSuccessOrInfoResponse(DB_res, "Create");
			}
			catch (Exception ex)
			{
				return GetErrorResponse(ex);
			}
		}

		[HttpPost]
		[Route("update")]
		public async Task<IHttpActionResult> UpdateMstrTrainerDetailsAsync([FromBody] UpdateMstrTrainerDetails_In Input)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return GetModelResponse(Input, ModelState);
				}

				DB_Response DB_res = await DAL_MstrTrainerDetails.UD_UpdateMstrTrainerDetailsAsyc(Input);
				return GetDBSuccessOrInfoResponse(DB_res, "");
			}
			catch (Exception ex)
			{
				return GetErrorResponse(ex);
			}
		}

        [HttpPost]
        [Route("approveOrInApprove")]
        public async Task<IHttpActionResult> ActiveOrInactiveCategoryMasterAsync([FromBody] ApproveOrInapproveTrainerDetails_In Input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetModelResponse(Input, ModelState);
                }

                DB_Response DB_res = await DAL_MstrTrainerDetails.UD_ApproveOrInapproveTrainerDetailsAsyn(Input);
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