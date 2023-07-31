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
using static Fitness.Models.BusinessObject.BranchMaster.BOL_MstrBranchGallery;

namespace Fitness.Models.DataAccessLayer.BranchMaster
{
    public class DAL_MstrBranchGallery : SqlHelper
    {
        /// <summary>
        /// this method is used to insert details in BranchGallery in db
        /// </summary>
        /// <param name="Input">InsertBranchGallery_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertMstrBranchGalleryAsync(InsertBranchGallery_In Input)
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

                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter imageUrl = new SqlParameter
                {
                    ParameterName = "imageUrl",
                    Value = Input.imageUrl,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter galleryId = new SqlParameter
                {
                    ParameterName = "galleryId",
                    Value = Input.galleryId,
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
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType, branchId, imageUrl, createdBy, galleryId, description };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrBranchGallery", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch BranchGallery details from db
        /// </summary>
        /// <param name="Input">GetBranchGallery_In class as input parameter</param>
        /// <returns>list of GetBranchGallery_Out as output</returns>
        public async Task<List<GetBranchGallery_Out>> UD_GetBranchGalleryAsync(GetBranchGallery_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getMstrBranchGallery",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter galleryId = new SqlParameter
                {
                    ParameterName = "galleryId",
                    Value = Input.galleryId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, branchId, galleryId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrBranchGallery", allParameters);

                List<GetBranchGallery_Out> lstOfOutput = new List<GetBranchGallery_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetBranchGallery_Out Output = new GetBranchGallery_Out();
                    Output.imageId = (int)(dr["imageId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.galleryId = (int)(dr["galleryId"]);
                    Output.imageUrl = dr["imageUrl"].ToString();
                    Output.galleryname = dr["GallaryName"].ToString();
                    Output.description = dr["description"].ToString();
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
        /// this method is used to update BranchGallery details in db
        /// </summary>
        /// <param name="Input">UpdateBranchGallery_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateBranchGalleryAsync(UpdateBranchGallery_In Input)
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
                SqlParameter imageId = new SqlParameter
                {
                    ParameterName = "imageId",
                    Value = Input.imageId,
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
                SqlParameter imageUrl = new SqlParameter
                {
                    ParameterName = "imageUrl",
                    Value = Input.imageUrl,
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
                SqlParameter galleryId = new SqlParameter
                {
                    ParameterName = "galleryId",
                    Value = Input.galleryId,
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
                SqlParameter[] allParameters = { queryType, imageId, branchId, imageUrl, updatedBy, galleryId, description };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrBranchGallery", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate BranchGallery master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateBranchGallery_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateBranchGalleryMstrAsyn(ActivateOrInactivateBranchGallery_In Input)
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
                SqlParameter imageId = new SqlParameter
                {
                    ParameterName = "imageId",
                    Value = Input.imageId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType, imageId, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrBranchGallery", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}