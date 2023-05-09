using METROAssignment.API.Configuration;
using METROAssignment.Application;
using METROAssignment.Infrastructure;
using METROAssignment.Infrastructure.Persistence;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var _configuration = ConfigurationHelper.GetConfiguration().Build();
builder.Configuration.AddConfiguration(_configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMediatR((configuration) =>
{
    configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

builder.Services.AddInfrastructure(_configuration);
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using var scope = app.Services.CreateScope();

    var context = scope.ServiceProvider.GetRequiredService<MetroDbContext>();
    context.Database.Migrate();
}

app.UseExceptionHandler(options =>
{
    options.Run(async context =>
    {
        context.Response.StatusCode = 500;
        var ex = context.Features.Get<IExceptionHandlerFeature>();

        if (ex != null)
        {
            await context.Response.WriteAsync(ex.Error.Message);
        }
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
