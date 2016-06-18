using System.Collections.Generic;
using BusinessEntities.Entities;

namespace BusinessServices.Interfaces
{
   public interface IVideoImobilService
    {
        VideoImobilEntity GetVideoImobilById(int videoImobilId);
        IEnumerable<VideoImobilEntity> GetAllVideos();
        int CreateVideoImobil(VideoImobilEntity videoImobilEntity);
        bool UpdateVideoImobil(int videoImobilId, VideoImobilEntity videoImobilEntity);
        bool DeleteVideoImobil(int videoImobilId);
    }
}
