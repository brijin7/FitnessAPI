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
using static Fitness.Models.BusinessObject.Subscription.BOL_MstrSubscriptionPlan;

namespace Fitness.Models.DataAccessLayer.Subscription
{
    public class DAL_MstrSubscriptionPlan : SqlHelper
    {
        IFormatProvider obj = new System.Globalization.CultureInfo("en-GB", true);
        /// <summary>
        /// this method is used to insert details in SubscriptionPlan in db
        /// </summary>
        /// <param name="Input">InsertSubscriptionPlan_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertMstrSubscriptionPlanAsync(InsertSubscriptionPlan_In Input)
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

                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
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
                SqlParameter description = new SqlParameter
                {
                    ParameterName = "description",
                    Value = Input.description,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter imageUrl = new SqlParameter
                {
                    ParameterName = "imageUrl",
                    Value = Input.imageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter noOfDays = new SqlParameter
                {
                    ParameterName = "noOfDays",
                    Value = Input.noOfDays,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter tax = new SqlParameter
                {
                    ParameterName = "tax",
                    Value = Input.tax,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter taxId = new SqlParameter
                {
                    ParameterName = "taxId",
                    Value = Input.taxId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter amount = new SqlParameter
                {
                    ParameterName = "amount",
                    Value = Input.amount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                };
                SqlParameter netAmount = new SqlParameter
                {
                    ParameterName = "netAmount",
                    Value = Input.netAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter credits = new SqlParameter
                {
                    ParameterName = "credits",
                    Value = Input.credits,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter isTrialAvailable = new SqlParameter
                {
                    ParameterName = "isTrialAvailable",
                    Value = Input.isTrialAvailable,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };
                SqlParameter noOfTrialDays = new SqlParameter
                {
                    ParameterName = "noOfTrialDays",
                    Value = Input.noOfTrialDays,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter fromDate = new SqlParameter
                {
                    ParameterName = "fromDate",
                    Value = DateTime.Parse(Input.fromDate, obj),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime

                };
                SqlParameter toDate = new SqlParameter
                {
                    ParameterName = "toDate",
                    Value = DateTime.Parse(Input.toDate, obj),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime

                };
                SqlParameter actualAmount = new SqlParameter
                {
                    ParameterName = "actualAmount",
                    Value = Input.actualAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter displayAmount = new SqlParameter
                {
                    ParameterName = "displayAmount",
                    Value = Input.displayAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter offerId = new SqlParameter
                {
                    ParameterName = "offerId",
                    Value = Input.offerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter offerName = new SqlParameter
                {
                    ParameterName = "offerName",
                    Value = Input.offerName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };

                SqlParameter[] allParameters = { queryType,gymOwnerId, branchId, packageName, description, imageUrl,noOfDays,tax,taxId,
                    amount,netAmount,credits,isTrialAvailable, noOfTrialDays,createdBy,fromDate, toDate,actualAmount,displayAmount,offerId,offerName};

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrSubscriptionPlan", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch SubscriptionPlan details from db
        /// </summary>
        /// <param name="Input">GetSubscriptionPlan_In class as input parameter</param>
        /// <returns>list of GetSubscriptionPlan_Out as output</returns>
        public async Task<List<GetSubscriptionPlan_Out>> UD_GetSubscriptionPlanAsync(GetSubscriptionPlan_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getSubscriptionPlan",
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
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrSubscriptionPlan", allParameters);

                List<GetSubscriptionPlan_Out> lstOfOutput = new List<GetSubscriptionPlan_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetSubscriptionPlan_Out Output = new GetSubscriptionPlan_Out();
                    Output.subscriptionPlanId = (int)(dr["subscriptionPlanId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.packageName = dr["packageName"].ToString();
                    Output.description = dr["description"].ToString();
                    Output.noOfDays = (int)(dr["noOfDays"]);
                    Output.taxId = (int)(dr["taxId"]);
                    Output.amount = dr["amount"].ToString();
                    Output.tax = dr["tax"].ToString();
                    Output.taxName = dr["taxName"].ToString();
                    Output.cgstTax = dr["cgstTax"].ToString();
                    Output.sgstTax = dr["sgstTax"].ToString();
                    Output.netAmount = dr["netAmount"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.credits = (int)(dr["credits"]);
                    Output.isTrialAvailable = dr["isTrialAvailable"].ToString();
                    Output.noOfTrialDays = (int)(dr["noOfTrialDays"]);
                    Output.activeStatus = dr["activeStatus"].ToString();
                    Output.actualAmount = dr["actualAmount"].ToString();
                    Output.displayAmount = dr["displayAmount"].ToString();
                    Output.offerId = (int)(dr["offerId"]);
                    Output.offerName = dr["offerName"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
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
        /// this method is used to fetch SubscriptionPlan details from db
        /// </summary>
        /// <param name="Input">GetSubscriptionPlan_In class as input parameter</param>
        /// <returns>list of GetSubscriptionPlan_Out as output</returns>
        public async Task<List<GetuserSubscriptionPlanDetails_Out>> UD_GetuserSubscriptionPlanAsync(GetuserSubscriptionPlanDetails_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getuserSubscriptionDetails",
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrSubscriptionPlan", allParameters);

                List<GetuserSubscriptionPlanDetails_Out> lstOfOutput = new List<GetuserSubscriptionPlanDetails_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetuserSubscriptionPlanDetails_Out Output = new GetuserSubscriptionPlanDetails_Out();
                    Output.subscriptionPlanId = (int)(dr["subscriptionPlanId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymName = dr["gymName"].ToString();
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.packageName = dr["packageName"].ToString();
                    Output.fromTime = dr["fromTime"].ToString();
                    Output.toTime = dr["toTime"].ToString();
                    Output.description = dr["description"].ToString();
                    Output.benefitsId = (int)(dr["benefitsId"]);
                    Output.benefitsDescription = dr["benefitsDescription"].ToString();
                    Output.benefitsImageUrl = dr["benefitsImageUrl"].ToString();
                    Output.noOfDays = (int)(dr["noOfDays"]);
                    Output.amount = dr["amount"].ToString();
                    Output.tax = dr["tax"].ToString();
                    Output.taxId = dr["taxId"].ToString();
                    Output.taxName = dr["taxName"].ToString();
                    Output.cgstTax = dr["cgstTax"].ToString();
                    Output.sgstTax = dr["sgstTax"].ToString();
                    Output.netAmount = dr["netAmount"].ToString();
                    Output.actualAmount = dr["actualAmount"].ToString();
                    Output.displayAmount = dr["displayAmount"].ToString();
                    Output.savedAmount = dr["savedAmount"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.credits = (int)(dr["credits"]);
                    Output.noOfTrialDays = (int)(dr["noOfTrialDays"]);
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
        /// this method is used to fetch SubscriptionPlan details from db
        /// </summary>
        /// <param name="Input">GetSubscriptionPlan_In class as input parameter</param>
        /// <returns>list of GetSubscriptionPlan_Out as output</returns>
        public async Task<List<GetuserHomeSubscriptionPlanDetails_Out>> UD_GetuserHomeSubscriptionPlanAsync(GetuserHomeSubscriptionPlanDetails_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getHomeuserSubscription",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType , gymOwnerId , branchId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrSubscriptionPlan", allParameters);

                List<GetuserHomeSubscriptionPlanDetails_Out> lstOfOutput = new List<GetuserHomeSubscriptionPlanDetails_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetuserHomeSubscriptionPlanDetails_Out Output = new GetuserHomeSubscriptionPlanDetails_Out();
                    Output.subscriptionPlanId = (int)(dr["subscriptionPlanId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymName = dr["gymName"].ToString();
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.packageName = dr["packageName"].ToString();
                    Output.description = dr["description"].ToString();
                    Output.noOfDays = (int)(dr["noOfDays"]);
                    Output.amount = dr["amount"].ToString();
                    Output.taxId = dr["taxId"].ToString();
                    Output.tax = dr["tax"].ToString();
                    Output.taxName = dr["taxName"].ToString();
                    Output.cgstTax = dr["cgstTax"].ToString();
                    Output.sgstTax = dr["sgstTax"].ToString();
                    Output.netAmount = dr["netAmount"].ToString();
                    Output.actualAmount = dr["actualAmount"].ToString();
                    Output.displayAmount = dr["displayAmount"].ToString();
                    Output.savedAmount = dr["savedAmount"].ToString();                  
                    Output.SubsBenefits = dr["SubsBenefits"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.credits = (int)(dr["credits"]);
                    Output.noOfTrialDays = (int)(dr["noOfTrialDays"]);
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
        /// this method is used to update SubscriptionPlan details in db
        /// </summary>
        /// <param name="Input">UpdateSubscriptionPlan_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateSubscriptionPlanAsync(UpdateSubscriptionPlan_In Input)
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
                SqlParameter subscriptionPlanId = new SqlParameter
                {
                    ParameterName = "subscriptionPlanId",
                    Value = Input.subscriptionPlanId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
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
                SqlParameter description = new SqlParameter
                {
                    ParameterName = "description",
                    Value = Input.description,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter imageUrl = new SqlParameter
                {
                    ParameterName = "imageUrl",
                    Value = Input.imageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter noOfDays = new SqlParameter
                {
                    ParameterName = "noOfDays",
                    Value = Input.noOfDays,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter tax = new SqlParameter
                {
                    ParameterName = "tax",
                    Value = Input.tax,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter taxId = new SqlParameter
                {
                    ParameterName = "taxId",
                    Value = Input.taxId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter amount = new SqlParameter
                {
                    ParameterName = "amount",
                    Value = Input.amount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                };
                SqlParameter netAmount = new SqlParameter
                {
                    ParameterName = "netAmount",
                    Value = Input.netAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter credits = new SqlParameter
                {
                    ParameterName = "credits",
                    Value = Input.credits,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter isTrialAvailable = new SqlParameter
                {
                    ParameterName = "isTrialAvailable",
                    Value = Input.isTrialAvailable,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };
                SqlParameter noOfTrialDays = new SqlParameter
                {
                    ParameterName = "noOfTrialDays",
                    Value = Input.noOfTrialDays,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter fromDate = new SqlParameter
                {
                    ParameterName = "fromDate",
                    Value = DateTime.Parse(Input.fromDate, obj),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime

                };
                SqlParameter toDate = new SqlParameter
                {
                    ParameterName = "toDate",
                    Value = DateTime.Parse(Input.toDate, obj),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime

                };
                SqlParameter actualAmount = new SqlParameter
                {
                    ParameterName = "actualAmount",
                    Value = Input.actualAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter displayAmount = new SqlParameter
                {
                    ParameterName = "displayAmount",
                    Value = Input.displayAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter offerId = new SqlParameter
                {
                    ParameterName = "offerId",
                    Value = Input.offerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter offerName = new SqlParameter
                {
                    ParameterName = "offerName",
                    Value = Input.offerName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter[] allParameters = { queryType, subscriptionPlanId,gymOwnerId,branchId, packageName, description, imageUrl,
                    noOfDays,tax,taxId,amount,netAmount,credits,isTrialAvailable, noOfTrialDays, updatedBy,fromDate, toDate,actualAmount,displayAmount,offerId,offerName };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrSubscriptionPlan", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate SubscriptionPlan master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateSubscriptionPlan_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateSubscriptionPlanMstrAsyn(ActivateOrInactivateSubscriptionPlan_In Input)
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
                SqlParameter subscriptionPlanId = new SqlParameter
                {
                    ParameterName = "subscriptionPlanId",
                    Value = Input.subscriptionPlanId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType, subscriptionPlanId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrSubscriptionPlan", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}