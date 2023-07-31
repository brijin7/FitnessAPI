using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Fitness.Models.BusinessObject
{
    public static class BOL_MstrConfigType
    {
       
        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetConfigType_Out
        {
            public int typeId { get; set; }
            public string typeName { get; set; }
            public string activeStatus { get; set; }
        }



        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class ddlConfigType_Out
        {
            public int typeId { get; set; }
            public string typeName { get; set; }
        }



        /// <summary>
        /// this class is used to get the insert input values 
        /// </summary>
        public class InsertConfigType_In
        {
            [Required(ErrorMessage = "typeName parameter is required")]
            public string typeName { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }

        /// <summary>
        /// this class is used as input for ConfigType Update Controller
        /// </summary>
        public class UpdateConfigType_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "typeId(Integer) parameter is required.")]
            public int typeId { get; set; }

            [Required(ErrorMessage = "typeName parameter is required")]
            public string typeName { get; set; }
        }
        /// <summary>
        /// this class is used as input for Activate ConfigType Controller
        /// </summary>
        public class ActivateConfigType_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "typeId(Integer) parameter is required.")]
            public int typeId { get; set; }
        }
        /// <summary>
        /// this class is used as input for InActivate ConfigType Controller
        /// </summary>
        public class InActivateConfigType_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "typeId(Integer) parameter is required.")]
            public int typeId { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for updateconfigType master
        /// </summary>
        public class ActivateOrInactivateConfigType_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "typeId(Integer) parameter is required.")]
            public int typeId { get; set; }
        }
    }
}