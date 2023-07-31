using Fitness.Helper;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Fitness.App_Start;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.TrainerUserTracking.BOL_TrainerUserTracking;
using Newtonsoft.Json.Linq;

namespace Fitness.Models.DataAccessLayer.TrainerUserTracking
{
	public class DAL_TrainerUserTracking : SqlHelper
	{
		IFormatProvider obj = new System.Globalization.CultureInfo("en-GB", true);
		public async Task<string> GetTrainerSlotAsync(GetTrainerSlot_In Input)
		{
			try
			{
				SqlParameter queryType = new SqlParameter
				{
					ParameterName = "queryType",
					Value = "GetTrainerSlot",
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

				SqlParameter[] allParameters = { queryType, trainerId };


				DataTable dt = await GetDataTableFromUSPAsync("usp_GetTrainerUserTraking", allParameters);

				return dt.Rows[0]["TrainerSlot"].ToString();
			}
			catch (Exception)
			{
				throw;
			}

		}
		public async Task<JArray> GetUserListAsync(GetUserList_In Input)
		{
			try
			{
				SqlParameter queryType = new SqlParameter
				{
					ParameterName = "queryType",
					Value = "GetUserList",
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

				SqlParameter slotId = new SqlParameter
				{
					ParameterName = "slotId",
					Value = Input.slotId,
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

                SqlParameter[] allParameters = { queryType, trainerId ,slotId, date };


                //DataTable dt = await GetDataTableFromUSPAsync("usp_GetTrainerUserTraking", allParameters);

                //return dt.Rows[0]["UserList"].ToString();

                return await GetResultFromGetDataTableFromUSPAsync("usp_GetTrainerUserTraking", allParameters);
            }
			catch (Exception)
			{
				throw;
			}
		}
		public async Task<string> GetUserWorkOurListAsync(GetUserWorkOutList_In Input)
		{
			try
			{
				SqlParameter queryType = new SqlParameter
				{
					ParameterName = "queryType",
					Value = "GetUserWorkOutList",
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

				SqlParameter slotId = new SqlParameter
				{
					ParameterName = "slotId",
					Value = Input.slotId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int,
				};
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
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
				SqlParameter day = new SqlParameter
				{
					ParameterName = "day",
					Value = Input.day,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
				};

				SqlParameter[] allParameters = { queryType, trainerId, slotId ,date,day, userId };


				DataTable dt = await GetDataTableFromUSPAsync("usp_GetTrainerUserTraking", allParameters);

				return dt.Rows[0]["UserList"].ToString();
			}
			catch (Exception)
			{
				throw;
			}
		}

        public async Task<string> GetUserOverallattendanceAsync(GetOverAllAttendance_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetOverAllAttendance",
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

                SqlParameter[] allParameters = { queryType, trainerId ,date, slotId };


                DataTable dt = await GetDataTableFromUSPAsync("usp_GetTrainerUserTraking", allParameters);

                return dt.Rows[0]["OverAll"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}