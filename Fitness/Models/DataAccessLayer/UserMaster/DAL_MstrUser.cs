using Fitness.Helper;
using Fitness.App_Start;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.UserMaster.BOL_MstrUser;

namespace Fitness.Models.DataAccessLayer.UserMaster
{
    public class DAL_MstrUser : SqlHelper
    {
        IFormatProvider objEnglishDate = new System.Globalization.CultureInfo("en-GB", true);
        /// this method is used to fetch Get User Details details from db
        /// </summary>
        /// <param name="Input">GetMstrUser_In class as input parameter</param>
        /// <returns>list of GetMstrUser_Out as output</returns>
        public async Task<List<GetMstrUserList_Out>> UD_GetMstrUserAsync(GetMstrUserList_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetMstrUser",
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

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrUser", allParameters);

                List<GetMstrUserList_Out> lstOfOutput = new List<GetMstrUserList_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetMstrUserList_Out Output = new GetMstrUserList_Out();
                    Output.userId = (int)(dr["userId"]);
                    Output.firstName = dr["firstName"].ToString();
                    Output.lastName = dr["lastName"].ToString();
                    Output.mobileNo = dr["mobileNo"].ToString();
                    Output.mailId = dr["mailId"].ToString();
                    Output.gender = dr["gender"].ToString();
                    Output.maritalStatus = dr["maritalStatus"].ToString();
                    Output.addressLine1 = dr["addressLine1"].ToString();
                    Output.addressLine2 = dr["addressLine2"].ToString();
                    Output.district = dr["district"].ToString();
                    Output.city = dr["city"].ToString();
                    Output.state = dr["state"].ToString();
                    Output.zipcode = dr["zipcode"].ToString();
                    Output.photoLink = dr["photoLink"].ToString();
                    Output.dob = dr["dob"].ToString();
                    Output.roleId = dr["roleId"].ToString();
                    Output.roleName = dr["roleName"].ToString();
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

        /// this method is used to fetch Get User Details details from db
        /// </summary>
        /// <param name="Input">GetMstrUser_In class as input parameter</param>
        /// <returns>list of GetMstrUser_Out as output</returns>
        public async Task<List<GetMstrAdminUserList_Out>> UD_GetMstrAdminUserAsync(GetMstrAdminUserList_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetAdminUser",
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
                SqlParameter followUpStatusId = new SqlParameter
                {
                    ParameterName = "followUpStatusId",
                    Value = Input.followUpStatusId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size=50
                };

                SqlParameter[] allParameters = { queryType, gymOwnerId, branchId, followUpStatusId };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrUser", allParameters);

                List<GetMstrAdminUserList_Out> lstOfOutput = new List<GetMstrAdminUserList_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetMstrAdminUserList_Out Output = new GetMstrAdminUserList_Out();
                    Output.userId = (int)(dr["userId"]);
                    Output.firstName = dr["firstName"].ToString();
                    Output.lastName = dr["lastName"].ToString();
                    Output.mobileNo = dr["mobileNo"].ToString();
                    Output.mailId = dr["mailId"].ToString();
                    Output.gender = dr["gender"].ToString();
                    Output.maritalStatus = dr["maritalStatus"].ToString();
                    Output.addressLine1 = dr["addressLine1"].ToString();
                    Output.addressLine2 = dr["addressLine2"].ToString();
                    Output.district = dr["district"].ToString();
                    Output.city = dr["city"].ToString();
                    Output.state = dr["state"].ToString();
                    Output.zipcode = dr["zipcode"].ToString();
                    Output.photoLink = dr["photoLink"].ToString();
                    Output.dob = dr["dob"].ToString();
                    Output.roleId = dr["roleId"].ToString();
                    Output.roleName = dr["roleName"].ToString();
                    Output.activeStatus = dr["activeStatus"].ToString();
                    Output.rewardPoints = dr["rewardPoints"].ToString();
                    Output.rewardUtilized = dr["rewardUtilized"].ToString();
                    Output.promoNotification = dr["promoNotification"].ToString();
                    Output.enquiryReason = dr["enquiryReason"].ToString();
                    Output.enquirydate = dr["enquirydate"].ToString();
                    Output.followUpMode = dr["followUpMode"].ToString();
                    Output.followUpModeName = dr["followUpModeName"].ToString();
                    Output.followUpStatus = dr["followUpStatus"].ToString();
                    Output.followUpStatusName = dr["followUpStatusName"].ToString();
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
        /// this method is used to update Update MstrUser Profile  in db
        /// </summary>
        /// <param name="Input"> UpdateMstrUserProfile_In</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateMstrUserProfileAsyc(UpdateMstrUserProfile_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "updateProfile",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
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
                SqlParameter photoLink = new SqlParameter
                {
                    ParameterName = "photoLink",
                    Value = Input.photoLink,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
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
                //SqlParameter passWord = new SqlParameter
                //{
                //    ParameterName = "passWord",
                //    Value =StrEncryption.Encrypt(Input.passWord),
                //    Direction = ParameterDirection.Input,
                //    SqlDbType = SqlDbType.NVarChar,
                //    Size = 100
                //};
              
               
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

                SqlParameter[] allParameters = { queryType,userId ,firstName ,lastName,gender,mobileNo,mailId,
                          addressLine1,addressLine2,district, state,city,zipcode,maritalStatus,dob,photoLink,updatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrUser", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// this method is used to update Update MstrUser Profile  in db
        /// </summary>
        /// <param name="Input"> UpdateMstrUserProfile_In</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertMstrUserProfileAsyc(InserteMstrUserProfile_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "InsertAdminUser",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
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
                SqlParameter photoLink = new SqlParameter
                {
                    ParameterName = "photoLink",
                    Value = Input.photoLink,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
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
                //SqlParameter passWord = new SqlParameter
                //{
                //    ParameterName = "passWord",
                //    Value =StrEncryption.Encrypt(Input.passWord),
                //    Direction = ParameterDirection.Input,
                //    SqlDbType = SqlDbType.NVarChar,
                //    Size = 100
                //};


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
                SqlParameter rewardPoints = new SqlParameter
                {
                    ParameterName = "rewardPoints",
                    Value = Input.rewardPoints,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter rewardUtilized = new SqlParameter
                {
                    ParameterName = "rewardUtilized",
                    Value = Input.rewardUtilized,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                  SqlParameter followUpStatus = new SqlParameter
                  {
                      ParameterName = "followUpStatus",
                      Value = Input.followUpStatus,
                      Direction = ParameterDirection.Input,
                      SqlDbType = SqlDbType.Int

                  };
                SqlParameter followUpMode = new SqlParameter
                {
                    ParameterName = "followUpMode",
                    Value = Input.followUpMode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter promoNotification = new SqlParameter
                {
                    ParameterName = "promoNotification",
                    Value = Input.promoNotification,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter enquiryReason = new SqlParameter
                {
                    ParameterName = "enquiryReason",
                    Value = Input.enquiryReason,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter enquirydate = new SqlParameter
                {
                    ParameterName = "enquirydate",
                    Value = DateTime.Parse(Input.enquirydate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };

                SqlParameter[] allParameters = { queryType,firstName ,lastName,gender,mobileNo,mailId,
                          addressLine1,addressLine2,district, state,city,zipcode,maritalStatus,dob,photoLink,createdBy,
                gymOwnerId,branchId,rewardPoints,rewardUtilized,promoNotification,enquiryReason,followUpMode,followUpStatus,enquirydate};
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrUser", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// this method is used to update Update MstrUser Profile  in db
        /// </summary>
        /// <param name="Input"> UpdateMstrUserProfile_In</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateMstrAdminUserProfileAsyc(UpdateMstrAdminUserProfile_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "updateAdminUserProfile",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
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
                SqlParameter photoLink = new SqlParameter
                {
                    ParameterName = "photoLink",
                    Value = Input.photoLink,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
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
                SqlParameter rewardPoints = new SqlParameter
                {
                    ParameterName = "rewardPoints",
                    Value = Input.rewardPoints,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter rewardUtilized = new SqlParameter
                {
                    ParameterName = "rewardUtilized",
                    Value = Input.rewardUtilized,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter followUpStatus = new SqlParameter
                {
                    ParameterName = "followUpStatus",
                    Value = Input.followUpStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter followUpMode = new SqlParameter
                {
                    ParameterName = "followUpMode",
                    Value = Input.followUpMode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter promoNotification = new SqlParameter
                {
                    ParameterName = "promoNotification",
                    Value = Input.promoNotification,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter enquiryReason = new SqlParameter
                {
                    ParameterName = "enquiryReason",
                    Value = Input.enquiryReason,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                };
                SqlParameter enquirydate = new SqlParameter
                {
                    ParameterName = "enquirydate",
                    Value = DateTime.Parse(Input.enquirydate, objEnglishDate),
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Date
                };
                SqlParameter[] allParameters = { queryType,userId ,firstName ,lastName,gender,mobileNo,mailId,
                          addressLine1,addressLine2,district, state,city,zipcode,maritalStatus,dob,photoLink,updatedBy,
                gymOwnerId,branchId,rewardPoints,rewardUtilized,promoNotification,enquiryReason,followUpMode,followUpStatus,enquirydate};
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrUser", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// this method is used to update Update MstrUser Profile  in db
        /// </summary>
        /// <param name="Input"> UpdateMstrUserProfile_In</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateMstrregistrationTokenAsyc(UpdateMstrregistrationToken_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "updateregistrationToken",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter registrationToken = new SqlParameter
                {
                    ParameterName = "registrationToken",
                    Value = Input.registrationToken,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 500
                };

                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
       
                SqlParameter[] allParameters = { queryType, userId, registrationToken, updatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_MstrUser", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}