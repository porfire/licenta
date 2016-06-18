using System.Collections.Generic;
using BusinessEntities.Entities;

namespace BusinessServices.Interfaces
{
   public interface IDetaliiImobilService
    {
        DetaliiImobilEntity GetdetailsById(int detaliiImobilId);
        IEnumerable<DetaliiImobilEntity> GetAllDetails();
        int CreateDetaliiImobil(DetaliiImobilEntity detaliiImobilEntity);
        bool UpdateDetaliiImobil(int detaliiImobilId, DetaliiImobilEntity detaliiImobilEntity);
        bool DeleteDetaliiImobil(int detaliiImobilId);
    }
}
