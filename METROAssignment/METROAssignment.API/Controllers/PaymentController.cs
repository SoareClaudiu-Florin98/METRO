using MediatR;
using METROAssignment.Application.Payment.Commands;
using METROAssignment.Application.Payment.Queries;
using METROAssignment.Contracts.Payment.Requests;
using METROAssignment.Contracts.Payment.Responses;
using Microsoft.AspNetCore.Mvc;

namespace METROAssignment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentResponseDto>>> Get()
        {
            var payments = await _mediator.Send(new GetPaymentsQuery());

            return Ok(payments);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePayment([FromBody] CreatePaymentRequestDto request)
        {
            await _mediator.Send(new CreatePaymentCommand(request.Amount));

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePayment([FromBody] UpdatePaymentRequestDto request, int id)
        {
            await _mediator.Send(new UpdatePaymentCommand(id, request.Amount));

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePayment(int id)
        {
            await _mediator.Send(new DeletePaymentCommand(id));

            return Ok();
        }
    }
}
