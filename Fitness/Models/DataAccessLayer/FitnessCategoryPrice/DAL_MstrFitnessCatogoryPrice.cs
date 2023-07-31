using Fitness.Helper;
using Fitness.Models.BusinessObject.FitnessCategoryPrice;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.FitnessCategoryPrice.BOL_MstrFitnessCategoryPrice;
namespace Fitness.Models.DataAccessLayer.FitnessCategoryPrice
{
    public class DAL_MstrFitnessCatogoryPrice : SqlHelper
    {
        IFormatProvider obj = new System.Globalization.CultureInfo("en-GB",true);
        /// <summary>
        /// this method is used to fetch FitnessCatogoryPrice master details from db
        /// </summary>
        /// <param name="Input">GetMstrFitnessCategoryPrice_In class as input parameter</param>
        /// <returns>list of GetMstrFitnessCategoryPrice_Out as output</returns>
        public async Task<List<GetMstrFitnessCategoryPrice_Out>> UD_GetMstrFitnessCategoryPriceAsync(GetMstrFitnessCategoryPrice_In Input)
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrFitnessCategoryPrice", allParameters);

                List<GetMstrFitnessCategoryPrice_Out> lstOfOutput = new List<GetMstrFitnessCategoryPrice_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetMstrFitnessCategoryPrice_Out Output = new GetMstrFitnessCategoryPrice_Out();
                    Output.priceId = (int)(dr["priceId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymName = (dr["gymName"].ToString());
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = (dr["branchName"].ToString());
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = (dr["categoryName"].ToString());
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeName = (dr["trainingTypeName"].ToString());
                    Output.trainingMode = dr["trainingMode"].ToString();
                    Output.planDuration = (int)(dr["planDuration"]);
                    Output.planDurationName = (dr["planDurationName"].ToString());
                    Output.taxId = (int)(dr["taxId"]);
                    Output.taxName = dr["taxName"].ToString();
                    Output.price = dr["price"].ToString();
                    Output.tax = (dr["tax"].ToString());
                    Output.cgstTax = (dr["cgstTax"].ToString());
                    Output.sgstTax = (dr["sgstTax"].ToString());
                    Output.netAmount = dr["netAmount"].ToString();
                    Output.actualAmount = dr["actualAmount"].ToString();
                    Output.displayAmount = dr["displayAmount"].ToString();
                    Output.cyclePaymentsAllowed = dr["cyclePaymentsAllowed"].ToString();
                    Output.maxNoOfCycles = (int)(dr["maxNoOfCycles"]);
                    Output.activeStatus = dr["activeStatus"].ToString();
                    Output.offerId = dr["offerId"].ToString();
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
        /// this method is used to fetch FitnessCatogoryPrice  details from db
        /// </summary>
        /// <param name="Input">GetPriceDetails_In class as input parameter</param>
        /// <returns>list of GetPriceDetails_Out as output</returns>

        public async Task<string> GetPriceDetailsAsync(GetPriceDetails_In Input)
        {
            try
            {
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
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter trainingMode = new SqlParameter
                {
                    ParameterName = "trainingMode",
                    Value = Input.trainingMode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };
                SqlParameter priceId = new SqlParameter
                {
                    ParameterName = "priceId",
                    Value = Input.priceId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };

                SqlParameter[] allParameters = { gymOwnerId, branchId, categoryId, trainingMode, priceId };


                DataTable dt = await GetDataTableFromUSPAsync("GetPriceDetails", allParameters);

                return dt.Rows[0]["GetPriceDetails"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch FitnessCatogoryPrice On Category master details from db
        /// </summary>
        /// <param name="Input">GetMstrFitnessCategoryPrice_In class as input parameter</param>
        /// <returns>list of GetMstrFitnessCategoryPrice_Out as output</returns>
        public async Task<List<GetMstrFitnessCategoryPrice_Out>> UD_GetMstrFitnessCategoryPriceOnCategoryAsync(GetMstrFitnessCategoryPriceonCategory Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetPriceOnCategory",
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
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, categoryId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrFitnessCategoryPrice", allParameters);

                List<GetMstrFitnessCategoryPrice_Out> lstOfOutput = new List<GetMstrFitnessCategoryPrice_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetMstrFitnessCategoryPrice_Out Output = new GetMstrFitnessCategoryPrice_Out();
                    Output.priceId = (int)(dr["priceId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymName = (dr["gymName"].ToString());
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = (dr["branchName"].ToString());
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = (dr["categoryName"].ToString());
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeName = (dr["trainingTypeName"].ToString());
                    Output.trainingMode = dr["trainingMode"].ToString();
                    Output.planDuration = (int)(dr["planDuration"]);
                    Output.planDurationName = (dr["planDurationName"].ToString());
                    Output.taxId = (int)(dr["taxId"]);
                    Output.taxName = dr["taxName"].ToString();
                    Output.price = dr["price"].ToString();
                    Output.tax = (dr["tax"].ToString());
                    Output.cgstTax = (dr["cgstTax"].ToString());
                    Output.sgstTax = (dr["sgstTax"].ToString());
                    Output.netAmount = dr["netAmount"].ToString();
                    Output.actualAmount = dr["actualAmount"].ToString();
                    Output.displayAmount = dr["displayAmount"].ToString();
                    Output.cyclePaymentsAllowed = dr["cyclePaymentsAllowed"].ToString();
                    Output.maxNoOfCycles = (int)(dr["maxNoOfCycles"]);
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
        /// this method is used to fetch FitnessCatogoryPrice On Duration master details from db
        /// </summary>
        /// <param name="Input">GetMstrFitnessCategoryPrice_In class as input parameter</param>
        /// <returns>list of GetMstrFitnessCategoryPrice_Out as output</returns>
        public async Task<List<GetMstrFitnessCategoryPrice_Out>> UD_GetMstrFitnessCategoryPriceOnDurationAsync(GetMstrFitnessCategoryPriceonDuration Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetPriceOnDuration",
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
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter planDuration = new SqlParameter
                {
                    ParameterName = "planDuration",
                    Value = Input.planDuration,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, categoryId, planDuration };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrFitnessCategoryPrice", allParameters);

                List<GetMstrFitnessCategoryPrice_Out> lstOfOutput = new List<GetMstrFitnessCategoryPrice_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetMstrFitnessCategoryPrice_Out Output = new GetMstrFitnessCategoryPrice_Out();
                    Output.priceId = (int)(dr["priceId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymName = (dr["gymName"].ToString());
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = (dr["branchName"].ToString());
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = (dr["categoryName"].ToString());
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeName = (dr["trainingTypeName"].ToString());
                    Output.trainingMode = dr["trainingMode"].ToString();
                    Output.planDuration = (int)(dr["planDuration"]);
                    Output.planDurationName = (dr["planDurationName"].ToString());
                    Output.taxId = (int)(dr["taxId"]);
                    Output.taxName = dr["taxName"].ToString();
                    Output.price = dr["price"].ToString();
                    Output.tax = (dr["tax"].ToString());
                    Output.cgstTax = (dr["cgstTax"].ToString());
                    Output.sgstTax = (dr["sgstTax"].ToString());
                    Output.netAmount = dr["netAmount"].ToString();
                    Output.actualAmount = dr["actualAmount"].ToString();
                    Output.displayAmount = dr["displayAmount"].ToString();
                    Output.cyclePaymentsAllowed = dr["cyclePaymentsAllowed"].ToString();
                    Output.maxNoOfCycles = (int)(dr["maxNoOfCycles"]);
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

        // <summary>
        /// this method is used to fetch FitnessCatogoryPrice master details from db
        /// </summary>
        /// <param name="Input">GetMstrFitnessCategoryPrice_In class as input parameter</param>
        /// <returns>list of GetMstrFitnessCategoryPrice_Out as output</returns>
        public async Task<List<GetMstrFitnessCategoryPriceDetailsForSlot_Out>> UD_GetMstrFitnessCategoryPriceDetailsForSlotAsync(GetMstrFitnessCategoryPriceDetailsForSlot_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetPriceListForSlot",
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
                SqlParameter priceId = new SqlParameter
                {
                    ParameterName = "priceId",
                    Value = Input.priceId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, priceId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrFitnessCategoryPrice", allParameters);

                List<GetMstrFitnessCategoryPriceDetailsForSlot_Out> lstOfOutput = new List<GetMstrFitnessCategoryPriceDetailsForSlot_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetMstrFitnessCategoryPriceDetailsForSlot_Out Output = new GetMstrFitnessCategoryPriceDetailsForSlot_Out();
                    Output.priceId = (int)(dr["priceId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymName = (dr["gymName"].ToString());
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = (dr["branchName"].ToString());
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = (dr["categoryName"].ToString());
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeName = (dr["trainingTypeName"].ToString());
                    Output.trainingMode = dr["trainingMode"].ToString();
                    Output.planDuration = (int)(dr["planDuration"]);
                    Output.planDurationName = (dr["planDurationName"].ToString());
                    Output.taxId = (int)(dr["taxId"]);
                    Output.taxName = dr["taxName"].ToString();
                    Output.price = dr["price"].ToString();
                    Output.tax = (dr["tax"].ToString());
                    Output.cgstTax = (dr["cgstTax"].ToString());
                    Output.sgstTax = (dr["sgstTax"].ToString());
                    Output.netAmount = dr["netAmount"].ToString();
                    Output.actualAmount = dr["actualAmount"].ToString();
                    Output.displayAmount = dr["displayAmount"].ToString();
                    Output.cyclePaymentsAllowed = dr["cyclePaymentsAllowed"].ToString();
                    Output.maxNoOfCycles = (int)(dr["maxNoOfCycles"]);
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
        /// this method is used to Insert FitnessCategoryPricemaster details in db
        /// </summary>
        /// <param name="Input"> InsertMstrFitnessCategoryPrice_In</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertMstrFitnessCategoryPriceAsyc(InsertMstrFitnessCategoryPrice_In Input)
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
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter trainingTypeId = new SqlParameter
                {
                    ParameterName = "trainingTypeId",
                    Value = Input.trainingTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter planDuration = new SqlParameter
                {
                    ParameterName = "planDuration",
                    Value = Input.planDuration,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter trainingMode = new SqlParameter
                {
                    ParameterName = "trainingMode",
                    Value = Input.trainingMode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };
                SqlParameter price = new SqlParameter
                {
                    ParameterName = "price",
                    Value = Input.price,
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
                SqlParameter tax = new SqlParameter
                {
                    ParameterName = "tax",
                    Value = Input.tax,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter netAmount = new SqlParameter
                {
                    ParameterName = "netAmount",
                    Value = Input.netAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
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
                SqlParameter cyclePaymentsAllowed = new SqlParameter
                {
                    ParameterName = "cyclePaymentsAllowed",
                    Value = Input.cyclePaymentsAllowed,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };
                SqlParameter maxNoOfCycles = new SqlParameter
                {
                    ParameterName = "maxNoOfCycles",
                    Value = Input.maxNoOfCycles,
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
                SqlParameter offerName = new SqlParameter
                {
                    ParameterName = "offerName",
                    Value = Input.offerName,
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
                SqlParameter[] allParameters = { queryType, gymOwnerId,branchId,categoryId,trainingTypeId,
                    planDuration,trainingMode, price, taxId, tax,netAmount,actualAmount,displayAmount, cyclePaymentsAllowed,
                    maxNoOfCycles, createdBy ,offerId,offerName,fromDate,toDate};
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrFitnessCategoryPrice", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// this method is used to Update FitnessCategoryPricemaster details in db
        /// </summary>
        /// <param name="Input"> UpdateMstrFitnessCategoryPrice_In</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateMstrFitnessCategoryPriceAsyc(UpdateMstrFitnessCategoryPrice_In Input)
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
                SqlParameter priceId = new SqlParameter
                {
                    ParameterName = "priceId",
                    Value = Input.priceId,
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
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter trainingTypeId = new SqlParameter
                {
                    ParameterName = "trainingTypeId",
                    Value = Input.trainingTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter planDuration = new SqlParameter
                {
                    ParameterName = "planDuration",
                    Value = Input.planDuration,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter trainingMode = new SqlParameter
                {
                    ParameterName = "trainingMode",
                    Value = Input.trainingMode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };
                SqlParameter price = new SqlParameter
                {
                    ParameterName = "price",
                    Value = Input.price,
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
                SqlParameter tax = new SqlParameter
                {
                    ParameterName = "tax",
                    Value = Input.tax,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter netAmount = new SqlParameter
                {
                    ParameterName = "netAmount",
                    Value = Input.netAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
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
                SqlParameter cyclePaymentsAllowed = new SqlParameter
                {
                    ParameterName = "cyclePaymentsAllowed",
                    Value = Input.cyclePaymentsAllowed,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };
                SqlParameter maxNoOfCycles = new SqlParameter
                {
                    ParameterName = "maxNoOfCycles",
                    Value = Input.maxNoOfCycles,
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
                SqlParameter[] allParameters = { queryType,priceId, gymOwnerId,branchId,categoryId,trainingTypeId,
                    planDuration,trainingMode, price, taxId, tax,netAmount,actualAmount,displayAmount,
                    cyclePaymentsAllowed, maxNoOfCycles, updatedBy,offerId,offerName,fromDate,toDate };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrFitnessCategoryPrice", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// this method is used to activate and inactivate MstrFitnessCategoryPrice master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateMstrFitnessCategoryPrice_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateMstrFitnessCategoryPriceAsyc(ActivateOrInactivateMstrFitnessCategoryPrice_In Input)
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
                SqlParameter priceId = new SqlParameter
                {
                    ParameterName = "priceId",
                    Value = Input.priceId,
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
                    SqlDbType = SqlDbType.Int,
                };



                SqlParameter[] allParameters = { queryType, priceId, branchId, gymOwnerId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrFitnessCategoryPrice", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<List<GetPriceOnPublicWeb_Out>> UD_GetPriceOnPublicWebAsync(GetPriceOnPublicWeb_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetPriceOnPublicWeb",
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
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, categoryId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrFitnessCategoryPrice", allParameters);

                List<GetPriceOnPublicWeb_Out> lstOfOutput = new List<GetPriceOnPublicWeb_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetPriceOnPublicWeb_Out Output = new GetPriceOnPublicWeb_Out();
                    Output.priceId = (int)(dr["priceId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.branchName = (dr["branchName"].ToString());
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = (dr["branchName"].ToString());
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = (dr["categoryName"].ToString());
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeName = (dr["trainingTypeName"].ToString());
                    Output.trainingMode = dr["trainingMode"].ToString();
                    Output.planDuration = (int)(dr["planDuration"]);
                    Output.planDurationName = (dr["planDurationName"].ToString());
                    Output.taxId = (int)(dr["taxId"]);
                    Output.taxName = dr["taxName"].ToString();
                    Output.price = dr["price"].ToString();
                    Output.tax = (dr["tax"].ToString());
                    Output.cgstTax = (dr["cgstTax"].ToString());
                    Output.sgstTax = (dr["sgstTax"].ToString());
                    Output.netAmount = dr["netAmount"].ToString();
                    Output.actualAmount = dr["actualAmount"].ToString();
                    Output.displayAmount = dr["displayAmount"].ToString();
                    Output.SavedAmount = dr["SavedAmount"].ToString();
                    Output.cyclePaymentsAllowed = dr["cyclePaymentsAllowed"].ToString();
                    Output.maxNoOfCycles = (int)(dr["maxNoOfCycles"]);
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
    }
}