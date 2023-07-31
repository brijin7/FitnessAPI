using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.PaymentCycles.BOL_PaymentCycles;
using Fitness.Helper;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Fitness.Models.DataAccessLayer.PaymentCycle
{
    public class DAL_PaymentCycle : SqlHelper
    {
        /// <summary>
        /// this method is used to Insert Paymentmaster details in db
        /// </summary>
        /// <param name="Input"> Insert Payment Master Class</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_InserttPaymentCyclesAsyc(InsertPaymentCycles_In Input)
        {
            try
            {

                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter bookingId = new SqlParameter
                {
                    ParameterName = "bookingId",
                    Value = Input.bookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
               
                SqlParameter userId = new SqlParameter
                {
                    ParameterName = "userId",
                    Value = Input.userId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter paidAmount = new SqlParameter
                {
                    ParameterName = "paidAmount",
                    Value = Input.paidAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50

                };
             
                SqlParameter paymentCyclesStatus = new SqlParameter
                {
                    ParameterName = "paymentCyclesStatus",
                    Value = Input.paymentCyclesStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1

                };
               
                SqlParameter transactionId = new SqlParameter
                {
                    ParameterName = "transactionId",
                    Value = Input.transactionId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                SqlParameter bankName = new SqlParameter
                {
                    ParameterName = "bankName",
                    Value = Input.bankName,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                SqlParameter bankReferenceNumber = new SqlParameter
                {
                    ParameterName = "bankReferenceNumber",
                    Value = Input.bankReferenceNumber,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int

                };
                SqlParameter[] allParameters = { queryType,userId,bookingId,
                            paidAmount,paymentCyclesStatus ,  transactionId,bankName
                            ,bankReferenceNumber,createdBy};
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync("usp_TranPaymentCycles", ListOfParameter);

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}