using METROAssignment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace METROAssignment.Infrastructure.Persistence.Configurations
{
    internal class PaymentEntityTypeConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment");

            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
            builder.Property(x => x.IsProcessed).HasDefaultValue(false);
        }
    }
}
