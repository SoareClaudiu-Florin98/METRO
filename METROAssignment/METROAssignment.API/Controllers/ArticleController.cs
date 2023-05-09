using MediatR;
using METROAssignment.Application.Article.Commands;
using METROAssignment.Application.Article.Queries;
using METROAssignment.Contracts.Article.Requests;
using METROAssignment.Contracts.Article.Responses;
using Microsoft.AspNetCore.Mvc;

namespace METROAssignment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : Controller
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleResponseDto>>> Get()
        {
            var articles = await _mediator.Send(new GetArticlesQuery());

            return Ok(articles);
        }

        [HttpPost]
        public async Task<ActionResult> CreateArticle([FromBody] CreateArticleRequestDto request)
        {
            await _mediator.Send(new CreateArticleCommand(request.Name, request.Inventory));

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArticle([FromBody] UpdateArticleRequestDto request, int id)
        {
            await _mediator.Send(new UpdateArticleCommand(id, request.Name, request.Inventory));

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            await _mediator.Send(new DeleteArticleCommand(id));

            return Ok();
        }
    }
}
