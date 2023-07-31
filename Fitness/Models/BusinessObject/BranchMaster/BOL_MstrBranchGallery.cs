using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.BranchMaster
{
    public class BOL_MstrBranchGallery
    {
        /// <summary>
        /// this class is used as input for inserting BranchGallery
        /// </summary>
        public class InsertBranchGallery_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "imageUrl parameter is required")]
            public string imageUrl { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "galleryId(Integer) parameter is required.")]
            public int galleryId { get; set; }

            [Required(ErrorMessage = "description parameter is required")]
            public string description { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }

        /// <summary>
        /// this class is used as input for getting BranchGallery details
        /// </summary>
        public class GetBranchGallery_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }
            public int galleryId { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting BranchGallery details
        /// </summary>
        public class GetBranchGallery_Out
        {
            public int imageId { get; set; }
            public int branchId { get; set; }
            public int galleryId { get; set; }
            public string galleryname { get; set; }
            public string imageUrl { get; set; }
            public string description { get; set; }
            public string activeStatus { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update BranchGallery master
        /// </summary>
        public class UpdateBranchGallery_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "imageId(Integer) parameter is required.")]
            public int imageId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "imageUrl parameter is required")]
            public string imageUrl { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "galleryId(Integer) parameter is required.")]
            public int galleryId { get; set; }

            [Required(ErrorMessage = "description parameter is required")]
            public string description { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update BranchGallery master
        /// </summary>
        public class ActivateOrInactivateBranchGallery_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "imageId(Integer) parameter is required.")]
            public int imageId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}