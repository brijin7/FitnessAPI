using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.Tran_UserWorkOutPlan
{
    public class BOL_UserWorkOutPlan
    {
        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetTran_WorkoutPlan_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required")]
            public int userId { get; set; }
        }

        public class GetTran_WorkoutPlanBasedBookingIdandDay_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required")]
            public int userId { get; set; }
            public int bookingId { get; set; }
        
        }

        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetTran_WorkoutPlanOnCategory_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required")]
            public int userId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutCatTypeId(Int) parameter is required")]
            public int workoutCatTypeId { get; set; }
        }

        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetTran_CategoryTypeBasedonDateDay_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required")]
            public int userId { get; set; }
            [Required(ErrorMessage = "Date parameter is required")]
            public string Date { get; set; }
            [Required(ErrorMessage = "day parameter is required")]
            public string day { get; set; }
        }
        public class GetTran_CategoryTypeBasedonDateDayCategory_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required")]
            public int userId { get; set; }   
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Int) parameter is required")]
            public int categoryId { get; set; }
            [Required(ErrorMessage = "Date parameter is required")]
            public string Date { get; set; }
            [Required(ErrorMessage = "day parameter is required")]
            public string day { get; set; }
        }

        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetTran_WorkoutTypeBasedonDateDay_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required")]
            public int userId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutCatTypeId(Int) parameter is required")]
            public int workoutCatTypeId { get; set; }

            [Required(ErrorMessage = "Date parameter is required")]
            public string Date { get; set; }

            [Required(ErrorMessage = "day parameter is required")]
            public string day { get; set; }
        }

        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetTran_SetTypeBasedonDateDay_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required")]
            public int userId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutCatTypeId(Int) parameter is required")]
            public int workoutCatTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutTypeId(Int) parameter is required")]
            public int workoutTypeId { get; set; }

            [Required(ErrorMessage = "Date parameter is required")]
            public string Date { get; set; }

            [Required(ErrorMessage = "day parameter is required")]
            public string day { get; set; }
        }


        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetTran_WorkoutPlan_Out
        {
            public int gymOwnerId { get; set; }
            public string gymOwnerName { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }
            public int workoutPlanId { get; set; }
            public int workoutCatTypeId { get; set; }
            public string workoutCatTypeName { get; set; }
            public int workoutTypeId { get; set; }
            public string workoutTypeName { get; set; }
            public int bookingId { get; set; }
            public string day { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public int csetType { get; set; }
            public string setTypeName { get; set; }
            public int cnoOfReps { get; set; }
            public int cweight { get; set; }
            public int userId { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public string video { get; set; }
        }

        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetTran_CategoryTypeBasedonDateDay_Out
        {
            public int gymOwnerId { get; set; }
            public string gymOwnerName { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }
            public int workoutCatTypeId { get; set; }
            public string workoutCatTypeName { get; set; }
            public int bookingId { get; set; }
            public string day { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public int userId { get; set; }
        }
        public class GetTran_CategoryTypeBasedonDateDayCategory_Out
        {
            public int gymOwnerId { get; set; }
            public string gymOwnerName { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }
            public int workoutCatTypeId { get; set; }
            public string workoutCatTypeName { get; set; }
            public int bookingId { get; set; }
            public string day { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public string VideoCount { get; set; }
            public int userId { get; set; }
        }


        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetTran_WorkoutTypeBasedonDateDay_Out
        {
            public int gymOwnerId { get; set; }
            public string gymOwnerName { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }
            public int workoutCatTypeId { get; set; }
            public string workoutCatTypeName { get; set; }
            public int workoutTypeId { get; set; }
            public string workoutTypeName { get; set; }
            public int bookingId { get; set; }
            public string day { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public int userId { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public string video { get; set; }
            public string UserUsed { get; set; }
            public string OverAllCompletedStatus { get; set; }
        }


        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetTran_SetType_Out
        {
            public int gymOwnerId { get; set; }
            public string gymOwnerName { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }
            public int workoutCatTypeId { get; set; }
            public string workoutCatTypeName { get; set; }
            public int workoutTypeId { get; set; }
            public string workoutTypeName { get; set; }
            public int bookingId { get; set; }
            public string day { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public int csetType { get; set; }
            public string setTypeName { get; set; }
            public int cnoOfReps { get; set; }
            public int cweight { get; set; }
            public int userId { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public string video { get; set; }
            public string VideoCompletedStatus { get; set; }
            public string OverAllCompletedStatus { get; set; }
        }

        /// <summary>
        /// this class is used as input for WorkoutPlan List 
        /// </summary>
        public class InsertTranrWorkoutPlan_In
        {
            [Required(ErrorMessage = "WorkoutPlan lists is required")]
            public List<UserWorkoutPlan> lstTranUserWorkoutPlan { get; set; }
        }

        /// <summary>
        /// this class is used as input for inserting configmaster
        /// </summary>
        public class UserWorkoutPlan
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "BranchId(Int) parameter is required")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutCatTypeId(Int) parameter is required")]
            public int workoutCatTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutTypeId(Int) parameter is required")]
            public int workoutTypeId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "bookingId(Int) parameter is required")]
            public int bookingId { get; set; }

            [Required(ErrorMessage = "day parameter is required")]
            public string day { get; set; }

            [Required(ErrorMessage = "fromDate parameter is required")]
            public string fromDate { get; set; }

            [Required(ErrorMessage = "toDate parameter is required")]
            public string toDate { get; set; }


            public int csetType { get; set; }


            public int cnoOfReps { get; set; }


            public int cweight { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required")]
            public int userId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }
        /// <summary>
        /// this class is used as input parameter for update Approve Status
        /// </summary>
        public class UpdateTran_WorkoutPlan_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "BranchId(Int) parameter is required")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutPlanId(Int) parameter is required")]
            public int workoutPlanId { get; set; }


            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutCatTypeId(Int) parameter is required")]
            public int workoutCatTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutTypeId(Int) parameter is required")]
            public int workoutTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "bookingId(Int) parameter is required")]
            public int bookingId { get; set; }

            [Required(ErrorMessage = "day parameter is required")]
            public string day { get; set; }

            [Required(ErrorMessage = "fromDate parameter is required")]
            public string fromDate { get; set; }

            [Required(ErrorMessage = "toDate parameter is required")]
            public string toDate { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "csetType(Int) parameter is required")]
            public int csetType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "cnoOfReps(Int) parameter is required")]
            public int cnoOfReps { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "cweight(Int) parameter is required")]
            public int cweight { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required")]
            public int userId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update Tran_WorkoutPlan
        /// </summary>
        public class UpdateTran_DietPlanApproveStatus_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "bookingId(Int) parameter is required")]
            public int bookingId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required")]
            public int userId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}