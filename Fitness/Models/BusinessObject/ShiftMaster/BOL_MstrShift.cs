using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.ShiftMaster
{
    public static class BOL_MstrShift
    {
        /// <summary>
        /// this class is used as input for inserting shiftmstr
        /// </summary>
        public class InsertShift_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "shiftName parameter is required")]
            public string shiftName { get; set; }

            [Required(ErrorMessage = "startTime parameter is required")]
            public string startTime { get; set; }

            [Required(ErrorMessage = "endTime parameter is required")]
            public string endTime { get; set; }

            [Required(ErrorMessage = "breakStartTime parameter is required")]
            public string breakStartTime { get; set; }

            [Required(ErrorMessage = "breakEndTime parameter is required")]
            public string breakEndTime { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gracePeriod(Integer) parameter is required.")]
            public int gracePeriod { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }
        /// <summary>
        /// this class is used as input for getting Shiftmstr details based on branch
        /// </summary>
        public class GetShiftMstr_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId parameter is required.")]
            public string branchId { get; set; }
        }
        ///// <summary>
        ///// this class is used as output for getting Shiftmstr details
        ///// </summary>
        //public class GetShiftMstr_Out
        //{
        //    public int shiftId { get; set; }
        //    public int branchId { get; set; }
        //    public string shiftName { get; set; }
        //    public string startTime { get; set; }
        //    public string endTime { get; set; }
        //    public string breakStartTime { get; set; }
        //    public string breakEndTime { get; set; }
        //    public int gracePeriod { get; set; }
        //    public string activeStatus { get; set; }
        //}

        /// <summary>
        /// this class is used as output for getting ddlShiftmstr details
        /// </summary>
        //public class GetddlShiftMstr_Out
        //{
        //    public int shiftId { get; set; }
        //    public string shiftName { get; set; }
        //}
        /// <summary>
        /// this class is used as input parameter for updateShift master
        /// </summary>
        public class UpdateShiftMstr_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "shiftId(Integer) parameter is required.")]
            public int shiftId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "shiftName parameter is required")]
            public string shiftName { get; set; }

            [Required(ErrorMessage = "startTime parameter is required")]
            public string startTime { get; set; }

            [Required(ErrorMessage = "endTime parameter is required")]
            public string endTime { get; set; }

            [Required(ErrorMessage = "breakStartTime parameter is required")]
            public string breakStartTime { get; set; }

            [Required(ErrorMessage = "breakEndTime parameter is required")]
            public string breakEndTime { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gracePeriod(Integer) parameter is required.")]
            public int gracePeriod { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for activateorinactivateShift master
        /// </summary>
        public class ActivateOrInactivateShiftMstr_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string QueryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "shiftId(Integer) parameter is required.")]
            public int shiftId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class ddlGetShiftMstr_In
        {
            public int branchId { get; set; }
        }
    }
}