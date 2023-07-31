using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.BookingReport
{
    public static class BOL_RptBookingReport
    {
        /// <summary>
        /// this method is used as input for GetBookingReport
        /// </summary>
        public class GetBookingReport_In
        {
            public string QueryType { get; set; }
            public int BranchId { get; set; }
            public int GymOwnerId { get; set; }
            public int CategoryId { get; set; }
            [Required(ErrorMessage = "fromDate parameter is required")]
            public string FromDate { get; set; }

            [Required(ErrorMessage = "toDate parameter is required")]
            public string ToDate { get; set; }
        }
        /// <summary>
        /// this method is used as output for GetBookingReport
        /// </summary>
        public class GetBookingReport_Out
        {
            public int bookingId { get; set; }
            public string bookingDate { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }
            public int gymOwnerId { get; set; }
            public string gymName { get; set; }
            public int categoryId { get; set; }
            public string categoryName { get; set; }
            public string trainingMode { get; set; }
            public int trainingTypeId { get; set; }
            public string description { get; set; }
            public int userId { get; set; }
            public string userName { get; set; }
            public string phoneNumber { get; set; }
            public decimal price { get; set; }
            public int taxId { get; set; }
            public decimal taxAmount { get; set; }
            public int offerId { get; set; }
            public decimal offerAmount { get; set; }
            public int paymentType { get; set; }
            public string paymentTypeName { get; set; }
        }
    }
}