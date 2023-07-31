using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.TaxMaster
{
    public static class BOL_mstrTax
    {
        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetmstrTax_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
            public int branchId { get; set; }
        }
     
        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetmstrTax_Out
        {
            public int uniqueId { get; set; }
            public int taxId { get; set; }
            public int branchId { get; set; }
            public int gymOwnerId { get; set; }
            public string serviceId { get; set; }
            public string serviceName { get; set; }
            public string taxDescription { get; set; }
            public string taxPercentage { get; set; }
            public string effectiveFrom { get; set; }
            public string effectiveTill { get; set; }
            public string activeStatus { get; set; }
        }


        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetddlmstrTax_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
            public int branchId { get; set; }
        }

        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetddlmstrTax_Out
        {
            public int taxId { get; set; }
            public string taxDetails { get; set; }
        }

        /// <summary>
        /// this class is used as input for Adding TaxMaster
        /// </summary>
        public class AddmstrTax_In
        {
          

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "BranchId(Int) parameter is required")]
            public int branchId { get; set; }
            [Required(ErrorMessage = "Service Name parameter is required")]
            public string serviceName { get; set; }
            [Required(ErrorMessage = "Tax Description parameter is required")]
            public string taxDescription { get; set; }
            [Required(ErrorMessage = "Effective From parameter is required")]
            public string effectiveFrom { get; set; }
            [Required(ErrorMessage = "Tax Percentage  parameter is required")]
            public string taxPercentage { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }


        }

        /// <summary>
        /// this class is used as input for Updating TaxMaster
        /// </summary>
        public class UpdatemstrTax_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Integer) parameter is required.")]
            public int uniqueId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "BranchId(Int) parameter is required")]
            public int branchId { get; set; }
            [Required(ErrorMessage = "Service Name parameter is required")]
            public string serviceName { get; set; }
            [Required(ErrorMessage = "Tax Description parameter is required")]
            public string taxDescription { get; set; }
            [Required(ErrorMessage = "Effective From parameter is required")]
            public string effectiveFrom { get; set; }
            [Required(ErrorMessage = "Tax Percentage  parameter is required")]
            public string taxPercentage { get; set; }

        }

        /// <summary>
        /// this class is used as input for Deleting TaxMaster
        /// </summary>
        public class DeletemstrTax_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Integer) parameter is required.")]
            public int uniqueId { get; set; }

        }

        /// <summary>
        /// this class is used as input for inserting TaxMaster
        /// </summary>
        public class InsertmstrTax_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "BranchId(Int) parameter is required")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "Service Name parameter is required")]
            public string serviceName { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input for inserting TaxMaster
        /// </summary>
        public class UpdateTaxId_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

        }

    }
}