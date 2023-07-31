using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using Fitness.Models.CommonModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Fitness.Helper
{
    public class SqlHelper
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["FitnessDBC"].ConnectionString;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProcedureName">pass the name of the procedure</param>
        /// <param name="Param">pass sqlparameter in arrayformat</param>
        /// <returns></returns>
        protected async Task<DataTable> GetDataTableFromUSPAsync(string ProcedureName, SqlParameter[] Param)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(ProcedureName, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(Param);

                    con.Open();
                    SqlDataReader Rdr = await cmd.ExecuteReaderAsync();

                    DataTable dt = new DataTable();
                    dt.Load(Rdr);

                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected DataTable GetDataTableFromUSP(string ProcedureName, SqlParameter[] Param)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(ProcedureName, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(Param);

                    con.Open();
                    SqlDataReader Rdr = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(Rdr);

                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// this method is used to insert,update,deleted .etc in db
        /// </summary>
        /// <param name="ProcedureName">pass procedure anem here</param>
        /// <param name="ListOfParameters">list of parameter</param>
        /// <returns></returns>
        protected async Task<DB_Response> ExecuteNonQueryAsync(string ProcedureName, List<SqlParameter> ListOfParameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(ProcedureName, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter StatusCode = new SqlParameter
                    {
                        ParameterName = "StatusCode",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Int,
                    };

                    SqlParameter Response = new SqlParameter
                    {
                        ParameterName = "Response",
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 150
                    };

                    SqlParameter[] arrParameter = { StatusCode, Response };

                    ListOfParameters.AddRange(arrParameter);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(ListOfParameters.ToArray<SqlParameter>());

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();

                    DB_Response DB_response = new DB_Response()
                    {
                        StatusCode = (int)(StatusCode.Value),
                        Response = Response.Value.ToString(),
                    };

                    return DB_response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this method is used to convert list to datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        /// <summary>
        /// this method is used to get the result from GetDataTableFromUSPAsync function
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        protected async Task<JArray> GetResultFromGetDataTableFromUSPAsync(string procedureName, SqlParameter[] Input)
        {
            try
            {
                DataTable dt = await GetDataTableFromUSPAsync(procedureName, Input);

                string dtToJson = JsonConvert.SerializeObject(dt, Formatting.Indented);

                JArray JsonArray = JsonConvert.DeserializeObject<JArray>(dtToJson);

                return JsonArray;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// this method is used to get response from ExecuteNonQueryAsync
        /// </summary>
        /// <param name="ParametersArray"></param>
        /// <returns></returns>
        protected async Task<DB_Response> GetResponseFromExecuteNonQueryAsync(string procedureName,SqlParameter[] ParametersArray)
        {
            try
            {
                List<SqlParameter> ListOfParameter = new List<SqlParameter>();
                ListOfParameter.AddRange(ParametersArray);

                DB_Response Response = await ExecuteNonQueryAsync(procedureName, ListOfParameter);
                return Response;
            }
            catch (Exception) { throw; }
        }
    }
}