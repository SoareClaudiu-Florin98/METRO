using METROAssignment.Domain.Models;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace METROAssignment.Infrastructure.Persistence.Repositories
{
    internal class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {

        public TransactionRepository(MetroDbContext dbContext) : base(dbContext)
        {
        }

        public async Task InsertTransactionWithArticlesAsync(Transaction transaction, IEnumerable<int> articleIds)
        {
            await _dbContext.Set<Transaction>().AddAsync(transaction);
            await _dbContext.SaveChangesAsync();

            var articles = _dbContext.Set<Article>().Include(x => x.TransactionArticles).Where(article => articleIds.Contains(article.Id));

            foreach (var article in articles)
            {
                if (article.Inventory > 0)
                {
                    article.Inventory -= 1;
                }

                if(article.TransactionArticles is null)
                {
                    article.TransactionArticles = new List<TransactionArticles>();
                }

                article.TransactionArticles.Add(new TransactionArticles
                {
                    TransactionId = transaction.Id,
                    ArticleId = article.Id
                });
            }

            _dbContext.Set<Article>().UpdateRange(articles);
            await _dbContext.SaveChangesAsync();
        }
    }
}
