using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.UserNotification
{
    public class BOL_mstrUserNotification
    {
        /// <summary>
        /// this class is used as input for Send Otp To user
        /// </summary>
        public class UpdateMstrUserNotification_In
        {          
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "notificationId(int) parameter is required")]
            public int notificationId { get; set; }
        }

        /// <summary>
        /// this class is used as input for Send Otp To user
        /// </summary>
        public class GetMstrUserNotification_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(int) parameter is required")]
            public int userId { get; set; }

            public string readstatus { get; set; }
        }
    }
}