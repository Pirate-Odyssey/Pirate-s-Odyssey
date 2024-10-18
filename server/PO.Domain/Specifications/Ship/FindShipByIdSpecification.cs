namespace PO.Domain.Specifications.Ship
{
    public class FindShipByIdSpecification : Specification<Entities.Ship>
    {
        public FindShipByIdSpecification(Guid shipId)
        {
            Criteria = ship => ship.Id == shipId;
        }
    }
}
