using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.SubscriptionBooking
{
    public static class BOL_SubscriptionBooking
    {

        /// this class is used as input for inserting SubscriptionBookingMaster
        /// </summary>
        public class InsertSubscriptionBooking_In
        {
            [Required(ErrorMessage = "queryType parameter is required")]
            public string queryType { get; set; }
            public int subBookingId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Branch Id(Int) parameter is required.")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "Branch Name parameter is required")]
            public string branchName { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "subscriptionPlanId (Int) parameter is required.")]
            public int subscriptionPlanId { get; set; }
            
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(int) parameter is required")]
            public int userId { get; set; }
            [Required(ErrorMessage = "booking parameter is required")]
            public string booking { get; set; }
            [Required(ErrorMessage = "loginType parameter is required")]
            public string loginType { get; set; }

            [Required(ErrorMessage = "price parameter is required")]
            public decimal price { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "taxId(Int) parameter is required.")]
            public int taxId { get; set; }

            [Required(ErrorMessage = "taxName parameter is required")]
            public string taxName { get; set; }
            [Required(ErrorMessage = "taxAmount parameter is required")]
            public decimal taxAmount { get; set; }
            [Required(ErrorMessage = "totalAmount parameter is required")]
            public decimal totalAmount { get; set; }

            [Required(ErrorMessage = "paidAmount parameter is required")]
            public decimal paidAmount { get; set; }

            [Required(ErrorMessage = "paymentStatus parameter is required")]
            public string paymentStatus { get; set; }


            [Required(ErrorMessage = "paymentType parameter is required")]
            public int paymentType { get; set; }
            public string transactionId { get; set; }
            public string bankName { get; set; }
            public string bankReferenceNumber { get; set; }
            public int offerId { get; set; }
            public decimal offerAmount { get; set; }

            //public string cancellationStatus { get; set; }
            //public string refundStatus { get; set; }
            //public string cancellationCharges { get; set; }
            //public string refundAmt { get; set; }
            //public string cancellationReason { get; set; }

            public int createdBy { get; set; }


        }

        /// <summary>
        /// this class is used as input for getting SubspBooking details
        /// </summary>
        public class GetUserSubspBooking_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
            public int userId { get; set; }
        }

        /// <summary>
        /// this class is used as input for getting SubspBooking details
        /// </summary>
        public class GetBranchOwnerSubspBooking_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting SubspBooking details
        /// </summary>
        public class GetSubspBooking_Out
        {
            public int subBookingId { get; set; }
            public int gymOwnerId { get; set; }
            public string gymOwnerName { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }
            public int subscriptionPlanId { get; set; }
            public string packageName { get; set; }
            public string noOfDays { get; set; }
            public string noOfTrialDays { get; set; }
            public string netAmount { get; set; }
            public string amount { get; set; }
            public string isTrialAvailable { get; set; }

            public string tax { get; set; }
            public int userId { get; set; }
            public string UserName { get; set; }
            public string booking { get; set; }
            public string loginType { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public string price { get; set; }
            public int taxId { get; set; }
            public string taxName { get; set; }
            public string taxAmount { get; set; }
            public int offerId { get; set; }
            public string offerAmount { get; set; }
            public string totalAmount { get; set; }
            public string paidAmount { get; set; }
            public string paymentStatus { get; set; }
            public string paymentType { get; set; }
            public string cancellationStatus { get; set; }
            public string refundStatus { get; set; }
            public string cancellationCharges { get; set; }
            public string refundAmt { get; set; }
            public string cancellationReason { get; set; }
            public string bookingDate { get; set; }
            public string cgstTax { get; set; }
            public string sgstTax { get; set; }

        }

        /// <summary>
        /// this class is used as input for getting SubspBooking details
        /// </summary>
        public class GetBookingIdSubspBooking_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "BookingId(Integer) parameter is required.")]
            public int BookingId { get; set; }
        }
    }
}