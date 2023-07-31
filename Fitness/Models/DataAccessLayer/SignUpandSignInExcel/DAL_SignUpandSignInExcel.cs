using Fitness.App_Start;
using Fitness.Helper;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using static Fitness.Models.BusinessObject.SignUpandSignInExcel.BOL_SignUpandSignInExcel;

namespace Fitness.Models.DataAccessLayer.SignUpandSignInExcel
{
    public class DAL_SignUpandSignInExcel : SqlHelper
    {

        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);

        /// <summary>
        /// this method is used to convert datatable to InsertMstrUserSignUp_In
        /// </summary>
        /// <param name="dtExcel"></param>
        /// <returns></returns>
        public async Task<InsertMstrUserSignUp_In> GetInputForExcelSignup(DataTable dtExcel)
        {
            try
            {
                List<MstrUserSignUp> lstOfMstrUserSignUp = new List<MstrUserSignUp>();
                string dtExcelToJson = "";

                await Task.Run(() =>
                {
                    dtExcelToJson = Newtonsoft.Json.JsonConvert.SerializeObject(dtExcel);
                    lstOfMstrUserSignUp = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MstrUserSignUp>>(dtExcelToJson);
                });


                InsertMstrUserSignUp_In Input = new InsertMstrUserSignUp_In()
                {
                    ListOfSignup = lstOfMstrUserSignUp,
                };

                return Input;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to insert details for signup from Excel
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertSignup(DataTable DtInput, MastrSignUpCommon CommonFields)
        {
            try
            {
                InsertMstrUserSignUp_In Input = await GetInputForExcelSignup(DtInput);
                int InsertCount = 0;
                int totalDataForInsert = Input.ListOfSignup.Count;
                string ErrorMessage = "";

                foreach (MstrUserSignUp item in Input.ListOfSignup)
                {
                    DB_Response res = await InsertSignupAsync(item, CommonFields);
                    if (res.StatusCode == 1)
                    {
                        InsertCount++;
                    }
                    else
                    {
                        ErrorMessage += $"'{res.Response}',";
                    }
                }

                DB_Response response = new DB_Response();

                if (InsertCount == totalDataForInsert)
                {
                    response = new DB_Response()
                    {
                        StatusCode = 1,
                        Response = "User Details Inserted Successfully !!!."
                    };
                }
                else
                {
                    response = new DB_Response()
                    {
                        StatusCode = 0,
                        Response = $"{ErrorMessage}"
                    };
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to insert sign up details
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<DB_Response> InsertSignupAsync(MstrUserSignUp Input, MastrSignUpCommon InputCommon)
        {
            try
            {
                SqlParameter roleId = new SqlParameter()
                {
                    ParameterName = "roleId",
                    Value = InputCommon.RoleId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = InputCommon.CreatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = InputCommon.GymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = InputCommon.BranchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter mobileNo = new SqlParameter
                {
                    ParameterName = "mobileNo",
                    Value = Input.MobileNo.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 15
                };
                SqlParameter mailId = new SqlParameter
                {
                    ParameterName = "mailId",
                    Value = Input.MailId.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter password = new SqlParameter
                {
                    ParameterName = "password",
                    Value = StrEncryption.Encrypt(Input.Password == null ? Input.Password : Input.Password.Trim()),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };

                SqlParameter firstName = new SqlParameter
                {
                    ParameterName = "firstName",
                    Value = Input.FirstName == null ? Input.FirstName : Input.FirstName.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter lastName = new SqlParameter
                {
                    ParameterName = "lastName",
                    Value = Input.LastName == null ? Input.LastName :Input.LastName.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter dob = new SqlParameter
                {
                    ParameterName = "dob",
                    Value = Input.Dob == null ? Input.Dob : Input.Dob.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter gender = new SqlParameter
                {
                    ParameterName = "gender",
                    Value = Input.Gender == null ? Input.Gender : Input.Gender.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };
                SqlParameter maritalStatus = new SqlParameter
                {
                    ParameterName = "maritalStatus",
                    Value = Input.MaritalStatus == null ? Input.MaritalStatus : Input.MaritalStatus.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };
                SqlParameter addressLine1 = new SqlParameter
                {
                    ParameterName = "addressLine1",
                    Value = Input.AddressLine1 == null ? Input.AddressLine1 : Input.AddressLine1.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter addressLine2 = new SqlParameter
                {
                    ParameterName = "addressLine2",
                    Value = Input.AddressLine2 == null ? Input.AddressLine2 : Input.AddressLine2.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter zipcode = new SqlParameter
                {
                    ParameterName = "zipcode",
                    Value = Input.Zipcode == null ? Input.Zipcode : Input.Zipcode.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter city = new SqlParameter
                {
                    ParameterName = "city",
                    Value = Input.City == null ? Input.City : Input.City.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter district = new SqlParameter
                {
                    ParameterName = "district",
                    Value = Input.District == null ? Input.District : Input.District.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter state = new SqlParameter
                {
                    ParameterName = "state",
                    Value = Input.State == null ? Input.State : Input.State.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };

                SqlParameter weight = new SqlParameter
                {
                    ParameterName = "weight",
                    Value = Input.Weight,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                    Precision = 6,
                    Scale = 2
                };
                SqlParameter height = new SqlParameter
                {
                    ParameterName = "height",
                    Value = Input.Height,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                    Precision = 6,
                    Scale = 2
                };
                SqlParameter fatPercentage = new SqlParameter
                {
                    ParameterName = "fatPercentage",
                    Value = Input.FatPercentage,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter date = new SqlParameter
                {
                    ParameterName = "date",
                    Value = Input.Date == null ? Input.Date :Input.Date.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date,
                };
                SqlParameter WorkOutStatus = new SqlParameter
                {
                    ParameterName = "WorkOutStatus",
                    Value = Input.WorkOutStatus == null ? Input.WorkOutStatus : Input.WorkOutStatus.Trim(),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter WorkOutValue = new SqlParameter
                {
                    ParameterName = "WorkOutValue",
                    Value = Input.WorkOutValue,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                    Precision = 6,
                    Scale = 2
                };

                SqlParameter age = new SqlParameter
                {
                    ParameterName = "age",
                    Value = Input.Age,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter BMR = new SqlParameter
                {
                    ParameterName = "BMR",
                    Value = Input.BMR,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                    Precision = 6,
                    Scale = 2
                };
                SqlParameter BMI = new SqlParameter
                {
                    ParameterName = "BMI",
                    Value = Input.BMI,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                    Precision = 6,
                    Scale = 2
                };
                SqlParameter TDEE = new SqlParameter
                {
                    ParameterName = "TDEE",
                    Value = Input.TDEE,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };


                SqlParameter[] allParameters =
                {
                roleId,
                createdBy,
                gymOwnerId,
                branchId,

                mobileNo,
                mailId,
                password,

                firstName,
                lastName,
                dob,
                gender,
                maritalStatus,
                addressLine1,
                addressLine2,
                zipcode,
                city,
                district,
                state,

                weight,
                height,
                date,
                fatPercentage,
                WorkOutStatus,
                WorkOutValue,

                age,
                BMR,
                BMI,
                TDEE
                };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                DB_Response Response = await ExecuteNonQueryAsync("usp_MstrSignupUsingExcel", ListOfParameter);
                return Response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}