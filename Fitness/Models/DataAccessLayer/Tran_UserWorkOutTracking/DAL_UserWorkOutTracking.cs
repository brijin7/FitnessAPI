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
using static Fitness.Models.BusinessObject.Tran_UserWorkOutTracking.BOL_UserWorkOutTracking;

namespace Fitness.Models.DataAccessLayer.Tran_UserWorkOutTracking
{
    public class DAL_UserWorkOutTracking : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);

        /// <summary>
        /// used to fetch Tran_WorkoutTracking category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<List<GetTran_WorkoutTracking_Out>> UD_GetTran_WorkoutTrackingAsync(GetTran_WorkoutTracking_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetTranUserWorkOutTracking",
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetTranUserWorkOutTracking", allParameters);

                List<GetTran_WorkoutTracking_Out> lstOfOutput = new List<GetTran_WorkoutTracking_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetTran_WorkoutTracking_Out Output = new GetTran_WorkoutTracking_Out();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.userId = (int)(dr["userId"]);
                    Output.date = dr["date"].ToString();
                    Output.workoutCatTypeId = (int)(dr["workoutCatTypeId"]);
                    Output.workoutCatTypeName = dr["workoutCatTypeName"].ToString();
                    Output.workoutTypeId = (int)(dr["workoutTypeId"]);
                    Output.workoutTypeName = dr["workoutTypeName"].ToString();
                    Output.setType = (int)(dr["setType"]);
                    Output.setTypeName = dr["setTypeName"].ToString();
                    Output.noOfReps = (int)(dr["noOfReps"]);
                    Output.weight = (int)(dr["weight"]);
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
        /// used to fetch Tran_WorkoutTracking category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<List<GetTran_WorkoutTrackingBasedonDateDay_Out>> UD_GetTran_WorkoutTrackingBasedonDateDayAsync(GetTran_WorkoutTrackingBasedonDateDay_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetTranUserWorkOutTrackingBasedonDateDay",
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetTranUserWorkOutTracking", allParameters);

                List<GetTran_WorkoutTrackingBasedonDateDay_Out> lstOfOutput = new List<GetTran_WorkoutTrackingBasedonDateDay_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetTran_WorkoutTrackingBasedonDateDay_Out Output = new GetTran_WorkoutTrackingBasedonDateDay_Out();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.userId = (int)(dr["userId"]);
                    Output.date = dr["date"].ToString();
                    Output.workoutCatTypeId = (int)(dr["workoutCatTypeId"]);
                    Output.workoutCatTypeName = dr["workoutCatTypeName"].ToString();
                    Output.workoutTypeId = (int)(dr["workoutTypeId"]);
                    Output.workoutTypeName = dr["workoutTypeName"].ToString();
                    Output.setType = (int)(dr["setType"]);
                    Output.setTypeName = dr["setTypeName"].ToString();
                    Output.noOfReps = (int)(dr["noOfReps"]);
                    Output.weight = (int)(dr["weight"]);
                    Output.description = dr["description"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.video = dr["video"].ToString();
                    Output.VideoCompletedStatus = dr["VideoCompletedStatus"].ToString();
                    Output.Day = dr["Day"].ToString();
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
        /// used to fetch Tran_WorkoutTracking category 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<List<GetTran_WorkoutTrackingBasedonDateDayCategoryIdWorkoutTypeId_Out>> UD_GetTran_WorkoutTrackingBasedonDateDayCategoryIdWorkoutTypeIdAsync(GetTran_WorkoutTrackingBasedonDateDayCategoryIdWorkoutTypeId_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetTranUserWorkOutTrackingBasedonDateDayCategoryIdWorkoutTypeId",
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
                SqlParameter WorkoutCatTypeId = new SqlParameter
                {
                    ParameterName = "WorkoutCatTypeId",
                    Value = Input.WorkoutCatTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter WorkoutTypeId = new SqlParameter
                {
                    ParameterName = "WorkoutTypeId",
                    Value = Input.WorkoutTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, userId, day, Date, WorkoutCatTypeId, WorkoutTypeId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetTranUserWorkOutTracking", allParameters);

                List<GetTran_WorkoutTrackingBasedonDateDayCategoryIdWorkoutTypeId_Out> lstOfOutput = new List<GetTran_WorkoutTrackingBasedonDateDayCategoryIdWorkoutTypeId_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetTran_WorkoutTrackingBasedonDateDayCategoryIdWorkoutTypeId_Out Output = new GetTran_WorkoutTrackingBasedonDateDayCategoryIdWorkoutTypeId_Out();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.userId = (int)(dr["userId"]);
                    Output.date = dr["date"].ToString();
                    Output.workoutCatTypeId = (int)(dr["workoutCatTypeId"]);
                    Output.workoutCatTypeName = dr["workoutCatTypeName"].ToString();
                    Output.workoutTypeId = (int)(dr["workoutTypeId"]);
                    Output.workoutTypeName = dr["workoutTypeName"].ToString();
                    Output.setType = (int)(dr["setType"]);
                    Output.setTypeName = dr["setTypeName"].ToString();
                    Output.noOfReps = (int)(dr["noOfReps"]);
                    Output.weight = (int)(dr["weight"]);
                    Output.description = dr["description"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.video = dr["video"].ToString();
                    Output.VideoCompletedStatus = dr["VideoCompletedStatus"].ToString();
                    Output.Day = dr["Day"].ToString();
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
        /// this method is used to Insert WorkoutType details in db
        /// </summary>
        /// <param name="Input"> Insert WorkoutType Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertTran_WorkoutTrackingAsyc(InsertTran_WorkoutTracking_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Insert",
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
                SqlParameter date = new SqlParameter
                {
                    ParameterName = "date",
                    Value = DateTime.Parse(Input.date, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };
                SqlParameter day = new SqlParameter
                {
                    ParameterName = "day",
                    Value = Input.day,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
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

                SqlParameter setType = new SqlParameter
                {
                    ParameterName = "setType",
                    Value = Input.setType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter noOfReps = new SqlParameter
                {
                    ParameterName = "noOfReps",
                    Value = Input.noOfReps,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter weight = new SqlParameter
                {
                    ParameterName = "weight",
                    Value = Input.weight,
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
                SqlParameter[] allParameters = { queryType, bookingId, userId,
                    date,day, workoutCatTypeId, workoutTypeId, setType, noOfReps, weight, createdBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_TranUserWorkoutTracking", ListOfParameter);

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
        public async Task<DB_Response> UD_UpdateTran_WorkoutTrackingAsyc(UpdateTran_WorkoutTracking_In Input)
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
                SqlParameter uniqueId = new SqlParameter
                {
                    ParameterName = "uniqueId",
                    Value = Input.uniqueId,
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
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };              
                SqlParameter date = new SqlParameter
                {
                    ParameterName = "date",
                    Value = DateTime.Parse(Input.date, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };
                SqlParameter day = new SqlParameter
                {
                    ParameterName = "day",
                    Value = Input.day,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
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

                SqlParameter setType = new SqlParameter
                {
                    ParameterName = "setType",
                    Value = Input.setType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter noOfReps = new SqlParameter
                {
                    ParameterName = "noOfReps",
                    Value = Input.noOfReps,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter weight = new SqlParameter
                {
                    ParameterName = "weight",
                    Value = Input.weight,
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
                SqlParameter[] allParameters = { queryType, uniqueId, bookingId, userId,
                    date,day, workoutCatTypeId, workoutTypeId, setType, noOfReps, weight, updatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_TranUserWorkoutTracking", ListOfParameter);

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
        public async Task<List<GetTwodateWorkoutPlaneOutNew>> GetTwoDateUserFoodMenuAsync(GetTwodateWorkoutPlane_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getTwoDateWorkoutCalories",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter Fromdate = new SqlParameter
                {
                    ParameterName = "Fromdate",
                    Value = DateTime.Parse(Input.Fromdate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };
                SqlParameter Todate = new SqlParameter
                {
                    ParameterName = "Todate",
                    Value = DateTime.Parse(Input.Todate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };


                SqlParameter[] allParameters = { queryType, userId, Fromdate, Todate };


                DataTable dt = await GetDataTableFromUSPAsync("usp_GetDashboardDatas", allParameters);

                List<GetTwodateWorkoutPlaneOutNew> lstOfOutput = new List<GetTwodateWorkoutPlaneOutNew>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetTwodateWorkoutPlaneOutNew Output = new GetTwodateWorkoutPlaneOutNew();
                    Output.TotalActivity = (int)(dr["TotalActivity"]);
                    Output.CompletedActivity = (int)(dr["CompletedActivity"]);
                    Output.bookingId = (int)(dr["bookingId"]);
                    Output.DaysName = dr["DaysName"].ToString();
                    Output.DateOfDay = dr["DateOfDay"].ToString();
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