using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.Tran_UserWorkOutTracking
{
    public class BOL_UserWorkOutTracking
    {
        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetTran_WorkoutTracking_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required")]
            public int userId { get; set; }
        }     

        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetTran_WorkoutTracking_Out
        {
            public int uniqueId { get; set; }
            public int bookingId { get; set; }
            public int userId { get; set; }
            public int workoutCatTypeId { get; set; }
            public string workoutCatTypeName { get; set; }
            public int workoutTypeId { get; set; }
            public string workoutTypeName { get; set; }
            public string date { get; set; }
            public int setType { get; set; }
            public string setTypeName { get; set; }
            public int noOfReps { get; set; }
            public int weight { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public string video { get; set; }
        }

        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetTran_WorkoutTrackingBasedonDateDay_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required")]
            public int userId { get; set; }

            [Required(ErrorMessage = "Date parameter is required")]
            public string Date { get; set; }

            [Required(ErrorMessage = "day parameter is required")]
            public string day { get; set; }
        }

        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetTran_WorkoutTrackingBasedonDateDay_Out
        {
            public int uniqueId { get; set; }
            public int bookingId { get; set; }
            public int userId { get; set; }
            public int workoutCatTypeId { get; set; }
            public string workoutCatTypeName { get; set; }
            public int workoutTypeId { get; set; }
            public string workoutTypeName { get; set; }
            public string date { get; set; }
            public int setType { get; set; }
            public string setTypeName { get; set; }
            public int noOfReps { get; set; }
            public int weight { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public string video { get; set; }
            public string VideoCompletedStatus { get; set; }
            public string Day { get; set; }
            public string OverAllCompletedStatus { get; set; }
        }
        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetTran_WorkoutTrackingBasedonDateDayCategoryIdWorkoutTypeId_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required")]
            public int userId { get; set; }

            [Required(ErrorMessage = "Date parameter is required")]
            public string Date { get; set; }

            [Required(ErrorMessage = "day parameter is required")]
            public string day { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "WorkoutCatTypeId(Int) parameter is required")]
            public int WorkoutCatTypeId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "WorkoutTypeId(Int) parameter is required")]
            public int WorkoutTypeId { get; set; }
        }

        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetTran_WorkoutTrackingBasedonDateDayCategoryIdWorkoutTypeId_Out
        {
            public int uniqueId { get; set; }
            public int bookingId { get; set; }
            public int userId { get; set; }
            public int workoutCatTypeId { get; set; }
            public string workoutCatTypeName { get; set; }
            public int workoutTypeId { get; set; }
            public string workoutTypeName { get; set; }
            public string date { get; set; }
            public int setType { get; set; }
            public string setTypeName { get; set; }
            public int noOfReps { get; set; }
            public int weight { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public string video { get; set; }
            public string VideoCompletedStatus { get; set; }
            public string Day { get; set; }
            public string OverAllCompletedStatus { get; set; }
        }
        /// <summary>
        /// this class is used as input for inserting configmaster
        /// </summary>
        public class InsertTran_WorkoutTracking_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutCatTypeId(Int) parameter is required")]
            public int workoutCatTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutTypeId(Int) parameter is required")]
            public int workoutTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "bookingId(Int) parameter is required")]
            public int bookingId { get; set; }

            [Required(ErrorMessage = "date parameter is required")]
            public string date { get; set; }

            [Required(ErrorMessage = "Day parameter is required")]
            public string day { get; set; }

           
            public int setType { get; set; }

            
            public int noOfReps { get; set; }

    
            public int weight { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required")]
            public int userId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }
        /// <summary>
        /// this class is used as input parameter for update Tran_WorkoutTracking
        /// </summary>
        public class UpdateTran_WorkoutTracking_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Int) parameter is required.")]
            public int uniqueId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutCatTypeId(Int) parameter is required")]
            public int workoutCatTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workoutTypeId(Int) parameter is required")]
            public int workoutTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "bookingId(Int) parameter is required")]
            public int bookingId { get; set; }

            [Required(ErrorMessage = "date parameter is required")]
            public string date { get; set; }

            [Required(ErrorMessage = "Day parameter is required")]
            public string day { get; set; }

          
            public int setType { get; set; }

           
            public int noOfReps { get; set; }

           
            public int weight { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Int) parameter is required")]
            public int userId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        public class GetTwodateWorkoutPlane_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
            public int userId { get; set; }

            [Required(ErrorMessage = "Fromdate parameter is required")]
            public string Fromdate { get; set; }
            [Required(ErrorMessage = "Todate parameter is required")]
            public string Todate { get; set; }


        }
        public class GetTwodateWorkoutPlaneOutNew
        {
            public int TotalActivity { get; set; }
            public int CompletedActivity { get; set; }
            public int bookingId { get; set; }
            public string DateOfDay { get; set; }
            public string DaysName { get; set; }

        }

    }
}