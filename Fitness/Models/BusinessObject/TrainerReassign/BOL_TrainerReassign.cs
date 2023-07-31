using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.TrainerReassign
{
    public class BOL_TrainerReassign
    {
        DateTime currentDate = DateTime.Now;
        public class InsertTrainerReassign_In
        {
            public List<TrainerReassigns> lstTrainerReAssign { get; set; }
        }

        public class TrainerReassigns
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
            [Range(1, int.MaxValue, ErrorMessage = "oldTrainerId(Integer) parameter is required")]
            public int oldTrainerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "newTrainerId(Integer) parameter is required")]
            public int newTrainerId { get; set; }
            [Required(ErrorMessage = "fromDate parameter is required")]
            public string fromDate { get; set; }
            [Required(ErrorMessage = "toDate parameter is required")]
            public string toDate { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required")]
            public int createdBy { get; set; }


        }

        public class GetAbsentTrainer_In
        {
            public DateTime getdate { get; set; } = DateTime.Now;
            public string queryType { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required")]
            public int branchId { get; set; }
            [DefaultValue(1)]                                             
            public int categoryId { get; set; }
            [DefaultValue(1)]
            public int trainingTypeId { get; set; }
            [DefaultValue(1)]
            public string slotId { get; set; }
            [DefaultValue(1)]
            public int trainerId { get; set; }
            
        }

    }
}