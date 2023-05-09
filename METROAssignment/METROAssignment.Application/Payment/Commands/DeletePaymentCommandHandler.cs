using MediatR;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;

namespace METROAssignment.Application.Payment.Commands
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand>
    {
        private readonly IPaymentRepository _paymentRepository;

        public DeletePaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.FindByIdAsync(request.Id);

            if (payment is not null)
            {
                await _paymentRepository.DeleteAsync(payment);
            }
            else
            {
                throw new Exception("Payment not found");
            }
        }
    }
}
