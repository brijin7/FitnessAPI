using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.CategorySlot
{
    public class BOL_CategorySlot
    {
        /// <summary>
        /// this class is used as input for get
        /// </summary>
        public class InsertCategorySlots_In
        {
            [Required(ErrorMessage = "CategorySlots lists is required")]
            public List<CategorySlots> lstOfCategorySlots { get; set; }
        }
        /// <summary>
        /// this class is used as inpu for InsertFintnessCategorySlots_In
        /// </summary>
        public class CategorySlots
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "SlotId(Integer) parameter is required")]
            public int slotId { get; set; }
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
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainerId(Integer) parameter is required")]
            public int trainerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymStrength(Integer) parameter is required")]
            public int gymStrength { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBY(Integer) parameter is required")]
            public int createdBy { get; set; }
        }
        /// <summary>
        /// this class is used as input for get
        /// </summary>
        public class GetCategorySlotsDetails_In
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
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainerId(Integer) parameter is required")]
            public int trainerId { get; set; }
        }
        public class CategorySlots_Out
        {
            public int StatusCode { get; set; }

            public object CategorySlot { get; set; }
        }
        /// <summary>
        /// this class is used as input for get
        /// </summary>
        public class GetCategorySlots_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required")]
            public int branchId { get; set; }
           
        }
        public class UpdateCategorySlots_In
        {
            [Required(ErrorMessage = "CategorySlots lists is required")]
            public List<UpdateCategorySlots> lstOfCategorySlots { get; set; }
        }
        public class UpdateCategorySlots
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categorySlotId(Integer) parameter is required")]
            public int categorySlotId { get; set; }
            [Required(ErrorMessage = "activeStatus")]
            public string activeStatus { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "SlotId(Integer) parameter is required")]
            public int slotId { get; set; }
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
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainerId(Integer) parameter is required")]
            public int trainerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymStrength(Integer) parameter is required")]
            public int gymStrength { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBY(Integer) parameter is required")]
            public int updatedBy { get; set; }
        }

    }
}