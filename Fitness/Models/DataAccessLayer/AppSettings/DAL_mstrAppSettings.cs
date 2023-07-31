using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.AppSetting.BOL_mstrAppSettings;
using Fitness.Helper;

namespace Fitness.Models.DataAccessLayer.AppSettings
{
    public class DAL_mstrAppSettings : SqlHelper
    {
        /// <summary>
        /// This method is used to inser appsettings
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertAppSettingsAsync(InsertAppSetting_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int  
                };

                SqlParameter packageName = new SqlParameter
                {
                    ParameterName = "packageName",
                    Value = Input.packageName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };

                SqlParameter versionChanges = new SqlParameter
                {
                    ParameterName = "versionChanges",
                    Value = Input.versionChanges,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = -1
                };

                SqlParameter appVersion = new SqlParameter
                {
                    ParameterName = "appVersion",
                    Value = Input.appVersion,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 25
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter appType = new SqlParameter
                {
                    ParameterName = "appType",
                    Value = Input.appType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };

                SqlParameter[] allParameters = { QueryType,gymOwnerId,packageName, appType, createdBy, appVersion, versionChanges };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrAppSetting", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// this method is used to get appsettings 
        /// </summary>
        /// <param name="Input">GetAppSetting_In class as input parameter</param>
        /// <returns></returns>
        public async Task<List<GetAppSetting_Out>> UD_GetAppVersions(GetAppSetting_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetAppVersions",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };

                SqlParameter appVersion = new SqlParameter
                {
                    ParameterName = "appVersion",
                    Value = Input.appVersion,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 25
                };

                SqlParameter appType = new SqlParameter
                {
                    ParameterName = "appType",
                    Value = Input.appType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };

                SqlParameter[] allParameters = { QueryType, appType, appVersion };


                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrAppSetting", allParameters);


                List<GetAppSetting_Out> listOfOut = new List<GetAppSetting_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetAppSetting_Out output = new GetAppSetting_Out();

                    output.Status = dr["Status"].ToString();

                    listOfOut.Add(output);
                }

                return listOfOut;
            }
            catch (Exception)
            {
                throw;
            }
        }
     
        /// <summary>
        /// this method is used to get appsettings 
        /// </summary>
        /// <param name="Input">GetAppSetting_In class as input parameter</param>
        /// <returns></returns>
        public async Task<List<GetAllAppSetting_Out>> UD_GetAppSettingsOnPckgNameAsync(GetAppSettingPckg_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetAppVersionOnPckgName",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter packageName = new SqlParameter
                {
                    ParameterName = "packageName",
                    Value = Input.packageName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };

                SqlParameter[] allParameters = { QueryType, packageName };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrAppSetting", allParameters);

                List<GetAllAppSetting_Out> listOfOut = new List<GetAllAppSetting_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetAllAppSetting_Out Output = new GetAllAppSetting_Out();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.appType = dr["appType"].ToString();
                    Output.appVersion = dr["appVersion"].ToString();
                    Output.packageName = dr["packageName"].ToString();
                    Output.versionChanges = dr["versionChanges"].ToString();
                    Output.activeStatus = dr["activeStatus"].ToString();
                    listOfOut.Add(Output);
                }

                return listOfOut;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// this method is used to get appsettings 
        /// </summary>
        /// <param name="Input">GetAppSetting_In class as input parameter</param>
        /// <returns></returns>
        public async Task<List<GetAllAppSetting_Out>> UD_GetAllAppVersions()
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetAllAppVersions",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };

                SqlParameter[] allParameters = { QueryType };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrAppSetting", allParameters);

                List<GetAllAppSetting_Out> listOfOut = new List<GetAllAppSetting_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetAllAppSetting_Out Output = new GetAllAppSetting_Out();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.appType = dr["appType"].ToString();
                    Output.appVersion = dr["appVersion"].ToString();
                    Output.packageName = dr["packageName"].ToString();
                    Output.versionChanges = dr["versionChanges"].ToString();
                    Output.activeStatus = dr["activeStatus"].ToString();
                    listOfOut.Add(Output);
                }

                return listOfOut;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}