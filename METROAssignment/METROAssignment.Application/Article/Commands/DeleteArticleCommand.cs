using MediatR;

namespace METROAssignment.Application.Article.Commands
{
    public class DeleteArticleCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteArticleCommand(int id)
        {
            Id = id;
        }
    }
}
