namespace PO.Domain.Specifications.CrewMember
{
    public class FindCrewMemberByIdSpecification : Specification<Entities.CrewMember>
    {
        public FindCrewMemberByIdSpecification(Guid equipmentId)
        {
            Criteria = equipment => equipment.Id == equipmentId;
        }
    }
}
