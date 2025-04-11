namespace EFCore.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task Add(T entity);
    Task<T> GetById(Guid id);
    Task<IEnumerable<T>> GetAll();
    Task Update(T entity);
    Task  Delete(T entity);
    IQueryable<T> GetAllWithQueryAble();
    Task<int> SaveChangeAsync();
}
