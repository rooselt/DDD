using Sisacon.Domain.Entities;

namespace Sisacon.Application.Interfaces
{
    public interface ICostAppService : IAppServiceBase<Cost>
    {
        ResponseMessage<Cost> SaveOrUpdate(Cost cost);
        ResponseMessage<Cost> DeleteCost(int costId);
        ResponseMessage<Cost> GetCostsByUserId(int userId);
        ResponseMessage<Cost> ValidateNewCost(int userId);
        ResponseMessage<Cost> GetCurrentCost(int userId);
        //ResponseMessage<Cost> getCostByCategory(int userId);
    }
}
