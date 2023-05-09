using MediatR;
using METROAssignment.Contracts.Article.Responses;

namespace METROAssignment.Application.Article.Queries
{
    public class GetArticlesQuery : IRequest<IEnumerable<ArticleResponseDto>>
    {
    }
}
