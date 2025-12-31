using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Application;
using Store.Infrastructure;
using Store.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Store.Api")));

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.MapGet("v1/products/{id}", async (
    ISender sender,
    Guid id,
    CancellationToken cancellationToken) =>
{
    var query = new Store.Application.UseCases.Products.GetById.Command(id);
    var result = await sender.Send(query, cancellationToken);

    return result.IsSuccess
        ? Results.Ok(result.Value)
        : Results.BadRequest(result.Error);
});

app.MapPost("v1/products", async (
    ISender sender,
    Store.Application.UseCases.Products.Create.Command command,
    CancellationToken cancellationToken) =>
{
    var result = await sender.Send(command, cancellationToken);

    return result.IsSuccess
        ? Results.Ok(result.Value)
        : Results.BadRequest(result.Error);
});

app.Run();
