using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.FormAccessRights.BOL_MstrFormAccessRights;
using Fitness.Helper;

namespace Fitness.Models.DataAccessLayer.FormAccessRights
{
    public class DAL_MstrFormAccessRights : SqlHelper
    {
        readonly private static string GetProcedureName;
        static DAL_MstrFormAccessRights()
        {
            GetProcedureName = "usp_GetFormsAccessRights";
        }

        /// <summary>
        /// this method is used to get Form Access Rights
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<JArray> GetFormAccessRights(GetFormAccessRights_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetFormAccessRights",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter BranchId = new SqlParameter
                {
                    ParameterName = "BranchId",
                    Value = Input.BranchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter UserId = new SqlParameter
                {
                    ParameterName = "UserId",
                    Value = Input.UserId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter GymOwnerId = new SqlParameter
                {
                    ParameterName = "GymOwnerId",
                    Value = Input.GymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter RoleId = new SqlParameter
                {
                    ParameterName = "RoleId",
                    Value = Input.RoleId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] ParameterArray = { QueryType, BranchId, UserId, GymOwnerId, RoleId };
                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, ParameterArray);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}