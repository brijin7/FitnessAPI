using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.MenuOption
{
    public static class BOL_MstrMenuOption
    {
        /// <summary>
        /// this class is used as input for inserting MenuOption
        /// </summary>
        public class InsertMenuOption_In
        {
            [Required]
            public string OptionName { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "CreatedBy(Integer) parameter is required.")]
            public int CreatedBy { get; set; }
        }
        /// <summary>
        /// this class is used as input for updating MenuOption
        /// </summary>
        public class UpdateMenuOption_In
        {
            [Required]
            public string OptionName { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "OptionId(Integer) parameter is required.")]
            public int OptionId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int UpdatedBy { get; set; }
        }

        /// <summary>
        /// this class is used as input for Activate Or Inactivate MenuOption
        /// </summary>
        public class ActiveOrInactiveMenuOption_In
        {
            [Required]
            public string QueryType { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "OptionId(Integer) parameter is required.")]
            public int OptionId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int UpdatedBy { get; set; }
        }
    }
}