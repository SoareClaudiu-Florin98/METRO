using AutoMapper;
using MediatR;
using METROAssignment.Contracts.Article.Responses;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace METROAssignment.Application.Article.Queries
{
    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, IEnumerable<ArticleResponseDto>>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public GetArticlesQueryHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArticleResponseDto>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetAll().ToListAsync();

            return article.Select(article => _mapper.Map<ArticleResponseDto>(article));
        }
    }
}
