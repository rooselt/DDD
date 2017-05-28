using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public override void add(Product product)
        {
            try
            {
                Context.User.Attach(product.User);

                Context.Product.Add(product);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override void update(Product product)
        {
            try
            {
                Context.Entry(product).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Product getById(int productId)
        {
            try
            {
                return Context.
                Product.
                Include("User").
                Include("ListMaterial").
                Include("ListProductImages").
                Where(x => x.Id == productId && x.ExclusionDate == null).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Product> GetByUserId(int userId)
        {
            try
            {
                return Context.
                    Product.
                    Include("User").
                    Include("ListMaterial").
                    Include("ListProductImages").
                    Where(x => x.User.Id == userId && x.ExclusionDate == null).ToList();
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
                    Product.
                    Where(x => x.ExclusionDate == null).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
