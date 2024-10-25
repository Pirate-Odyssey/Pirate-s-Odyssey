namespace PO.Domain.Specifications.Crew
{
    public class FindCrewByIdSpecification : Specification<Entities.Crew>
    {
        public FindCrewByIdSpecification(Guid equipmentId)
        {
            Criteria = equipment => equipment.Id == equipmentId;
        }
    }
}
