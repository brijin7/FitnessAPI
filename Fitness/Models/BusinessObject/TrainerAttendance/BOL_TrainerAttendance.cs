using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.TrainerAttendance
{
    public class BOL_UserAttendance
    {
        /// <summary>
        /// this class is used as input for inserting TrainerAttendance
        /// </summary>
        public class InsertTrainerAttendance_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "empId(Integer) parameter is required.")]
            public int empId { get; set; }
           
            [Required(ErrorMessage = "logDate parameter is required")]
            public string logDate { get; set; }

            [Required(ErrorMessage = "inTime parameter is required")]
            public string inTime { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }

        /// <summary>
        /// this class is used as input for getting TrainerAttendance details
        /// </summary>
        public class GetTrainerAttendance_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
            [Required(ErrorMessage = "date parameter is required")]
            public string date { get; set; }
        }
     
        /// <summary>
        /// this class is used as input parameter for update TrainerAttendance master
        /// </summary>
        public class UpdateTrainerAttendance_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "empId(Integer) parameter is required.")]
            public int empId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Integer) parameter is required.")]
            public int UniqueId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            public string outTime { get; set; }

            [Required(ErrorMessage = "inTime parameter is required")]
            public string inTime { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

    }
}