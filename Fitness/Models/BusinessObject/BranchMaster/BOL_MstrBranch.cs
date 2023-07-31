using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Fitness.Models.BusinessObject.BranchMaster
{
    public static class BOL_MstrBranch
    {
        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetMstrBranch_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            //[Required]
            //[Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required")]
            public int gymOwnerId { get; set; }
            //[Required]
            //[Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
            public int branchId { get; set; }
        }


        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetMstrBranch_Out
        {
            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }
            public string shortName { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string district { get; set; }
            public string fromtime { get; set; }
            public string totime { get; set; }
            public string state { get; set; }
            public string city { get; set; }
            public string pincode { get; set; }
            public string primaryMobileNumber { get; set; }
            public string secondayMobilenumber { get; set; }
            public string emailId { get; set; }
            public string gstNumber { get; set; }
            public string activeStatus { get; set; }
            public string approvalStatus { get; set; }

        }



        /// <summary>
        /// this class is used to get the ddl input values
        /// </summary>
        public class ddlMstrBranch_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            //[Required]
            //[Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required")]
            public int gymOwnerId { get; set; }
            //[Required]
            //[Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
            public int branchId { get; set; }
        }


        /// <summary>
        /// this class is used to bind the ddl output values
        /// </summary>
        public class ddlMstrBranch_Out
        {
            public int branchId { get; set; }
            public string branchName { get; set; }
            public string image { get; set; }
        }



        /// <summary>
        /// this class is used as input for inserting Branchmaster
        /// </summary>
        public class InsertMstrBranch_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required(ErrorMessage = "Branch Name parameter is required")]
            public string branchName { get; set; }
            [Required(ErrorMessage = "Short Name parameter is required")]
            public string shortName { get; set; }
            [Required(ErrorMessage = "Latitude parameter is required")]
            public string latitude { get; set; }
            [Required(ErrorMessage = "Longitude parameter is required")]
            public string longitude { get; set; }
            [Required(ErrorMessage = "Address1 parameter is required")]
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string district { get; set; }

            [Required(ErrorMessage = "fromtime parameter is required")]
            public string fromtime { get; set; }

            [Required(ErrorMessage = "toTime parameter is required")]
            public string totime { get; set; }
            public string state { get; set; }
            public string city { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Pincode(Int) parameter is required.")]
            public int pincode { get; set; }
            [Required(ErrorMessage = "Primary Mobile Number parameter is required")]
            public string primaryMobileNumber { get; set; }
            public string secondayMobilenumber { get; set; }
            public string emailId { get; set; }
            public string gstNumber { get; set; }
            [Required(ErrorMessage = "Approval Status parameter is required")]
            public string approvalStatus { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }


        }

        /// <summary>
        /// this class is used as input for Updating Branchmaster
        /// </summary>
        public class UpdateMstrBranch_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required.")]
            public int branchId { get; set; }
            [Required(ErrorMessage = "Branch Name parameter is required")]
            public string branchName { get; set; }
            [Required(ErrorMessage = "Short Name parameter is required")]
            public string shortName { get; set; }
            [Required(ErrorMessage = "Latitude parameter is required")]
            public string latitude { get; set; }
            [Required(ErrorMessage = "Longitude parameter is required")]
            public string longitude { get; set; }
            [Required(ErrorMessage = "Address1 parameter is required")]
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string district { get; set; }
            [Required(ErrorMessage = "fromtime parameter is required")]
            public string fromtime { get; set; }
            [Required(ErrorMessage = "toTime parameter is required")]
            public string totime { get; set; }
            public string state { get; set; }
            public string city { get; set; }
            [Required(ErrorMessage = "Pincode parameter is required")]
            public string pincode { get; set; }
            [Required(ErrorMessage = "Primary Mobile Number parameter is required")]
            public string primaryMobileNumber { get; set; }
            public string secondayMobilenumber { get; set; }
            public string emailId { get; set; }
            public string gstNumber { get; set; }
            [Required(ErrorMessage = "Approval Status parameter is required")]
            public string approvalStatus { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }


        }

        /// <summary>
        /// this class is used as input parameter for update branch master
        /// </summary>
        public class ActivateOrInactivateMstrBranch_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Int) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update branch master
        /// </summary>
        public class UpdateApprovalStatusMstrBranch_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Int) parameter is required.")]
            public int updatedBy { get; set; }

            [Required(ErrorMessage = "Approval Status parameter is required")]
            public string approvalStatus { get; set; }

            public string cancellationReason { get; set; }

        }


        /// <summary>
        /// this class is used to get the ddl input values
        /// </summary>
        public class ownercourrentDayDetails_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required")]
            public int gymOwnerId { get; set; }
        }

        public class GetMstrBranchBasedOnLocation_In
        {
            public string lattitude { get; set; }
            public string longitude { get; set; }
            public string radius { get; set; }


            public class GetMstrBranchBasedOnLocation_Out
            {
                public int StatusCode { get; set; }
                public object Response { get; set; }
            }
        }
    }
}