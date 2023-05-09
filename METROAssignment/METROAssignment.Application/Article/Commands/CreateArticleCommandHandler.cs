using MediatR;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;

namespace METROAssignment.Application.Article.Commands
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;

        public CreateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name)) throw new InvalidOperationException("Name cannot be empty.");
            if (request.Inventory < 0) throw new InvalidOperationException("Inventory cannot be a negative number.");

            await _articleRepository.InsertAsync(new Domain.Models.Article
            {
                Name = request.Name,
                Inventory = request.Inventory,
            });
        }
    }
}
