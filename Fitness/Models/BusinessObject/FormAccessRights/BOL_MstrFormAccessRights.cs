using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.FormAccessRights
{
    public static class BOL_MstrFormAccessRights
    {
        public class GetFormAccessRights_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "BranchId parameter is required")]
            public int BranchId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId parameter is required")]
            public int GymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "UserId parameter is required")]
            public int UserId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "RoleId parameter is required")]
            public int RoleId { get; set; }
        }
    }
}