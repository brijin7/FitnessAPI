using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.PaymentCycles
{
    public static class BOL_PaymentCycles
    {
        /// this class is used as input for inserting PaymentMaster
        /// </summary>
        public class InsertPaymentCycles_In
        {                          
         
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "bookingId(Int) parameter is required.")]
            public int bookingId { get; set; }
            public int userId { get; set; }

            [Required(ErrorMessage = "paidAmount parameter is required")]
            public string paidAmount { get; set; }

            [Required(ErrorMessage = "paymentStatus parameter is required")]
            public string paymentCyclesStatus { get; set; }

            public string transactionId { get; set; }
            public string bankName { get; set; }
            public string bankReferenceNumber { get; set; }
            public int createdBy { get; set; }


        }
    }
}