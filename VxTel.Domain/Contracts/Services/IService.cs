using System;
using System.Linq;
using System.Threading.Tasks;

namespace VxTel.Domain.Contracts.Services
{
    public interface IService<T>
        where T : class
    {
        IQueryable<T> GetAll();

        Task<T> GetById(Guid id);

        Task<T> Create(T entity);

        Task<T> Update(Guid id, T entity);

        Task Delete(Guid id);
    }
}