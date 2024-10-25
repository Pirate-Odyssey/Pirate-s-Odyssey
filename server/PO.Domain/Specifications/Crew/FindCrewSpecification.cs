namespace PO.Domain.Specifications.Crew
{
    public class FindCrewSpecification : Specification<Entities.Crew>
    {
        public FindCrewSpecification()
        {
            Criteria = equipment => 1 == 1;
        }
    }
}
