using MediatR;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;

namespace METROAssignment.Application.Payment.Commands
{
    public class CreatePaymentCommandHnadler : IRequestHandler<CreatePaymentCommand>
    {
        private readonly IPaymentRepository _paymentRepository;

        public CreatePaymentCommandHnadler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            await _paymentRepository.InsertAsync(new Domain.Models.Payment
            {
                Amount = request.Amount

            });
        }
    }
}
