using Sisacon.Domain.Interfaces.Services;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sisacon.Domain.Interfaces;
using Sisacon.Domain.Interfaces.Repositories;

namespace Sisacon.Domain.Services
{
    public class MaterialCategoryService : ServiceBase<MaterialCategory>, IMaterialCategoryService
    {
        private readonly IMaterialCategoryRepository _repository;

        public MaterialCategoryService(IMaterialCategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public List<MaterialCategory> getByUserId(int userId)
        {
            try
            {
                return _repository.getByUserId(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
