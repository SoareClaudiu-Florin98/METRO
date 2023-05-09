using MediatR;

namespace METROAssignment.Application.Article.Commands
{
    public class UpdateArticleCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Inventory { get; set; }


        public UpdateArticleCommand(int id, string? name, int? inventory)
        {
            Name = name;
            Id = id;
            Inventory = inventory;
        }
    }
}
