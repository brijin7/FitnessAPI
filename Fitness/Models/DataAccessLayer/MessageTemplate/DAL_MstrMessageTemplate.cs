using Fitness.Helper;
using Fitness.Models.CommonModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.MessageTemplate.BOL_MstrMessageTemplate;

namespace Fitness.Models.DataAccessLayer.MessageTemplate
{
    public class DAL_MstrMessageTemplate : SqlHelper
    {
        /// <summary>
        /// this method is used to insert details in MessageTemplatemstr in db
        /// </summary>
        /// <param name="Input">InsertMessageTemplate class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertMessageTemplateMasterAsync(InsertMessageTemplate_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Insert",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter messageHeader = new SqlParameter
                {
                    ParameterName = "messageHeader",
                    Value = Input.messageHeader,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter subject = new SqlParameter
                {
                    ParameterName = "subject",
                    Value = Input.subject,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter messageBody = new SqlParameter
                {
                    ParameterName = "messageBody",
                    Value = Input.messageBody,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter templateType = new SqlParameter
                {
                    ParameterName = "templateType",
                    Value = Input.templateType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };
                SqlParameter peid = new SqlParameter
                {
                    ParameterName = "peid",
                    Value = Input.peid,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                };
                SqlParameter tpid = new SqlParameter
                {
                    ParameterName = "tpid",
                    Value = Input.tpid,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, messageHeader, subject, messageBody, templateType, peid, tpid, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrMessageTemplate", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch MessageTemplatemstr details from db
        /// </summary>
        /// <param name="Input">GetMessageTemplateMstr_In class as input parameter</param>
        /// <returns>list of GetMessageTemplateMstr_Out as output</returns>
        public async Task<List<GetMessageTemplateMstr_Out>> UD_GetMessageTemplateMstrAsync()
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getMessageTemplate",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter[] allParameters = { queryType };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrMessageTemplate", allParameters);

                List<GetMessageTemplateMstr_Out> lstOfOutput = new List<GetMessageTemplateMstr_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetMessageTemplateMstr_Out Output = new GetMessageTemplateMstr_Out();
                    Output.uniqueId = (int)(dr["uniqueId"]);
                    Output.messageHeader = dr["messageHeader"].ToString();
                    Output.subject = dr["subject"].ToString();
                    Output.messageBody = dr["messageBody"].ToString();
                    Output.templateType = Convert.ToChar(dr["templateType"]);
                    Output.peid = dr["peid"].ToString();
                    Output.tpid = dr["tpid"].ToString();

                    lstOfOutput.Add(Output);
                }

                return lstOfOutput;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to update MessageTemplatemstr details in db
        /// </summary>
        /// <param name="Input">UpdateMessageTemplateMstr_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateMessageTemplateMstrAsync(UpdateMessageTemplateMstr_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "Update",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter uniqueId = new SqlParameter
                {
                    ParameterName = "uniqueId",
                    Value = Input.uniqueId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter messageHeader = new SqlParameter
                {
                    ParameterName = "messageHeader",
                    Value = Input.messageHeader,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter subject = new SqlParameter
                {
                    ParameterName = "subject",
                    Value = Input.subject,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter messageBody = new SqlParameter
                {
                    ParameterName = "messageBody",
                    Value = Input.messageBody,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                SqlParameter templateType = new SqlParameter
                {
                    ParameterName = "templateType",
                    Value = Input.templateType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char,
                    Size = 1
                };
                SqlParameter peid = new SqlParameter
                {
                    ParameterName = "peid",
                    Value = Input.peid,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                };
                SqlParameter tpid = new SqlParameter
                {
                    ParameterName = "tpid",
                    Value = Input.tpid,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, uniqueId, messageHeader, subject, messageBody, templateType, peid, tpid, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrMessageTemplate", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}