using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WMS.Contracts;
using WMS.DataLayer;
using WMS.Models;

namespace WMS.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        private WMSContext RepositoryContext;
        private DbSet<T> Entities;

        public RepositoryBase(WMSContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
            Entities = repositoryContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entities.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetListByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await Entities.Where(expression).Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Entities.Where(x => x.Id == id).Where(x => x.IsDeleted == false).FirstOrDefaultAsync();
        }

        public async Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression)
        {
            var result = await Entities.Where(x => x.IsDeleted == false).Where(expression).FirstOrDefaultAsync();
            //await DisposeAsync();
            return result;
        }

        public async Task<T> CreateAsync(T createEntity)
        {
            createEntity.CreatedDate = DateTime.UtcNow;
            Entities.Add(createEntity);
            await SaveAsync();
            //await DisposeAsync();
            return createEntity;
        }

        public async Task<T> UpdateAsync(T editEntity)
        {
            editEntity.ModifiedDate = DateTime.UtcNow;
            Entities.Update(editEntity);
            await SaveAsync();
            //await DisposeAsync();
            return editEntity;
        }

        public async Task<T> DeleteAsync(T deleteEntity)
        {
            deleteEntity.ModifiedDate = DateTime.UtcNow;
            deleteEntity.IsDeleted = true;
            RepositoryContext.Entry(deleteEntity).Property("ModifiedDate").IsModified = true;
            RepositoryContext.Entry(deleteEntity).Property("IsDeleted").IsModified = true;
            await SaveAsync();
            //await DisposeAsync();
            return deleteEntity;
        }

        private async Task<int> SaveAsync()
        {
            var result = await RepositoryContext.SaveChangesAsync();
            //await DisposeAsync();
            return result;
        }

        private async Task DisposeAsync()
        {
            await Task.Run(() => RepositoryContext.DisposeAsync());
        }
    }
}