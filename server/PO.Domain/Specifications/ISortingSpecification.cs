namespace PO.Domain.Specifications
{
    public interface ISortingSpecification
    {
        public string OrderBy { get; }
        public bool OrderByDescending { get; }

        public void AddOrderBy(string orderBy, bool descending = false);
    }

}
