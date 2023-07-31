using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.ConfigMaster
{
    public static class BOL_MstrConfig
    {
        /// <summary>
        /// this class is used as input for inserting configmaster
        /// </summary>
        public class InsertConfig_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "typeId(Integer) parameter is required.")]
            public int typeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

            [Required(ErrorMessage = "configName parameter is required")]
            public string configName { get; set; }
        }

        
        /// <summary>
        /// this class is used as output for getting configmaster details
        /// </summary>
        public class GetConfigMstr_Out
        {
            public int typeId { get; set; }
            public string typeName { get; set; }
            public int configId { get; set; }
            public string configName { get; set; }
            public string activeStatus { get; set; }
        }




        /// <summary>
        /// this class is used as input for getting ddl configmaster details
        /// </summary>
        public class ddlConfigMstr_In
        {
            public int typeId { get; set; }
        }
        /// <summary>
        /// this class is used as output for ddl getting configmaster details
        /// </summary>
        public class ddlConfigMstr_Out
        {
            public int configId { get; set; }
            public string configName { get; set; }
        }


        /// <summary>
        /// this class is used as input parameter for updateconfig master
        /// </summary>
        public class UpdateConfigMstr_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "typeId(Integer) parameter is required.")]
            public int typeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "configId(Integer) parameter is required.")]
            public int configId { get; set; }

            [Required(ErrorMessage = "configName parameter is required")]
            public string configName { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for updateconfig master
        /// </summary>
        public class ActivateOrInactivateConfigMstr_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "typeId(Integer) parameter is required.")]
            public int typeId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "configId(Integer) parameter is required.")]
            public int configId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }
    }
}