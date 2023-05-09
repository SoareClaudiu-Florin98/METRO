using METROAssignment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace METROAssignment.Infrastructure.Persistence.Configurations
{
    internal class ArticleEntityTypeConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Article");

            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasMany(u => u.TransactionArticles)
                .WithOne(c => c.Article)
                .HasForeignKey(k => k.ArticleId);
        }
    }
}
