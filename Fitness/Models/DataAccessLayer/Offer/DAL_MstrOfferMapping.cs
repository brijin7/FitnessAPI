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
using static Fitness.Models.BusinessObject.Offer.BOL_MstrOfferMapping;

namespace Fitness.Models.DataAccessLayer.Offer
{
    public  class DAL_MstrOfferMapping :SqlHelper
    {
        /// <summary>
        /// this method is used to fetch offer Mapping master details from db
        /// </summary>
        /// <param name="Input">GetMstrOfferMapping_In class as input parameter</param>
        /// <returns>list of GetMstrOfferMapping_Out as output</returns>
        public async Task<List<GetMstrOfferMapping_Out>> UD_GetMstrOfferMappingAsync(GetMstrOfferMapping_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetMstrOfferMapping",
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrOfferMapping", allParameters);

                List<GetMstrOfferMapping_Out> lstOfOutput = new List<GetMstrOfferMapping_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetMstrOfferMapping_Out Output = new GetMstrOfferMapping_Out();
                    Output.offerMappingId = (int)(dr["offerMappingId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();                  
                    Output.offerId = (int)(dr["offerId"]);
                    Output.offerTypePeriod = dr["offerTypePeriod"].ToString();
                    Output.offerHeading = dr["offerHeading"].ToString();
                    Output.offerDescription = dr["offerDescription"].ToString();
                    Output.offerCode = dr["offerCode"].ToString();
                    Output.offerImageUrl = dr["offerImageUrl"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.offerType = Convert.ToString(dr["offerType"]);
                    Output.offerValue = Convert.ToDecimal(dr["offerValue"]);
                    Output.minAmt = Convert.ToDecimal(dr["minAmt"]);
                    Output.maxAmt = Convert.ToDecimal(dr["maxAmt"]);
                    Output.noOfTimesPerUser = (int)(dr["noOfTimesPerUser"]);
                    Output.termsAndConditions = dr["termsAndConditions"].ToString();
                    Output.activeStatus = dr["activeStatus"].ToString();
                    Output.expireStatus = dr["expireStatus"].ToString();

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
        /// this method is used to fetch offer Mapping master details from db
        /// </summary>
        /// <param name="Input">GetMstrOfferMapping_In class as input parameter</param>
        /// <returns>list of GetMstrOfferMapping_Out as output</returns>
        public async Task<List<GetMstrOfferMapping_Out>> UD_GetMstrOfferMappingUserAsync(GetMstrOfferMapping_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetMstrOfferMappingUser",
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrOfferMapping", allParameters);

                List<GetMstrOfferMapping_Out> lstOfOutput = new List<GetMstrOfferMapping_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetMstrOfferMapping_Out Output = new GetMstrOfferMapping_Out();
                    Output.offerMappingId = (int)(dr["offerMappingId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.offerId = (int)(dr["offerId"]);
                    Output.offerTypePeriod = dr["offerTypePeriod"].ToString();
                    Output.offerHeading = dr["offerHeading"].ToString();
                    Output.offerDescription = dr["offerDescription"].ToString();
                    Output.offerCode = dr["offerCode"].ToString();
                    Output.offerImageUrl = dr["offerImageUrl"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.offerType = Convert.ToString(dr["offerType"]);
                    Output.offerValue = Convert.ToDecimal(dr["offerValue"]);
                    Output.minAmt = Convert.ToDecimal(dr["minAmt"]);
                    Output.maxAmt = Convert.ToDecimal(dr["maxAmt"]);
                    Output.noOfTimesPerUser = (int)(dr["noOfTimesPerUser"]);
                    Output.termsAndConditions = dr["termsAndConditions"].ToString();
                    Output.activeStatus = dr["activeStatus"].ToString();
                    Output.expireStatus = dr["expireStatus"].ToString();
                    Output.OfferValueType = dr["OfferValueType"].ToString();

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
        /// this method is used to update OfferMapping details in db
        /// </summary>
        /// <param name="Input"> Update OfferMapping Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateMstrOfferMappingAsyc(UpdateMstrOfferMapping_In Input)
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
                SqlParameter offerMappingId = new SqlParameter
                {
                    ParameterName = "offerMappingId",
                    Value = Input.offerMappingId,
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
                SqlParameter offerId = new SqlParameter
                {
                    ParameterName = "offerId",
                    Value = Input.offerId,
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
                SqlParameter[] allParameters = { queryType,offerMappingId, gymOwnerId
                        ,branchId, offerId,  updatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrOfferMapping", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// this method is used to Insert OfferMapping details in db
        /// </summary>
        /// <param name="Input">InsertMstrOfferMapping_In</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertMstrOfferMappingAsyc(InsertMstrOfferMapping_In Input)
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
                SqlParameter offerId = new SqlParameter
                {
                    ParameterName = "offerId",
                    Value = Input.offerId,
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
                SqlParameter[] allParameters = { queryType, gymOwnerId
                        ,branchId, offerId,  createdBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrOfferMapping", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate offer master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateMstrOfferMapping_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateMstrOfferMappingAsyn(ActivateOrInactivateMstrOfferMapping_In Input)
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
                SqlParameter offerMappingId = new SqlParameter
                {
                    ParameterName = "offerMappingId",
                    Value = Input.offerMappingId,
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
              

                SqlParameter[] allParameters = { queryType, offerMappingId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrOfferMapping", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}