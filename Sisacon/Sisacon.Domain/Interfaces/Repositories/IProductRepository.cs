using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        List<Product> GetByUserId(int userId);
        int GetCount(int userId);
    }
}
