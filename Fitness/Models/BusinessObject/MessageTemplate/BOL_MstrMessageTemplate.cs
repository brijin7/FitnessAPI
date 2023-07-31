using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Fitness.Models.BusinessObject.MessageTemplate
{
    public class BOL_MstrMessageTemplate
    {
        /// <summary>
        /// this class is used as input for inserting mstrmessageTemplate
        /// </summary>
        public class InsertMessageTemplate_In
        {

            [Required(ErrorMessage = "messageHeader parameter is required")]
            public string messageHeader { get; set; }

            [Required(ErrorMessage = "subject parameter is required")]
            public string subject { get; set; }

            [Required(ErrorMessage = "messageBody parameter is required")]
            public string messageBody { get; set; }

            [Required]
            [Range(1, char.MaxValue, ErrorMessage = "templateType(Character 1) parameter is required.")]
            public char templateType { get; set; }

            public string peid { get; set; }
            public string tpid { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }
        }

       
        /// <summary>
        /// this class is used as output for getting MessageTemplatemstr details
        /// </summary>
        public class GetMessageTemplateMstr_Out
        {
            public int uniqueId { get; set; }
            public string messageHeader { get; set; }
            public string subject { get; set; }
            public string messageBody { get; set; }
            public char templateType { get; set; }
            public string peid { get; set; }
            public string tpid { get; set; }
        }

        /// <summary>
        /// this class is used as input parameter for updateMessageTemplate master
        /// </summary>
        public class UpdateMessageTemplateMstr_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "UniqueId(Integer) parameter is required.")]
            public string uniqueId { get; set; }

            [Required(ErrorMessage = "messageHeader parameter is required")]
            public string messageHeader { get; set; }

            [Required(ErrorMessage = "subject parameter is required")]
            public string subject { get; set; }

            [Required(ErrorMessage = "messageBody parameter is required")]
            public string messageBody { get; set; }

            [Required]
            [Range(1, char.MaxValue, ErrorMessage = "templateType(Character 1) parameter is required.")]
            public char templateType { get; set; }

            public string peid { get; set; }
            public string tpid { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }
        }

    }
}