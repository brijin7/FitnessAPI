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
using static Fitness.Models.BusinessObject.TrainerMaster.BOL_MstrTrainer;
namespace Fitness.Models.DataAccessLayer.TrainerMaster
{
	public class DAL_MstrTrainer : SqlHelper
	{
		IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);


		public async Task<string> GetTrainerDetailsAsync(GetMstrTrainer_In Input)
		{
			try
			{
				SqlParameter queryType = new SqlParameter
				{
					ParameterName = "queryType",
					Value = "GetMstrTrainer",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
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

				SqlParameter[] allParameters = { queryType,gymOwnerId, branchId };


				DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrTrainer", allParameters);

				return dt.Rows[0]["TrainerDetails"].ToString();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<string> GetddlTrainerDetailsAsync(ddlMstrTrainer_In Input)
		{
			try
			{
				SqlParameter queryType = new SqlParameter
				{
					ParameterName = "queryType",
					Value = "ddlMstrTloyee",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
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

				SqlParameter[] allParameters = { queryType, gymOwnerId, branchId };


				DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrTrainer", allParameters);

				return dt.Rows[0]["TrainerDetails"].ToString();
			}
			catch (Exception)
			{
				throw;
			}
		}
		public async Task<DB_Response> UD_InsertMstrTrainerAsyc(InsertMstrTrainer_In Input)
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

				SqlParameter trainerType = new SqlParameter
				{
					ParameterName = "trainerType",
					Value = Input.trainerType,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int
				};
				SqlParameter firstName = new SqlParameter
				{
					ParameterName = "firstName",
					Value = Input.firstName,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};
				SqlParameter lastName = new SqlParameter
				{
					ParameterName = "lastName",
					Value = Input.lastName,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};
				SqlParameter addressLine1 = new SqlParameter
				{
					ParameterName = "addressLine1",
					Value = Input.addressLine1,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};


				SqlParameter addressLine2 = new SqlParameter
				{
					ParameterName = "addressLine2",
					Value = Input.addressLine2,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};

				SqlParameter district = new SqlParameter
				{
					ParameterName = "district",
					Value = Input.district,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};
				SqlParameter city = new SqlParameter
				{
					ParameterName = "city",
					Value = Input.city,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};
				SqlParameter state = new SqlParameter
				{
					ParameterName = "state",
					Value = Input.state,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};

				SqlParameter zipcode = new SqlParameter
				{
					ParameterName = "zipcode",
					Value = Input.zipcode,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int

				};
				SqlParameter dob = new SqlParameter
				{
					ParameterName = "dob",
					Value = DateTime.Parse(Input.dob, objEnglishDate),
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Date
				};
				SqlParameter doj = new SqlParameter
				{
					ParameterName = "doj",
					Value = DateTime.Parse(Input.doj, objEnglishDate),
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Date
				};
				SqlParameter aadharId = new SqlParameter
				{
					ParameterName = "aadharId",
					Value = Input.aadharId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 16
				};
				SqlParameter mobileNo = new SqlParameter
				{
					ParameterName = "mobileNo",
					Value = Input.mobileNo,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 15
				};
				SqlParameter mailId = new SqlParameter
				{
					ParameterName = "mailId",
					Value = Input.mailId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};
				SqlParameter photoLink = new SqlParameter
				{
					ParameterName = "photoLink",
					Value = Input.photoLink,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.VarChar
				};
				SqlParameter shiftId = new SqlParameter
				{
					ParameterName = "shiftId",
					Value = Input.shiftId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int
				};
				SqlParameter roleId = new SqlParameter
				{
					ParameterName = "roleId",
					Value = Input.roleId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int
				};
				SqlParameter maritalStatus = new SqlParameter
				{
					ParameterName = "maritalStatus",
					Value = Input.maritalStatus,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Char,
					Size = 1
				};
				SqlParameter gender = new SqlParameter
				{
					ParameterName = "gender",
					Value = Input.gender,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Char,
					Size = 1
				};
				SqlParameter createdBy = new SqlParameter
				{
					ParameterName = "createdBy",
					Value = Input.createdBy,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int

				};

				SqlParameter[] allParameters = { queryType, gymOwnerId,branchId
						,trainerType,firstName ,lastName,gender,
						  addressLine1,addressLine2,district, state,city,zipcode,maritalStatus,dob,doj,aadharId,mobileNo,mailId
						,photoLink,shiftId,roleId,createdBy };
				List<SqlParameter> ListOfParameter = new List<SqlParameter>();
				ListOfParameter.AddRange(allParameters);
				return await ExecuteNonQueryAsync("usp_MstrTrainer", ListOfParameter);

			}
			catch (Exception)
			{
				throw;
			}

		}

		public async Task<DB_Response> UD_UpdateMstrTrainerAsyc(UpdateMstrTrainer_In Input)
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

				SqlParameter trainerType = new SqlParameter
				{
					ParameterName = "trainerType",
					Value = Input.trainerType,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int
				};
				SqlParameter firstName = new SqlParameter
				{
					ParameterName = "firstName",
					Value = Input.firstName,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};
				SqlParameter lastName = new SqlParameter
				{
					ParameterName = "lastName",
					Value = Input.lastName,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};
				SqlParameter addressLine1 = new SqlParameter
				{
					ParameterName = "addressLine1",
					Value = Input.addressLine1,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};
				SqlParameter addressLine2 = new SqlParameter
				{
					ParameterName = "addressLine2",
					Value = Input.addressLine2,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};

				SqlParameter district = new SqlParameter
				{
					ParameterName = "district",
					Value = Input.district,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};
				SqlParameter city = new SqlParameter
				{
					ParameterName = "city",
					Value = Input.city,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};
				SqlParameter state = new SqlParameter
				{
					ParameterName = "state",
					Value = Input.state,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};

				SqlParameter zipcode = new SqlParameter
				{
					ParameterName = "zipcode",
					Value = Input.zipcode,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int

				};
				SqlParameter dob = new SqlParameter
				{
					ParameterName = "dob",
					Value = DateTime.Parse(Input.dob, objEnglishDate),
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Date
				};
				SqlParameter doj = new SqlParameter
				{
					ParameterName = "doj",
					Value = DateTime.Parse(Input.doj, objEnglishDate),
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Date
				};
				SqlParameter aadharId = new SqlParameter
				{
					ParameterName = "aadharId",
					Value = Input.aadharId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 16
				};
				SqlParameter mobileNo = new SqlParameter
				{
					ParameterName = "mobileNo",
					Value = Input.mobileNo,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 15
				};
				SqlParameter mailId = new SqlParameter
				{
					ParameterName = "mailId",
					Value = Input.mailId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 50
				};
				SqlParameter passWord = new SqlParameter
				{
					ParameterName = "passWord",
					Value = StrEncryption.Encrypt("123"),
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 100
				};
				SqlParameter photoLink = new SqlParameter
				{
					ParameterName = "photoLink",
					Value = Input.photoLink,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.VarChar
				};
				SqlParameter shiftId = new SqlParameter
				{
					ParameterName = "shiftId",
					Value = Input.shiftId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int
				};
				SqlParameter roleId = new SqlParameter
				{
					ParameterName = "roleId",
					Value = Input.roleId,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int
				};
				SqlParameter maritalStatus = new SqlParameter
				{
					ParameterName = "maritalStatus",
					Value = Input.maritalStatus,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Char,
					Size = 1
				};
				SqlParameter gender = new SqlParameter
				{
					ParameterName = "gender",
					Value = Input.gender,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Char,
					Size = 1
				};
				SqlParameter updatedBy = new SqlParameter
				{
					ParameterName = "updatedBy",
					Value = Input.updatedBy,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int

				};

				SqlParameter[] allParameters = { queryType, gymOwnerId,branchId,trainerId
						,trainerType,firstName ,lastName,gender,
						  addressLine1,addressLine2,district, state,city,zipcode,maritalStatus,dob,doj,aadharId,mobileNo,mailId,
						passWord, photoLink,shiftId,roleId,updatedBy };
				List<SqlParameter> ListOfParameter = new List<SqlParameter>();
				ListOfParameter.AddRange(allParameters);
				return await ExecuteNonQueryAsync("usp_MstrTrainer", ListOfParameter);

			}
			catch (Exception)
			{
				throw;
			}

		}

		public async Task<DB_Response> UD_ActivateOrInactivateMstrTrainerAsyc(ActivateOrInactivateMstrTrainer_In Input)
		{
			try
			{
				SqlParameter queryType = new SqlParameter
				{
					ParameterName = "queryType",
					Value = Input.queryType,
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

				SqlParameter updatedBy = new SqlParameter
				{
					ParameterName = "updatedBy",
					Value = Input.updatedBy,
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.Int

				};

				SqlParameter[] allParameters = { queryType, trainerId, gymOwnerId, branchId, updatedBy };
				List<SqlParameter> ListOfParameter = new List<SqlParameter>();
				ListOfParameter.AddRange(allParameters);
				return await ExecuteNonQueryAsync("usp_MstrTrainer", ListOfParameter);

			}
			catch (Exception)
			{
				throw;
			}

		}
	}
}