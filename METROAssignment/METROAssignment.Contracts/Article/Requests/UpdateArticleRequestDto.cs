using System.ComponentModel.DataAnnotations;

namespace METROAssignment.Contracts.Article.Requests
{
    public class UpdateArticleRequestDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int? Inventory { get; set; }
    }
}
