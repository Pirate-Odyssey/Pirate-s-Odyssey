using System.Linq.Expressions;

namespace PO.Domain.Specifications
{
    public abstract class Specification<T> : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Criteria { get; protected set; }

        public List<Expression<Func<T, object>>> Includes { get; private set; } = [];

        public int Skip { get; private set; }

        public int Take { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        public string OrderBy { get; private set; }

        public bool OrderByDescending { get; private set; }

        public void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

        public void AddOrderBy(string orderBy, bool descending = false)
        {
            OrderBy = orderBy;
            OrderByDescending = descending;
        }

        public void AddInclude(Expression<Func<T, object>> expression)
        {
            Includes.Add(expression);
        }
    }
}
