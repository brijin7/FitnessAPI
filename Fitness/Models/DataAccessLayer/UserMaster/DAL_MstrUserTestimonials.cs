using Fitness.Helper;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.UserMaster.BOL_MstrUserTestimonials;

namespace Fitness.Models.DataAccessLayer.UserMaster
{
    public class DAL_MstrUserTestimonials : SqlHelper
    {

        /// <summary>
        /// this method is used to insert details in UserTestimonials in db
        /// </summary>
        /// <param name="Input">InsertUserTestimonials_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertMstrUserTestimonialsAsync(InsertUserTestimonials_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };               
                SqlParameter imageUrl = new SqlParameter
                {
                    ParameterName = "imageUrl",
                    Value = Input.imageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };               
                SqlParameter feedbackRating = new SqlParameter
                {
                    ParameterName = "feedbackRating",
                    Value = Input.feedbackRating,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };               
                SqlParameter feedbackComment = new SqlParameter
                {
                    ParameterName = "feedbackComment",
                    Value = Input.feedbackComment,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };               
                SqlParameter dispayStatus = new SqlParameter
                {
                    ParameterName = "dispayStatus",
                    Value = Input.dispayStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, bookingId,
                    imageUrl,feedbackRating,feedbackComment,dispayStatus,createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrUserTestimonials", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch UserTestimonials details from db
        /// </summary>
        /// <param name="Input">GetUserTestimonials_In class as input parameter</param>
        /// <returns>list of GetUserTestimonials_Out as output</returns>
        public async Task<List<GetUserTestimonials_Out>> UD_GetUserTestimonialsAsync(GetUserTestimonials_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getMstrUserTestimonials",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, bookingId};

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrUserTestimonials", allParameters);

                List<GetUserTestimonials_Out> lstOfOutput = new List<GetUserTestimonials_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetUserTestimonials_Out Output = new GetUserTestimonials_Out();
                    Output.feedbackId = (int)(dr["feedbackId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.feedbackRating = (int)(dr["feedbackRating"]);
                    Output.feedbackComment = dr["feedbackComment"].ToString();
                    Output.dispayStatus = dr["dispayStatus"].ToString();                   
                    lstOfOutput.Add(Output);
                }

                return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch UserTestimonials details from db
        /// </summary>
        /// <param name="Input">GetUserTestimonials_In class as input parameter</param>
        /// <returns>list of GetUserTestimonials_Out as output</returns>
        public async Task<List<GetUserTestimonials_Out>> UD_GetAllUserTestimonialsAsync()
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getMstrUserTestimonials",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrUserTestimonials", allParameters);

                List<GetUserTestimonials_Out> lstOfOutput = new List<GetUserTestimonials_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetUserTestimonials_Out Output = new GetUserTestimonials_Out();
                    Output.feedbackId = (int)(dr["feedbackId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.feedbackRating = (int)(dr["feedbackRating"]);
                    Output.feedbackComment = dr["feedbackComment"].ToString();
                    Output.dispayStatus = dr["dispayStatus"].ToString();
                    lstOfOutput.Add(Output);
                }

                return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch UserTestimonials details from db
        /// </summary>
        /// <param name="Input">GetUserTestimonials_In class as input parameter</param>
        /// <returns>list of GetUserTestimonials_Out as output</returns>
        public async Task<List<GetUserTestimonials_Out>> UD_GetBranchTestimonialsAsync(GetBranchTestimonials_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getMstrUserBranchTestimonials",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrUserTestimonials", allParameters);

                List<GetUserTestimonials_Out> lstOfOutput = new List<GetUserTestimonials_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetUserTestimonials_Out Output = new GetUserTestimonials_Out();
                    Output.feedbackId = (int)(dr["feedbackId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.feedbackRating = (int)(dr["feedbackRating"]);
                    Output.feedbackComment = dr["feedbackComment"].ToString();
                    Output.dispayStatus = dr["dispayStatus"].ToString();
                    Output.userId = (int)(dr["userId"]);
                    Output.firstName = dr["firstName"].ToString();
                    lstOfOutput.Add(Output);
                }

                return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to update UserTestimonials details in db
        /// </summary>
        /// <param name="Input">UpdateUserTestimonials_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateUserTestimonialsAsync(UpdateUserTestimonials_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100

                };
                SqlParameter feedbackId = new SqlParameter
                {
                    ParameterName = "feedbackId",
                    Value = Input.feedbackId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter imageUrl = new SqlParameter
                {
                    ParameterName = "imageUrl",
                    Value = Input.imageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter feedbackRating = new SqlParameter
                {
                    ParameterName = "feedbackRating",
                    Value = Input.feedbackRating,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter feedbackComment = new SqlParameter
                {
                    ParameterName = "feedbackComment",
                    Value = Input.feedbackComment,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter dispayStatus = new SqlParameter
                {
                    ParameterName = "dispayStatus",
                    Value = Input.dispayStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char
                };
                SqlParameter updateBy = new SqlParameter
                {
                    ParameterName = "updateBy",
                    Value = Input.updateBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, feedbackId, gymOwnerId, branchId, bookingId,
                    imageUrl,feedbackRating,feedbackComment,dispayStatus, updateBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrUserTestimonials", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}