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
using static Fitness.Models.BusinessObject.PaymentUPI.BOL_PaymentUPIDetails;

namespace Fitness.Models.DataAccessLayer.PaymentUPI
{
    public class DAL_PaymentUPIDetails : SqlHelper
    {
        /// <summary>
        /// this method is used to fetch FitnessCatogoryPrice  details from db
        /// </summary>
        /// <param name="Input">GetPriceDetails_In class as input parameter</param>
        /// <returns>list of GetPriceDetails_Out as output</returns>

        public async Task<string> GetPaymentUPIDetailsAsync(GetPaymentUPIDetails_In Input)
        {
            try
            {
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

                SqlParameter[] allParameters = { gymOwnerId, branchId};


                DataTable dt = await GetDataTableFromUSPAsync("GetPaymentUPIDetails", allParameters);

                return dt.Rows[0]["PaymentUPIDetails"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to Insert  Payment UPI Details in db
        /// </summary>
        /// <param name="Input"> InsertPaymentUPIDetails_In</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InsertPaymentUPIDetailsAsync(InsertPaymentUPIDetails_In Input)
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
                SqlParameter name = new SqlParameter
                {
                    ParameterName = "name",
                    Value = Input.name,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter phoneNumber = new SqlParameter
                {
                    ParameterName = "phoneNumber",
                    Value = Input.phoneNumber,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter UPIId = new SqlParameter
                {
                    ParameterName = "UPIId",
                    Value = Input.UPIId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter merchantId = new SqlParameter
                {
                    ParameterName = "merchantId",
                    Value = Input.merchantId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                   
                };
                SqlParameter merchantCode = new SqlParameter
                {
                    ParameterName = "merchantCode",
                    Value = Input.merchantCode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter mode = new SqlParameter
                {
                    ParameterName = "mode",
                    Value = Input.mode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter orgId = new SqlParameter
                {
                    ParameterName = "orgId",
                    Value = Input.orgId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter sign = new SqlParameter
                {
                    ParameterName = "sign",
                    Value = Input.sign,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter url = new SqlParameter
                {
                    ParameterName = "url",
                    Value = Input.url,
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
                SqlParameter[] allParameters = { queryType, gymOwnerId,branchId,name,phoneNumber,
                    UPIId,merchantId, merchantCode, mode, orgId,sign, url, createdBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_paymentUPIDetails", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to Update  Payment UPI Details in db
        /// </summary>
        /// <param name="Input"> UpdatePaymentUPIDetails_In</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdatePaymentUPIDetailsAsync(UpdatePaymentUPIDetails_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100
                };
                SqlParameter paymentUPIDetailsId = new SqlParameter
                {
                    ParameterName = "paymentUPIDetailsId",
                    Value = Input.paymentUPIDetailsId,
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
                SqlParameter name = new SqlParameter
                {
                    ParameterName = "name",
                    Value = Input.name,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter phoneNumber = new SqlParameter
                {
                    ParameterName = "phoneNumber",
                    Value = Input.phoneNumber,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter UPIId = new SqlParameter
                {
                    ParameterName = "UPIId",
                    Value = Input.UPIId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter merchantId = new SqlParameter
                {
                    ParameterName = "merchantId",
                    Value = Input.merchantId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,

                };
                SqlParameter merchantCode = new SqlParameter
                {
                    ParameterName = "merchantCode",
                    Value = Input.merchantCode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter mode = new SqlParameter
                {
                    ParameterName = "mode",
                    Value = Input.mode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter orgId = new SqlParameter
                {
                    ParameterName = "orgId",
                    Value = Input.orgId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter sign = new SqlParameter
                {
                    ParameterName = "sign",
                    Value = Input.sign,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter url = new SqlParameter
                {
                    ParameterName = "url",
                    Value = Input.url,
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
                SqlParameter[] allParameters = { queryType,paymentUPIDetailsId, gymOwnerId,branchId,name,phoneNumber,
                    UPIId,merchantId, merchantCode, mode, orgId,sign, url, updatedBy };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_paymentUPIDetails", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to activate and inactivate PaymentUPIDetails master
        /// </summary>
        /// <param name="Input">ActivateOrInactivatePaymentUPIDetails_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateMstrFitnessCategoryPriceAsyc(ActivateOrInactivatePaymentUPIDetails_In Input)
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
                SqlParameter paymentUPIDetailsId = new SqlParameter
                {
                    ParameterName = "paymentUPIDetailsId",
                    Value = Input.paymentUPIDetailsId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { queryType, paymentUPIDetailsId,  updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_paymentUPIDetails", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}