using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.SlotMaster
{
    public class BOL_SlotMaster
    {
        /// <summary>
        /// this class is used as input for inserting SlotMaster
        /// </summary>
        public class InsertSlotMaster_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "Duration parameter is required")]
            public string Duration { get; set; }

            //[Required]
            //[Range(1, int.MaxValue, ErrorMessage = "strengthPerSlot(Integer) parameter is required.")]
            //public int strengthPerSlot { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }

        /// <summary>
        /// this class is used as input for getting SlotMaster details
        /// </summary>
        public class GetSlotMaster_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for activateorinactivate SlotMaster
        /// </summary>
        public class ActivateOrInactivateSlotMaster_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "slotId(Integer) parameter is required.")]
            public int slotId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}