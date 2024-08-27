namespace FlyHighStreamlineCapstone.Interface
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        
        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        void DeleteAsync(int id);

        void UpdateAsync(T entity, T viewModelEntity);

        Task SaveAsync();

        Task<int> CountAsync();
    }
}
