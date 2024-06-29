using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace Data.Abstract
{
    public interface ICartRepository : IRepository<Cart>
    {
        void DeleteFromCart(int cartId, int productId);
        Cart GetByUserId(string userId);
    }
}