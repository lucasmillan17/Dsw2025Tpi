using Dsw2025Tpi.Application.Services;
using Dsw2025Tpi.Application.Services.Interfaces;
using Dsw2025Tpi.Data;
using Dsw2025Tpi.Data.Repositories;
using Dsw2025Tpi.Data.Helpers;
using Dsw2025Tpi.Data.Repositories.Interfaces;
using Dsw2025Tpi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Dsw2025Tpi.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<IOrderService,OrderService>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IRepository, EfRepository>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddDbContext<Dsw2025TpiContext>(options => {
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Dsw2025Db;Integrated Security=True;");
        });

        
        builder.Services.AddSwaggerGen();
        builder.Services.AddHealthChecks();

        var app = builder.Build();
        //Agrego los clientes a la db
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<Dsw2025TpiContext>();
            context.Seedwork<Customer>("Resources/clients.json");
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        
        app.MapHealthChecks("/healthcheck");

        app.Run();
    }
}
