namespace MyRock.Infrastructure.Extensions
{
    public static class SpecificationExtension
    {
        public static IQueryable<T> Specify<T>(this IQueryable<T> query, ISpecification<T> spec) where T : class
        {
            // remove tracking
            query = query.AsNoTracking();

            // condition
            query = query.Where(spec.Criteria);

            // fetch a Queryable that includes all expression-based includes
            query = spec.Includes
                .Aggregate(query,
                    (current, include) => current.Include(include));

            // sorting
            if (spec.OrderBy != null)
            {
                query = spec.OrderByDescending
                    ? query.OrderByDescending(e => EF.Property<object>(e, spec.OrderBy))
                    : query.OrderBy(e => EF.Property<object>(e, spec.OrderBy));
            }

            // paging
            if (spec.IsPagingEnabled)
            {
                query = query
                .Skip(spec.Skip)
                .Take(spec.Take);
            }

            return query;
        }
    }
}
