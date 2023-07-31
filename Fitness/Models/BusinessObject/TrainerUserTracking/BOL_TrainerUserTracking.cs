using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.TrainerUserTracking
{
	public class BOL_TrainerUserTracking
	{
		public class GetTrainerSlot_In
		{

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "trainerId(Int) parameter is required")]
			public int trainerId { get; set; }
		}
		public class GetTrainerSlot_Out
		{
			public int StatusCode { get; set; }

			public object TrainerSlot { get; set; }
		}

		public class GetUserList_In
		{

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "trainerId(Int) parameter is required")]
			public int trainerId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "slotId(Int) parameter is required")]
			public int slotId { get; set; }


            [Required(ErrorMessage = "date parameter is required")]
            public string date { get; set; }
        }
		public class GetUserList_Out
		{
			public int StatusCode { get; set; }

			public object UserList { get; set; }
		}

		public class GetUserWorkOutList_In
		{
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "trainerId(Int) parameter is required")]
			public int trainerId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "slotId(Int) parameter is required")]
			public int slotId { get; set; }

			[Required(ErrorMessage = "day parameter is required")]
			public string day { get; set; }
			
			[Required(ErrorMessage = "date parameter is required")]
			public string date { get; set; }
            [Required(ErrorMessage = "userId parameter is required")]
            public string userId { get; set; }
        }
		public class GetUserWorkOutList_Out
		{
			public int StatusCode { get; set; }

			public object UserList { get; set; }
		}


        public class GetOverAllAttendance_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainerId(Int) parameter is required")]
            public int trainerId { get; set; }

            [Required(ErrorMessage = "date parameter is required")]
            public string date { get; set; }

            [Required(ErrorMessage = "slotId parameter is required")]
            public string slotId { get; set; }


        }
        public class GetOverAllAttendance_Out
        {
            public int StatusCode { get; set; }

            public object OverAll { get; set; }
        }
    }
}