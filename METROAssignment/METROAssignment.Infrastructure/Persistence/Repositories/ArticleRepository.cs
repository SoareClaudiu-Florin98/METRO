using METROAssignment.Domain.Models;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;

namespace METROAssignment.Infrastructure.Persistence.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(MetroDbContext dbContext) : base(dbContext)
        {
        }
    }
}
