using Fitness.Helper;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.BranchWorkingSlots.BOL_mstrBranchWorkingSlots;
using static Fitness.Models.BusinessObject.AppSetting.BOL_mstrAppSettings;

namespace Fitness.Models.DataAccessLayer.BranchWorkingSlots
{
    public class DAL_MstrBranchWorkingSlots : SqlHelper
    {

        /// <summary>
        /// this method is used to get BranchworkingDaysForSlots
        /// </summary>
        /// <param name="Input">GetBranchworkingDaysForSlots_In as inpt parameter</param>
        /// <returns></returns>
        public async Task<List<GetBranchworkingDaysForSlots_Out>> UD_GetBranchworkingDaysForSlots(GetBranchworkingDaysForSlots_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetBranchworkingDaysForSlots",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
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


                SqlParameter[] allParameters = { QueryType, branchId, gymOwnerId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrBranchWorkingSlot", allParameters);

                List<GetBranchworkingDaysForSlots_Out> listOfOut = new List<GetBranchworkingDaysForSlots_Out>();

                foreach (DataRow dr in dt.Rows)
                {
                    GetBranchworkingDaysForSlots_Out output = new GetBranchworkingDaysForSlots_Out();

                    output.branchId = (int)dr["branchId"];
                    output.workingDayId = (int)dr["workingDayId"];
                    output.gymOwnerId = (int)dr["gymOwnerId"];
                    output.workingDay = dr["workingDay"].ToString();

                    listOfOut.Add(output);
                }

                return listOfOut;
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// this method is GetBranchworkingDaysForSlots
        /// </summary>
        /// <param name="Input">GetBranchWorkingSlots_In class as input</param>
        /// <returns></returns>
        public async Task<List<GetBranchWorkingSlots_Out>> UD_GetBranchSlots(GetBranchWorkingSlots_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = Input.queryType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter workingDayId = new SqlParameter
                {
                    ParameterName = "workingDayId",
                    Value = Input.workingDayId,
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

                SqlParameter[] allParameters = { QueryType, branchId, workingDayId, gymOwnerId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrBranchWorkingSlot", allParameters);

                List<GetBranchWorkingSlots_Out> listOfOut = new List<GetBranchWorkingSlots_Out>();

                foreach (DataRow dr in dt.Rows)
                {
                    GetBranchWorkingSlots_Out output = new GetBranchWorkingSlots_Out();

                    output.branchId = (int)dr["branchId"];
                    output.slotId = (int)dr["slotId"];
                    output.workingDayId = (int)dr["workingDayId"];
                    output.gymOwnerId = (int)dr["gymOwnerId"];
                    output.workingDay = dr["workingDay"].ToString();
                    output.fromTime = dr["fromTime"].ToString();
                    output.toTime = dr["toTime"].ToString();
                    output.slotTimeInMinutes = (int)dr["slotTimeInMinutes"];

                    listOfOut.Add(output);
                }

                return listOfOut;
            }
            catch (Exception) { throw; }
        }
        /// <summary>
        /// this method is used to insert branch working slots
        /// </summary>
        /// <param name="Input">InsertBranchWorkingSlots_In as input</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_insertBranchWorkingSlots(InsertBranchWorkingSlots_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter InsertMstrBranchWorkingSlot = new SqlParameter
                {
                    ParameterName = "InsertMstrBranchWorkingSlot",
                    Value = ToDataTable(Input.LstOfbranchWorkingSlots),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Structured,
                };

                SqlParameter[] allParameters = { QueryType, InsertMstrBranchWorkingSlot };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrBranchWorkingSlot", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to insert branch working slots
        /// </summary>
        /// <param name="Input">InsertBranchWorkingSlots_In as input</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_SingleinsertBranchWorkingSlots(singleInsertBranchWorkingSlots_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "singleInsert",
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
                SqlParameter workingDayId = new SqlParameter
                {
                    ParameterName = "workingDayId",
                    Value = Input.workingDayId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter fromTime = new SqlParameter
                {
                    ParameterName = "fromTime",
                    Value = Input.fromTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter toTime = new SqlParameter
                {
                    ParameterName = "toTime",
                    Value = Input.toTime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };

                SqlParameter[] allParameters = { QueryType,gymOwnerId,branchId,workingDayId,fromTime,toTime,createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrBranchWorkingSlot", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to delete Branch Working Slots
        /// </summary>
        /// <param name="Input">DeleteBranchWorkingSlots_In class as input</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_DeleteFromBranchWorkingSlots(DeleteBranchWorkingSlots_In Input)
        {
            try
            {
                try
                {
                    SqlParameter QueryType = new SqlParameter
                    {
                        ParameterName = "queryType",
                        Value = "inActive",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 150
                    };
                    SqlParameter branchId = new SqlParameter
                    {
                        ParameterName = "branchId",
                        Value = Input.branchId,
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int
                    };
                    SqlParameter workingDayId = new SqlParameter
                    {
                        ParameterName = "workingDayId",
                        Value = Input.workingDayId,
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

                    SqlParameter[] allParameters = { QueryType, branchId, workingDayId, gymOwnerId };

                    List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                    ListOfParameter.AddRange(allParameters);

                    return await ExecuteNonQueryAsync("usp_MstrBranchWorkingSlot", ListOfParameter);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}