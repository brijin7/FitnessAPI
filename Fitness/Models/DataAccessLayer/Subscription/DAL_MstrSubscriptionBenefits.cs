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
using static Fitness.Models.BusinessObject.Subscription.BOL_MstrSubscriptionBenefits;

namespace Fitness.Models.DataAccessLayer.Subscription
{
    public class DAL_MstrSubscriptionBenefits : SqlHelper
    {

        /// <summary>
        /// this method is used to insert details in SubscriptionBenefits in db
        /// </summary>
        /// <param name="Input">InsertSubscriptionBenefits_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertMstrSubscriptionBenefitsAsync(InsertSubscriptionBenefits_In Input)
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

                SqlParameter subscriptionPlanId = new SqlParameter
                {
                    ParameterName = "subscriptionPlanId",
                    Value = Input.subscriptionPlanId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter imageUrl = new SqlParameter
                {
                    ParameterName = "imageUrl",
                    Value = Input.imageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter description = new SqlParameter
                {
                    ParameterName = "description",
                    Value = Input.description,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType, subscriptionPlanId, imageUrl, description, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrSubscriptionBenefits", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch SubscriptionBenefits details from db
        /// </summary>
        /// <param name="Input">GetSubscriptionBenefits_In class as input parameter</param>
        /// <returns>list of GetSubscriptionBenefits_Out as output</returns>
        public async Task<List<GetSubscriptionBenefits_Out>> UD_GetSubscriptionBenefitsAsync(GetSubscriptionBenefits_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getSubscriptionBenefits",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter subscriptionPlanId = new SqlParameter
                {
                    ParameterName = "subscriptionPlanId",
                    Value = Input.subscriptionPlanId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, subscriptionPlanId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrSubscriptionBenefits", allParameters);

                List<GetSubscriptionBenefits_Out> lstOfOutput = new List<GetSubscriptionBenefits_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetSubscriptionBenefits_Out Output = new GetSubscriptionBenefits_Out();
                    Output.SubBenefitId = (int)(dr["SubBenefitId"]);
                    Output.subscriptionPlanId = (int)(dr["subscriptionPlanId"]);
                    Output.imageUrl = Convert.ToString(dr["imageUrl"]);
                    Output.description = dr["description"].ToString();
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
        /// this method is used to update SubscriptionBenefits details in db
        /// </summary>
        /// <param name="Input">UpdateSubscriptionBenefits_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateSubscriptionBenefitsAsync(UpdateSubscriptionBenefits_In Input)
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
                SqlParameter uniqueId = new SqlParameter
                {
                    ParameterName = "uniqueId",
                    Value = Input.uniqueId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter subscriptionPlanId = new SqlParameter
                {
                    ParameterName = "subscriptionPlanId",
                    Value = Input.subscriptionPlanId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter imageUrl = new SqlParameter
                {
                    ParameterName = "imageUrl",
                    Value = Input.imageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                };
                SqlParameter description = new SqlParameter
                {
                    ParameterName = "description",
                    Value = Input.description,
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
                SqlParameter[] allParameters = { queryType, uniqueId, subscriptionPlanId, imageUrl, description, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrSubscriptionBenefits", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate SubscriptionBenefits master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateSubscriptionBenefits_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateSubscriptionBenefitsMstrAsyn(ActivateOrInactivateSubscriptionBenefits_In Input)
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
                SqlParameter uniqueId = new SqlParameter
                {
                    ParameterName = "uniqueId",
                    Value = Input.uniqueId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType, uniqueId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrSubscriptionBenefits", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}