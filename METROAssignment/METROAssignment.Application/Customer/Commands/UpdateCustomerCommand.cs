using MediatR;

namespace METROAssignment.Application.Customer.Commands
{
    public class UpdateCustomerCommand : IRequest
    {
        public UpdateCustomerCommand(int id, string? firstName, string? lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Id { get; set; }
    }
}
