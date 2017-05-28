﻿using System;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces
{
    public interface IRepositoryBase<T> : IDisposable where T : class
    {
        void attach(T obj);
        void add(T obj);
        void update(T obj);
        void delete(int id);
        void delete(T obj);
        T getById(int id);
        T getById(int id, bool includeUser);
        List<T> getAll();
        List<T> getAll(bool includeUser);
        int commit();
        void commitAsync();
        void rollback();
    }
}
