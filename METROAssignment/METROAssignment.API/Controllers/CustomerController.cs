using MediatR;
using METROAssignment.Application.Customer.Commands;
using METROAssignment.Application.Customer.Queries;
using METROAssignment.Contracts.Customer.Requests;
using METROAssignment.Contracts.Customer.Responses;
using Microsoft.AspNetCore.Mvc;

namespace METROAssignment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponseDto>>> Get()
        {
            var customers = await _mediator.Send(new GetCustomersQuery());

            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer([FromBody] CreateCustomerRequestDto request)
        {
            await _mediator.Send(new CreateCustomerCommand(request.FirstName, request.LastName));

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer([FromBody] UpdateCustomerRequestDto request, int id)
        {
            await _mediator.Send(new UpdateCustomerCommand(id, request.FirstName, request.LastName));

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            await _mediator.Send(new DeleteCustomerCommand(id));

            return Ok();
        }
    }
}
