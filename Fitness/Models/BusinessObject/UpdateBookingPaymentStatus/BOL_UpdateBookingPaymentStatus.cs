using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.UpdateBookingPaymentStatus
{
    public class BOL_UpdateBookingPaymentStatus
    {
        public class UpdateBookingPaymentStatus_In
        {
            public Double PaidAmount { get; set; }
            public int BookingId { get; set; }
            public string PaymentStatus { get; set; }
            public string BankReferenceNumber { get; set; }
        }
    }
}