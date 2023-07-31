using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.Booking
{
	public static class BOL_Booking
	{
		/// this class is used as input for inserting EmployeeMaster
		/// </summary>
		public class InsertBooking_In
		{
			[Required(ErrorMessage = "queryType parameter is required")]
			public string queryType { get; set; }
			public int bookingId { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "GymOwnerId(Int) parameter is required.")]
			public int gymOwnerId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "Branch Id(Int) parameter is required.")]
			public int branchId { get; set; }

			[Required(ErrorMessage = "Branch Name parameter is required")]
			public string branchName { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "CategoryId (Int) parameter is required.")]
			public int categoryId { get; set; }

			public int trainingTypeId { get; set; }
			//[Required]
			//[Range(1, int.MaxValue, ErrorMessage = "slotId (Int) parameter is required.")]
			public int slotId { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "PlanDurationId (Int) parameter is required.")]
			public int planDurationId { get; set; }

			[Required(ErrorMessage = "traningMode parameter is required")]
			public string traningMode { get; set; }

			//[Required(ErrorMessage = "slotFromTime parameter is required")]
			public string slotFromTime { get; set; }
			//[Required(ErrorMessage = "slotToTime parameter is required")]
			public string slotToTime { get; set; }
			[Required(ErrorMessage = "phone Number parameter is required")]
			public string phoneNumber { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "userId(int) parameter is required")]
			public int userId { get; set; }
			[Required(ErrorMessage = "booking parameter is required")]
			public string booking { get; set; }
			[Required(ErrorMessage = "loginType parameter is required")]
			public string loginType { get; set; }

			
			public int trainerId { get; set; }

			[Required(ErrorMessage = "wakeUpTime parameter is required")]
			public string wakeUpTime { get; set; }


			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "slotSwapType (Int) parameter is required.")]
			public int slotSwapType { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "PriceId (Int) parameter is required.")]
			public int priceId { get; set; }

			[Required(ErrorMessage = "price parameter is required")]
			public decimal price { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "taxId(Int) parameter is required.")]
			public int taxId { get; set; }

			[Required(ErrorMessage = "taxName parameter is required")]
			public string taxName { get; set; }
			[Required(ErrorMessage = "taxAmount parameter is required")]
			public decimal taxAmount { get; set; }
			[Required(ErrorMessage = "totalAmount parameter is required")]
			public decimal totalAmount { get; set; }
			public decimal paidAmount { get; set; }

			[Required(ErrorMessage = "paymentStatus parameter is required")]
			public string paymentStatus { get; set; }
			public int paymentCycles { get; set; }

			[Required(ErrorMessage = "paymentType parameter is required")]
			public int paymentType { get; set; }
			public string paymentCyclesStatus { get; set; }
			public string transactionId { get; set; }
			public string bankName { get; set; }
			public string bankReferenceNumber { get; set; }
			public int offerId { get; set; }
			public decimal offerAmount { get; set; }
			//public int utilizedRewardPoints { get; set; }
			//public string rewardPointsAmount { get; set; }
			//public string cancellationStatus { get; set; }
			//public string refundStatus { get; set; }
			//public string cancellationCharges { get; set; }
			//public string refundAmt { get; set; }
			//public string cancellationReason { get; set; }

			public int createdBy { get; set; }


		}

		/// <summary>
		/// this class is used as input for getting Booking details
		/// </summary>
		public class GetBooking_In
		{
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
			public int gymOwnerId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
			public int branchId { get; set; }

			[Required(ErrorMessage = "fromDate parameter is required.")]
			public DateTime fromDate { get; set; }

			[Required(ErrorMessage = "toDate parameter is required.")]
			public DateTime toDate { get; set; }
		}

		/// <summary>
		/// this class is used as input for getting Booking details
		/// </summary>
		public class GetUserBooking_In
		{
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
			public int userId { get; set; }
		}
		public class GetBookingId_In
		{
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "bookingId(Integer) parameter is required.")]
			public int bookingId { get; set; }
		}

		public class GetTrackingBooking_In
		{
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "gymOwnerId parameter is required")]
			public int gymOwnerId { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "branchId parameter is required")]
			public int branchId { get; set; }
			public string mobileNo { get; set; }
		}
		/// <summary>
		/// this class is used as output for getting Booking details
		/// </summary>
		public class GetBooking_Out
		{
			public int bookingId { get; set; }
			public int gymOwnerId { get; set; }
			public string gymOwnerName { get; set; }
			public int branchId { get; set; }
			public string branchName { get; set; }
			public int categoryId { get; set; }
			public string categoryName { get; set; }
			public int trainingTypeId { get; set; }
			public string trainingTypeName { get; set; }
			public string traningMode { get; set; }
			public int slotId { get; set; }
			public string slotFromTime { get; set; }
			public string dob { get; set; }
			public string gender { get; set; }
			public string slotToTime { get; set; }
			public int priceId { get; set; }
			public string phoneNumber { get; set; }
			public int userId { get; set; }
			public string UserName { get; set; }
			public string booking { get; set; }
			public string loginType { get; set; }
			public string fromDate { get; set; }
			public string toDate { get; set; }
			public string price { get; set; }
			public int taxId { get; set; }
			public string taxName { get; set; }
			public string taxAmount { get; set; }
			public int offerId { get; set; }
			public string offerAmount { get; set; }
			public string utilizedRewardPoints { get; set; }
			public string rewardPointsAmount { get; set; }
			public string totalAmount { get; set; }
			public string paidAmount { get; set; }
			public string paymentStatus { get; set; }
			public string paymentCycles { get; set; }
			public string paymentType { get; set; }
			public string cancellationStatus { get; set; }
			public string refundStatus { get; set; }
			public string cancellationCharges { get; set; }
			public string refundAmt { get; set; }
			public string cancellationReason { get; set; }
			public string bookingDate { get; set; }
			public string cgstTax { get; set; }
			public string sgstTax { get; set; }
			public int planDurationId { get; set; }
			public string PlaneDuration { get; set; }

		}

		public class GetFollowupTrackingBooking_In
		{
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "gymOwnerId parameter is required")]
			public int gymOwnerId { get; set; }
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "branchId parameter is required")]
			public int branchId { get; set; }
			[Required(ErrorMessage = "fromDate parameter is required.")]
			public string FromDate { get; set; }
			[Required(ErrorMessage = "ToDate parameter is required.")]
			public string ToDate { get; set; }
		}

		public class GetFollowupTrackingBooking_Out
		{
			public int StatusCode { get; set; }
			public object BookingFollowupDetails { get; set; }
		}


		public class GetSlotListIn
		{
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "categoryId parameter is required")]
			public int categoryId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "trainingTypeId parameter is required")]
			public int trainingTypeId { get; set; }

		}

		public class GetSlotListOut
		{
			public int StatusCode { get; set; }
			public object SlotList { get; set; }

		}

		public class GetTrainerListIn
		{
			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "categoryId parameter is required")]
			public int categoryId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "trainingTypeId parameter is required")]
			public int trainingTypeId { get; set; }

			[Required]
			[Range(1, int.MaxValue, ErrorMessage = "slotId parameter is required")]
			public int slotId { get; set; }

		}

		public class GetTraierListOut
		{
			public int StatusCode { get; set; }
			public object TrainerList { get; set; }

		}
	}
}