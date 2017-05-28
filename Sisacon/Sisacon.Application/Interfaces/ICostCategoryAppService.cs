using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Application.Interfaces
{
    public interface ICostCategoryAppService : IAppServiceBase<CostCategory>
    {
        ResponseMessage<CostCategory> saveOrUpdate(CostCategory costCategory);
        ResponseMessage<CostCategory> deleteCostCategory(int costCategoryId);
        ResponseMessage<CostCategory> getCostCategoryByUserId(int userId);
    }
}
