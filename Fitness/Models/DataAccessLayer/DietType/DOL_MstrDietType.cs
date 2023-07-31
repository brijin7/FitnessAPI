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
using static Fitness.Models.BusinessObject.DietType.BOL_MstrDietType;

namespace Fitness.Models.DataAccessLayer.DietType
{
    public class DAL_MstrDietType : SqlHelper
    {

        /// <summary>
        /// this method is used to insert details in DeietType in db
        /// </summary>
        /// <param name="Input">InsertDietType_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertMstrDietTypeAsync(InsertDietType_In Input)
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
                SqlParameter dietTypeNameId = new SqlParameter
                {
                    ParameterName = "dietTypeNameId",
                    Value = Input.dietTypeNameId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 150
                };
                SqlParameter description = new SqlParameter
                {
                    ParameterName = "description",
                    Value = Input.description,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter imageUrl = new SqlParameter
                {
                    ParameterName = "imageUrl",
                    Value = Input.imageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter typeIndicationImageUrl = new SqlParameter
                {
                    ParameterName = "typeIndicationImageUrl",
                    Value = Input.typeIndicationImageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };

                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType, dietTypeNameId,description, imageUrl,typeIndicationImageUrl ,
                        createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrDietType", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch DietType details from db
        /// </summary>
        /// <param name="Input">GetDietType_In class as input parameter</param>
        /// <returns>list of GetDietType_Out as output</returns>
        public async Task<List<GetDietType_Out>> UD_GetDietTypeMstrAsync()
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getDietType",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrDietType", allParameters);

                List<GetDietType_Out> lstOfOutput = new List<GetDietType_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetDietType_Out Output = new GetDietType_Out();
                    Output.dietTypeId = (int)(dr["dietTypeId"]);
                    Output.dietTypeNameId = (int)(dr["dietTypeNameId"]);
                    Output.dietTypeName = dr["dietTypeName"].ToString();
                    Output.description = dr["description"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.typeIndicationImageUrl = dr["typeIndicationImageUrl"].ToString();
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

        public async Task<List<GetddlDietType_Out>> UD_GetddlDietTypeMstrAsync()
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getddlDietType",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrDietType", allParameters);

                List<GetddlDietType_Out> lstOfOutput = new List<GetddlDietType_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetddlDietType_Out Output = new GetddlDietType_Out();
                    Output.dietTypeId = (int)(dr["dietTypeId"]);
                    Output.dietTypeName = dr["dietTypeName"].ToString();
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
        /// this method is used to update DietType details in db
        /// </summary>
        /// <param name="Input">UpdateDietType_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateDietTypeMstrAsync(UpdateDietType_In Input)
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
                SqlParameter dietTypeId = new SqlParameter
                {
                    ParameterName = "dietTypeId",
                    Value = Input.dietTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter dietTypeNameId = new SqlParameter
                {
                    ParameterName = "dietTypeNameId",
                    Value = Input.dietTypeNameId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 50
                };
                SqlParameter description = new SqlParameter
                {
                    ParameterName = "description",
                    Value = Input.description,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter imageUrl = new SqlParameter
                {
                    ParameterName = "imageUrl",
                    Value = Input.imageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter typeIndicationImageUrl = new SqlParameter
                {
                    ParameterName = "typeIndicationImageUrl",
                    Value = Input.typeIndicationImageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter[] allParameters = { queryType, dietTypeId, dietTypeNameId, description, imageUrl, typeIndicationImageUrl, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrDietType", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate DietType master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateDietType_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateDietTypeMstrAsyn(ActivateOrInactivateDietType_In Input)
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
                SqlParameter dietTypeId = new SqlParameter
                {
                    ParameterName = "dietTypeId",
                    Value = Input.dietTypeId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType, dietTypeId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrDietType", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}