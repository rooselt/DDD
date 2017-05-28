using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Application.Interfaces
{
    public interface IClientAppService : IAppServiceBase<Client>
    {
        ResponseMessage<Client> saveOrUpdate(Client client);
        ResponseMessage<Client> deleteClient(int clientId);
        ResponseMessage<List<Client>> getClientByUserId(int userId);
        ResponseMessage<Client> GetCount(int userId);
    }
}
