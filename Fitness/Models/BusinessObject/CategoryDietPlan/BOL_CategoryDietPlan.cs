using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.CategoryDietPlan
{
    public class BOL_CategoryDietPlan
    { /// <summary>
      /// this class is used as input for inserting CategoryDietPlan
      /// </summary>

        public class InsertCategoryDietPlan_In
        {
            [Required(ErrorMessage = "CategoryDietPlan lists is required")]
            public List<CategoryDietPlans> lstWorkOutFoodMenu { get; set; }
        }
        public class CategoryDietPlans
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "mealTypeId(Integer) parameter is required.")]
            public int mealTypeId { get; set; }

            [Required(ErrorMessage = "foodItemId parameter is required")]
            public int foodItemId { get; set; }

            [Required(ErrorMessage = "dietTimeId parameter is required")]
            public int dietTimeId { get; set; }

            [Required(ErrorMessage = "categoryId parameter is required")]
            public int categoryId { get; set; }

            [Required(ErrorMessage = "ActiveStatus parameter is required")]
            public string activeStatus { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }

        public class UpdateCategoryDietPlan
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
            [Range(1, int.MaxValue, ErrorMessage = "mealTypeId(Integer) parameter is required.")]
            public int mealTypeId { get; set; }

            [Required(ErrorMessage = "foodItemId parameter is required")]
            public int foodItemId { get; set; }

            [Required(ErrorMessage = "dietTimeId parameter is required")]
            public int dietTimeId { get; set; }

            [Required(ErrorMessage = "categoryId parameter is required")]
            public int categoryId { get; set; }
            [Required(ErrorMessage = "ActiveStatus parameter is required")]
            public string activeStatus { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }

        }

        public class CategoryDietPlan_In
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
        public class Category_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
          
        }


        /// <summary>
        /// this class is used as input parameter for update CategoryDietPlan master
        /// </summary>
        public class UpdateCategoryDietPlan_In
        {

            [Required(ErrorMessage = "CategoryDietPlan lists is required")]
            public List<UpdateCategoryDietPlan> lstWorkOutFoodMenu { get; set; }
        }

        public class CategoryDietPlan_Out
        {
            public int StatusCode { get; set; }
            public object CategoryDietPlan { get; set; }
        }


    }
}