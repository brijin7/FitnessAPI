using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Fitness.Models.BusinessObject.Offer
{
    public static class BOL_MstrOfferMapping
    {
        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetMstrOfferMapping_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
            public int branchId { get; set; }
        }

        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetMstrOfferMapping_Out
        {
            public int offerMappingId { get; set; }
            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }     
            public int offerId { get; set; }
            public string offerTypePeriod { get; set; }
            public string offerHeading { get; set; }
            public string offerDescription { get; set; }
            public string offerCode { get; set; }
            public string offerImageUrl { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public string offerType { get; set; }
            public decimal offerValue { get; set; }
            public decimal minAmt { get; set; }
            public decimal maxAmt { get; set; }
            public int noOfTimesPerUser { get; set; }
            public string termsAndConditions { get; set; }
            public string activeStatus { get; set; }
            public string expireStatus { get; set; }
            public string OfferValueType { get; set; }
        }

        /// <summary>
        /// this class is used as input for inserting 
        /// </summary>
        public class InsertMstrOfferMapping_In
        {
           
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "offerId(Int) parameter is required")]
            public int offerId { get; set; }
          
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }
        /// <summary>
        /// this class is used as input parameter for update
        /// </summary>
        public class UpdateMstrOfferMapping_In
        {
          
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "offerMappingId(Int) parameter is required")]
            public int offerMappingId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "offerId(Int) parameter is required")]
            public int offerId { get; set; }
            
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Int) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update
        /// </summary>
        public class ActivateOrInactivateMstrOfferMapping_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "offerMappingId(Int) parameter is required.")]
            public int offerMappingId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) Int is required.")]
            public int updatedBy { get; set; }
        }
    }
}