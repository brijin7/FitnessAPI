using Fitness.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.GetGymOwnerAndBranch.BOL_GetGymOwnerAndBranch;
using Newtonsoft.Json.Linq;

namespace Fitness.Models.DataAccessLayer.GetGymOwnerAndBranch
{
    public class DAL_getGymOwnerAndBranch : SqlHelper
    {
        readonly string procedureName;
        public DAL_getGymOwnerAndBranch()
        {
            procedureName = "usp_GetGymOwnerAndBranch";
        }
        /// <summary>
        /// This method is used to get gymownerId
        /// </summary>
        /// <returns></returns>
        public async Task<JArray> UD_GetGymOwnerIdAsync()
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "QueryType",
                    Value = "GetGymOwnerId",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                };

                SqlParameter[] allParameters = { QueryType };

                return await GetResultFromGetDataTableFromUSPAsync(procedureName, allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method is used to get branchId
        /// </summary>
        /// <returns></returns>
        public async Task<JArray> UD_GetBranchIdAsync(GetBranchId Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "QueryType",
                    Value = "GetBranchId",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                };
                SqlParameter GymOwnerId = new SqlParameter
                {
                    ParameterName = "GymOwnerId",
                    Value = Input.GymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, GymOwnerId };

                return await GetResultFromGetDataTableFromUSPAsync(procedureName, allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}