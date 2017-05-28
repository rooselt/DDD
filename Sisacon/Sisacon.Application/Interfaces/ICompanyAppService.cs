using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Application.Interfaces
{
    public interface ICompanyAppService : IAppServiceBase<Company>
    {
        ResponseMessage<Company> saveOrUpdate(Company company);
        ResponseMessage<Company> getCompanyByUserId(int userId);
        ResponseMessage<OccupationArea> getOccupationAreas();
    }
}
