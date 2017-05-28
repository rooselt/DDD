using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Sisacon.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : BaseEntity
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public void attach(T obj)
        {
            try
            {
                _repository.attach(obj);
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
                return _repository.commit();
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
                _repository.commitAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void delete(int id)
        {
            try
            {
                _repository.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void delete(T obj)
        {
            try
            {
                _repository.delete(obj);
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
                _repository.Dispose();
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
                return _repository.getAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T getById(int id)
        {
            try
            {
                return _repository.getById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T getById(int id, bool includeUser)
        {
            try
            {
                return _repository.getById(id, includeUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void rollback()
        {
            try
            {
                _repository.rollback();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void add(T obj)
        {
            try
            {
                _repository.add(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(T obj)
        {
            try
            {
                _repository.update(obj);
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
                return _repository.getAll(includeUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
