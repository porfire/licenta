using System.Collections.Generic;
using BusinessEntities.Entities;

namespace BusinessServices.Interfaces
{
   public interface IFotoImobilService
    {
        FotoImobilEntity GetFotoImobilById(int fotoImobilId);
        IEnumerable<FotoImobilEntity> GetAllFotos();
        int CreateFotoImobil(FotoImobilEntity fotoImobilEntity);
        bool UpdateFotoImobil(int fotoImobilId, FotoImobilEntity fotoImobilEntity);
        bool DeleteFotoImobil(int fotoImobilId);
    }
}
