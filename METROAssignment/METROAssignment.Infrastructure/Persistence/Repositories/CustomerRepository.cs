using METROAssignment.Domain.Models;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;

namespace METROAssignment.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MetroDbContext dbContext) : base(dbContext)
        {
        }
    }
}
