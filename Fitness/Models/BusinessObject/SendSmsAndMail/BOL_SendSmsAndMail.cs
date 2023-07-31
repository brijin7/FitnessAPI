using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.SendSmsAndMail
{
    public class BOL_SendSmsAndMail
    {
        public class SendSmsandMailClass
        {
            public string queryType { get; set; }
            [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile No")]
            public string mobileNo { get; set; }

            [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid mail Id")]
            public string mailId { get; set; }

            public string userId { get; set; }
           
        }
        public class SendNotification
        {
            public string userId { get; set; }
            public string title { get; set; }
            public string body { get; set; }

        }

        public class User
        {
            public string userId { get; set; }
            public string userName { get; set; }
            public string mobileNo { get; set; }
            public string mailId { get; set; }

        }
        public class Message
        {
            public int uniqueId { get; set; }
            public string messageHeader { get; set; }
            public string subject { get; set; }
            public string messageBody { get; set; }
            public string templateType { get; set; }
            public string peid { get; set; }
            public string tpid { get; set; }

        }

        public class SendSmsNotificationClass
        {
            public string queryType { get; set; }
            [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile No")]
            public string mobileNo { get; set; }
            public string link { get; set; }
            public string Userid { get; set; }


        }
    }
}