using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.Subscription
{
    public class BOL_MstrSubscriptionBenefits
    {

        /// <summary>
        /// this class is used as input for inserting SubscriptionBenefits
        /// </summary>
        public class InsertSubscriptionBenefits_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "subscriptionPlanId(Integer) parameter is required.")]
            public int subscriptionPlanId { get; set; }

            [Required(ErrorMessage = "description parameter is required")]
            public string description { get; set; }

            public string imageUrl { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }

        /// <summary>
        /// this class is used as input for getting SubscriptionBenefits details
        /// </summary>
        public class GetSubscriptionBenefits_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "subscriptionPlanId(Integer) parameter is required.")]
            public int subscriptionPlanId { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting SubscriptionBenefits details
        /// </summary>
        public class GetSubscriptionBenefits_Out
        {
            public int SubBenefitId { get; set; }
            public int subscriptionPlanId { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public string activeStatus { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update SubscriptionBenefits master
        /// </summary>
        public class UpdateSubscriptionBenefits_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Integer) parameter is required.")]
            public int uniqueId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "subscriptionPlanId(Integer) parameter is required.")]
            public int subscriptionPlanId { get; set; }

            [Required(ErrorMessage = "description parameter is required")]
            public string description { get; set; }

            public string imageUrl { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update SubscriptionBenefits master
        /// </summary>
        public class ActivateOrInactivateSubscriptionBenefits_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "uniqueId(Integer) parameter is required.")]
            public int uniqueId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}