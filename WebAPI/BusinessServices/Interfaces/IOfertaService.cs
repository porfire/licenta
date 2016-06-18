using System.Collections.Generic;
using BusinessEntities.Entities;

namespace BusinessServices.Interfaces
{
    public interface IOfertaService
    {
        OfertaEntity GetOfertaById(int ofertaId);
        IEnumerable<OfertaEntity> GetAllOfertas();
        int CreateOferta(OfertaEntity ofertaEntity);
        bool UpdateOferta(int ofertaId, OfertaEntity ofertaEntity);
        bool DeleteOferta(int ofertaId);
    }
}
