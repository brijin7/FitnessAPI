using Fitness.Models.CommonModels;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using static System.Net.Mime.MediaTypeNames;
using static Fitness.Helper.CommonMethods;
using System.Threading;
using static Fitness.Models.BusinessObject.SignUpandSignInExcel.BOL_SignUpandSignInExcel;
using Fitness.Models.DataAccessLayer.SignUpandSignInExcel;
using Swashbuckle.Swagger;

namespace Fitness.Controllers.SignUpandSignInExcel
{
                  //[Authorize]
    [RoutePrefix("api/SignupExcel")]
    public class SignupandSignInExcelController : ApiController
    {
        readonly DAL_SignUpandSignInExcel _signUpandSignInExcel = new DAL_SignUpandSignInExcel();
        /// <summary>
        /// this api is used to get signup excel
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult ShowExcel()
        {
            try
            {
                string Path = AppDomain.CurrentDomain.BaseDirectory;
                FileInfo fileInfo = new FileInfo($"{Path}Controllers\\SignUpandSignInExcel\\Signup.xlsx");
                FileStream stream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.Read);

                if (fileInfo.Length > 0)
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StreamContent(stream);
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue($"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = "SignUp.xlsx"
                    };
                    return ResponseMessage(response);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, $"No Excel Files Found !!!");
                }
            }
            catch (Exception Ex)
            {
                return Content(HttpStatusCode.InternalServerError, Ex.Message.ToString());
            }
        }


        /// <summary>
        /// this method is used to Insert SignUp using Excel
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Insert")]
        public async Task<IHttpActionResult> InsertSignUpAsync()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return GetBadRequestResponse("UnsupportedMediaType", "USM");
                }

                HttpPostedFile File = HttpContext.Current.Request.Files["Excel"];
                string RoleId = HttpContext.Current.Request.Params["RoleId"].ToString().Trim();
                string CreatedBy = HttpContext.Current.Request.Params["CreatedBy"].ToString().Trim();
                string GymOwnerId = HttpContext.Current.Request.Params["GymOwnerId"].ToString().Trim();
                string branchId = HttpContext.Current.Request.Params["BranchId"].ToString().Trim();

                if (string.IsNullOrEmpty(RoleId) ||
                    string.IsNullOrEmpty(CreatedBy) ||
                    string.IsNullOrEmpty(GymOwnerId) ||
                    string.IsNullOrEmpty(branchId))
                {
                    string InfoMessage = "";
                    if (string.IsNullOrEmpty(RoleId))
                    {
                        InfoMessage += "RoleId Field Is Required, ";
                    }
                    if (string.IsNullOrEmpty(CreatedBy))
                    {
                        InfoMessage += "CreatedBy Field Is Required, ";
                    }
                    if (string.IsNullOrEmpty(GymOwnerId))
                    {
                        InfoMessage += "GymOwnerId Field Is Required, ";
                    }
                    if (string.IsNullOrEmpty(branchId))
                    {
                        InfoMessage += "branchId Field Is Required, ";
                    }

                    return GetBadRequestResponse(InfoMessage.Trim().TrimEnd(','));
                }


                IList<string> AllowedFileExtensions = new List<string> { "xlsx" };

                if (!AllowedFileExtensions.Contains(File.FileName.Split('.')[1].ToLower()))
                {
                    return GetBadRequestResponse("only .xlsx Excel format is supported.");
                }


                DataTable dtExcel = new DataTable("ExcelTable");

                MastrSignUpCommon commonFields = new MastrSignUpCommon()
                {
                    BranchId = Convert.ToInt32(branchId),
                    CreatedBy = Convert.ToInt32(CreatedBy),
                    GymOwnerId = Convert.ToInt32(GymOwnerId),
                    RoleId = Convert.ToInt32(RoleId)
                };
                if (File.ContentLength > 0)
                {
                    dtExcel = ConvertExcelToDataTable(File);

                    if (dtExcel.Rows.Count > 0)
                    {
                        DB_Response res = await _signUpandSignInExcel.UD_InsertSignup(dtExcel, commonFields);

                        return GetDBSuccessOrInfoResponse(res, "Create");
                    }
                    else
                    {
                        return GetBadRequestResponse("No Records Found In Excel File.");
                    }
                }
                else
                {
                    return GetBadRequestResponse("No File Found.");
                }
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
        /// this method is used to get Bad Request Response
        /// </summary>
        /// <param name="Response"></param>
        /// <returns></returns>
        private IHttpActionResult GetBadRequestResponse(string Response, string ResponseType = "BR")
        {
            if (Response == "USM")
            {
                DB_Response DB_Response = new DB_Response()
                {
                    StatusCode = 0,
                    Response = Response
                };
                return Content(HttpStatusCode.UnsupportedMediaType, DB_Response);
            }
            else
            {
                DB_Response DB_Response = new DB_Response()
                {
                    StatusCode = 0,
                    Response = Response
                };
                return Content(HttpStatusCode.BadRequest, DB_Response);
            }
        }
    }
}
