using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.Booking.BOL_Booking;
using Fitness.Helper;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Fitness.Models.DataAccessLayer.Booking
{
    public class DAL_Booking : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);
        /// <summary>
        /// this method is used to Insert branchmaster details in db
        /// </summary>
        /// <param name="Input"> Insert Branch Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertBookingAsyc(InsertBooking_In Input)
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
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
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
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
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
                SqlParameter planDurationId = new SqlParameter
                {
                    ParameterName = "planDurationId",
                    Value = Input.planDurationId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter traningMode = new SqlParameter
                {
                    ParameterName = "traningMode",
                    Value = Input.traningMode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size=1

                };
                SqlParameter slotId = new SqlParameter
                {
                    ParameterName = "slotId",
                    Value = Input.slotId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                
                SqlParameter slotFromTime = new SqlParameter
                {
                    ParameterName = "slotFromTime",
                    Value = Input.slotFromTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50

                };
                SqlParameter slotToTime = new SqlParameter
                {
                    ParameterName = "slotToTime",
                    Value = Input.slotToTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter phoneNumber = new SqlParameter
                {
                    ParameterName = "phoneNumber",
                    Value = Input.phoneNumber,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
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
				SqlParameter trainerId = new SqlParameter
				{
					ParameterName = "trainerId",
					Value = Input.trainerId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int
				};
				SqlParameter wakeUpTime = new SqlParameter
				{
					ParameterName = "wakeUpTime",
					Value = Input.wakeUpTime,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar
				};

				SqlParameter slotSwapType = new SqlParameter
				{
					ParameterName = "slotSwapType",
					Value = Input.slotSwapType,
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
                SqlParameter taxName = new SqlParameter
                {
                    ParameterName = "taxName",
                    Value = Input.taxName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter taxAmount = new SqlParameter
                {
                    ParameterName = "taxAmount",
                    Value = Input.taxAmount,
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
                SqlParameter offerAmount = new SqlParameter
                {
                    ParameterName = "offerAmount",
                    Value = Input.offerAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
               
                
                SqlParameter totalAmount = new SqlParameter
                {
                    ParameterName = "totalAmount",
                    Value = Input.totalAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter paidAmount = new SqlParameter
                {
                    ParameterName = "paidAmount",
                    Value = Input.paidAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal

                };
                SqlParameter paymentStatus = new SqlParameter
                {
                    ParameterName = "paymentStatus",
                    Value = Input.paymentStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size=1

                };
                SqlParameter paymentCycles = new SqlParameter
                {
                    ParameterName = "paymentCycles",
                    Value = Input.paymentCycles,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter paymentCyclesStatus = new SqlParameter
                {
                    ParameterName = "paymentCyclesStatus",
                    Value = Input.paymentCyclesStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size=1

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
                //SqlParameter utilizedRewardPoints = new SqlParameter
                //{
                //    ParameterName = "utilizedRewardPoints",
                //    Value = Input.utilizedRewardPoints,
                //    Direction = ParameterDirection.Input,
                //    SqlDbType = SqlDbType.Int

                //};
                //SqlParameter rewardPointsAmount = new SqlParameter
                //{
                //    ParameterName = "rewardPointsAmount",
                //    Value = Input.rewardPointsAmount,
                //    Direction = ParameterDirection.Input,
                //    SqlDbType = SqlDbType.NVarChar,
                //    Size = 50
                //};
                //SqlParameter cancellationStatus = new SqlParameter
                //{
                //    ParameterName = "cancellationStatus",
                //    Value = Input.cancellationStatus,
                //    Direction = ParameterDirection.Input,
                //    SqlDbType = SqlDbType.Char,
                //    Size = 1

                //};
                //SqlParameter refundStatus = new SqlParameter
                //{
                //    ParameterName = "refundStatus",
                //    Value = Input.refundStatus,
                //    Direction = ParameterDirection.Input,
                //    SqlDbType = SqlDbType.Char,
                //    Size = 1
                //};
                //SqlParameter cancellationCharges = new SqlParameter
                //{
                //    ParameterName = "cancellationCharges",
                //    Value = Input.cancellationCharges,
                //    Direction = ParameterDirection.Input,
                //    SqlDbType = SqlDbType.NVarChar,
                //    Size = 50

                //};
                //SqlParameter refundAmt = new SqlParameter
                //{
                //    ParameterName = "refundAmt ",
                //    Value = Input.refundAmt,
                //    Direction = ParameterDirection.Input,
                //    SqlDbType = SqlDbType.NVarChar,
                //    Size = 50
                //};
                //SqlParameter cancellationReason = new SqlParameter
                //{
                //    ParameterName = "cancellationReason",
                //    Value = Input.cancellationReason,
                //    Direction = ParameterDirection.Input,
                //    SqlDbType = SqlDbType.VarChar

                //};
                SqlParameter[] allParameters = { queryType,bookingId, gymOwnerId ,branchId ,branchName ,categoryId  ,planDurationId,
                             trainingTypeId ,traningMode,slotId ,slotFromTime ,slotToTime,trainerId,wakeUpTime,slotSwapType, priceId  ,phoneNumber,userId
                            ,booking,loginType,price ,taxId ,taxName ,taxAmount ,offerId  ,offerAmount  
                             ,totalAmount,paidAmount,paymentStatus ,paymentCyclesStatus,paymentCycles,paymentType 
                            ,transactionId,bankName  ,bankReferenceNumber,createdBy};
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_TranUserBooking", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// this method is used to fetch Booking details from db
        /// </summary>
        /// <param name="Input">GetBooking_In class as input parameter</param>
        /// <returns>list of GetBooking_Out as output</returns>
        public async Task<List<GetBooking_Out>> UD_GetBookingAsync(GetBooking_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getDateBasedBookingDetails",
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
                SqlParameter fromDate = new SqlParameter
                {
                    ParameterName = "fromDate",
                    Value = Input.fromDate,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter toDate = new SqlParameter
                {
                    ParameterName = "toDate",
                    Value = Input.toDate,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };

                SqlParameter[] allParameters = { queryType, gymOwnerId , branchId , fromDate , toDate };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetBookingDetails", allParameters);

                List<GetBooking_Out> lstOfOutput = new List<GetBooking_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetBooking_Out Output = new GetBooking_Out();
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = dr["categoryName"].ToString();                  
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeName = dr["trainingTypeName"].ToString();
                    Output.traningMode = dr["traningMode"].ToString();
                    Output.slotId = (int)(dr["slotId"]);
                    Output.slotFromTime = dr["slotFromTime"].ToString();
                    Output.slotToTime = dr["slotToTime"].ToString();
                    Output.priceId = (int)(dr["priceId"]);
                    Output.phoneNumber = dr["phoneNumber"].ToString();
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
                    Output.utilizedRewardPoints = dr["utilizedRewardPoints"].ToString();
                    Output.rewardPointsAmount = dr["rewardPointsAmount"].ToString();
                    Output.totalAmount = dr["totalAmount"].ToString();
                    Output.paidAmount = dr["paidAmount"].ToString();
                    Output.paymentStatus = dr["paymentStatus"].ToString();
                    Output.paymentCycles = dr["paymentCycles"].ToString();
                    Output.paymentType = dr["paymentType"].ToString();
                    Output.cancellationStatus = dr["cancellationStatus"].ToString();
                    Output.refundStatus = dr["refundStatus"].ToString();
                    Output.cancellationCharges = dr["cancellationCharges"].ToString();
                    Output.refundAmt = dr["refundAmt"].ToString();
                    Output.cancellationReason = dr["cancellationReason"].ToString();
                    Output.bookingDate = dr["bookingDate"].ToString();
                    Output.cgstTax = dr["cgstTax"].ToString();
                    Output.sgstTax = dr["sgstTax"].ToString();
                    Output.planDurationId = (int)(dr["planDuration"]);
                    Output.PlaneDuration = dr["PlaneDurationMonth"].ToString();

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
        /// this method is used to fetch UserBooking details from db
        /// </summary>
        /// <param name="Input">GetUserBooking_In class as input parameter</param>
        /// <returns>list of GetUserBooking_Out as output</returns>
        public async Task<List<GetBooking_Out>> UD_GetUserBookingAsync(GetUserBooking_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getUserBookingDetails",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType, userId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetBookingDetails", allParameters);

                List<GetBooking_Out> lstOfOutput = new List<GetBooking_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetBooking_Out Output = new GetBooking_Out();
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = dr["categoryName"].ToString();
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeName = dr["trainingTypeName"].ToString();
                    Output.traningMode = dr["traningMode"].ToString();
                    Output.slotId = (int)(dr["slotId"]);
                    Output.slotFromTime = dr["slotFromTime"].ToString();
                    Output.slotToTime = dr["slotToTime"].ToString();
                    Output.priceId = (int)(dr["priceId"]);
                    Output.phoneNumber = dr["phoneNumber"].ToString();
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
                    Output.utilizedRewardPoints = dr["utilizedRewardPoints"].ToString();
                    Output.rewardPointsAmount = dr["rewardPointsAmount"].ToString();
                    Output.totalAmount = dr["totalAmount"].ToString();
                    Output.paidAmount = dr["paidAmount"].ToString();
                    Output.paymentStatus = dr["paymentStatus"].ToString();
                    Output.paymentCycles = dr["paymentCycles"].ToString();
                    Output.paymentType = dr["paymentType"].ToString();
                    Output.cancellationStatus = dr["cancellationStatus"].ToString();
                    Output.refundStatus = dr["refundStatus"].ToString();
                    Output.cancellationCharges = dr["cancellationCharges"].ToString();
                    Output.refundAmt = dr["refundAmt"].ToString();
                    Output.cancellationReason = dr["cancellationReason"].ToString();
                    Output.bookingDate = dr["bookingDate"].ToString();
                    Output.cgstTax = dr["cgstTax"].ToString();
                    Output.sgstTax = dr["sgstTax"].ToString();
                    Output.planDurationId = (int)(dr["planDuration"]);
                    Output.PlaneDuration = dr["PlaneDurationMonth"].ToString();

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
        /// this method is used to fetch UserBooking details from db
        /// </summary>
        /// <param name="Input">GetUserBooking_In class as input parameter</param>
        /// <returns>list of GetUserBooking_Out as output</returns>
        public async Task<List<GetBooking_Out>> UD_GetUserBookinIdgAsync(GetBookingId_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getBookingDetails",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };

                SqlParameter[] allParameters = { queryType, bookingId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetBookingDetails", allParameters);

                List<GetBooking_Out> lstOfOutput = new List<GetBooking_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetBooking_Out Output = new GetBooking_Out();
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = dr["categoryName"].ToString();
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeName = dr["trainingTypeName"].ToString();
                    Output.traningMode = dr["traningMode"].ToString();
                    Output.slotId = (int)(dr["slotId"]);
                    Output.slotFromTime = dr["slotFromTime"].ToString();
                    Output.slotToTime = dr["slotToTime"].ToString();
                    Output.priceId = (int)(dr["priceId"]);
                    Output.phoneNumber = dr["phoneNumber"].ToString();
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
                    Output.utilizedRewardPoints = dr["utilizedRewardPoints"].ToString();
                    Output.rewardPointsAmount = dr["rewardPointsAmount"].ToString();
                    Output.totalAmount = dr["totalAmount"].ToString();
                    Output.paidAmount = dr["paidAmount"].ToString();
                    Output.paymentStatus = dr["paymentStatus"].ToString();
                    Output.paymentCycles = dr["paymentCycles"].ToString();
                    Output.paymentType = dr["paymentType"].ToString();
                    Output.cancellationStatus = dr["cancellationStatus"].ToString();
                    Output.refundStatus = dr["refundStatus"].ToString();
                    Output.cancellationCharges = dr["cancellationCharges"].ToString();
                    Output.refundAmt = dr["refundAmt"].ToString();
                    Output.cancellationReason = dr["cancellationReason"].ToString();
                    Output.bookingDate = dr["bookingDate"].ToString();
                    Output.cgstTax = dr["cgstTax"].ToString();
                    Output.sgstTax = dr["sgstTax"].ToString();
                    Output.planDurationId = (int)(dr["planDuration"]);
                    Output.PlaneDuration = dr["PlaneDurationMonth"].ToString();

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
        /// this method is used to fetch UserBooking details from db
        /// </summary>
        /// <param name="Input">GetUserBooking_In class as input parameter</param>
        /// <returns>list of GetUserBooking_Out as output</returns>
        public async Task<List<GetBooking_Out>> UD_GetTrackBookinIdgAsync(GetTrackingBooking_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getTrackBookingDetails",
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
                SqlParameter mobileNo = new SqlParameter
                {
                    ParameterName = "mobileNo",
                    Value = Input.mobileNo,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };

                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, mobileNo };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetBookingDetails", allParameters);

                List<GetBooking_Out> lstOfOutput = new List<GetBooking_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetBooking_Out Output = new GetBooking_Out();
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = dr["categoryName"].ToString();
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeName = dr["trainingTypeName"].ToString();
                    Output.traningMode = dr["traningMode"].ToString();
                    Output.slotId = (int)(dr["slotId"]);
                    Output.slotFromTime = dr["slotFromTime"].ToString();
                    Output.slotToTime = dr["slotToTime"].ToString();
                    Output.priceId = (int)(dr["priceId"]);
                    Output.phoneNumber = dr["phoneNumber"].ToString();
                    Output.userId = (int)(dr["userId"]);
                    Output.UserName = dr["UserName"].ToString();
                    Output.dob = dr["dob"].ToString();
                    Output.gender = dr["gender"].ToString();
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
                    Output.utilizedRewardPoints = dr["utilizedRewardPoints"].ToString();
                    Output.rewardPointsAmount = dr["rewardPointsAmount"].ToString();
                    Output.totalAmount = dr["totalAmount"].ToString();
                    Output.paidAmount = dr["paidAmount"].ToString();
                    Output.paymentStatus = dr["paymentStatus"].ToString();
                    Output.paymentCycles = dr["paymentCycles"].ToString();
                    Output.paymentType = dr["paymentType"].ToString();
                    Output.cancellationStatus = dr["cancellationStatus"].ToString();
                    Output.refundStatus = dr["refundStatus"].ToString();
                    Output.cancellationCharges = dr["cancellationCharges"].ToString();
                    Output.refundAmt = dr["refundAmt"].ToString();
                    Output.cancellationReason = dr["cancellationReason"].ToString();
                    Output.bookingDate = dr["bookingDate"].ToString();
                    Output.cgstTax = dr["cgstTax"].ToString();
                    Output.sgstTax = dr["sgstTax"].ToString();
                    Output.planDurationId = (int)(dr["planDuration"]);
                    Output.PlaneDuration = dr["PlaneDurationMonth"].ToString();

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

        public async Task<string> GetFollowupTrackingBookingAsync(GetFollowupTrackingBooking_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getFollowupBooking",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
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
                SqlParameter fromDate = new SqlParameter
                {
                    ParameterName = "fromDate",
                    Value = DateTime.Parse(Input.FromDate,objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter toDate = new SqlParameter
                {
                    ParameterName = "toDate",
                    Value = DateTime.Parse(Input.ToDate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };


                SqlParameter[] allParameters = { queryType,gymOwnerId, branchId, fromDate, toDate };


                DataTable dt = await GetDataTableFromUSPAsync("usp_GetBookingDetails", allParameters);

                return dt.Rows[0]["BookingFollowupDetails"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }



		public async Task<string> GetSlotListAsync(GetSlotListIn Input)
		{
			try
			{
				SqlParameter queryType = new SqlParameter
				{
					ParameterName = "queryType",
					Value = "getSlotList",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.VarChar,
					Size = 100
				};
				SqlParameter categoryId = new SqlParameter
				{
					ParameterName = "categoryId",
					Value = Input.categoryId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int,
				};
				SqlParameter trainingTypeId = new SqlParameter
				{
					ParameterName = "trainingTypeId",
					Value = Input.trainingTypeId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int,
				};

				SqlParameter[] allParameters = { queryType, categoryId, trainingTypeId };

				DataTable dt = await GetDataTableFromUSPAsync("usp_GetBookingDetails", allParameters);

				return dt.Rows[0]["SlotList"].ToString();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<string> GetTrainerListAsync(GetTrainerListIn Input)
		{
			try
			{
				SqlParameter queryType = new SqlParameter
				{
					ParameterName = "queryType",
					Value = "getTrainerList",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.VarChar,
					Size = 100
				};
				SqlParameter categoryId = new SqlParameter
				{
					ParameterName = "categoryId",
					Value = Input.categoryId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int,
				};
				SqlParameter trainingTypeId = new SqlParameter
				{
					ParameterName = "trainingTypeId",
					Value = Input.trainingTypeId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int,
				};
				SqlParameter slotId = new SqlParameter
				{
					ParameterName = "slotId",
					Value = Input.slotId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int,
				};

				SqlParameter[] allParameters = { queryType, categoryId, trainingTypeId , slotId };

				DataTable dt = await GetDataTableFromUSPAsync("usp_GetBookingDetails", allParameters);

				return dt.Rows[0]["TrainerList"].ToString();
			}
			catch (Exception)
			{
				throw;
			}
		}

	}
}