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
    public class CompanyService : ServiceBase<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository) : base(companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Company getCompanyByUserId(int userId)
        {
            var company = new Company();

            try
            {
                company = _companyRepository.getByUserId(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return company;
        }
    }
}
