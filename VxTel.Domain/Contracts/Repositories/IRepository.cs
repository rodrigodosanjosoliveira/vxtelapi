using System;
using System.Linq;
using System.Threading.Tasks;
using VxTel.Domain.Entities;

namespace VxTel.Domain.Contracts.Repositories
{
    public interface IRepository<T>
        where T : Entity
    {
        IQueryable<T> GetAll();

        Task<T> GetById(Guid id);

        Task<T> Create(T entity);

        Task<T> Update(Guid id, T entity);

        Task Delete(Guid id);
    }
}
