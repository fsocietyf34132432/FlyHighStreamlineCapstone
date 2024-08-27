using FlyHighStreamlineCapstone.Data;
using FlyHighStreamlineCapstone.Interface;
using Microsoft.EntityFrameworkCore;

namespace FlyHighStreamlineCapstone.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly FlyHighStreamlineCapstoneContext _context;

        public async Task<IEnumerable<T>> GetAllAsync() 
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id) ?? default!;
        }

        public async Task AddAsync(T entity) 
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async void DeleteAsync(int id) 
        {
            T entity = await _context.Set<T>().FindAsync(id) ?? default!;
            if (entity != null) 
            {
                _context.Set<T>().Remove(entity);
            }
        }

        public void UpdateAsync(T entity, T viewModelEntity) 
        {
            _context.Entry(entity).CurrentValues.SetValues(viewModelEntity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

    }
}
