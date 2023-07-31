using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.UserMaster
{
    public class BOL_MstrUserInBodyTest
    {
        /// <summary>
        /// this class is used as input for inserting UserInBodyTest
        /// </summary>
        public class InsertUserInBodyTest_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
            public int userId { get; set; }


            public string firstName { get; set; }

            public string lastName { get; set; }

            [Required(ErrorMessage = "Gender parameter is required")]
            public string gender { get; set; }


            public string dob { get; set; }

            [Required(ErrorMessage = "weight parameter is required")]
            public Decimal weight { get; set; }

            [Required(ErrorMessage = "height parameter is required")]
            public Decimal height { get; set; }
            public string mobileNo { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "fatPercentage(Integer) parameter is required.")]
            public int fatPercentage { get; set; }

            public string WorkOutStatus { get; set; }

            public Decimal WorkOutValue { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "age(Integer) parameter is required.")]
            public int age { get; set; }

            [Required(ErrorMessage = "BMR parameter is required")]
            public Decimal BMR { get; set; }

            [Required(ErrorMessage = "BMI parameter is required")]
            public Decimal BMI { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "TDEE(Integer) parameter is required.")]
            public int TDEE { get; set; }

            public string date { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }



        /// <summary>
        /// this class is used as input for inserting UserInBodyTest
        /// </summary>
        public class InsertUserInBodyTestDep_In
        {


            public string firstName { get; set; }

            public string dob { get; set; }

            [Required(ErrorMessage = "weight parameter is required")]
            public Decimal weight { get; set; }

            [Required(ErrorMessage = "height parameter is required")]
            public Decimal height { get; set; }
            public string mobileNo { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "fatPercentage(Integer) parameter is required.")]
            public int fatPercentage { get; set; }

            [Required(ErrorMessage = "Gender parameter is required")]
            public string gender { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "age(Integer) parameter is required.")]
            public int age { get; set; }

            [Required(ErrorMessage = "BMR parameter is required")]
            public Decimal BMR { get; set; }

            [Required(ErrorMessage = "BMI parameter is required")]
            public Decimal BMI { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "TDEE(Integer) parameter is required.")]
            public int TDEE { get; set; }

            public string date { get; set; }
            public string WorkOutStatus { get; set; }

            public string WorkOutValue { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }

        }

        /// <summary>
        /// this class is used as input for getting UserInBodyTest details
        /// </summary>
        public class GetUserInBodyTest_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "userId(Integer) parameter is required.")]
            public int userId { get; set; }
        }
        /// <summary>
        /// this class is used as output for getting UserInBodyTest details
        /// </summary>
        public class GetUserInBodyTest_Out
        {
            public int userId { get; set; }
            public string UserName { get; set; }
            public string dob { get; set; }
            public string gender { get; set; }
            public decimal weight { get; set; }
            public decimal height { get; set; }
            public int fatPercentage { get; set; }
            public decimal WorkOutValue { get; set; }
            public string WorkOutStatus { get; set; }
            public int age { get; set; }
            public decimal BMR { get; set; }
            public decimal BMI { get; set; }
            public int TDEE { get; set; }
            public string date { get; set; }

        }
    }
}