using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.Fooditem
{
    public class BOL_MstrFoodDietTime
    {
        /// <summary>
        /// this class is used as input for inserting FoodDietTime
        /// </summary>
        /// 


           public class InsertFoodDietTime_In
        {
            [Required(ErrorMessage = "FoodDietTime lists is required")]
            public List<FoodDietTime> lstFoodDietTime { get; set; }
        }
        public class FoodDietTime
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "mealType(Integer) parameter is required.")]
            public int mealType { get; set; }

            [Required(ErrorMessage = "foodItemId parameter is required")]
            public int foodItemId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }

        /// this class is used as output for getting FoodDietTime details
        /// </summary>
        public class GetFoodDietTime_Out
        {
            public int uniqueId { get; set; }
            public int foodItemId { get; set; }
            public string foodItemName { get; set; }
            public string mealType { get; set; }
            public string mealTypeName { get; set; }
            public string activeStatus { get; set; }
        }

        /// <summary>
        /// this class is used as output for getting FoodDietTime details
        /// </summary>
        public class ddlFoodDietTime_Out
        {
            public string uniqueId { get; set; }
            public string mealTypeName { get; set; }
        }


        /// <summary>
        /// this class is used as output for getting FoodDietTime details
        /// </summary>
        /// 


        public class FoodDietTime_In
        { 
            public int foodItemId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
        }


        public class FoodDietTime_OutNew
        {
            public int StatusCode { get; set; }
            public object FoodDietTime { get; set; }
        }
        public class FoodDietTime_Out
        {
            public int uniqueId { get; set; }
            public int foodItemId { get; set; }
            public string foodItemName { get; set; }
            public string mealType { get; set; }
            public string mealTypeName { get; set; }
            public string activeStatus { get; set; }
        }


        /// <summary>
        /// this class is used as input parameter for update FoodDietTime master
        /// </summary>
        public class UpdateFoodDietTime_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Integer) parameter is required.")]
            public int uniqueId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "mealType(Integer) parameter is required.")]
            public int mealType { get; set; }

            [Required(ErrorMessage = "foodItemId parameter is required")]
            public int foodItemId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update FoodDietTime master
        /// </summary>
        public class ActivateOrInactivateFoodDietTime_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Integer) parameter is required.")]
            public int uniqueId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input for inserting FoodDietTime
        /// </summary>
        public class GetMealtypebasedFoodItem_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "mealType(Integer) parameter is required.")]
            public int mealType { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

        }
        /// <summary>
        /// this class is used as input for inserting FoodDietTime
        /// </summary>
        public class GetFoodDietTime_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

        }
    }
}