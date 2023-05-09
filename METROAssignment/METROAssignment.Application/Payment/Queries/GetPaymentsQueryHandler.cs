using AutoMapper;
using MediatR;
using METROAssignment.Contracts.Payment.Responses;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace METROAssignment.Application.Payment.Queries
{
    public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQuery, IEnumerable<PaymentResponseDto>>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public GetPaymentsQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentResponseDto>> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentRepository.GetAll().ToListAsync();

            return payments.Select(payment => _mapper.Map<PaymentResponseDto>(payment));
        }
    }
}
