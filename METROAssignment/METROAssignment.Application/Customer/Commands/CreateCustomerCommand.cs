using MediatR;

namespace METROAssignment.Application.Customer.Commands
{
    public class CreateCustomerCommand : IRequest
    {
        public CreateCustomerCommand(string? firstName, string? lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
