using Fitness.Models.CommonModels;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Fitness.Controllers.UploadImage
{
    [RoutePrefix("api")]
    [AllowAnonymous]
    public class ImageController : ApiController
    {
        string CS = ConfigurationManager.ConnectionStrings["FitnessImageDBC"].ConnectionString;
        /// <summary>
        /// this method is used to upload Image in mongoDb
        /// </summary>
        /// /Changed By Suriya
        /// 02-DEC-2022
        /// <returns>it returns url 0f uploaded image</returns>
        [HttpPost]
        [Route("UploadImage")]
        public async Task<IHttpActionResult> ImageAPI()
        {
            try
            {
                DB_Response response = new DB_Response();

                if (!Request.Content.IsMimeMultipartContent())
                {
                    response = new DB_Response()
                    {
                        StatusCode = 0,
                        Response = "UnsupportedMediaType."
                    };
                    return Content(HttpStatusCode.UnsupportedMediaType, response);
                }
                var File = HttpContext.Current.Request.Files["Image"];


                IList<string> AllowedFileExtensions = new List<string> { "jpg", "jpeg", "png" };

                if (!AllowedFileExtensions.Contains(File.FileName.Split('.')[1].ToLower()))
                {
                    response = new DB_Response()
                    {
                        StatusCode = 0,
                        Response = "only .jpg, .jpeg, .png Image formats are supported."
                    };
                    return Content(HttpStatusCode.BadRequest, response);
                }

                var FileExtension = HttpContext.Current.Request.Files["Image"].FileName.Split('.')[1];

                MongoClient client = new MongoClient(CS);
                IMongoDatabase database = client.GetDatabase("fitness");
                var collection = database.GetCollection<GridFSFileInfo>("fitness");
                GridFSBucket bucket = new GridFSBucket(database, new GridFSBucketOptions
                {
                    BucketName = "fitnessImg",
                });
                var id = await bucket.UploadFromStreamAsync(File.FileName, File.InputStream);

                if (id != null)
                {
                    Uri baseUri = new Uri(Request.RequestUri.AbsoluteUri);
                    string getImagePath = baseUri.ToString().Replace("/UploadImage", $"/GetImage?ImageId={id}.{FileExtension}");

                    response = new DB_Response()
                    {
                        StatusCode = 1,
                        Response = getImagePath
                    };
                }
                else
                {
                    response = new DB_Response()
                    {
                        StatusCode = 0,
                        Response = "Sorry Could Not Upload Image..!!!"
                    };
                }
                return Ok(response);
            }
            catch (Exception Ex)
            {
                return Content(HttpStatusCode.InternalServerError, Ex.Message.ToString());
            }
        }

        /// <summary>
        /// this method is used to getImage from database
        /// </summary>
        /// <param name="ImageId">takes imageId as input parameter</param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Route("GetImage")]
        public async Task<IHttpActionResult> ShowImage([FromUri] string ImageId)
        {
            try
            {
                string Id = ImageId.Split('.')[0];
                string Extension = ImageId.Split('.')[1];

                MongoClient client = new MongoClient(CS);
                IMongoDatabase database = client.GetDatabase("fitness");
                var collection = database.GetCollection<GridFSFileInfo>("fitness");
                GridFSBucket bucket = new GridFSBucket(database, new GridFSBucketOptions
                {
                    BucketName = "fitnessImg",
                });

                ObjectId objId = new ObjectId(Id);

                var filter = Builders<GridFSFileInfo>.Filter.Eq("_id", objId);
                var file = await (await bucket.FindAsync(filter)).ToListAsync();

                if (file.Count > 0)
                {
                    byte[] byteImage = await bucket.DownloadAsBytesAsync(file.FirstOrDefault().Id);
                    MemoryStream stream = new MemoryStream(byteImage);

                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StreamContent(stream);
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue($"image/{Extension}");

                    return ResponseMessage(response);

                }
                else
                {
                    return Content(HttpStatusCode.NotFound, $"No Images Found !!!");
                }
            }
            catch (Exception Ex)
            {
                return Content(HttpStatusCode.InternalServerError, Ex.Message.ToString());
            }
        }

        /// <summary>
        /// this method is used to get success or no records found response
        /// </summary>
        /// <param name="DB_res">DB_Response class as input parameter</param>
        /// <param name="CUD">CUD Create Update Delete</param>
        /// <returns></returns>
        private IHttpActionResult GetDBSuccessOrInfoResponse(DB_Response DB_res, string CUD)
        {
            if (DB_res.StatusCode == 0)
            {
                API_SuccessOrErrorOrInfo API_InfoRes = new API_SuccessOrErrorOrInfo()
                {
                    StatusCode = DB_res.StatusCode,
                    Response = DB_res.Response
                };
                return Content(HttpStatusCode.OK, API_InfoRes);
            }
            else
            {
                API_SuccessOrErrorOrInfo API_SuccessRes = new API_SuccessOrErrorOrInfo()
                {
                    StatusCode = DB_res.StatusCode,
                    Response = DB_res.Response
                };
                if (CUD == "Create")
                {
                    return Content(HttpStatusCode.Created, API_SuccessRes);
                }
                else
                {
                    return Ok(API_SuccessRes);
                }

            }
        }


    }
}
