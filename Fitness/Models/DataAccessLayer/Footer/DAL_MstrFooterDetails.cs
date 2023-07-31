using Fitness.Helper;
using Fitness.Models.CommonModels;
using MongoDB.Bson.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.Footer.BOL_MstrFooterDetails;

namespace Fitness.Models.DataAccessLayer.Footer
{
    public class DAL_MstrFooterDetails : SqlHelper
    {

        public async Task<DB_Response> UD_InsertMstrFooterDetailsAsync(InsertFooter_In Input)
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

                SqlParameter Icons = new SqlParameter
                {
                    ParameterName = "Icons",
                    Value = Input.icons,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter Description = new SqlParameter
                {
                    ParameterName = "Description",
                    Value = Input.description,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                };
                SqlParameter Link = new SqlParameter
                {
                    ParameterName = "Link",
                    Value = Input.link,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter DisplayType = new SqlParameter
                {
                    ParameterName = "DisplayType",
                    Value = Input.displayType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };         
                SqlParameter[] allParameters = { queryType, Icons, Description, Link, DisplayType, 
                    gymOwnerId, branchId, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrFooterDetails", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetFooter_Out>> UD_GetFooterAsync(GetFooter_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getFooterDetails",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                };
                SqlParameter displayType = new SqlParameter
                {
                    ParameterName = "displayType",
                    Value = Input.displayType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };
                SqlParameter[] allParameters = { queryType ,branchId ,gymOwnerId, displayType };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrFooterDetails", allParameters);

                List<GetFooter_Out> lstOfOutput = new List<GetFooter_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetFooter_Out Output = new GetFooter_Out();
                    Output.FooterDetailsId = (int)(dr["FooterDetailsId"]);
                    Output.icons = dr["icons"].ToString();
                    Output.description = dr["description"].ToString();
                    Output.link = dr["link"].ToString();
                    Output.displayType = (int)(dr["displayType"]);
                    Output.displayTypeName = dr["displayTypeName"].ToString();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.branchId = (int)(dr["branchId"]);
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

        public async Task<DB_Response> UD_UpdateMstrFooterDetailsAsync(UpdateFooter_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter FooterDetailsId = new SqlParameter
                {
                    ParameterName = "FooterDetailsId",
                    Value = Input.FooterDetailsId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter Icons = new SqlParameter
                {
                    ParameterName = "Icons",
                    Value = Input.icons,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter Description = new SqlParameter
                {
                    ParameterName = "Description",
                    Value = Input.description,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                };
                SqlParameter Link = new SqlParameter
                {
                    ParameterName = "Link",
                    Value = Input.link,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter DisplayType = new SqlParameter
                {
                    ParameterName = "DisplayType",
                    Value = Input.displayType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType,FooterDetailsId, Icons, Description, Link, DisplayType,
                    gymOwnerId, branchId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrFooterDetails", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DB_Response> UD_ActivateOrInactivateFoodterAsyn(ActivateOrInactivateFooter_In Input)
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
                SqlParameter FooterDetailsId = new SqlParameter
                {
                    ParameterName = "FooterDetailsId",
                    Value = Input.FooterDetailsId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType, FooterDetailsId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrFooterDetails", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}