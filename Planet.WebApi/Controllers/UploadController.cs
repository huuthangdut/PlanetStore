using Planet.Data.Core;
using Planet.Infrastructure.Core;
using Planet.Services.Core;
using Planet.WebApi.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Planet.Common;

namespace Planet.WebApi.Controllers
{
    //[Authorize]
    [RoutePrefix("api/upload")]
    public class UploadController : BaseApiController
    {
        public UploadController(IErrorService errorService, IUnitOfWork unitOfWork) : base(errorService, unitOfWork)
        {
        }

        [HttpPost]
        [Route("images")]
        public IHttpActionResult PostImages(string type = "")
        {
            return CreateResponse(() =>
            {
                var dict = new Dictionary<string, object>();

                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count == 0)
                {
                    return BadRequest(ApiMessage.RequiredFileUpload);
                }

                var postedFile = httpRequest.Files[0];

                if (!UploadValidation.AllowFileExtensions.Contains(Path.GetExtension(postedFile.FileName).ToLower()))
                    return Content(HttpStatusCode.UnsupportedMediaType, ApiMessage.UploadExtensionFailed);

                if (postedFile.ContentLength > UploadValidation.MaxContentLength)
                    return BadRequest(ApiMessage.UploadContentSizeFailed);

                string directory = String.Empty; ;

                switch (type)
                {
                    case UploadType.Avatar:
                        directory = UploadPath.Avatar;
                        break;
                    case UploadType.Product:
                        directory = UploadPath.Product;
                        break;
                    case UploadType.Banner:
                        directory = UploadPath.Banner;
                        break;
                    case UploadType.News:
                        directory = UploadPath.News;
                        break;
                    default:
                        directory = UploadPath.Root;
                        break;
                }

                string imageName = new string(postedFile.FileName.ToArray()).Replace(" ", "_");

                string rootPath = HttpContext.Current.Server.MapPath(directory);
                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }

                postedFile.SaveAs(Path.Combine(rootPath, imageName));

                dict.Add("location", UploadPath.PrefixWebApi + Path.Combine(directory, imageName));
                dict.Add("message", ApiMessage.UploadedSuccess);

                return Ok(dict);

            });


        }

    }
}
