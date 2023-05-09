namespace METROAssignment.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<TEntity?> FindByIdAsync(int id);
        IQueryable<TEntity> GetAll();
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
