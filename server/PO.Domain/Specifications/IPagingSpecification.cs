namespace PO.Domain.Specifications
{
    public interface IPagingSpecification
    {
        public int Skip { get; }
        public int Take { get; }
        public bool IsPagingEnabled { get; }

        public void ApplyPaging(int skip, int take);
    }

}
