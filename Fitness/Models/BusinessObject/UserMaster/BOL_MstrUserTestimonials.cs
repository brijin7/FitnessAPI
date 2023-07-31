using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.UserMaster
{
    public class BOL_MstrUserTestimonials
    {

        /// <summary>
        /// this class is used as input for inserting UserTestimonials
        /// </summary>
        public class InsertUserTestimonials_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
           
            public int bookingId { get; set; }

            [Required(ErrorMessage = "imageUrl parameter is required")]
            public string imageUrl { get; set; }
            
            public int feedbackRating { get; set; }

            [Required(ErrorMessage = "feedbackComment parameter is required")]
            public string feedbackComment { get; set; }

            [Required]
            [Range(1, char.MaxValue, ErrorMessage = "dispayStatus(Integer) parameter is required.")]
            public char dispayStatus { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }

        /// <summary>
        /// this class is used as input for getting UserTestimonials details
        /// </summary>
        public class GetUserTestimonials_In
        {
            public int bookingId { get; set; }
        }

        /// <summary>
        /// this class is used as input for getting Branch Testimonials details
        /// </summary>
        public class GetBranchTestimonials_In
        {
            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
        }

        /// <summary>
        /// this class is used as output for getting UserTestimonials details
        /// </summary>
        public class GetUserTestimonials_Out
        {
            public int feedbackId { get; set; }
            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
            public int bookingId { get; set; }
            public string imageUrl { get; set; }
            public int feedbackRating { get; set; }
            public string feedbackComment { get; set; }
            public string dispayStatus { get; set; }
            public int userId { get; set; }
            public string firstName { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update UserTestimonials master
        /// </summary>
        public class UpdateUserTestimonials_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "feedbackId(Integer) parameter is required.")]
            public int feedbackId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }           
            public int bookingId { get; set; }

            [Required(ErrorMessage = "imageUrl parameter is required")]
            public string imageUrl { get; set; }

            public int feedbackRating { get; set; }

            [Required(ErrorMessage = "feedbackComment parameter is required")]
            public string feedbackComment { get; set; }

            [Required]
            [Range(1, char.MaxValue, ErrorMessage = "dispayStatus(Integer) parameter is required.")]
            public char dispayStatus { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updateBy { get; set; }
        }

    }
}