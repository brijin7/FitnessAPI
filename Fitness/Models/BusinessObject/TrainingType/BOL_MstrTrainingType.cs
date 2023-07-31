using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.TrainingType
{
    public class BOL_MstrTrainingType
    {

        /// <summary>
        /// this class is used as input for inserting TrainingType
        /// </summary>
        public class InsertTrainingType_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "trainingTypeNameId parameter is required")]
            public int trainingTypeNameId { get; set; }
            public string imageUrl { get; set; }
            public string description { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }


        /// <summary>
        /// this class is used as output for getting TrainingType details
        /// </summary>
        public class GetTrainingType_Out
        {
            public int trainingTypeId { get; set; }
            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
            public int trainingTypeNameId { get; set; }
            public string trainingTypeName { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public string activeStatus { get; set; }
        }
        /// <summary>
        /// this class is used as input for getting TrainingType details
        /// </summary>
        public class ddlTrainingType_In
        {

            [Required(ErrorMessage = "branchId parameter is required")]
            public int branchId { get; set; } 
            
            [Required(ErrorMessage = "gymOwnerId parameter is required")]
            public int gymOwnerId { get; set; }


        }
        /// <summary>
        /// this class is used as output for getting TrainingType details
        /// </summary>
        public class ddlTrainingType_Out
        {
            public int trainingTypeId { get; set; }
            public int trainingTypeNameId { get; set; }
            public string trainingTypeName { get; set; }

        }

        /// <summary>
        /// this class is used as input parameter for update TrainingType master
        /// </summary>
        public class UpdateTrainingType_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainingTypeId(Integer) parameter is required.")]
            public int trainingTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Integer) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Integer) parameter is required.")]
            public int branchId { get; set; }

            [Required(ErrorMessage = "trainingTypeNameId parameter is required")]
            public string trainingTypeNameId { get; set; }
            public string imageUrl { get; set; }
            public string description { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update TrainingType master
        /// </summary>
        public class ActivateOrInactivateTrainingType_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "trainingTypeId(Integer) parameter is required.")]
            public int trainingTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

    }
}