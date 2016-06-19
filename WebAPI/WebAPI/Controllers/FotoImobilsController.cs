using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using BusinessServices.Services;
using System.Drawing.Imaging;
using System.Reflection;
using System.IO;
using System.Web;
using System.Drawing;
using System.Net.Http.Headers;
using System;
using System.Web.Hosting;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    public class FotoImobilsController : ApiController
    {
        private readonly IFotoImobilService _fotoImobilService;

        public FotoImobilsController()
        {
            _fotoImobilService = new FotoImobilServce();
        }
        private static ImageFormat GetImageFormat(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(extension))
                throw new ArgumentException(
                    string.Format("Unable to determine file extension for fileName: {0}", fileName));

            switch (extension.ToLower())
            {
                case @".bmp":
                    return ImageFormat.Bmp;

                case @".gif":
                    return ImageFormat.Gif;

                case @".ico":
                    return ImageFormat.Icon;

                case @".jpg":
                case @".jpeg":
                    return ImageFormat.Jpeg;

                case @".png":
                    return ImageFormat.Png;

                case @".tif":
                case @".tiff":
                    return ImageFormat.Tiff;

                case @".wmf":
                    return ImageFormat.Wmf;

                default:
                    throw new NotImplementedException();
            }
        }

        //public static ImageFormat GetImageFormat(string extension)
        //{
        //    ImageFormat result = null;
        //    PropertyInfo prop = typeof(ImageFormat).GetProperties().Where(p => p.Name.Equals(extension, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        //    if (prop != null)
        //    {
        //        result = prop.GetValue(prop) as ImageFormat;
        //    }
        //    return result;
        //}
        private MemoryStream CopyFileToMemory(string path)
        {
            MemoryStream ms = new MemoryStream();
            FileStream fs = new FileStream(path, FileMode.Open);
            fs.Position = 0;
            fs.CopyTo(ms);
            fs.Close();
            fs.Dispose();
            return ms;
        }

        public HttpResponseMessage Geti(string id)
        {
            MemoryStream ms = new MemoryStream();
            HttpContext context = HttpContext.Current;
            //Limit access only to images folder at root level  
            string filePath = context.Server.MapPath(string.Concat("images/", id));
            string extension = Path.GetExtension(id);
            if (File.Exists(filePath))
            {
                if (!string.IsNullOrWhiteSpace(extension))
                {
                    extension = extension.Substring(extension.IndexOf(".") + 1);
                }

                //If requested file is an image than load file to memory  
                if (GetImageFormat(extension) != null)
                {
                    ms = CopyFileToMemory(filePath);
                }
            }
            //        ImageFormat format = GetImageFormat(extension);
            //        //If invalid image file is requested the following line wil throw an exception  
            //        new Bitmap(filePath).Save(ms, format != null ? format as ImageFormat : ImageFormat.Bmp);
            //}
            if (ms == null)
            {
                extension = "png";
                ms = CopyFileToMemory(context.Server.MapPath("/content/images/fallback.png"));
            }

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(ms.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(string.Format("images/{0}", extension));
            return result;
        }

        // GET: api/fotoImobils
        public HttpResponseMessage GetfotoImobils()
        {
            var fotoImobil = _fotoImobilService.GetAllFotos();
            if (fotoImobil != null)
            {
                var fotoImobilEntities = fotoImobil as List<FotoImobilEntity> ?? fotoImobil.ToList();
                if (fotoImobilEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, fotoImobilEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "fotoImobil not found");
        }

        //// GET: api/fotoImobils/5
        public HttpResponseMessage GetfotoImobil(int id)
        {
            var fotoImobil = _fotoImobilService.GetFotoImobilById(id);
            //var img_path = HttpContext.Current.Server.MapPath(string.Concat("images/{0}", id));
            //var imageByteArray = GetFile(img_path);
            if (fotoImobil != null)
                return Request.CreateResponse(HttpStatusCode.OK, fotoImobil);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }
        // [ResponseType(typeof(OfertaEntity))]
        //public IHttpActionResult Post([FromBody] AgentiEntity agentiEntity)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    _agentService.CreateAgent(agentiEntity);
        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, agentiEntity);

        //    response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = agentiEntity.agentID}));
        //    return StatusCode(HttpStatusCode.Conflict);

        //}
        // POST api/fotoImobils
        [ResponseType(typeof(OfertaEntity))]
        public IHttpActionResult Post([FromBody] FotoImobilEntity fotoImobilEntity)
        {
            HttpContext context = HttpContext.Current;
            //string filePath = context.Server.MapPath(string.Concat("images/", fotoImobilEntity.fotoID));
            //string extension = Path.GetExtension("images/id");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var img_path = HttpContext.Current.Server.MapPath(string.Concat("images/{0}", fotoImobilEntity.NumeFoto));
            var imageByteArray = GetFile(img_path);

            fotoImobilEntity.img_path = "/images/" + fotoImobilEntity.NumeFoto + "getformat foto";
            //Copy to memory
            _fotoImobilService.CreateFotoImobil(fotoImobilEntity);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, fotoImobilEntity);

            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = fotoImobilEntity.fotoID }));
            return StatusCode(HttpStatusCode.Conflict);
        }



        // PUT api/fotoImobils/5
        public bool Put(int id, [FromBody] FotoImobilEntity fotoImobilEntity)
        {
            if (id > 0)
            {
                return _fotoImobilService.UpdateFotoImobil(id, fotoImobilEntity);
            }
            return false;
        }

        // DELETE api/People/5
        //public bool Delete(int id)
        //{
        //    if (id > 0)
        //        return _fotoImobilService.DeleteFotoImobil(id);
        //    return false;
        //}


        // GET api/People/5
        public HttpResponseMessage Get(int id)
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            String filePath = HostingEnvironment.MapPath("~/Images/HT.jpg");
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            Image image = Image.FromStream(fileStream);
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            result.Content = new ByteArrayContent(memoryStream.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

            return result;
        }

        // DELETE api/People/5
        public void Delete(int id)
        {
            String filePath = HostingEnvironment.MapPath("~/images/HT.jpg");
            File.Delete(filePath);
        }

        public void Post()
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            if (Request.Content.IsMimeMultipartContent())
            {
                StreamContent content = (StreamContent)Request.Content;
                Task<Stream> task = content.ReadAsStreamAsync();
                Stream readOnlyStream = task.Result;
                Byte[] buffer = new Byte[readOnlyStream.Length];
                readOnlyStream.Read(buffer, 0, buffer.Length);
                MemoryStream memoryStream = new MemoryStream(buffer);
                Image image = Image.FromStream(memoryStream);
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }
        }

        public Task<HttpResponseMessage> Post(int id)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/images");
            var provider = new MultipartFormDataStreamProvider(root);

            var task = Request.Content.ReadAsMultipartAsync(provider).
                ContinueWith<HttpResponseMessage>(t =>
                {
                    if (t.IsFaulted || t.IsCanceled)
                    {
                        Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                    }

                    foreach (MultipartFileData file in provider.FileData)
                    {
                //Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                //Trace.WriteLine("Server file path: " + file.LocalFileName);
            }
                    return Request.CreateResponse(HttpStatusCode.OK);
                });

            return task;
        }

        [HttpPost]
        public HttpResponseMessage Index(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    return Request.CreateResponse(HttpStatusCode.Accepted, "File uploaded successfully");

                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "File  NOT uploaded successfully");
                }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.Accepted, "You have not specified a file.");
            }
           // return View();
        }

        public byte[] GetFile(string storagePath)  //asta o sa iti returneze un byte array dintr-run path care il dai 
        {
            FileStream fileStream = null;

            try
            {
                int BufferSize = 1;
                fileStream = new FileStream(storagePath, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, true);
                var file = new byte[fileStream.Length];
                fileStream.Read(file, 0, (int)fileStream.Length);
                return file;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }

        //FotoImobilEntity imagePath =HttpContext.Current.Server.MapPath(string.Format("Images/{0}",photo.imageName));  // photo o sa iti fie direct obiect din db
        //ImagesOfertaEntity imageByteArray =GetFile(imagePath); // asta iti va returna un byte array cu poza care il transmiti ca si response

        public HttpResponseMessage Post2()
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            if (Request.Content.IsMimeMultipartContent())
            {
                Request.Content.ReadAsMultipartAsync<MultipartMemoryStreamProvider>(new MultipartMemoryStreamProvider()).ContinueWith((task) =>
                {
                    MultipartMemoryStreamProvider provider = task.Result;
                    foreach (HttpContent content in provider.Contents)
                    {
                        Stream stream = content.ReadAsStreamAsync().Result;
                        Image image = Image.FromStream(stream);
                        var testName = content.Headers.ContentDisposition.Name;
                        String filePath = HostingEnvironment.MapPath("~/images/");
                        String[] headerValues = (String[])Request.Headers.GetValues("UniqueId");
                        String fileName = headerValues[0] + ".jpg";
                        String fullPath = Path.Combine(filePath, fileName);
                        image.Save(fullPath);
                    }
                });
                return result;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }


        }

    }
}
