using Fitness.Helper;
using Fitness.Models.CommonModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.Offer.BOL_MstrOffer;

namespace Fitness.Models.DataAccessLayer.Offer
{
    public class DAL_MstrOffer : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);
        /// <summary>
        /// this method is used to insert details in Offer in db
        /// </summary>
        /// <param name="Input">InsertOffer_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertMstrOfferAsync(InsertOffer_In Input)
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

                SqlParameter offerTypePeriod = new SqlParameter
                {
                    ParameterName = "offerTypePeriod",
                    Value = Input.offerTypePeriod,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char
                }; 
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter offerHeading = new SqlParameter
                {
                    ParameterName = "offerHeading",
                    Value = Input.offerHeading,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter offerDescription = new SqlParameter
                {
                    ParameterName = "offerDescription",
                    Value = Input.offerDescription,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter offerCode = new SqlParameter
                {
                    ParameterName = "offerCode",
                    Value = Input.offerCode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                };
                SqlParameter offerImageUrl = new SqlParameter
                {
                    ParameterName = "offerImageUrl",
                    Value = Input.offerImageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                };
                SqlParameter fromDate = new SqlParameter
                {
                    ParameterName = "fromDate",
                    Value = DateTime.Parse(Input.fromDate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime,
                };
                SqlParameter toDate = new SqlParameter
                {
                    ParameterName = "toDate",
                    Value = DateTime.Parse(Input.toDate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime,
                };
                SqlParameter offerType = new SqlParameter
                {
                    ParameterName = "offerType",
                    Value = Input.offerType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };
                SqlParameter offerValue = new SqlParameter
                {
                    ParameterName = "offerValue",
                    Value = Input.offerValue,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                };
                SqlParameter minAmt = new SqlParameter
                {
                    ParameterName = "minAmt",
                    Value = Input.minAmt,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                };
                SqlParameter maxAmt = new SqlParameter
                {
                    ParameterName = "maxAmt",
                    Value = Input.maxAmt,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                };
                SqlParameter noOfTimesPerUser = new SqlParameter
                {
                    ParameterName = "noOfTimesPerUser",
                    Value = Input.noOfTimesPerUser,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter termsAndConditions = new SqlParameter
                {
                    ParameterName = "termsAndConditions",
                    Value = Input.termsAndConditions,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType,gymOwnerId, offerTypePeriod, offerHeading, offerDescription, offerCode,
                    offerImageUrl,fromDate,toDate,offerType,offerValue,minAmt,maxAmt,noOfTimesPerUser,termsAndConditions, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrOffer", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch Offer details from db
        /// </summary>
        /// <param name="Input">GetOffer_In class as input parameter</param>
        /// <returns>list of GetOffer_Out as output</returns>
        public async Task<List<GetOffer_Out>> UD_GetOfferAsync(GetOffer_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getOffer",
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
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, offerId, gymOwnerId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrOffer", allParameters);

                List<GetOffer_Out> lstOfOutput = new List<GetOffer_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetOffer_Out Output = new GetOffer_Out();
                    Output.offerId = (int)(dr["offerId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
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
        /// this method is used to fetch ddlOffer details from db
        /// </summary>
        /// <param name="Input">GetddlOffer_In class as input parameter</param>
        /// <returns>list of GetddlOffer_Out as output</returns>
        public async Task<List<GetddlOffer_Out>> UD_GetddlOfferAsync(GetOffer_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "ddlgetOffer",
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrOffer", allParameters);

                List<GetddlOffer_Out> lstOfOutput = new List<GetddlOffer_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetddlOffer_Out Output = new GetddlOffer_Out();
                    Output.offerId = (int)(dr["offerId"]);
                    Output.offerHeading = dr["offerHeading"].ToString();
                    Output.offerCode = dr["offerCode"].ToString();
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
        /// this method is used to update Offer details in db
        /// </summary>
        /// <param name="Input">UpdateOffer_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateOfferAsync(UpdateOffer_In Input)
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

                SqlParameter offerId = new SqlParameter
                {
                    ParameterName = "offerId",
                    Value = Input.offerId,
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
                SqlParameter offerTypePeriod = new SqlParameter
                {
                    ParameterName = "offerTypePeriod",
                    Value = Input.offerTypePeriod,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char
                };
                SqlParameter offerHeading = new SqlParameter
                {
                    ParameterName = "offerHeading",
                    Value = Input.offerHeading,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter offerDescription = new SqlParameter
                {
                    ParameterName = "offerDescription",
                    Value = Input.offerDescription,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter offerCode = new SqlParameter
                {
                    ParameterName = "offerCode",
                    Value = Input.offerCode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                };
                SqlParameter offerImageUrl = new SqlParameter
                {
                    ParameterName = "offerImageUrl",
                    Value = Input.offerImageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                };
                SqlParameter fromDate = new SqlParameter
                {
                    ParameterName = "fromDate",
                    Value = DateTime.Parse(Input.fromDate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime,
                };
                SqlParameter toDate = new SqlParameter
                {
                    ParameterName = "toDate",
                    Value = DateTime.Parse(Input.toDate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime,
                };
                SqlParameter offerType = new SqlParameter
                {
                    ParameterName = "offerType",
                    Value = Input.offerType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };
                SqlParameter offerValue = new SqlParameter
                {
                    ParameterName = "offerValue",
                    Value = Input.offerValue,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                };
                SqlParameter minAmt = new SqlParameter
                {
                    ParameterName = "minAmt",
                    Value = Input.minAmt,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                };
                SqlParameter maxAmt = new SqlParameter
                {
                    ParameterName = "maxAmt",
                    Value = Input.maxAmt,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                };
                SqlParameter noOfTimesPerUser = new SqlParameter
                {
                    ParameterName = "noOfTimesPerUser",
                    Value = Input.noOfTimesPerUser,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter termsAndConditions = new SqlParameter
                {
                    ParameterName = "termsAndConditions",
                    Value = Input.termsAndConditions,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType,offerId ,gymOwnerId, offerTypePeriod, offerHeading, offerDescription, offerCode,
                    offerImageUrl,fromDate,toDate,offerType,offerValue,minAmt,maxAmt,noOfTimesPerUser,termsAndConditions, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrOffer", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate Offer master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateOffer_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateOfferMstrAsyn(ActivateOrInactivateOffer_In Input)
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

                SqlParameter offerId = new SqlParameter
                {
                    ParameterName = "offerId",
                    Value = Input.offerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType, offerId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrOffer", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}