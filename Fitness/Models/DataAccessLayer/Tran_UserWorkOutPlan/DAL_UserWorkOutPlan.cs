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
using static Fitness.Models.BusinessObject.Tran_UserWorkOutPlan.BOL_UserWorkOutPlan;

namespace Fitness.Models.DataAccessLayer.Tran_UserWorkOutPlan
{
    public class DAL_UserWorkOutPlan : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);

        /// <summary>
        /// used to fetch Tran_WorkoutPlan category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<List<GetTran_WorkoutPlan_Out>> UD_GetTran_WorkoutPlanAsync(GetTran_WorkoutPlan_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetTranUserWorkOutPlan",
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetTranUserWorkOutPlan", allParameters);

                List<GetTran_WorkoutPlan_Out> lstOfOutput = new List<GetTran_WorkoutPlan_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetTran_WorkoutPlan_Out Output = new GetTran_WorkoutPlan_Out();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.workoutPlanId = (int)(dr["workoutPlanId"]);
                    Output.workoutCatTypeId = (int)(dr["workoutCatTypeId"]);
                    Output.workoutCatTypeName = dr["workoutCatTypeName"].ToString();
                    Output.workoutTypeId = (int)(dr["workoutTypeId"]);
                    Output.workoutTypeName = dr["workoutTypeName"].ToString();
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.day = dr["day"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.csetType = (int)(dr["csetType"]);
                    Output.setTypeName = dr["setTypeName"].ToString();
                    Output.cnoOfReps = (int)(dr["cnoOfReps"]);
                    Output.cweight = (int)(dr["cweight"]);
                    Output.userId = (int)(dr["userId"]);
                    Output.description = dr["description"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.video = dr["video"].ToString();

                    lstOfOutput.Add(Output);
                }

                return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetTran_WorkoutPlan_Out>> UD_GetTran_WorkoutPlanBasedBookingIdandDayAsync(GetTran_WorkoutPlanBasedBookingIdandDay_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetTranUserWorkOutPlanBasedOnDay",
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
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
              

                SqlParameter[] allParameters = { queryType, userId, bookingId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetTranUserWorkOutPlan", allParameters);

                List<GetTran_WorkoutPlan_Out> lstOfOutput = new List<GetTran_WorkoutPlan_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetTran_WorkoutPlan_Out Output = new GetTran_WorkoutPlan_Out();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.workoutPlanId = (int)(dr["workoutPlanId"]);
                    Output.workoutCatTypeId = (int)(dr["workoutCatTypeId"]);
                    Output.workoutCatTypeName = dr["workoutCatTypeName"].ToString();
                    Output.workoutTypeId = (int)(dr["workoutTypeId"]);
                    Output.workoutTypeName = dr["workoutTypeName"].ToString();
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.day = dr["day"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.csetType = (int)(dr["csetType"]);
                    Output.setTypeName = dr["setTypeName"].ToString();
                    Output.cnoOfReps = (int)(dr["cnoOfReps"]);
                    Output.cweight = (int)(dr["cweight"]);
                    Output.userId = (int)(dr["userId"]);
                    Output.description = dr["description"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.video = dr["video"].ToString();

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
        /// used to fetch Tran_WorkoutPlan workouttypes and details based on category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<List<GetTran_WorkoutPlan_Out>> UD_GetTran_WorkoutPlanOnCategoryAsync(GetTran_WorkoutPlanOnCategory_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetTranUserWorkOutPlanCategoryTypeDetails",
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
                SqlParameter workoutCatTypeId = new SqlParameter
                {
                    ParameterName = "workoutCatTypeId",
                    Value = Input.workoutCatTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, userId, workoutCatTypeId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetTranUserWorkOutPlan", allParameters);

                List<GetTran_WorkoutPlan_Out> lstOfOutput = new List<GetTran_WorkoutPlan_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetTran_WorkoutPlan_Out Output = new GetTran_WorkoutPlan_Out();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.workoutPlanId = (int)(dr["workoutPlanId"]);
                    Output.workoutCatTypeId = (int)(dr["workoutCatTypeId"]);
                    Output.workoutCatTypeName = dr["workoutCatTypeName"].ToString();
                    Output.workoutTypeId = (int)(dr["workoutTypeId"]);
                    Output.workoutTypeName = dr["workoutTypeName"].ToString();
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.day = dr["day"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.csetType = (int)(dr["csetType"]);
                    Output.setTypeName = dr["setTypeName"].ToString();
                    Output.cnoOfReps = (int)(dr["cnoOfReps"]);
                    Output.cweight = (int)(dr["cweight"]);
                    Output.userId = (int)(dr["userId"]);
                    Output.description = dr["description"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.video = dr["video"].ToString();

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
        /// used to fetch Tran_WorkoutPlan category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<List<GetTran_CategoryTypeBasedonDateDay_Out>> UD_GetTran_WorkoutPlanBasedonDateDayAsync(GetTran_CategoryTypeBasedonDateDay_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetCategoryTypeBasedonDateDayPublicPlan",
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
                SqlParameter day = new SqlParameter
                {
                    ParameterName = "day",
                    Value = Input.day,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter Date = new SqlParameter
                {
                    ParameterName = "Date",
                    Value = DateTime.Parse(Input.Date, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };
                SqlParameter[] allParameters = { queryType, userId, day, Date };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetTranUserWorkOutPlan", allParameters);

                List<GetTran_CategoryTypeBasedonDateDay_Out> lstOfOutput = new List<GetTran_CategoryTypeBasedonDateDay_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetTran_CategoryTypeBasedonDateDay_Out Output = new GetTran_CategoryTypeBasedonDateDay_Out();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.workoutCatTypeId = (int)(dr["workoutCatTypeId"]);
                    Output.workoutCatTypeName = dr["workoutCatTypeName"].ToString();
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.day = dr["day"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.userId = (int)(dr["userId"]);

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
        /// used to fetch Tran_WorkoutPlan category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<List<GetTran_CategoryTypeBasedonDateDayCategory_Out>> UD_GetTran_WorkoutPlanBasedonDateDayCategoryAsync
            (GetTran_CategoryTypeBasedonDateDayCategory_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetCategoryTypeBasedonDateDayPublicPlan",
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
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter day = new SqlParameter
                {
                    ParameterName = "day",
                    Value = Input.day,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter Date = new SqlParameter
                {
                    ParameterName = "Date",
                    Value = DateTime.Parse(Input.Date, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };
                SqlParameter[] allParameters = { queryType, categoryId, userId, day, Date };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetTranUserWorkOutPlan", allParameters);

                List<GetTran_CategoryTypeBasedonDateDayCategory_Out> lstOfOutput = new List<GetTran_CategoryTypeBasedonDateDayCategory_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetTran_CategoryTypeBasedonDateDayCategory_Out Output = new GetTran_CategoryTypeBasedonDateDayCategory_Out();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.workoutCatTypeId = (int)(dr["workoutCatTypeId"]);
                    Output.workoutCatTypeName = dr["workoutCatTypeName"].ToString();
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.day = dr["day"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.userId = (int)(dr["userId"]);
                    Output.VideoCount =dr["VideoCount"].ToString();

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
        /// used to fetch Tran_WorkoutPlan workouttypes and details based on category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<List<GetTran_WorkoutTypeBasedonDateDay_Out>> UD_GetTran_WorkoutPlanOnCategoryBasedonDateDayAsync(GetTran_WorkoutTypeBasedonDateDay_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetWorkoutTypeBasedonDateDay",
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
                SqlParameter workoutCatTypeId = new SqlParameter
                {
                    ParameterName = "workoutCatTypeId",
                    Value = Input.workoutCatTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter day = new SqlParameter
                {
                    ParameterName = "day",
                    Value = Input.day,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter Date = new SqlParameter
                {
                    ParameterName = "Date",
                    Value = DateTime.Parse(Input.Date, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };

                SqlParameter[] allParameters = { queryType, userId, workoutCatTypeId, day, Date };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetTranUserWorkOutPlan", allParameters);

                List<GetTran_WorkoutTypeBasedonDateDay_Out> lstOfOutput = new List<GetTran_WorkoutTypeBasedonDateDay_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetTran_WorkoutTypeBasedonDateDay_Out Output = new GetTran_WorkoutTypeBasedonDateDay_Out();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.workoutCatTypeId = (int)(dr["workoutCatTypeId"]);
                    Output.workoutCatTypeName = dr["workoutCatTypeName"].ToString();
                    Output.workoutTypeId = (int)(dr["workoutTypeId"]);
                    Output.workoutTypeName = dr["workoutTypeName"].ToString();
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.day = dr["day"].ToString();
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.userId = (int)(dr["userId"]);
                    Output.description = dr["description"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.video = dr["video"].ToString();
                    Output.UserUsed = dr["UserUsed"].ToString();
                    Output.OverAllCompletedStatus = dr["OverAllCompletedStatus"].ToString();

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
        /// used to fetch Tran_WorkoutPlan workouttypes and details based on category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<List<GetTran_SetType_Out>> UD_GetTran_SetTypeBasedonDateDayAsync(GetTran_SetTypeBasedonDateDay_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetSetTypeBasedonDateDay",
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
                SqlParameter workoutCatTypeId = new SqlParameter
                {
                    ParameterName = "workoutCatTypeId",
                    Value = Input.workoutCatTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter workoutTypeId = new SqlParameter
                {
                    ParameterName = "workoutTypeId",
                    Value = Input.workoutTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter day = new SqlParameter
                {
                    ParameterName = "day",
                    Value = Input.day,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter Date = new SqlParameter
                {
                    ParameterName = "Date",
                    Value = DateTime.Parse(Input.Date, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };

                SqlParameter[] allParameters = { queryType, userId, workoutCatTypeId, workoutTypeId, day, Date };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetTranUserWorkOutPlan", allParameters);

                List<GetTran_SetType_Out> lstOfOutput = new List<GetTran_SetType_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetTran_SetType_Out Output = new GetTran_SetType_Out();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.gymOwnerName = dr["gymOwnerName"].ToString();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.workoutCatTypeId = (int)(dr["workoutCatTypeId"]);
                    Output.workoutCatTypeName = dr["workoutCatTypeName"].ToString();
                    Output.workoutTypeId = (int)(dr["workoutTypeId"]);
                    Output.workoutTypeName = dr["workoutTypeName"].ToString();
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.fromDate = dr["fromDate"].ToString();
                    Output.toDate = dr["toDate"].ToString();
                    Output.csetType = (int)(dr["csetType"]);
                    Output.setTypeName = dr["setTypeName"].ToString();
                    Output.cnoOfReps = (int)(dr["cnoOfReps"]);
                    Output.cweight = (int)(dr["cweight"]);
                    Output.userId = (int)(dr["userId"]);
                    Output.description = dr["description"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.video = dr["video"].ToString();
                    Output.day = dr["Day"].ToString();
                    Output.VideoCompletedStatus = dr["VideoCompletedStatus"].ToString();
                    Output.OverAllCompletedStatus = dr["OverAllCompletedStatus"].ToString();

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
        /// this method is used for insert
        /// </summary>
        /// <param name="Input">InsertTranUserFoodTracking_In class as update</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertTranWorkoutPlane(InsertTranrWorkoutPlan_In Input)
        {
            try
            {
                int InsertCount = 0;
                int totalDataForInsert = Input.lstTranUserWorkoutPlan.Count;

                foreach (UserWorkoutPlan item in Input.lstTranUserWorkoutPlan)
                {
                    if (await UD_InsertTran_WorkoutPlanAsyc("Insert", item) == 1)
                    {
                        InsertCount++;
                    }
                }

                DB_Response response = new DB_Response();

                if (InsertCount == totalDataForInsert)
                {
                    response = new DB_Response()
                    {
                        StatusCode = 1,
                        Response = "Workout Plans Inserted Successfully !!!."
                    };
                }
                else
                {
                    response = new DB_Response()
                    {
                        StatusCode = 0,
                        Response = $"'{InsertCount}' Workout Plans Inserted Out Of '{totalDataForInsert}'"
                    };
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to Insert WorkoutType details in db
        /// </summary>
        /// <param name="Input"> Insert WorkoutType Master Class</param>
        /// <returns>DB_Response class as output</returns>
        private async Task<int> UD_InsertTran_WorkoutPlanAsyc(string Qtype, UserWorkoutPlan Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = Qtype,
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


                SqlParameter workoutCatTypeId = new SqlParameter
                {
                    ParameterName = "workoutCatTypeId",
                    Value = Input.workoutCatTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter workoutTypeId = new SqlParameter
                {
                    ParameterName = "workoutTypeId",
                    Value = Input.workoutTypeId,
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

                SqlParameter day = new SqlParameter
                {
                    ParameterName = "day",
                    Value = Input.day,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter fromDate = new SqlParameter
                {
                    ParameterName = "fromDate",
                    Value = DateTime.Parse(Input.fromDate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };
                SqlParameter toDate = new SqlParameter
                {
                    ParameterName = "toDate",
                    Value = DateTime.Parse(Input.toDate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };
                SqlParameter csetType = new SqlParameter
                {
                    ParameterName = "csetType",
                    Value = Input.csetType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter cnoOfReps = new SqlParameter
                {
                    ParameterName = "cnoOfReps",
                    Value = Input.cnoOfReps,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter cweight = new SqlParameter
                {
                    ParameterName = "cweight",
                    Value = Input.cweight,
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

                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, workoutCatTypeId,
                    workoutTypeId, bookingId, day, fromDate, toDate, csetType, cnoOfReps, cweight, userId, createdBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                DB_Response response = await ExecuteNonQueryAsync("usp_TranUserWorkOutPlan", ListOfParameter);
                return response.StatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to update WorkOutTypemaster details in db
        /// </summary>
        /// <param name="Input"> Update WorkOutType Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateTran_WorkoutPlanAsyc(UpdateTran_WorkoutPlan_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Update",
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
                SqlParameter workoutPlanId = new SqlParameter
                {
                    ParameterName = "workoutPlanId",
                    Value = Input.workoutPlanId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter workoutCatTypeId = new SqlParameter
                {
                    ParameterName = "workoutCatTypeId",
                    Value = Input.workoutCatTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter workoutTypeId = new SqlParameter
                {
                    ParameterName = "workoutTypeId",
                    Value = Input.workoutTypeId,
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

                SqlParameter day = new SqlParameter
                {
                    ParameterName = "day",
                    Value = Input.day,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter fromDate = new SqlParameter
                {
                    ParameterName = "fromDate",
                    Value = DateTime.Parse(Input.fromDate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };
                SqlParameter toDate = new SqlParameter
                {
                    ParameterName = "toDate",
                    Value = DateTime.Parse(Input.toDate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };
                SqlParameter csetType = new SqlParameter
                {
                    ParameterName = "csetType",
                    Value = Input.csetType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter cnoOfReps = new SqlParameter
                {
                    ParameterName = "cnoOfReps",
                    Value = Input.cnoOfReps,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter cweight = new SqlParameter
                {
                    ParameterName = "cweight",
                    Value = Input.cweight,
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
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, workoutPlanId, workoutCatTypeId,
                    workoutTypeId, bookingId, day, fromDate, toDate, csetType, cnoOfReps, cweight, userId, updatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_TranUserWorkOutPlan", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// this method is used to update Approve Status in DietPlane details in db
        /// </summary>
        /// <param name="Input"> Update Approve Status in DietPlane Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateTran_DietPlanAsyc(UpdateTran_DietPlanApproveStatus_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "UpdateApproveStatus",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
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
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter[] allParameters = { queryType, bookingId, userId, updatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_TranUserWorkOutPlan", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}