using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.UserSlotSwapping
{
    public class BOL_mstrUserSlotSwapping
    {
        /// <summary>
        /// this class is used as input for inserting UserSlotSwapping
        /// </summary>
        public class InsertUserSlotSwapping_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "newslotId(Integer) parameter is required.")]
            public int newslotId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "oldslotId(Integer) parameter is required.")]
            public int oldslotId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
            public int userId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "slotswapTypeId(Integer) parameter is required.")]
            public int slotswapTypeId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "bookingId(Integer) parameter is required.")]
            public int bookingId { get; set; }

            [Required(ErrorMessage = "slotfromDate parameter is required")]
            public string slotfromDate { get; set; }
            [Required(ErrorMessage = "toDate parameter is required")]
            public string toDate { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }

        /// <summary>
        /// this class is used as input for getting UserSlotSwapping details
        /// </summary>
        public class GetUserSlotSwapping_In
        {
            public string QueryType { get; set; }
            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
            public int trainerId { get; set; }
            public int slotSwapId { get; set; }
            public int userId { get; set; }
        }

    }
}