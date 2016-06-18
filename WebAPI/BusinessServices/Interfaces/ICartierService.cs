using System.Collections.Generic;
using BusinessEntities.Entities;

namespace BusinessServices.Interfaces
{
    public interface ICartierService
    {
        CartierEntity GetCartierById(int cartierId);
        IEnumerable<CartierEntity> GetAllCartiers();
        int CreateCartier(CartierEntity cartierEntity);
        bool UpdateCartier(int cartierId, CartierEntity cartierEntity);
        bool DeleteCartier(int cartierId);
    }
}
