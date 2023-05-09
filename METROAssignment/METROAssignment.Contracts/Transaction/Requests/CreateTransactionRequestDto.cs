using System.ComponentModel.DataAnnotations;

namespace METROAssignment.Contracts.Transaction.Requests
{
    public class CreateTransactionRequestDto
    {
        public IEnumerable<int>? ArticleIds { get; set; }
        public IEnumerable<int>? PaymentIds { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
    }
}
