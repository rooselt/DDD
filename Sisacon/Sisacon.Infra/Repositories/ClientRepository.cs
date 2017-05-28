using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public override void add(Client client)
        {
            try
            {
                Context.Client.Add(client);
                Context.Address.Add(client.Address);
                Context.Contact.Add(client.Contact);

                Context.User.Attach(client.User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void update(Client client)
        {
            try
            {
                Context.Entry(client).State = EntityState.Modified;
                Context.Entry(client.Address).State = EntityState.Modified;
                Context.Entry(client.Contact).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Client getById(int id, bool includeUser)
        {
            try
            {
                return Context.Client.
                    Where(x => x.Id == id &&
                    x.ExclusionDate == null)
                    .Include("Address")
                    .Include("Contact")
                    .Include("User")
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Client> getByUserId(int userId)
        {
            try
            {
                return Context.Client.
                    Where(x => x.User.Id == userId &&
                    x.ExclusionDate == null)
                    .Include("Address")
                    .Include("Contact")
                    .Include("User")
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetCount(int userId)
        {
            try
            {
                return Context.
                    Client.
                    Where(x => x.User.Id == userId && x.ExclusionDate == null).
                    Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
