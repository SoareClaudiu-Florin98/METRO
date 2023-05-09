using MediatR;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;

namespace METROAssignment.Application.Customer.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerRepository.InsertAsync(new Domain.Models.Customer
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
            });
        }
    }
}
