using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.FitnessCategorySlot.BOL_FitnessCategorySlot;
using Fitness.Helper;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Fitness.Models.DataAccessLayer.FitnessCategorySlot
{
    public class DAL_FitnessCategorySlot : SqlHelper
    {
        /// <summary>
        /// this method is used for insert
        /// </summary>
        /// <param name="Input">InsertFintnessCategorySlots_In class as update</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertFitnessCategorySlot(InsertFintnessCategorySlots_In Input)
        {
            try
            {
                int InsertCount = 0;
                int totalDataForInsert = Input.lstOfFintnessCategorySlots.Count;

                foreach (FintnessCategorySlots item in Input.lstOfFintnessCategorySlots)
                {
                    if (await InsertFintnessCategorySlotsAsync("Insert", item) == 1)
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
                        Response = "Fitness Category Slots Inserted Successfully !!!."
                    };
                }
                else
                {
                    response = new DB_Response()
                    {
                        StatusCode = 0,
                        Response = $"'{InsertCount}' Fitness Category Slots Inserted Out Of '{totalDataForInsert}'"
                    };
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task<int> InsertFintnessCategorySlotsAsync(string QType, FintnessCategorySlots Input)
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
                SqlParameter SlotId = new SqlParameter
                {
                    ParameterName = "SlotId",
                    Value = Input.SlotId,
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
                SqlParameter trainingMode = new SqlParameter
                {
                    ParameterName = "trainingMode",
                    Value = Input.trainingMode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };
                SqlParameter empId = new SqlParameter
                {
                    ParameterName = "empId",
                    Value = Input.empId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter fromDate = new SqlParameter
                {
                    ParameterName = "fromDate",
                    Value = Input.fromDate,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime,
                };
                SqlParameter toDate = new SqlParameter
                {
                    ParameterName = "toDate",
                    Value = Input.toDate,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.DateTime,
                };

                SqlParameter[] allParameters = { QueryType, branchId, workingDayId, gymOwnerId,SlotId,
                     categoryId, trainingTypeId,trainingMode, empId,createdBy,fromDate,toDate};

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                DB_Response response = await ExecuteNonQueryAsync("usp_MstrCategoryPriceSlots", ListOfParameter);

                return response.StatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to get fitness category slots
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<List<GetFintnessCategorySlots_Out>> GetFintnessCategorysingleSlotsAsync(GetFintnessCategorySlots_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetCategorySingleSlot",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
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
                SqlParameter trainingMode = new SqlParameter
                {
                    ParameterName = "trainingMode",
                    Value = Input.trainingMode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };


                SqlParameter[] allParameters = { QueryType, branchId,  gymOwnerId,
                    categoryId, trainingTypeId,trainingMode};


                List<GetFintnessCategorySlots_Out> listOfOut = new List<GetFintnessCategorySlots_Out>();
                DataTable dt = await GetDataTableFromUSPAsync("usp_MstrGetCategoryPriceSlots", allParameters);
                foreach (DataRow dr in dt.Rows)
                {
                    GetFintnessCategorySlots_Out output = new GetFintnessCategorySlots_Out();
                    output.gymOwnerId = (int)dr["gymOwnerId"];
                    output.branchId = (int)dr["branchId"];
                    output.categoryId = (int)dr["categoryId"];
                    output.categoryName = dr["categoryName"].ToString();
                    output.trainingTypeId = (int)dr["trainingTypeId"];
                    output.traningTypeName = dr["traningTypeName"].ToString();
                    output.trainingMode = dr["trainingMode"].ToString();
                    output.empId = (int)(dr["empId"]);
                    output.empName = dr["empName"].ToString();
                    output.fromDate = dr["fromDate"].ToString();
                    output.toDate = dr["toDate"].ToString();
                    output.slotDaydetails = GetFintnessCategorysingleSlotsListForDayAsync(Input);
                    listOfOut.Add(output);
                }

                return listOfOut;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<GetFintnessCategorySlotsDay_Out> GetFintnessCategorysingleSlotsListForDayAsync(GetFintnessCategorySlots_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetCategoryListDays",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
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
                SqlParameter trainingMode = new SqlParameter
                {
                    ParameterName = "trainingMode",
                    Value = Input.trainingMode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };


                SqlParameter[] allParameters = { QueryType, branchId,  gymOwnerId,
                    categoryId, trainingTypeId,trainingMode};


                List<GetFintnessCategorySlotsDay_Out> listOfOut = new List<GetFintnessCategorySlotsDay_Out>();
                DataTable dt = GetDataTableFromUSP("usp_MstrGetCategoryPriceSlots", allParameters);
                foreach (DataRow dr in dt.Rows)
                {
                    GetFintnessCategorySlotsDay_Out output = new GetFintnessCategorySlotsDay_Out();
                    output.workingDayId = (int)dr["workingDayId"];
                    output.workingDay = dr["workingDay"].ToString();

                    output.slotdetails = GetFintnessCategorysingleSlotsListAsync("GetCategoryListSlot", Input.gymOwnerId, Input.branchId, Input.categoryId,
                         Input.trainingTypeId, Input.trainingMode, output.workingDayId);
                    listOfOut.Add(output);
                }

                return listOfOut;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<GetFintnessCategorySlotsList_Out> GetFintnessCategorysingleSlotsListAsync(string querytypes, int gymOwnerIds, int branchIds,
                      int categoryIds, int trainingTypeIds, char trainingModes, int workingDayIds)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = querytypes,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = gymOwnerIds,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = branchIds,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = categoryIds,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter trainingTypeId = new SqlParameter
                {
                    ParameterName = "trainingTypeId",
                    Value = trainingTypeIds,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter trainingMode = new SqlParameter
                {
                    ParameterName = "trainingMode",
                    Value = trainingModes,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };
                SqlParameter workingDayId = new SqlParameter
                {
                    ParameterName = "workingDayId",
                    Value = workingDayIds,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };


                SqlParameter[] allParameters = { QueryType, branchId,  gymOwnerId,
                    categoryId, trainingTypeId,trainingMode,workingDayId};


                List<GetFintnessCategorySlotsList_Out> listOfOut = new List<GetFintnessCategorySlotsList_Out>();
                DataTable dt = GetDataTableFromUSP("usp_MstrGetCategoryPriceSlots", allParameters);
                foreach (DataRow dr in dt.Rows)
                {
                    GetFintnessCategorySlotsList_Out output = new GetFintnessCategorySlotsList_Out();
                    output.workingDayId = (int)dr["workingDayId"];
                    output.workingDay = dr["workingDay"].ToString();

                    output.slotId = (int)(dr["slotId"]);
                    output.slots = dr["slots"].ToString();
                    listOfOut.Add(output);
                }

                return listOfOut;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public async Task<List<GetFintnessCategorySingleSlots_Out>> GetFintnessCategorysingleSlotsAsync(GetFintnessCategorySlots_In Input)
        //{
        //    try
        //    {
        //        SqlParameter QueryType = new SqlParameter
        //        {
        //            ParameterName = "queryType",
        //            Value = "GetCategorySingleSlot",
        //            Direction = ParameterDirection.Input,
        //            SqlDbType = SqlDbType.VarChar,
        //            Size = 150
        //        };
        //        SqlParameter gymOwnerId = new SqlParameter
        //        {
        //            ParameterName = "gymOwnerId",
        //            Value = Input.gymOwnerId,
        //            Direction = ParameterDirection.Input,
        //            SqlDbType = SqlDbType.Int,
        //        };
        //        SqlParameter branchId = new SqlParameter
        //        {
        //            ParameterName = "branchId",
        //            Value = Input.branchId,
        //            Direction = ParameterDirection.Input,
        //            SqlDbType = SqlDbType.Int,
        //        };
        //        SqlParameter categoryId = new SqlParameter
        //        {
        //            ParameterName = "categoryId",
        //            Value = Input.categoryId,
        //            Direction = ParameterDirection.Input,
        //            SqlDbType = SqlDbType.Int,
        //        };
        //        SqlParameter trainingTypeId = new SqlParameter
        //        {
        //            ParameterName = "trainingTypeId",
        //            Value = Input.trainingTypeId,
        //            Direction = ParameterDirection.Input,
        //            SqlDbType = SqlDbType.Int,
        //        };
        //        SqlParameter trainingMode = new SqlParameter
        //        {
        //            ParameterName = "trainingMode",
        //            Value = Input.trainingMode,
        //            Direction = ParameterDirection.Input,
        //            SqlDbType = SqlDbType.Char,
        //        };


        //        SqlParameter[] allParameters = { QueryType, branchId,  gymOwnerId,
        //            categoryId, trainingTypeId,trainingMode};


        //        List<GetFintnessCategorySingleSlots_Out> listOfOut = new List<GetFintnessCategorySingleSlots_Out>();
        //        DataTable dt = await GetDataTableFromUSPAsync("usp_MstrGetCategoryPriceSlots", allParameters);
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            GetFintnessCategorySingleSlots_Out output = new GetFintnessCategorySingleSlots_Out();
        //            output.gymOwnerId = (int)dr["gymOwnerId"];
        //            output.branchId = (int)dr["branchId"];
        //            output.workingDayId = (int)dr["workingDayId"];
        //            output.workingDay = dr["workingDay"].ToString();
        //            output.categoryId = (int)dr["categoryId"];
        //            output.categoryName = dr["categoryName"].ToString();
        //            output.trainingTypeId = (int)dr["trainingTypeId"];
        //            output.traningTypeName = dr["traningTypeName"].ToString();
        //            output.empId = (int)(dr["empId"]);
        //            output.empName = dr["empName"].ToString();
        //            output.fromDate = dr["fromDate"].ToString(); 
        //            output.toDate = dr["toDate"].ToString();
        //            listOfOut.Add(output);
        //        }

        //        return listOfOut;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        /// <summary>
        /// this method is used to get fitness category slots
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<List<GetFintnessCategoryAvailableSlots_Out>> GetFintnessCategoryAvailableSlotsAsync(GetFintnessCategoryAvailableSlots_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetCategoryAvailableSlot",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
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


                SqlParameter[] allParameters = { QueryType, branchId,  gymOwnerId,
                    categoryId, trainingTypeId};


                List<GetFintnessCategoryAvailableSlots_Out> listOfOut = new List<GetFintnessCategoryAvailableSlots_Out>();
                DataTable dt = await GetDataTableFromUSPAsync("usp_MstrGetCategoryPriceSlots", allParameters);
                foreach (DataRow dr in dt.Rows)
                {
                    GetFintnessCategoryAvailableSlots_Out output = new GetFintnessCategoryAvailableSlots_Out();
                    output.gymOwnerId = (int)dr["gymOwnerId"];
                    output.branchId = (int)dr["branchId"];
                    output.categorySlotId = (int)dr["categorySlotId"];
                    output.workingDayId = (int)dr["workingDayId"];
                    output.workingDay = dr["workingDay"].ToString();
                    output.categoryId = (int)dr["categoryId"];
                    output.categoryName = dr["categoryName"].ToString();
                    output.fromTime = dr["fromTime"].ToString();
                    output.totime = dr["totime"].ToString();
                    output.slotTimeInMinutes = dr["slotTimeInMinutes"].ToString();
                    output.trainingTypeId = (int)dr["trainingTypeId"];
                    output.traningTypeName = dr["traningTypeName"].ToString();
                    output.trainingMode = dr["trainingMode"].ToString();
                    listOfOut.Add(output);
                }

                return listOfOut;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}