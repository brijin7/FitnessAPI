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
using static Fitness.Models.BusinessObject.Offer.BOL_MstrOfferRule;

namespace Fitness.Models.DataAccessLayer.Offer
{
    public class DAL_MstrOfferRule : SqlHelper
    {

        /// <summary>
        /// this method is used to insert details in OfferRule in db
        /// </summary>
        /// <param name="Input">InsertOfferRule_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertMstrOfferRuleAsync(InsertOfferRule_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter offerId = new SqlParameter
                {
                    ParameterName = "offerId",
                    Value = Input.offerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter offerRule = new SqlParameter
                {
                    ParameterName = "offerRule",
                    Value = Input.offerRule,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter ruleType = new SqlParameter
                {
                    ParameterName = "ruleType",
                    Value = Input.ruleType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 50
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType, offerId, offerRule, ruleType, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrOfferRule", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch OfferRule details from db
        /// </summary>
        /// <param name="Input">GetOfferRule_In class as input parameter</param>
        /// <returns>list of GetOfferRule_Out as output</returns>
        public async Task<List<GetOfferRule_Out>> UD_GetOfferRuleAsync(GetOfferRule_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getOfferRule",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter offerId = new SqlParameter
                {
                    ParameterName = "offerId",
                    Value = Input.offerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, offerId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrOfferRule", allParameters);

                List<GetOfferRule_Out> lstOfOutput = new List<GetOfferRule_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetOfferRule_Out Output = new GetOfferRule_Out();
                    Output.offerRuleId = (int)(dr["offerRuleId"]);
                    Output.offerId = (int)(dr["offerId"]);
                    Output.offerHeading = dr["offerHeading"].ToString();
                    Output.ruleTypeName = dr["ruleTypeName"].ToString();
                    Output.offerRule = Convert.ToString(dr["offerRule"]);
                    Output.ruleType = (int)(dr["ruleType"]);
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
        /// this method is used to update OfferRule details in db
        /// </summary>
        /// <param name="Input">UpdateOfferRule_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateOfferRuleAsync(UpdateOfferRule_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value ="update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100

                };
                SqlParameter offerRuleId = new SqlParameter
                {
                    ParameterName = "offerRuleId",
                    Value = Input.offerRuleId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter offerId = new SqlParameter
                {
                    ParameterName = "offerId",
                    Value = Input.offerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter offerRule = new SqlParameter
                {
                    ParameterName = "offerRule",
                    Value = Input.offerRule,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                };
                SqlParameter ruleType = new SqlParameter
                {
                    ParameterName = "ruleType",
                    Value = Input.ruleType,
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
                SqlParameter[] allParameters = { queryType, offerRuleId, offerId, offerRule, ruleType, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrOfferRule", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate OfferRule master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateOfferRule_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateOfferRuleMstrAsyn(ActivateOrInactivateOfferRule_In Input)
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
                SqlParameter offerRuleId = new SqlParameter
                {
                    ParameterName = "offerRuleId",
                    Value = Input.offerRuleId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType, offerRuleId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrOfferRule", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}