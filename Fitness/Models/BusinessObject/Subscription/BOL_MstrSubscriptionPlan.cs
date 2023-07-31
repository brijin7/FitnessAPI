using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.Subscription
{
    public class BOL_MstrSubscriptionPlan
    {


        /// <summary>
        /// this class is used as input for inserting SubscriptionPlan
        /// </summary>
        public class InsertSubscriptionPlan_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "packageName parameter is required")]
            public string packageName { get; set; }

            [Required(ErrorMessage = "description parameter is required")]
            public string description { get; set; }

            public string imageUrl { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "noOfDays(Integer) parameter is required.")]
            public int noOfDays { get; set; }

            [Required(ErrorMessage = "tax (decimal) parameter is required")]
            public Decimal tax { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "taxId(Integer) parameter is required.")]
            public int taxId { get; set; }

            [Required(ErrorMessage = "amount (decimal) parameter is required")]
            public decimal amount { get; set; } 
            
            [Required(ErrorMessage = "netAmount (decimal) parameter is required")]
            public decimal netAmount { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "credits(Integer) parameter is required.")]
            public int credits { get; set; }

            [Required]
            [Range(1, char.MaxValue, ErrorMessage = "isTrialAvailable(Allows Only Char(1)) parameter is required.")]
            public char isTrialAvailable { get; set; }

            public int noOfTrialDays { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
            public int offerId { get; set; }
            public string offerName { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public string actualAmount { get; set; }
            public string displayAmount { get; set; }

        }

        /// <summary>
        /// this class is used as input for getting SubscriptionPlan details
        /// </summary>
        public class GetSubscriptionPlan_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "subscriptionPlanId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting SubscriptionPlan details
        /// </summary>
        public class GetSubscriptionPlan_Out
        {
            public int subscriptionPlanId { get; set; }
            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
            public string packageName { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public int noOfDays { get; set; }
            public int taxId { get; set; }
            public string amount { get; set; }
            public string tax { get; set; }
            public string taxName { get; set; }
            public string cgstTax { get; set; }
            public string sgstTax { get; set; }
            public string netAmount { get; set; }
            public int credits { get; set; }
            public string isTrialAvailable { get; set; }
            public int noOfTrialDays { get; set; }
            public string activeStatus { get; set; }
            public int offerId { get; set; }
            public string offerName { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public string actualAmount { get; set; }
            public string displayAmount { get; set; }
        }


        /// <summary>
        /// this class is used as input for getting user SubscriptionPlan details
        /// </summary>
        public class GetuserSubscriptionPlanDetails_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "subscriptionPlanId(Integer) parameter is required.")]
            public int subscriptionPlanId { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting user SubscriptionPlan details
        /// </summary>
        public class GetuserSubscriptionPlanDetails_Out
        {
            public int subscriptionPlanId { get; set; }
            public int gymOwnerId { get; set; }
            public string gymName { get; set; }
            public string gymOwnerName { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }
            public string packageName { get; set; }
            public string fromTime { get; set; }
            public string toTime { get; set; }
            public string description { get; set; }
            public int benefitsId { get; set; }
            public string benefitsDescription { get; set; }
            public string benefitsImageUrl { get; set; }
            public string imageUrl { get; set; }
            public int noOfDays { get; set; }
            public string amount { get; set; }
            public string tax { get; set; }
            public string taxId { get; set; }
            public string taxName { get; set; }
            public string cgstTax { get; set; }
            public string sgstTax { get; set; }
            public string netAmount { get; set; }
            public string actualAmount { get; set; }
            public string displayAmount { get; set; }
            public string savedAmount { get; set; }
            public int credits { get; set; }
            public int noOfTrialDays { get; set; }
        }




        /// <summary>
        /// this class is used as input for getting user Home SubscriptionPlan details
        /// </summary>
        public class GetuserHomeSubscriptionPlanDetails_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "subscriptionPlanId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting user Home  SubscriptionPlan details
        /// </summary>
        public class GetuserHomeSubscriptionPlanDetails_Out
        {
            public int subscriptionPlanId { get; set; }
            public int gymOwnerId { get; set; }
            public string gymName { get; set; }
            public string gymOwnerName { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }
            public string packageName { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public int noOfDays { get; set; }
            public string amount { get; set; }
            public string taxId { get; set; }
            public string tax { get; set; }
            public string taxName { get; set; }
            public string cgstTax { get; set; }
            public string sgstTax { get; set; }
            public string netAmount { get; set; }
            public string actualAmount { get; set; }
            public string displayAmount { get; set; }
            public string savedAmount { get; set; }
            public string SubsBenefits { get; set; }
            public int credits { get; set; }
            public int noOfTrialDays { get; set; }
          
        }



        /// <summary>
        /// this class is used as input parameter for update SubscriptionPlan master
        /// </summary>
        public class UpdateSubscriptionPlan_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "subscriptionPlanId(Integer) parameter is required.")]
            public int subscriptionPlanId { get; set; }


            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }


            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "packageName parameter is required")]
            public string packageName { get; set; }

            [Required(ErrorMessage = "description parameter is required")]
            public string description { get; set; }

            public string imageUrl { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "noOfDays(Integer) parameter is required.")]
            public int noOfDays { get; set; }

            [Required(ErrorMessage = "tax (decimal) parameter is required")]
            public Decimal tax { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "taxId(Integer) parameter is required.")]
            public int taxId { get; set; }

            [Required(ErrorMessage = "amount (decimal) parameter is required")]
            public decimal amount { get; set; }

            [Required(ErrorMessage = "netAmount (decimal) parameter is required")]
            public decimal netAmount { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "credits(Integer) parameter is required.")]
            public int credits { get; set; }

            [Required]
            [Range(1, char.MaxValue, ErrorMessage = "isTrialAvailable(Allows Only Char(1)) parameter is required.")]
            public char isTrialAvailable { get; set; }

            public int noOfTrialDays { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
            public int offerId { get; set; }
            public string offerName { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public string actualAmount { get; set; }
            public string displayAmount { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update SubscriptionPlan master
        /// </summary>
        public class ActivateOrInactivateSubscriptionPlan_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "subscriptionPlanId(Integer) parameter is required.")]
            public int subscriptionPlanId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

    }
}