using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface IClientService : IServiceBase<Client>
    {
        List<Client> getByUserId(int userId);
        int GetCount(int userId);
    }
}
