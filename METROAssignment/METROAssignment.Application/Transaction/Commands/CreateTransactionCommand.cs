using MediatR;

namespace METROAssignment.Application.Transaction.Commands
{
    public class CreateTransactionCommand : IRequest
    {
        public string? Description { get; set; }
        public IEnumerable<int>? ArticleIds { get; set; }
        public IEnumerable<int>? PaymentIds { get; set; }

        public CreateTransactionCommand(string? description,
            IEnumerable<int>? articleIds,
            IEnumerable<int>? paymentIds)
        {
            Description = description;
            ArticleIds = articleIds;
            PaymentIds = paymentIds;
        }
    }
}
