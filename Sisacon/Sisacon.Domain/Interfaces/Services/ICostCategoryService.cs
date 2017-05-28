using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface ICostCategoryService : IServiceBase<CostCategory>
    {
        List<CostCategory> getByUserId(int userId);
    }
}
