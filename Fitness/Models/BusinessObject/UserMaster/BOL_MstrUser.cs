using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Fitness.Models.BusinessObject.UserMaster
{
    public static class BOL_MstrUser
    {
        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetMstrUserList_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "User Id parameter is required")]
            public int userId { get; set; }
           
        }
        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetMstrUserList_Out
        {
            public int userId { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string gender { get; set; }
            public string addressLine1 { get; set; }
            public string addressLine2 { get; set; }
            public string district { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string zipcode { get; set; }
            public string maritalStatus { get; set; }
            public string dob { get; set; }
            public string mobileNo { get; set; }
            public string photoLink { get; set; }
            //public string password { get; set; }
            public string mailId { get; set; }
            public string roleId { get; set; }
            public string roleName { get; set; }
            public string activeStatus { get; set; }
            
        }

        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetMstrAdminUserList_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId parameter is required")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId parameter is required")]
            public int branchId { get; set; }

            public string followUpStatusId { get; set; }

        }
        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetMstrAdminUserList_Out
        {
            public int userId { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string gender { get; set; }
            public string addressLine1 { get; set; }
            public string addressLine2 { get; set; }
            public string district { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string zipcode { get; set; }
            public string maritalStatus { get; set; }
            public string dob { get; set; }
            public string mobileNo { get; set; }
            public string photoLink { get; set; }
            public string mailId { get; set; }
            public string roleId { get; set; }
            public string roleName { get; set; }
            public string activeStatus { get; set; }
            public string rewardPoints { get; set; }
            public string rewardUtilized { get; set; }
            public string promoNotification { get; set; }
            public string enquiryReason { get; set; }
            public string enquirydate { get; set; }
            public string followUpMode { get; set; }
            public string followUpModeName { get; set; }
            public string followUpStatus { get; set; }
            public string followUpStatusName { get; set; }           


        }
        /// <summary>
        /// this class is used as input for updating Profile For User
        /// </summary>
        /// <summary>
        /// this class is used as input for updating Profile For User
        /// </summary>

        public class UpdateMstrUserProfile_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "UserId(Int) parameter is required.")]
            public int userId { get; set; }
           
            [Required(ErrorMessage = "FirstName parameter is required")]
            public string firstName { get; set; }

          
            public string lastName { get; set; }
            
            [Required(ErrorMessage = "Gender parameter is required")]
            public string gender { get; set; }

            public string addressLine1 { get; set; }
            public string addressLine2 { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Zipcode(Int) parameter is required.")]
            public int zipcode { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string state { get; set; }
            public string maritalStatus { get; set; }
            [Required(ErrorMessage = "Date Of Birth parameter is required")]
            public string dob { get; set; }

            [Required(ErrorMessage = "Mobile Number parameter is required")]
            public string mobileNo { get; set; }

            //[Required(ErrorMessage = "Password parameter is required")]
            //public string passWord { get; set; }

           
            public string photoLink { get; set; }
            public string mailId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }


        }

        /// <summary>
        /// this class is used as input for  Insert Profile For User
        /// </summary>
        /// <summary>
        /// this class is used as input for  Insert Profile For User
        /// </summary>

        public class InserteMstrUserProfile_In
        {

            [Required(ErrorMessage = "FirstName parameter is required")]
            public string firstName { get; set; }

            public string lastName { get; set; }

            [Required(ErrorMessage = "Gender parameter is required")]
            public string gender { get; set; }

            public string addressLine1 { get; set; }
            public string addressLine2 { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Zipcode(Int) parameter is required.")]
            public int zipcode { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string state { get; set; }
            public string maritalStatus { get; set; }
            [Required(ErrorMessage = "Date Of Birth parameter is required")]
            public string dob { get; set; }

            [Required(ErrorMessage = "Mobile Number parameter is required")]
            public string mobileNo { get; set; }          

            
            public string photoLink { get; set; }
            [Required(ErrorMessage = "mailId parameter is required")]
            public string mailId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
            public int rewardPoints { get; set; }
            public int rewardUtilized { get; set; }
            public string promoNotification { get; set; }
            public string enquiryReason { get; set; }
            public string enquirydate { get; set; }
            public int followUpMode { get; set; }
            public int followUpStatus { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public string createdBy { get; set; }

        }

        /// <summary>
        /// this class is used as input for updating Profile For User
        /// </summary>
        /// <summary>
        /// this class is used as input for updating Profile For User
        /// </summary>

        public class UpdateMstrAdminUserProfile_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "UserId(Int) parameter is required.")]
            public int userId { get; set; }

            [Required(ErrorMessage = "FirstName parameter is required")]
            public string firstName { get; set; }

          
            public string lastName { get; set; }

            [Required(ErrorMessage = "Gender parameter is required")]
            public string gender { get; set; }

            public string addressLine1 { get; set; }
            public string addressLine2 { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Zipcode(Int) parameter is required.")]
            public int zipcode { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string state { get; set; }
            public string maritalStatus { get; set; }
            [Required(ErrorMessage = "Date Of Birth parameter is required")]
            public string dob { get; set; }

            [Required(ErrorMessage = "Mobile Number parameter is required")]
            public string mobileNo { get; set; }
           
            public string photoLink { get; set; }
            public string mailId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
            public int rewardPoints { get; set; }
            public int rewardUtilized { get; set; }
            public string promoNotification { get; set; }
            public string enquiryReason { get; set; }
            public string enquirydate { get; set; }
            public int followUpMode { get; set; }
            public int followUpStatus { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }


        }

        public class UpdateMstrregistrationToken_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "UserId(Int) parameter is required.")]
            public int userId { get; set; }

            [Required(ErrorMessage = "registrationToken parameter is required")]
            public string registrationToken { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }


        }

    }
}