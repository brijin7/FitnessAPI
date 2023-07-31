using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.MealTimeConfig
{
    public class BOL_MstrMealTimeConfig
    {
        public class InsertMealTimeConfig_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "mealType(Integer) parameter is required.")]
            public int mealTypeId { get; set; }

            [Required(ErrorMessage = "timeInHrs parameter is required")]
            public int timeInHrs { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }
        public class UpdateMealTimeConfig_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Integer) parameter is required.")]
            public int uniqueId { get; set; } 
            [Required]

            [Range(1, int.MaxValue, ErrorMessage = "mealType(Integer) parameter is required.")]
            public int mealTypeId { get; set; }

            [Required(ErrorMessage = "timeInHrs parameter is required")]
            public int timeInHrs { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }

        }
        public class MealTimeConfig_Out
        {
            public int uniqueId { get; set; }
            public int mealTypeId { get; set; }
            public string mealTypeName { get; set; }
            public int timeInHrs { get; set; }
        }

        /// <summary>
        /// this class is used as input for getting MealTimeConfig details
        /// </summary>
        public class MealTimeConfig_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
        }
    }
}