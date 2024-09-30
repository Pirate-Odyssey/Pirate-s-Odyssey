using System.Linq.Expressions;

namespace PO.Domain.Specifications
{
    public interface ISpecification<T> : IPagingSpecification, ISortingSpecification where T : class
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }

}
