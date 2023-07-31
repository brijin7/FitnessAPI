using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.SubscriptionBooking.BOL_SubscriptionBooking;
using Fitness.Helper;

namespace Fitness.Models.DataAccessLayer.SubscriptionBooking
{
    public class DAL_SubscriptionBooking  : SqlHelper
    {
        /// <summary>
        /// this method is used to Insert branchmaster details in db
        /// </summary>
        /// <param name="Input"> Insert Branch Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertSubscriptionBookingAsyc(InsertSubscriptionBooking_In Input)
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
                SqlParameter subBookingId = new SqlParameter
                {
                    ParameterName = "subBookingId",
                    Value = Input.subBookingId,
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
                SqlParameter branchName = new SqlParameter
                {
                    ParameterName = "branchName",
                    Value = Input.branchName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };

               
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
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

                SqlParameter booking = new SqlParameter
                {
                    ParameterName = "booking",
                    Value = Input.booking,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 2
                };
                SqlParameter loginType = new SqlParameter
                {
                    ParameterName = "loginType",
                    Value = Input.loginType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 1
                };
               
                SqlParameter price = new SqlParameter
                {
                    ParameterName = "price",
                    Value = Input.price,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter taxId = new SqlParameter
                {
                    ParameterName = "taxId",
                    Value = Input.taxId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter taxName = new SqlParameter
                {
                    ParameterName = "taxName",
                    Value = Input.taxName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                SqlParameter taxAmount = new SqlParameter
                {
                    ParameterName = "taxAmount",
                    Value = Input.taxAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                SqlParameter offerId = new SqlParameter
                {
                    ParameterName = "offerId",
                    Value = Input.offerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter offerAmount = new SqlParameter
                {
                    ParameterName = "offerAmount",
                    Value = Input.offerAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };


                SqlParameter totalAmount = new SqlParameter
                {
                    ParameterName = "totalAmount",
                    Value = Input.totalAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter paidAmount = new SqlParameter
                {
                    ParameterName = "paidAmount",
                    Value = Input.paidAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50

                };
                SqlParameter paymentStatus = new SqlParameter
                {
                    ParameterName = "paymentStatus",
                    Value = Input.paymentStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1

                };
               
              
                SqlParameter paymentType = new SqlParameter
                {
                    ParameterName = "paymentType",
                    Value = Input.paymentType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                ;
                SqlParameter transactionId = new SqlParameter
                {
                    ParameterName = "transactionId",
                    Value = Input.transactionId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                SqlParameter bankName = new SqlParameter
                {
                    ParameterName = "bankName",
                    Value = Input.bankName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                SqlParameter bankReferenceNumber = new SqlParameter
                {
                    ParameterName = "bankReferenceNumber",
                    Value = Input.bankReferenceNumber,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
 
                SqlParameter[] allParameters = { queryType,subBookingId, gymOwnerId ,branchId ,branchName ,subscriptionPlanId  ,userId
                            ,booking,loginType,price ,taxId ,taxName ,taxAmount ,offerId  ,offerAmount
                             ,totalAmount,paidAmount,paymentStatus ,paymentType
                            ,transactionId,bankName  ,bankReferenceNumber,createdBy};
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_TranSubspBooking", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// this method is used to fetch SubspBooking details from db
        /// </summary>
        /// <param name="Input">GetSubspBooking_In class as input parameter</param>
        /// <returns>list of GetSubspBooking_Out as output</returns>
        public async Task<List<GetSubspBooking_Out>> UD_GetSubspBookingAsync()
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getAllSubspBookingDetails",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter[] allParameters = { queryType };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetSubspBookingDetails", allParameters);

                List<GetSubspBooking_Out> lstOfOutput = new List<GetSubspBooking_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetSubspBooking_Out Output = new GetSubspBooking_Out();
                    Output.subBookingId = (int)(dr["subBookingId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.subscriptionPlanId = (int)(dr["subscriptionPlanId"]);
                    Output.packageName = dr["packageName"].ToString();
                    Output.noOfDays = dr["noOfDays"].ToString();
                    Output.noOfTrialDays = dr["noOfTrialDays"].ToString();
                    Output.netAmount = dr["netAmount"].ToString();
                    Output.amount = dr["amount"].ToString();
                    Output.isTrialAvailable = dr["isTrialAvailable"].ToString();
                    Output.tax = dr["tax"].ToString();
                    Output.userId = (int)(dr["userId"]);
                    Output.UserName = dr["UserName"].ToString();
                    Output.booking = dr["booking"].ToString();
                    Output.loginType = dr["loginType"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.price = dr["price"].ToString();
                    Output.taxId = (int)(dr["taxId"]);
                    Output.taxName = dr["taxName"].ToString();
                    Output.taxAmount = dr["taxAmount"].ToString();
                    Output.offerId = (int)(dr["offerId"]);
                    Output.offerAmount = dr["offerAmount"].ToString();
                    Output.totalAmount = dr["totalAmount"].ToString();
                    Output.paidAmount = dr["paidAmount"].ToString();
                    Output.paymentStatus = dr["paymentStatus"].ToString();
                    Output.paymentType = dr["paymentType"].ToString();
                    Output.cancellationStatus = dr["cancellationStatus"].ToString();
                    Output.refundStatus = dr["refundStatus"].ToString();
                    Output.cancellationCharges = dr["cancellationCharges"].ToString();
                    Output.refundAmt = dr["refundAmt"].ToString();
                    Output.cancellationReason = dr["cancellationReason"].ToString();
                    Output.bookingDate = dr["bookingDate"].ToString();
                    Output.cgstTax = dr["cgstTax"].ToString();
                    Output.sgstTax = dr["sgstTax"].ToString();

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
        /// this method is used to fetch UserSubspBooking details from db
        /// </summary>
        /// <param name="Input">GetUserSubspBooking_In class as input parameter</param>
        /// <returns>list of GetUserSubspBooking_Out as output</returns>
        public async Task<List<GetSubspBooking_Out>> UD_GetUserSubspBookingAsync(GetUserSubspBooking_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getUserSubspBookingDetails",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };

                SqlParameter[] allParameters = { queryType, userId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetSubspBookingDetails", allParameters);

                List<GetSubspBooking_Out> lstOfOutput = new List<GetSubspBooking_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetSubspBooking_Out Output = new GetSubspBooking_Out();
                    Output.subBookingId = (int)(dr["subBookingId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.subscriptionPlanId = (int)(dr["subscriptionPlanId"]);
                    Output.packageName = dr["packageName"].ToString();
                    Output.noOfDays = dr["noOfDays"].ToString();
                    Output.noOfTrialDays = dr["noOfTrialDays"].ToString();
                    Output.netAmount = dr["netAmount"].ToString();
                    Output.amount = dr["amount"].ToString();
                    Output.isTrialAvailable = dr["isTrialAvailable"].ToString();
                    Output.tax = dr["tax"].ToString();
                    Output.userId = (int)(dr["userId"]);
                    Output.UserName = dr["UserName"].ToString();
                    Output.booking = dr["booking"].ToString();
                    Output.loginType = dr["loginType"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.price = dr["price"].ToString();
                    Output.taxId = (int)(dr["taxId"]);
                    Output.taxName = dr["taxName"].ToString();
                    Output.taxAmount = dr["taxAmount"].ToString();
                    Output.offerId = (int)(dr["offerId"]);
                    Output.offerAmount = dr["offerAmount"].ToString();                   
                    Output.totalAmount = dr["totalAmount"].ToString();
                    Output.paidAmount = dr["paidAmount"].ToString();
                    Output.paymentStatus = dr["paymentStatus"].ToString();
                    Output.paymentType = dr["paymentType"].ToString();
                    Output.cancellationStatus = dr["cancellationStatus"].ToString();
                    Output.refundStatus = dr["refundStatus"].ToString();
                    Output.cancellationCharges = dr["cancellationCharges"].ToString();
                    Output.refundAmt = dr["refundAmt"].ToString();
                    Output.cancellationReason = dr["cancellationReason"].ToString();
                    Output.bookingDate = dr["bookingDate"].ToString();
                    Output.cgstTax = dr["cgstTax"].ToString();
                    Output.sgstTax = dr["sgstTax"].ToString();

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
        /// this method is used to fetch UserSubspBooking details from db
        /// </summary>
        /// <param name="Input">GetUserSubspBooking_In class as input parameter</param>
        /// <returns>list of GetUserSubspBooking_Out as output</returns>
        public async Task<List<GetSubspBooking_Out>> UD_GetBookingIdSubspBookingAsync(GetBookingIdSubspBooking_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getBookingIdSubspBookingDetails",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter BookingId = new SqlParameter
                {
                    ParameterName = "BookingId",
                    Value = Input.BookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };

                SqlParameter[] allParameters = { queryType, BookingId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetSubspBookingDetails", allParameters);

                List<GetSubspBooking_Out> lstOfOutput = new List<GetSubspBooking_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetSubspBooking_Out Output = new GetSubspBooking_Out();
                    Output.subBookingId = (int)(dr["subBookingId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.subscriptionPlanId = (int)(dr["subscriptionPlanId"]);
                    Output.packageName = dr["packageName"].ToString();
                    Output.noOfDays = dr["noOfDays"].ToString();
                    Output.noOfTrialDays = dr["noOfTrialDays"].ToString();
                    Output.netAmount = dr["netAmount"].ToString();
                    Output.amount = dr["amount"].ToString();
                    Output.isTrialAvailable = dr["isTrialAvailable"].ToString();
                    Output.tax = dr["tax"].ToString();
                    Output.userId = (int)(dr["userId"]);
                    Output.UserName = dr["UserName"].ToString();
                    Output.booking = dr["booking"].ToString();
                    Output.loginType = dr["loginType"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.price = dr["price"].ToString();
                    Output.taxId = (int)(dr["taxId"]);
                    Output.taxName = dr["taxName"].ToString();
                    Output.taxAmount = dr["taxAmount"].ToString();
                    Output.offerId = (int)(dr["offerId"]);
                    Output.offerAmount = dr["offerAmount"].ToString();
                    Output.totalAmount = dr["totalAmount"].ToString();
                    Output.paidAmount = dr["paidAmount"].ToString();
                    Output.paymentStatus = dr["paymentStatus"].ToString();
                    Output.paymentType = dr["paymentType"].ToString();
                    Output.cancellationStatus = dr["cancellationStatus"].ToString();
                    Output.refundStatus = dr["refundStatus"].ToString();
                    Output.cancellationCharges = dr["cancellationCharges"].ToString();
                    Output.refundAmt = dr["refundAmt"].ToString();
                    Output.cancellationReason = dr["cancellationReason"].ToString();
                    Output.bookingDate = dr["bookingDate"].ToString();
                    Output.cgstTax = dr["cgstTax"].ToString();
                    Output.sgstTax = dr["sgstTax"].ToString();

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
        /// this method is used to fetch UserSubspBooking details from db
        /// </summary>
        /// <param name="Input">GetUserSubspBooking_In class as input parameter</param>
        /// <returns>list of GetUserSubspBooking_Out as output</returns>
        public async Task<List<GetSubspBooking_Out>> UD_GetBranchOwnerSubspBookingAsync(GetBranchOwnerSubspBooking_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getBranchownerSubspBookingDetails",
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetSubspBookingDetails", allParameters);

                List<GetSubspBooking_Out> lstOfOutput = new List<GetSubspBooking_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetSubspBooking_Out Output = new GetSubspBooking_Out();
                    Output.subBookingId = (int)(dr["subBookingId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.subscriptionPlanId = (int)(dr["subscriptionPlanId"]);
                    Output.packageName = dr["packageName"].ToString();
                    Output.noOfDays = dr["noOfDays"].ToString();
                    Output.noOfTrialDays = dr["noOfTrialDays"].ToString();
                    Output.netAmount = dr["netAmount"].ToString();
                    Output.amount = dr["amount"].ToString();
                    Output.isTrialAvailable = dr["isTrialAvailable"].ToString();
                    Output.tax = dr["tax"].ToString();
                    Output.userId = (int)(dr["userId"]);
                    Output.UserName = dr["UserName"].ToString();
                    Output.booking = dr["booking"].ToString();
                    Output.loginType = dr["loginType"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.price = dr["price"].ToString();
                    Output.taxId = (int)(dr["taxId"]);
                    Output.taxName = dr["taxName"].ToString();
                    Output.taxAmount = dr["taxAmount"].ToString();
                    Output.offerId = (int)(dr["offerId"]);
                    Output.offerAmount = dr["offerAmount"].ToString();
                    Output.totalAmount = dr["totalAmount"].ToString();
                    Output.paidAmount = dr["paidAmount"].ToString();
                    Output.paymentStatus = dr["paymentStatus"].ToString();
                    Output.paymentType = dr["paymentType"].ToString();
                    Output.cancellationStatus = dr["cancellationStatus"].ToString();
                    Output.refundStatus = dr["refundStatus"].ToString();
                    Output.cancellationCharges = dr["cancellationCharges"].ToString();
                    Output.refundAmt = dr["refundAmt"].ToString();
                    Output.cancellationReason = dr["cancellationReason"].ToString();
                    Output.bookingDate = dr["bookingDate"].ToString();
                    Output.cgstTax = dr["cgstTax"].ToString();
                    Output.sgstTax = dr["sgstTax"].ToString();

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