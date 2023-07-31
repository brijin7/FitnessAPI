using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.FaqMaster
{
    public class BOL_FaqMaster
    {
        /// <summary>
        /// this class is used as input for inserting faqmstr
        /// </summary>
        public class InsertFaq_In
        {
            public int offerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymownerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required(ErrorMessage = "question parameter is required")]
            public string question { get; set; }

            [Required(ErrorMessage = "answer parameter is required")]
            public string answer { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "questionType(int) parameter is required.")]
            public int questionType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }


        public class GetFaqMstr_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            public char questionType { get; set; }
        }


        /// <summary>
        /// this class is used as output for getting Faqmstr details
        /// </summary>
        public class GetFaqMstr_Out
        {
            public int faqId { get; set; }
            public int gymOwnerId { get; set; }
            public int offerId { get; set; }
            public string question { get; set; }
            public string answer { get; set; }
            public int questionType { get; set; }
            public string activeStatus { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for updateFaq master
        /// </summary>
        public class UpdateFaqMstr_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "faqId(Integer) parameter is required.")]
            public int faqId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymownerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            public int offerId { get; set; }

            [Required(ErrorMessage = "question parameter is required")]
            public string question { get; set; }

            [Required(ErrorMessage = "answer parameter is required")]
            public string answer { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "questionType(int) parameter is required.")]
            public int questionType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for activateorinactivateFaq master
        /// </summary>
        public class ActivateOrInactivateFaqMstr_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "categoryId(Integer) parameter is required.")]
            public int faqId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}