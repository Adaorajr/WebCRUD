using System;
using System.Collections.Generic;

namespace WebCRUDApp
{
    public interface IRepositoryBase<TEntity>: IDisposable where TEntity : class
    {
        TEntity GetById(int? id);
        IEnumerable<TEntity> GetAll();
        

    }

}