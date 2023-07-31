using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.PaymentUPI
{
    public class BOL_PaymentUPIDetails
    {

        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetPaymentUPIDetails_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public decimal gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public decimal branchId { get; set; }
        }
        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetPaymentUPIDetails_Out
        {
            public int StatusCode { get; set; }
            public object PaymentUPIDetails { get; set; }
        }


        /// <summary>
        /// this class is used to Insert the input values
        /// </summary>
        public class InsertPaymentUPIDetails_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public decimal gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "UPIId parameter is required")]
            public string UPIId { get; set; }

            public string name { get; set; }
            public string phoneNumber { get; set; }


            [Required(ErrorMessage = "merchantId parameter is required")]
            public string merchantId { get; set; }

            [Required(ErrorMessage = "merchantCode parameter is required")]
            public string merchantCode { get; set; }

            public string mode { get; set; }
            public string orgId { get; set; }
            public string sign { get; set; }
            public string url { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public string createdBy { get; set; }


        }

        /// <summary>
        /// this class is used to Insert the input values
        /// </summary>
        public class UpdatePaymentUPIDetails_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "paymentUPIDetailsId(Integer) parameter is required.")]
            public decimal paymentUPIDetailsId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public decimal gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "UPIId parameter is required")]
            public string UPIId { get; set; }

            public string name { get; set; }
            public string phoneNumber { get; set; }


            [Required(ErrorMessage = "merchantId parameter is required")]
            public string merchantId { get; set; }

            [Required(ErrorMessage = "merchantCode parameter is required")]
            public string merchantCode { get; set; }

            public string mode { get; set; }
            public string orgId { get; set; }
            public string sign { get; set; }
            public string url { get; set; }
            public string updatedBy { get; set; }

        }

        /// <summary>
        /// this class is used as input parameter for Active 
        /// </summary>
        public class ActivateOrInactivatePaymentUPIDetails_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "paymentUPIDetailsId(Integer) parameter is required.")]
            public int paymentUPIDetailsId { get; set; }
 
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

    }
}