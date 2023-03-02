using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upstorm.Data.IRepositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> CreateAsync(TEntity model);
        Task<TEntity> UpdateAsync(TEntity model);
        Task<bool> DeleteAsync(long id);
        Task<TEntity> GetByIdAsync(long id);
        Task<List<TEntity>> GetAllAsync(Predicate<TEntity> predicate = null);
    }
}
