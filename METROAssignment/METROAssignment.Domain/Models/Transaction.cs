namespace METROAssignment.Domain.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<TransactionArticles>? TransactionArticles { get; set; }
    }
}
