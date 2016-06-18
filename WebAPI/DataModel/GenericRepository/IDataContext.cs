using System;
using System.Data.Entity;

namespace DataModel.GenericRepository
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();

        IDbSet<T> GetDbSet<T>() where T : class;
    }
}
