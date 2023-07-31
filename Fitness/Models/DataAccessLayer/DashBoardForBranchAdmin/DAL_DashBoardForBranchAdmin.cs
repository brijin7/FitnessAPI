using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.DashBoardForBranchAdmin.BOL_DashBoardForBranchAdmin;
using Fitness.Helper;

namespace Fitness.Models.DataAccessLayer.DashBoardForBranchAdmin
{
    public class DAL_DashBoardForBranchAdmin : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);

        readonly private string GetProcedure;
        public DAL_DashBoardForBranchAdmin()
        {
            GetProcedure = "usp_GetDashBoardForBranchAdmin";
        }
        /// <summary>
        /// this method is used to GetBookingAndEnquiryCount Data from db
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<JArray> UD_GetBookingAndEnquiryCountAsync(GetBookingAndEnquiryCount_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter()
                {
                    ParameterName = "QueryType",
                    Value = "GetBookingAndEnquiryCount",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                };
                SqlParameter GymOwnerId = new SqlParameter()
                {
                    ParameterName = "GymOwnerId",
                    Value = Input.GymOwnerId,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter BranchId = new SqlParameter()
                {
                    ParameterName = "BranchId",
                    Value = Input.BranchId,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter FromDate = new SqlParameter()
                {
                    ParameterName = "FromDate",
                    Value = DateTime.Parse(Input.FromDate.Trim(), objEnglishDate),
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter ToDate = new SqlParameter()
                {
                    ParameterName = "ToDate",
                    Value = DateTime.Parse(Input.ToDate.Trim(), objEnglishDate),
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter[] parameterArr = { QueryType, GymOwnerId, BranchId, FromDate, ToDate };

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedure, parameterArr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to GetEnquiryListBasedOnGymAndBranch Data from db
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<JArray> UD_GetBookingListBasedOnGymAndBranchAsync(GetBookingListBasedOnGymAndBranch_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter()
                {
                    ParameterName = "QueryType",
                    Value = "GetBookingListBasedOnGymAndBranch",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                };
                SqlParameter GymOwnerId = new SqlParameter()
                {
                    ParameterName = "GymOwnerId",
                    Value = Input.GymOwnerId,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter BranchId = new SqlParameter()
                {
                    ParameterName = "BranchId",
                    Value = Input.BranchId,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter FromDate = new SqlParameter()
                {
                    ParameterName = "FromDate",
                    Value = DateTime.Parse(Input.FromDate.Trim(), objEnglishDate),
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter ToDate = new SqlParameter()
                {
                    ParameterName = "ToDate",
                    Value = DateTime.Parse(Input.ToDate.Trim(), objEnglishDate),
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter[] parameterArr = { QueryType, GymOwnerId, BranchId, FromDate, ToDate };

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedure, parameterArr);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to GetEnquiryListBasedOnGymAndBranch Data from db
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<JArray> UD_GetEnquiryListBasedOnGymAndBranchAsync(GetEnquiryListBasedOnGymAndBranch_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter()
                {
                    ParameterName = "QueryType",
                    Value = "GetEnquiryListBasedOnGymAndBranch",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                };
                SqlParameter GymOwnerId = new SqlParameter()
                {
                    ParameterName = "GymOwnerId",
                    Value = Input.GymOwnerId,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter BranchId = new SqlParameter()
                {
                    ParameterName = "BranchId",
                    Value = Input.BranchId,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter FromDate = new SqlParameter()
                {
                    ParameterName = "FromDate",
                    Value = DateTime.Parse(Input.FromDate.Trim(), objEnglishDate),
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter ToDate = new SqlParameter()
                {
                    ParameterName = "ToDate",
                    Value = DateTime.Parse(Input.ToDate.Trim(), objEnglishDate),
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter[] parameterArr = { QueryType, GymOwnerId, BranchId, FromDate, ToDate };

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedure, parameterArr);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}