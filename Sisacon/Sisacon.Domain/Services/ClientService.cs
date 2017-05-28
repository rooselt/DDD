using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sisacon.Domain.Interfaces;
using Sisacon.Domain.Interfaces.Repositories;

namespace Sisacon.Domain.Services
{
    public class ClientService : ServiceBase<Client>, IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public List<Client> getByUserId(int userId)
        {
            var clientList = new List<Client>();

            try
            {
                clientList = _repository.getByUserId(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return clientList;
        }

        public int GetCount(int userId)
        {
            try
            {
                return _repository.GetCount(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
