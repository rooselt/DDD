using Sisacon.Domain.Interfaces.Repositories;
using Sisacon.Domain.Interfaces.Services;
using Sisacon.Domain.ValueObjects;

namespace Sisacon.Domain.Services
{
    public class PriceResearchService : ServiceBase<PriceResearch>, IPriceResearchService
    {
        private readonly IPriceResearchRepository _priceRepository;

        public PriceResearchService(IPriceResearchRepository priceRepository) : base(priceRepository)
        {
            _priceRepository = priceRepository;
        }
    }
}
