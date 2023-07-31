using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace Fitness.Models.BusinessObject.SendandVerifyOtp
{
    public static class BOL_SendandVerifyOtp
    {
        /// <summary>
        /// this class is used as input for Send Otp To user
        /// </summary>
        public class InsertMstrUserSendOtp_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }
            
            [Required(ErrorMessage = "Mobile No parameter is required")]
            public string mobileNo { get; set; }
        }
        /// <summary>
        /// this class is used as input for Verify Otp To user
        /// </summary>
        public class InsertMstrUserVerifyOtp_In
        {
            [Required(ErrorMessage = "Mobile No parameter is required")]
            public string mobileNo { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "OTP(Int) parameter is required.")]
            public int otp { get; set; }
        }
        public class SendSmSBulk
        {
           
            public string route { get; set; }
            public string sender_id { get; set; }
            public string message { get; set; }
            public string language { get; set; }
            public string flash { get; set; }
            public string numbers { get; set; }
        }

    }
}