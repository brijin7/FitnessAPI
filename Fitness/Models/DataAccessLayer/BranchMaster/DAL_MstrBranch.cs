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
using static Fitness.Models.BusinessObject.BranchMaster.BOL_MstrBranch;

namespace Fitness.Models.DataAccessLayer.BranchMaster
{
    public class DAL_MstrBranch : SqlHelper
    {

        /// this method is used to fetch branchMaster details from db
        /// </summary>
        /// <param name="Input">GetMstrBranch_In class as input parameter</param>
        /// <returns>list of GetMstrBranch_Out as output</returns>
        public async Task<List<GetMstrBranch_Out>> UD_GetMstrBranchAsync(GetMstrBranch_In Input)
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrBranch", allParameters);

                List<GetMstrBranch_Out> lstOfOutput = new List<GetMstrBranch_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetMstrBranch_Out Output = new GetMstrBranch_Out();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.shortName = dr["shortName"].ToString();
                    Output.latitude = dr["latitude"].ToString();
                    Output.longitude = dr["longitude"].ToString();
                    Output.address1 = dr["address1"].ToString();
                    Output.address2 = dr["address2"].ToString();
                    Output.district = dr["district"].ToString();
                    Output.fromtime = dr["fromtime"].ToString();
                    Output.totime = dr["totime"].ToString();
                    Output.city = dr["city"].ToString();
                    Output.state = dr["state"].ToString();
                    Output.pincode = dr["pincode"].ToString();
                    Output.primaryMobileNumber = dr["primaryMobileNumber"].ToString();
                    Output.secondayMobilenumber = dr["secondayMobilenumber"].ToString();
                    Output.emailId = dr["emailId"].ToString();
                    Output.gstNumber = dr["gstNumber"].ToString();
                    Output.approvalStatus = dr["approvalStatus"].ToString();
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




        /// this method is used to fetch branchMaster details from db
        /// </summary>
        /// <param name="Input">GetMstrBranch_In class as input parameter</param>
        /// <returns>list of GetMstrBranch_Out as output</returns>
        public async Task<List<ddlMstrBranch_Out>> UD_ddlMstrBranchAsync(ddlMstrBranch_In Input)
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrBranch", allParameters);

                List<ddlMstrBranch_Out> lstOfOutput = new List<ddlMstrBranch_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    ddlMstrBranch_Out Output = new ddlMstrBranch_Out();
                    Output.branchId = (int)(dr["branchId"]);
                    Output.branchName = dr["branchName"].ToString();
                    Output.image = dr["image"].ToString();
                    lstOfOutput.Add(Output);
                }

