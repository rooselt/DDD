using Sisacon.Domain.ValueObjects;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface IMaterialCategoryService : IServiceBase<MaterialCategory>
    {
        List<MaterialCategory> getByUserId(int userId);
    }
}
