using Sisacon.Domain.Interfaces.Services;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sisacon.Domain.Interfaces;
using Sisacon.Domain.Interfaces.Repositories;

namespace Sisacon.Domain.Services
{
    public class FixedCostService : ServiceBase<FixedCost>, IFixedCostService
    {
        private readonly IFixedCostRepository _fixedCostRespository;

        public FixedCostService(IFixedCostRepository fixedCostRepository) : base(fixedCostRepository)
        {
            _fixedCostRespository = fixedCostRepository;
        }
    }
}
