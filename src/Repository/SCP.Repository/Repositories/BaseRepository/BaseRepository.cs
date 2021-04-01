using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SCP.Domain.Base;
using SCP.Repository.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SCP.Repository.Repositories.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly BaseContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public BaseRepository(BaseContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async void Delete(int id)
        {
            await new TaskFactory().StartNew(() =>
            { 
                T entity = entities.SingleOrDefault(s => s.Id == id);
                entities.Remove(entity);
            });
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return await new TaskFactory().StartNew(() =>
            { 
                return entities.AsQueryable();
            });
        }

        public async Task<T> GetById(int id)
        {
            return await entities.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<EntityEntry> Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            return await entities.AddAsync(entity);
        }

        public async void Update(T entity)
        {
            await new TaskFactory().StartNew(() =>
            { 
                if (entity == null) throw new ArgumentNullException("entity");
                entities.Update(entity);
            });
        }
    }
}
