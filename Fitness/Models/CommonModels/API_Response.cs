using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Models.CommonModels
{
    public class API_Success<T>
    {
        public int StatusCode { get; set; }
        public List<T> Response { get; set; }
    }
    public class API_JArraySuccess
    {
        public int StatusCode { get; set; }
        public JArray Response { get; set; }
    }
    public class API_SuccessOrErrorOrInfo
    {
        public int StatusCode { get; set; }
        public string Response { get; set; }
    }

    public class DB_Response
    {
        public int StatusCode { get; set; }
        public string Response { get; set; }
    }
    public class API_JObjectSuccess
    {
        public int StatusCode { get; set; }
        public JObject Response { get; set; }
    }
}