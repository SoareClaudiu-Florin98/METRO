using MediatR;
using METROAssignment.Application.Customer.Commands;
using METROAssignment.Application.Transaction.Commands;
using METROAssignment.Contracts.Customer.Requests;
using METROAssignment.Contracts.Transaction.Requests;
using Microsoft.AspNetCore.Mvc;

namespace METROAssignment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTransaction([FromBody] CreateTransactionRequestDto request)
        {
            await _mediator.Send(new CreateTransactionCommand(request.Description, request.ArticleIds, request.PaymentIds));

            return Ok();
        }
    }
}
