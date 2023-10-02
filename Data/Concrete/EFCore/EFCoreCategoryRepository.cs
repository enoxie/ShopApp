using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;
using Entity;

namespace Data.Concrete.EFCore
{
    public class EFCoreCategoryRepository : EFCoreGenericRepository<Category, ShopContext>, ICategoryRepository
    {

    }
}