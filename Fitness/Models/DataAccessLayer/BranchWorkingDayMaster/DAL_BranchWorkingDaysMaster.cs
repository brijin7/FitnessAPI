using Fitness.Helper;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.BranchWorkingDayMaster.BOL_BranchWorkingDays;
using System.Web.Configuration;

namespace Fitness.Models.DataAccessLayer.BranchWorkingDayMaster
{
    public class DAL_BranchWorkingDaysMaster : SqlHelper
    {
        /// <summary>
        /// this method is used for insert
        /// </summary>
        /// <param name="Input">InsertBranchWorkingDays_In class as input</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertBranchWorkingDays(InsertBranchWorkingDays_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter InsertBranchWrokingDays = new SqlParameter
                {
                    ParameterName = "InsertBranchWrokingDays",
                    Value = ToDataTable(Input.LstOfbranchWorkingDays),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Structured,
                };

                SqlParameter[] allParameters = { QueryType, InsertBranchWrokingDays };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrBranchWorkingDays", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used for update
        /// </summary>
        /// <param name="Input">InsertBranchWorkingDays_In class as update</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_UpdateBranchWorkingDays(UpdateBranchWorkingDays_In Input)
        {
            try
            {
                int updatedCount = 0;
                int totalDataForUpdation = Input.LstOfbranchWorkingDays.Count;

                foreach (BranchWorkingDays_Update item in Input.LstOfbranchWorkingDays)
                {
                    if (await UpdateBranchWorkingDays("Update", item) == 1)
                    {
                        updatedCount++;
                    }
                }

                DB_Response response = new DB_Response();

                if (updatedCount == totalDataForUpdation)
                {
                    response = new DB_Response()
                    {
                        StatusCode = 1,
                        Response = "BranchWorkingDays Updated Successfully !!!."
                    };
                }
                else
                {
                    response = new DB_Response()
                    {
                        StatusCode = 0,
                        Response = $"{updatedCount} BranchWorkingDays Updated Out Of {totalDataForUpdation}"
                    };
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<int> UpdateBranchWorkingDays(string QType, BranchWorkingDays_Update Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = QType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };

                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter workingDayId = new SqlParameter
                {
                    ParameterName = "workingDayId",
                    Value = Input.workingDayId,
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
                SqlParameter isHoliday = new SqlParameter
                {
                    ParameterName = "isHoliday",
                    Value = Input.isHoliday,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, branchId, workingDayId, gymOwnerId, isHoliday ,updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                DB_Response rsponse = await ExecuteNonQueryAsync("usp_MstrBranchWorkingDays", ListOfParameter);
                return rsponse.StatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to get workinghdays
        /// </summary>
        /// <param name="Input">GetBranchWorkingDays_In class as input</param>
        /// <returns>GetBranchWorkingDays_Out class</returns>
        public async Task<List<GetBranchWorkingDays_Out>> UD_getBranchWorkingDays(GetBranchWorkingDays_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetBranchWorkingDays",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };

                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, branchId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetBranchWorkingDays", allParameters);

                List<GetBranchWorkingDays_Out> outList = new List<GetBranchWorkingDays_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetBranchWorkingDays_Out output = new GetBranchWorkingDays_Out();
                    output.branchId = (int)dr["branchId"];
                    output.branchName = dr["branchName"].ToString();
                    output.workingDayId = (int)dr["workingDayId"];
                    output.fromTime = (TimeSpan)dr["fromTime"];
                    output.toTime = (TimeSpan)dr["toTime"];
                    output.gymOwnerId = (int)dr["gymOwnerId"];
                    output.gymOwnerName = dr["gymOwnerName"].ToString();
                    output.workingDay = dr["workingDay"].ToString();
                    output.branchId = (int)dr["branchId"];
                    output.isHoliday = (string)dr["isHoliday"];
                    outList.Add(output);
                }

                return outList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to get workinghdays
        /// </summary>
        /// <param name="Input">GetBranchWorkingDaysForSlot_In class as input</param>
        /// <returns>GetBranchWorkingDaysForSlot_Out class</returns>
        public async Task<List<GetBranchWorkingDaysForSlot_Out>> UD_GetBranchWorkingDaysForSlot(GetBranchWorkingDaysForSlot_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetBranchWorkingDaysForSlot",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };

                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, branchId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetBranchWorkingDays", allParameters);

                List<GetBranchWorkingDaysForSlot_Out> outList = new List<GetBranchWorkingDaysForSlot_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetBranchWorkingDaysForSlot_Out output = new GetBranchWorkingDaysForSlot_Out();
                    output.workingDayId = (int)dr["workingDayId"];
                    output.workingDay = dr["workingDay"].ToString(); 
                    outList.Add(output);
                }

                return outList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}