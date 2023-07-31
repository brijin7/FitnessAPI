using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.DashBoardForBranchAdmin
{
    public static class BOL_DashBoardForBranchAdmin
    {
        /// <summary>
        /// this class is used as input for GetBookingAndEnquiryCount QueryType    
        /// </summary>
        public class GetBookingAndEnquiryCount_In
        {
            [Required]
            [Range(0, int.MaxValue, ErrorMessage = "GymOwnerId Parameter Is Required.")]
            public int GymOwnerId { get; set; }
            [Required]
            [Range(0, int.MaxValue, ErrorMessage = "BarnchId Parameter Is Required.")]
            public int BranchId { get; set; }
            [Required(ErrorMessage = "FromDate Parameter Is Required.")]
            public string FromDate { get; set; }

            [Required(ErrorMessage = "ToDate Parameter Is Required.")]
            public string ToDate { get; set; } 
        }


        /// <summary>
        /// this class is used as input for GetBookingListBasedOnGymAndBranch QueryType    
        /// </summary>
        public class GetBookingListBasedOnGymAndBranch_In
        {
            [Required]
            [Range(0, int.MaxValue, ErrorMessage = "GymOwnerId Parameter Is Required.")]
            public int GymOwnerId { get; set; }
            [Required]
            [Range(0, int.MaxValue, ErrorMessage = "BarnchId Parameter Is Required.")]
            public int BranchId { get; set; }
            [Required(ErrorMessage = "FromDate Parameter Is Required.")]
            public string FromDate { get; set; }

            [Required(ErrorMessage = "ToDate Parameter Is Required.")]
            public string ToDate { get; set; }
        }

        /// <summary>
        /// this class is used as input for GetEnquiryListBasedOnGymAndBranch QueryType    
        /// </summary>
        public class GetEnquiryListBasedOnGymAndBranch_In
        {
            [Required]
            [Range(0, int.MaxValue, ErrorMessage = "GymOwnerId Parameter Is Required.")]
            public int GymOwnerId { get; set; }
            [Required]
            [Range(0, int.MaxValue, ErrorMessage = "BarnchId Parameter Is Required.")]
            public int BranchId { get; set; }
            [Required(ErrorMessage = "FromDate Parameter Is Required.")]
            public string FromDate { get; set; }

            [Required(ErrorMessage = "ToDate Parameter Is Required.")]
            public string ToDate { get; set; }
        }
    }
}