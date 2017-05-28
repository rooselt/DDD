using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using System;

namespace Sisacon.Application
{
    public class AppServiceBase<T> : IAppServiceBase<T> where T : BaseEntity
    {
        private readonly IServiceBase<T> _serviceBase;

        public AppServiceBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void add(T obj)
        {
            try
            {
                _serviceBase.add(obj);
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
                _serviceBase.attach(obj);
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
                return _serviceBase.commit();
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
                _serviceBase.commitAsync();
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
                _serviceBase.delete(id);
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
                _serviceBase.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ResponseMessage<T> getAll()
        {
            var response = new ResponseMessage<T>();

            try
            {
                response.ValueList = _serviceBase.getAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public ResponseMessage<T> getById(int id)
        {
            var response = new ResponseMessage<T>();

            try
            {
                response.Value = _serviceBase.getById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public ResponseMessage<T> getById(int id, bool includeUser)
        {
            var response = new ResponseMessage<T>();

            try
            {
                response.Value = _serviceBase.getById(id, includeUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public void rollback()
        {
            try
            {
                _serviceBase.rollback();
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
                _serviceBase.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
