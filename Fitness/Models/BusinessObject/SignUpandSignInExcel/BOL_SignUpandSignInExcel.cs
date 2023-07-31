using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.SignUpandSignInExcel
{
    public static class BOL_SignUpandSignInExcel
    {
        /// <summary>
        /// this method is used as input for insert in SignUp
        /// </summary>
        public class InsertMstrUserSignUp_In
        {
            public List<MstrUserSignUp> ListOfSignup { get; set; }
            public MastrSignUpCommon SignUpCommon { get; set; }
        }
        /// <summary>
        /// this class contains details of MstrUserSignUp
        /// </summary>
        public class MstrUserSignUp
        {
            public string MobileNo { get; set; }
            public string MailId { get; set; }
            public string Password { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Dob { get; set; }
            public string Gender { get; set; }
            public string MaritalStatus { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string Zipcode { get; set; }
            public string City { get; set; }
            public string District { get; set; }
            public string State { get; set; }
            public decimal Weight { get; set; }
            public decimal Height { get; set; }
            public int FatPercentage { get; set; }
            public string Date { get; set; }
            public string WorkOutStatus { get; set; }
            public decimal WorkOutValue { get; set; }
            public int Age { get; set; }
            public decimal BMR { get; set; }
            public decimal BMI { get; set; }
            public int TDEE { get; set; }
        }

        public class MastrSignUpCommon
        {
            public int RoleId { get; set; }
            public int CreatedBy { get; set; }
            public int GymOwnerId { get; set; }
            public int BranchId { get; set; }
        }
    }
}