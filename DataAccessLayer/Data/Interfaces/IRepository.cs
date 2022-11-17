namespace DataAccessLayer.Data
{
    /// <summary>
    /// Interface for basic CRUD operations for all tables.
    /// </summary>
    public interface IRepository<T>
    {
        Task Delete(int id);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Insert(T model);
        Task Update(T model);
    }
}