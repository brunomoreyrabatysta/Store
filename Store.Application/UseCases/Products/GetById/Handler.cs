using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;
using Store.Domain.Specifications.Products;

namespace Store.Application.UseCases.Products.GetById;

public sealed class Handler(IProductRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var spec = new GetProductByIdSpecification(request.Id);
        var product = await repository.GetByIdAsync(spec, cancellationToken);
        if (product is null)
        {
            return Result.Failure<Response>(new Error("404", "Product Not Found"));
        }
        var response = new Response(product.Id, product.Title);
        return Result<Response>.Success<Response>(response);
    }
}
