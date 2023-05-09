using METROAssignment.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace METROAssignment.Infrastructure.Persistence
{
    public class MetroDbContext : DbContext
    {
        public MetroDbContext(DbContextOptions<MetroDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionArticles> TransactionArticles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        }
    }
}
