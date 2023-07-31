using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.WorkOutType
{
    public static class BOL_MstrWorkoutType
    {
        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetMstrWorkoutType_In
        {
            [Required]
            [Range(1, int.MaxValue,ErrorMessage = "gymOwnerId(Int) parameter is required")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
            public int branchId { get; set; }
        }
        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetMstrWorkoutTypeSub_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutCatTypeId(Int) parameter is required")]
            public int workoutCatTypeId { get; set; }
        }

        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetMstrWorkoutType_Out
        {
            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
            public int workoutTypeId { get; set; }
            public int workoutCatTypeId { get; set; }
            public string workoutTypeName { get; set; }
            public string workoutType { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public string video { get; set; }
            public string calories { get; set; }
            public string activeStatus { get; set; }
        }

        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetMstrWorkoutTypeSub_Out
        {
            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
            public int workoutTypeId { get; set; }
            public int workoutCatTypeId { get; set; }
            public string workoutTypeName { get; set; }
            public string workoutType { get; set; }
            public string activeStatus { get; set; }
        }

        /// <summary>
        /// this class is used as input for inserting configmaster
        /// </summary>
        public class InsertMstrWorkoutType_In
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

            [Required(ErrorMessage = "workoutType parameter is required")]
            public string workoutType { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public string video { get; set; }
            [Required(ErrorMessage = "calories parameter is required")]
            public string calories { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }


        }
        /// <summary>
        /// this class is used as input parameter for updateconfig master
        /// </summary>
        public class UpdateMstrWorkoutType_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "WorkoutTypeId(Int) parameter is required")]
            public int workoutTypeId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue,ErrorMessage = "BranchId(Int) parameter is required")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutCatTypeId(Int) parameter is required")]
            public int workoutCatTypeId { get; set; }

            [Required(ErrorMessage = "workoutType parameter is required")]
            public string workoutType { get; set; }
            public string description { get; set; }      
            public string imageUrl { get; set; }
            public string video { get; set; }
            [Required(ErrorMessage = "calories parameter is required")]
            public string calories { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for updateconfig master
        /// </summary>
        public class ActivateOrInactivateMstrWorkoutType_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "WorkoutTypeId(Int) parameter is required")]
            public int workoutTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Int) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}