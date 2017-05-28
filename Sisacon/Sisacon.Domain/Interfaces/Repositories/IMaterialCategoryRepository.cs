using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Interfaces.Repositories
{
    public interface IMaterialCategoryRepository : IRepositoryBase<MaterialCategory>
    {
        List<MaterialCategory> getByUserId(int userId);
    } 
}
