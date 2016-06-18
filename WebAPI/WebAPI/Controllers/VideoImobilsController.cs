using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using BusinessServices.Services;

namespace WebAPI.Controllers
{
    public class VideoImobilsController : ApiController
    {
        private readonly IVideoImobilService _videoImobilService;

        public VideoImobilsController()
        {
            _videoImobilService=new VideoImobilSerice();
        }
        // GET: api/videoImobils
        public HttpResponseMessage GetvideoImobils()
        {
            var videoImobile = _videoImobilService.GetAllVideos();
            if (videoImobile != null)
            {
                var videoImobilEntities = videoImobile as List<VideoImobilEntity> ?? videoImobile.ToList();
                if (videoImobilEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, videoImobilEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "videoImobil not found");
        }

        //// GET: api/videoImobils/5
        public HttpResponseMessage GetGetvideoImobil(int id)
        {
            var videoImobil = _videoImobilService.GetVideoImobilById(id);
            if (videoImobil != null)
                return Request.CreateResponse(HttpStatusCode.OK, videoImobil);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }

        // POST api/videoImobil
        public int Post( VideoImobilEntity videoImobilEntity)
        {
            return _videoImobilService.CreateVideoImobil(videoImobilEntity);
        }

        // PUT api/videoImobil/5
        public bool Put(int id, VideoImobilEntity videoImobilEntity)
        {
            if (id > 0)
            {
                return _videoImobilService.UpdateVideoImobil(id, videoImobilEntity);
            }
            return false;
        }

        // DELETE api/VideoImobil/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _videoImobilService.DeleteVideoImobil(id);
            return false;
        }
    }
}