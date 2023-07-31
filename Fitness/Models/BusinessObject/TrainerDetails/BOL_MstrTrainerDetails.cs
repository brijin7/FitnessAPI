using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.TrainerDetails
{
	public class BOL_MstrTrainerDetails
	{
		public class GetMstrTrainerDetails_In
		{

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "trainerId(Int) parameter is required")]
			public int trainerId { get; set; }
            public string Public { get; set; }

        }

        public class GetMstrTrainerDetailsApproval_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
            public int branchId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymownerId(Int) parameter is required")]
            public int gymownerId { get; set; }

        }
        public class GetMstrTrainerDetails_Out
		{
			public int StatusCode { get; set; }

			public object TrainerDetails { get; set; }
		}

		public class InsertMstrTrainerDetails_In
		{
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "trainerId(Int) parameter is required.")]
			public int trainerId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "specialistTypeId(Int) parameter is required.")]
			public int specialistTypeId { get; set; }

			public string experience { get; set; }

			public string qualification { get; set; }

			public string certificates { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
			public int createdBy { get; set; }


		}
		public class UpdateMstrTrainerDetails_In
		{
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Int) parameter is required.")]
            public int uniqueId { get; set; }

            [Required]
			[Range(1, int.MaxValue, ErrorMessage = "trainerId(Int) parameter is required.")]
			public int trainerId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "specialistTypeId(Int) parameter is required.")]
			public int specialistTypeId { get; set; }

			public string experience { get; set; }

			public string qualification { get; set; }

			public string certificates { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
			public int updatedBy { get; set; }


		}

        /// <summary>
        /// this class is used as input parameter for activateorinactivateFaq master
        /// </summary>
        public class ApproveOrInapproveTrainerDetails_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
            public int uniqueId{ get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}