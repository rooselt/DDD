using Sisacon.Domain.ValueObjects;

namespace Sisacon.Application.Interfaces
{
    public interface IFixedCostAppService : IAppServiceBase<FixedCost>
    {
        ResponseMessage<FixedCost> saveOrUpdate(FixedCost fixedCost);
        ResponseMessage<FixedCost> deleteFixedCost(int fixedCostId);

    }
}
