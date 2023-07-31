using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.Models.BusinessObject.EmployeeMaster
{
    public static class BOL_MstrEmployee
    {
        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class GetMstrEmployee_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
            public int branchId { get; set; }
        }

        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class GetMstrEmployee_Out
        {
            public int gymOwnerId { get; set; }
            public int branchId { get; set; }
            public string branchName { get; set; }
            public int empId { get; set; }
            public string empType { get; set; }
            public string empTypeName { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string designation { get; set; }
            public string designationName { get; set; }
            public string district { get; set; }
            public string state { get; set; }
            public string city { get; set; }
            public string zipcode { get; set; }
            public string department { get; set; }
            public string departmentName { get; set; }
            public string gender { get; set; }
            public string addressLine1 { get; set; }
            public string addressLine2 { get; set; }
            public string maritalStatus { get; set; }
            public string dob { get; set; }
            public string doj { get; set; }
            public string aadharId { get; set; }
            public string photoLink { get; set; }
            public string mobileNo { get; set; }
            public string mailId { get; set; }
            public string passWord { get; set; }
            public string shiftId { get; set; }
            public string shiftName { get; set; }
            public string roleId { get; set; }
            public string Role { get; set; }
            public string mobileAppAccess { get; set; }
            public string activeStatus { get; set; }


        }

        /// <summary>
        /// this class is used to get the input values
        /// </summary>
        public class ddlMstrEmployee_In
        {

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
            public int branchId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "designationId(Int) parameter is required")]
            public int designationId { get; set; }
        }


        /// <summary>
        /// this class is used to bind the output values
        /// </summary>
        public class ddlMstrEmployee_Out
        {
            public int empId { get; set; }
            public string empName { get; set; }

        }
        /// <summary>
        /// this class is used as input for inserting EmployeeMaster
        /// </summary>
        public class InsertMstrEmployee_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Branch Id(Int) parameter is required.")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Emp Type (Int) parameter is required.")]
            public int empType { get; set; }

            [Required(ErrorMessage = "FirstName parameter is required")]
            public string firstName { get; set; }

            [Required(ErrorMessage = "LastName parameter is required")]
            public string lastName { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Designation(int) parameter is required")]
            public int designation { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Department(int) parameter is required")]
            public int department { get; set; }

            [Required(ErrorMessage = "Gender parameter is required")]
            public string gender { get; set; }

            public string addressLine1 { get; set; }
            public string addressLine2 { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Zipcode(Int) parameter is required.")]
            public int zipcode { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string state { get; set; }
            public string maritalStatus { get; set; }
            [Required(ErrorMessage = "Date Of Birth parameter is required")]
            public string dob { get; set; }
            [Required(ErrorMessage = "Date Of Joining parameter is required")]
            public string doj { get; set; }
            public string aadharId { get; set; }
          
            public string photoLink { get; set; }

            [Required(ErrorMessage = "Mobile Number parameter is required")]
            public string mobileNo { get; set; }

            [Required(ErrorMessage = "Password parameter is required")]
            public string passWord { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "ShiftId(int) parameter is required")]
            public int shiftId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "RoleId(int) parameter is required")]
            public int roleId { get; set; }
            public string mailId { get; set; }
            public string mobileAppAccess { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "createdBy(Integer) parameter is required.")]
            public int createdBy { get; set; }


        }

        /// <summary>
        /// this class is used as input for updating EmployeeMaster
        /// </summary>
        public class UpdateMstrEmployee_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "empId(Int) parameter is required.")]
            public int empId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Branch Id(Int) parameter is required.")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Emp Type (Int) parameter is required.")]
            public int empType { get; set; }

            [Required(ErrorMessage = "FirstName parameter is required")]
            public string firstName { get; set; }

            [Required(ErrorMessage = "LastName parameter is required")]
            public string lastName { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Designation(int) parameter is required")]
            public int designation { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Department(int) parameter is required")]
            public int department { get; set; }

            [Required(ErrorMessage = "Gender parameter is required")]
            public string gender { get; set; }

            public string addressLine1 { get; set; }
            public string addressLine2 { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Zipcode(Int) parameter is required.")]
            public int zipcode { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string state { get; set; }
            public string maritalStatus { get; set; }
            [Required(ErrorMessage = "Date Of Birth parameter is required")]
            public string dob { get; set; }
            [Required(ErrorMessage = "Date Of Joining parameter is required")]
            public string doj { get; set; }
            public string aadharId { get; set; }
        
            public string photoLink { get; set; }

            [Required(ErrorMessage = "Mobile Number parameter is required")]
            public string mobileNo { get; set; }

            [Required(ErrorMessage = "Password parameter is required")]
            public string passWord { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "ShiftId(int) parameter is required")]
            public int shiftId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "RoleId(int) parameter is required")]
            public int roleId { get; set; }
            public string mailId { get; set; }
            public string mobileAppAccess { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Integer) parameter is required.")]
            public int updatedBy { get; set; }


        }


        /// <summary>
        /// this class is used as input parameter for update employee master
        /// </summary>
        public class ActivateOrInactivateMstrEmployee_In
        {
            [Required(ErrorMessage = "QueryType parameter is required")]
            public string queryType { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "empId(Int) parameter is required.")]
            public int empId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "gymOwnerId(Int) parameter is required.")]
            public int gymOwnerId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "branchId(Int) parameter is required")]
            public int branchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "updatedBy(Int) parameter is required.")]
            public int updatedBy { get; set; }
        }


    }
}