using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.TrainerTracking
{
    public class BOL_TrainerTracking
    {
        public class UpdateTrainerWorkout_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainerId(Int) parameter is required")]
            public int trainerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "slotId(Int) parameter is required")]
            public int slotId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Int) parameter is required")]
            public int categoryId { get; set; }
            
            public string starttime { get; set; }
          
            public string endtime { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Int) parameter is required")]
            public int createdBy { get; set; }
        }
        public class GetTrainerWorkOutOverall_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainerId(Int) parameter is required")]
            public int trainerId { get; set; }

            [Required(ErrorMessage = "date parameter is required")]
            public string date { get; set; }

        }
        public class GetTrainerWorkOutOverall_Out
        {
            public int StatusCode { get; set; }

            public object TrainerDetails { get; set; }
        }
        public class GetTrainerWorkOutList_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainerId(Int) parameter is required")]
            public int trainerId { get; set; }

            [Required(ErrorMessage = "date parameter is required")]
            public string date { get; set; }

        }
        public class GetTrainerslotcompletedList_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainerId(Int) parameter is required")]
            public int trainerId { get; set; }

            [Required(ErrorMessage = "date parameter is required")]
            public string date { get; set; }
            public string slotId { get; set; }

        }
        public class GetTrainerWorkOutList_Out
        {
            public int StatusCode { get; set; }

            public object TrainerDetails { get; set; }
        }

    }
}