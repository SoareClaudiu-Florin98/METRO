using MediatR;

namespace METROAssignment.Application.Customer.Commands
{
    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
