using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.GetGymOwnerAndBranch
{
    public static class BOL_GetGymOwnerAndBranch
    {
        public class GetBranchId
        {
            [Required(ErrorMessage = "GymOwnerId Parameter Is Required.")]
            public int GymOwnerId { get; set; }
        }
    }
}