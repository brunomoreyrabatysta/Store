using Store.Domain.Abstractions;
using Store.Domain.Entities;
using System.Linq.Expressions;

namespace Store.Domain.Specifications.Products;

public class GetProductByIdSpecification(Guid id) : Specification<Product>
{    

    public override Expression<Func<Product, bool>> ToExpression()
        => product => product.Id == id;
}
