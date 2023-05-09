using MediatR;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;

namespace METROAssignment.Application.Article.Commands
{
    internal class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;

        public UpdateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            await _articleRepository.UpdateAsync(new Domain.Models.Article
            {
                Id = request.Id,
                Name = request.Name,
                Inventory = request.Inventory,
            });
        }
    }
}
