using Fitness.Helper;
using Fitness.Models.CommonModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.UserMaster.BOL_MstrUserInBodyTest;

namespace Fitness.Models.DataAccessLayer.UserMaster
{
    public class DAL_MstrUserInBodyTest : SqlHelper
    {
        readonly private static string GetProcedureName;
        static DAL_MstrUserInBodyTest()
        {
            GetProcedureName = "usp_GetMstrUserInBodyTest";
        }
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);
        /// <summary>
        /// this method is used to insert details in UserInBodyTest in db
        /// </summary>
        /// <param name="Input">InsertUserInBodyTest_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertMstrUserInBodyTestAsync(InsertUserInBodyTest_In Input)
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

                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
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
                SqlParameter dob;
                if (Input.dob != null)
                {
                    dob = new SqlParameter
                    {
                        ParameterName = "dob",
                        Value = DateTime.Parse(Input.dob, objEnglishDate),
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Date
                    };
                }
                else
                {
                    dob = new SqlParameter
                    {
                        ParameterName = "dob",
                        Value = Input.dob,
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Date
                    };
                }
                SqlParameter weight = new SqlParameter
                {
                    ParameterName = "weight",
                    Value = Input.weight,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter height = new SqlParameter
                {
                    ParameterName = "height",
                    Value = Input.height,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter fatPercentage = new SqlParameter
                {
                    ParameterName = "fatPercentage",
                    Value = Input.fatPercentage,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter WorkOutStatus = new SqlParameter
                {
                    ParameterName = "WorkOutStatus",
                    Value = Input.WorkOutStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter WorkOutValue = new SqlParameter
                {
                    ParameterName = "WorkOutValue",
                    Value = Input.WorkOutValue,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter gender = new SqlParameter
                {
                    ParameterName = "gender",
                    Value = Input.gender,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };
                SqlParameter age = new SqlParameter
                {
                    ParameterName = "age",
                    Value = Input.age,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter BMR = new SqlParameter
                {
                    ParameterName = "BMR",
                    Value = Input.BMR,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter BMI = new SqlParameter
                {
                    ParameterName = "BMI",
                    Value = Input.BMI,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };

                SqlParameter TDEE = new SqlParameter
                {
                    ParameterName = "TDEE",
                    Value = Input.TDEE,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter date;
                if (Input.date != null)
                {
                    date = new SqlParameter
                    {
                        ParameterName = "date",
                        Value = DateTime.Parse(Input.date, objEnglishDate),
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Date
                    };
                }
                else
                {
                    date = new SqlParameter
                    {
                        ParameterName = "date",
                        Value = Input.date,
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Date
                    };
                }
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType, userId,firstName,lastName,dob,gender, weight, height, fatPercentage,WorkOutStatus,
                    WorkOutValue,age,BMR,BMI,TDEE,date,createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrUserInBodyTest", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<DB_Response> UD_InsertUserInBodyTestAsync(InsertUserInBodyTestDep_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "InsertForEnrollment",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter firstName = new SqlParameter
                {
                    ParameterName = "firstName",
                    Value = Input.firstName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter dob;
                if (Input.dob != null)
                {
                    dob = new SqlParameter
                    {
                        ParameterName = "dob",
                        Value = Input.dob,
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Date
                    };
                }
                else
                {
                    dob = new SqlParameter
                    {
                        ParameterName = "dob",
                        Value = Input.dob,
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Date
                    };
                }
                SqlParameter gender = new SqlParameter
                {
                    ParameterName = "gender",
                    Value = Input.gender,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 2
                };
                SqlParameter WorkOutStatus = new SqlParameter
                {
                    ParameterName = "WorkOutStatus",
                    Value = Input.WorkOutStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter WorkOutValue = new SqlParameter
                {
                    ParameterName = "WorkOutValue",
                    Value = Input.WorkOutValue,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter weight = new SqlParameter
                {
                    ParameterName = "weight",
                    Value = Input.weight,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter height = new SqlParameter
                {
                    ParameterName = "height",
                    Value = Input.height,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };

                SqlParameter fatPercentage = new SqlParameter
                {
                    ParameterName = "fatPercentage",
                    Value = Input.fatPercentage,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter mobileNo = new SqlParameter
                {
                    ParameterName = "mobileNo",
                    Value = Input.mobileNo,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,

                };
                SqlParameter age = new SqlParameter
                {
                    ParameterName = "age",
                    Value = Input.age,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter BMR = new SqlParameter
                {
                    ParameterName = "BMR",
                    Value = Input.BMR,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                SqlParameter BMI = new SqlParameter
                {
                    ParameterName = "BMI",
                    Value = Input.BMI,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };

                SqlParameter TDEE = new SqlParameter
                {
                    ParameterName = "TDEE",
                    Value = Input.TDEE,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter date;
                if (Input.date != null)
                {
                    date = new SqlParameter
                    {
                        ParameterName = "date",
                        Value = DateTime.Parse(Input.date, objEnglishDate),
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Date
                    };
                }
                else
                {
                    date = new SqlParameter
                    {
                        ParameterName = "date",
                        Value = Input.date,
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Date
                    };
                }
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { queryType,firstName,dob,mobileNo, weight, height, fatPercentage
                    ,age,BMR,BMI,TDEE,date,gender,WorkOutStatus,WorkOutValue,createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrUserInBodyTest", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to fetch UserInBodyTest details from db
        /// </summary>
        /// <param name="Input">GetUserInBodyTest_In class as input parameter</param>
        /// <returns>list of GetUserInBodyTest_Out as output</returns>
        public async Task<JArray> UD_GetUserInBodyTestAsync(GetUserInBodyTest_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getMstrUserInBodyTest",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, userId };
                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to fetch UserInBodyTest details from db
        /// </summary>
        /// <param name="Input">GetUserInBodyTest_In class as input parameter</param>
        /// <returns>list of GetUserInBodyTest_Out as output</returns>
        public async Task<JArray> UD_GetAllUserInBodyTestAsync()
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getMstrUserInBodyTest",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType };

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}