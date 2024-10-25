namespace PO.Domain.Specifications.CrewMember
{
    public class FindCrewMemberSpecification : Specification<Entities.CrewMember>
    {
        public FindCrewMemberSpecification()
        {
            Criteria = equipment => 1 == 1;
        }
    }
}
