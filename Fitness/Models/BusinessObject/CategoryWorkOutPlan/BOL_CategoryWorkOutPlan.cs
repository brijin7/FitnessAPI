using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.CategoryWorkOutPlan
{
    public class BOL_CategoryWorkOutPlan
    {
        /// <summary>
        /// this class is used as input for inserting CategoryWorkOutPlan
        /// </summary>

        public class InsertCategoryWorkOutPlan_In
        {
            [Required(ErrorMessage = "CategoryWorkOutPlan lists is required")]
            public List<CategoryWorkOutPlans> lstWorkOutFoodMenu { get; set; }
        }
        public class CategoryWorkOutPlans
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutCatTypeId(Integer) parameter is required.")]
            public int workoutCatTypeId { get; set; }

            [Required(ErrorMessage = "workoutTypeId parameter is required")]
            public int workoutTypeId { get; set; }

            [Required(ErrorMessage = "categoryId parameter is required")]
            public int categoryId { get; set; }

            [Required(ErrorMessage = "ActiveStatus parameter is required")]
            public string activeStatus { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }

        public class UpdateCategoryWorkOutPlan
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Integer) parameter is required.")]
            public int uniqueId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutCatTypeId(Integer) parameter is required.")]
            public int workoutCatTypeId { get; set; }

            [Required(ErrorMessage = "workoutTypeId parameter is required")]
            public int workoutTypeId { get; set; }

            [Required(ErrorMessage = "categoryId parameter is required")]
            public int categoryId { get; set; }
            [Required(ErrorMessage = "ActiveStatus parameter is required")]
            public string activeStatus { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }

        }

        public class CategoryWorkOutPlan_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
            [Required(ErrorMessage = "categoryId parameter is required")]
            public int categoryId { get; set; }
        }
        public class CategoryWorkOut_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

        }


        /// <summary>
        /// this class is used as input parameter for update CategoryWorkOutPlan master
        /// </summary>
        public class UpdateCategoryWorkOutPlan_In
        {

            [Required(ErrorMessage = "CategoryWorkOutPlan lists is required")]
            public List<UpdateCategoryWorkOutPlan> lstWorkOutFoodMenu { get; set; }
        }

        public class CategoryWorkOutPlan_Out
        {
            public int StatusCode { get; set; }
            public object CategoryWorkOutPlan { get; set; }
        }
    }
}