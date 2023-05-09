namespace METROAssignment.Domain.Models
{
    public class TransactionArticles
    {
        public virtual int ArticleId { get; set; }
        public virtual Article? Article { get; set; }
        public virtual int TransactionId { get; set; }
        public virtual Transaction? Transaction { get; set; }
    }
}
