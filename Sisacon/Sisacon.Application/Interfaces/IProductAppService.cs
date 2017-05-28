using Sisacon.Domain.Entities;

namespace Sisacon.Application.Interfaces
{
    public interface IProductAppService : IAppServiceBase<Product>
    {
        ResponseMessage<Product> SaveOrUpdate(Product product);
        ResponseMessage<Product> DeleteProduct(int productId);
        ResponseMessage<Product> GetProductByUserId(int userId);
    }
}
