using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.WorkOutType
{
    public class BOL_MstrWorkoutMealPlan
    {
        /// <summary>
        /// this class is used as input for inserting workoutMealPlan
        /// </summary>
        public class InsertworkoutMealPlan_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "typeOfRoutine(Integer) parameter is required.")]
            public int typeOfRoutine { get; set; }

            [Required(ErrorMessage = "description parameter is required")]
            public string description { get; set; }

            [Required(ErrorMessage = "specificInstruction parameter is required")]
            public string specificInstruction { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }

        /// <summary>
        /// this class is used as input for getting workoutMealPlan details
        /// </summary>
        public class GetworkoutMealPlan_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }
           
            public int typeOfRoutine { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting workoutMealPlan details
        /// </summary>
        public class GetworkoutMealPlan_Out
        {
            public int uniqueId { get; set; }
            public string typeOfRoutine { get; set; }
            public string description { get; set; }
            public string specificInstruction { get; set; }
            public string activeStatus { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update workoutMealPlan master
        /// </summary>
        public class UpdateworkoutMealPlan_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Integer) parameter is required.")]
            public int uniqueId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "typeOfRoutine(Integer) parameter is required.")]
            public int typeOfRoutine { get; set; }

            [Required(ErrorMessage = "description parameter is required")]
            public string description { get; set; }

            [Required(ErrorMessage = "specificInstruction parameter is required")]
            public string specificInstruction { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update workoutMealPlan master
        /// </summary>
        public class ActivateOrInactivateworkoutMealPlan_In
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
    }
}