using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.CategoryBenefit
{
    public class BOL_MstrCategoryBenefit
    {
        /// <summary>
        /// this class is used as input for inserting CategoryBenefitmstr
        /// </summary>
        public class InsertCategoryBenefit_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
            public int categoryId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "type(Integer) parameter is required.")]
            public int type { get; set; }

            [Required(ErrorMessage = "description parameter is required")]
            public string description { get; set; }

            public string imageUrl { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }

        /// <summary>
        /// this class is used as input for getting CategoryBenefitmstr details
        /// </summary>
        public class GetCategoryBenefitMstr_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "CategoryId(Integer) parameter is required.")]
            public string CategoryId { get; set; }
        }

        public class ddlCategoryBenefitMstr_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
        }
        public class CategoryBenefitBasedOnType
        {
            public int categoryId { get; set; }
            public int branchId { get; set; }
            public string typeName { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting CategoryBenefitmstr details
        /// </summary>
        public class GetCategoryBenefitMstr_Out
        {
            public int uniqueId { get; set; }
            public int categoryId { get; set; }
            public string categoryName { get; set; }
            public int type { get; set; }
            public string BenefitName { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public string activeStatus { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for updatecategory master
        /// </summary>
        public class UpdateCategoryBenefitMstr_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Integer) parameter is required.")]
            public int uniqueId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
            public int categoryId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "type(Integer) parameter is required.")]
            public int type { get; set; }

            [Required(ErrorMessage = "description parameter is required")]
            public string description { get; set; }

            public string imageUrl { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for activateorinactivateCategoryBenefit master
        /// </summary>
        public class ActivateOrInactivateCategoryBenefitMstr_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string QueryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Integer) parameter is required.")]
            public int uniqueId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}