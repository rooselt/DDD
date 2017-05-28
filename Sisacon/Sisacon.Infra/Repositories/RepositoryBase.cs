using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces;
using Sisacon.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra.Repositories
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : BaseEntity
    {
        protected SisaconDbContext Context { get; private set; }

        public RepositoryBase()
        {
            Context = new SisaconDbContext();
        }

        private DbSet<T> Entity { get { return Context.Set<T>(); } }

        public virtual void add(T obj)
        {
            try
            {
                obj.RegistrationDate = DateTime.Now;
                Entity.Add(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void update(T obj)
        {
            try
            {
                Context.Entry(obj).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void delete(int id)
        {
            try
            {
                var obj = getById(id);
                obj.ExclusionDate = DateTime.Now;

                update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void delete(T obj)
        {
            try
            {
                obj.ExclusionDate = DateTime.Now;

                update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T getById(int id, bool includeUser)
        {
            try
            {
                return Entity.
                    Include("User").
                    Where(x => x.Id == id && x.ExclusionDate == null).
                    FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T getById(int id)
        {
            try
            {
                return Entity.Where(x => x.Id == id && x.ExclusionDate == null).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> getAll()
        {
            try
            {
                return Entity.Where(x => x.ExclusionDate == null).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> getAll(bool includeUser)
        {
            try
            {
                if (includeUser)
                {
                    return Entity
                        .Include("User")
                        .Where(x => x.ExclusionDate == null)
                        .ToList();
                }
                else
                {
                    return Entity.Where(x => x.ExclusionDate == null).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            try
            {
                if (Context != null)
                {
                    Context.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void attach(T obj)
        {
            try
            {
                Entity.Attach(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int commit()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void commitAsync()
        {
            try
            {
                Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void rollback()
        {
            Context.ChangeTracker.Entries()
                         .ToList()
                         .ForEach(entry => entry.State = EntityState.Unchanged);
        }


    }
}
