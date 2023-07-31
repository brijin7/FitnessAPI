using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.TrainerMaster
{
	public class BOL_MstrTrainer
	{
		public class GetMstrTrainer_In
		{

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required")]
			public int gymOwnerId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
			public int branchId { get; set; }
		}
		public class GetMstrTrainer_Out
		{
			public int StatusCode { get; set; }
			public object TrainerDetails { get; set; }
		}
		public class ddlMstrTrainer_In
		{

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required")]
			public int gymOwnerId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
			public int branchId { get; set; }

		}
		public class ddlMstrTrainer_Out
		{
			public int StatusCode { get; set; }
			public object TrainerDetails { get; set; }
		}
		public class InsertMstrTrainer_In
		{
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "GymOwnerId(Int) parameter is required.")]
			public int gymOwnerId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "Branch Id(Int) parameter is required.")]
			public int branchId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "trainerType (Int) parameter is required.")]
			public int trainerType { get; set; }

			[Required(ErrorMessage = "FirstName parameter is required")]
			public string firstName { get; set; }

			[Required(ErrorMessage = "LastName parameter is required")]
			public string lastName { get; set; }

			[Required(ErrorMessage = "Gender parameter is required")]
			public string gender { get; set; }

			public string addressLine1 { get; set; }
			public string addressLine2 { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "Zipcode(Int) parameter is required.")]
			public int zipcode { get; set; }
			public string city { get; set; }
			public string district { get; set; }
			public string state { get; set; }
			public string maritalStatus { get; set; }
			[Required(ErrorMessage = "Date Of Birth parameter is required")]
			public string dob { get; set; }
			[Required(ErrorMessage = "Date Of Joining parameter is required")]
			public string doj { get; set; }
			public string aadharId { get; set; }
			public string photoLink { get; set; }

			[Required(ErrorMessage = "Mobile Number parameter is required")]
			public string mobileNo { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "ShiftId(int) parameter is required")]
			public int shiftId { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "RoleId(int) parameter is required")]
			public int roleId { get; set; }
			public string mailId { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
			public int createdBy { get; set; }


		}
		public class UpdateMstrTrainer_In
		{
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "trainerId(Int) parameter is required.")]
			public int trainerId { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "GymOwnerId(Int) parameter is required.")]
			public int gymOwnerId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "Branch Id(Int) parameter is required.")]
			public int branchId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "trainerType (Int) parameter is required.")]
			public int trainerType { get; set; }

			[Required(ErrorMessage = "FirstName parameter is required")]
			public string firstName { get; set; }

			[Required(ErrorMessage = "LastName parameter is required")]
			public string lastName { get; set; }

			[Required(ErrorMessage = "Gender parameter is required")]
			public string gender { get; set; }

			public string addressLine1 { get; set; }
			public string addressLine2 { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "Zipcode(Int) parameter is required.")]
			public int zipcode { get; set; }
			public string city { get; set; }
			public string district { get; set; }
			public string state { get; set; }
			public string maritalStatus { get; set; }
			[Required(ErrorMessage = "Date Of Birth parameter is required")]
			public string dob { get; set; }
			[Required(ErrorMessage = "Date Of Joining parameter is required")]
			public string doj { get; set; }
			public string aadharId { get; set; }

			public string photoLink { get; set; }

			[Required(ErrorMessage = "Mobile Number parameter is required")]
			public string mobileNo { get; set; }

			[Required(ErrorMessage = "Password parameter is required")]
			public string passWord { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "ShiftId(int) parameter is required")]
			public int shiftId { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "RoleId(int) parameter is required")]
			public int roleId { get; set; }
			public string mailId { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
			public int updatedBy { get; set; }


		}
		public class ActivateOrInactivateMstrTrainer_In
		{
			[Required(ErrorMessage = "QueryType parameter is required")]
			public string queryType { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "trainerId(Int) parameter is required.")]
			public int trainerId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required.")]
			public int gymOwnerId { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
			public int branchId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "updatedBy(Int) parameter is required.")]
			public int updatedBy { get; set; }
		}
	}
}