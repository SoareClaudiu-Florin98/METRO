using MediatR;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;

namespace METROAssignment.Application.Transaction.Commands
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IPaymentRepository _paymentRepository;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IPaymentRepository paymentRepository)
        {
            _transactionRepository = transactionRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Domain.Models.Transaction
            {
                Description = request.Description,
            };

            if (request.ArticleIds is not null)
            {
                await _transactionRepository.InsertTransactionWithArticlesAsync(transaction, request.ArticleIds);
            }
            else
            {
                await _transactionRepository.InsertAsync(transaction);
            }

            if (request.PaymentIds is not null)
            {
                await _paymentRepository.ProcessPaymentsAsync(request.PaymentIds);
            }

        }
    }
}
