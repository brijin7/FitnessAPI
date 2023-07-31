using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.MenuOption.BOL_MstrMenuOption;
using DnsClient;
using Microsoft.Owin.BuilderProperties;
using System.Security.Cryptography.X509Certificates;
using Fitness.Helper;
using Newtonsoft.Json.Linq;

namespace Fitness.Models.DataAccessLayer.MenuOption
{
    public class DAL_MstrMenuOption : SqlHelper
    {
        ///// <summary>
        ///// this method is used to Get Menu Option in Database
        ///// </summary>
        ///// <returns>JArray As Return Type</returns>
        public async Task<JArray> UD_GetMenuOptionAsync()
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "QueryType",
                    Value = "GetMenuOption",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };

                SqlParameter[] allParameters = { QueryType };


                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrMenuOption", allParameters);
                string JsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(dt);

                JArray JsonArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(JsonObject);
                return JsonArray;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// this method is used to insert Menu Option in Database
        /// </summary>
        /// <param name="Input">InsertMenuOption_In as Input</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertMenuOptionAsync(InsertMenuOption_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "QueryType",
                    Value = "Insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter OptionName = new SqlParameter
                {
                    ParameterName = "OptionName",
                    Value = Input.OptionName.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.CreatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, OptionName, createdBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();

                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrMenuOption", ListOfParameter);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to Update Menu Option in Database
        /// </summary>
        /// <param name="Input">UpdateMenuOption_In AS Input</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_UpdateMenuOptionAsync(UpdateMenuOption_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "QueryType",
                    Value = "Update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter OptionId = new SqlParameter
                {
                    ParameterName = "OptionId",
                    Value = Input.OptionId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter OptionName = new SqlParameter
                {
                    ParameterName = "OptionName",
                    Value = Input.OptionName.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter UpdatedBy = new SqlParameter
                {
                    ParameterName = "UpdatedBy",
                    Value = Input.UpdatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, OptionId, OptionName, UpdatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrMenuOption", ListOfParameter);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to Activate Or Inactivate Menu Option in Database
        /// </summary>
        /// <param name="Input">ActiveOrInactiveMenuOption_In As Input</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_ActiveOrInactiveMenuOptionAsync(ActiveOrInactiveMenuOption_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "QueryType",
                    Value = Input.QueryType.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter OptionId = new SqlParameter
                {
                    ParameterName = "OptionId",
                    Value = Input.OptionId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter UpdatedBy = new SqlParameter
                {
                    ParameterName = "UpdatedBy",
                    Value = Input.UpdatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, OptionId, UpdatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();

                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrMenuOption", ListOfParameter);
            }
            catch
            {
                throw;
            }
        }
    }
}