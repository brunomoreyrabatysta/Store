using MediatR;
using Store.Application.UseCases.Products.GetById;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Products.Create;

public sealed record Command(string Title) : IRequest<Result<Response>>;
