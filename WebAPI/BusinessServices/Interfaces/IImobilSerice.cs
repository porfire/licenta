using System.Collections.Generic;
using BusinessEntities.Entities;

namespace BusinessServices.Interfaces
{
    public interface IImobilSerice
    {
        ImobilEntity GetImobilById(int imobilId);
        IEnumerable<ImobilEntity> GetAllImobiles();
        int CreateImobil(ImobilEntity imobilEntity);
        bool UpdateImobil(int imobilId, ImobilEntity imobilEntity);
        bool DeleteImobil(int imobilId);
    }
}
