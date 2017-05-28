using System;

namespace Sisacon.Application.Interfaces
{
    public interface IAppServiceBase<T> : IDisposable where T : class
    {
        void attach(T obj);
        void add(T obj);
        void update(T obj);
        void delete(int id);
        ResponseMessage<T> getById(int id);
        ResponseMessage<T> getById(int id, bool includeUser);
        ResponseMessage<T> getAll();
        int commit();
        void commitAsync();
        void rollback();
    }
}
