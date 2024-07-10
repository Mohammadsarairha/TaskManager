namespace Domain.Interfaces
{
    public interface IEntityBase<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int? id);
        Task<T?> CreateAsync(T entity);
        Task<T?> UpdateAsync(int? id, T entity);
        Task<T?> DeleteAsync(int? id);
    }
}
