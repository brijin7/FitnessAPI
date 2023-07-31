using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.UserWorkOutPlanandDietPlan.BOL_UserWorkOutPlanandDietPlan;
using Fitness.Helper;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Fitness.Models.DataAccessLayer.UserWorkOutPlanandDietPlan
{
    public class DAL_UserWorkOutPlanandDietPlan : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);
        /// <summary>
        /// this method is used to fetch UserBooking details from db
        /// </summary>
        /// <param name="Input">GetUserBooking_In class as input parameter</param>
        /// <returns>list of GetUserBooking_Out as output</returns>
        public async Task<List<GetUserBookingDetailsDept_Out>> UD_GetUserWorkOutPlanandDietPlangAsync(GetUserBookingDetailsDept_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetUserBookingDetails",
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
                    Size = 100
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };

                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetUserBookingDetailsDept", allParameters);

                List<GetUserBookingDetailsDept_Out> lstOfOutput = new List<GetUserBookingDetailsDept_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetUserBookingDetailsDept_Out Output = new GetUserBookingDetailsDept_Out();
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.userId = (int)(dr["userId"]);
                    Output.userName = dr["userName"].ToString();
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = dr["categoryName"].ToString();
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeName = dr["trainingTypeName"].ToString();
                    Output.planDuration = (int)(dr["planDuration"]);
                    Output.planDurationName = dr["planDurationName"].ToString();
                    Output.phoneNumber = dr["phoneNumber"].ToString();
                    Output.mailId = dr["mailId"].ToString();
                    Output.TDEE = dr["TDEE"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.approvedStatus = dr["approvedStatus"].ToString();
                    Output.PlanGeneareted = dr["PlanGeneareted"].ToString();
                    Output.PlanGenearetedDiet = dr["PlanGenearetedDiet"].ToString();
                    Output.paymentStatus = dr["paymentStatus"].ToString();
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
        public async Task<List<GetUserBookingDetailsDept_Out>> UD_GetUserBookingDetailsBasedOnTypeAsync(GetUserBookingDetailsBasedOnType_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetUserBookingDetailsBasedOnType",
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
                    Size = 100
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };
                SqlParameter Date = new SqlParameter
                {
                    ParameterName = "Date",
                    Value = DateTime.Parse(Input.date, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };
                SqlParameter Type = new SqlParameter
                {
                    ParameterName = "Type",
                    Value = Input.type,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 3
                };

                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId , Date, Type };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetUserBookingDetailsDept", allParameters);

                List<GetUserBookingDetailsDept_Out> lstOfOutput = new List<GetUserBookingDetailsDept_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetUserBookingDetailsDept_Out Output = new GetUserBookingDetailsDept_Out();
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.userId = (int)(dr["userId"]);
                    Output.userName = dr["userName"].ToString();
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = dr["categoryName"].ToString();
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeName = dr["trainingTypeName"].ToString();
                    Output.planDuration = (int)(dr["planDuration"]);
                    Output.planDurationName = dr["planDurationName"].ToString();
                    Output.phoneNumber = dr["phoneNumber"].ToString();
                    Output.mailId = dr["mailId"].ToString();
                    Output.TDEE = dr["TDEE"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.approvedStatus = dr["approvedStatus"].ToString();
                    Output.PlanGeneareted = dr["PlanGeneareted"].ToString();
                    Output.PlanGenearetedDiet = dr["PlanGenearetedDiet"].ToString();
                    Output.paymentStatus = dr["paymentStatus"].ToString();
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
        /// Added by Imran - 18-05-2023
        /// </summary>
        /// <param name="Input">GetUserBooking_In class as input parameter</param>
        /// <returns>list of GetUserBooking_Out as output</returns>
        public async Task<List<GetUserBookingDetailsUser_Out>> UD_GetUserBookingDetailsBasedOnUserIdAsync(GetUserBookingDetailsBasedOnUserId_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetUserBookingDetailsBasedOnUserId",
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetUserBookingDetailsDept", allParameters);

                List<GetUserBookingDetailsUser_Out> lstOfOutput = new List<GetUserBookingDetailsUser_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetUserBookingDetailsUser_Out Output = new GetUserBookingDetailsUser_Out();
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.userId = (int)(dr["userId"]);
                    Output.userName = dr["userName"].ToString();
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = dr["categoryName"].ToString();
                    Output.trainingTypeId = (int)(dr["trainingTypeId"]);
                    Output.trainingTypeName = dr["trainingTypeName"].ToString();
                    Output.planDuration = (int)(dr["planDuration"]);
                    Output.planDurationName = dr["planDurationName"].ToString();
                    Output.phoneNumber = dr["phoneNumber"].ToString();
                    Output.mailId = dr["mailId"].ToString();
                    Output.TDEE = dr["TDEE"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.approvedStatus = dr["approvedStatus"].ToString();
                    Output.PlanGeneareted = dr["PlanGeneareted"].ToString();
                    Output.PlanGenearetedDiet = dr["PlanGenearetedDiet"].ToString();
                    Output.paymentStatus = dr["paymentStatus"].ToString();
                    Output.slotId = (int)(dr["slotId"]);
                    Output.trainerId = (int)(dr["trainerId"]);
                    Output.SlotTime = dr["SlotTime"].ToString();
                    Output.TrainerName = dr["TrainerName"].ToString();
                    Output.traningMode = dr["traningMode"].ToString();
                    Output.TrainermobileNo = dr["mobileNo"].ToString();
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
        public async Task<List<GetFoodItemBasedOnMealType_Out>> UD_GetFoodItemBasedOnMealTypeAsync(GetFoodItemBasedOnMealType_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetFoodItemBasedOnMealType",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter mealType = new SqlParameter
                {
                    ParameterName = "mealType",
                    Value = Input.mealType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter dietTypeId = new SqlParameter
                {
                    ParameterName = "dietTypeId",
                    Value = Input.dietTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter uniqueId = new SqlParameter
                {
                    ParameterName = "uniqueId",
                    Value = Input.uniqueId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };

                SqlParameter[] allParameters = { queryType, mealType, dietTypeId, userId, bookingId,uniqueId , gymOwnerId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetUserBookingDetailsDept", allParameters);

                List<GetFoodItemBasedOnMealType_Out> lstOfOutput = new List<GetFoodItemBasedOnMealType_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetFoodItemBasedOnMealType_Out Output = new GetFoodItemBasedOnMealType_Out();
                    Output.foodItemId = (int)(dr["foodItemId"]);
                    Output.dietTimeId = (int)(dr["dietTimeId"]);
                    Output.foodItemName = dr["foodItemName"].ToString();
                    Output.servingIn = dr["servingIn"].ToString();
                    Output.calories = dr["calories"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
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