using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Fitness.Models.BusinessObject.UserFoodMenu
{
    public class BOL_UserFoodMenu
    {

        /// <summary>
        /// this class is used as input for getting UserFoodMenu details
        /// </summary>
        public class GetUserFoodMenu_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
            public int userId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "bookingId(Integer) parameter is required.")]
            public int bookingId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }

        }

        public class GetInsertUserFoodMenu_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
            public int userId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "bookingId(Integer) parameter is required.")]
            public int bookingId { get; set; }


            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "DietType(Integer) parameter is required.")]
            public int DietType { get; set; }


            [Required(ErrorMessage = "WakeUpTime parameter is required")]
            public string WakeUpTime { get; set; }

            [Required(ErrorMessage = "fromDate parameter is required")]
            public string fromDate { get; set; }

            [Required(ErrorMessage = "ToDate parameter is required")]
            public string ToDate { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "TotalCalories(Integer) parameter is required.")]
            public int TotalCalories { get; set; }


            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }


        }



        public class GetListUserFoodMenu_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
            public int userId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "bookingId(Integer) parameter is required.")]
            public int bookingId { get; set; }

            public string fromDate { get; set; }
            public int mealTypeId { get; set; }


            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }


        }


        public class GetListPublicUserFoodMenu_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
            public int userId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "bookingId(Integer) parameter is required.")]
            public int bookingId { get; set; }

            [Required(ErrorMessage = "fromDate parameter is required")]
            public DateTime fromDate { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }


        }


        public class GetListPublicUserFoodMenuBasedCategory_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
            public int userId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "bookingId(Integer) parameter is required.")]
            public int bookingId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
            public int categoryId { get; set; }

            [Required(ErrorMessage = "fromDate parameter is required")]
            public DateTime fromDate { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }

        }

        public class GetUserFoodMenu_OutNew
        {
            public int StatusCode { get; set; }
            public object UserFoodMenu { get; set; }
        }
        /// <summary>
        /// this class is used as input for inserting categorymstr
        /// </summary>
        public class InsertUserFoodMenu_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
            public int userId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "dietTimeId(Integer) parameter is required.")]
            public int dietTimeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "dietTypeId(Integer) parameter is required.")]
            public int dietTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "foodItemId(Integer) parameter is required.")]
            public int foodItemId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "bookingId(Integer) parameter is required.")]
            public int bookingId { get; set; }

            [Required(ErrorMessage = "foodItemName parameter is required")]
            public string foodItemName { get; set; }
            public string fromTime { get; set; }
            public string ToTime { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }

        public class UpdateUserFoodMenu_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Integer) parameter is required.")]
            public int uniqueId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "dietTimeId(Integer) parameter is required.")]
            public int dietTimeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "foodItemId(Integer) parameter is required.")]
            public int foodItemId { get; set; }
            public string fromTime { get; set; }
            public string ToTime { get; set; }
            public int UserfoodDietTimeId { get; set; }
            [Required(ErrorMessage = "foodItemName parameter is required")]
            public string foodItemName { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }

        }

        public class DeleteUserFoodMenu_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Integer) parameter is required.")]
            public int uniqueId { get; set; }
            public int UserFoodDietTimeId { get; set; }

        }


    }
}