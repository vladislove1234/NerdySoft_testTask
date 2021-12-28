using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nerdysoft_testTask.Model.Abstraction;

namespace Nerdysoft_testTask.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Remove(T entity);
    }
}
