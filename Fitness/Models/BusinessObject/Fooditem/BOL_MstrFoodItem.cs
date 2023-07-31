using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.Fooditem
{
    public class BOL_MstrFoodItem
    {
        /// <summary>
        /// this class is used as input for inserting Fooditem
        /// </summary>
        public class InsertFooditem_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "dietTypeId(Integer) parameter is required.")]
            public int dietTypeId { get; set; }

            [Required(ErrorMessage = "foodItemName parameter is required")]
            public string foodItemName { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "unit(Integer) parameter is required.")]
            public int unit { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "servingIn(Integer) parameter is required.")]
            public int servingIn { get; set; }

            [Required(ErrorMessage = "protein (decimal) parameter is required")]
            public decimal protein { get; set; }

            [Required(ErrorMessage = "carbs (decimal) parameter is required")]
            public decimal carbs { get; set; }

            [Required(ErrorMessage = "fat (decimal) parameter is required")]
            public decimal fat { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "calories(Integer) parameter is required.")]
            public int calories { get; set; }

            public string imageUrl { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }

        /// <summary>
        /// this class is used as output for getting Fooditem ddl details
        /// </summary>
        public class GetFooditem_Out
        {
            public int foodItemId { get; set; }
            public int dietTypeId { get; set; }

            public string foodItemName { get; set; }
            public int unit { get; set; }
            public int servingIn { get; set; }
            public string servingInName { get; set; }
            public string unitName { get; set; }
            public Decimal protein { get; set; }
            public Decimal carbs { get; set; }
            public Decimal fat { get; set; }
            public int calories { get; set; }
            public string imageUrl { get; set; }
            public string activeStatus { get; set; }
        }


        /// <summary>
        /// this class is used as input for getting GetFooditem details
        /// </summary>
        public class GetFooditem_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting Fooditem ddl details
        /// </summary>
        public class ddlGetFooditem_Out
        {
            public int dietTypeId { get; set; }
            public int foodItemId { get; set; }            
            public string foodItemName { get; set; }
         
        }


        /// <summary>
        /// this class is used as input parameter for update Fooditem master
        /// </summary>
        public class UpdateFooditem_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "foodItemId(Integer) parameter is required.")]
            public int foodItemId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "dietTypeId(Integer) parameter is required.")]
            public int dietTypeId { get; set; }

            [Required(ErrorMessage = "foodItemName parameter is required")]
            public string foodItemName { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "unit(Integer) parameter is required.")]
            public int unit { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "servingIn(Integer) parameter is required.")]
            public int servingIn { get; set; }

            [Required(ErrorMessage = "protein (decimal) parameter is required")]
            public decimal protein { get; set; }
            [Required(ErrorMessage = "carbs (decimal) parameter is required")]
            public decimal carbs { get; set; }
            [Required(ErrorMessage = "fat (decimal) parameter is required")]
            public decimal fat { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "calories(Integer) parameter is required.")]
            public int calories { get; set; }
            public string imageUrl { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update Fooditem master
        /// </summary>
        public class ActivateOrInactivateFooditem_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "foodItemId(Integer) parameter is required.")]
            public int foodItemId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}