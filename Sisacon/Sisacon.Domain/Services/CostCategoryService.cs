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
    public class CostCategoryService : ServiceBase<CostCategory>, ICostCategoryService
    {
        private readonly ICostCategoryRepository _costCategoryRepository;

        public CostCategoryService(ICostCategoryRepository costCategoryRepository) : base(costCategoryRepository)
        {
            _costCategoryRepository = costCategoryRepository;
        }

        public List<CostCategory> getByUserId(int userId)
        {
            try
            {
                return _costCategoryRepository.getByUserId(userId);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
