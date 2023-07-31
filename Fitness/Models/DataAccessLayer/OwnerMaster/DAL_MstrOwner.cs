using Fitness.Helper;
using Fitness.App_Start;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.OwnerMaster.BOL_MstrOwner;
using Newtonsoft.Json.Linq;

namespace Fitness.Models.DataAccessLayer.OwnerMaster
{
    public class DAL_MstrOwner : SqlHelper
    {
        readonly private static string GetProcedureName;
        static DAL_MstrOwner()
        {
            GetProcedureName = "usp_GetMstrOwner";
        }
        /// <summary>
        /// this method is used to fetch Ownermaster details from db
        /// </summary>
        /// <param name="Input">GetMstrOwner_In class as input parameter</param>
        /// <returns>list of GetMstrOwner_Out as output</returns>
        public async Task<List<GetMstrOwner_Out>> UD_GetMstrOwnerAsync()
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetMstrOwner",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrOwner", allParameters);

                List<GetMstrOwner_Out> lstOfOutput = new List<GetMstrOwner_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetMstrOwner_Out Output = new GetMstrOwner_Out();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymName = dr["gymName"].ToString();
                    Output.shortName = dr["shortName"].ToString();
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.passWord = dr["passWord"].ToString();
                    Output.mobileNumber = dr["mobileNumber"].ToString();
                    Output.mailId = dr["mailId"].ToString();
                    Output.logoUrl = dr["logoUrl"].ToString();
                    Output.websiteUrl = dr["websiteUrl"].ToString();
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
        /// this method is used to fetch Ownermaster details from db
        /// </summary>
        /// <param name="Input">GetMstrOwner_In class as input parameter</param>
        /// <returns>list of GetMstrOwner_Out as output</returns>
        public async Task<List<GetMstrOwner_Out>> UD_GetMstrIndividualOwnerAsync(GetMstrIndividualOwner_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetMstrIndividualOwner",
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
                SqlParameter[] allParameters = { queryType , gymOwnerId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrOwner", allParameters);

                List<GetMstrOwner_Out> lstOfOutput = new List<GetMstrOwner_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetMstrOwner_Out Output = new GetMstrOwner_Out();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymName = dr["gymName"].ToString();
                    Output.shortName = dr["shortName"].ToString();
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.passWord = dr["passWord"].ToString();
                    Output.mobileNumber = dr["mobileNumber"].ToString();
                    Output.mailId = dr["mailId"].ToString();
                    Output.logoUrl = dr["logoUrl"].ToString();
                    Output.websiteUrl = dr["websiteUrl"].ToString();
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
        /// this method is used to fetch ddlOwnermaster details from db
        /// </summary>
        /// <param name="Input">GetddlMstrOwner_In class as input parameter</param>
        /// <returns>list of GetddlMstrOwner_Out as output</returns>
        public async Task<JArray> UD_GetddlMstrOwnerAsync()
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "ddlGetMstrOwner",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType };

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to update Ownermaster details in db
        /// </summary>
        /// <param name="Input"> Update Owner Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateMstrOwnerAsyc(UpdateMstrOwner_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter gymName = new SqlParameter
                {
                    ParameterName = "gymName",
                    Value = Input.gymName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter shortName = new SqlParameter
                {
                    ParameterName = "shortName",
                    Value = Input.shortName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter gymOwnerName = new SqlParameter
                {
                    ParameterName = "gymOwnerName",
                    Value = Input.gymOwnerName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter passWord = new SqlParameter
                {
                    ParameterName = "passWord",
                    Value =StrEncryption.Encrypt(Input.passWord),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter mobileNumber = new SqlParameter
                {
                    ParameterName = "mobileNumber",
                    Value = Input.mobileNumber,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 10
                };
                SqlParameter mailId = new SqlParameter
                {
                    ParameterName = "mailId",
                    Value = Input.mailId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter logoUrl = new SqlParameter
                {
                    ParameterName = "logoUrl",
                    Value = Input.logoUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 200
                };
                SqlParameter websiteUrl = new SqlParameter
                {
                    ParameterName = "websiteUrl",
                    Value = Input.websiteUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter[] allParameters = { queryType, gymOwnerId,gymOwnerName, gymName,
                    shortName, passWord, mobileNumber,mailId, logoUrl, websiteUrl, updatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrOwner", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// this method is used to Insert Ownermaster details in db
        /// </summary>
        /// <param name="Input"> Insert Owner Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertMstrOwnerAsyc(InsertMstrOwner_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter gymName = new SqlParameter
                {
                    ParameterName = "gymName",
                    Value = Input.gymName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter shortName = new SqlParameter
                {
                    ParameterName = "shortName",
                    Value = Input.shortName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter gymOwnerName = new SqlParameter
                {
                    ParameterName = "gymOwnerName",
                    Value = Input.gymOwnerName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter passWord = new SqlParameter
                {
                    ParameterName = "passWord",
                    Value = StrEncryption.Encrypt(Input.passWord),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter mobileNumber = new SqlParameter
                {
                    ParameterName = "mobileNumber",
                    Value = Input.mobileNumber,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 10
                };
                SqlParameter mailId = new SqlParameter
                {
                    ParameterName = "mailId",
                    Value = Input.mailId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter logoUrl = new SqlParameter
                {
                    ParameterName = "logoUrl",
                    Value = Input.logoUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 200
                };
                SqlParameter websiteUrl = new SqlParameter
                {
                    ParameterName = "websiteUrl",
                    Value = Input.websiteUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter[] allParameters = { queryType, gymName,gymOwnerName,
                    shortName, passWord, mobileNumber,mailId, logoUrl, websiteUrl, createdBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrOwner", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate Owner master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateMstrOwner_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateMstrOwnerAsyn(ActivateOrInactivateMstrOwner_In Input)
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
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };


                SqlParameter[] allParameters = { queryType, gymOwnerId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrOwner", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}