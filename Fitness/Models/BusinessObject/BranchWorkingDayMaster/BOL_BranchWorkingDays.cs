using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Fitness.Models.BusinessObject.BranchWorkingDayMaster
{
    public static class BOL_BranchWorkingDays
    {
        /// <summary>
        /// insert
        /// </summary>
        public class InsertBranchWorkingDays_In
        {
            [Required(ErrorMessage = "BranchWorkingDays  List is Required")]
            public List<BranchWorkingDays_Insert> LstOfbranchWorkingDays { get; set; }
        }
        public class BranchWorkingDays_Insert
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required")]
            public int gymOwnerId { get; set; }

            [Required(ErrorMessage = "workingDay(String) parameter is required")]
            public string workingDay { get; set; }

     

            [Required(ErrorMessage = "isHoliday(Char) parameter is required")]
            public char isHoliday { get; set; }


            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required")]
            public int createdBy { get; set; }
        }

        /// <summary>
        /// update
        /// </summary>
        public class UpdateBranchWorkingDays_In
        {
            [Required(ErrorMessage = "BranchWorkingDays  List is Required")]
            public List<BranchWorkingDays_Update> LstOfbranchWorkingDays { get; set; }
        }
        public class BranchWorkingDays_Update
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workingDayId(Integer) parameter is required")]
            public int workingDayId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required")]
            public int gymOwnerId { get; set; }

            [Required(ErrorMessage = "isHoliday parameter is required")]
            public string isHoliday { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required")]
            public int updatedBy { get; set; }
        }


        /// <summary>
        /// get
        /// </summary>

        public class GetBranchWorkingDays_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required")]
            public int branchId { get; set; }
        }

        public class GetBranchWorkingDays_Out
        {
            public int branchId { get; set; }
            public string branchName { get; set; }
            public int workingDayId { get; set; }
            public int gymOwnerId { get; set; }
            public string gymOwnerName { get; set; }
            public TimeSpan fromTime { get; set; }
            public TimeSpan toTime { get; set; }
            public string isHoliday { get; set; }
            public string workingDay { get; set; }
        }

        /// <summary>
        /// get
        /// </summary>

        public class GetBranchWorkingDaysForSlot_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required")]
            public int branchId { get; set; }
        }

        public class GetBranchWorkingDaysForSlot_Out
        {
            public int workingDayId { get; set; }
            public string workingDay { get; set; }
        }
    }
}