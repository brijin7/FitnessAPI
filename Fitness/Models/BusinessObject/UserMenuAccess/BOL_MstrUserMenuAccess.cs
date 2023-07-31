using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Fitness.Models.BusinessObject.SendSmsAndMail.BOL_SendSmsAndMail;

namespace Fitness.Models.BusinessObject.UserMenuAccess
{
    public static class BOL_MstrUserMenuAccess
    {
        /// <summary>
        /// this class is used as input for GetEmployee
        /// </summary>
        public class GetEmployee_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "RoleId parameter is required")]
            public int RoleId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "BranchId parameter is required")]
            public int BranchId { get; set; }
        }

        /// <summary>
        /// this class is used as input for GetAllOptionsName
        /// </summary>
        public class GetAllOptionsName_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "RoleId parameter is required")]
            public int RoleId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "BranchId parameter is required")]
            public int BranchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId parameter is required")]
            public int GymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "EmpId parameter is required")]
            public int EmpId { get; set; }
        }

        /// <summary>
        /// this class is used as input for GetAllOptionsNameForUpdate
        /// </summary>
        public class GetAllOptionsNameForUpdate_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "RoleId parameter is required")]
            public int RoleId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "BranchId parameter is required")]
            public int BranchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId parameter is required")]
            public int GymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "EmpId parameter is required")]
            public int EmpId { get; set; }
        }

        /// <summary>
        /// this class is used as input for GetAllOptionsName
        /// </summary>
        public class GetEmpNameForGV_In
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "BranchId parameter is required")]
            public int BranchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId parameter is required")]
            public int GymOwnerId { get; set; }
        }

        /// <summary>
        /// this class is used as input for insert menu access 
        /// </summary>
        public class InsertMenuAccess_In
        {
            public List<InsertMenuAccess> ListOfInsertMenuAccess { get; set; }

        }
        public class InsertMenuAccess
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId parameter is required")]
            public int GymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "BranchId parameter is required")]
            public int BranchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "empId parameter is required")]
            public int EmpId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "RoleId parameter is required")]
            public int RoleId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "OptionId parameter is required")]
            public int OptionId { get; set; }

            [Required(ErrorMessage = "ViewRights parameter is required")]
            public string ViewRights { get; set; }
            [Required(ErrorMessage = "AddRights parameter is required")]
            public string AddRights { get; set; }

            [Required(ErrorMessage = "EditRights parameter is required")]
            public string EditRights { get; set; }

            [Required(ErrorMessage = "DeleteRights parameter is required")]
            public string DeleteRights { get; set; }

            [Required(ErrorMessage = "ActiveStatus parameter is required")]
            public string ActiveStatus { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "CreatedBy parameter is required")]
            public int CreatedBy { get; set; }
        }
        /// <summary>
        /// this class is used as input for updte menu access 
        /// </summary>
        /// 

        public class UpdateMenuAccess_In
        {
            public List<UpdateMenuAccess> listOfUpdateMenuAccess { get; set; }
        }
        public class UpdateMenuAccess
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "MenuOptionAcessId parameter is required")]
            public int MenuOptionAcessId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "GymOwnerId parameter is required")]
            public int GymOwnerId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "BranchId parameter is required")]
            public int BranchId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "empId parameter is required")]
            public int EmpId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "RoleId parameter is required")]
            public int RoleId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "OptionId parameter is required")]
            public int OptionId { get; set; }

            [Required(ErrorMessage = "ViewRights parameter is required")]
            public string ViewRights { get; set; }
            [Required(ErrorMessage = "AddRights parameter is required")]
            public string AddRights { get; set; }

            [Required(ErrorMessage = "EditRights parameter is required")]
            public string EditRights { get; set; }

            [Required(ErrorMessage = "DeleteRights parameter is required")]
            public string DeleteRights { get; set; }

            [Required(ErrorMessage = "ActiveStatus parameter is required")]
            public string ActiveStatus { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "UpdatedBy parameter is required")]
            public int UpdatedBy { get; set; }
        }
    }
}