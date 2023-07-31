using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Fitness.Models.BusinessObject.FitnessCategoryPrice
{
    public static class BOL_MstrFitnessCategoryPrice
    {
        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetMstrFitnessCategoryPrice_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            public int priceId { get; set; }
        }

        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetPriceDetails_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
            public int categoryId { get; set; }

            [Required]
            [Range(1, Char.MaxValue, ErrorMessage = "trainingMode(Char(1)) parameter is required.")]
            public Char trainingMode { get; set; }

            public int priceId { get; set; }
        }

        public class GetPriceDetails_Out
        {
            public int StatusCode { get; set; }
            public object GetPriceDetails { get; set; }
        }


        /// <summary>
        /// this class is used to get the Category Price on Duration values
        /// </summary>
        public class GetMstrFitnessCategoryPriceonDuration
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
            public int categoryId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "planDuration(Integer) parameter is required.")]
            public int planDuration { get; set; }
        }
        /// <summary>
        /// this class is used to get the Category Price on Duration values
        /// </summary>
        public class GetMstrFitnessCategoryPriceonCategory
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
            public int categoryId { get; set; }
        }
        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetMstrFitnessCategorytax_In
        {
            [Required(ErrorMessage = "netAmount parameter is required")]
            public decimal netAmount { get; set; }

            [Required(ErrorMessage = "taxPercentage parameter is required")]
            public decimal taxPercentage { get; set; }
        }
        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetMstrFitnessCategorytax_Out
        {
            public string netAmount { get; set; }
            public string tax { get; set; }


        }
        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetMstrFitnessCategoryPrice_Out
        {
            public int priceId { get; set; }
            public int gymOwnerId { get; set; }
            public string gymName { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }
            public int categoryId { get; set; }
            public string categoryName { get; set; }
            public int trainingTypeId { get; set; }
            public string trainingTypeName { get; set; }
            public string trainingMode { get; set; }
            public int planDuration { get; set; }
            public string planDurationName { get; set; }
            public string price { get; set; }
            public string tax { get; set; }
            public string cgstTax { get; set; }
            public string sgstTax { get; set; }
            public int taxId { get; set; }
            public string taxName { get; set; }
            public string netAmount { get; set; }
            public string actualAmount { get; set; }
            public string displayAmount { get; set; }
            public string cyclePaymentsAllowed { get; set; }
            public int maxNoOfCycles { get; set; }
            public string activeStatus { get; set; }
            public string offerId { get; set; }
            public string offerName { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
        }


        /// <summary>
        /// this class is used to get the input values
        /// 
        /// Created By Abhinaya K
        /// Created DAte 07-DEC-2022
        /// </summary>
        public class GetMstrFitnessCategoryPriceDetailsForSlot_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "priceId(Integer) parameter is required.")]
            public int priceId { get; set; }
        }

        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetMstrFitnessCategoryPriceDetailsForSlot_Out
        {
            public int priceId { get; set; }
            public int gymOwnerId { get; set; }
            public string gymName { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }
            public int categoryId { get; set; }
            public string categoryName { get; set; }
            public int trainingTypeId { get; set; }
            public string trainingTypeName { get; set; }
            public string trainingMode { get; set; }
            public int planDuration { get; set; }
            public string planDurationName { get; set; }
            public string price { get; set; }
            public string tax { get; set; }
            public string cgstTax { get; set; }
            public string sgstTax { get; set; }
            public int taxId { get; set; }
            public string taxName { get; set; }
            public string netAmount { get; set; }
            public string actualAmount { get; set; }
            public string displayAmount { get; set; }
            public string cyclePaymentsAllowed { get; set; }
            public int maxNoOfCycles { get; set; }
            public string activeStatus { get; set; }
        }

        /// <summary>
        /// this class is used as input for inserting pricemaster
        /// </summary>
        public class InsertMstrFitnessCategoryPrice_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
            public int categoryId { get; set; }
            //[Required]
            //[Range(1, int.MaxValue, ErrorMessage = "trainingTypeId(Integer) parameter is required.")] for online it wont come so removed
            public int trainingTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "planDuration(Integer) parameter is required.")]
            public int planDuration { get; set; }

            [Required(ErrorMessage = "trainingMode parameter is required")]
            public string trainingMode { get; set; }

            [Required(ErrorMessage = "price parameter is required")]
            public string price { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "taxId(Integer) parameter is required.")]
            public string taxId { get; set; }

            [Required(ErrorMessage = "Tax parameter is required")]
            public string tax { get; set; }

            [Required(ErrorMessage = "Password parameter is required")]
            public int offerId { get; set; }
            public string offerName { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public string netAmount { get; set; }
            public string actualAmount { get; set; }
            public string displayAmount { get; set; }
            public string cyclePaymentsAllowed { get; set; }
            public int maxNoOfCycles { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }

        /// <summary>
        /// this class is used as input for updating pricemaster
        /// </summary>
        public class UpdateMstrFitnessCategoryPrice_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "priceId(Integer) parameter is required.")]
            public int priceId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
            public int categoryId { get; set; }

            //[Required]
            //[Range(1, int.MaxValue, ErrorMessage = "trainingTypeId(Integer) parameter is required.")]
            public int trainingTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "planDuration(Integer) parameter is required.")]
            public int planDuration { get; set; }

            [Required(ErrorMessage = "trainingMode parameter is required")]
            public string trainingMode { get; set; }
            [Required(ErrorMessage = "price parameter is required")]
            public string price { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "taxId(Integer) parameter is required.")]
            public int taxId { get; set; }

            [Required(ErrorMessage = "Tax parameter is required")]
            public string tax { get; set; }

            [Required(ErrorMessage = "netAmount parameter is required")]
            public int offerId { get; set; }
            public string offerName { get; set; }
            public string fromDate { get; set; }
            public string toDate { get; set; }
            public string netAmount { get; set; }
            public string actualAmount { get; set; }
            public string displayAmount { get; set; }
            public string cyclePaymentsAllowed { get; set; }
            public int maxNoOfCycles { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }

        }
        /// <summary>
        /// this class is used as input parameter for updatePricemaster
        /// </summary>
        public class ActivateOrInactivateMstrFitnessCategoryPrice_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "priceId(Integer) parameter is required.")]
            public int priceId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }

    public class GetPriceOnPublicWeb_In
    {

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
        public int gymOwnerId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
        public int branchId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
        public int categoryId { get; set; }

    }

    public class GetPriceOnPublicWeb_Out
    {

        public int priceId { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public int trainingTypeId { get; set; }
        public string trainingTypeName { get; set; }
        public string trainingMode { get; set; }
        public int planDuration { get; set; }
        public string planDurationName { get; set; }
        public string cyclePaymentsAllowed { get; set; }
        public int maxNoOfCycles { get; set; }
        public string price { get; set; }
        public string tax { get; set; }
        public string cgstTax { get; set; }
        public string sgstTax { get; set; }
        public int taxId { get; set; }
        public string taxName { get; set; }
        public string netAmount { get; set; }
        public string actualAmount { get; set; }
        public string displayAmount { get; set; }
        public string SavedAmount { get; set; }
        public string activeStatus { get; set; }
        public int gymOwnerId { get; set; }
        public int branchId { get; set; }
        public string branchName { get; set; }

    }

    
}