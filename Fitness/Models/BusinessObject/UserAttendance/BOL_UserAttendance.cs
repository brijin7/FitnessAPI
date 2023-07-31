using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.UserAttendance
{
    public class BOL_UserAttendance
    {
        /// <summary>
        /// this class is used as input for inserting UserAttendance
        /// </summary>
        public class InsertUserAttendance_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
            public int userId { get; set; }

            [Required(ErrorMessage = "logDate parameter is required")]
            public string logDate { get; set; }

            [Required(ErrorMessage = "inTime parameter is required")]
            public string inTime { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }

        /// <summary>
        /// this class is used as input for getting UserAttendance details
        /// </summary>
        public class GetUserAttendance_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainerId(Integer) parameter is required.")]
            public int trainerId { get; set; }
            public int userId { get; set; }
        }

        /// <summary>
        /// this class is used as input for getting UserAttendance details
        /// </summary>
        public class GetTrainerBasedUsers_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainerId(Integer) parameter is required.")]
            public int trainerId { get; set; }
        }
        /// <summary>
        /// this class is used as input parameter for update UserAttendance master
        /// </summary>
        public class UpdateUserAttendance_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
            public int userId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "UniqueId(Integer) parameter is required.")]
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



        public class UpdateUserAttendanceByTrainer_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
            public int userId { get; set; }

            [Required(ErrorMessage = "logDate parameter is required")]
            public string logDate { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "inTime parameter is required")]
            public string inTime { get; set; }

            [Required(ErrorMessage = "OutTime parameter is required")]
            public string OutTime { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }
    }
}