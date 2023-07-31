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
using static Fitness.Models.BusinessObject.WorkOutType.BOL_MstrWorkoutMealPlan;
namespace Fitness.Models.DataAccessLayer.WorkOutType
{
    public class DAL_MstrWorkoutMealPlan : SqlHelper
    {

        /// <summary>
        /// this method is used to insert details in workoutMealPlan in db
        /// </summary>
        /// <param name="Input">InsertworkoutMealPlan_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertMstrworkoutMealPlanAsync(InsertworkoutMealPlan_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter typeOfRoutine = new SqlParameter
                {
                    ParameterName = "typeOfRoutine",
                    Value = Input.typeOfRoutine,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter description = new SqlParameter
                {
                    ParameterName = "description",
                    Value = Input.description,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter specificInstruction = new SqlParameter
                {
                    ParameterName = "specificInstruction",
                    Value = Input.specificInstruction,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType,typeOfRoutine, description, specificInstruction, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrWorkoutMealPlan", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch workoutMealPlan details from db
        /// </summary>
        /// <param name="Input">GetworkoutMealPlan_In class as input parameter</param>
        /// <returns>list of GetworkoutMealPlan_Out as output</returns>
        public async Task<List<GetworkoutMealPlan_Out>> UD_GetworkoutMealPlanAsync(GetworkoutMealPlan_In Input)
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
                SqlParameter typeOfRoutine = new SqlParameter
                {
                    ParameterName = "typeOfRoutine",
                    Value = Input.typeOfRoutine,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, typeOfRoutine };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrWorkoutMealPlan", allParameters);

                List<GetworkoutMealPlan_Out> lstOfOutput = new List<GetworkoutMealPlan_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetworkoutMealPlan_Out Output = new GetworkoutMealPlan_Out();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.typeOfRoutine = dr["typeOfRoutine"].ToString();
                    Output.description = dr["description"].ToString();
                    Output.specificInstruction = dr["specificInstruction"].ToString();
                    Output.activeStatus = dr["activeStatus"].ToString();
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
        /// this method is used to update workoutMealPlan details in db
        /// </summary>
        /// <param name="Input">UpdateworkoutMealPlan_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateworkoutMealPlanAsync(UpdateworkoutMealPlan_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100

                };
                SqlParameter uniqueId = new SqlParameter
                {
                    ParameterName = "uniqueId",
                    Value = Input.uniqueId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter typeOfRoutine = new SqlParameter
                {
                    ParameterName = "typeOfRoutine",
                    Value = Input.typeOfRoutine,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter description = new SqlParameter
                {
                    ParameterName = "description",
                    Value = Input.description,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                }; 
                SqlParameter specificInstruction = new SqlParameter
                {
                    ParameterName = "specificInstruction",
                    Value = Input.specificInstruction,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, uniqueId, typeOfRoutine, description,specificInstruction, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrworkoutMealPlan", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate workoutMealPlan master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateworkoutMealPlan_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateworkoutMealPlanMstrAsyn(ActivateOrInactivateworkoutMealPlan_In Input)
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
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType, uniqueId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrworkoutMealPlan", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}