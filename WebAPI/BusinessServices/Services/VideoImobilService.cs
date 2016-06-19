using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Entities;
using BusinessServices.Interfaces;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices.Services
{
    public class VideoImobilSerice : IVideoImobilService
    {
        public readonly UnitOfWork _UnitOfWork;

        public VideoImobilSerice()
        {
            _UnitOfWork = new UnitOfWork();
        }

        public VideoImobilEntity GetVideoImobilById(int videoImobilId)
        {
            var videoImobil = _UnitOfWork.VideoImobilRepository.GetByID(videoImobilId);
            if (videoImobil != null)
            {
                Mapper.CreateMap<VideoImobil, VideoImobilEntity>();
                var videoImobilModel = Mapper.Map<VideoImobil, VideoImobilEntity>(videoImobil);
                return videoImobilModel;
            }
            return null;
        }

        public IEnumerable<VideoImobilEntity> GetAllVideos()
        {
            var videoImobil = _UnitOfWork.VideoImobilRepository.GetAll().ToList();
            if (videoImobil.Any())
            {
                Mapper.CreateMap<VideoImobil, VideoImobilEntity>();
                var videoImobilModel = Mapper.Map<List<VideoImobil>, List<VideoImobilEntity>>(videoImobil);
                return videoImobilModel;
            }
            return null;
        }

        public int CreateVideoImobil(VideoImobilEntity videoImobilEntity)
        {
            var videoImobil = new VideoImobil();
            {

                videoImobil.video_path = videoImobilEntity.video_path;
                videoImobil.videoDescription = videoImobilEntity.videoDescription;
            }
            _UnitOfWork.VideoImobilRepository.Insert(videoImobil);
            _UnitOfWork.Save();
            return videoImobil.videoID;
        }

        public bool UpdateVideoImobil(int videoImobilId, VideoImobilEntity videoImobilEntity)
        {
            var success = false;
            if (videoImobilEntity != null)
            {
                var videoImobil = _UnitOfWork.VideoImobilRepository.GetByID(videoImobilId);

                if (videoImobil != null)
                {
                    videoImobil.video_path = videoImobilEntity.video_path;
                    videoImobil.videoDescription = videoImobilEntity.videoDescription;
                    _UnitOfWork.VideoImobilRepository.Update(videoImobil);
                    _UnitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }

        public bool DeleteVideoImobil(int videoImobilId)
        {

            var success = false;
            if (videoImobilId > 0)
            {
                var videoImobil = _UnitOfWork.VideoImobilRepository.GetByID(videoImobilId);
                if (videoImobil != null)
                {
                    _UnitOfWork.VideoImobilRepository.Delete(videoImobil);
                    _UnitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }
    }
}
