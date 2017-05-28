using Sisacon.Domain.Interfaces.Repositories;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Repositories
{
    public class MaterialCategoryRepository : RepositoryBase<MaterialCategory>, IMaterialCategoryRepository
    {
        public override void add(MaterialCategory materialCategory)
        {
            try
            {
                Context.MaterialCategory.Add(materialCategory);

                Context.User.Attach(materialCategory.User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MaterialCategory> getByUserId(int userId)
        {
            try
            {
                return Context.
                    MaterialCategory.
                    Where(x => x.User.Id == userId && x.ExclusionDate == null).
                    ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
