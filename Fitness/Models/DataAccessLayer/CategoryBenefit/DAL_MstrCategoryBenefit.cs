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
using static Fitness.Models.BusinessObject.CategoryBenefit.BOL_MstrCategoryBenefit;

namespace Fitness.Models.DataAccessLayer.CategoryBenefit
{
    public class DAL_MstrCategoryBenefit : SqlHelper
    {
        /// <summary>
        /// this method is used to insert details in CategoryBenefitmstr in db
        /// </summary>
        /// <param name="Input">InsertCategoryBenefit_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertCategoryBenefitMasterAsync(InsertCategoryBenefit_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "QueryType",
                    Value = "Insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter type = new SqlParameter
                {
                    ParameterName = "type",
                    Value = Input.type,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
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
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, categoryId, type, description, imageUrl, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrCategoryBenefit", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch CategoryBenefitmstr details from db
        /// </summary>
        /// <param name="Input">GetCategoryBenefitMstr_In class as input parameter</param>
        /// <returns>list of GetCategoryBenefitMstr_Out as output</returns>
        public async Task<List<GetCategoryBenefitMstr_Out>> UD_GetCategoryBenefitMstrAsync(GetCategoryBenefitMstr_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getCategoryBenefit",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter CategoryId = new SqlParameter
                {
                    ParameterName = "CategoryId",
                    Value = Input.CategoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType, CategoryId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrCategoryBenefit", allParameters);

                List<GetCategoryBenefitMstr_Out> lstOfOutput = new List<GetCategoryBenefitMstr_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetCategoryBenefitMstr_Out Output = new GetCategoryBenefitMstr_Out();
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = dr["categoryName"].ToString();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.type = (int)(dr["type"]);
                    Output.BenefitName = dr["configName"].ToString();
                    Output.description = dr["description"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
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
        /// this method is used to fetch CategoryBenefitmstr details from db
        /// </summary>
        /// <param name="Input">GetCategoryBenefitMstr_In class as input parameter</param>
        /// <returns>list of GetCategoryBenefitMstr_Out as output</returns>
        public async Task<List<GetCategoryBenefitMstr_Out>> UD_ddlCategoryBenefitMstrAsync(ddlCategoryBenefitMstr_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getCategoryBenefit",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType, branchId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrCategoryBenefit", allParameters);

                List<GetCategoryBenefitMstr_Out> lstOfOutput = new List<GetCategoryBenefitMstr_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetCategoryBenefitMstr_Out Output = new GetCategoryBenefitMstr_Out();
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = dr["categoryName"].ToString();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.type = (int)(dr["type"]);
                    Output.BenefitName = dr["configName"].ToString();
                    Output.description = dr["description"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
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
        /// this method is used to fetch CategoryBenefitmstr details from db
        /// </summary>
        /// <param name="Input">GetCategoryBenefitMstr_In class as input parameter</param>
        /// <returns>list of GetCategoryBenefitMstr_Out as output</returns>
        public async Task<List<GetCategoryBenefitMstr_Out>> UD_CategoryBenefitMstrTypeAsync(CategoryBenefitBasedOnType Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getCategoryBenefitBasedOnBenefitType",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter typeName = new SqlParameter
                {
                    ParameterName = "typeName",
                    Value = Input.typeName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType, branchId, typeName , categoryId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrCategoryBenefit", allParameters);

                List<GetCategoryBenefitMstr_Out> lstOfOutput = new List<GetCategoryBenefitMstr_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetCategoryBenefitMstr_Out Output = new GetCategoryBenefitMstr_Out();
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = dr["categoryName"].ToString();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.type = (int)(dr["type"]);
                    Output.BenefitName = dr["configName"].ToString();
                    Output.description = dr["description"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
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
        /// this method is used to fetch CategoryBenefitmstr details from db
        /// </summary>
        /// <param name="Input">GetCategoryBenefitMstr_In class as input parameter</param>
        /// <returns>list of GetCategoryBenefitMstr_Out as output</returns>
        public async Task<List<GetCategoryBenefitMstr_Out>> UD_GetCategoryBenefitActiveMstrAsync(GetCategoryBenefitMstr_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getCategoryBenefitForUser",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter CategoryId = new SqlParameter
                {
                    ParameterName = "CategoryId",
                    Value = Input.CategoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType, CategoryId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrCategoryBenefit", allParameters);

                List<GetCategoryBenefitMstr_Out> lstOfOutput = new List<GetCategoryBenefitMstr_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetCategoryBenefitMstr_Out Output = new GetCategoryBenefitMstr_Out();
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = dr["categoryName"].ToString();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.type = (int)(dr["type"]);
                    Output.BenefitName = dr["configName"].ToString();
                    Output.description = dr["description"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
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


        public async Task<List<GetCategoryBenefitMstr_Out>> UD_GetCategoryBenefitDepActiveMstrAsync(GetCategoryBenefitMstr_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getCategoryBenefitDep",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter CategoryId = new SqlParameter
                {
                    ParameterName = "CategoryId",
                    Value = Input.CategoryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType, CategoryId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrCategoryBenefit", allParameters);

                List<GetCategoryBenefitMstr_Out> lstOfOutput = new List<GetCategoryBenefitMstr_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetCategoryBenefitMstr_Out Output = new GetCategoryBenefitMstr_Out();
                    Output.categoryId = (int)(dr["categoryId"]);
                    Output.categoryName = dr["categoryName"].ToString();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.type = (int)(dr["type"]);
                    Output.BenefitName = dr["configName"].ToString();
                    Output.description = dr["description"].ToString();
                    Output.imageUrl = dr["imageUrl"].ToString();
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
        /// this method is used to update CategoryBenefitmstr details in db
        /// </summary>
        /// <param name="Input">UpdateCategoryBenefitMstr_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateCategoryBenefitMstrAsync(UpdateCategoryBenefitMstr_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "QueryType",
                    Value = "Update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter categoryId = new SqlParameter
                {
                    ParameterName = "categoryId",
                    Value = Input.categoryId,
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
                SqlParameter type = new SqlParameter
                {
                    ParameterName = "type",
                    Value = Input.type,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
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
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, categoryId, uniqueId, type, description, imageUrl, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrCategoryBenefit", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate CategoryBenefit master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateCategoryBenefitMstr_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateCategoryBenefitMstrAsyn(ActivateOrInactivateCategoryBenefitMstr_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "QueryType",
                    Value = Input.QueryType,
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

                SqlParameter[] allParameters = { QueryType, updatedBy, uniqueId };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrCategoryBenefit", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}