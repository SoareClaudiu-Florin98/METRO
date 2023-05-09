using METROAssignment.Domain.Models;

namespace METROAssignment.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IPaymentRepository: IRepository<Payment>
    {
        Task ProcessPaymentsAsync(IEnumerable<int> paymentIds);
    }
}
