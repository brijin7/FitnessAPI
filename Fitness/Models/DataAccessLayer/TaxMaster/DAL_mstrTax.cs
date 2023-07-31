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
using static Fitness.Models.BusinessObject.TaxMaster.BOL_mstrTax;

namespace Fitness.Models.DataAccessLayer.TaxMaster
{
    public class DAL_mstrTax : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);
        /// <summary>
        /// this method is used to fetch Taxmaster details from db
        /// </summary>
        /// <param name="Input">GetmstrTax_In class as input parameter</param>
        /// <returns>list of GetmstrTax_Out as output</returns>
        public async Task<List<GetmstrTax_Out>> UD_GetMstrWorkoutTypeAsync(GetmstrTax_In Input)
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
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrTax", allParameters);

                List<GetmstrTax_Out> lstOfOutput = new List<GetmstrTax_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetmstrTax_Out Output = new GetmstrTax_Out();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.taxId = (int)(dr["taxId"]);
                    Output.serviceId = (dr["serviceId"].ToString());
                    Output.serviceName = dr["serviceName"].ToString();
                    Output.taxDescription = dr["taxDescription"].ToString();
                    Output.taxPercentage = dr["taxPercentage"].ToString();
                    Output.effectiveFrom = dr["effectiveFrom"].ToString();
                    Output.effectiveTill = dr["effectiveTill"].ToString();
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
        /// this method is used to fetch ddlTaxmaster details from db
        /// </summary>
        /// <param name="Input">GetddlmstrTax_In class as input parameter</param>
        /// <returns>list of GetddlmstrTax_Out as output</returns>
        public async Task<List<GetddlmstrTax_Out>> UD_GetddlMstrTaxAsync(GetddlmstrTax_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "ddlgetTax",
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
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrTax", allParameters);

                List<GetddlmstrTax_Out> lstOfOutput = new List<GetddlmstrTax_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetddlmstrTax_Out Output = new GetddlmstrTax_Out();
                    Output.taxId = (int)(dr["taxId"]);
                    Output.taxDetails = dr["taxDetails"].ToString();
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
        /// this method is used to Insert Tax details in db
        /// </summary>
        /// <param name="Input"> Insert Tax Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_AddmstrTaxAsyc(AddmstrTax_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "add",
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

                SqlParameter serviceName = new SqlParameter
                {
                    ParameterName = "serviceName",
                    Value = Input.serviceName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter taxDescription = new SqlParameter
                {
                    ParameterName = "taxDescription",
                    Value = Input.taxDescription,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter taxPercentage = new SqlParameter
                {
                    ParameterName = "taxPercentage",
                    Value = Input.taxPercentage,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter effectiveFrom = new SqlParameter
                {
                    ParameterName = "effectiveFrom",
                    Value = DateTime.Parse(Input.effectiveFrom, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };

                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId
                    , serviceName, taxDescription, taxPercentage, effectiveFrom, createdBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrTax", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to Insert Tax details in db
        /// </summary>
        /// <param name="Input"> Insert Tax Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertmstrTaxAsyc(InsertmstrTax_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "insert",
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

                SqlParameter serviceName = new SqlParameter
                {
                    ParameterName = "serviceName",
                    Value = Input.serviceName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };

                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId
                    , serviceName, updatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrTax", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to Update Tax details in db
        /// </summary>
        /// <param name="Input"> Update Tax Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdatemstrTaxAsyc(UpdatemstrTax_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "update",
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
                SqlParameter uniqueId = new SqlParameter
                {
                    ParameterName = "uniqueId",
                    Value = Input.uniqueId,
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

                SqlParameter serviceName = new SqlParameter
                {
                    ParameterName = "serviceName",
                    Value = Input.serviceName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter taxDescription = new SqlParameter
                {
                    ParameterName = "taxDescription",
                    Value = Input.taxDescription,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 150
                };
                SqlParameter taxPercentage = new SqlParameter
                {
                    ParameterName = "taxPercentage",
                    Value = Input.taxPercentage,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter effectiveFrom = new SqlParameter
                {
                    ParameterName = "effectiveFrom",
                    Value = DateTime.Parse(Input.effectiveFrom, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId,taxDescription,taxPercentage,
                   effectiveFrom , serviceName ,uniqueId};
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrTax", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to Delete Tax details in db
        /// </summary>
        /// <param name="Input"> Delete Tax Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_DeletemstrTaxAsyc(DeletemstrTax_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "delete",
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

                SqlParameter[] allParameters = { queryType, uniqueId };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrTax", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to Insert Tax details in db
        /// </summary>
        /// <param name="Input"> Insert Tax Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateTaxIdAsyc(InsertmstrTax_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "UpdateTaxId",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };

                SqlParameter[] allParameters = { queryType };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_UpdateTaxId", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}