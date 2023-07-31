using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.LiveConfig
{
    public class BOL_MstrLiveConfig 
    {
        /// <summary>
        /// this class is used as input for inserting LiveConfig
        /// </summary>
        public class InsertLiveConfig_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymownerId(Integer) parameter is required.")]

            public string gymownerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]

            public string branchId { get; set; }

            [Required(ErrorMessage = "liveurl parameter is required")]

            public string liveurl { get; set; }
            [Required(ErrorMessage = "livedate parameter is required")]

            public string livedate { get; set; }
            [Required(ErrorMessage = "purposename parameter is required")]

            public string purposename { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "slotId(Integer) parameter is required.")]
            public int slotId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainerId(Integer) parameter is required.")]
            public int trainerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
            public int categoryId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainingTypeId(Integer) parameter is required.")]
            public int trainingTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }


        /// <summary>
        /// this class is used as output for getting LiveConfig details
        /// </summary>
        public class GetLiveConfigMstr_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
            public int categoryId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainerId(Integer) parameter is required.")]
            public int trainerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainingTypeId(Integer) parameter is required.")]
            public int trainingTypeId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "slotId(Integer) parameter is required.")]
            public int slotId { get; set; }
            [Required(ErrorMessage = "date parameter is required")]
            public string date { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting LiveConfig details
        /// </summary>
        public class GetLiveBranchownerConfigMstr_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymownerId(Integer) parameter is required.")]
            public int gymownerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting LiveConfig details
        /// </summary>
        public class GetLiveConfigMstr_Out
        {
            public int uniqueId { get; set; }
            public int gymownerId { get; set; }
            public int branchId { get; set; }
            public string liveurl { get; set; }
            public string livedate { get; set; }
            public string purposename { get; set; }
            public string activeStatus { get; set; }
            public int trainerId { get; set; }
            public int categoryId { get; set; }
            public int trainingTypeId { get; set; }
            public int trainingTypeNameId { get; set; }
            public int slotId { get; set; }
            public string trainerName { get; set; }
            public string SlotTime { get; set; }
            public string categoryName { get; set; }
            public string configName { get; set; }
        }
        /// <summary>
        /// this class is used as input parameter for LiveConfig master
        /// </summary>
        public class UpdateLiveConfigMstr_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Integer) parameter is required.")]
            public int uniqueId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymownerId(Integer) parameter is required.")]

            public string gymownerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]

            public string branchId { get; set; }

            [Required(ErrorMessage = "liveurl parameter is required")]

            public string liveurl { get; set; }
            [Required(ErrorMessage = "livedate parameter is required")]

            public string livedate { get; set; }
            [Required(ErrorMessage = "purposename parameter is required")]

            public string purposename { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "slotId(Integer) parameter is required.")]
            public int slotId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainerId(Integer) parameter is required.")]
            public int trainerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
            public int categoryId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainingTypeId(Integer) parameter is required.")]
            public int trainingTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for activateorinactivateLiveConfig master
        /// </summary>
        public class ActivateOrInactivateLiveConfigMstr_In
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

        public class SendSmsForAllUSerLiveUrl_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymownerId(Integer) parameter is required.")]
            public string gymownerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public string branchId { get; set; }

            public string SMSBody { get; set; }
        }
    }
}
