using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class UploadingController : ApiController
    {
        public void Post()
        {
            //if (Request.Content.IsMimeMultipartContent())
            //{
            //    var streamProvider = new MultipartFormDataStreamProvider("c:/uploads/");
            //    var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith(t =>
            //    {
            //        if (t.IsFaulted || t.IsCanceled)
            //            throw new HttpResponseException(HttpStatusCode.InternalServerError);
            //    };

            //else
            //{
            //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            //}
            //}
        }
    }
}
