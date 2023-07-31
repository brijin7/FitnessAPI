using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.Offer
{
    public class BOL_MstrOfferRule
    {
        /// <summary>
        /// this class is used as input for inserting OfferRule
        /// </summary>
        public class InsertOfferRule_In
        {
          

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "offerId(Integer) parameter is required.")]
            public int offerId { get; set; }

            [Required(ErrorMessage = "offerRule parameter is required")]
            public string offerRule { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "ruleType(Integer) parameter is required.")]
            public int ruleType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }

        /// <summary>
        /// this class is used as input for getting OfferRule details
        /// </summary>
        public class GetOfferRule_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "subscriptionPlanId(Integer) parameter is required.")]
            public int offerId { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting OfferRule details
        /// </summary>
        public class GetOfferRule_Out
        {
            public int offerRuleId { get; set; }
            public int offerId { get; set; }
            public string offerHeading { get; set; }
            public string offerRule { get; set; }
            public int ruleType { get; set; }
            public string ruleTypeName { get; set; }
            public string activeStatus { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update OfferRule master
        /// </summary>
        public class UpdateOfferRule_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "offerRuleId(Integer) parameter is required.")]
            public int offerRuleId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "offerId(Integer) parameter is required.")]
            public int offerId { get; set; }

            [Required(ErrorMessage = "offerRule parameter is required")]
            public string offerRule { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "ruleType(Integer) parameter is required.")]
            public int ruleType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update OfferRule master
        /// </summary>
        public class ActivateOrInactivateOfferRule_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "offerRuleId(Integer) parameter is required.")]
            public int offerRuleId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}