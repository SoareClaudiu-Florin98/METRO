using MediatR;

namespace METROAssignment.Application.Payment.Commands
{
    public class DeletePaymentCommand : IRequest
    {
        public int Id { get; set; }

        public DeletePaymentCommand(int id)
        {
            Id = id;
        }
    }
}
