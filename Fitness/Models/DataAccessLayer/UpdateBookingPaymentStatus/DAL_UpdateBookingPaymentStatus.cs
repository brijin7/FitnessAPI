using Fitness.Helper;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using static Fitness.Models.BusinessObject.UpdateBookingPaymentStatus.BOL_UpdateBookingPaymentStatus;

namespace Fitness.Models.DataAccessLayer.UpdateBookingPaymentStatus
{
    public class DAL_UpdateBookingPaymentStatus : SqlHelper
    {
        readonly string ProcedureName;
        public DAL_UpdateBookingPaymentStatus()
        {
            ProcedureName = "usp_TranUpdateBookingPaymentStatus";
        }
        /// <summary>
        /// this method is used to update Booking payment status
        /// </summary>
        /// <returns></returns>
        public async Task<DB_Response> UD_UpdatePaymentStatusAsync(UpdateBookingPaymentStatus_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "QueryType",
                    Value = "UpdateBookingPaymentStatus",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                };
                SqlParameter BookingId = new SqlParameter
                {
                    ParameterName = "BookingId",
                    Value = Input.BookingId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter PaidAmount = new SqlParameter
                {
                    ParameterName = "PaidAmount",
                    Value = Input.PaidAmount,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal,
                    Precision = 18,
                    Scale = 2
                };
                SqlParameter PaymentStatus = new SqlParameter
                {
                    ParameterName = "PaymentStatus",
                    Value = Input.PaymentStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                };
                SqlParameter BankReferenceNumber = new SqlParameter
                {
                    ParameterName = "BankReferenceNumber",
                    Value = Input.BankReferenceNumber,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                };

                SqlParameter[] allParameters = { QueryType, BookingId, PaidAmount, PaymentStatus, BankReferenceNumber };
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);
                return await ExecuteNonQueryAsync(ProcedureName, ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}