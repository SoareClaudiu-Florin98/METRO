using MediatR;

namespace METROAssignment.Application.Article.Commands
{
    public class CreateArticleCommand : IRequest
    {
        public string? Name { get; set; }
        public int? Inventory { get; set; }

        public CreateArticleCommand(string? name, int? inventory)
        {
            Name = name;
            Inventory = inventory;
        }
    }
}
