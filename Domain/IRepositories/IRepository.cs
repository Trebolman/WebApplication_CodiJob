using System;
using System.Linq;
namespace Domain.IRepositories
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Items { get; }
        void Save(TEntity item);
        void Delete(Guid itemId);
    }
}