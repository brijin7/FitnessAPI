using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.SignUpandSignIn
{
    public static class BOL_SignUpandSignIn
    {
        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class InsertMstrUserSignIn_In
        {
            [Required(ErrorMessage = "MobileNo Or MailId parameter is required")]
            public string mobileNo { get; set; }
           
            public string passWord { get; set; }
        }
        /// <summary>
        /// this class is used to bind the output values
        /// </summary>

        public class InsertMstrUserSignIn_Out
        {
            public int userId { get; set; }
            public string mobileNo { get; set; }
            public string mailId { get; set; }
            public string roleId { get; set; }
            public string roleName { get; set; }
            public string UserName { get; set; }
            public string Image { get; set; }
            public string activeStatus { get; set; }
            public string gymOwnerId { get; set; }
            public string branchId { get; set; }
        }

        /// <summary>
        /// this class is used as input for inserting EmployeeMaster
        /// </summary>
        public class InsertMstrUserSignUp_In
        {
            public string mobileNo { get; set; }
            public string mailId { get; set; }           
            public string passWord { get; set; }
        }

        /// <summary>
        /// this class is used as input for Updating EmployeeMaster
        /// </summary>
        public class UpdateMstrUserPassword_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
            public int userId { get; set; }
            
            public string passWord { get; set; }
        }
    }
}