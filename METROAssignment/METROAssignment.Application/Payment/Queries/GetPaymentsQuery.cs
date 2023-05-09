using MediatR;
using METROAssignment.Contracts.Payment.Responses;

namespace METROAssignment.Application.Payment.Queries
{
    public class GetPaymentsQuery : IRequest<IEnumerable<PaymentResponseDto>>
    {
    }
}
