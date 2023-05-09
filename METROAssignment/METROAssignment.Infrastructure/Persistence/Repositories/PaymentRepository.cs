using METROAssignment.Domain.Models;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;

namespace METROAssignment.Infrastructure.Persistence.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(MetroDbContext dbContext) : base(dbContext)
        {
        }

        public async Task ProcessPaymentsAsync(IEnumerable<int> paymentIds)
        {
            var payments = _dbContext.Set<Payment>().Where(payment => paymentIds.Contains(payment.Id));

            foreach (var payment in payments)
            {
                payment.IsProcessed = true;
            }

            _dbContext.Set<Payment>().UpdateRange(payments);

            await _dbContext.SaveChangesAsync();
        }
    }
}
