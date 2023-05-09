using METROAssignment.Domain.Models;

namespace METROAssignment.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task InsertTransactionWithArticlesAsync(Transaction transaction, IEnumerable<int> articleIds);
    }
}
