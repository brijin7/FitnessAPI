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
using static Fitness.Models.BusinessObject.EmployeeMaster.BOL_MstrEmployee;

namespace Fitness.Models.DataAccessLayer.EmployeeMaster
{
   
    public class DAL_MstrEmployee : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);

        /// this method is used to fetch employeeMaster details from db
        /// </summary>
        /// <param name="Input">GetMstrEmployee_In class as input parameter</param>
        /// <returns>list of GetMstrEmployee_Out as output</returns>
        public async Task<List<GetMstrEmployee_Out>> UD_GetMstrBranchAsync(GetMstrEmployee_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetMstrEmployee",
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrEmployee", allParameters);

                List<GetMstrEmployee_Out> lstOfOutput = new List<GetMstrEmployee_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetMstrEmployee_Out Output = new GetMstrEmployee_Out();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.empId = (int)(dr["empId"]);
                    Output.empType = dr["empType"].ToString();
                    Output.empTypeName = dr["EmployeTypeName"].ToString();
                    Output.firstName = dr["firstName"].ToString();
                    Output.lastName = dr["lastName"].ToString();
                    Output.designation = dr["designation"].ToString();
                    Output.designationName = dr["DesignationName"].ToString();
                    Output.department = dr["department"].ToString();
                    Output.departmentName = dr["DepartmentName"].ToString();
                    Output.city = dr["city"].ToString();
                    Output.state = dr["state"].ToString();
                    Output.gender = dr["gender"].ToString();
                    Output.addressLine1 = dr["addressLine1"].ToString();
                    Output.addressLine2 = dr["addressLine2"].ToString();
                    Output.zipcode = dr["zipcode"].ToString();
                    Output.city = dr["city"].ToString();
                    Output.district = dr["district"].ToString();
                    Output.state = dr["state"].ToString();
                    Output.maritalStatus = dr["maritalStatus"].ToString();
                    Output.dob = dr["dob"].ToString();
                    Output.doj = dr["doj"].ToString();
                    Output.aadharId = dr["aadharId"].ToString();
                    Output.photoLink = dr["photoLink"].ToString();
                    Output.mobileNo = dr["mobileNo"].ToString();
                    Output.passWord = dr["passWord"].ToString();
                    Output.mailId = dr["mailId"].ToString();
                    Output.shiftId = dr["shiftId"].ToString();
                    Output.shiftName = dr["ShiftName"].ToString();
                    Output.roleId = dr["roleId"].ToString();
                    Output.Role = dr["RoleName"].ToString();
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

        /// this method is used to fetch employeeMaster details from db
        /// </summary>
        /// <param name="Input">GetMstrEmployee_In class as input parameter</param>
        /// <returns>list of ddlMstrEmployee_Out as output</returns>
        public async Task<List<ddlMstrEmployee_Out>> UD_ddlMstrBranchAsync(ddlMstrEmployee_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "ddlMstrEmployee",
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
                SqlParameter designationId = new SqlParameter
                {
                    ParameterName = "designationId",
                    Value = Input.designationId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, designationId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrEmployee", allParameters);

                List<ddlMstrEmployee_Out> lstOfOutput = new List<ddlMstrEmployee_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    ddlMstrEmployee_Out Output = new ddlMstrEmployee_Out();
                   
                    Output.empId = (int)(dr["empId"]);
                    Output.empName = dr["empName"].ToString();
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
        /// this method is used to Insert employeemaster details in db
        /// </summary>
        /// <param name="Input"> Insert Branch Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertMstrBranchAsyc(InsertMstrEmployee_In Input)
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
               
                SqlParameter empType = new SqlParameter
                {
                    ParameterName = "empType",
                    Value = Input.empType,
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
                SqlParameter designation = new SqlParameter
                {
                    ParameterName = "designation",
                    Value = Input.designation,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter department = new SqlParameter
                {
                    ParameterName = "department",
                    Value = Input.department,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

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
                    Value = StrEncryption.Encrypt(Input.passWord),
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
                SqlParameter mobileAppAccess = new SqlParameter
                {
                    ParameterName = "mobileAppAccess",
                    Value = Input.mobileAppAccess,
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
                        ,empType,firstName ,lastName,designation,department,gender,
                          addressLine1,addressLine2,district, state,city,zipcode,maritalStatus,dob,doj,aadharId,mobileNo,mailId,
                        passWord, photoLink,shiftId,roleId,mobileAppAccess,createdBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrEmployee", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// this method is used to update Employee details in db
        /// </summary>
        /// <param name="Input"> Update Employee Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateMstrEmployeeAsyc(UpdateMstrEmployee_In Input)
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
                SqlParameter empId = new SqlParameter
                {
                    ParameterName = "empId",
                    Value = Input.empId,
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

                SqlParameter empType = new SqlParameter
                {
                    ParameterName = "empType",
                    Value = Input.empType,
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
                SqlParameter designation = new SqlParameter
                {
                    ParameterName = "designation",
                    Value = Input.designation,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter department = new SqlParameter
                {
                    ParameterName = "department",
                    Value = Input.department,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

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
                    Value =StrEncryption.Encrypt(Input.passWord),
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
                SqlParameter mobileAppAccess = new SqlParameter
                {
                    ParameterName = "mobileAppAccess",
                    Value = Input.mobileAppAccess,
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

                SqlParameter[] allParameters = { queryType, gymOwnerId,branchId,empId
                        ,empType,firstName ,lastName,designation,department,gender,
                          addressLine1,addressLine2,district, state,city,zipcode,maritalStatus,dob,doj,aadharId,mobileNo,mailId,
                        passWord, photoLink,shiftId,roleId,mobileAppAccess,updatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrEmployee", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// this method is used to ActiveORINactive employee details in db
        /// </summary>
        /// <param name="Input"> ActiveORINactive employee Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateMstrEmployeeAsyc(ActivateOrInactivateMstrEmployee_In Input)
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
                SqlParameter empId = new SqlParameter
                {
                    ParameterName = "empId",
                    Value = Input.empId,
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

                SqlParameter[] allParameters = { queryType, empId, gymOwnerId, branchId, updatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrEmployee", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}