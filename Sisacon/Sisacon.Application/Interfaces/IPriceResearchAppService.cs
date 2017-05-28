using Sisacon.Domain.ValueObjects;

namespace Sisacon.Application.Interfaces
{
    public interface IPriceResearchAppService : IAppServiceBase<PriceResearch>
    {
        ResponseMessage<PriceResearch> saveOrUpdate(PriceResearch PriceResearch);
        ResponseMessage<PriceResearch> deletePriceResearch(int PriceResearchId);
    }
}
