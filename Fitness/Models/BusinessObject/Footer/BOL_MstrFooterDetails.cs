using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.Footer
{
    public class BOL_MstrFooterDetails
    {

        public class InsertFooter_In
        {

            [Required(ErrorMessage = "Icons parameter is required")]
            public string icons { get; set; }

            [Required(ErrorMessage = "Description parameter is required")]
            public string description { get; set; }

            [Required(ErrorMessage = "Link parameter is required")]
            public string link { get; set; }


            [Required(ErrorMessage = "DisplayType parameter is required")]
            public int displayType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]

            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }

        public class GetFooter_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
            public char displayType { get; set; }

        }

        public class GetFooter_Out
        {
            public int FooterDetailsId { get; set; }
            public string icons { get; set; }
            public string description { get; set; }
            public string link { get; set; }
            public int displayType { get; set; }
            public string displayTypeName { get; set; }
            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
            public string activeStatus { get; set; }
            public int createdBy { get; set; }

        }

        public class UpdateFooter_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "FooterDetailsId(Integer) parameter is required.")]
            public int FooterDetailsId { get; set; }

            [Required(ErrorMessage = "Icons parameter is required")]
            public string icons { get; set; }

            [Required(ErrorMessage = "Description parameter is required")]
            public string description { get; set; }

            [Required(ErrorMessage = "Link parameter is required")]
            public string link { get; set; }


            [Required(ErrorMessage = "DisplayType parameter is required")]
            public int displayType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]

            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }

        }

        public class ActivateOrInactivateFooter_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "FooterDetailsId(Integer) parameter is required.")]
            public int FooterDetailsId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}