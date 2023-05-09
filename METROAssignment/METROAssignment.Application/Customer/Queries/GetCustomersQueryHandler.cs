using AutoMapper;
using MediatR;
using METROAssignment.Contracts.Customer.Responses;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace METROAssignment.Application.Customer.Queries
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerResponseDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerResponseDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAll().ToListAsync();

            return customers.Select(customer => _mapper.Map<CustomerResponseDto>(customer));
        }
    }
}
