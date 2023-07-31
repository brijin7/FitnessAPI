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
using static Fitness.Models.BusinessObject.ConfigMaster.BOL_MstrConfig;


namespace Fitness.Models.DataAccessLayer.ConfigMaster
{
    public class DAL_MstrConfig : SqlHelper
    {

        /// <summary>
        /// this method is used to insert details in configmaster in db
        /// </summary>
        /// <param name="Input">InsertConfig_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertConfigMasterAsync(InsertConfig_In Input)
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
                SqlParameter configName = new SqlParameter
                {
                    ParameterName = "configName",
                    Value = Input.configName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter typeId = new SqlParameter
                {
                    ParameterName = "typeId",
                    Value = Input.typeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, typeId, createdBy, configName };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrConfig", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch configmaster details from db
        /// </summary>
        /// <param name="Input">GetConfigMstr_In class as input parameter</param>
        /// <returns>list of GetConfigMstr_Out as output</returns>
        public async Task<List<GetConfigMstr_Out>> UD_GetConfigMstrAsync()
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetConfigMaster",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter[] allParameters = { queryType };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrConfig", allParameters);

                List<GetConfigMstr_Out> lstOfOutput = new List<GetConfigMstr_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetConfigMstr_Out Output = new GetConfigMstr_Out();
                    Output.typeId = (int)(dr["typeId"]);
                    Output.typeName = dr["typeName"].ToString();
                    Output.configId = (int)(dr["configId"]);
                    Output.configName = dr["configName"].ToString();
                    Output.activeStatus = dr["activeStatus"].ToString();

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
        /// this method is used to fetch configmaster details from db
        /// </summary>
        /// <param name="Input">GetConfigMstr_In class as input parameter</param>
        /// <returns>list of GetConfigMstr_Out as output</returns>
        public async Task<List<ddlConfigMstr_Out>> UD_ddlConfigMstrAsync(ddlConfigMstr_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "ddlConfigMaster",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter typeId = new SqlParameter
                {
                    ParameterName = "typeId",
                    Value = Input.typeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType, typeId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrConfig", allParameters);

                List<ddlConfigMstr_Out> lstOfOutput = new List<ddlConfigMstr_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    ddlConfigMstr_Out Output = new ddlConfigMstr_Out();
                    Output.configId = (int)(dr["configId"]);
                    Output.configName = dr["configName"].ToString();

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
        /// this method is used to update configmaster details in db
        /// </summary>
        /// <param name="Input">UpdateConfigMstr_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateConfigMstrAsync(UpdateConfigMstr_In Input)
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
                SqlParameter configName = new SqlParameter
                {
                    ParameterName = "configName",
                    Value = Input.configName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter typeId = new SqlParameter
                {
                    ParameterName = "typeId",
                    Value = Input.typeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter configId = new SqlParameter
                {
                    ParameterName = "configId",
                    Value = Input.configId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType, typeId, configId, configName, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrConfig", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate config master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateConfigMstr_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateConfigMstrAsyn(ActivateOrInactivateConfigMstr_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = Input.queryType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter typeId = new SqlParameter
                {
                    ParameterName = "typeId",
                    Value = Input.typeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter configId = new SqlParameter
                {
                    ParameterName = "configId",
                    Value = Input.configId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType, typeId, configId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrConfig", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}