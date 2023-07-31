using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.SlotMaster
{
    public class BOL_DeactivateSlots
    {

        /// <summary>
        /// this class is used as input for inserting SlotMaster
        /// </summary>
        public class InsertDeactivatedSlotMaster_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "slotId(Integer) parameter is required.")]
            public int slotId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "workingDayId(Integer) parameter is required.")]
            public int workingDayId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }

        /// <summary>
        /// this class is used as input for getting SlotMaster details
        /// </summary>
        public class GetDeactivatedSlotMaster_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for activateorinactivatecategory master
        /// </summary>
        public class ActivateOrInactivateDeactivatedSlotMaster_In
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