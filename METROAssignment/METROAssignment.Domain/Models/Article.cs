namespace METROAssignment.Domain.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Inventory { get; set; }
        public virtual ICollection<TransactionArticles>? TransactionArticles { get; set; }

    }
}
