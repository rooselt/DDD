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
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public override void add(Company company)
        {
            try
            {
                Context.Company.Add(company);
                Context.Address.Add(company.Address);
                Context.Contact.Add(company.Contact);

                Context.OccupationArea.Attach(company.OccupationArea);
                Context.User.Attach(company.User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void update(Company company)
        {
            try
            {
                Context.Entry(company).State = EntityState.Modified;
                Context.Entry(company.Address).State = EntityState.Modified;
                Context.Entry(company.Contact).State = EntityState.Modified;
                Context.Entry(company.OccupationArea).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Company getByUserId(int userId)
        {
            try
            {
                return Context.Company.
                    Where(x => x.User.Id == userId &&
                    x.ExclusionDate == null)
                    .Include("OccupationArea")
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
    }
}
