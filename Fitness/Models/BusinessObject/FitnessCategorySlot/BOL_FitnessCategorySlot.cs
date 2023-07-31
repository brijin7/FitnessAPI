using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Fitness.Models.BusinessObject.FitnessCategorySlot
{
    public static class BOL_FitnessCategorySlot
    {
        /// <summary>
        /// this class is used as input for get
        /// </summary>
        public class InsertFintnessCategorySlots_In
        {
            [Required(ErrorMessage = "FintnessCategorySlots lists is required")]
            public List<FintnessCategorySlots> lstOfFintnessCategorySlots { get; set; }
        }
        /// <summary>
        /// this class is used as inpu for InsertFintnessCategorySlots_In
        /// </summary>
        public class FintnessCategorySlots
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "SlotId(Integer) parameter is required")]
            public int SlotId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required")]
            public int branchId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workingDayId(Integer) parameter is required")]
            public int workingDayId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required")]
            public int categoryId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainingTypeId(Integer) parameter is required")]
            public int trainingTypeId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "empId(Integer) parameter is required")]
            public int empId { get; set; }
            [Required(ErrorMessage = "traningMode parameter is required")]
            public Char trainingMode { get; set; }
            [Required(ErrorMessage = "fromDate parameter is required")]
            public DateTime fromDate { get; set; }
            [Required(ErrorMessage = "toDate parameter is required")]
            public DateTime toDate { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBY(Integer) parameter is required")]
            public int createdBy { get; set; }
        }

        /// <summary>
        /// this class is used as input for get
        /// </summary>
        public class GetFintnessCategorySlots_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required")]
            public int branchId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required")]
            public int categoryId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainingTypeId(Integer) parameter is required")]
            public int trainingTypeId { get; set; }
            [Required(ErrorMessage = "traningMode parameter is required")]
            public Char trainingMode { get; set; }
        }



        /// <summary>
        /// this class is used as output for get
        /// </summary>
        public class GetFintnessCategorySingleSlots_Out
        {
            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
            public int workingDayId { get; set; }
            public string workingDay { get; set; }
            public int categoryId { get; set; }
            public string categoryName { get; set; }
            public int trainingTypeId { get; set; }
            public string traningTypeName { get; set; }
            public string trainingMode { get; set; }
            public int empId { get; set; }
            public string empName { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
        }

        /// <summary>
        /// this class is used as output for get
        /// </summary>
        public class GetFintnessCategorySlots_Out
        {
            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
            public int categoryId { get; set; }
            public string categoryName { get; set; }
            public int trainingTypeId { get; set; }
            public string traningTypeName { get; set; }
            public string trainingMode { get; set; }
            public int empId { get; set; }
            public string empName { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public List<GetFintnessCategorySlotsDay_Out> slotDaydetails { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class GetFintnessCategorySlotsList_Out
        {
            public int workingDayId { get; set; }
            public string workingDay { get; set; }
            public int slotId { get; set; }
            public string slots { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class GetFintnessCategorySlotsDay_Out
        {
            public int workingDayId { get; set; }
            public string workingDay { get; set; }

            public List<GetFintnessCategorySlotsList_Out> slotdetails { get; set; }
        }


        /// <summary>
        /// this class is used as input for get
        /// </summary>
        public class GetFintnessCategoryAvailableSlots_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required")]
            public int branchId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required")]
            public int categoryId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainingTypeId(Integer) parameter is required")]
            public int trainingTypeId { get; set; }

        }

        /// <summary>
        /// this class is used as output for get
        /// </summary>
        public class GetFintnessCategoryAvailableSlots_Out
        {

            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
            public int workingDayId { get; set; }
            public string workingDay { get; set; }

            public int categorySlotId
            {
                get; set;
            }
            public int categoryId { get; set; }
            public string categoryName { get; set; }
            public int trainingTypeId { get; set; }
            public string traningTypeName { get; set; }
            public string trainingMode { get; set; }
            public string fromTime { get; set; }
            public string totime { get; set; }
            public string slotTimeInMinutes { get; set; }


        }
    }
}