                return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<string> GetBranchBaesdOnLocationAsync(GetMstrBranchBasedOnLocation_In Input)
        {
            try
            {

                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetBranchBasedOnLocation",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                };

                SqlParameter lattitude = new SqlParameter
                {
                    ParameterName = "lattitude",
                    Value = Input.lattitude,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                };
                SqlParameter longitude = new SqlParameter
                {
                    ParameterName = "longitude",
                    Value = Input.longitude,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                };
                SqlParameter radius = new SqlParameter
                {
                    ParameterName = "radius",
                    Value = Input.radius,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                };

                SqlParameter[] allParameters = { queryType, lattitude, longitude ,radius };


                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrBranch", allParameters);

                return dt.Rows[0]["Response"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to Insert branchmaster details in db
        /// </summary>
        /// <param name="Input"> Insert Branch Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertMstrBranchAsyc(InsertMstrBranch_In Input)
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
                SqlParameter branchName = new SqlParameter
                {
                    ParameterName = "branchName",
                    Value = Input.branchName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                SqlParameter shortName = new SqlParameter
                {
                    ParameterName = "shortName",
                    Value = Input.shortName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                SqlParameter latitude = new SqlParameter
                {
                    ParameterName = "latitude",
                    Value = Input.latitude,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter longitude = new SqlParameter
                {
                    ParameterName = "longitude",
                    Value = Input.longitude,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter address1 = new SqlParameter
                {
                    ParameterName = "address1",
                    Value = Input.address1,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };

                SqlParameter address2 = new SqlParameter
                {
                    ParameterName = "address2",
                    Value = Input.address2 == "" ? null : Input.address2,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50

                };
                SqlParameter district = new SqlParameter
                {
                    ParameterName = "district",
                    Value = Input.district == "" ? null : Input.district,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter fromtime = new SqlParameter
                {
                    ParameterName = "fromtime",
                    Value = Input.fromtime == "" ? null : Input.fromtime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter totime = new SqlParameter
                {
                    ParameterName = "totime",
                    Value = Input.totime == "" ? null : Input.totime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter city = new SqlParameter
                {
                    ParameterName = "city",
                    Value = Input.city == "" ? null : Input.city,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter state = new SqlParameter
                {
                    ParameterName = "state",
                    Value = Input.state == "" ? null : Input.state,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };

                SqlParameter pincode = new SqlParameter
                {
                    ParameterName = "pincode",
                    Value = Input.pincode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter primaryMobileNumber = new SqlParameter
                {
                    ParameterName = "primaryMobileNumber",
                    Value = Input.primaryMobileNumber,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 15
                };
                SqlParameter secondayMobilenumber = new SqlParameter
                {
                    ParameterName = "secondayMobilenumber",
                    Value = Input.secondayMobilenumber == "" ? null : Input.secondayMobilenumber,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 15
                };
                SqlParameter emailId = new SqlParameter
                {
                    ParameterName = "emailId",
                    Value = Input.emailId == "" ? null : Input.emailId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter gstNumber = new SqlParameter
                {
                    ParameterName = "gstNumber",
                    Value = Input.gstNumber == "" ? null : Input.gstNumber,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 20
                };
                SqlParameter approvalStatus = new SqlParameter
                {
                    ParameterName = "approvalStatus",
                    Value = Input.approvalStatus,
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

                SqlParameter[] allParameters = { queryType, gymOwnerId,branchName,shortName,latitude,longitude ,
                    address1,address2,district,fromtime,totime,state,city,pincode,primaryMobileNumber,
                    secondayMobilenumber,emailId,gstNumber,approvalStatus, createdBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrBranch", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// this method is used to update branchmaster details in db
        /// </summary>
        /// <param name="Input"> Update Branch Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateMstrBranchAsyc(UpdateMstrBranch_In Input)
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
                SqlParameter branchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.branchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter branchName = new SqlParameter
                {
                    ParameterName = "branchName",
                    Value = Input.branchName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                SqlParameter shortName = new SqlParameter
                {
                    ParameterName = "shortName",
                    Value = Input.shortName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                SqlParameter latitude = new SqlParameter
                {
                    ParameterName = "latitude",
                    Value = Input.latitude,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter longitude = new SqlParameter
                {
                    ParameterName = "longitude",
                    Value = Input.longitude,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter address1 = new SqlParameter
                {
                    ParameterName = "address1",
                    Value = Input.address1,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };

                SqlParameter address2 = new SqlParameter
                {
                    ParameterName = "address2",
                    Value = Input.address2 == "" ? null : Input.address2,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50

                };
                SqlParameter district = new SqlParameter
                {
                    ParameterName = "district",
                    Value = Input.district == "" ? null : Input.district,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter fromtime = new SqlParameter
                {
                    ParameterName = "fromtime",
                    Value = Input.fromtime == "" ? null : Input.fromtime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter totime = new SqlParameter
                {
                    ParameterName = "totime",
                    Value = Input.totime == "" ? null : Input.totime,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Time
                };
                SqlParameter city = new SqlParameter
                {
                    ParameterName = "city",
                    Value = Input.city == "" ? null : Input.city,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter state = new SqlParameter
                {
                    ParameterName = "state",
                    Value = Input.state == "" ? null : Input.state,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };

                SqlParameter pincode = new SqlParameter
                {
                    ParameterName = "pincode",
                    Value = Input.pincode == "" ? null : Input.pincode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter primaryMobileNumber = new SqlParameter
                {
                    ParameterName = "primaryMobileNumber",
                    Value = Input.primaryMobileNumber,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 15
                };
                SqlParameter secondayMobilenumber = new SqlParameter
                {
                    ParameterName = "secondayMobilenumber",
                    Value = Input.secondayMobilenumber == "" ? null : Input.secondayMobilenumber,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 15
                };
                SqlParameter emailId = new SqlParameter
                {
                    ParameterName = "emailId",
                    Value = Input.emailId == "" ? null : Input.emailId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter gstNumber = new SqlParameter
                {
                    ParameterName = "gstNumber",
                    Value = Input.gstNumber == "" ? null : Input.gstNumber,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 20
                };
                SqlParameter approvalStatus = new SqlParameter
                {
                    ParameterName = "approvalStatus",
                    Value = Input.approvalStatus,
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

                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId,branchName,shortName,latitude,longitude ,
                    address1,address2,district,fromtime,totime,state,city,pincode,primaryMobileNumber,
                    secondayMobilenumber,emailId,gstNumber,approvalStatus, updatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrBranch", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// this method is used to ActiveORINactive branchmaster details in db
        /// </summary>
        /// <param name="Input"> ActiveORINactive Branch Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateMstrBranchAsyc(ActivateOrInactivateMstrBranch_In Input)
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

                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, updatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrBranch", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// this method is used to Update Approval Status  details in db
        /// </summary>
        /// <param name="Input"> Update Approval Status Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateApprovalStatusMstrBranchAsyc(UpdateApprovalStatusMstrBranch_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "approve",
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
                SqlParameter approvalStatus = new SqlParameter
                {
                    ParameterName = "approvalStatus",
                    Value = Input.approvalStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };
                SqlParameter cancellationReason = new SqlParameter
                {
                    ParameterName = "cancellationReason",
                    Value = Input.cancellationReason,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 200
                };

                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };

                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, approvalStatus, cancellationReason, updatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrBranch", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }



        /// this method is used to fetch branchMaster details from db
        /// </summary>
        /// <param name="Input">GetOwnerCurrentDay_Details class as input parameter</param>
        /// <returns>list of GetMstrBranch_Out as output</returns>
        public async Task<JArray> UD_GetOwnerCurrentDayDetailsAsync(ownercourrentDayDetails_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getOwnerLoginDetails",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                    Size = 100
                };

                SqlParameter[] allParameters = { queryType, gymOwnerId };

                return await GetResultFromGetDataTableFromUSPAsync("usp_GetTranOwnerLoginDetails", allParameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}