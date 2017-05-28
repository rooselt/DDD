using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Application.Interfaces
{
    public interface IMaterialCategoryAppService : IAppServiceBase<MaterialCategory>
    {
        ResponseMessage<MaterialCategory> saveOrUpdate(MaterialCategory MaterialCategory);
        ResponseMessage<MaterialCategory> deleteMaterialCategory(int MaterialCategoryId);
        ResponseMessage<MaterialCategory> getMaterialCategoryByUserId(int userId);
    }
}
