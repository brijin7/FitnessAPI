using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.BranchWorkingSlots
{
    public static class BOL_mstrBranchWorkingSlots
    {
        /// <summary>
        /// this class is used as input parameter of BranchWorkingSlots
        /// </summary>
        public class InsertBranchWorkingSlots_In
        {
            [Required(ErrorMessage = "BranchWorkingDays  List is Required")]
            public List<BranchWorkingSlots> LstOfbranchWorkingSlots { get; set; }
        }

        public class singleInsertBranchWorkingSlots_In
        {
           
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workingDayId(Integer) parameter is required")]
            public int workingDayId { get; set; }

            public string fromTime { get; set; }

            public string toTime { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required")]
            public int createdBy { get; set; }

        }

        /// <summary>
        /// BranchWorkingSlots details
        /// </summary>
        public class BranchWorkingSlots
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

            public string fromTime { get; set; }

            public string toTime { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required")]
            public int createdBy { get; set; }
        }


        /// <summary>
        /// this method is used as input for GetBranchworkingDaysForSlots
        /// </summary>
        public class GetBranchworkingDaysForSlots_In
        { 
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required")]
            public int branchId { get; set; }
         
        }
        /// <summary>
        /// this method is used as output for GetBranchworkingDaysForSlots
        /// </summary>
        public class GetBranchworkingDaysForSlots_Out
        {
            public int branchId { get; set; }
            public int gymOwnerId { get; set; }
            public int workingDayId { get; set; }
            public string workingDay { get; set; }
        }

        /// <summary>
        /// this method is used as input for GetBranchworkingDaysForSlots
        /// </summary>
        public class GetBranchWorkingSlots_In
        {
            [Required(ErrorMessage = "queryType Parameter is Required")]
            public string queryType { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workingDayId(Integer) parameter is required")]
            public int workingDayId { get; set; }

           
        }
        /// <summary>
        /// this method is used as output for GetBranchworkingDaysForSlots
        /// </summary>
        public class GetBranchWorkingSlots_Out
        {
            public int branchId { get; set; }
            public int slotId { get; set; }
            public int gymOwnerId { get; set; }
            public int workingDayId { get; set; }
            public string workingDay { get; set; }
            public string fromTime { get; set; }
            public string toTime { get; set; }
            public int slotTimeInMinutes { get; set; }
        }

        /// <summary>
        /// this method is used to delete  Branch Working Slots
        /// </summary>
        public class DeleteBranchWorkingSlots_In
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
        }
    }
}