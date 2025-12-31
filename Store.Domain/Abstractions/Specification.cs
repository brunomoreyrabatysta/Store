using System.Linq.Expressions;

namespace Store.Domain.Abstractions;

public abstract class Specification<T> : ISpecification<T>
{
    public bool IsSatisfiedBy(T entity)
    {
        var predicate = ToExpression().Compile();
        return predicate(entity);
    }

    public abstract Expression<Func<T, bool>> ToExpression();
}
