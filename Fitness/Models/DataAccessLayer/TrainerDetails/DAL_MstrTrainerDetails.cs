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
using static Fitness.Models.BusinessObject.TrainerDetails.BOL_MstrTrainerDetails;
using Newtonsoft.Json.Linq;
using static Fitness.Models.BusinessObject.FaqMaster.BOL_FaqMaster;

namespace Fitness.Models.DataAccessLayer.TrainerDetails
{
	public class DAL_MstrTrainerDetails : SqlHelper
	{

		public async Task<string> GetTrainerDetailsAsync(GetMstrTrainerDetails_In Input)
		{
			try
			{
				SqlParameter queryType = new SqlParameter
				{
					ParameterName = "queryType",
					Value = "getTrainerDetails",
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
				SqlParameter Public = new SqlParameter
                {
                    ParameterName = "Public",
                    Value = Input.Public,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                };


                SqlParameter[] allParameters = { queryType, trainerId, Public };


				DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrTrainerDetails", allParameters);

				return dt.Rows[0]["TrainerDetails"].ToString();
			}
			catch (Exception)
			{
				throw;
			}
		}

        public async Task<JArray> GetTrainerDetailsApprovalAsync(GetMstrTrainerDetailsApproval_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getTrainerDetailsApproval",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter gymownerId = new SqlParameter
                {
                    ParameterName = "gymownerId",
                    Value = Input.gymownerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };


                SqlParameter[] allParameters = { queryType, branchId, gymownerId };

                return await GetResultFromGetDataTableFromUSPAsync("usp_GetMstrTrainerDetails", allParameters);
               
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<JArray> GetTrainerSpecialistAsync(GetMstrTrainerDetails_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getTrainerSpecialist",
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
                return await GetResultFromGetDataTableFromUSPAsync("usp_GetMstrTrainerDetails", allParameters);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DB_Response> UD_InsertMstrTrainerDetailsAsyc(InsertMstrTrainerDetails_In Input)
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
				SqlParameter trainerId = new SqlParameter
				{
					ParameterName = "trainerId",
					Value = Input.trainerId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int
				};
				SqlParameter specialistTypeId = new SqlParameter
				{
					ParameterName = "specialistTypeId",
					Value = Input.specialistTypeId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int
				};

				SqlParameter experience = new SqlParameter
				{
					ParameterName = "experience",
					Value = Input.experience,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar
				};
				SqlParameter qualification = new SqlParameter
				{
					ParameterName = "qualification",
					Value = Input.qualification,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};
				SqlParameter certificates = new SqlParameter
				{
					ParameterName = "certificates",
					Value = Input.certificates,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
				};
				SqlParameter createdBy = new SqlParameter
				{
					ParameterName = "createdBy",
					Value = Input.createdBy,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int

				};

				SqlParameter[] allParameters = { queryType, trainerId,specialistTypeId,experience,qualification,certificates,
						createdBy };
				List<SqlParameter> ListOfParameter = new List<SqlParameter>();
				ListOfParameter.AddRange(allParameters);
				return await ExecuteNonQueryAsync("usp_MstrTrainerDetails", ListOfParameter);

			}
			catch (Exception)
			{
				throw;
			}

		}

		public async Task<DB_Response> UD_UpdateMstrTrainerDetailsAsyc(UpdateMstrTrainerDetails_In Input)
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
				SqlParameter trainerId = new SqlParameter
				{
					ParameterName = "trainerId",
					Value = Input.trainerId,
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
				SqlParameter specialistTypeId = new SqlParameter
				{
					ParameterName = "specialistTypeId",
					Value = Input.specialistTypeId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int
				};

				SqlParameter experience = new SqlParameter
				{
					ParameterName = "experience",
					Value = Input.experience,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar
				};
				SqlParameter qualification = new SqlParameter
				{
					ParameterName = "qualification",
					Value = Input.qualification,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};
				SqlParameter certificates = new SqlParameter
				{
					ParameterName = "certificates",
					Value = Input.certificates,
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

				SqlParameter[] allParameters = { queryType, uniqueId, trainerId, specialistTypeId, experience, qualification, certificates, updatedBy };
				List<SqlParameter> ListOfParameter = new List<SqlParameter>();
				ListOfParameter.AddRange(allParameters);
				return await ExecuteNonQueryAsync("usp_MstrTrainerDetails", ListOfParameter);

			}
			catch (Exception)
			{
				throw;
			}

		}


        /// <summary>
        /// this method is used to activate and inactivate Faq master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateFaqMstr_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ApproveOrInapproveTrainerDetailsAsyn(ApproveOrInapproveTrainerDetails_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
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

                SqlParameter[] allParameters = { QueryType, updatedBy, uniqueId };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrTrainerDetails", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}