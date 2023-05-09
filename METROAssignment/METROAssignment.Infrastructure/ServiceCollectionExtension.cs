using METROAssignment.Infrastructure.Persistence;
using METROAssignment.Infrastructure.Persistence.Repositories;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace METROAssignment.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddDbContext<MetroDbContext>(options => options
            .UseSqlServer(configuration.GetSection("SqlDB").GetValue<string>("ConnectionString"),
            x => x.MigrationsAssembly("METROAssignment.Database")));

            return services;
        }
    }
}
