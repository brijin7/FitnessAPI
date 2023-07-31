using Fitness.Helper;
using Fitness.Models.CommonModels;
using MongoDB.Bson.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static Fitness.Models.BusinessObject.FaqMaster.BOL_FaqMaster;

namespace Fitness.Models.DataAccessLayer.FaqMaster
{
    public class DAL_FaqMaster : SqlHelper
    {
        /// <summary>
        /// this method is used to insert details in Faqmstr in db
        /// </summary>
        /// <param name="Input">InsertFaq_In class as input parameter</param>
        /// <returns></returns>
        public async Task<DB_Response> UD_InsertFaqMasterAsync(InsertFaq_In Input)
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
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter offerId = new SqlParameter
                {
                    ParameterName = "offerId",
                    Value = Input.offerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter question = new SqlParameter
                {
                    ParameterName = "question",
                    Value = Input.question,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter answer = new SqlParameter
                {
                    ParameterName = "answer",
                    Value = Input.answer,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter questionType = new SqlParameter
                {
                    ParameterName = "questionType",
                    Value = Input.questionType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter createdBy = new SqlParameter
                {
                    ParameterName = "createdBy",
                    Value = Input.createdBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, gymOwnerId, offerId, question, answer, questionType, createdBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrFaq", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to fetch Faqmstr details from db
        /// </summary>
        /// <param name="Input">GetFaqMstr_In class as input parameter</param>
        /// <returns>list of GetFaqMstr_Out as output</returns>
        public async Task<List<GetFaqMstr_Out>> UD_GetFaqMstrAsync(GetFaqMstr_In Input)
        {
            try
            {
                SqlParameter queryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = "getFaq",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter questionType = new SqlParameter
                {
                    ParameterName = "questionType",
                    Value = Input.questionType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Char
                };

                SqlParameter[] allParameters = { queryType,gymOwnerId,questionType };

                DataTable dt = await GetDataTableFromUSPAsync("usp_GetMstrFaq", allParameters);

                List<GetFaqMstr_Out> lstOfOutput = new List<GetFaqMstr_Out>();
                foreach (DataRow dr in dt.Rows)
                {
                    GetFaqMstr_Out Output = new GetFaqMstr_Out();
                    Output.gymOwnerId = (int)(dr["gymOwnerId"]);
                    Output.faqId = (int)(dr["faqId"]);
                    Output.offerId = (int)(dr["offerId"]);
                    Output.question = dr["question"].ToString();
                    Output.answer = dr["answer"].ToString();
                    Output.questionType = (int)(dr["questionType"]);
                    Output.activeStatus = dr["activeStatus"].ToString();

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
        /// this method is used to update Faqmstr details in db
        /// </summary>
        /// <param name="Input">UpdateFaqMstr_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_UpdateFaqMstrAsync(UpdateFaqMstr_In Input)
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
                SqlParameter gymOwnerId = new SqlParameter
                {
                    ParameterName = "gymOwnerId",
                    Value = Input.gymOwnerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter faqId = new SqlParameter
                {
                    ParameterName = "faqId",
                    Value = Input.faqId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter offerId = new SqlParameter
                {
                    ParameterName = "offerId",
                    Value = Input.offerId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter question = new SqlParameter
                {
                    ParameterName = "question",
                    Value = Input.question,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter answer = new SqlParameter
                {
                    ParameterName = "answer",
                    Value = Input.answer,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                };
                SqlParameter questionType = new SqlParameter
                {
                    ParameterName = "questionType",
                    Value = Input.questionType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };

                SqlParameter[] allParameters = { QueryType, faqId,gymOwnerId, offerId, question, answer, questionType, updatedBy };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrFaq", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to activate and inactivate Faq master
        /// </summary>
        /// <param name="Input">ActivateOrInactivateFaqMstr_In class as input parameter</param>
        /// <returns>DB_Response class as output</returns>
        public async Task<DB_Response> UD_ActivateOrInactivateFaqMstrAsyn(ActivateOrInactivateFaqMstr_In Input)
        {
            try
            {
                SqlParameter QueryType = new SqlParameter
                {
                    ParameterName = "queryType",
                    Value = Input.queryType,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100
                };

                SqlParameter updatedBy = new SqlParameter
                {
                    ParameterName = "updatedBy",
                    Value = Input.updatedBy,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int,
                };
                SqlParameter faqId = new SqlParameter
                {
                    ParameterName = "faqId",
                    Value = Input.faqId,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter[] allParameters = { QueryType, updatedBy, faqId };

                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(allParameters);

                return await ExecuteNonQueryAsync("usp_MstrFaq", ListOfParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}