using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.CategoryMaster
{
    public class BOL_MstrCategory
    {
        /// <summary>
        /// this class is used as input for inserting categorymstr
        /// </summary>
        public class InsertCategory_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "categoryName parameter is required")]
            public string categoryName { get; set; }

            public string description { get; set; }

            public string imageUrl { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }

        /// <summary>
        /// this class is used as input for getting categorymstr details
        /// </summary>
        public class GetCategoryMstr_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting categorymstr details
        /// </summary>
        public class GetCategoryMstr_Out
        {
            public int categoryId { get; set; }
            public int gymOwnerId { get; set; }
            public string gymOwnerName { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }
            public string categoryName { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public string activeStatus { get; set; }
        }




        /// <summary>
        /// this class is used as input for getting ddl categorymstr details
        /// </summary>
        public class ddlCategoryMstr_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting ddl categorymstr details
        /// </summary>
        public class ddlCategoryMstr_Out
        {
            public int categoryId { get; set; }
            public string categoryName { get; set; }

        }


        /// <summary>
        /// this class is used as input for getting categorymstr details
        /// </summary>
        public class GetUserCategoryMstr_In
        {
           
            public int gymOwnerId { get; set; }

            public int branchId { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting categorymstr details
        /// </summary>
        public class GetuserCategoryMstr_Out
        {
            public int categoryId { get; set; }
            public int gymOwnerId { get; set; }
            public string gymOwnerName { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }
            public string categoryName { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public string activeStatus { get; set; }
            public string actualAmount { get; set; }
            public string displayAmount { get; set; }
            public string SavedAmount { get; set; }           
        }


        /// <summary>
        /// this class is used as input parameter for updatecategory master
        /// </summary>
        public class UpdateCategoryMstr_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
            public int categoryId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "categoryName parameter is required")]
            public string categoryName { get; set; }

            public string description { get; set; }

            public string imageUrl { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for activateorinactivatecategory master
        /// </summary>
        public class ActivateOrInactivateCategoryMstr_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
            public int categoryId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}