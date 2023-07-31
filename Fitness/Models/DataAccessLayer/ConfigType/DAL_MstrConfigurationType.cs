using Fitness.Helper;
using Fitness.Models.CommonModels;
using static Fitness.Models.BusinessObject.BOL_MstrConfigType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Fitness.Models.DataAccessLayer
{
    public class DAL_MstrConfigurationType : SqlHelper
    {
        /// <summary>
        /// this method is used to fetch configtype from db
        /// </summary>
        /// <param name="In">GetConfigType_In as input parameter</param>
        /// <returns>DataTable as output</returns>
        public async Task<DataTable> UD_GetConfigTypeAsync()
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetConfigTypes",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter[] allParameters = { QueryType };
                var dtbl = await base.GetDataTableFromUSPAsync("usp_GetMstrConfigType", allParameters);

                return dtbl;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to fetch ddl configtype  from db
        /// </summary>
        /// <param name="In">GetConfigType_In as input parameter</param>
        /// <returns>DataTable as output</returns>
        public async Task<DataTable> UD_ddlConfigTypeAsync()
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "ddlConfigTypes",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter[] allParameters = { QueryType};
                var dtbl = await base.GetDataTableFromUSPAsync("usp_GetMstrConfigType", allParameters);

                return dtbl;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is use to insert config type
        /// </summary>
        /// <param name="In">InsertConfigType_In as input parameter</param>
        ///<returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertConfigTypeAsync(InsertConfigType_In In)
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
                SqlParameter typeName = new SqlParameter
                {
                    ParameterName = "typeName",
                    Value = In.typeName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = In.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter[] allParameters = { QueryType, typeName, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);


                return await ExecuteNonQueryAsync("usp_MstrConfigType", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// this method is used to update configtype
        /// </summary>
        /// <param name="In">UpdateConfigType_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateConfigTypeAsync(UpdateConfigType_In In)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter typeName = new SqlParameter
                {
                    ParameterName = "typeName",
                    Value = In.typeName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter typeId = new SqlParameter
                {
                    ParameterName = "typeId",
                    Value = In.typeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };  
                
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = In.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter[] allParameters = { QueryType, typeName, typeId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrConfigType", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// this method is used to active details in db
        /// </summary>
        /// <param name="In">ActivateInActiveConfigType_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateConfigTypeAsync(ActivateOrInactivateConfigType_In In)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = In.queryType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter typeId = new SqlParameter
                {
                    ParameterName = "typeId",
                    Value = In.typeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = In.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, typeId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrConfigType", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}