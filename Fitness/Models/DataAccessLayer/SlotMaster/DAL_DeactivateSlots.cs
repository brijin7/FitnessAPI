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
using Newtonsoft.Json.Linq;
using static Fitness.Models.BusinessObject.SlotMaster.BOL_DeactivateSlots;
using static Fitness.Models.BusinessObject.CategoryMaster.BOL_MstrCategory;

namespace Fitness.Models.DataAccessLayer.SlotMaster
{
    public class DAL_DeactivateSlots : SqlHelper
    {
        /// <summary>
        /// this method is used to fetch SlotMaster details from db
        /// </summary>
        /// <param name="Input">GetSlotMaster_In class as input parameter</param>
        /// <returns>list of GetSlotMaster_Out as output</returns>
        public async Task<JArray> UD_GetSlotMasterAsync(GetDeactivatedSlotMaster_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getDaybasedDeactivatedSlots",
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

                return await GetResultFromGetDataTableFromUSPAsync("usp_GetMstrDayBasedDeacivatedSlots", allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to insert details in SlotMaster in db
        /// </summary>
        /// <param name="Input">InsertSlotMaster_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertSlotMasterAsync(InsertDeactivatedSlotMaster_In Input)
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
                SqlParameter slotId = new SqlParameter
                {
                    ParameterName = "slotId",
                    Value = Input.slotId,
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
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, gymOwnerId, branchId, slotId, workingDayId, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_DaybasedSlotMaster", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate category master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateCategoryMstr_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateDeactivatedSlotMasterMstrAsyn(ActivateOrInactivateDeactivatedSlotMaster_In Input)
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

                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter uniqueId = new SqlParameter
                {
                    ParameterName = "uniqueId",
                    Value = Input.uniqueId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType, updatedBy, uniqueId };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_DaybasedSlotMaster", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}