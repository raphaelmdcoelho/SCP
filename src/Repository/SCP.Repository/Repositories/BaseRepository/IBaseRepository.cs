using Microsoft.EntityFrameworkCore.ChangeTracking;
using SCP.Domain.Base;
using System.Linq;
using System.Threading.Tasks;

namespace SCP.Repository.Repositories.BaseRepository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAll();
        Task<T> GetById(int id);
        Task<EntityEntry> Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
