using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.SingleLogin
{
    public static class BOL_SingleLogin
    {
        /// <summary>
        /// Login Input
        /// </summary>
        public class UpdateSingleLogin_In
        {
            [Required]
            [Range(0, int.MaxValue, ErrorMessage = "UserId Parameter Is Required.")]
            public int UserId { get; set; }

            [Required(ErrorMessage = "SessionId Parameter Is Required.")]
            public string SessionId { get; set; }
        }

        /// <summary>
        /// ReLogin Input
        /// </summary>
        public class UpdateSingleReLogin_In
        {
            [Required]
            [Range(0, int.MaxValue, ErrorMessage = "UserId Parameter Is Required.")]
            public int UserId { get; set; }

            [Required(ErrorMessage = "SessionId Parameter Is Required.")]
            public string SessionId { get; set; }
        }

        /// <summary>
        /// GetUserSessionId Input
        /// </summary>
        public class GetUserSessionId_In
        {
            [Required]
            [Range(0, int.MaxValue, ErrorMessage = "UserId Parameter Is Required.")]
            public int UserId { get; set; }

            [Required(ErrorMessage = "SessionId Parameter Is Required.")]
            public string SessionId { get; set; }
        }
    }
}