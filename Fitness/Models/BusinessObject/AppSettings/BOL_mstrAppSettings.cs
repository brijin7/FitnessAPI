using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.AppSetting
{
    public static class BOL_mstrAppSettings
    {
        /// <summary>
        /// this class is input for insert app version
        /// </summary>
        public class InsertAppSetting_In
        {

            [Required(ErrorMessage = "appVersion parameter is required.")]
            public string appVersion { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required(ErrorMessage = "packageName parameter is required.")]
            public string packageName { get; set; }

            [Required(ErrorMessage = "versionChanges parameter is required.")]
            public string versionChanges { get; set; }

            [Required(ErrorMessage = "appType parameter is required.")]
            public char appType { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy parameter is required.")]
            public int createdBy { get; set; }
        }

        /// <summary>
        /// this class is input for get app version
        /// </summary>
        public class GetAppSetting_In
        {   
            [Required(ErrorMessage = "appVersion parameter is required.")]
            public string appVersion { get; set; }

            [Required(ErrorMessage = "appType parameter is required.")]
            public char appType { get; set; }
        }
        /// <summary>
        /// this class is input for get app version
        /// </summary>
        public class GetAppSettingPckg_In
        {
            [Required(ErrorMessage = "packageName parameter is required.")]
            public string packageName { get; set; }           
        }
        /// <summary>
        /// this class is output for get app version
        /// </summary>
        public class GetAppSetting_Out
        {
            public string Status { get; set; }
        }
        /// <summary>
        /// this class is output for get all app version
        /// </summary>
        public class GetAllAppSetting_Out
        {
            public int uniqueId { get; set; }
            public int gymOwnerId { get; set; }
            public string gymOwnerName { get; set; }
            public string appType { get; set; }
            public string appVersion { get; set; }          
            public string packageName { get; set; }  
            public string versionChanges { get; set; }
            public string activeStatus { get; set; }
            



        }
    }
}