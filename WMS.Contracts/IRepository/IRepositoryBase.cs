using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WMS.Contracts
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetListByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id);
        Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T createEntity);
        Task<T> UpdateAsync(T editEntity);
        Task<T> DeleteAsync(T deleteEntity);
    }
}