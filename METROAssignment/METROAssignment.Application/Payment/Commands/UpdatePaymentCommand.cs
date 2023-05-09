using MediatR;

namespace METROAssignment.Application.Payment.Commands
{
    public class UpdatePaymentCommand : IRequest
    {
        public int Id { get; set; }
        public int? Amount { get; set; }

        public UpdatePaymentCommand(int id, int? amount)
        {
            Id = id;
            Amount = amount;
        }
    }
}
