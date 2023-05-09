using MediatR;
using METROAssignment.Contracts.Customer.Responses;

namespace METROAssignment.Application.Customer.Queries
{
    public class GetCustomersQuery : IRequest<IEnumerable<CustomerResponseDto>>
    {
    }
}
