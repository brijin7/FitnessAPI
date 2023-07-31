using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Fitness.Models.BusinessObject.DietType
{
    public class BOL_MstrDietType
    {
        /// <summary>
        /// this class is used as input for inserting DietType
        /// </summary>
        public class InsertDietType_In
        {

            [Required(ErrorMessage = "dietTypeNameId parameter is required")]
            public int dietTypeNameId { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            [Required(ErrorMessage = "typeIndicationImageUrl parameter is required")]
            public string typeIndicationImageUrl { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }


        /// <summary>
        /// this class is used as output for getting DietType details
        /// </summary>
        public class GetDietType_Out
        {
            public int dietTypeId { get; set; }
            public int dietTypeNameId { get; set; }
            public string dietTypeName { get; set; }
            public string description { get; set; }
            public string imageUrl { get; set; }
            public string typeIndicationImageUrl { get; set; }
            public string activeStatus { get; set; }
        }
        public class GetddlDietType_Out
            {
                public int dietTypeId { get; set; }

                public string dietTypeName { get; set; }

            }

            /// <summary>
            /// this class is used as input parameter for update DietType master
            /// </summary>
            public class UpdateDietType_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "dietTypeId(Integer) parameter is required.")]
            public int dietTypeId { get; set; }

            [Required(ErrorMessage = "dietTypeName parameter is required")]
            public int dietTypeNameId { get; set; }
            public string description { get; set; }

            public string imageUrl { get; set; }

            [Required(ErrorMessage = "typeIndicationImageUrl parameter is required")]
            public string typeIndicationImageUrl { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for update DietType master
        /// </summary>
        public class ActivateOrInactivateDietType_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "dietTypeId(Integer) parameter is required.")]
            public int dietTypeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}