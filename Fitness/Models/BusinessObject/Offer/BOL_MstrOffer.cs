using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.Offer
{
    public class BOL_MstrOffer
    {
        /// <summary>
        /// this class is used as input for inserting Offer
        /// </summary>
        public class InsertOffer_In
        {
            [Required]
            [Range(1, char.MaxValue, ErrorMessage = "offerTypePeriod(Allows Only Char(1)) parameter is required.")]
            public char offerTypePeriod { get; set; }


            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required(ErrorMessage = "offerHeading parameter is required")]
            public string offerHeading { get; set; }

            [Required(ErrorMessage = "offerDescription parameter is required")]
            public string offerDescription { get; set; }

            [Required(ErrorMessage = "offerCode parameter is required")]
            public string offerCode { get; set; }

            [Required(ErrorMessage = "offerImageUrl parameter is required")]
            public string offerImageUrl { get; set; }


            [Required(ErrorMessage = "fromDate parameter is required")]
            public string fromDate { get; set; }

            [Required(ErrorMessage = "toDate parameter is required")]
            public string toDate { get; set; }

            [Required]
            [Range(1, char.MaxValue, ErrorMessage = "offerType(Allows Only Char(1)) parameter is required.")]
            public char offerType { get; set; }

            [Required(ErrorMessage = "offerValue parameter is required")]
            public Decimal offerValue { get; set; }

            [Required(ErrorMessage = "minAmt parameter is required")]
            public Decimal minAmt { get; set; }

            [Required(ErrorMessage = "maxAmt parameter is required")]
            public Decimal maxAmt { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "noOfTimesPerUser(Integer) parameter is required.")]
            public int noOfTimesPerUser { get; set; }

            [Required(ErrorMessage = "termsAndConditions parameter is required")]
            public string termsAndConditions { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }

        /// <summary>
        /// this class is used as input for getting Offer details
        /// </summary>
        public class GetOffer_In
        {
            public int offerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
        }
       
        
        /// <summary>
        /// this class is used as output for getting Offer details
        /// </summary>
        public class GetddlOffer_Out
        {
            public int offerId { get; set; }
            public string offerHeading { get; set; }
            public string offerCode { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting Offer details
        /// </summary>
        public class GetOffer_Out
        {
            public int offerId { get; set; }
            public int gymOwnerId { get; set; }
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
        }

        /// <summary>
        /// this class is used as input parameter for update Offer master
        /// </summary>
        public class UpdateOffer_In
        {
            [Required]
            [Range(1, char.MaxValue, ErrorMessage = "offerId(Integer) parameter is required.")]
            public int offerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, char.MaxValue, ErrorMessage = "offerTypePeriod(Allows Only Char(1)) parameter is required.")]
            public char offerTypePeriod { get; set; }

            [Required(ErrorMessage = "offerHeading parameter is required")]
            public string offerHeading { get; set; }

            [Required(ErrorMessage = "offerDescription parameter is required")]
            public string offerDescription { get; set; }

            [Required(ErrorMessage = "offerCode parameter is required")]
            public string offerCode { get; set; }

            [Required(ErrorMessage = "offerImageUrl parameter is required")]
            public string offerImageUrl { get; set; }


            [Required(ErrorMessage = "fromDate parameter is required")]
            public string fromDate { get; set; }

            [Required(ErrorMessage = "toDate parameter is required")]
            public string toDate { get; set; }

            [Required]
            [Range(1, char.MaxValue, ErrorMessage = "offerType(Allows Only Char(1)) parameter is required.")]
            public char offerType { get; set; }

            [Required(ErrorMessage = "offerValue parameter is required")]
            public Decimal offerValue { get; set; }

            [Required(ErrorMessage = "minAmt parameter is required")]
            public Decimal minAmt { get; set; }

            [Required(ErrorMessage = "maxAmt parameter is required")]
            public Decimal maxAmt { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "noOfTimesPerUser(Integer) parameter is required.")]
            public int noOfTimesPerUser { get; set; }

            [Required(ErrorMessage = "termsAndConditions parameter is required")]
            public string termsAndConditions { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update Offer master
        /// </summary>
        public class ActivateOrInactivateOffer_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "offerId(Integer) parameter is required.")]
            public int offerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}