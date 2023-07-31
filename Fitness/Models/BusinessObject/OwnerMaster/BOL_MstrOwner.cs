using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Fitness.Models.BusinessObject.OwnerMaster
{
    /// <summary>
    /// Summary description for BOL_MstrOwner
    /// </summary>
    public static class BOL_MstrOwner
    {
        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetMstrIndividualOwner_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
        }
      
        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetMstrOwner_Out
        {
            public int gymOwnerId { get; set; }
            public string gymName { get; set; }
            public string shortName { get; set; }
            public string gymOwnerName { get; set; }
            public string mobileNumber { get; set; }
            public string mailId { get; set; }
            public string passWord { get; set; }
            public string logoUrl { get; set; }
            public string websiteUrl { get; set; }
            public string activeStatus { get; set; }
        }

        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetddlMstrOwner_Out
        {
            public int gymOwnerId { get; set; }
            public string gymOwnerName { get; set; }
        }

        /// <summary>
        /// this class is used as input for inserting configmaster
        /// </summary>
        public class InsertMstrOwner_In
        {

            [Required(ErrorMessage = "Gym Name parameter is required")]
            public string gymName { get; set; }

            [Required(ErrorMessage = "Short Name parameter is required")]
            public string shortName { get; set; }

            [Required(ErrorMessage = "Gym Owner Name parameter is required")]
            public string gymOwnerName { get; set; }

            [Required(ErrorMessage = "Mobile Number parameter is required")]
            public string mobileNumber { get; set; }

            [Required(ErrorMessage = "Password parameter is required")]
            public string passWord { get; set; }

            public string mailId { get; set; }
            public string logoUrl { get; set; }
            public string websiteUrl { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }
        /// <summary>
        /// this class is used as input parameter for updateconfig master
        /// </summary>
        public class UpdateMstrOwner_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required(ErrorMessage = "Gym Name parameter is required")]
            public string gymName { get; set; }

            [Required(ErrorMessage = "Short Name parameter is required")]
            public string shortName { get; set; }

            [Required(ErrorMessage = "Gym Owner Name parameter is required")]
            public string gymOwnerName { get; set; }

            [Required(ErrorMessage = "Mobile Number parameter is required")]
            public string mobileNumber { get; set; }

            [Required(ErrorMessage = "Password parameter is required")]
            public string passWord { get; set; }
            public string mailId { get; set; }
            public string logoUrl { get; set; }
            public string websiteUrl { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for updateconfig master
        /// </summary>
        public class ActivateOrInactivateMstrOwner_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}

