using Fitness.Models.CommonModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.UserSlotSwapping.BOL_mstrUserSlotSwapping;
using DnsClient;
using Fitness.Helper;

namespace Fitness.Models.DataAccessLayer.UserSlotSwapping
{
    public class DAL_mstrUserSlotSwapping : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);
        /// <summary>
        /// this method is used to fetch UserSlotSwapping details from db
        /// </summary>
        /// <param name="Input">GetUserSlotSwapping_In class as input parameter</param>
        /// <returns>list of GetUserSlotSwapping_Out as output</returns>
        public async Task<JArray> UD_GetUserSlotSwappingAsync(GetUserSlotSwapping_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = Input.QueryType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter trainerId = new SqlParameter
                {
                    ParameterName = "trainerId",
                    Value = Input.trainerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter slotSwapId = new SqlParameter
                {
                    ParameterName = "slotSwapId",
                    Value = Input.slotSwapId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, trainerId, slotSwapId, userId };

                return await GetResultFromGetDataTableFromUSPAsync("usp_GetMstrUserSlotSwapping", allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to insert details in categorymstr in db
        /// </summary>
        /// <param name="Input">InsertCategory_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertUserSlotSwappingAsync(InsertUserSlotSwapping_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter newslotId = new SqlParameter
                {
                    ParameterName = "newslotId",
                    Value = Input.newslotId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter oldslotId = new SqlParameter
                {
                    ParameterName = "oldslotId",
                    Value = Input.oldslotId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter slotswapTypeId = new SqlParameter
                {
                    ParameterName = "slotswapTypeId",
                    Value = Input.slotswapTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                //SqlParameter slotfromDate = new SqlParameter
                //{
                //    ParameterName = "slotfromDate",
                //    Value = DateTime.Parse(Input.slotfromDate, objEnglishDate),
                //    Direction = ParameterDirection.Input,
                //    SqlDbType = SqlDbType.NVarChar,
                //    Size = 200
                //};
                SqlParameter slotfromDate = new SqlParameter
                {
                    ParameterName = "slotfromDate",
                    Value = Input.slotfromDate,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 200
                };

                SqlParameter toDate = new SqlParameter
                {
                    ParameterName = "toDate",
                    Value = DateTime.Parse(Input.toDate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 200
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, newslotId, oldslotId, userId, slotswapTypeId, slotfromDate, toDate, createdBy, bookingId };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_TranUserslotswapping", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}