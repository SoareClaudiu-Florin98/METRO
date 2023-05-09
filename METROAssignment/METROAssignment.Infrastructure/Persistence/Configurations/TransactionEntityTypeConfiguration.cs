using METROAssignment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace METROAssignment.Infrastructure.Persistence.Configurations
{
    internal class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");

            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasMany(u => u.TransactionArticles)
                .WithOne(c => c.Transaction)
                .HasForeignKey(k => k.TransactionId);
        }
    }
}
