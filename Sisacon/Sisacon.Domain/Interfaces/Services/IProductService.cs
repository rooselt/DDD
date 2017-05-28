using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
        List<Product> GetByUserId(int userId);
        int GetCount(int userId);
    }
}
