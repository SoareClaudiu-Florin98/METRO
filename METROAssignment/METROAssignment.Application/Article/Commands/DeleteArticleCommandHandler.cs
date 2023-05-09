using MediatR;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;

namespace METROAssignment.Application.Article.Commands
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;

        public DeleteArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.FindByIdAsync(request.Id);

            if (article is not null)
            {
                await _articleRepository.DeleteAsync(article);
            }
            else
            {
                throw new Exception("Article not found");
            }
        }
    }
}
