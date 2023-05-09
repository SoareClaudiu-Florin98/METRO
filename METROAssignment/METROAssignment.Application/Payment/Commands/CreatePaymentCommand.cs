using MediatR;

namespace METROAssignment.Application.Payment.Commands
{
    public class CreatePaymentCommand : IRequest
    {
        public int? Amount { get; set; }

        public CreatePaymentCommand(int? amount)
        {
            Amount = amount;
        }
    }
}
