using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.Tran_UserFoodTracking
{
	public class BOL_TranUserFoodTracking
	{

		public class InsertTranUserFoodTracking_In
		{
			[Required(ErrorMessage = "FoodItem lists is required")]
			public List<UserFoodTracking> lstTranUserFoodTracking { get; set; }
		}

		/// <summary>
		/// this class is used as input for inserting TranUserFoodTracking
		/// </summary>
		public class UserFoodTracking
		{

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
			public int userId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "bookingId(Integer) parameter is required.")]
			public int bookingId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "foodMenuId(Integer) parameter is required.")]
			public int foodMenuId { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "mealtypeId(Integer) parameter is required.")]
			public int mealtypeId { get; set; }

			[Required]
			[Range(1, char.MaxValue, ErrorMessage = "consumingStatus(Only One Character Allows) parameter is required.")]
			public Char consumingStatus { get; set; }

			[Required(ErrorMessage = "date parameter is required")]
			public string date { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
			public int createdBy { get; set; }

		}
		public class GetListUserDietFoodMenu_In
		{

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
			public int userId { get; set; }

			[Required(ErrorMessage = "date parameter is required")]
			public DateTime date { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
			public int gymOwnerId { get; set; }


		}
		public class GetUserDietFoodMenu_OutNew
		{
			public int StatusCode { get; set; }
			public object UserFoodMenu { get; set; }
		}

		public class GetOnedateDietFoodMenu_In
		{

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
			public int userId { get; set; }

			[Required(ErrorMessage = "date parameter is required")]
			public string date { get; set; }


		}
		public class GetOnedateDietFoodMenu_OutNew
		{
			public int TotalCalories { get; set; }
			public int ConsumedCalories { get; set; }
			public int bookingId { get; set; }

		}

		public class GetTwodateDietFoodMenu_In
		{

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
			public int userId { get; set; }

			[Required(ErrorMessage = "Fromdate parameter is required")]
			public string Fromdate { get; set; }
			[Required(ErrorMessage = "Todate parameter is required")]
			public string Todate { get; set; }


		}
		public class GetTwodateDietFoodMenu_OutNew
		{
			public int TotalCalories { get; set; }
			public int ConsumedCalories { get; set; }
			public int bookingId { get; set; }
			public string DateOfDay { get; set; }
			public string DaysName { get; set; }
		}

	}
}