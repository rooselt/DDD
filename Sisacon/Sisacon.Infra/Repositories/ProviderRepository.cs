using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra.Repositories
{
    public class ProviderRepository : RepositoryBase<Provider>, IProviderRepository
    {
        public override void add(Provider provider)
        {
            try
            {
                Context.Provider.Add(provider);
                Context.Address.Add(provider.Address);
                Context.Contact.Add(provider.Contact);
                Context.BankDetails.Add(provider.BankDetails);

                Context.User.Attach(provider.User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void update(Provider provider)
        {
            try
            {
                Context.Entry(provider).State = EntityState.Modified;
                Context.Entry(provider.Address).State = EntityState.Modified;
                Context.Entry(provider.Contact).State = EntityState.Modified;
                Context.Entry(provider.BankDetails).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Provider getById(int id, bool includeUser)
        {
            try
            {
                return Context.
                    Provider.
                    Include("Address").
                    Include("Contact").
                    Include("BankDetails").
                    Include("User").
                    Where(x => x.Id == id && x.ExclusionDate == null).
                    FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Provider> getByUserId(int userId)
        {
            try
            {
                return Context.
                    Provider.
                    Include("Address").
                    Include("Contact").
                    Include("BankDetails").
                    Include("User").
                    Where(x => x.IdUser == userId && x.ExclusionDate == null).
                    ToList();
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
                    Provider.
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
