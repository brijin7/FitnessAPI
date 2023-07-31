using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Fitness.Models.BusinessObject.UserWorkOutPlanandDietPlan
{
    public class BOL_UserWorkOutPlanandDietPlan
    {
        /// this class is used as input for inserting EmployeeMaster
        /// </summary>
        public class GetUserBookingDetailsDept_In
        {
           
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Branch Id(Int) parameter is required.")]
            public int branchId { get; set; }

        }
        public class GetUserBookingDetailsBasedOnType_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Branch Id(Int) parameter is required.")]
            public int branchId { get; set; }
            [Required(ErrorMessage = "date parameter is required")]
            public string date { get; set; }

            [Required(ErrorMessage = "type parameter is required")]
            public string type { get; set; }

        }

        public class GetUserBookingDetailsBasedOnUserId_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required.")]
            public int userId { get; set; }
        }
        public class GetUserBookingDetailsDept_Out
        { 
            public int bookingId { get; set; }
            public string TDEE { get; set; }
            public int userId { get; set; }
            public string userName { get; set; }
            public string phoneNumber { get; set; }
            public string mailId { get; set; }
            public int categoryId { get; set; }
            public string categoryName { get; set; }
            public int trainingTypeId { get; set; }
            public string trainingTypeName { get; set; }
            public int planDuration { get; set; }
            public string planDurationName { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public string approvedStatus { get; set; }
            public string paymentStatus { get; set; }
            public string PlanGeneareted { get; set; }
            public string PlanGenearetedDiet { get; set; }
        }


        public class GetUserBookingDetailsUser_Out
        {
            public int bookingId { get; set; }
            public string TDEE { get; set; }
            public int userId { get; set; }
            public string userName { get; set; }
            public string phoneNumber { get; set; }
            public string mailId { get; set; }
            public int categoryId { get; set; }
            public string categoryName { get; set; }
            public int trainingTypeId { get; set; }
            public string trainingTypeName { get; set; }
            public int planDuration { get; set; }
            public string planDurationName { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public string approvedStatus { get; set; }
            public string paymentStatus { get; set; }
            public string PlanGeneareted { get; set; }
            public string PlanGenearetedDiet { get; set; }
            public int slotId { get; set; }
            public string SlotTime { get; set; }
            public int trainerId { get; set; }
            public string TrainerName { get; set; }
            public string traningMode { get; set; }
            public string TrainermobileNo { get; set; }
        }
        public class GetFoodItemBasedOnMealType_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "mealType(Int) parameter is required.")]
            public int mealType { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "dietTypeId(Int) parameter is required.")]
            public int dietTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required.")]
            public int userId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "bookingId(Int) parameter is required.")]
            public int bookingId { get; set; }

            public int uniqueId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }

        }
        public class GetFoodItemBasedOnMealType_Out
        {
            public int foodItemId { get; set; }
            public int dietTimeId { get; set; }
            public string foodItemName { get; set; }
            public string servingIn { get; set; }
            public string calories { get; set; }
            public string imageUrl { get; set; }
           
        }
    }
}