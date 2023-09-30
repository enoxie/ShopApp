using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {

        List<Product> GetPopularProducts();
    }
}