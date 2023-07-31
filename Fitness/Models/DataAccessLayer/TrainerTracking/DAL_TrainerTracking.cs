using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Fitness.Helper;
using Fitness.Models.CommonModels;
using static Fitness.Models.BusinessObject.TrainerTracking.BOL_TrainerTracking;
using Newtonsoft.Json.Linq;

namespace Fitness.Models.DataAccessLayer.TrainerTracking
{
    public class DAL_TrainerTracking : SqlHelper
    {
        IFormatProvider obj = new System.Globalization.CultureInfo("en-GB", true);


        public async Task<DB_Response> UpdateTrainerWorkoutAsync(UpdateTrainerWorkout_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter trainerId = new SqlParameter
                {
                    ParameterName = "trainerId",
                    Value = Input.trainerId,
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
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter starttime = new SqlParameter
                {
                    ParameterName = "starttime",
                    Value = DateTime.Parse(Input.starttime, obj),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime,
                };
                SqlParameter endtime = new SqlParameter
                {
                    ParameterName = "endtime",
                    Value = DateTime.Parse(Input.endtime, obj),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime,
                };

                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, trainerId,slotId,
                     categoryId, starttime,endtime, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_TrainerWorkoutTracking", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<string> GetTrainerWorkoutOverallAsync(GetTrainerWorkOutOverall_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetTrainerOverAll",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                };
                SqlParameter trainerId = new SqlParameter
                {
                    ParameterName = "trainerId",
                    Value = Input.trainerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter date = new SqlParameter
                {
                    ParameterName = "date",
                    Value = DateTime.Parse(Input.date, obj),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };

                SqlParameter[] allParameters = { queryType, trainerId, date };


                DataTable dt = await GetDataTableFromUSPAsync("usp_GetTrainerWorkoutTraking", allParameters);

                return dt.Rows[0]["TrainerDetails"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GetTrainerWorkoutListAsync(GetTrainerWorkOutList_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetTrainerWorkOutList",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                };
                SqlParameter trainerId = new SqlParameter
                {
                    ParameterName = "trainerId",
                    Value = Input.trainerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter date = new SqlParameter
                {
                    ParameterName = "date",
                    Value = DateTime.Parse(Input.date, obj),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };

                SqlParameter[] allParameters = { queryType, trainerId,date };


                DataTable dt = await GetDataTableFromUSPAsync("usp_GetTrainerWorkoutTraking", allParameters);

                return dt.Rows[0]["TrainerDetails"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<JArray> GetTrainerslotcompletedAsync(GetTrainerslotcompletedList_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetTrainercompletedstatus",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                };
                SqlParameter trainerId = new SqlParameter
                {
                    ParameterName = "trainerId",
                    Value = Input.trainerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter date = new SqlParameter
                {
                    ParameterName = "date",
                    Value = DateTime.Parse(Input.date, obj),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter slotId = new SqlParameter
                {
                    ParameterName = "slotId",
                    Value = Input.slotId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType, trainerId, date, slotId };


                //DataTable dt = await GetDataTableFromUSPAsync("usp_GetTrainerWorkoutTraking", allParameters);

                //return dt.Rows[0]["TrainerDetails"].ToString();
                return await GetResultFromGetDataTableFromUSPAsync("usp_GetTrainerWorkoutTraking", allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}