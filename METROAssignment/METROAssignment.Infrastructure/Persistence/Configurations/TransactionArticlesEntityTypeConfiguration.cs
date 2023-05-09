using METROAssignment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;

namespace METROAssignment.Infrastructure.Persistence.Configurations
{
    internal class TransactionArticlesEntityTypeConfiguration : IEntityTypeConfiguration<TransactionArticles>
    {
        public void Configure(EntityTypeBuilder<TransactionArticles> builder)
        {
            builder.ToTable("TransactionArticles");
            builder.HasKey(o => new { o.ArticleId, o.TransactionId});

            builder
                .HasOne(u => u.Article)
                .WithMany(l => l.TransactionArticles)
                .HasForeignKey(u => u.ArticleId);

            builder
                .HasOne(u => u.Transaction)
                .WithMany(l => l.TransactionArticles)
                .HasForeignKey(u => u.TransactionId);
        }
    }
}
