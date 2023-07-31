using Fitness.Helper;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Fitness.Models.BusinessObject.UserMenuAccess.BOL_MstrUserMenuAccess;
using System.Web.Security;
using Fitness.Models.CommonModels;

namespace Fitness.Models.DataAccessLayer.UserMenuAccess
{
    public class DAL_MstrUserAccessMenu : SqlHelper
    {
        readonly private static string GetProcedureName;
        readonly private static string InsertProcedureName;
        static DAL_MstrUserAccessMenu()
        {
            GetProcedureName = "usp_GetMstrUserMenuAccess";
            InsertProcedureName = "usp_MstrUserMenuAccess";
        }

        /// <summary>
        /// this Method is Used To Get Roles
        /// </summary>
        /// <returns></returns>
        public async Task<JArray> UD_GetRolesAsync()
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetRoles",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter[] parameterArray = { QueryType };

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, parameterArray);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// this  method is used to get Employee details form DataBase
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<JArray> UD_GetEmployeeAsync(GetEmployee_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetEmployee",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter BranchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.BranchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter RoleId = new SqlParameter
                {
                    ParameterName = "roleId",
                    Value = Input.RoleId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] parameterArray = { QueryType, BranchId, RoleId };
                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, parameterArray);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this  method is used to Get EmpName For Grid View details form DataBase
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<JArray> UD_GetEmpNameForGV(GetEmpNameForGV_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetEmpNameForGV",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter BranchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.BranchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter GymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.GymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] parameterArray = { QueryType, BranchId, GymOwnerId };

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, parameterArray);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this Method is Used To Get Menu Options
        /// </summary>
        /// <returns></returns>
        public async Task<JArray> UD_GetMenuOptionsAsync(GetAllOptionsName_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetAllOptionsName",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter BranchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.BranchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter RoleId = new SqlParameter
                {
                    ParameterName = "roleId",
                    Value = Input.RoleId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter EmpId = new SqlParameter
                {
                    ParameterName = "empId",
                    Value = Input.EmpId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter GymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.GymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] parameterArray = { QueryType, BranchId, RoleId, GymOwnerId, EmpId };

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, parameterArray);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// this Method is Used To Get Menu Options For Update
        /// </summary>
        /// <returns></returns>
        public async Task<JArray> UD_GetMenuOptionsForUpdateAsync(GetAllOptionsNameForUpdate_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "GetAllOptionsNameForUpdate",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter BranchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.BranchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter RoleId = new SqlParameter
                {
                    ParameterName = "roleId",
                    Value = Input.RoleId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter EmpId = new SqlParameter
                {
                    ParameterName = "empId",
                    Value = Input.EmpId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter GymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.GymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] parameterArray = { QueryType, BranchId, RoleId, GymOwnerId, EmpId };

                return await GetResultFromGetDataTableFromUSPAsync(GetProcedureName, parameterArray);
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to insert multiple menu access 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertUserAccessAsync(InsertMenuAccess_In Input)
        {
            try
            {
                int InsertCount = 0;
                int totalDataForInsert = Input.ListOfInsertMenuAccess.Count;
                string ErrorMessage = "";

                foreach (InsertMenuAccess item in Input.ListOfInsertMenuAccess)
                {
                    DB_Response res = await InsertMenuAccessAsync(item);
                    if (res.StatusCode == 1)
                    {
                        InsertCount++;
                    }
                    else
                    {
                        ErrorMessage += $"'{res.Response}',";
                    }
                }

                DB_Response response = new DB_Response();

                if (InsertCount == totalDataForInsert)
                {
                    response = new DB_Response()
                    {
                        StatusCode = 1,
                        Response = "Menu Access Rights Inserted Successfully !!!."
                    };
                }
                else
                {
                    response = new DB_Response()
                    {
                        StatusCode = 0,
                        Response = $"{ErrorMessage.TrimEnd(',')}"
                    };
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to insert menu access in db
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        private async Task<DB_Response> InsertMenuAccessAsync(InsertMenuAccess Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter GymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.GymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter BranchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.BranchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter EmpId = new SqlParameter
                {
                    ParameterName = "empId",
                    Value = Input.EmpId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter RoleId = new SqlParameter
                {
                    ParameterName = "RoleId",
                    Value = Input.RoleId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter OptionId = new SqlParameter
                {
                    ParameterName = "optionId",
                    Value = Input.OptionId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter ViewRights = new SqlParameter
                {
                    ParameterName = "ViewRights",
                    Value = Input.ViewRights,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };

                SqlParameter AddRights = new SqlParameter
                {
                    ParameterName = "AddRights",
                    Value = Input.AddRights,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };

                SqlParameter EditRights = new SqlParameter
                {
                    ParameterName = "editRights",
                    Value = Input.EditRights,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };

                SqlParameter DeleteRights = new SqlParameter
                {
                    ParameterName = "DeleteRights",
                    Value = Input.DeleteRights,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };

                SqlParameter ActiveStatus = new SqlParameter
                {
                    ParameterName = "activeStatus",
                    Value = Input.ActiveStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };

                SqlParameter CreatedBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.CreatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] parameterArray =
                    {
                    QueryType,
                    GymOwnerId,
                    BranchId,
                    EmpId,
                    RoleId,
                    OptionId,
                    ViewRights,
                    AddRights,
                    EditRights,
                    DeleteRights,
                    ActiveStatus,
                    CreatedBy
                };

                return await GetResponseFromExecuteNonQueryAsync(InsertProcedureName, parameterArray);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to update multiple menu options
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<DB_Response> UD_UpdateUserAccessAsync(UpdateMenuAccess_In Input)
        {
            try
            {
                int UpdateCount = 0;
                int totalDataForUpdate = Input.listOfUpdateMenuAccess.Count;
                string ErrorMessage = "";

                foreach (UpdateMenuAccess item in Input.listOfUpdateMenuAccess)
                {
                    DB_Response res = await UpdateMenuAccessAsync(item);
                    if (res.StatusCode == 1)
                    {
                        UpdateCount++;
                    }
                    else
                    {
                        ErrorMessage += $"'{res.Response}',";
                    }
                }

                DB_Response response = new DB_Response();

                if (UpdateCount == totalDataForUpdate)
                {
                    response = new DB_Response()
                    {
                        StatusCode = 1,
                        Response = "Menu Access Rights Updated Successfully !!!."
                    };
                }
                else
                {
                    response = new DB_Response()
                    {
                        StatusCode = 0,
                        Response = $"{ErrorMessage.TrimEnd(',')}"
                    };
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to update menu options
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        private async Task<DB_Response> UpdateMenuAccessAsync(UpdateMenuAccess Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150
                };
                SqlParameter GymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.GymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter MenuOptionAcessId = new SqlParameter
                {
                    ParameterName = "MenuOptionAcessId",
                    Value = Input.MenuOptionAcessId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter BranchId = new SqlParameter
                {
                    ParameterName = "branchId",
                    Value = Input.BranchId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter EmpId = new SqlParameter
                {
                    ParameterName = "empId",
                    Value = Input.EmpId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter RoleId = new SqlParameter
                {
                    ParameterName = "RoleId",
                    Value = Input.RoleId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter OptionId = new SqlParameter
                {
                    ParameterName = "optionId",
                    Value = Input.OptionId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter ViewRights = new SqlParameter
                {
                    ParameterName = "ViewRights",
                    Value = Input.ViewRights,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };

                SqlParameter AddRights = new SqlParameter
                {
                    ParameterName = "AddRights",
                    Value = Input.AddRights,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };

                SqlParameter EditRights = new SqlParameter
                {
                    ParameterName = "editRights",
                    Value = Input.EditRights,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };

                SqlParameter DeleteRights = new SqlParameter
                {
                    ParameterName = "DeleteRights",
                    Value = Input.DeleteRights,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };

                SqlParameter ActiveStatus = new SqlParameter
                {
                    ParameterName = "activeStatus",
                    Value = Input.ActiveStatus,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };

                SqlParameter UpdatedBy = new SqlParameter
                {
                    ParameterName = "UpdatedBy",
                    Value = Input.UpdatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] parameterArray =
                    {
                    QueryType,
                    MenuOptionAcessId,
                    GymOwnerId,
                    BranchId,
                    EmpId,
                    RoleId,
                    OptionId,
                    ViewRights,
                    AddRights,
                    EditRights,
                    DeleteRights,
                    ActiveStatus,
                    UpdatedBy
                };

                return await GetResponseFromExecuteNonQueryAsync(InsertProcedureName, parameterArray);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}